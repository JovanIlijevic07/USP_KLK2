using FluentValidation;
using USP_Application.Common.Dto;

namespace USP_Application.Common.Validators;

public class EditUserDtoValidator:AbstractValidator<EditUserDetailsDto>

{
    public EditUserDtoValidator()
    {
        RuleFor(x => x.FirstName).MinimumLength(3);
        RuleFor(x => x.FirstName).MaximumLength(15);
        RuleFor(x => x.LastName).MinimumLength(7);
        RuleFor(x => x.LastName).MaximumLength(15);
        RuleFor(x => x.Email).MinimumLength(15);
        RuleFor(x => x.Email).MaximumLength(150);
        
        

    }    
}