using System;
using System.Collections.Generic;

namespace RecruitmentAPI.Models
{
    public partial class InstitutionMaster
    {
        public int InstitutionId { get; set; }
        public string InstitutionName { get; set; }
        public sbyte? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
