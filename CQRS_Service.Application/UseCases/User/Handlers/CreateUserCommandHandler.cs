using CQRS_Service.Application.Absreactions;
using MediatR;

namespace CQRS_Service.Application.UseCases.User.Handlers
{
    public class CreateUserCommandHandler : AsyncRequestHandler<CreateUserCommandHandler>
    {
        private readonly ICQRSDBContext _dbContext;

        public CreateUserCommandHandler(ICQRSDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override Task Handle(CreateUserCommandHandler request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
