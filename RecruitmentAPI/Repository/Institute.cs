
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecruitmentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RecruitmentAPI.Repository
{
    public class Institute : IFactoryMaster
    {
        private readonly hris_tagContext _context;
        public Institute(hris_tagContext context)
        {
            _context = context;
        }
        public bool Save(object objParam)
        {
            try
            {
                var req = (InstitutionMaster)objParam;

                req.IsActive = 1;
                req.CreatedDate = DateTime.Now;

                _context.InstitutionMaster.Add(req);
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
                var req = (InstitutionMaster)objParam;

                var obj = _context.InstitutionMaster.Where(e => e.InstitutionId == req.InstitutionId).FirstOrDefault();

                obj.InstitutionName = req.InstitutionName;
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

            var data = _context.InstitutionMaster.Select(c => new ListItem()
            {
                Value = c.InstitutionId,
                Name = c.InstitutionName
            }).OrderBy(e => e.Value).ToList();

            obj = data.Count > 0 ? data : null;
            return obj;
        }

        public bool Remove(int id)
        {
            try
            {
                _context.Remove(_context.InstitutionMaster.Single(e => e.InstitutionId == id));
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
