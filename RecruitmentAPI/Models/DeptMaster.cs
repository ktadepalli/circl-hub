using System;
using System.Collections.Generic;

namespace RecruitmentAPI.Models
{
    public partial class DeptMaster
    {
        public DeptMaster()
        {
            JobPostings = new HashSet<JobPostings>();
            JobTitleMaster = new HashSet<JobTitleMaster>();
        }

        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public sbyte IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<JobPostings> JobPostings { get; set; }
        public virtual ICollection<JobTitleMaster> JobTitleMaster { get; set; }
    }
}
