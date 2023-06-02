using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Skills")]
    public class ApplicantSkillPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Applicant { get; set; }
        public string Skill { get; set; }
        [Column("Skill_Level")]
        public string SkillLevel { get; set; }
        [Column("Start_Month")]
        public byte StartMonth { get; set; }
        [Column("Start_Year")]
        public Int32 StartYear { get; set; }
        [Column("End_Month")]
        public byte EndMonth { get; set; }
        [Column("End_Year")]
        public Int32 EndYear { get; set; }
        [Column("Time_Stamp")]
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public virtual ApplicantProfilePoco ApplicantProfile { get; set; }

    }
}
