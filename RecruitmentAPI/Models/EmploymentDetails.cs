using System;
using System.Collections.Generic;

namespace RecruitmentAPI.Models
{
    public partial class EmploymentDetails
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public sbyte? IsCurrent { get; set; }
        public string CompanyName { get; set; }
        public string PayrollCompany { get; set; }
        public string Designation { get; set; }
        public DateTime? EmployeedFrom { get; set; }
        public DateTime? EmployeedTo { get; set; }
        public string Experience { get; set; }
        public string ReasonforChange { get; set; }
        public string CurrentCtc { get; set; }

        public virtual CandidateData Candidate { get; set; }
    }
}
