using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarDealershipProject.Core.Domain.Content;

namespace CarDealershipProject.Repositories.Interfaces
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> SearchCars(CarSearchRequest carSearchRequest);
    }
}
