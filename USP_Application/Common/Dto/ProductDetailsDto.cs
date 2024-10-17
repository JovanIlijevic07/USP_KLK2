namespace USP_Application.Common.Dto;

public record ProductDetailsDto(
    string Name,
    string Description,
    decimal Price,
    UserDetailsDto ReferencedOneToOneUser,
    ListUserDetailsDto ReferencedOneToManyUsers,
    ListUserDetailsDto ReferencerManyToManyUser
    );