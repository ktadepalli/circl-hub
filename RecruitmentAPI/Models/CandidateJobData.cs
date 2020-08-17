using System;
using System.Collections.Generic;

namespace RecruitmentAPI.Models
{
    public partial class CandidateJobData
    {
        public CandidateJobData()
        {
            DeptCandidateJobData = new HashSet<DeptCandidateJobData>();
        }

        public int CandidateJobId { get; set; }
        public int CandidateId { get; set; }
        public int JobId { get; set; }
        public int StatusId { get; set; }
        public string Comments { get; set; }
        public string CvPath { get; set; }
        public sbyte? IsEmailSubscribed { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? JobStatus { get; set; }

        public virtual CandidateData Candidate { get; set; }
        public virtual JobPostings Job { get; set; }
        public virtual ICollection<DeptCandidateJobData> DeptCandidateJobData { get; set; }
    }
}
