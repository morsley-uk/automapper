using System;

namespace AutoMapper.Console.Converters
{
    public class StringToDateTimeTypeConverter : ITypeConverter<string, DateTime>
    {
        public DateTime Convert(string source, DateTime destination, ResolutionContext context)
        {
            return DateTime.ParseExact(source, "yyyy-MM-dd HH:mm:ss", null);
        }
    }
}