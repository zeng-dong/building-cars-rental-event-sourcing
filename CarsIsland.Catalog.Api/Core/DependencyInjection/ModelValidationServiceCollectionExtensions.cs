using CarsIsland.Catalog.Api.Infrastructure.Validators;
using CarsIsland.Catalog.Domain.Model;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CarsIsland.Catalog.Api.Core.DependencyInjection
{
    public static class ModelValidationServiceCollectionExtensions
    {
        public static IServiceCollection AddModelValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<Car>, CarValidator>();
            return services;
        }
    }
}
