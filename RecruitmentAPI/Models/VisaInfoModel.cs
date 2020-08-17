using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentAPI.Models
{
    public class VisaInfoModel
    {
        public int Id { get; set; }
        public string TypeOfValidVisaHold { get; set; }
        public string ValidityTill { get; set; }
        public string OnSiteTravelExperience { get; set; }
    }
}
