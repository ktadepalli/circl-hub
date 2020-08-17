
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecruitmentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RecruitmentAPI.Repository
{
    public class EmploymentType : IFactoryMaster
    {
        private readonly hris_tagContext _context;
        public EmploymentType(hris_tagContext context)
        {
            _context = context;
        }
        public bool Save(object objParam)
        {
            try
            {
                var req = (EmploymentypeMaster)objParam;

                req.IsActive = 1;
                req.CreatedDate = DateTime.Now;

                _context.EmploymentypeMaster.Add(req);
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
                var req = (EmploymentypeMaster)objParam;

                var obj = _context.EmploymentypeMaster.Where(e => e.EmplyId == req.EmplyId).FirstOrDefault();

                obj.EmplyName = req.EmplyName;
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

            var data = _context.EmploymentypeMaster.Select(c => new ListItem()
            {
                Value = c.EmplyId,
                Name = c.EmplyName
            }).OrderBy(e => e.Value).ToList();

            obj = data.Count > 0 ? data : null;
            return obj;
        }

        public bool Remove(int id)
        {
            try
            {
                _context.Remove(_context.EmploymentypeMaster.Single(e => e.EmplyId == id));
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
