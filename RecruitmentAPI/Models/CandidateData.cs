using System;
using System.Collections.Generic;

namespace RecruitmentAPI.Models
{
    public partial class CandidateData
    {
        public CandidateData()
        {
            AdditionalDetails = new HashSet<AdditionalDetails>();
            AddressDetails = new HashSet<AddressDetails>();
            CandidateJobData = new HashSet<CandidateJobData>();
            CandidateNotifications = new HashSet<CandidateNotifications>();
            CurrentEmploymentDetails = new HashSet<CurrentEmploymentDetails>();
            EducationDetails = new HashSet<EducationDetails>();
            EmploymentDetails = new HashSet<EmploymentDetails>();
            ProjectDetails = new HashSet<ProjectDetails>();
            SkillsDetails = new HashSet<SkillsDetails>();
            VisaDetails = new HashSet<VisaDetails>();
        }

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
        public int? RegStatus { get; set; }

        public virtual ICollection<AdditionalDetails> AdditionalDetails { get; set; }
        public virtual ICollection<AddressDetails> AddressDetails { get; set; }
        public virtual ICollection<CandidateJobData> CandidateJobData { get; set; }
        public virtual ICollection<CandidateNotifications> CandidateNotifications { get; set; }
        public virtual ICollection<CurrentEmploymentDetails> CurrentEmploymentDetails { get; set; }
        public virtual ICollection<EducationDetails> EducationDetails { get; set; }
        public virtual ICollection<EmploymentDetails> EmploymentDetails { get; set; }
        public virtual ICollection<ProjectDetails> ProjectDetails { get; set; }
        public virtual ICollection<SkillsDetails> SkillsDetails { get; set; }
        public virtual ICollection<VisaDetails> VisaDetails { get; set; }
    }
}
