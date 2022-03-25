namespace NFT_API.Models
{
    public class Artist_Event
    {
        public int EventId { get; set; }
        public Event Event { get; set; }

        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
