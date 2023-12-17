using MediatR;

namespace CQRS_Service.Application.UseCases.User.Commands
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
