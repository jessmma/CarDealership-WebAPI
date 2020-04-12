using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CarDealershipProject.Core.Domain.Content;
using CarDealershipProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarDealershipProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class CarController : ControllerBase
    {
       private readonly IMapper _mapper;
       private readonly ICarService _carService;

       public CarController(ICarService carService, IMapper mapper)
            {
                _carService = carService;
                _mapper = mapper;
            }
        [HttpPost("search")]
        //ActionResult is going to return an http response, i.e. 200, 401, 500, etc and inside of the response is going to return
        //a list of Cars
        public async Task<IActionResult> SearchCars([FromBody]CarDealershipProject.Models.CarSearchRequest carSearchRequest)
        {
            var request = _mapper.Map<CarSearchRequest>(carSearchRequest);
            var domainResult = await _carService.SearchCarsAsync(request);
            var result = _mapper.Map<IEnumerable<CarDealershipProject.Models.Car>>(domainResult);

             return Ok(result);
            }

        }
    
}
