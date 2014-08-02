namespace Cars.Tests.JustMock
{
    using System;
    using Cars.Contracts;
    using Cars.Controllers;
    using Cars.Models;
    using Cars.Tests.JustMock.Mocks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CarsControllerDetailsMethodTests
    {
        private ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerDetailsMethodTests() : this(new MoqCarsRepository())
        {
        }

        public CarsControllerDetailsMethodTests(ICarsRepositoryMock carsControllerMock)
        {
            this.carsData = carsControllerMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Non existing car id is accepted wich is incorrect!")]
        public void DetailsMethodShouldThrowArgumentNullExceptionIfCarIdIsNotFound()
        {
            this.controller.Details(-1);
        }

        [TestMethod]
        public void DetailsMethodCarShouldReturnACarView()
        {
            var model = (Car)this.GetModel(() => this.controller.Details(1));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A4", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
