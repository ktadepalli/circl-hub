using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentAPI.Models
{
    public class EducDetailModel
    {
        public int Id { get; set; }
        public string Course { get; set; }
        public string Stream { get; set; }
        public string Institution { get; set; }
        public string University { get; set; }
        public string Location { get; set; }
        public string YearOfPassing { get; set; }
        public string Percentage { get; set; }
    }
}
