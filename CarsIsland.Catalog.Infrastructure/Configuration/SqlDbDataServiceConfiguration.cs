using CarsIsland.Catalog.Infrastructure.Configuration.Interfaces;
using Microsoft.Extensions.Options;
using System;

namespace CarsIsland.Catalog.Infrastructure.Configuration
{
    public class SqlDbDataServiceConfiguration : ISqlDbDataServiceConfiguration
    {
        public string ConnectionString { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    public class SqlDbDataServiceConfigurationValidation : IValidateOptions<SqlDbDataServiceConfiguration>
    {
        public ValidateOptionsResult Validate(string name, SqlDbDataServiceConfiguration options)
        {
            if (string.IsNullOrEmpty(options.ConnectionString))
            {
                return ValidateOptionsResult.Fail($"{nameof(options.ConnectionString)} configuration parameter for the Azure SQL is required");
            }

            return ValidateOptionsResult.Success;
        }
    }
}
