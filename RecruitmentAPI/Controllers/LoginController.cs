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
    public class LoginController: ControllerBase
    {
        private readonly IRecruitment _repo;

        public LoginController(IRecruitment repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public ResponseModel Login([FromBody]AuthModal req)
        {

            ResponseModel response = new ResponseModel();
            response.Message = "Unauthorized User";
            response.Status = false;
            response.Data = 0;

            //PersonalInfoModel info = new PersonalInfoModel();

            var user = _repo.Login(req.Email, req.Pwd);

            if(user!=null)
            {
                response.Message = "Authorized User";
                response.Status = true;
                response.Data = user;
            }

            return response;
        }
    }
}