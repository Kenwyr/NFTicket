using Microsoft.EntityFrameworkCore;
using NFT_API.Data.Base;
using NFT_API.Data.ViewModels;
using NFT_API.Models;
using System.Linq;
using System.Threading.Tasks;

namespace NFT_API.Data.Services
{
    public class EventsService : EntityBaseRepository<Event>, IEventsService
    {
        private readonly AppDbContext _context;
        public EventsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewEventAsync(NewEventVM data)
        {
            var newEvent = new Event()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                LocationId = data.LocationId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                EventCategory = data.EventCategory,
                PublisherId = data.PublisherId
            };
            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();

            //Add Event_Artists

            foreach (var artistId in data.ArtistIds) 
            {
                var newArtistEvent = new Artist_Event()
                {
                    EventId = newEvent.Id,
                    ArtistId = artistId
                };
                await _context.Artists_Events.AddAsync(newArtistEvent);
            }
            await _context.SaveChangesAsync();
        }   

        public async Task<Event> GetEventByIdAsync(int id)
        {
            var eventDetails = await _context.Events
                .Include(l => l.Location)
                .Include(p => p.Publisher)
                .Include(ae => ae.Artists_Events).ThenInclude(a =>a.Artist)
                .FirstOrDefaultAsync(n => n.Id == id);
           
            return eventDetails;
        }

        public async Task<NewEventDropdownsVM> GetNewEventDropdownsValues()
        {
            var respones = new NewEventDropdownsVM();
            respones.Artists = await _context.Artists.OrderBy(n => n.FullName).ToListAsync();
            respones.Locations = await _context.Locations.OrderBy(n => n.Name).ToListAsync();
            respones.Publishers = await _context.Publishers.OrderBy(n => n.FullName).ToListAsync();

            return respones;
        }

        public async Task UpdateEventAsync(NewEventVM data)
        {
            var dbEvent = await _context.Events.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbEvent != null)
            {

                dbEvent.Name = data.Name;
                dbEvent.Description = data.Description;
                dbEvent.Price = data.Price;
                dbEvent.ImageURL = data.ImageURL;
                dbEvent.LocationId = data.LocationId;
                dbEvent.StartDate = data.StartDate;
                dbEvent.EndDate = data.EndDate;
                dbEvent.EventCategory = data.EventCategory;
                dbEvent.PublisherId = data.PublisherId;

                await _context.SaveChangesAsync();
            }

            //Remove exiting artist
            var existingArtistsDb = _context.Artists_Events.Where(n => n.ArtistId == data.Id).ToList();
            _context.Artists_Events.RemoveRange(existingArtistsDb);
            await _context.SaveChangesAsync();


            //Add Event_Artists

            foreach (var artistId in data.ArtistIds)
            {
                var newArtistEvent = new Artist_Event()
                {
                    EventId = data.Id,
                    ArtistId = artistId
                };
                await _context.Artists_Events.AddAsync(newArtistEvent);
            }
            await _context.SaveChangesAsync();
        }
    }
}
