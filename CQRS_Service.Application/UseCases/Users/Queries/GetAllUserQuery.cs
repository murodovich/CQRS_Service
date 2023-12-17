using MediatR;

namespace CQRS_Service.Application.UseCases.Users.Queries
{
    public class GetAllUserQuery : IRequest<List<Domain.Entities.User>>
    {
    }
}
