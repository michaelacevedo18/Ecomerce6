using Microsoft.AspNetCore.Mvc;
using Rocosa.Data;
using Rocosa.Models;

namespace Rocosa.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //IEnumerable<Categoria> Lista = _context.Categoria;
            var categorias = _context.Categoria.ToList();
            return View(categorias);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Categoria categoria)
        {
            if (ModelState.IsValid) 
            {
                _context.Categoria.Add(categoria);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);            
        }
        [HttpGet]
        public IActionResult Editar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var objeto = _context.Categoria.Find(Id);
            if (objeto == null)
            {
                return NotFound();
            }
            return View(objeto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Categoria categoria)
        {
    
            if (ModelState.IsValid)
            {
                _context.Categoria.Update(categoria);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        [HttpGet]
        public IActionResult Eliminar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var objeto = _context.Categoria.Find(Id);
            if (objeto == null)
            {
                return NotFound();
            }
            return View(objeto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Categoria categoria)
        {
            if (categoria==null)
            {
                return NotFound();
            }
            _context.Categoria.Remove(categoria);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
