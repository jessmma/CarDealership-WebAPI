using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarDealershipProject.Core.Domain.Content;
using CarDealershipProject.Repositories.Interfaces;
using CarDealershipProject.Services.Interfaces;

namespace CarDealershipProject.Services.Implementations
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;

        }

        public async Task<IEnumerable<Car>> SearchCarsAsync(CarSearchRequest carSearchRequest)
        {
            var result = await _carRepository.SearchCars(carSearchRequest);
            return result;
        }
    }
}
