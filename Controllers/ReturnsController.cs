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
    public class ReturnsController : Controller
    {
        private readonly AppFerreteriaContext _context;

        public ReturnsController(AppFerreteriaContext context)
        {
            _context = context;
        }

        // GET: Returns
        public async Task<IActionResult> Index()
        {
            var appFerreteriaContext = _context.Return.Include(r => r.Cliente).Include(r => r.Motosierra);
            return View(await appFerreteriaContext.ToListAsync());
        }

        // GET: Returns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Return == null)
            {
                return NotFound();
            }

            var @return = await _context.Return
                .Include(r => r.Cliente)
                .Include(r => r.Motosierra)
                .FirstOrDefaultAsync(m => m.ReturnID == id);
            if (@return == null)
            {
                return NotFound();
            }

            return View(@return);
        }

        // GET: Returns/Create
        public IActionResult Create()
        {
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteID", "ClienteApellido");
            // ViewData["MotosierraID"] = new SelectList(_context.Motosierra, "MotosierraID", "CodigoAlfanumericoMotosierra");
            ViewData["MotosierraID"] = new SelectList(_context.Motosierra.Where(x => x.StockStart != x.Stock && x.isDeleted == false), "MotosierraID", "CodigoAlfanumericoMotosierra");
            
            return View();
        }

        // POST: Returns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReturnID,ReturnDate,ClienteID,ClienteApellido,ClienteName,CodigoAlfanumericoMotosierra,MotosierraID,Stock,MontoTotal")] Return @return)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var ClienteID = (from a in _context.Rental where a.ClienteID == @return.ClienteID && a.MotosierraID == @return.MotosierraID select a).FirstOrDefault();
                    if (ClienteID != null)
                    {
                        if (ClienteID.RentalDate < @return.ReturnDate)
                        {
                            if (@return.Stock == ClienteID.Stock)
                            {
                                
                                 var Motosierra = (from a in _context.Motosierra where a.MotosierraID == @return.MotosierraID select a).SingleOrDefault();
                                 var Cliente = (from a in _context.Cliente where a.ClienteID == @return.ClienteID select a).SingleOrDefault();
                                @return.CodigoAlfanumericoMotosierra = Motosierra.CodigoAlfanumericoMotosierra;
                                @return.ClienteName = Cliente.ClienteName + " " + Cliente.ClienteApellido;
                                @return.ClienteID = Cliente.ClienteID;
                                @return.MotosierraID = Motosierra.MotosierraID;
                                Motosierra.Stock = Motosierra.Stock + @return.Stock;
                                @return.MontoTotal = Motosierra.PrecioMotosierra * @return.Stock;
                                _context.Add(@return);
                                await _context.SaveChangesAsync();
                                return RedirectToAction(nameof(Index));
                            }
                        }
                    }
              
                }
                catch (System.Exception)
                {
                    
                    throw;
                }
              
            }
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteID", "ClienteName", @return.ClienteID);
            ViewData["MotosierraID"] = new SelectList(_context.Motosierra.Where(x => x.StockStart != x.Stock && x.isDeleted == false), "MotosierraID", "CodigoAlfanumericoMotosierra");
            return View(@return);
        }

        // GET: Returns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Return == null)
            {
                return NotFound();
            }

            var @return = await _context.Return.FindAsync(id);
            if (@return == null)
            {
                return NotFound();
            }
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteID", "ClienteApellido", @return.ClienteID);
            ViewData["MotosierraID"] = new SelectList(_context.Motosierra, "MotosierraID", "CodigoAlfanumericoMotosierra", @return.MotosierraID);
            return View(@return);
        }

        // POST: Returns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReturnID,ReturnDate,ClienteID,ClienteApellido,ClienteName,CodigoAlfanumericoMotosierra,MotosierraID")] Return @return)
        {
            if (id != @return.ReturnID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@return);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReturnExists(@return.ReturnID))
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
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteID", "ClienteApellido", @return.ClienteID);
            ViewData["MotosierraID"] = new SelectList(_context.Motosierra, "MotosierraID", "CodigoAlfanumericoMotosierra", @return.MotosierraID);
            return View(@return);
        }

        // GET: Returns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Return == null)
            {
                return NotFound();
            }

            var @return = await _context.Return
                .Include(r => r.Cliente)
                .Include(r => r.Motosierra)
                .FirstOrDefaultAsync(m => m.ReturnID == id);
            if (@return == null)
            {
                return NotFound();
            }

            return View(@return);
        }

        // POST: Returns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Return == null)
            {
                return Problem("Entity set 'AppFerreteriaContext.Return'  is null.");
            }
            var @return = await _context.Return.FindAsync(id);
            if (@return != null)
            {
                _context.Return.Remove(@return);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReturnExists(int id)
        {
          return (_context.Return?.Any(e => e.ReturnID == id)).GetValueOrDefault();
        }
    }
}
