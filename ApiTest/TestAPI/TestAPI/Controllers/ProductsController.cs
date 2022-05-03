using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Data;
using TestAPI.Data.Entities;
using TestAPI.DTOs.ProductDtos;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet("")]
        public IActionResult GetAll(int page = 1)
        {
            ProductListDto productListDto = new ProductListDto
            {
                Products = _context.Products.Where(x => !x.IsDeleted).Include(x => x.Category).Skip((page - 1) * 10).Take(10).Select(x => new ProductListItemDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    SalePrice = x.SalePrice,
                    CategoryName = x.Category.Name
                }).ToList(),
                TotalCount = _context.Products.Where(x => !x.IsDeleted).Count()
            };


            return Ok(productListDto);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Product product = _context.Products.Where(x => !x.IsDeleted).Include(x => x.Category).FirstOrDefault(x => x.Id == id);

            if (product == null) return NotFound();

            ProductDetailDto productDetailDto = new ProductDetailDto
            {
                Id = product.Id,
                Name = product.Name,
                CostPrice = product.CostPrice,
                SalePrice = product.SalePrice,
                Category = new CategoryInProductDetailDto
                {
                    Id = product.CategoryId,
                    Name = product.Category.Name
                }
            };

            return Ok(productDetailDto);
        }


        [HttpPost("")]
        public IActionResult Create(ProductPostDto productDto)
        {
            if (!_context.Categories.Any(x => x.Id == productDto.CategoryId)) return StatusCode(402);


            Product product = new Product
            {
                Name = productDto.Name,
                CostPrice = productDto.CostPrice,
                SalePrice = productDto.SalePrice,
                CreatedAt = DateTime.UtcNow.AddHours(4),
                ModifiedAt = DateTime.UtcNow.AddHours(4),
                CategoryId = productDto.CategoryId,
                IsDeleted = false
            };

            _context.Add(product);
            _context.SaveChanges();

            return StatusCode(201, productDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductPostDto productDto)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Id == id && !x.IsDeleted);

            if (product == null) return NotFound();
            if (!_context.Categories.Any(x => x.Id == productDto.CategoryId)) return StatusCode(402);


            product.Name = productDto.Name;
            product.SalePrice = productDto.SalePrice;
            product.CostPrice = productDto.CostPrice;
            product.ModifiedAt = DateTime.UtcNow.AddHours(4);
            product.CategoryId = productDto.CategoryId;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Id == id && !x.IsDeleted);

            if (product == null) return NotFound();

            product.IsDeleted = true;
            product.ModifiedAt = DateTime.UtcNow.AddHours(4);

            _context.SaveChanges();

            return NoContent();
        }
    }
}
