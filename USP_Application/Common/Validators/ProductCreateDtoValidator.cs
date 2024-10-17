using FluentValidation;
using USP_Application.Common.Dto;
using USP_Domain.Enums;
using USP_Domain.Extentions;

namespace USP_Application.Common.Validators;

public class ProductCreateDtoValidator:AbstractValidator<ProductCreateDto>
{
    public ProductCreateDtoValidator()
    {
       
        RuleFor(x => x.Name).MinimumLength(3);
        RuleFor(x => x.Name).MaximumLength(15);
        RuleFor(x => x.Description).MinimumLength(15);
        RuleFor(x => x.Description).MaximumLength(150);
        RuleFor(x => x.Price).GreaterThan(0);
        RuleFor(x => x.Price).LessThanOrEqualTo(50000m);
        RuleFor(x => x.Category).NotNull();
        RuleFor(x=>x.Category).Must(t=>Category.TryFromValue(t,out _))
            .WithMessage($"Category is not in list: {EnumExtentions.ValidCategoryList}");
    }
}