using NFT_API.Data.Base;
using NFT_API.Models;

namespace NFT_API.Data.Services
{
    public class LocationsService : EntityBaseRepository<Location>, ILocationsService
    {
        public LocationsService(AppDbContext context) : base(context)
        {
        }
    }
}