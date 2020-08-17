using System;
using System.Collections.Generic;

namespace RecruitmentAPI.Models
{
    public partial class AppliedUserData
    {
        public int? Id { get; set; }
        public string Experience { get; set; }
        public DateTime? AppliedAtTimestamp { get; set; }
        public int? JobId { get; set; }
        public int? CandidateId { get; set; }
    }
}
