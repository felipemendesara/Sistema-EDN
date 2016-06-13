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
            return View(_context.Produtos.OrderBy(m => m.CategoriaProduto).ToList());
        }
        [Authorize]
        // GET: Produtos
        public IActionResult RelatorioProdutos(int? id)
        {
            ViewBag.idEvento = id;

            var produtosPorEvento = (from pe in _context.ItemVenda
                                     where pe.Evento.IdEvento == id
                                     orderby pe.Produto.NomeProduto
                                     select new ProdutoEmEvento
                                     {
                                         IdProdutoEvento = pe.IdProduto,
                                         Eventos = pe.Evento,
                                         Produto = pe.Produto,

                                     }).ToList();

            return View(produtosPorEvento);
        }
        [Authorize] 
        // GET: Produtos
        public IActionResult VenderProduto(int? id)
        {
            ViewBag.idEvento = id;

            var produtosPorEvento = (from pe in _context.ProdutoEmEvento
                                     where pe.Eventos.IdEvento == id
                                     orderby pe.Produto.NomeProduto
                                     select new ProdutoEmEvento
                                     {
                                         IdProdutoEvento = pe.IdProdutoEvento,
                                         Eventos = pe.Eventos,
                                         Quantidade = pe.Quantidade,
                                         Produto = pe.Produto,
                                         //IdProduto = pe.Produto.IdProduto,
                                         //NomeProduto = pe.Produto.NomeProduto,
                                         //QuantidadeProduto = pe.Quantidade,
                                         //Imagem = pe.Produto.Imagem,
                                         //ValorProduto = pe.Produto.ValorProduto,
                                         //Caixa = pe.Eventos.Caixa
                                     }).ToList();
            
            return View(produtosPorEvento);
        }
        [HttpPost]
        public JsonResult VenderProduto(ItemVenda venda)
        {
            // Valida se tem estoque
            ProdutoEmEvento estoque = _context.ProdutoEmEvento.First(pe => pe.Eventos.IdEvento == venda.IdEvento && pe.Produto.IdProduto == venda.IdProduto);
            if (estoque.Quantidade > 0)
            {
                venda.Produto = _context.Produtos.First(p => p.IdProduto == venda.IdProduto);
                venda.Evento = _context.Eventos.First(e => e.IdEvento == venda.IdEvento);
                // Atualiza valor
                venda.ValorUnit = venda.Produto.ValorProduto;
                venda.ValorTotal = venda.ValorUnit * venda.Quantidade;
                venda.Evento.Caixa += venda.ValorTotal;

                // Registra a venda
                _context.ItemVenda.Add(venda);

                // Atualiza o caixa
                _context.Eventos.Update(venda.Evento);

                // Atualiza o estoque
                estoque.Quantidade = estoque.Quantidade - 1;
                _context.ProdutoEmEvento.Update(estoque);
                _context.SaveChanges();
                return Json(new { codigo = 1, mensagem = "Venda efetuada!" });
            } else
            {
                return Json(new { codigo = 2, mensagem = "Produto esgotado!" });
            }

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
        [Authorize(Roles = "Admin")]
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
                Index();
                ViewBag.Message = "Sucesso";
                return View("Index");
            }
            ViewBag.Message = "Erro";
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
                return View();
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
        public IActionResult Grafico(int? id)
        {
            var produtosPorEvento = (from pe in _context.ProdutoEmEvento
                                     where pe.Eventos.IdEvento == id
                                     orderby pe.Produto.NomeProduto
                                     select new RegistroRelatorioProdutoPorEvento
                                     {
                                         IdProduto = pe.Produto.IdProduto,
                                         NomeProduto = pe.Produto.NomeProduto,
                                         QuantidadeProduto = pe.Quantidade
                                     }).ToList();
            ViewBag.idEvento = id;
            return View(produtosPorEvento);
        }
    }
}
