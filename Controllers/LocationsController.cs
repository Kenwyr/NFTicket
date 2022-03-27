using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NFT_API.Data;
using NFT_API.Data.Services;
using NFT_API.Data.Static;
using NFT_API.Models;
using System.Threading.Tasks;

namespace NFT_API.Controllers
{
    [Authorize]
    public class LocationsController : Controller
    {
        private readonly ILocationsService _service;

        public LocationsController(ILocationsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allLocations = await _service.GetAllAsync();
            return View(allLocations);
        }

        //Get: Locations/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Location location)
        {
            if (!ModelState.IsValid) return View(location);
            await _service.AddAsync(location);
            return RedirectToAction(nameof(Index));
        }

        //Get: Locations/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var locationDetails = await _service.GetByIdAsync(id);
            if (locationDetails == null) return View("NotFound");
            return View(locationDetails);
        }

        //Get: Locations/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var locationDetails = await _service.GetByIdAsync(id);
            if (locationDetails == null) return View("NotFound");
            return View(locationDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Location location)
        {
            if (!ModelState.IsValid) return View(location);
            await _service.UpdateAsync(id, location);
            return RedirectToAction(nameof(Index));
        }

        //Get: Locations/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var locationDetails = await _service.GetByIdAsync(id);
            if (locationDetails == null) return View("NotFound");
            return View(locationDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var locationDetails = await _service.GetByIdAsync(id);
            if (locationDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}