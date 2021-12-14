using System;
using Infrastructure.Enums;

namespace DomainModel
{
    public class Cpu : Device
    {
        public int Cores { get; set; }
        public string Series { get; set; }
        public string Socket { get; set; }
        public Cpu(int id, string name, string model, string series, string socket, int cores)
        {
            Id = Guid.NewGuid();
            Series = series;
            Cores = cores;
            Name = name;
            Model = model;
            Socket = socket;
            DeviceType = DeviceType.Cpu;
        }
        
    }
}
