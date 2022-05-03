using FluentValidation;
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

    public class ProductPostDtoValidator : AbstractValidator<ProductPostDto>
    {
        public ProductPostDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(200).MinimumLength(2);
            RuleFor(x => x.CategoryId).GreaterThan(0);
            RuleFor(x => x.CostPrice).GreaterThanOrEqualTo(0);
            RuleFor(x => x.SalePrice).GreaterThanOrEqualTo(0);

            // Custom validation

            RuleFor(x => x).Custom((x, context) =>
            {
                  if (x.CostPrice > x.SalePrice)
                  {
                      context.AddFailure(nameof(x.CostPrice), "CostPrice can't be greater than SalePrice");
                      //context.AddFailure("CostPrice", "CostPrice can't be greater than SalePrice");
                  }
            });
        }
    }
}
