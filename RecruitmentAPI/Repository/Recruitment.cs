using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecruitmentAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.OpenApi.Writers;
using System.Runtime.Remoting;
using Microsoft.AspNetCore.Mvc;

namespace RecruitmentAPI.Repository
{
    public class Recruitment : IRecruitment
    {
        private readonly hris_tagContext _context;

        private readonly ILogger<Recruitment> _logger;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(Recruitment));

        public Recruitment(hris_tagContext context, ILogger<Recruitment> logger)
        {
            _context = context;
            _logger = logger;
        }
        public bool RegisterCandidate(CandidateData req)
        {
            try
            {

                var obj = _context.CandidateData.Where(e => e.CandidateId == req.CandidateId).FirstOrDefault();

                obj.Pwd = req.Pwd;
                obj.Email = req.Email;
                obj.PhoneNumber = req.PhoneNumber;
                obj.FirstName = req.FirstName;
                obj.MiddleName = req.MiddleName;
                obj.LastName = req.LastName;

                obj.Address = req.Address;
                obj.Gender = req.Gender;
                obj.TempAddress = req.TempAddress;
                obj.PerAddress = req.PerAddress;
                obj.Nationality = req.Nationality;
                obj.PassportNo = req.PassportNo;
                obj.Resume = req.Resume;
                //obj.ProfilePic = req.ProfilePic;
                obj.AdharNumber = req.AdharNumber;
                obj.ModifiedBy = req.ModifiedBy;
                obj.ModifiedDate = DateTime.Now;
                obj.RegStatus = 2; //Registration Status 1= Partially Registered, 2= Fully Registered.
                // In Registration call, the Candidate Registered Completely.

                _context.SaveChanges();

                return true;


            }
            catch
            {
                return false;
            }
        }

        public PersonalInfoModel Login(string username, string password)
        {
            PersonalInfoModel info = new PersonalInfoModel();
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    return null;

                var user = _context.CandidateData.FirstOrDefault(x => x.Email == username);

                if (user.Email == username && user.Pwd == password)
                {
                    //return user.CandidateId;
                    info.CandidateId = user.CandidateId;
                    info.FirstName = user.FirstName;
                    info.LastName = user.LastName;
                    info.Email = user.Email;
                    info.PhoneNumber = user.PhoneNumber;
                }

                return info;
            }
            catch
            {
                return null;
            }
        }
        public bool AdditionalDetails(AdditionalDetails req)
        {
            try
            {
                _context.AdditionalDetails.Add(req);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EducationDetails(EducationDetails req)
        {
            try
            {
                _context.EducationDetails.Add(req);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EmploymentDetails(EmploymentDetails req)
        {
            var Message = $" EmploymentDetails About page visited at {DateTime.Now}";
            _logger.LogInformation("EmploymentDetails Message displayed: {Message}", Message);
            _log4net.Debug(" EmploymentDetails Login API " + Message);

            try
            {
                if (req.EmployeedFrom.HasValue)
                {
                    _log4net.Info("EmploymentDetails invoked:: " + req.EmployeedFrom);
                    req.EmployeedFrom = DateTime.Now;
                }
                _log4net.Info("EmploymentDetails 2222invoked:: " + req.EmployeedFrom);


                _context.EmploymentDetails.Add(req);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public int CreateProfile(CandidateData req)
        {
            try
            {
                req.CreatedDate = DateTime.Now;
                req.PhoneNumber = "";
                req.Address = "";
                req.CreatedBy = req.FirstName;
                req.Gender = "";
                req.RegStatus = 1; //Registration Status 1= Partially Registered, 2= Fully Registered.
                // In Crteate Profile, We are Partially Registering the Candiddate.
                _context.CandidateData.Add(req);
                _context.SaveChanges();
                int x = req.CandidateId;
                return x;
                //return true;
            }
            catch
            {
                return -1;
            }
        }

        public bool SkillsDetails(SkillsDetails req)
        {

            try
            {

                _context.SkillsDetails.Add(req);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddressDetails(AddressDetails req)
        {

            try
            {

                _context.AddressDetails.Add(req);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CurrentEmploymentDetails(CurrentEmploymentDetails req)
        {

            try
            {

                _context.CurrentEmploymentDetails.Add(req);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool VisaDetails(VisaDetails req)
        {

            try
            {

                _context.VisaDetails.Add(req);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public PersonalInfoModel GetCandidateById(int id)
        {
            var obj = _context.CandidateData.Where(e => e.CandidateId == id).FirstOrDefault();

            PersonalInfoModel info = new PersonalInfoModel();

            if (obj != null)
            {
                info.CandidateId = obj.CandidateId;
                info.FirstName = obj.FirstName;
                info.MiddleName = obj.MiddleName;
                info.LastName = obj.LastName;
                info.Email = obj.Email;
                info.Gender = obj.Gender;
                info.AdharNumber = obj.AdharNumber;
                info.Nationality = obj.Nationality;
                info.PassportNo = obj.PassportNo;
                info.ProfilePic = obj.ProfilePic;
                info.Resume = obj.Resume;
            }

            return info;
        }

        public bool GetAadhar(string aadhar)
        {
            bool resp = false;
            try
            {

                resp = _context.CandidateData.Any(x => x.AdharNumber == aadhar);


                return resp;
            }
            catch
            {
                return resp;
            }
        }

        public bool GetEmail(string email)
        {
            bool resp = false;
            try
            {

                resp = _context.CandidateData.Any(x => x.Email == email);


                return resp;
            }
            catch
            {
                return resp;
            }
        }

        public bool GetMobile(string mobile)
        {
            bool resp = false;
            try
            {

                resp = _context.CandidateData.Any(x => x.PhoneNumber == mobile);


                return resp;
            }
            catch
            {
                return resp;
            }
        }

        public List<AdditionalDetails> GetAdditionalDetails(int id)
        {
            List<AdditionalDetails> resp = new List<AdditionalDetails>();
            try
            {
                resp = _context.AdditionalDetails.Where(e => e.CandidateId == id).ToList();
                return resp;
            }
            catch
            {
                return resp;
            }
        }

        public List<AddressModel> GetAddresses(int id)
        {
            List<AddressModel> resp = new List<AddressModel>();

            try
            {
                var obj = _context.AddressDetails.Where(e => e.CandidateId == id).Select(e => new AddressModel()
                {
                    Id = e.Id,
                    Address1 = e.Address1,
                    Address2 = e.Address2,
                    Landmark = e.Landmark,
                    City = e.City,
                    State = e.State,
                    Country = e.Country,
                    IsSame = e.IsSame
                }).ToList();

                if (obj.Count > 0)
                {
                    resp = obj;
                }
                return resp;
            }
            catch
            {
                return resp;
            }
        }

        public List<EducDetailModel> GetEducationDetail(int id)
        {
            List<EducDetailModel> resp = new List<EducDetailModel>();

            try
            {
                var obj = _context.EducationDetails.Where(e => e.CandidateId == id).Select(e => new EducDetailModel()
                {
                    Id = e.Id,
                    Course = e.Course,
                    Stream = e.Stream,
                    Institution = e.Institution,
                    University = e.University,
                    Location = e.Location,
                    Percentage = e.Percentage,
                    YearOfPassing = e.YearOfPassing
                }).ToList();

                if (obj.Count > 0) resp = obj;
                
                return resp;
            }
            catch
            {
                return resp;
            }
        }

        public List<EmployerInfoModel> GetEmploymentDetail(int id)
        {
            List<EmployerInfoModel> resp = new List<EmployerInfoModel>();

            try
            {
                var obj = _context.EmploymentDetails.Where(e => e.CandidateId == id).Select(e => new EmployerInfoModel()
                {
                    Id = e.Id,
                    CompanyName= e.CompanyName,
                    PayrollCompany = e.PayrollCompany,
                    Designation = e.Designation,
                    EmployeedFrom = e.EmployeedFrom,
                    EmployeedTo = e.EmployeedTo,
                    Experience = e.Experience,
                    ReasonforChange = e.ReasonforChange,
                    CurrentCtc = e.CurrentCtc,
                    IsCurrent = e.IsCurrent
                }).ToList();

                if (obj.Count > 0) resp = obj;

                return resp;
            }
            catch
            {
                return resp;
            }
            
        }

        public CurrEmploymentAddlInfo GetCurrEmploymentDetail(int id)
        {
            var obj = _context.CurrentEmploymentDetails.Where(e => e.CandidateId == id).FirstOrDefault();

            CurrEmploymentAddlInfo info = new CurrEmploymentAddlInfo();

            if (obj != null)
            {
                info.TotalExperience = obj.TotalExperience;
                info.ExpectedCtc = obj.ExpectedCtc;
                info.CurrentLocation = obj.CurrentLocation;
                info.NoticePeriod = obj.NoticePeriod;
                info.PreferredLocation = obj.PreferredLocation;
            }

            return info;
        }

        public List<SkillsInfoModel> GetSkillsDetails(int id)
        {
            List<SkillsInfoModel> resp = new List<SkillsInfoModel>();

            try
            {
                var obj = _context.SkillsDetails.Where(e => e.CandidateId == id).Select(e => new SkillsInfoModel()
                {
                    Id = e.Id,
                    SkillType = e.Type,
                    Skills = e.Skills,
                    SubSkills=e.SubSkills,
                    Version = e.Version,
                    LastUsed = e.LastUsed,
                    ExpInMonths=e.ExpInMonths,
                    ExpInYrs = e.ExpInYrs
                }).ToList();

                if (obj.Count > 0) resp = obj;

                return resp;
            }
            catch
            {
                return resp;
            }
        }

        public List<VisaInfoModel> GetVisaDetails(int id)
        {
            List<VisaInfoModel> resp = new List<VisaInfoModel>();
            try
            {
                var obj = _context.VisaDetails.Where(e => e.CandidateId == id).Select(e => new VisaInfoModel()
                {
                    Id = e.Id,
                    TypeOfValidVisaHold = e.TypeOfValidVisaHold,
                    ValidityTill = e.ValidityTill,
                    OnSiteTravelExperience = e.OnSiteTravelExperience
                }).ToList();

                if (obj.Count > 0) resp = obj;

                return resp;
            }
            catch
            {
                return resp;
            }

        }

        public List<AddlInfoModel> GetAdditionalDetail(int id)
        {
            List<AddlInfoModel> resp = new List<AddlInfoModel>();

            try
            {
                var obj = _context.AdditionalDetails.Where(e => e.CandidateId == id).Select(e => new AddlInfoModel()
                {
                    Id = e.Id,
                    AdditionalDocs = e.AdditionalDocs,
                    Channel = e.Channel,
                    Reason = e.Reason,
                    WhyValueLabs = e.WhyValueLabs,
                    ReferredBy = e.ReferredBy,
                    ReferredById = e.ReferredById,
                    IsExEmployee = e.IsExEmployee,
                    Duration = e.Duration
                }).ToList();

                if (obj.Count > 0) resp = obj;

                return resp;
            }
            catch
            {
                return resp;
            }
        }

        public string UpdateProfilePic(ProfilepicModel pic)
        {
            try
            {
                var obj = _context.CandidateData.Where(e => e.CandidateId == pic.UserId).FirstOrDefault();

                obj.ProfilePic = pic.ProfilePic;
                _context.SaveChanges();

                return obj.ProfilePic;
            }
            catch
            {
                return "";
            }
        }

        public bool ProjectDetails(ProjectDetails req)
        {
            var Message = $" ProjectDetails About page visited at {DateTime.Now}";
            _logger.LogInformation("ProjectDetails Message displayed: {Message}", Message);
            _log4net.Debug(" ProjectDetails Login API " + Message);

            try
            {
                _context.ProjectDetails.Add(req);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}