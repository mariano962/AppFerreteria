using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppFerreteria.Models;

namespace AppFerreteria.Controllers
{
    public class MotosierrasController : Controller
    {
        private readonly AppFerreteriaContext _context;

        public MotosierrasController(AppFerreteriaContext context)
        {
            _context = context;
        }

        // GET: Motosierras
        public async Task<IActionResult> Index()
        {
              return _context.Motosierra != null ? 
                          View(await _context.Motosierra.ToListAsync()) :
                          Problem("Entity set 'AppFerreteriaContext.Motosierra'  is null.");
        }

        // GET: Motosierras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Motosierra == null)
            {
                return NotFound();
            }

            var motosierra = await _context.Motosierra
                .FirstOrDefaultAsync(m => m.MotosierraID == id);
            if (motosierra == null)
            {
                return NotFound();
            }

            return View(motosierra);
        }

        // GET: Motosierras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Motosierras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MotosierraID,CodigoAlfanumericoMotosierra,PrecioMotosierra,Codigodefabrica,EstaAlquilada,isDeleted")] Motosierra motosierra, IFormFile MotosierraImg )
        {
           if (ModelState.IsValid)
            {
                if (MotosierraImg != null && MotosierraImg.Length > 0)
                {
                    byte[]? Img = null;
                    using (var fs1 = MotosierraImg.OpenReadStream())
                    using (var ms1 = new MemoryStream())
                    {
                        fs1.CopyTo(ms1);
                        Img = ms1.ToArray();
                    }
                    motosierra.MotosierraImg = Img;

                    _context.Add(motosierra);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(motosierra);
        }

        // GET: Motosierras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Motosierra == null)
            {
                return NotFound();
            }

            var motosierra = await _context.Motosierra.FindAsync(id);
            if (motosierra == null)
            {
                return NotFound();
            }
            return View(motosierra);
        }

        // POST: Motosierras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MotosierraID,CodigoAlfanumericoMotosierra,PrecioMotosierra,Codigodefabrica,MotosierraImg,EstaAlquilada,isDeleted")] Motosierra motosierra)
        {
            if (id != motosierra.MotosierraID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motosierra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotosierraExists(motosierra.MotosierraID))
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
            return View(motosierra);
        }

        // GET: Motosierras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Motosierra == null)
            {
                return NotFound();
            }

            var motosierra = await _context.Motosierra
                .FirstOrDefaultAsync(m => m.MotosierraID == id);
            if (motosierra == null)
            {
                return NotFound();
            }

            return View(motosierra);
        }

        // POST: Motosierras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Motosierra == null)
            {
                return Problem("Entity set 'AppFerreteriaContext.Motosierra'  is null.");
            }
            var motosierra = await _context.Motosierra.FindAsync(id);
            if (motosierra != null)
            {
                _context.Motosierra.Remove(motosierra);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotosierraExists(int id)
        {
          return (_context.Motosierra?.Any(e => e.MotosierraID == id)).GetValueOrDefault();
        }
    }
}
