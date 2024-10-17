using FluentValidation;
using USP_Application.Common.Validators;

namespace USP_Application.Users.Commands;

public class EditUserCommandValidator:AbstractValidator<EditUserCommand>
{
    
        public EditUserCommandValidator()
        {
            RuleFor(x => x.User).NotNull();
            RuleFor(x => x.User).SetValidator(new EditUserDtoValidator());
        }
    
}