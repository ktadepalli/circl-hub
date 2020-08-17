
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecruitmentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RecruitmentAPI.Repository
{
    public class University : IFactoryMaster
    {
        private readonly hris_tagContext _context;
        public University(hris_tagContext context)
        {
            _context = context;
        }
        public bool Save(object objParam)
        {
            try
            {
                var req = (UniversityMaster)objParam;

                req.IsActive = 1;
                req.CreatedDate = DateTime.Now;

                _context.UniversityMaster.Add(req);
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
                var req = (UniversityMaster)objParam;

                var obj = _context.UniversityMaster.Where(e => e.UniversityId == req.UniversityId).FirstOrDefault();

                obj.UniversityName = req.UniversityName;
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

            var data = _context.UniversityMaster.Select(c => new ListItem()
            {
                Value = c.UniversityId,
                Name = c.UniversityName
            }).OrderBy(e => e.Value).ToList();

            obj = data.Count > 0 ? data : null;
            return obj;
        }

        public bool Remove(int id)
        {
            try
            {
                _context.Remove(_context.UniversityMaster.Single(e => e.UniversityId == id));
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
