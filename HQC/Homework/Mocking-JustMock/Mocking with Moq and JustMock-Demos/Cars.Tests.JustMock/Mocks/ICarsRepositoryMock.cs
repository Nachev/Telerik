namespace Cars.Tests.JustMock.Mocks
{
    using System;
    using Cars.Contracts;

    public interface ICarsRepositoryMock
    {
        ICarsRepository CarsData { get; }
    }
}
