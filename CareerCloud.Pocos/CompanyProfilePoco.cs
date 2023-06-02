using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Company_Profiles")]
    public class CompanyProfilePoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        [Column("Registration_Date")]
        public DateTime RegistrationDate { get; set; }
        [Column("Company_Website")]
        public string? CompanyWebsite { get; set; }
        [Column("Contact_Phone")]
        public string? ContactPhone { get; set; }
        [Column("Contact_Name")]
        public string? ContactName { get; set; }
        [Column("Company_Logo")]
        public byte[]? CompanyLogo { get; set; }
        [Column("Time_Stamp")]
        [Timestamp]
        public byte[]? TimeStamp { get; set; }

        public virtual ICollection<CompanyDescriptionPoco>? CompanyDescriptions { get; set; }
        public virtual ICollection<CompanyJobPoco>? CompanyJobs { get; set; }
        public virtual ICollection<CompanyLocationPoco>? CompanyLocations { get; set; }
    }
}
