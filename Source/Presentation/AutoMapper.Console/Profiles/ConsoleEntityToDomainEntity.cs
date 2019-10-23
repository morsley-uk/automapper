using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper.Console.Converters;

namespace AutoMapper.Console.Profiles
{
    public class ConsoleEntityToDomainEntity : Profile
    {
        public ConsoleEntityToDomainEntity()
        {
            CreateMap<AutoMapper.Console.Models.ConsoleEntity,
                      AutoMapper.Domain.Models.DomainEntity>().ConvertUsing<ConsoleEntityToDomainEntityTypeConverter>();
        }
    }
}