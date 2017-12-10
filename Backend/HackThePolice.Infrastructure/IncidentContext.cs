using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using HackThePolice.Infrastructure.Core.Models;

namespace HackThePolice.Infrastructure
{
    public class IncidentContext : DbContext
    {
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Statement> Statements { get; set; }

        public IncidentContext() : this(InfrastructureConstants.MAIN) { }

        public IncidentContext(string connectionStringName)
            : base(connectionStringName)
        {
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 180;
            //DbContextExtensions<ApiContext>.SetInitializer(
            //    new NullDatabaseInitializer<ApiContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Adding a Reg-Prefix so the tables will be grouped in the Database.
            //modelBuilder.Entity<Incident>().ToTable("Incidents");
            //modelBuilder.Entity<Statement>().ToTable("Statements");

            //modelBuilder.Entity<User>()
            //    .HasOptional(x => x.RegistrationDetails)
            //    .WithOptionalDependent()
            //    .WillCascadeOnDelete(false);
            //
            //modelBuilder.Entity<User>()
            //    .HasOptional(x => x.Address)
            //    .WithOptionalDependent()
            //    .WillCascadeOnDelete(false);
            //
            //modelBuilder.Entity<User>()
            //    .HasOptional(x => x.ContactDetails)
            //    .WithOptionalDependent()
            //    .WillCascadeOnDelete(false);
        }
    }

    public class InfrastructureConstants
    {
        public static string MAIN = "Main";
    }
}
