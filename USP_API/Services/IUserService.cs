using System.Dynamic;

namespace USP_API.Services;

public interface IUserService
{
    Task<string> Get();
    Task<string> Create();
}