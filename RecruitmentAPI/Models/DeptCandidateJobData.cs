using System;
using System.Collections.Generic;

namespace RecruitmentAPI.Models
{
    public partial class DeptCandidateJobData
    {
        public int TrackingId { get; set; }
        public int? CandidateJobId { get; set; }
        public string Comments { get; set; }
        public int? StatusId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual CandidateJobData CandidateJob { get; set; }
        public virtual StatusMaster Status { get; set; }
    }
}
