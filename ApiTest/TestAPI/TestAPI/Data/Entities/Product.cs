using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.Data.Entities
{
    public class Product : BaseEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public double CostPrice { get; set; }
        public double SalePrice { get; set; }
        public Category Category { get; set; }
    }
}
