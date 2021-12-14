using System.Collections.Generic;
using DomainModel;

namespace Repository.Database
{
    public class DatabaseTable
    {
        private static DatabaseTable _instance;
        public static DatabaseTable GetInstance()
        {
            if (_instance == null)
                _instance = new DatabaseTable();
            return _instance;
        }
        public List<Cart> CartList { get; set; } = new List<Cart>();
    public List<User> UsersList { get; set; } = new List<User>() {new User(){Username = "123" , Password = "123", Name = "Arshia", Address = "123", Phone = "123"},
            new User(){Username = "456", Password = "456", Name = "456", Address = "456", Phone = "456" } };
        public List<Cpu> CpuList
        {
            get
            {
                List<Cpu> list = new List<Cpu>()
                {
                    new Cpu(1, "Intel", "Core i9", "10900", "LGA 1200", 10),
                    new Cpu(2, "Intel", "Core i9", "9900K", "LGA 1151", 8),
                    new Cpu(3, "Intel", "Core i7", "10700K", "LGA 1200", 8),
                    new Cpu(4, "AMD", "Ryzen 9", "5900X", "AMD AM4", 12),
                    new Cpu(5, "AMD", "Ryzen 7", "5800X", "AMD AM4", 8)
                };
                return list;
            }
        }
        public List<Ram> RamList
        {
            get
            {
                List<Ram> list = new List<Ram>()
                {
                    new Ram(1, "G Skill", "TRIDNTZ ROYAL LITE", 4000, 32, "DDR4"),
                    new Ram(2, "G Skill","TRIDENTZ ROYAL GOLD", 4000, 16, "DDR4"),
                    new Ram(3, "G Skill","TRIDENTZ ROYAL", 4000, 16, "DDR4"),
                    new Ram(4, "G Skill","TRIDENTZ", 3200, 8, "DDR4"),
                    new Ram(5, "TeamGroup","T-Force Delta", 3200, 8, "DDR4")
                };
                return list;
            }
        }
        public List<GraphicCard> GraphicCardList
        {
            get
            {
                List<GraphicCard> list = new List<GraphicCard>()
                {
                    new GraphicCard(1, "PNY", "Nvidia Quadro RTX 6000", 24, "PCI Express 4.0"),
                    new GraphicCard(2, "ASUS","TUF RTX3080", 10, "PCI Express 4.0"),
                    new GraphicCard(3, "MSI","RTX 3070 VENTUS 2X", 14, "PCI Express 3.0"),
                    new GraphicCard(4, "ASUS","TUF AMD RX6800", 16, "PCI Express 4.0"),
                    new GraphicCard(5, "XFX","AMD RX 6700 XT", 12, "PCI Express 4.0")
                };
                return list;
            }
        }
        public List<Hdd> HddList
        {
            get
            {
                List<Hdd> list = new List<Hdd>()
                {
                    new Hdd(1, "WesternDigital", "Purple WD121PURZ", 12, "SATA 3.0"),
                    new Hdd(2, "WesternDigital","Purple WD60PURN", 10, "SATA 3.0"),
                    new Hdd(3, "WesternDigital","Purple WD60PUMZ", 8, "SATA 3.0"),
                    new Hdd(4, "WesternDigital","Purple WD60PURX", 6, "SATA 3.0"),
                    new Hdd(5, "WesternDigital","Purple WD10PGMZON", 2, "SATA 3.0")
                };
                return list;
            }
        }


        public List<Product> ProductsList
        {
            get
            {
                List<Product> products = new List<Product>()
                {
                    new Product(1, CpuList[0],new Amount(18000000)),
                    new Product(2, CpuList[1],new Amount(15000000)),
                    new Product(3, CpuList[2],new Amount(13000000)),
                    new Product(4, CpuList[3],new Amount(15000000)),
                    new Product(5, CpuList[4],new Amount(13000000)),
                    new Product(6, RamList[0],new Amount(12000000)),
                    new Product(7, RamList[1],new Amount(10000000)),
                    new Product(8, RamList[2],new Amount(8000000)),
                    new Product(9, RamList[3],new Amount(6000000)),
                    new Product(10, RamList[4],new Amount(4000000)),
                    new Product(11, GraphicCardList[0],new Amount(130000000)),
                    new Product(12, GraphicCardList[1],new Amount(90000000)),
                    new Product(13, GraphicCardList[2],new Amount(70000000)),
                    new Product(14, GraphicCardList[3],new Amount(65000000)),
                    new Product(15, GraphicCardList[4],new Amount(40000000)),
                    new Product(16, HddList[0],new Amount(18000000)),
                    new Product(17, HddList[1],new Amount(13000000)),
                    new Product(18, HddList[2],new Amount(10000000)),
                    new Product(19, HddList[3],new Amount(7000000)),
                    new Product(20, HddList[4],new Amount(3000000)),

                };
                return products;
            }
        }
    }
}