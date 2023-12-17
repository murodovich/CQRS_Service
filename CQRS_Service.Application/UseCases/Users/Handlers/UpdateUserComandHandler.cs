using CQRS_Service.Application.Absreactions;
using CQRS_Service.Application.UseCases.User.Commands;
using CQRS_Service.Domain.Exceptions.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Service.Application.UseCases.Users.Handlers
{
    public class UpdateUserComandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly ICQRSDBContext _dbContext;

        public UpdateUserComandHandler(ICQRSDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (result == null) throw new UserNotFoundException();

            result.FirstName = request.FirstName;
            result.LastName = request.LastName;
            result.Email = request.Email;
            result.Password = request.Password;

            _dbContext.Users.Update(result);

            var res = await _dbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
