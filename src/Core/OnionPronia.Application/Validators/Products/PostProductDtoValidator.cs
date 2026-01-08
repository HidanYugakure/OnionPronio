using FluentValidation;
using OnionPronia.Application.DTOS.Products;

namespace OnionPronia.Application.Validators.Products
{
    public class PostProductDtoValidator: AbstractValidator<PostProductDto>
    {
        private const int MaxLength = 150;
        private const int MinLength = 3;
        public PostProductDtoValidator()
        {
            RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(MaxLength)
            .MinimumLength(MinLength);
            /*.Matches(@"^[A-Za-z0-9\s]*$")*/
            RuleFor(p => p.Description)
            .NotEmpty();
            RuleFor(p => p.SKU)
            .NotEmpty()
            .MaximumLength(10);
            RuleFor(p => p.Price)
            .GreaterThan(0);
            RuleFor(p => p.TagIds)
             .NotEmpty()
             .Must(tgIds => tgIds.Count > 0);
            RuleForEach(p => p.TagIds)
             .GreaterThan(0);


        }
    }
}
