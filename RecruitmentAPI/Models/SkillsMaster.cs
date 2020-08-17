using System;
using System.Collections.Generic;

namespace RecruitmentAPI.Models
{
    public partial class SkillsMaster
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public sbyte? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
