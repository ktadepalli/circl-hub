using System.Collections.Generic;
using System.Threading.Tasks;
using RecruitmentAPI.Models;

namespace RecruitmentAPI.Repository
{
    public interface IRecruitment
    {
        bool RegisterCandidate(CandidateData req);
        PersonalInfoModel GetCandidateById(int id);
        List<AddressModel> GetAddresses(int id);
        List<EducDetailModel> GetEducationDetail(int id);
        List<EmployerInfoModel> GetEmploymentDetail(int id);
        CurrEmploymentAddlInfo GetCurrEmploymentDetail(int id);
        List<SkillsInfoModel> GetSkillsDetails(int id);
        List<VisaInfoModel> GetVisaDetails(int id);
        List<AddlInfoModel> GetAdditionalDetail(int id);



        PersonalInfoModel Login(string username, string password);
        bool AdditionalDetails(AdditionalDetails req);
        bool EducationDetails(EducationDetails req);
        bool EmploymentDetails(EmploymentDetails req);
        int CreateProfile(CandidateData req);
        bool SkillsDetails(SkillsDetails req);
        bool AddressDetails(AddressDetails req);
        bool CurrentEmploymentDetails(CurrentEmploymentDetails req);
        bool VisaDetails(VisaDetails req);
        bool GetAadhar(string aadhar);
        bool GetEmail(string email);
        bool GetMobile(string mobile);

        string UpdateProfilePic(ProfilepicModel pic);
        bool ProjectDetails(ProjectDetails req);
    }
}