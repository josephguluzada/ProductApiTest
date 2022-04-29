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

        public ProductsController( AppDbContext context)
        {
            _context = context;
        }


        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(_context.Products.Where(x=>!x.IsDeleted).Include(x=>x.Category).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Product product = _context.Products.Where(x => !x.IsDeleted).Include(x=>x.Category).FirstOrDefault(x => x.Id == id);

            if (product == null) return NotFound();

            ProductDetailDto productDetailDto = new ProductDetailDto
            {
                Id = product.Id,
                Name = product.Name,
                CostPrice = product.CostPrice,
                SalePrice = product.SalePrice,
                CategoryName = product.Category.Name
            };

            return Ok(productDetailDto);
        }


        [HttpPost("")]
        public IActionResult Create(ProductPostDto productDto)
        {
            Product product = new Product
            {
                Name = productDto.Name,
                CostPrice = productDto.CostPrice,
                SalePrice = productDto.SalePrice,
                CreatedAt = DateTime.UtcNow.AddHours(4),
                ModifiedAt = DateTime.UtcNow.AddHours(4),
                IsDeleted = false
            };

            _context.Add(product);
            _context.SaveChanges();

            return StatusCode(201, productDto);
        }
    }
}
