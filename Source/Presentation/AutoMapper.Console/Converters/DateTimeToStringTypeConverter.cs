using System;

namespace AutoMapper.Console.Converters
{
    public class DateTimeToStringTypeConverter : ITypeConverter<DateTime, string>
    {
        public string Convert(DateTime source, string destination, ResolutionContext context)
        {
            return source.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}