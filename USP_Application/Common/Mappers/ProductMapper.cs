using MongoDB.Entities;
using Riok.Mapperly.Abstractions;
using USP_Application.Common.Dto;
using USP_Domain.Entities;
using USP_Domain.Enums;

namespace USP_Application.Common.Mappers;


[Mapper]
public static partial class ProductMapper
{
    public static async Task<ProductDetailsDto> ToDtoAsync(this Product entity)
    {
        var userDetails = await entity.ReferencedOneToOneUser.ToEntityAsync();
        var userDetatilsDto = userDetails.ToDto();
        return new ProductDetailsDto(entity.Name, entity.Description, entity.Price, userDetatilsDto,
            entity.ReferencedOneToManyUser.ToListDto(), entity.ReferencedManyToManyUser.ToListDto());
    }

    public static ProductCustomDetailsDto ToCustomDto(this Product entity)
    {
        return new ProductCustomDetailsDto(entity.Name + " - " + entity.Price); 
    }
    
    //iz DTo u entity
    public static Product ToEntity(this ProductCreateDto dto,User user,One<User> referencedOneToOneUser)
    {
        var entity = new Product
        {
            Name = dto.Name,
            Price = dto.Price,
            Description = dto.Description,
           // Category = Category.FromValue(dto.Category),
            User = user,
            ReferencedOneToOneUser = referencedOneToOneUser,
        };
            return entity;
    }

    public static async Task<ProductEmbedded> ToEmbedded(this Product entity)
    {
        return new ProductEmbedded()
        {
            Name = entity.Name,
            Description = entity.Description,
            Price = entity.Price,
            User = entity.User,
            ReferencedOneToOneUser = await entity.ReferencedOneToOneUser.ToEntityAsync(),
            ReferencedOneToManyUser = entity.ReferencedOneToManyUser.ToListEntity(),
            ReferencedManyToManyUser = entity.ReferencedManyToManyUser.ToListEntity()
        };
    }
}