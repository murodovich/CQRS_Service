using CQRS_Service.Application.Absreactions;
using CQRS_Service.Application.UseCases.User.Commands;
using MediatR;

namespace CQRS_Service.Application.UseCases.Users.Handlers
{
    public class CreateUserCommandHandler : AsyncRequestHandler<CreateUserCommand>
    {
        private readonly ICQRSDBContext _dbContext;

        public CreateUserCommandHandler(ICQRSDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected async override Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var person = new Domain.Entities.User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password
            };

            await _dbContext.Users.AddAsync(person);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
