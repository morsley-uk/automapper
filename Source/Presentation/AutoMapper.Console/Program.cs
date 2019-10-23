using System;
using System.Drawing;
using AutoMapper.Domain.Enumerations;
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
            var domainEntity = new AutoMapper.Domain.Models.DomainEntity("John Doe")
            {
                Id = Guid.NewGuid(),
                Title = Title.Mr,
                Sex = Sex.Male
            };

            // Get AutoMapper to automatically perform the mapping...
            var consoleEntity = autoMapper.Map<AutoMapper.Domain.Models.DomainEntity,
                                               AutoMapper.Console.Models.ConsoleEntity>(domainEntity);
        }
    }
}
