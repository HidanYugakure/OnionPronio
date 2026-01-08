using FluentValidation;
using OnionPronia.Application.DTOs;

namespace OnionPronia.Application.Validators.AppUsers
{
    public class RegisterDtoValidator:AbstractValidator<RegisterDto>
    {
      public RegisterDtoValidator() 
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .MaximumLength(60)
                .MinimumLength(3)
                .Matches(@"^[A-Za-z]*$");
            RuleFor(r => r.Surname)
                .NotEmpty()
                .MaximumLength(60)
                .MinimumLength(3)
                .Matches(@"^[A-Za-z]*$");
            RuleFor(r=> r.Email)
                .NotEmpty()
                .MaximumLength(255)
                .MinimumLength(4)
                .Matches(@"^[A-Za-z]*$");
            RuleFor(r => r.UsernameorEmail)
             .NotEmpty()
             .MaximumLength(255)
             .MinimumLength(4)
             .Matches(@"^[A-Za-z]*$");
            RuleFor(r => r.Password)
            .NotEmpty()
            .MaximumLength(255)
            .MinimumLength(8);
            RuleFor(r => r)
                .Must(r => r.ConfirmPassword == r.Password);


        }
    }
}
