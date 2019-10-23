using System;
using System.Drawing;
using AutoMapper.Console.Models;
using AutoMapper.Domain.Enumerations;
using AutoMapper.Domain.Models;

namespace AutoMapper.Console.Converters
{
    public class ConsoleEntityToDomainEntityTypeConverter : ITypeConverter<AutoMapper.Console.Models.ConsoleEntity,
                                                                           AutoMapper.Domain.Models.DomainEntity>
    {
        public DomainEntity Convert(ConsoleEntity source, DomainEntity destination, ResolutionContext context)
        {
            destination = new DomainEntity(source.Name)
            {
                Id = source.Id,
                Title = context.Mapper.Map<string, Title>(source.Title),
                Sex = context.Mapper.Map<string, Sex>(source.Sex),
                Created = context.Mapper.Map<string, DateTime>(source.Created)
            };
            return destination;
        }
    }
}