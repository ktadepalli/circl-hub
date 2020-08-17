using System;
using System.Collections.Generic;

namespace RecruitmentAPI.Models
{
    public partial class RoleMaster
    {
        public RoleMaster()
        {
            JobPostings = new HashSet<JobPostings>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public sbyte? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<JobPostings> JobPostings { get; set; }
    }
}
