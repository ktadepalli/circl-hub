using System;
using System.Collections.Generic;

namespace RecruitmentAPI.Models
{
    public partial class ExperienceMaster
    {
        public int ExpId { get; set; }
        public string ExpName { get; set; }
        public sbyte? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
