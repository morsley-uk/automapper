using System;
using AutoMapper.Console.Converters;
using AutoMapper.Console.Models;
using AutoMapper.Domain.Enumerations;
using AutoMapper.Domain.Models;
using FluentAssertions;
using Xunit;

namespace AutoMapper.UnitTests
{
    public class CustomTypeConverterUnitTests
    {
        [Fact]
        public void DomainEntity_To_ConsoleEntity()
        {
            // Arrange...
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Sex, string>().ConvertUsing<SexEnumToStringTypeConverter>();
                cfg.CreateMap<DateTime, string>().ConvertUsing<DateTimeToStringTypeConverter>();
                cfg.CreateMap<DomainEntity, ConsoleEntity>();
            });
            configuration.AssertConfigurationIsValid();
            var sut = configuration.CreateMapper();
            DomainEntity domainEntity = new DomainEntity("John Doe")
            {
                Id = Guid.NewGuid(),
                Title = Title.Mr,
                Sex = Sex.Male,
                Created = new DateTime(1,2,3,4,5,6)
            };

            // Act...
            ConsoleEntity consoleEntity = sut.Map<DomainEntity, ConsoleEntity>(domainEntity);

            // Assert...
            consoleEntity.Should().NotBeNull();
            consoleEntity.Id.Should().Be(domainEntity.Id);
            consoleEntity.Name.Should().Be(domainEntity.Name);
            consoleEntity.Title.Should().Be("Mr");
            consoleEntity.Sex.Should().Be("Male");
            consoleEntity.Created.Should().Be("0001-02-03 04:05:06");
        }

        [Fact]
        public void ConsoleEntity_To_DomainEntity()
        {
            // Arrange...
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<string, Sex>().ConvertUsing<StringToSexEnumTypeConverter>();
                cfg.CreateMap<string, DateTime>().ConvertUsing<StringToDateTimeTypeConverter>();
                cfg.CreateMap<ConsoleEntity, DomainEntity>().ConvertUsing<ConsoleEntityToDomainEntityTypeConverter>();
            });
            configuration.AssertConfigurationIsValid();
            var sut = configuration.CreateMapper();
            ConsoleEntity consoleEntity = new ConsoleEntity
            {
                Id = Guid.NewGuid(),
                Title = "Mr",
                Name = "John Doe",
                Sex = "Male",
                Created = "0001-02-03 04:05:06"
            };

            // Act...
            DomainEntity domainEntity = sut.Map<ConsoleEntity, DomainEntity>(consoleEntity);

            // Assert...
            domainEntity.Should().NotBeNull();
            domainEntity.Id.Should().Be(consoleEntity.Id);
            domainEntity.Name.Should().Be(consoleEntity.Name);
            domainEntity.Title.Should().Be(Title.Mr);
            domainEntity.Sex.Should().Be(Sex.Male);
            domainEntity.Created.Should().Be(new DateTime(1, 2, 3, 4, 5, 6));
        }
    }
}
