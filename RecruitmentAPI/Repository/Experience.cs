
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecruitmentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RecruitmentAPI.Repository
{
    public class Experience : IFactoryMaster
    {
        private readonly hris_tagContext _context;
        public Experience(hris_tagContext context)
        {
            _context = context;
        }
        public bool Save(object objParam)
        {
            try
            {
                var req = (ExperienceMaster)objParam;

                req.IsActive = 1;
                req.CreatedDate = DateTime.Now;

                _context.ExperienceMaster.Add(req);
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
                var req = (ExperienceMaster)objParam;

                var obj = _context.ExperienceMaster.Where(e => e.ExpId == req.ExpId).FirstOrDefault();

                obj.ExpName = req.ExpName;
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

            var data = _context.ExperienceMaster.Select(c => new ListItem()
            {
                Value = c.ExpId,
                Name = c.ExpName
            }).OrderBy(e => e.Value).ToList();

            obj = data.Count > 0 ? data : null;
            return obj;
        }

        public bool Remove(int id)
        {
            try
            {
                _context.Remove(_context.ExperienceMaster.Single(e => e.ExpId == id));
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
