using NFT_API.Data.Base;
using NFT_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NFT_API.Data.Services
{
    public interface IArtistsService: IEntityBaseRepository<Artist>
    {
        //Task <IEnumerable<Artist>> GetAllAsync();
        //Task<Artist> GetByIdAsync(int id);
        //Task AddAsync(Artist artist);
        //Task<Artist> UpdateAsync(int id, Artist newArtist);
        //Task DeleteAsync(int id);
    }
}
