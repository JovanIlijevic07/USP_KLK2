using MediatR;
using MongoDB.Entities;
using USP_Application.Common.Dto;
using USP_Application.Common.Mappers;
using USP_Domain.Entities;

namespace USP_Application.Products.Commands;

public record CreateProductCommand(ProductCreateDto Product) : IRequest<ProductDetailsDto>;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDetailsDto>
{
    public async Task<ProductDetailsDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var userEntity = new USP_Domain.Entities.User
        {
            Email = "jovan@gmail.com",
            FirstName = "Jovan",
            LastName = "Ilijevic"
        };
        var userEntity2 = new USP_Domain.Entities.User
        {
            Email = "jovan2@gmail.com",
            FirstName = "Jovan2",
            LastName = "Ilijevic2"
        };
        
        await userEntity.SaveAsync(cancellation:cancellationToken);
        await userEntity2.SaveAsync(cancellation:cancellationToken);
        var entity = request.Product.ToEntity(userEntity, new One<USP_Domain.Entities.User>(userEntity));
        
        await entity.SaveAsync(cancellation:cancellationToken);
        entity.ReferencedOneToManyUser.AddAsync([userEntity2,userEntity],cancellation:cancellationToken);
        var dto=await entity.ToDtoAsync();
        
        return dto;
    }
}
//sa ovim one nemamo embeded usera nego samo id ce da pamti a ne sve o njemu kao sto to radi ovaj deo
// var entity = request.Product.ToEntity(userEntity)
