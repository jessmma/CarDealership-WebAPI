using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarDealershipProject.Core.Domain.Content;

namespace CarDealershipProject.Services.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> SearchCarsAsync(CarSearchRequest carSearchRequest);
    }
}
