using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecruitmentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RecruitmentAPI.Repository
{
    public class Location : IFactoryMaster
    {
        private readonly hris_tagContext _context;
        public Location(hris_tagContext context)
        {
            _context = context;
        }
        public bool Save(object objParam)
        {
            try
            {
                var req = (LocationMaster)objParam;

                req.IsActive = 1;
                req.CreatedDate = DateTime.Now;

                _context.LocationMaster.Add(req);
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
                var req = (LocationMaster)objParam;

                var obj = _context.LocationMaster.Where(e => e.LocationId == req.LocationId).FirstOrDefault();

                obj.LocationName = req.LocationName;
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

            var data = _context.LocationMaster.Select(c => new ListItem()
            {
                Value = c.LocationId,
                Name = c.LocationName
            }).OrderBy(e => e.Value).ToList();

            obj = data.Count > 0 ? data : null;
            return obj;
        }

        public bool Remove(int id)
        {
            try
            {
                _context.Remove(_context.LocationMaster.Single(e => e.LocationId == id));
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