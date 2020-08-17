using System;
using System.Collections.Generic;

namespace RecruitmentAPI.Models
{
    public class RegistrationModel
    {
        public int CandidateId { get; set; }
        public string Pwd { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Gender { get; set; }
        public string PerAddress { get; set; }
        public string TempAddress { get; set; }
        public string Nationality { get; set; }
        public string PassportNo { get; set; }
        public string MiddleName { get; set; }
        public string Resume { get; set; }
        public string ProfilePic { get; set; }
        public string AdharNumber { get; set; }
        // Additional Details Start
        public string AdditionalDocs { get; set; }
        public string Channel { get; set; }
        public string Reason { get; set; }
        public string WhyValueLabs { get; set; }
        public string ReferredBy { get; set; }
        public string ReferredById { get; set; }
        public sbyte? IsExEmployee { get; set; }
        public string Duration { get; set; }

        // Additional Details End
        public int EmpType { get; set; } // 1 - Fresher; 2 - Experienced
        //Education Details Start

        public List<EducationDetails> EduDTO { get; set; }


       

        //Education Details End

        //Employment Details Start

        public List<EmploymentDetails> EmpDTO { get; set; }

        public List<CurrentEmploymentDetails> CurEmpDTO { get; set; }
        public List<VisaDetails> VisaDTO { get; set; }

        public List<SkillsDetails> SkillsDTO { get; set; }

        public List<AddressDetails> AddressDTO { get; set; }
        public List<ProjectDetails> ProjectsDTO { get; set; }

        


    }

    public class EducationDetailsDTO
    {
        public string Course { get; set; }
        public string Stream { get; set; }
        public string Institute { get; set; }
        public string PeriodOfCourse { get; set; }
        public string Percentage { get; set; }
        public string Location { get; set; }
        public string YearOfPassing { get; set; }
    }
}