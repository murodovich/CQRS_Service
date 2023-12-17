using MediatR;

namespace CQRS_Service.Application.UseCases.Users.Queries
{
    public class GetByIdUserQuery : IRequest<Domain.Entities.User>
    {
        public int Id { get; set; }

    }
}
