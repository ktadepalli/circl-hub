using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecruitmentAPI.Models;
using RecruitmentAPI.Repository;


namespace RecruitmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IRecruitment _repo;
        public RegistrationController(IRecruitment repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Controller For Registration
        /// </summary>
        [HttpPost]
        public ResponseModel RegisterCandidate([FromBody] RegistrationModel req)
        {
            ResponseModel response = new ResponseModel();
            bool eduDetails = false;
            bool empDetails = false;
            bool skillsDetails = false;
            bool addressDetails = false;
            bool canData = false;
            bool curEmpDetails = false;
            bool visaDetails = false;
            bool projDetails = false;
            try
            {
                CandidateData cd = new CandidateData();
                cd.CandidateId = req.CandidateId;
                cd.Pwd = req.Pwd;
                cd.Email = req.Email;
                cd.PhoneNumber = req.PhoneNumber;
                cd.FirstName = req.FirstName;
                cd.MiddleName = req.MiddleName;
                cd.LastName = req.LastName;

                cd.Address = req.Address;
                cd.Gender = req.Gender;
                cd.TempAddress = req.TempAddress;
                cd.PerAddress = req.PerAddress;
                cd.Nationality = req.Nationality;
                cd.PassportNo = req.PassportNo;
                cd.Resume = req.Resume;
                cd.ProfilePic = req.ProfilePic;
                cd.AdharNumber = req.AdharNumber;

                canData = _repo.RegisterCandidate(cd);

                AdditionalDetails ad = new AdditionalDetails();
                ad.CandidateId = req.CandidateId;
                ad.Channel = req.Channel;
                ad.Reason = req.Reason;
                ad.WhyValueLabs = req.WhyValueLabs;
                ad.ReferredBy = req.ReferredBy;
                ad.ReferredById = req.ReferredById;
                ad.IsExEmployee = req.IsExEmployee;
                ad.Duration = req.Duration;
                ad.AdditionalDocs = "NO";

                bool addDetails = _repo.AdditionalDetails(ad);


                //dynamic dynJson = JsonConvert.DeserializeObject(json);
                foreach (var item in req.EduDTO)
                {
                    item.CandidateId = req.CandidateId;
                    eduDetails = _repo.EducationDetails(item);
                }

                if (req.EmpType == 1)// If he is fresher, no need to insert in Employee details.
                {
                    empDetails = true;
                    projDetails = true;

                }

                else
                {

                    foreach (var item in req.EmpDTO)
                    {
                        // Console.WriteLine("{0} {1} {2} {3}\n", item.id, item.displayName,
                        //     item.slug, item.imageUrl);
                        item.CandidateId = req.CandidateId;
                        empDetails = _repo.EmploymentDetails(item);


                    }
                    foreach (var item in req.ProjectsDTO)
                    {
                        item.CandidateId = req.CandidateId;
                        empDetails = _repo.ProjectDetails(item);
                    }
                }

                foreach (var item in req.SkillsDTO)
                {
                    // Console.WriteLine("{0} {1} {2} {3}\n", item.id, item.displayName,
                    //     item.slug, item.imageUrl);
                    item.CandidateId = req.CandidateId;
                    skillsDetails = _repo.SkillsDetails(item);


                }

                foreach (var item in req.AddressDTO)
                {
                    item.CandidateId = req.CandidateId;
                    addressDetails = _repo.AddressDetails(item);
                }

                if (req.EmpType == 1)
                {
                    curEmpDetails = true;
                    visaDetails = true;
                }
                else
                {
                    foreach (var item in req.CurEmpDTO)
                    {
                        item.CandidateId = req.CandidateId;
                        curEmpDetails = _repo.CurrentEmploymentDetails(item);
                    }

                    foreach (var item in req.VisaDTO)
                    {
                        item.CandidateId = req.CandidateId;
                        visaDetails = _repo.VisaDetails(item);
                    }
                }

                if (eduDetails && empDetails && skillsDetails && addressDetails && canData && curEmpDetails && visaDetails)
                {
                    response.Message = "Success";
                    response.Status = true;
                    response.Data = null;
                    return response;
                }
                else
                {
                    response.Message = "Failed";
                    response.Status = false;
                    response.Data = null;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                response.Data = null;
                return response;
            }
        }

        [HttpGet]
        public ResponseModel Get(int id)
        {

            ResponseModel response = new ResponseModel();
            RegistrationViewModel objView = new RegistrationViewModel();

            objView.PersonalInfo = _repo.GetCandidateById(id);
            objView.AddressDetail = _repo.GetAddresses(id);
            objView.EducationDetail = _repo.GetEducationDetail(id);
            objView.EmploymentDetail = _repo.GetEmploymentDetail(id);
            objView.CurrEmploymentDetail = _repo.GetCurrEmploymentDetail(id);
            objView.SkillsDetails = _repo.GetSkillsDetails(id);
            objView.VisaDetails = _repo.GetVisaDetails(id);

            objView.AdditionalDetail = _repo.GetAdditionalDetail(id);
            

            response.Message = "Success";
            response.Status = true;
            response.Data = objView;

            return response;
        }

        [HttpGet]
        [Route("Aadhar/{aadhar}")]
        public ResponseModel GetAadhar(string aadhar)
        {
            ResponseModel response = new ResponseModel();
            bool isAadharExists = false;
            try
            {

                isAadharExists = _repo.GetAadhar(aadhar);

                response.Message = "Success";
                response.Status = isAadharExists;
                response.Data = null;
                return response;

            }
            catch (Exception ex)
            {
                return response;
            }

        }

        [HttpGet]
        [Route("Email/{email}")]
        public ResponseModel GetEmail(string email)
        {
            ResponseModel response = new ResponseModel();
            bool isAadharExists = false;
            try
            {

                isAadharExists = _repo.GetEmail(email);

                response.Message = "Success";
                response.Status = isAadharExists;
                response.Data = null;
                return response;

            }
            catch (Exception ex)
            {
                return response;
            }

        }

        [HttpGet]
        [Route("Mobile/{mobile}")]
        public ResponseModel GetMobile(string mobile)
        {
            ResponseModel response = new ResponseModel();
            bool isAadharExists = false;
            try
            {

                isAadharExists = _repo.GetMobile(mobile);

                response.Message = "Success";
                response.Status = isAadharExists;
                response.Data = null;
                return response;

            }
            catch (Exception ex)
            {
                return response;
            }

        }

        [HttpPost]
        [Route("ProfilePic")]
        public string UpdateProfilePic([FromBody] ProfilepicModel profilepic)
        {
            string response = string.Empty;

            
            try
            {

                response  = _repo.UpdateProfilePic(profilepic);

                return response;

            }
            catch (Exception ex)
            {
                return response;
            }

        }

    }
}