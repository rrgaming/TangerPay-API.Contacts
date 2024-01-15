using Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace Contracts.Context
{
    public class DB_Context : DbContext
    {
        public DbSet<ContactModel> Contact { get; set; }

        public DB_Context(DbContextOptions<DB_Context> options)
            : base(options)
        {

        }
    }
}
