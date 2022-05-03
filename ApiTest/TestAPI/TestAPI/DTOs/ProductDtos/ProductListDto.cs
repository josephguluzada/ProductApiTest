using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.DTOs.ProductDtos
{
    public class ProductListDto
    {
        public List<ProductListItemDto> Products { get; set; }
        public int TotalCount { get; set; }
    }
    public class ProductListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double SalePrice { get; set; }
        public string CategoryName { get; set; }
    }
}
