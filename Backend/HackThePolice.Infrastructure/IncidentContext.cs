using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using HackThePolice.Api.Core.Models;

namespace HackThePolice.Infrastructure
{
    public class IncidentContext : DbContext
    {
        public DbSet<Incident> Incidents { get; set; }

        public UserContext() : this(InfrastructureConstants.MAIN) { }

        public UserContext(string connectionStringName)
            : base(ConnectionStringCache.GetConnectionString(connectionStringName))
        {
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 180;
            //DbContextExtensions<ApiContext>.SetInitializer(
            //    new NullDatabaseInitializer<ApiContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Adding a Reg-Prefix so the tables will be grouped in the Database.
            modelBuilder.Entity<User>().ToTable("UsrUsers");
            modelBuilder.Entity<UserRegistrationDetails>().ToTable("UsrRegistrationDetails");
            modelBuilder.Entity<UserSuperIntendentPosition>().ToTable("UsrSuperIntendentPositions");
            modelBuilder.Entity<UserOtherRegulator>().ToTable("UsrOtherRegulators");
            modelBuilder.Entity<UserEducation>().ToTable("UsrEducations");
            modelBuilder.Entity<UserQualification>().ToTable("UsrQualifications");
            modelBuilder.Entity<UserRegulatoryBody>().ToTable("UsrRegulatoryBodies");
            modelBuilder.Entity<UserRole>().ToTable("UsrRoles");
            modelBuilder.Entity<PendingEmailChange>().ToTable("UsrPendingEmailChanges");

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
