using CarsIsland.Catalog.Infrastructure.Repositories;
using CarsIsland.Catalog.Infrastructure.Services.Integration.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
    }
}
