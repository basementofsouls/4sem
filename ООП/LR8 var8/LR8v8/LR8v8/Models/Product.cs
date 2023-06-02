using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR8v8.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public int Size { get; set; }
        public int Weight { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public int ManufacturerId { get; set; }
        public int StorekeeperId { get; set; }
    }
}
