using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Data;
using TestAPI.Data.Entities;
using TestAPI.DTOs.CategoryDtos;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult GetAll(int page = 1)
        {
            CategoryListDto categoryListDto = new CategoryListDto
            {
                Categories = _context.Categories.Where(x => !x.IsDeleted).Skip((page - 1) * 10).Take(10).Select(x => new CategoryListItemDto
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList(),
                Count = _context.Categories.Where(x => !x.IsDeleted).Count()
            };

            return Ok(categoryListDto);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Category category = _context.Categories.FirstOrDefault(x => x.Id == id && !x.IsDeleted);

            if (category == null) return NotFound();

            CategoryDetailDto categoryDetailDto = new CategoryDetailDto
            {
                Id = category.Id,
                Name = category.Name,
                Products = _context.Products.Where(x => !x.IsDeleted && x.CategoryId == category.Id).Select(x => new ProductInCategoryDetailDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    SalePrice = x.SalePrice
                }).ToList()
            };

            return Ok(categoryDetailDto);
        }

        [HttpPost("")]
        public IActionResult Create(CategoryPostDto categoryPostDto)
        {
            Category category = new Category
            {
                Name = categoryPostDto.Name,
                IsDeleted = false,
                CreatedAt = DateTime.UtcNow.AddHours(4),
                ModifiedAt = DateTime.UtcNow.AddHours(4),
            };

            _context.Categories.Add(category);
            _context.SaveChanges();

            return StatusCode(201, categoryPostDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CategoryPostDto categoryDto)
        {
            Category category = _context.Categories.FirstOrDefault(x => x.Id == id && !x.IsDeleted);

            if (category == null) return NotFound();

            category.Name = categoryDto.Name;
            category.ModifiedAt = DateTime.UtcNow.AddHours(4);

            _context.SaveChanges();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Category category = _context.Categories.FirstOrDefault(x => x.Id == id && !x.IsDeleted);

            if (category == null) return NotFound();

            category.IsDeleted = true;
            category.ModifiedAt = DateTime.UtcNow.AddHours(4);

            _context.SaveChanges();

            return NoContent();
        }

    }
}
