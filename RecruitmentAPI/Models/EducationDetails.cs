using System;
using System.Collections.Generic;

namespace RecruitmentAPI.Models
{
    public partial class EducationDetails
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public string Course { get; set; }
        public string Stream { get; set; }
        public string Institution { get; set; }
        public string University { get; set; }
        public string Location { get; set; }
        public string YearOfPassing { get; set; }
        public string Percentage { get; set; }

        public virtual CandidateData Candidate { get; set; }
    }
}
