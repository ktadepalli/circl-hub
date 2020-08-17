using System;
using System.Collections.Generic;

namespace RecruitmentAPI.Models
{
    public partial class SkillsDetails
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public string Type { get; set; }
        public string Skills { get; set; }
        public string Version { get; set; }
        public string LastUsed { get; set; }
        public string SubSkills { get; set; }
        public string ExpInMonths { get; set; }
        public string ExpInYrs { get; set; }

        public virtual CandidateData Candidate { get; set; }
    }
}
