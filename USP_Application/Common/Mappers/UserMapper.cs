using MongoDB.Entities;
using Riok.Mapperly.Abstractions;
using USP_Application.Common.Dto;
using USP_Domain.Entities;

namespace USP_Application.Common.Mappers;

[Mapper]
public static partial class UserMapper
{
    public static partial UserDetailsDto ToDto(this USP_Domain.Entities.User entity);
    public static partial User ToEntity(this UserDetailsDto dto);

    public static  User ToEntity(this EditUserDetailsDto dto)
    {
       return new User()
        {
            ID = (string.IsNullOrEmpty(dto.UserId) ? null : dto.UserId) ?? string.Empty,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
        };
    }

    public static ListUserDetailsDto ToListDto(this Many<USP_Domain.Entities.User,USP_Domain.Entities.Product> manyEntities)
    {
        var listDto=new List<UserDetailsDto>();

        foreach (var entity in manyEntities)
        {
            listDto.Add(entity.ToDto());
        }

        return new ListUserDetailsDto(listDto);
    }
    
    public static List<User> ToListEntity(this Many<USP_Domain.Entities.User,USP_Domain.Entities.Product> manyEntities)
    {
        var list=new List<User>();

        foreach (var entity in manyEntities)
        {
            list.Add(entity);
        }

        return list;
    }
}