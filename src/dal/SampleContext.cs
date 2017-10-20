using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace dal
{
    public class SampleContext : DbContext  
    {
        public SampleContext(DbContextOptions<SampleContext> options)
            : base(options)
        { }

        public DbSet<Article> Articles { get; set; }
    }

    public class SampleContextFactory : IDesignTimeDbContextFactory<SampleContext>
    {
        const string CONNECTION_STRING = "User ID=webapi;Password=mypostgrespassword!;Host={0};Port=5432;Database=sample;Pooling=true;";

        public SampleContext CreateDbContext(string[] args)
        {
            var servername = Environment.GetEnvironmentVariable("APP_DB_SERVER");

            if(string.IsNullOrEmpty(servername))
                servername = "localhost";

            var builder = new DbContextOptionsBuilder<SampleContext>();
            builder.UseNpgsql(string.Format(CONNECTION_STRING, servername));
            
            var context = new SampleContext(builder.Options);
            return context;
        }
    }
}
