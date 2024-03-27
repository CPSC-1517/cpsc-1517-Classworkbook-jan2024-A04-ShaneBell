
#region Additional Namespaces
using WestWindSystem.DAL;
using WestWindSystem.Entities;
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

        public Region? LookupRegionByID(int id)
        {
            return _context.Regions.Where(R => R.RegionId == id).FirstOrDefault();
        }

        public List<Region> GetAllRegions()
        {
            return _context.Regions.ToList();
        }

    }
}
