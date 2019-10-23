using System;
using AutoMapper.Domain.Enumerations;

namespace AutoMapper.Console.Converters
{
    public class StringToSexEnumTypeConverter : ITypeConverter<string, Sex>
    {
        public Sex Convert(string source, Sex destination, ResolutionContext context)
        {
            return Enum.Parse<Sex>(source, true);
        }
    }
}