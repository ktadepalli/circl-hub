using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentAPI.Models
{
    public class PersonalInfoModel
    {
        public int CandidateId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string PassportNo { get; set; }
        public string PhoneNumber { get; set; }
        public string Resume { get; set; }
        public string AdharNumber { get; set; }
        public string ProfilePic { get; set; }
    }
}
