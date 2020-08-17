using System;
using System.Collections.Generic;

namespace RecruitmentAPI.Models
{
    public partial class CandidateNotifications
    {
        public int NotificationId { get; set; }
        public int? CandidateId { get; set; }
        public string JobFilter { get; set; }
        public sbyte? IsNotify { get; set; }
        public sbyte? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual CandidateData Candidate { get; set; }
    }
}
