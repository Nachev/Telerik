namespace Cars.Tests.JustMock.Mocks
{
    using System.Linq;
    using Cars.Contracts;
    using Cars.Models;
    using Moq;

    public class MoqCarsRepository : CarRepositoryMock, ICarsRepositoryMock
    {
        protected override void ArrangeCarsRepositoryMock()
        {
            var mockedCarsRepository = new Mock<ICarsRepository>();
            Car NullCar = null;
            mockedCarsRepository.Setup(r => r.Add(It.IsAny<Car>())).Verifiable();
            mockedCarsRepository.Setup(r => r.All()).Returns(this.FakeCarCollection);
            mockedCarsRepository.Setup(r => r.Search(It.IsAny<string>())).Returns(this.FakeCarCollection.Where(c => c.Make == "BMW").ToList());
            mockedCarsRepository.Setup(r => r.SortedByMake()).Returns(this.FakeCarCollection.ToList());
            mockedCarsRepository.Setup(r => r.SortedByYear()).Returns(this.FakeCarCollection.ToList());
            mockedCarsRepository.Setup(r => r.GetById(It.Is<int>(id => id < 0))).Returns(NullCar);
            mockedCarsRepository.Setup(r => r.GetById(It.Is<int>(id => id > 0))).Returns(this.FakeCarCollection.First());
            this.CarsData = mockedCarsRepository.Object;
        }
    }
}
