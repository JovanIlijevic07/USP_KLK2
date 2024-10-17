using USP_Domain.Entities;

namespace USP_Application.Common.Interfaces;

public interface IProductService
{
    Task<List<Product>> GetAllProductsAsync(CancellationToken cancellationToken);
}
