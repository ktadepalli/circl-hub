
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecruitmentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RecruitmentAPI.Repository
{
    public class Company : IFactoryMaster
    {
        private readonly hris_tagContext _context;
        public Company(hris_tagContext context)
        {
            _context = context;
        }
        public bool Save(object objParam)
        {
            try
            {
                var req = (CompanyMaster)objParam;

                req.IsActive = 1;
                req.CreatedDate = DateTime.Now;

                _context.CompanyMaster.Add(req);
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
                var req = (CompanyMaster)objParam;

                var obj = _context.CompanyMaster.Where(e => e.CompanyId == req.CompanyId).FirstOrDefault();

                obj.CompanyName = req.CompanyName;
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

            var data = _context.CompanyMaster.Select(c => new ListItem()
            {
                Value = c.CompanyId,
                Name = c.CompanyName
            }).OrderBy(e => e.Value).ToList();

            obj = data.Count > 0 ? data : null;
            return obj;
        }

        public bool Remove(int id)
        {
            try
            {
                _context.Remove(_context.CompanyMaster.Single(e => e.CompanyId == id));
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
