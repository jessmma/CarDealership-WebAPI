using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ploeh.AutoFixture;
using CarDealershipProject.Repositories.Interfaces;
using CarDealershipProject.Services.Implementations;
using CarDealershipProject.Models;
using Moq;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;

namespace CarDealershipProject.Test.Services
{
    [TestFixture]
    public class CarServiceTests
    {
        private Mock<ICarRepository> _carRepository;
        private IFixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _carRepository = new Mock<ICarRepository>();
            _fixture = new Fixture();
        }

        [Test]
        public async Task SearchCarsAsync_returns_IEnumerableCar()
        {
            //Arange
            var cars = _fixture.CreateAnonymous<List<Core.Domain.Content.Car>>();
            var request = _fixture.Create<CarDealershipProject.Core.Domain.Content.CarSearchRequest>();
            _carRepository.Setup(xy => xy.SearchCars(It.IsAny<CarDealershipProject.Core.Domain.Content.CarSearchRequest>())).ReturnsAsync(cars);
            var service = new CarService(_carRepository.Object);

            //Act
            var result = await service.SearchCarsAsync(request);


            //Assert
            Assert.IsInstanceOf<List<Core.Domain.Content.Car>>(result);
        }
    }
}
