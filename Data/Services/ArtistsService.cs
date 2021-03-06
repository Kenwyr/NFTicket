using Microsoft.EntityFrameworkCore;
using NFT_API.Data.Base;
using NFT_API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFT_API.Data.Services
{
    public class ArtistsService : EntityBaseRepository<Artist>, IArtistsService
    {
        //private readonly AppDbContext _context;
        public ArtistsService(AppDbContext context) : base(context) { }
       /* {
            _context = context;
        }

        /*public async Task AddAsync(Artist artist)
        {
            await _context.Artists.AddAsync(artist);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Artists.FirstOrDefaultAsync(x => x.Id == id);
            _context.Artists.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Artist>> GetAllAsync()
        {
            var result = await _context.Artists.ToListAsync();
            return result;
        }

        public async Task<Artist> GetByIdAsync(int id)
        {
            var result = await _context.Artists.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public Artist Update(int id, Artist newArtist)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Artist> UpdateAsync(int id, Artist newArtist)
        {
            _context.Update(newArtist);
            await _context.SaveChangesAsync();
            return newArtist;
        }*/
    }
}
