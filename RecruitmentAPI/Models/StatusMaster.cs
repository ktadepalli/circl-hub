using System;
using System.Collections.Generic;

namespace RecruitmentAPI.Models
{
    public partial class StatusMaster
    {
        public StatusMaster()
        {
            DeptCandidateJobData = new HashSet<DeptCandidateJobData>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public sbyte IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<DeptCandidateJobData> DeptCandidateJobData { get; set; }
    }
}
