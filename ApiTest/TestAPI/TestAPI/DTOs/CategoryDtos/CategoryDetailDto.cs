using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.DTOs.CategoryDtos
{
    public class CategoryDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductInCategoryDetailDto> Products { get; set; }
    }

    public class ProductInCategoryDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double SalePrice { get; set; }
    }
}
