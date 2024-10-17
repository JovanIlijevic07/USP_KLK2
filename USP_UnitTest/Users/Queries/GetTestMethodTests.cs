using System.Net;
using FluentAssertions;
using FluentAssertions.Execution;
using USP_BaseTest;

namespace USP_UnitTest.Users.Queries;

public class GetTestMethodTests:BaseTest
{
    [Fact]
    public async Task User_Get_Test()
    {
        //Given(Arrange)-staje deo requesta
        
        //When(Act)-sta radimo sa tim podacima
        var response = await AnonymousClient.GetAsync("api/User/Get");
        //Then(assert)-sta je odgovor(response)
        using var _ = new AssertionScope();

        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}