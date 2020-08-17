using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentAPI.Models
{
    public class EmployerInfoModel
    {
        public int Id { get; set; }
        public sbyte? IsCurrent { get; set; }
        public string CompanyName { get; set; }
        public string PayrollCompany { get; set; }
        public string Designation { get; set; }
        public DateTime? EmployeedFrom { get; set; }
        public DateTime? EmployeedTo { get; set; }
        public string Experience { get; set; }
        public string ReasonforChange { get; set; }
        public string CurrentCtc { get; set; }
    }
}
