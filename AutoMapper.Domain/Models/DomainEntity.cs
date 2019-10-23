using System;
using System.Drawing;
using AutoMapper.Domain.Enumerations;

namespace AutoMapper.Domain.Models
{
    public class DomainEntity
    {
        public DomainEntity(string name)
        {
            SetName(name);
        }

        public Guid Id { get; set; }

        public Title? Title { get; set; }

        public string Name { get; protected set; }

        public Sex Sex { get; set; }

        public DateTime Created { get; set; }

        public void SetName(string name)
        {
            Name = name;
        }
    }
}