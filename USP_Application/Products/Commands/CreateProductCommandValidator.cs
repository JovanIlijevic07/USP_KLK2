using FluentValidation;
using USP_Application.Common.Validators;
using USP_Application.Products.Commands;
using USP_Domain.Enums;
using USP_Domain.Extentions;

namespace USP_Application.Products.Commands;

public class CreateProductCommandValidator:AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Product).NotNull();
        RuleFor(x => x.Product).SetValidator(new ProductCreateDtoValidator());
    }
}