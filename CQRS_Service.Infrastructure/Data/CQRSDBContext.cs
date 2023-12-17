using CQRS_Service.Application.Absreactions;
using CQRS_Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Service.Infrastructure.Data
{
    public class CQRSDBContext : DbContext,ICQRSDBContext
    {
        public CQRSDBContext(DbContextOptions<CQRSDBContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
    }
}
