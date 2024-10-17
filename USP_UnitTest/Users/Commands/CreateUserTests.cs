using System.Net;
using System.Text;
using System.Text.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using USP_Application.Common.Dto;
using USP_Application.Users.Commands;
using USP_BaseTest;
using USP_BaseTest.Builders.Commands;
using USP_BaseTest.Builders.Dto;

namespace USP_UnitTest.Users.Commands;

public class CreateUserTests:BaseTest
{
    [Fact]
    public async Task CreateUserCommand_User_UserCreated()
    {
        //Given (Arrange) - what is part of request
        var dto = new EditUserDtoBuilder()
            .WithFirstName("Jovan")
            .WithLastName("Ilijevic")
            .WithEmail("jovanI@gmail.com")
            .Build();

        var command = new EditUserCommandBuilder()
            .WithDto(dto)
            .Build();
        
        var json = JsonSerializer.Serialize(command);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        //When (Act) - what we do with that data
        var response = await AnonymousClient.PostAsync("api/User/Edit", content);

        //Then (Assert) - what is response
        using var _ = new AssertionScope();

        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task CreateUserCommand_InvalidFirstName_BadRequest()
    {
        //Given (Arrange) - what is part of request
        var dto = new EditUserDtoBuilder()
            .WithLastName("Ilijevic")
            .WithEmail("jovanI@gmail.com")
            .Build();

        var command = new EditUserCommandBuilder()
            .WithDto(dto)
            .Build();
        
        var json = JsonSerializer.Serialize(command);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        //When (Act) - what we do with that data
        var response = await AnonymousClient.PostAsync("api/User/Edit", content);

        //Then (Assert) - what is response
        using var _ = new AssertionScope();

        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task CreateUserCommand_InvalidLastName_BadRequest()
    {
        //Given (Arrange) - what is part of request
        var dto = new EditUserDtoBuilder()
            .WithFirstName("Jovan")
            .WithEmail("jovanI@gmail.com")
            .Build();

        var command = new EditUserCommandBuilder()
            .WithDto(dto)
            .Build();
        
        var json = JsonSerializer.Serialize(command);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        //When (Act) - what we do with that data
        var response = await AnonymousClient.PostAsync("api/User/Edit", content);

        //Then (Assert) - what is response
        using var _ = new AssertionScope();

        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task CreateUserCommand_InvalidEmail_BadRequest()
    {
        //Given (Arrange) - what is part of request
        var dto = new EditUserDtoBuilder()
            .WithFirstName("Jovan")
            .WithLastName("ilijevic")
            .Build();

        var command = new EditUserCommandBuilder()
            .WithDto(dto)
            .Build();
        
        var json = JsonSerializer.Serialize(command);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        //When (Act) - what we do with that data
        var response = await AnonymousClient.PostAsync("api/User/Edit", content);

        //Then (Assert) - what is response
        using var _ = new AssertionScope();

        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}