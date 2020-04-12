using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarDealershipProject.Core.Domain;
using CarDealershipProject.Core.Domain.Content;
using CarDealershipProject.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using Dapper;
namespace CarDealershipProject.Repositories.Implementations
{
    public class CarRepository : AbstractSQLRepository, ICarRepository
    {
        public CarRepository(IOptionsSnapshot<ServiceOptions> serviceOptions) : base(serviceOptions)
        {
        }

        public async Task<IEnumerable<Car>> SearchCars(CarSearchRequest carSearchRequest)
        {
            try
            {
                string query;
                //Build the query you need
                if (carSearchRequest.IsEmpty)
                {
                    query = @"SELECT * FROM Car";
                }
                else
                {
                    query = BuildSearchCar(carSearchRequest);
                }
                //Execute the query
                var result = await QueryAsync<Car>(query, carSearchRequest);
                return result;
            }
            catch (Exception e)
            {
                return new List<Car>();
            }


        }

        private string BuildSearchCar(CarSearchRequest carSearchRequest)
        {
            var builder = new SqlBuilder();
            var selector = builder.AddTemplate("select * from car /**where**/");

            if (!carSearchRequest.IsEmpty)
            {
                //query += " WHERE ";
            }
            if (carSearchRequest.color != null)
            {
                //query += "color= @color";
                builder.Where("color = @color", new { carSearchRequest.color });
            }
            if (carSearchRequest.hasSunRoof != null)
            {
                //query += " hasSunRoof = @hasSunRoof ";
                builder.Where("hasSunRoof = @hasSunRoof", new { carSearchRequest.hasSunRoof });
            }
            if (carSearchRequest.isFourWheelDrive != null)
            {
                //query += "isFourWheelDrive = @isFourWheelDrive AND ";
                builder.Where("isFourWheelDrive = @isFourWheelDrive", new { carSearchRequest.isFourWheelDrive });
            }
            if (carSearchRequest.hasLowMiles != null)
            {
                //query += "hasLowMiles = @hasLowMiles AND ";
                builder.Where("hasLowMiles = @hasLowMiles", new { carSearchRequest.hasLowMiles });
            }
            if (carSearchRequest.hasPowerWindows != null)
            {
                //query += "hasPowerWindows = @hasPowerWindows AND ";
                builder.Where("hasPowerWindows = @hasPowerWindows", new { carSearchRequest.hasPowerWindows });
            }
            if (carSearchRequest.hasNavigation != null)
            {
                //query += "hasNavigation = @hasNavigation AND ";
                builder.Where("hasNavigation = @hasNavigation", new { carSearchRequest.hasNavigation });
            }
            if (carSearchRequest.hasHeatedSeats != null)
            {
                //query += "hasHeatedSeats = @hasHeatedSeats";
                builder.Where("hasHeatedSeats = @hasHeatedSeats", new { carSearchRequest.hasHeatedSeats });
            }
            return selector.RawSql;

        }
    }
}
