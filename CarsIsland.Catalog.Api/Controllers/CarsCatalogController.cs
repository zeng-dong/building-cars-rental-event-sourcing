using CarsIsland.Catalog.Domain.Model;
using CarsIsland.Catalog.Infrastructure.Repositories;
using CarsIsland.Catalog.Infrastructure.Services.Integration.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CarsIsland.Catalog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsCatalogController : ControllerBase
    {
        private readonly CarCatalogDbContext _carCatalogDbContext;
        private readonly ICatalogIntegrationEventService _catalogIntegrationEventService;

        public CarsCatalogController(CarCatalogDbContext carCatalogDbContext,
                                     ICatalogIntegrationEventService catalogIntegrationEventService)
        {
            _carCatalogDbContext = carCatalogDbContext;
            _catalogIntegrationEventService = catalogIntegrationEventService;
        }

        [ProducesResponseType(typeof(IReadOnlyList<Car>), (int)HttpStatusCode.OK)]
        [HttpGet]
        public async Task<IActionResult> GetAllCarsAsync()
        {
            var cars = await _carCatalogDbContext.Cars.ToListAsync();
            return Ok(cars);
        }

        [ProducesResponseType(typeof(Car), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarAsync(Guid id)
        {
            var car = await _carCatalogDbContext.Cars.SingleOrDefaultAsync(i => i.Id == id);
            if (car == null)
            {
                return NotFound(new { Message = $"Car with id {id} not found." });
            }
            return Ok(car);
        }

        [ProducesResponseType(typeof(Car), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpPost]
        public async Task<IActionResult> AddCarAsync([FromBody] Car car)
        {
            var addedCar = _carCatalogDbContext.Add(car);
            await _carCatalogDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCarAsync), new { id = addedCar.Entity.Id });
        }


    }
}
