using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindWholesale.DAL;
using WestWindWholesale.Models;

namespace WestWindWholesale.BLL
{
    public class RegionServices
    {
        //holds the context
        private readonly WestWindContext _context;

        //give the context the data it needs to connect
        public RegionServices(WestWindContext context)
        {
            _context = context;
        }

        public Region LookUpRegionByID(int regionID)
        {
            return _context.Regions.Where(R => R.RegionId == regionID).FirstOrDefault();
        }
        public List<Region> GetAllRegions()
        {
            return _context.Regions.ToList();
        }


    }
}
