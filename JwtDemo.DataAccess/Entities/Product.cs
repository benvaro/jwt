using System;
using System.Collections.Generic;
using System.Text;

namespace JwtDemo.DataAccess.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }


    }
}
