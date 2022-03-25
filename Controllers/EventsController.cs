using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NFT_API.Data;
using NFT_API.Data.Services;
using NFT_API.Data.Static;
using NFT_API.Data.ViewModels;
using NFT_API.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NFT_API.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class EventsController : Controller
    {
        private readonly IEventsService _service;

        public EventsController(IEventsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allEvents = await _service.GetAllAsync(n => n.Location);
            return View(allEvents);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allEvents = await _service.GetAllAsync(n => n.Location);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResultNew = allEvents.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) 
                || string.Equals(n.EventCategory.ToString(), searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allEvents);
        }

        //GET: Events/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var eventDetail = await _service.GetEventByIdAsync(id);
            return View(eventDetail);
        }

        //GET: Movies/Create
        public async Task<IActionResult> Create()
        {
            var eventDropdownsData = await _service.GetNewEventDropdownsValues();

            ViewBag.Locations = new SelectList(eventDropdownsData.Locations, "Id", "Name");
            ViewBag.Publishers = new SelectList(eventDropdownsData.Publishers, "Id", "FullName");
            ViewBag.Artists = new SelectList(eventDropdownsData.Artists, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewEventVM e)
        {
            if (!ModelState.IsValid)
            {
                var eventDropdownsData = await _service.GetNewEventDropdownsValues();

                ViewBag.Locations = new SelectList(eventDropdownsData.Locations, "Id", "Name");
                ViewBag.Publishers = new SelectList(eventDropdownsData.Publishers, "Id", "FullName");
                ViewBag.Artists = new SelectList(eventDropdownsData.Artists, "Id", "FullName");
                return View(e);
            }

            await _service.AddNewEventAsync(e);
            return RedirectToAction(nameof(Index));
        }

        //GET: Movies/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var eventDetails = await _service.GetEventByIdAsync(id);
            if (eventDetails == null) return View("NotFound");
            
            var response = new NewEventVM()
            {
                Id = eventDetails.Id,
                Name = eventDetails.Name,
                Description = eventDetails.Description,
                Price = eventDetails.Price,
                StartDate = eventDetails.StartDate,
                EndDate = eventDetails.EndDate,
                ImageURL = eventDetails.ImageURL,
                EventCategory = eventDetails.EventCategory,
                LocationId = eventDetails.LocationId,
                PublisherId = eventDetails.PublisherId,
                ArtistIds = eventDetails.Artists_Events.Select(n => n.ArtistId).ToList(),
            };

            var eventDropdownsData = await _service.GetNewEventDropdownsValues();

            ViewBag.Locations = new SelectList(eventDropdownsData.Locations, "Id", "Name");
            ViewBag.Publishers = new SelectList(eventDropdownsData.Publishers, "Id", "FullName");
            ViewBag.Artists = new SelectList(eventDropdownsData.Artists, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewEventVM e)
        {
            if (id != e.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var eventDropdownsData = await _service.GetNewEventDropdownsValues();

                ViewBag.Locations = new SelectList(eventDropdownsData.Locations, "Id", "Name");
                ViewBag.Publishers = new SelectList(eventDropdownsData.Publishers, "Id", "FullName");
                ViewBag.Artists = new SelectList(eventDropdownsData.Artists, "Id", "FullName");
                
                return View(e);
            }

            await _service.UpdateEventAsync(e);
            return RedirectToAction(nameof(Index));
        }
    }
}