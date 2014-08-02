namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Cars.Contracts;
    using Cars.Controllers;
    using Cars.Models;
    using Cars.Tests.JustMock.Mocks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CarsControllerSearchMethodTests
    {
        private ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerSearchMethodTests() : this(new MoqCarsRepository())
        {
        }

        public CarsControllerSearchMethodTests(ICarsRepositoryMock carsControllerMock)
        {
            this.carsData = carsControllerMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        public void SearchMethodCarShouldReturnACarViewList()
        {
            string messageFormat = "Incorrect value for {0} returned";
            var car = new Car
            {
                Id = 2,
                Make = "BMW",
                Model = "325i",
                Year = 2008
            };

            var modelList = (ICollection<Car>)this.GetModel(() => this.controller.Search("No mather what"));
            var model = modelList.FirstOrDefault();

            Assert.AreEqual(car.Id, model.Id, messageFormat, "Id");
            Assert.AreEqual(car.Make, model.Make, messageFormat, "Make");
            Assert.AreEqual(car.Model, model.Model, messageFormat, "Model");
            Assert.AreEqual(car.Year, model.Year, messageFormat, "Year");
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
