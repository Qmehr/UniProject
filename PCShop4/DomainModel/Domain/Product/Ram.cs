using System;
using Infrastructure.Enums;

namespace DomainModel
{
    public class Ram : Device
    {
        public int Capacity { get; set; }
        public string Socket { get; set; }
        public int Frequency { get; set; }
        public Ram(int id, string name, string model, int frequency, int capacity, string socket)
        {
            Id = Guid.NewGuid();
            Name = name;
            Model = model;
            Capacity = capacity;
            Socket = socket;
            Frequency = frequency;
            DeviceType = DeviceType.Ram;
        }
       
    }
}