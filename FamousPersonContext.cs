using CIS174_TestCoreApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace CIS174_TestCoreApp
{
    public class FamousPersonContext : DbContext
    {
        public FamousPersonContext(DbContextOptions<FamousPersonContext> options)
            : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Accomplishment> Accomplishments { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=tcp:cis174juridout.database.windows.net,1433;Initial Catalog=CIS174WebApp10.1;Persist Security Info=False;User ID=cis174;Password=(Jtr2018);MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    }
}
