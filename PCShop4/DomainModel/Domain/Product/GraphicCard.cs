using System;
using Infrastructure.Enums;

namespace DomainModel
{
    public class GraphicCard : Device
    {
        public int Capacity { get; set; }
        public string Socket { get; set; }
        public GraphicCard(int id, string name, string model, int capacity, string socket)
        {
            Id = Guid.NewGuid();
            Name = name;
            Model = model;
            Capacity = capacity;
            Socket = socket;
            DeviceType = DeviceType.GraphicCard;
        }
      
    }
}