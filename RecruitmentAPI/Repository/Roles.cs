
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecruitmentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RecruitmentAPI.Repository
{
    public class Roles : IFactoryMaster
    {
        private readonly hris_tagContext _context;
        public Roles(hris_tagContext context)
        {
            _context = context;
        }
        public bool Save(object objParam)
        {
            try
            {
                var req = (RoleMaster)objParam;

                req.IsActive = 1;
                req.CreatedDate = DateTime.Now;

                _context.RoleMaster.Add(req);
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
                var req = (RoleMaster)objParam;

                var obj = _context.RoleMaster.Where(e => e.RoleId== req.RoleId).FirstOrDefault();

                obj.RoleName = req.RoleName;
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

            var data = _context.RoleMaster.Select(c => new ListItem()
            {
                Value = c.RoleId,
                Name = c.RoleName
            }).OrderBy(e => e.Value).ToList();

            obj = data.Count > 0 ? data : null;
            return obj;
        }

        public bool Remove(int id)
        {
            try
            {
                _context.Remove(_context.RoleMaster.Single(e => e.RoleId == id));
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
