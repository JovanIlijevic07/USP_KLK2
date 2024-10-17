namespace USP_API.Services;

public class ProductService:IProductService
{
    public async Task<string> Get() => "JovanProduct";

    public async Task<string> Create() => "CreateJovanProduct";
}