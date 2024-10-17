namespace USP_API.Services;

public class UserService:IUserService
{
    public async Task<string> Get() => "Jovan User";

    public async Task<string> Create() => "Create User";
}