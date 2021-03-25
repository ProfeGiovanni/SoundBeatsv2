using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoundBeatsV2.Core.Domain;
using SoundBeatsV2.Infrastructure.Data;

namespace SoundBeatsV2.Web.Controllers
{
    public class AlbumController : Controller
    {
        private readonly SoundBeatsDbContext _context;

        public AlbumController(SoundBeatsDbContext context)
        {
            _context = context;
        }

        // GET: Album
        public async Task<IActionResult> Index()
        {
            var soundBeatsDbContext = _context.Album.Include(a => a.Artist);
            return View(await soundBeatsDbContext.ToListAsync());
        }

        public async Task<IActionResult> ByArtist(int id)
        {
            var soundBeatsDbContext = _context.Album.Where(x => x.ArtistId == id);
            var listAlbum = await soundBeatsDbContext.ToListAsync();

            ViewData["ArtistName"] = _context.Artist.Where(x => x.Id == id).FirstOrDefault().Name;
            ViewData["ArtistBiography"] = _context.Artist.Where(x => x.Id == id).FirstOrDefault().Biography;
            ViewData["ArtistId"] = id;
            return View(listAlbum);
        }



        // GET: Album/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            // Se modifica los detalles de ALbum para mostrar el listado de canciones

            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Album
                .Include(a => a.Artist)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }


        //[Authorize(Roles = "Administrator")]
        // GET: Album/Create
        public IActionResult Create(int id)
        {
            ViewData["ArtistName"] = _context.Artist.Where(x => x.Id == id).FirstOrDefault().Name;
            Album album = new Album { ArtistId = id };
            return View(album);
        }

        // POST: Album/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Year,PhotoCover,ImageType,ArtistId")] Album album, 
            List<IFormFile> Image)
        {
            //if (ModelState.IsValid)
            if (ModelState.IsValid && Image != null)
            {
                //// full path to file in temp location
                //var filePath = Path.GetTempFileName();
                //foreach (var formFile in Image)
                //{
                //    if (formFile.Length > 0)
                //    {
                //        using (var stream = new FileStream(filePath, FileMode.Create))
                //        {
                //            await formFile.CopyToAsync(stream);
                //        }
                //    }
                //}
                //album.PhotoCover = new byte[Image.ContentLength];
                //album.ImageType = Image.ContentType;
                //Image.InputStream.Read(album.PhotoCover, 0, Image.ContentLength);


                _context.Add(album);
                await _context.SaveChangesAsync();
                return RedirectToAction("ByArtist", "Album", new { id = album.ArtistId });
                 
                    //RedirectToAction(nameof(Index));
            }
            ViewData["ArtistId"] = new SelectList(_context.Artist, "Id", "Name", album.ArtistId);
            return View(album);
        }

        // GET: Album/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Album.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }
            ViewData["ArtistId"] = new SelectList(_context.Artist, "Id", "Name", album.ArtistId);
            return View(album);
        }

        // POST: Album/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Year,PhotoCover,ImageType,ArtistId")] Album album)
        {
            if (id != album.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(album);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(album.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistId"] = new SelectList(_context.Artist, "Id", "Name", album.ArtistId);
            return View(album);
        }

        // GET: Album/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Album
                .Include(a => a.Artist)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // POST: Album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var album = await _context.Album.FindAsync(id);
            _context.Album.Remove(album);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumExists(int id)
        {
            return _context.Album.Any(e => e.Id == id);
        }
    }
}
