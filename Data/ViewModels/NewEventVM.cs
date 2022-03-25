using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NFT_API.Data.ViewModels
{
    public class NewEventVM
    {
        public int Id { get; set; }

        [Display(Name = "Event name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Event description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Event poster URL")]
        [Required(ErrorMessage = "Event poster URL is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Event salesstart date")]
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Event end date")]
        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Event category is required")]
        public EventCategory EventCategory { get; set; }

        //Relationships
        [Display(Name = "Select actor(s)")]
        [Required(ErrorMessage = "Event artist(s) is required")]
        public List<int> ArtistIds { get; set; }

        [Display(Name = "Select a location")]
        [Required(ErrorMessage = "Event location is required")]
        public int LocationId { get; set; }

        [Display(Name = "Select a publisher")]
        [Required(ErrorMessage = "Event publisher is required")]
        public int PublisherId { get; set; }
    }
}
