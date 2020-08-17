using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecruitmentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RecruitmentAPI.Repository
{
    public class FactoryMaster
    {
        public static IFactoryMaster GetFactoryObj(string objName)
        {
            if (objName == "dept")
                return new Department(new hris_tagContext());
            else if (objName == "loc")
                return new Location(new hris_tagContext());
            else if (objName == "role")
                return new Roles(new hris_tagContext());
            else if (objName == "institute")
                return new Institute(new hris_tagContext());
            else if (objName == "University")
                return new University(new hris_tagContext());
            else if (objName == "company")
                return new Company(new hris_tagContext());
            else if (objName == "employment")
                return new EmploymentType(new hris_tagContext());
            else if (objName == "skills")
                return new Skills(new hris_tagContext());
            else if (objName == "experience")
                return new Experience(new hris_tagContext());
            else
                return new Department(new hris_tagContext());

        }
    }
}