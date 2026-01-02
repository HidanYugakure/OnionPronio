using FluentValidation;
using OnionPronia.Application.DTOS.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Application.Validators.Categories
{
    public class PutCategoryDtoValidator:AbstractValidator<PutCategoryDto>
    {
        private const int MaxNameLength = 100;
        private const int MinNameLength = 3;
        public PutCategoryDtoValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Category name is required")
                .MaximumLength(MaxNameLength).WithMessage("Category name must not exceed 100 characters")
                .MinimumLength(MinNameLength).WithMessage("Category name must be at least 3 characters long")
                .Matches("^[a-zA-Z0-9 ]+$").WithMessage("Category name can only contain alphanumeric characters and spaces");

        }
    }
}
