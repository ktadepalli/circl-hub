using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace RecruitmentAPI.Models
{
    public class RegistrationViewModel
    {
        public PersonalInfoModel PersonalInfo { get; set; }
        public List<AddressModel> AddressDetail { get; set; }
        public List<EducDetailModel> EducationDetail { get; set; }
        public List<EmployerInfoModel> EmploymentDetail { get; set; }
        public CurrEmploymentAddlInfo CurrEmploymentDetail { get; set; }
        public List<SkillsInfoModel> SkillsDetails { get; set; }
        public List<VisaInfoModel> VisaDetails { get; set; }
        public List<AddlInfoModel> AdditionalDetail { get; set; }
    }
}
