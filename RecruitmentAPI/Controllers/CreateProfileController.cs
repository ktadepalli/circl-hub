using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecruitmentAPI.Models;
using RecruitmentAPI.Repository;
using System.IO;
using System.Net.Http;
using System.Net;
//using System.Net.HttpRequestBase;

namespace RecruitmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreateProfileController : ControllerBase
    {
        private readonly IRecruitment _repo;
        private readonly ILogger<CreateProfileController> _logger;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(CreateProfileController));
        public CreateProfileController(IRecruitment repo, ILogger<CreateProfileController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpPost]
        public ResponseModel CreateProfile([FromBody] CandidateData req)
        {
            var Message = $"About page visited at {DateTime.Now}";
            _logger.LogInformation("Message displayed: {Message}", Message);
            _log4net.Debug("Login API " + Message);
            _log4net.Info("GetEmployee invoked");
            
            ResponseModel resp = new ResponseModel();
            
            try
            {
                CandidateData cd = new CandidateData();

                cd.Pwd = "Vl@123";
                cd.Email = req.Email;
                cd.FirstName = req.FirstName;
                cd.LastName = req.LastName;

                cd.Nationality = req.Nationality;
                cd.Resume = req.Resume;

                int id = _repo.CreateProfile(cd);

                //var obj = cd;
                resp.Message = "Success";
                resp.Status = true;
                resp.Data = cd;

                // var response = Request.CreateResponse(HttpStatusCode.OK);
                // response.Content = new StringContent(resp, Encoding.UTF8, "application/json");

                //return Request.CreateResponse(HttpStatusCode.OK, resp);

                return resp;


                //return Ok("Success");

            }
            catch
            {
                return resp;
            }
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> UploadDocument(IFormFile file)
        {
            string path = string.Empty;
            string status = "Failed";
            string DocMentId = string.Empty;
            try
            {
                // Extract file name from whatever was posted by browser
                var fileName = System.IO.Path.GetFileName(file.FileName);
                _logger.LogInformation("Upload fileName displayed: ", fileName);
                // If file with same name exists delete it
                DocMentId = DateTime.UtcNow.ToString("MMddyyyyHHmmss") + DateTime.UtcNow.Millisecond;
                path = Path.Combine(
                     Directory.GetCurrentDirectory(), "UploadResumes",
                     DocMentId + "_" + file.FileName);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                // Create new local file and copy contents of uploaded file
                using (var localFile = System.IO.File.OpenWrite(path))
                using (var uploadedFile = file.OpenReadStream())
                {

                    uploadedFile.CopyTo(localFile);
                    status = "Success";
                }
            }
            catch (Exception ex)
            {
                path = string.Empty;
                status = "Failed";
                DocMentId = string.Empty;
            }

            return Ok(new { Status = status, ID = file.FileName + "_" + DocMentId, path = path });
        }

    }
}