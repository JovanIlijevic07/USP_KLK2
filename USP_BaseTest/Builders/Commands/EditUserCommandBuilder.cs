using USP_Application.Common.Dto;
using USP_Application.Users.Commands;
using USP_BaseTest.Builders.Dto;

namespace USP_BaseTest.Builders.Commands;

public class EditUserCommandBuilder
{
    private EditUserDetailsDto _dto = new EditUserDtoBuilder().Build();

    public EditUserCommand Build() => new(_dto);

    public EditUserCommandBuilder WithDto(EditUserDetailsDto dto)
    {
        _dto = dto;
        return this;
    }
}