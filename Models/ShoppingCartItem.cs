using System.ComponentModel.DataAnnotations;

namespace NFT_API.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public Event Event { get; set; }
        public int Amount { get; set; }


        public string ShoppingCartId { get; set; }
    }
}