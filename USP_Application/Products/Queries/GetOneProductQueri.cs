using MediatR;
using MongoDB.Entities;
using USP_Application.Common.Dto;
using USP_Application.Common.Mappers;

namespace USP_Application.Products.Queries;

public record GetOneProductQueri(string Id):IRequest<ProductDetailsDto?>;

public class GetOneProductQueriHandler : IRequestHandler<GetOneProductQueri,ProductDetailsDto?>
{
    public async Task<ProductDetailsDto?> Handle(GetOneProductQueri request, CancellationToken cancellationToken)
    {
        var entity = await DB.Find<USP_Domain.Entities.Product>().OneAsync(request.Id, cancellation: cancellationToken);
        var dto =await  entity?.ToDtoAsync();
        return dto;
    }
}