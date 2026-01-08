using FluentValidation;
using OnionPronia.Application.DTOs.AppUsers;


namespace OnionPronia.Application.Validators.AppUsers
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(u => u.UsernameorEmail)
                .NotEmpty()
                .MaximumLength(255)
                .MinimumLength(3)
                .Matches(@"^[A-Za-z0-0-._@+]*$");
            RuleFor(u => u.Password)
                .NotEmpty()
                .MaximumLength(255)
                .MinimumLength(8);


        }
    }
}
