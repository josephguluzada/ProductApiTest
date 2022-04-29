using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.DTOs.ProductDtos
{
    public class ProductDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double CostPrice { get; set; }
        public double SalePrice { get; set; }
        public string CategoryName { get; set; }
    }
}
