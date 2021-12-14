using System;
using Infrastructure.Enums;

namespace DomainModel
{
    public class Device
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public DeviceType DeviceType { get; set; }
    }
}