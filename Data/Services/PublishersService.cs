using NFT_API.Data.Base;
using NFT_API.Models;

namespace NFT_API.Data.Services
{
    public class PublishersService : EntityBaseRepository<Publisher>, IPublishersService
    {
        public PublishersService(AppDbContext context) : base(context)
        {
        }
    }
}