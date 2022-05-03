using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.DTOs.CategoryDtos
{
    public class CategoryListDto
    {
        public List<CategoryListItemDto> Categories { get; set; }
        public int Count { get; set; }
    }

    public class CategoryListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
