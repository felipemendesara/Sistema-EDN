using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using EDNEVENTOS.Models;

namespace EDNEVENTOS.Controllers
{
    public class EventosController : Controller
    {
        private ApplicationDbContext _context;

        public EventosController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Eventos
        public IActionResult Index()
        {
            return View(_context.Eventos.ToList());
        }

        // GET: Eventos/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Eventos eventos = _context.Eventos.Single(m => m.IdEvento == id);
            if (eventos == null)
            {
                return HttpNotFound();
            }

            return View(eventos);
        }

        // GET: Eventos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Eventos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Eventos eventos)
        {
            if (ModelState.IsValid)
            {
                _context.Eventos.Add(eventos);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventos);
        }

        // GET: Eventos/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Eventos eventos = _context.Eventos.Single(m => m.IdEvento == id);
            if (eventos == null)
            {
                return HttpNotFound();
            }
            return View(eventos);
        }

        // POST: Eventos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Eventos eventos)
        {
            if (ModelState.IsValid)
            {
                _context.Update(eventos);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventos);
        }

        // GET: Eventos/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Eventos eventos = _context.Eventos.Single(m => m.IdEvento == id);
            if (eventos == null)
            {
                return HttpNotFound();
            }

            return View(eventos);
        }

        // POST: Eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Eventos eventos = _context.Eventos.Single(m => m.IdEvento == id);
            _context.Eventos.Remove(eventos);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}