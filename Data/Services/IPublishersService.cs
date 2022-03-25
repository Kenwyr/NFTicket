using NFT_API.Data.Base;
using NFT_API.Models;
using System.Security.Policy;
using Publisher = NFT_API.Models.Publisher;

namespace NFT_API.Data.Services
{
    public interface IPublishersService : IEntityBaseRepository<Publisher>
    {
    }
}
