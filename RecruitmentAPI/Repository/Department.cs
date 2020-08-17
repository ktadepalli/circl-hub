using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecruitmentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RecruitmentAPI.Repository
{
    public class Department : IFactoryMaster
    {
        private readonly hris_tagContext _context;

        public Department(hris_tagContext context)
        {
            _context = context;
        }
        public bool Save(object objParam)
        {
            try
            {
                var req = (DeptMaster)objParam;

                req.IsActive = 1;
                req.CreatedDate = DateTime.Now;

                _context.DeptMaster.Add(req);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(object objParam)
        {
            try
            {
                var req = (DeptMaster)objParam;

                var obj = _context.DeptMaster.Where(e => e.DeptId == req.DeptId).FirstOrDefault();

                obj.DeptName = req.DeptName;
                obj.ModifiedBy = req.ModifiedBy;
                obj.ModifiedDate = DateTime.Now;

                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<ListItem> GetDetails()
        {
            List<ListItem> obj = new List<ListItem>();
            var data = _context.DeptMaster.Select(c => new ListItem()
            {
                Value = c.DeptId,
                Name = c.DeptName
            }).OrderBy(e => e.Value).ToList();

            obj = data;
            return obj;
        }

        public bool Remove(int id)
        {
            try
            {
                _context.Remove(_context.DeptMaster.Single(e => e.DeptId == id));
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