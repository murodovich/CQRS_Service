using CQRS_Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Service.Application.Absreactions
{
    public interface ICQRSDBContext
    {
        public DbSet<User> Users { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
