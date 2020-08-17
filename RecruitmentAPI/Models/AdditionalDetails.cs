using System;
using System.Collections.Generic;

namespace RecruitmentAPI.Models
{
    public partial class AdditionalDetails
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public string AdditionalDocs { get; set; }
        public string Channel { get; set; }
        public string Reason { get; set; }
        public string WhyValueLabs { get; set; }
        public string ReferredBy { get; set; }
        public string ReferredById { get; set; }
        public sbyte? IsExEmployee { get; set; }
        public string Duration { get; set; }

        public virtual CandidateData Candidate { get; set; }
    }
}
