using System;
using AutoMapper.Domain.Enumerations;

namespace AutoMapper.Console.Converters
{
    public class StringToTitleEnumTypeConverter : ITypeConverter<string?, Title?>
    {
        public Title? Convert(string? source, Title? destination, ResolutionContext context)
        {
            if (string.IsNullOrWhiteSpace(source)) return null;
            if (Enum.TryParse<Title>(source, true, out var result)) return result;
            return null;
        }
    }
}