using System;
using System.Collections.Generic;

namespace RecruitmentAPI.Models
{
    public class ResponseModel
    {
        public string Message { set; get; }
        public bool Status { set; get; }
        public object Data { set; get; }
    }
}