using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using WestWindSystem.Entities;
using WestWindSystem.DAL;
#endregion


namespace WestWindSystem.BLL
{
    public class RegionServices
    {
        private readonly WestWindContext _context;

        public RegionServices(WestWindContext context)
        {
            _context = context;
        }

        //Code the services

        public Region? LookUpRegionByID(int regionID)
        {
            return _context.Regions.Where(R => R.RegionId == regionID).FirstOrDefault();
        }

        public List<Region> GetAllRegions() 
        {
        return _context.Regions.ToList();
        }


    }
}
