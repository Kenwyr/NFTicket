using NFT_API.Models;
using System.Collections.Generic;

namespace NFT_API.Data.ViewModels
{
    public class NewEventDropdownsVM
    {
        public NewEventDropdownsVM()
        {
            Publishers = new List<Publisher>();
            Locations = new List<Location>();
            Artists = new List<Artist>();
        }

        public List<Publisher> Publishers { get; set; }
        public List<Location> Locations { get; set; }
        public List<Artist> Artists { get; set; }
    }
}
