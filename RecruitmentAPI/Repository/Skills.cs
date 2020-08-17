
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecruitmentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RecruitmentAPI.Repository
{
    public class Skills : IFactoryMaster
    {
        private readonly hris_tagContext _context;
        public Skills(hris_tagContext context)
        {
            _context = context;
        }
        public bool Save(object objParam)
        {
            try
            {
                var req = (SkillsMaster)objParam;

                req.IsActive = 1;
                req.CreatedDate = DateTime.Now;

                _context.SkillsMaster.Add(req);
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
                var req = (SkillsMaster)objParam;

                var obj = _context.SkillsMaster.Where(e => e.SkillId == req.SkillId).FirstOrDefault();

                obj.SkillName = req.SkillName;
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

            var data = _context.SkillsMaster.Select(c => new ListItem()
            {
                Value = c.SkillId,
                Name = c.SkillName
            }).OrderBy(e => e.Value).ToList();

            obj = data.Count > 0 ? data : null;
            return obj;
        }

        public bool Remove(int id)
        {
            try
            {
                _context.Remove(_context.SkillsMaster.Single(e => e.SkillId == id));
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
