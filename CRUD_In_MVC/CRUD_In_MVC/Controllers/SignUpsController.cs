using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_In_MVC.Models;

namespace CRUD_In_MVC.Controllers
{
    public class SignUpsController : Controller
    {
        private readonly ServesContext _context;

        public SignUpsController(ServesContext context)
        {
            _context = context;
        }

        // GET: SignUps
        public async Task<IActionResult> Index()
        {
              return _context.SignUps != null ? 
                          View(await _context.SignUps.ToListAsync()) :
                          Problem("Entity set 'ServesContext.SignUps'  is null.");
        }

        // GET: SignUps/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.SignUps == null)
            {
                return NotFound();
            }

            var signUp = await _context.SignUps
                .FirstOrDefaultAsync(m => m.FirstName == id);
            if (signUp == null)
            {
                return NotFound();
            }

            return View(signUp);
        }

        // GET: SignUps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SignUps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Email,Role,Password,ComformPassword")] SignUp signUp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(signUp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(signUp);
        }

        // GET: SignUps/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.SignUps == null)
            {
                return NotFound();
            }

            var signUp = await _context.SignUps.FindAsync(id);
            if (signUp == null)
            {
                return NotFound();
            }
            return View(signUp);
        }

        // POST: SignUps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FirstName,LastName,Email,Role,Password,ComformPassword")] SignUp signUp)
        {
            if (id != signUp.FirstName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(signUp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SignUpExists(signUp.FirstName))
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
            return View(signUp);
        }

        // GET: SignUps/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.SignUps == null)
            {
                return NotFound();
            }

            var signUp = await _context.SignUps
                .FirstOrDefaultAsync(m => m.FirstName == id);
            if (signUp == null)
            {
                return NotFound();
            }

            return View(signUp);
        }

        // POST: SignUps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.SignUps == null)
            {
                return Problem("Entity set 'ServesContext.SignUps'  is null.");
            }
            var signUp = await _context.SignUps.FindAsync(id);
            if (signUp != null)
            {
                _context.SignUps.Remove(signUp);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SignUpExists(string id)
        {
          return (_context.SignUps?.Any(e => e.FirstName == id)).GetValueOrDefault();
        }
    }
}
