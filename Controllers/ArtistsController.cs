using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NFT_API.Data;
using NFT_API.Data.Services;
using NFT_API.Data.Static;
using NFT_API.Models;
using System.Linq;
using System.Threading.Tasks;

namespace NFT_API.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ArtistsController : Controller
    {
        private readonly IArtistsService _service;

        public ArtistsController(IArtistsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Artist/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return View(artist);
            }
            await _service.AddAsync(artist);
            return RedirectToAction(nameof(Index));
        }

        //Get: Artist/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var artistDetails = await _service.GetByIdAsync(id);

            if (artistDetails == null) return View("NotFound");

            return View(artistDetails);
        }

        //Get: Artist/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var ArtistDetails = await _service.GetByIdAsync(id);
            if (ArtistDetails == null) return View("NotFound");
            return View(ArtistDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,FullName,ProfilePictureURL,Bio")] Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return View(artist);
            }
            await _service.UpdateAsync(id, artist);
            return RedirectToAction(nameof(Index));
        }

        //Get: Artist/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var artistDetails = await _service.GetByIdAsync(id);
            if (artistDetails == null) return View("NotFound");
            return View(artistDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artistDetails = await _service.GetByIdAsync(id);
            if (artistDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
