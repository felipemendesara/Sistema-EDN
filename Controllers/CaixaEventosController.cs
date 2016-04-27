using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using EDNEVENTOS.Models;

namespace SistemaEDN.Controllers
{
    public class CaixaEventosController : Controller
    {
        private ApplicationDbContext _context;

        public CaixaEventosController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: CaixaEventos
        public IActionResult Index()
        {
            return View(_context.CaixaEventos.ToList());
        }

        // GET: CaixaEventos/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CaixaEventos caixaEventos = _context.CaixaEventos.Single(m => m.IdCaixa == id);
            if (caixaEventos == null)
            {
                return HttpNotFound();
            }

            return View(caixaEventos);
        }

        // GET: CaixaEventos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CaixaEventos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CaixaEventos caixaEventos)
        {
            caixaEventos.Caixa = caixaEventos.CaixaInicial;
            caixaEventos.StatusCaixa = true;
            if (ModelState.IsValid)
            {
                _context.CaixaEventos.Add(caixaEventos);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(caixaEventos);
        }

        // GET: CaixaEventos/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CaixaEventos caixaEventos = _context.CaixaEventos.Single(m => m.IdCaixa == id);
            if (caixaEventos == null)
            {
                return HttpNotFound();
            }
            return View(caixaEventos);
        }

        // POST: CaixaEventos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CaixaEventos caixaEventos)
        {
            if (ModelState.IsValid)
            {
                _context.Update(caixaEventos);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(caixaEventos);
        }

        // GET: CaixaEventos/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CaixaEventos caixaEventos = _context.CaixaEventos.Single(m => m.IdCaixa == id);
            if (caixaEventos == null)
            {
                return HttpNotFound();
            }

            return View(caixaEventos);
        }

        // POST: CaixaEventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            CaixaEventos caixaEventos = _context.CaixaEventos.Single(m => m.IdCaixa == id);
            _context.CaixaEventos.Remove(caixaEventos);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: CaixaEventos/Edit/5
        public IActionResult Vender(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CaixaEventos caixaEventos = _context.CaixaEventos.Single(m => m.IdCaixa == id);
            if (caixaEventos == null)
            {
                return HttpNotFound();
            }
            return View(caixaEventos);
        }

        // POST: CaixaEventos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Vender(CaixaEventos caixaEventos)
        {
            if (ModelState.IsValid)
            {
                _context.Update(caixaEventos);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(caixaEventos);
        }

    }
}
