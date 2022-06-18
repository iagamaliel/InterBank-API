using Microsoft.EntityFrameworkCore;

namespace InterBankServices.WebApi.Configurations
{
   
    public class DatabaseConfig : DbContext
    {
        // public DbSet<Certificate> Certificate { get; set; }
        public DatabaseConfig(DbContextOptions<DatabaseConfig> options) : base(options)
        {

        }
    }
}
