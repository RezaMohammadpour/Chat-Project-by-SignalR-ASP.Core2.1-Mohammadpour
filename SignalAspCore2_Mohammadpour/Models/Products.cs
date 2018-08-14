using System;
using System.Collections.Generic;

namespace SignalAspCore2_Mohammadpour.Models
{
    public partial class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public byte[] Img { get; set; }
    }
}
