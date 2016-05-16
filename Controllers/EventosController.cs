using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using EDNEVENTOS.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Authorization;

namespace EDNEVENTOS.Controllers
{
    public class EventosController : Controller
    {
        private ApplicationDbContext _context;

        public EventosController(ApplicationDbContext context)
        {
            _context = context;    
        }
        [Authorize]
        // GET: Eventos
        public IActionResult Index()
        {
            return View(_context.Eventos.ToList());
        }

        public IActionResult AdicionarProdutoEmEventoForm()
        {

            //if (id == null)
            //{
            //    return HttpNotFound();
            //}

            //Eventos eventos = _context.Eventos.Single(m => m.IdEvento == id);
            //if (eventos == null)
            //{
            //    return HttpNotFound();
            //}
            var eventos = new SelectList(_context.Eventos.Select(x => new { Name = x.NomeEvento, Id = x.IdEvento }).ToList(),
                "Id", "Name");
            ViewBag.Eventos = eventos;

            var produtos = new SelectList(_context.Produtos.Select(x => new { Name = x.NomeProduto, Id = x.IdProduto }).ToList(),
                "Id", "Name");

            ViewBag.Produtos = produtos;



            return View();
         }

        [HttpPost]
        public IActionResult AdicionarProdutoEmEventoForm(ProdutoEmEvento prod)
        {
            //prod.IdEvento = prod.Eventos.IdEvento;
            //prod.IdProduto = prod.Produto.IdProduto;
            _context.ProdutoEmEvento.Add(prod);
            _context.SaveChanges();
            return RedirectToAction("Index");

            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Maps(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Eventos eventos = _context.Eventos.Single(m => m.IdEvento == id);
            if (id == null)
            {
                return HttpNotFound();
            }
            return View(eventos);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Maps(Eventos eventos)
        {
            return View(eventos);
        }
        [Authorize]
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
        [Authorize]
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
                eventos.Status = true;
                _context.Eventos.Add(eventos);
                _context.SaveChanges();
              
                return RedirectToAction("Index");
            }
            return View(eventos);
        }
        [Authorize]
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
        [Authorize]
        // GET: Eventos/Edit/5
        public IActionResult MenuEventos(int? id)
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

        // POST: Eventos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FinalizarEvento(Eventos eventos)
        {
            if (ModelState.IsValid)
            {
                eventos.Status = false;
                _context.Update(eventos);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventos);
        }

        [Authorize]
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
