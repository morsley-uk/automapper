using System;

namespace AutoMapper.Console.Models
{
    public class ConsoleEntity
    {
        public Guid Id { get; set; }

        public string? Title { get; set; }

        public string Name { get; set; }

        public string Sex { get; set; }

        // Expected Format: YY-MM-DD HH:MM:SS
        public string Created { get; set; }
    }
}