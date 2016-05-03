using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using EDNEVENTOS.Models;
using Microsoft.AspNet.Authorization;

namespace EDNEVENTOS.Controllers
{
    public class ProdutosController : Controller
    {
        private ApplicationDbContext _context;

        public ProdutosController(ApplicationDbContext context)
        {
            _context = context;    
        }
        [Authorize]
        // GET: Produtos
        public IActionResult Index()
        {
            return View(_context.Produtos.ToList());
        }
        [Authorize]
        // GET: Produtos
        public IActionResult VenderProduto()
        {
            return View(_context.Produtos.ToList());
        }
        public IActionResult AdicionarProdutoEmEventoForm()
        {
            var eventos = new SelectList(_context.Eventos.Select(x => new { Name = x.NomeEvento,Id = x.IdEvento }).ToList(),
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
         
                _context.ProdutoEmEvento.Add(prod);
                _context.SaveChanges();
                return RedirectToAction("Index");
        
            return View();
        }


        [Authorize]
        // GET: Produtos/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Produtos produtos = _context.Produtos.Single(m => m.IdProduto == id);
            if (produtos == null)
            {
                return HttpNotFound();
            }

            return View(produtos);
        }
        [Authorize]
        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Produtos produtos)
        {
            if (ModelState.IsValid)
            {
                _context.Produtos.Add(produtos);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produtos);
        }
        // POST: Produtos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FinalizarEventos(Eventos eventos)
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
        // GET: Produtos/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Produtos produtos = _context.Produtos.Single(m => m.IdProduto == id);
            if (produtos == null)
            {
                return HttpNotFound();
            }
            return View(produtos);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Produtos produtos)
        {
            if (ModelState.IsValid)
            {
                _context.Update(produtos);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produtos);
        }
        [Authorize]
        // GET: Produtos/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Produtos produtos = _context.Produtos.Single(m => m.IdProduto == id);
            if (produtos == null)
            {
                return HttpNotFound();
            }

            return View(produtos);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Produtos produtos = _context.Produtos.Single(m => m.IdProduto == id);
            _context.Produtos.Remove(produtos);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        // GET: Produtos/Grafico/5
        public IActionResult Grafico()
        {
            return View(_context.Produtos.ToList());
        }
    }
}
