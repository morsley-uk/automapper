using System;
using AutoMapper.Domain.Enumerations;

namespace AutoMapper.Console.Converters
{
    public class SexEnumToStringTypeConverter : ITypeConverter<Sex, string>
    {
        public string Convert(Sex source, string destination, ResolutionContext context)
        {
            var value = Enum.GetName(typeof(Sex), source);
            return value;
        }
    }
}