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
    public class RentalsController : Controller
    {
        private readonly AppFerreteriaContext _context;

        public RentalsController(AppFerreteriaContext context)
        {
            _context = context;
        }

        // GET: Rentals
        public async Task<IActionResult> Index()
        {
            var appFerreteriaContext = _context.Rental.Include(r => r.Cliente).Include(r => r.Motosierra);
            return View(await appFerreteriaContext.ToListAsync());
        }

        // GET: Rentals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rental == null)
            {
                return NotFound();
            }

            var rental = await _context.Rental
                .Include(r => r.Cliente)
                .Include(r => r.Motosierra)
                .FirstOrDefaultAsync(m => m.RentalID == id);
            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        // GET: Rentals/Create
        public IActionResult Create()
        {
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteID", "ClienteApellido");
            ViewData["MotosierraID"] = new SelectList(_context.Motosierra.Where(x => x.EstaAlquilada == false && x.isDeleted == false), "MotosierraID", "CodigoAlfanumericoMotosierra");
            
            return View();
        }

        // POST: Rentals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentalID,RentalDate,ClienteID,ClienteApellido,ClienteName,MotosierraID,CodigoAlfanumericoMotosierra")] Rental rental)
        {
          if (ModelState.IsValid)
            {
                var Motosierra = (from a in _context.Motosierra where a.MotosierraID == rental.MotosierraID select a).SingleOrDefault();
                var Cliente = (from a in _context.Cliente where a.ClienteID == rental.ClienteID select a).SingleOrDefault();
                rental.CodigoAlfanumericoMotosierra = Motosierra.CodigoAlfanumericoMotosierra;
                rental.ClienteName = Cliente.ClienteName + " " + Cliente.ClienteApellido;
                rental.ClienteID = Cliente.ClienteID;
                rental.MotosierraID = Motosierra.MotosierraID;
                Motosierra.EstaAlquilada = true;
                _context.Add(rental);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteID", "ClienteName", rental.ClienteID);
            ViewData["MotosierraID"] = new SelectList(_context.Motosierra.Where(x => x.EstaAlquilada == false && x.isDeleted == false), "MotosierraID", "CodigoAlfanumericoMotosierra");
            return View(rental);
        }

        // GET: Rentals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rental == null)
            {
                return NotFound();
            }

            var rental = await _context.Rental.FindAsync(id);
            if (rental == null)
            {
                return NotFound();
            }
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteID", "ClienteApellido", rental.ClienteID);
            ViewData["MotosierraID"] = new SelectList(_context.Motosierra, "MotosierraID", "CodigoAlfanumericoMotosierra", rental.MotosierraID);
            return View(rental);
        }

        // POST: Rentals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RentalID,RentalDate,ClienteID,ClienteApellido,ClienteName,MotosierraID,CodigoAlfanumericoMotosierra")] Rental rental)
        {
            if (id != rental.RentalID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rental);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalExists(rental.RentalID))
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
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteID", "ClienteApellido", rental.ClienteID);
            ViewData["MotosierraID"] = new SelectList(_context.Motosierra, "MotosierraID", "CodigoAlfanumericoMotosierra", rental.MotosierraID);
            return View(rental);
        }

        // GET: Rentals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rental == null)
            {
                return NotFound();
            }

            var rental = await _context.Rental
                .Include(r => r.Cliente)
                .Include(r => r.Motosierra)
                .FirstOrDefaultAsync(m => m.RentalID == id);
            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        // POST: Rentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rental == null)
            {
                return Problem("Entity set 'AppFerreteriaContext.Rental'  is null.");
            }
            var rental = await _context.Rental.FindAsync(id);
            if (rental != null)
            {
                _context.Rental.Remove(rental);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalExists(int id)
        {
          return (_context.Rental?.Any(e => e.RentalID == id)).GetValueOrDefault();
        }
    }
}
