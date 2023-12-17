using CQRS_Service.Application.Absreactions;
using CQRS_Service.Application.UseCases.Users.Queries;
using CQRS_Service.Domain.Exceptions.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Service.Application.UseCases.Users.Handlers
{
    public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, Domain.Entities.User>
    {
        private readonly ICQRSDBContext _dbContext;

        public GetByIdUserQueryHandler(ICQRSDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Domain.Entities.User> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (result == null) throw new UserNotFoundException();
            return result;
        }
    }
}
