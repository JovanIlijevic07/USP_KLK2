using MongoDB.Entities;
using USP_Application.Common.Interfaces;
using USP_Domain.Entities;

namespace USP_Infrastructure.Services;

public class ProductService:IProductService
{
    public async Task<List<Product>> GetAllProductsAsync(CancellationToken cancellationToken) =>
        await DB.Find<Product>().ExecuteAsync(cancellationToken);
}