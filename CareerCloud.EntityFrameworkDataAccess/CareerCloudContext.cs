using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class CareerCloudContext : DbContext
    {
        public DbSet<ApplicantEducationPoco>? ApplicantEducations { get; set; }
        public DbSet<ApplicantJobApplicationPoco>? ApplicantJobApplications { get; set; }
        public DbSet<ApplicantProfilePoco>? ApplicantProfiles { get; set; }
        public DbSet<ApplicantResumePoco>? ApplicantResumes { get; set; }
        public DbSet<ApplicantSkillPoco>? ApplicantSkills { get; set; }
        public DbSet<ApplicantWorkHistoryPoco>? ApplicantWorkHistories { get; set; }
        public DbSet<CompanyDescriptionPoco>? CompanyDescriptions { get; set; }
        public DbSet<CompanyJobDescriptionPoco>? CompanyJobDescriptions { get; set; }
        public DbSet<CompanyJobEducationPoco>? CompanyJobEducations { get; set; }
        public DbSet<CompanyJobPoco>? CompanyJobs { get; set; }
        public DbSet<CompanyJobSkillPoco>? CompanyJobSkills { get; set; }
        public DbSet<CompanyLocationPoco>? CompanyLocations { get; set; }
        public DbSet<CompanyProfilePoco>? CompanyProfile { get; set; }
        public DbSet<SecurityLoginPoco>? SecurityLogins { get; set; }
        public DbSet<SecurityLoginsLogPoco>? SecurityLoginsLogs { get; set; }
        public DbSet<SecurityLoginsRolePoco>? SecurityLoginsRoles { get; set; }
        public DbSet<SecurityRolePoco>? SecurityRoles { get; set; }
        public DbSet<SystemCountryCodePoco>? SystemCountryCodes { get; set; }
        public DbSet<SystemLanguageCodePoco>? SystemLanguageCodes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=SOHAD-PC\HUMBERBRIDGING;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region CompanyLocations
            builder.Entity<CompanyLocationPoco>().Ignore(x => x.SystemCountryCode);
            #endregion

            #region SystemLanguageCodePoco
            builder.Entity<SystemLanguageCodePoco>().HasMany(x => x.CompanyDescriptions).WithOne(x => x.SystemLanguageCode)
                .HasForeignKey(x => x.LanguageId);
            #endregion

            #region SystemCountryCodePoco
            builder.Entity<SystemCountryCodePoco>().HasMany(x => x.ApplicantWorkHistories).WithOne(x => x.SystemCountryCode)
                .HasForeignKey(x => x.CountryCode);

            builder.Entity<SystemCountryCodePoco>().HasMany(x => x.ApplicantProfiles).WithOne(x => x.SystemCountryCode)
                .HasForeignKey(x => x.Country);
            #endregion

            #region SecurityRolePoco
            builder.Entity<SecurityRolePoco>().HasMany(x => x.SecurityLoginsRoles).WithOne(x => x.SecurityRole)
                .HasForeignKey(x => x.Id);
            #endregion

            #region SecurityLoginPoco
            builder.Entity<SecurityLoginPoco>().HasMany(x => x.SecurityLoginsLogs).WithOne(x => x.SecurityLogin)
                .HasForeignKey(x => x.Login);

            builder.Entity<SecurityLoginPoco>().HasMany(x => x.ApplicantProfiles).WithOne(x => x.SecurityLogin)
                .HasForeignKey(x => x.Login);

            builder.Entity<SecurityLoginPoco>().HasMany(x => x.SecurityLoginsRoles).WithOne(x => x.SecurityLogin)
                .HasForeignKey(x => x.Login);
            #endregion

            #region ApplicantProfilePoco
            builder.Entity<ApplicantProfilePoco>().HasMany(x => x.ApplicantSkills).WithOne(x => x.ApplicantProfile)
                .HasForeignKey(x => x.Applicant);

            builder.Entity<ApplicantProfilePoco>().HasMany(x => x.ApplicantResumes).WithOne(x => x.ApplicantProfile)
                .HasForeignKey(x => x.Applicant);

            builder.Entity<ApplicantProfilePoco>().HasMany(x => x.ApplicantWorkHistorys).WithOne(x => x.ApplicantProfile)
                .HasForeignKey(x => x.Applicant);

            builder.Entity<ApplicantProfilePoco>().HasMany(x => x.ApplicantJobApplications).WithOne(x => x.ApplicantProfile)
                .HasForeignKey(x => x.Applicant);

            builder.Entity<ApplicantProfilePoco>().HasMany(x => x.ApplicantEducations).WithOne(x => x.ApplicantProfile)
                .HasForeignKey(x => x.Applicant);
            #endregion

            #region CompanyJobPoco
            builder.Entity<CompanyJobPoco>()
                .HasMany(x => x.CompanyJobEducations).WithOne(x => x.CompanyJob)
                .HasForeignKey(x => x.Job);

            builder.Entity<CompanyJobPoco>().HasMany(x => x.CompanyJobDescriptions).WithOne(x => x.CompanyJob)
                .HasForeignKey(x => x.Job);

            builder.Entity<CompanyJobPoco>().HasMany(x => x.CompanyJobSkills).WithOne(x => x.CompanyJob)
                .HasForeignKey(x => x.Job);

            builder.Entity<CompanyJobPoco>().HasMany(x => x.ApplicantJobApplications).WithOne(x => x.CompanyJob)
                .HasForeignKey(x => x.Job);
            #endregion

            #region CompanyProfilePoco
            builder.Entity<CompanyProfilePoco>().HasMany(x => x.CompanyLocations).WithOne(x => x.CompanyProfile)
                .HasForeignKey(x => x.Company);

            builder.Entity<CompanyProfilePoco>().HasMany(x => x.CompanyDescriptions).WithOne(x => x.CompanyProfile)
                .HasForeignKey(x => x.Company);

            builder.Entity<CompanyProfilePoco>().HasMany(x => x.CompanyJobs).WithOne(x => x.CompanyProfile)
                .HasForeignKey(x => x.Company);
            #endregion
            
        }



    }
}
