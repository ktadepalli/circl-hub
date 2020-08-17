using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentAPI.Models
{
    public class SkillsInfoModel
    {
        public int Id { get; set; }
        public string SkillType { get; set; }
        public string Skills { get; set; }
        public string Version { get; set; }
        public string LastUsed { get; set; }
        public string SubSkills { get; set; }
        public string ExpInMonths { get; set; }
        public string ExpInYrs { get; set; }
    }
}
