using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecruitmentAPI.Models;
using RecruitmentAPI.Repository;

using System.IO;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;

namespace RecruitmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommonController : ControllerBase
    {

        IConfiguration config = null;

        public CommonController(IConfiguration config)
        {
            this.config = config;
        }

        [HttpGet]
        public CommonResponseModel Get(string id)
        {
            List<ListItem> objType = new List<ListItem>();
            config.GetSection(id).Bind(objType);

            CommonResponseModel objResp = new CommonResponseModel();
            objResp.Count = objType.Count;
            objResp.Data = objType;

            return objResp;
        }
    }
}