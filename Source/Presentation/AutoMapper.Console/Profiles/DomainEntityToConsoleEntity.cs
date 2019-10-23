using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapper.Console.Profiles
{
    public class DomainEntityToConsoleEntity : Profile
    {
        public DomainEntityToConsoleEntity()
        {
            CreateMap<AutoMapper.Domain.Models.DomainEntity, AutoMapper.Console.Models.ConsoleEntity>();
        }
    }
}