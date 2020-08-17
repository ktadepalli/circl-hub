using System;
using System.Collections.Generic;

namespace RecruitmentAPI.Models
{
    public partial class CurrentEmploymentDetails
    {
        public int Id { get; set; }
        public string TotalExperience { get; set; }
        public string ExpectedCtc { get; set; }
        public string NoticePeriod { get; set; }
        public string CurrentLocation { get; set; }
        public string PreferredLocation { get; set; }
        public int? EmploymentType { get; set; }
        public int? CandidateId { get; set; }

        public virtual CandidateData Candidate { get; set; }
    }
}
