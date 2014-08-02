namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Cars.Contracts;
    using Cars.Controllers;
    using Cars.Models;
    using Cars.Tests.JustMock.Mocks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CarsControllerSortMethodTests
    {
        private ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerSortMethodTests()
            : this(new MoqCarsRepository())
        {
        }

        public CarsControllerSortMethodTests(ICarsRepositoryMock carsControllerMock)
        {
            this.carsData = carsControllerMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Incorrect key for sorting accepted!")]
        public void SortMethodWithInvalidKeyShouldThrowAnException()
        {
            var modelList = (ICollection<Car>)this.GetModel(() => this.controller.Sort("No mather what"));
        }

        [TestMethod]
        public void SortMethodByMakeShouldReturnACarViewList()
        {
            var expectedCarCollection = new List<Car>
            {
                new Car { Id = 1, Make = "Audi", Model = "A4", Year = 2005 },
                new Car { Id = 2, Make = "BMW", Model = "325i", Year = 2008 },
                new Car { Id = 3, Make = "BMW", Model = "330d", Year = 2007 },
                new Car { Id = 4, Make = "Opel", Model = "Astra", Year = 2010 },
            };

            var modelList = (List<Car>)this.GetModel(() => this.controller.Sort("make"));

            CollectionAssert.AllItemsAreInstancesOfType(expectedCarCollection, typeof(Car), "Expected collection does not contain types required!");
            Assert.AreEqual(expectedCarCollection.Count, modelList.Count, "Collections are not equal in length!");
            Assert.IsTrue(expectedCarCollection.SequenceEqual(modelList, new CarEqualityComparer()));
        }

        [TestMethod]
        public void SortMethodByYearShouldReturnACarViewList()
        {
            var expectedCarCollection = new List<Car>
            {
                new Car { Id = 1, Make = "Audi", Model = "A4", Year = 2005 },
                new Car { Id = 2, Make = "BMW", Model = "325i", Year = 2008 },
                new Car { Id = 3, Make = "BMW", Model = "330d", Year = 2007 },
                new Car { Id = 4, Make = "Opel", Model = "Astra", Year = 2010 },
            };

            var modelList = (List<Car>)this.GetModel(() => this.controller.Sort("year"));

            CollectionAssert.AllItemsAreInstancesOfType(expectedCarCollection, typeof(Car), "Expected collection does not contain types required!");
            Assert.AreEqual(expectedCarCollection.Count, modelList.Count, "Collections are not equal in length!");
            Assert.IsTrue(expectedCarCollection.SequenceEqual(modelList, new CarEqualityComparer()));
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
