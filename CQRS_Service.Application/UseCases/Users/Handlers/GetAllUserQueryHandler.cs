using CQRS_Service.Application.Absreactions;
using CQRS_Service.Application.UseCases.Users.Queries;
using CQRS_Service.Domain.Exceptions.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Service.Application.UseCases.Users.Handlers
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<Domain.Entities.User>>
    {
        private readonly ICQRSDBContext _dbContext;

        public GetAllUserQueryHandler(ICQRSDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Domain.Entities.User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Users.ToListAsync();
            if (result == null) throw new UserNotFoundException();
            return result;
        }
    }
}
