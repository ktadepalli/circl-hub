using System;
using System.Collections.Generic;

namespace RecruitmentAPI.Models
{
    public partial class AddressDetails
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Landmark { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Type { get; set; }
        public sbyte? IsSame { get; set; }

        public virtual CandidateData Candidate { get; set; }
    }
}
