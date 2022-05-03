using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.DTOs.ProductDtos
{
    public class ProductPostDto
    {
        [StringLength(maximumLength:50)]
        public string Name { get; set; }
        public double CostPrice { get; set; }
        public double SalePrice { get; set; }
        public int CategoryId { get; set; }
    }
}
