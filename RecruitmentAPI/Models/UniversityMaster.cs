using System;
using System.Collections.Generic;

namespace RecruitmentAPI.Models
{
    public partial class UniversityMaster
    {
        public int UniversityId { get; set; }
        public string UniversityName { get; set; }
        public sbyte? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
