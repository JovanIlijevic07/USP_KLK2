using MediatR;
using MongoDB.Entities;
using USP_Application.Common.Dto;
using USP_Application.Common.Mappers;

namespace USP_Application.Users.Commands;

//ovo moze da se koristi i za edit i za create ne mor dve razlicite komande
public record EditUserCommand(EditUserDetailsDto User): IRequest;

public class EditUserCommandHandler : IRequestHandler<EditUserCommand>
{
    public async Task Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var entity = request.User.ToEntity();
       await entity.SaveAsync(cancellation:cancellationToken);
    }
}