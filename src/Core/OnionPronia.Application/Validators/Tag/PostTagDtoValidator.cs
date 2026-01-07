using FluentValidation;
using OnionPronia.Application.DTOs;
using OnionPronia.Application.DTOS.Categories;
using OnionPronia.Application.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Application.Validators
{
    public class PostTagDtoValidator : AbstractValidator<PostTagDto>
    {
        private const int MAX_LIMIT = 200;
        private const int MIN_LIMIT = 5;
        public PostTagDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(MAX_LIMIT)
                .WithMessage("Name must be less than 150 characters")
                .MinimumLength(MIN_LIMIT)
                .WithMessage("Name must be more than 1 characters")
                .Matches(@"^[A-Za-z0-9\s]*$");
        }
    }
}
