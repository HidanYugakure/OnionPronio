using FluentValidation;
using OnionPronia.Application.DTOS.Categories;
using OnionPronia.Application.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Application.Validators
{
    public class PostCategoryDtoValidator:AbstractValidator<PostCategoryDto>
    {
        private const int MaxNameLength = 100;
        private const int MinNameLength = 3;
        public PostCategoryDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Category name is required")
                .MaximumLength(MaxNameLength).WithMessage("Category name must not exceed 100 characters")
                .MinimumLength(MinNameLength).WithMessage("Category name must be at least 3 characters long")
                .Matches("^[a-zA-Z0-9 ]+$").WithMessage("Category name can only contain alphanumeric characters and spaces")
                .Must(CheckName).WithMessage("Category name contains prohibited words");

            //.MustAsync(async (name, cancellation) =>
            //{
            //    var exists = await repository.AnyAsync(c => c.Name == name);
            //    return !exists;
            //}).WithMessage("Category with the same name already exists");
        }
        private bool CheckName(string name)
        {
            var prohibitedNames = new List<string> { "Invalid", "Test", "Sample" };
            return !prohibitedNames.Contains(name);
        }
    }
}
