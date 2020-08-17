using System;
using System.Collections.Generic;

namespace RecruitmentAPI.Models
{
    public partial class JobPostings
    {
        public JobPostings()
        {
            CandidateJobData = new HashSet<CandidateJobData>();
        }

        public int JobId { get; set; }
        public string JobCode { get; set; }
        public string JobDescription { get; set; }
        public int DeptId { get; set; }
        public int LocationId { get; set; }
        public sbyte IsActive { get; set; }
        public string Experience { get; set; }
        public string SalaryDetails { get; set; }
        public string JobTitle { get; set; }
        public int? RoleId { get; set; }
        public string QualificationDetails { get; set; }
        public string RecruiterName { get; set; }
        public string Requirements { get; set; }
        public string Responsibities { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public sbyte? IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public int? SkillsId { get; set; }
        public int? ExpId { get; set; }
        public int? EmptypeId { get; set; }
        public int? Nofpos { get; set; }

        public virtual DeptMaster Dept { get; set; }
        public virtual LocationMaster Location { get; set; }
        public virtual RoleMaster Role { get; set; }
        public virtual ICollection<CandidateJobData> CandidateJobData { get; set; }
    }
}
