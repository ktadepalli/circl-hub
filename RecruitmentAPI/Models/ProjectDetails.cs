using System;
using System.Collections.Generic;

namespace RecruitmentAPI.Models
{
    public partial class ProjectDetails
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public string ProjectName { get; set; }
        public string ClientName { get; set; }
        public string Organization { get; set; }
        public string TeamSize { get; set; }
        public string Domain { get; set; }
        public string TechnologiesUsed { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public string RolesResponsibilities { get; set; }

        public virtual CandidateData Candidate { get; set; }
    }
}
