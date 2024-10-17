using MediatR;
using MongoDB.Entities;
using USP_Application.Common.Dto;
using USP_Application.Common.Interfaces;
using USP_Application.Common.Mappers;
using USP_Domain.Entities;

namespace USP_Application.Products.Queries;

public record GetAllProductQueri:IRequest<List<ProductDetailsDto>>;

public class GetAllProductQueriHandler(IProductService productService) : IRequestHandler<GetAllProductQueri,List<ProductDetailsDto>>
{
    public async Task<List<ProductDetailsDto>> Handle(GetAllProductQueri request, CancellationToken cancellationToken)
    {
        var results = await productService.GetAllProductsAsync(cancellationToken);
        
        var listDto = new List<ProductDetailsDto>();

        foreach (var item in results)
        {
            var result = await item.ToDtoAsync();
            listDto.Add(result);
        }

        return listDto;
    }
    
}