using CQRS_Service.Application.Absreactions;
using CQRS_Service.Application.UseCases.User.Commands;
using MediatR;

namespace CQRS_Service.Application.UseCases.Users.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {

        private readonly ICQRSDBContext _dbContext;

        public CreateUserCommandHandler(ICQRSDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var person = new Domain.Entities.User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password
            };

            await _dbContext.Users.AddAsync(person);
            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
