using System;
using System.Collections.Generic;

namespace RecruitmentAPI.Models
{
    public partial class VisaDetails
    {
        public int Id { get; set; }
        public string TypeOfValidVisaHold { get; set; }
        public string ValidityTill { get; set; }
        public int? CandidateId { get; set; }
        public string OnSiteTravelExperience { get; set; }

        public virtual CandidateData Candidate { get; set; }
    }
}
