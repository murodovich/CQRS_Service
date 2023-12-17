using CQRS_Service.Application.Absreactions;
using CQRS_Service.Application.UseCases.User.Commands;
using CQRS_Service.Domain.Exceptions.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Service.Application.UseCases.Users.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly ICQRSDBContext _dbContext;

        public DeleteUserCommandHandler(ICQRSDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (result == null) throw new UserNotFoundException();

            _dbContext.Users.Remove(result);
            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
