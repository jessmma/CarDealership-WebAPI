using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ploeh.AutoFixture;
using AutoMapper;
using CarDealershipProject.Controllers;
using CarDealershipProject.Core.Domain.Content;
using CarDealershipProject.Mapping;
using CarDealershipProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace CarDealershipProject.Test.Controllers
{
    [TestFixture]
    public class CarControllerTests
    {
        private Mock<ICarService> _carService;
        private IFixture _fixture;
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            _carService = new Mock<ICarService>();
            _fixture = new Fixture();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile(new DealershipMappingProfile());
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Test]
        public async Task SearchCars_returns_IEnumerableCar()
        {
            //Arange

            var request = _fixture.Create<CarDealershipProject.Models.CarSearchRequest>();
            _carService.Setup(xy => xy.SearchCarsAsync(It.IsAny<CarSearchRequest>())).ReturnsAsync(_fixture.Create<IEnumerable<Car>>);
            var controller = new CarController(_carService.Object, _mapper);

            //Act
            var result = await controller.SearchCars(request);
            var okResult = result as OkObjectResult;

            //Assert
            Assert.IsInstanceOf<List<Models.Car>>(okResult.Value);
        }
    }
}
