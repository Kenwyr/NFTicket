using NFT_API.Data.Base;
using NFT_API.Data.ViewModels;
using NFT_API.Models;
using System.Threading.Tasks;

namespace NFT_API.Data.Services
{
    public interface IEventsService : IEntityBaseRepository<Event>
    {
        Task<Event> GetEventByIdAsync(int id);
        Task<NewEventDropdownsVM> GetNewEventDropdownsValues();

        Task AddNewEventAsync(NewEventVM data);
        Task UpdateEventAsync(NewEventVM data);
    }
}
