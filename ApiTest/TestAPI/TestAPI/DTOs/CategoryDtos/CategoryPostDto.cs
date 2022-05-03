using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.DTOs.CategoryDtos
{
    public class CategoryPostDto
    {
        public string Name { get; set; }
    }

    public class CategoryPostDtoValidator : AbstractValidator<CategoryPostDto>
    {
        public CategoryPostDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(50).MinimumLength(2);
        }
    }
}
