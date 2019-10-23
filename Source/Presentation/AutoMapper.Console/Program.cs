using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace AutoMapper.Console
{
    class Program
    {
        static void Main()
        {
            System.Console.WriteLine("Hello, AutoMapper!");

            // Set up DI in our console app...
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var serviceProvider = new ServiceCollection().AddAutoMapper(assemblies)
                                                         .BuildServiceProvider();

            // Get a handle on out MediatR instance via DI...
            var autoMapper = serviceProvider.GetService<IMapper>();

            // Create the source entity...
            var domainEntity = new AutoMapper.Domain.Models.DomainEntity
            {
                Id = Guid.NewGuid()
            };

            // Get AutoMapper to automatically perform the mapping...
            var consoleEntity = autoMapper.Map<AutoMapper.Domain.Models.DomainEntity,
                                               AutoMapper.Console.Models.ConsoleEntity>(domainEntity);
        }
    }
}
