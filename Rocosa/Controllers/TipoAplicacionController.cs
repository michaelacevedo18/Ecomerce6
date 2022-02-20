using Microsoft.AspNetCore.Mvc;
using Rocosa.Data;
using Rocosa.Models;

namespace Rocosa.Controllers
{
    public class TipoAplicacionController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TipoAplicacionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tipoAplicacion = _context.TipoAplicacion.ToList();
            return View(tipoAplicacion);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(TipoAplicacion tipoAplicacion)
        {
            if (ModelState.IsValid)
            {
                _context.TipoAplicacion.Add(tipoAplicacion);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoAplicacion);
        }
        [HttpGet]
        public IActionResult Editar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var objeto = _context.TipoAplicacion.Find(Id);
            if (objeto == null)
            {
                return NotFound();
            }
            return View(objeto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(TipoAplicacion tipoAplicacion)
        {

            if (ModelState.IsValid)
            {
                _context.TipoAplicacion.Update(tipoAplicacion);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoAplicacion);
        }

        [HttpGet]
        public IActionResult Eliminar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var objeto = _context.TipoAplicacion.Find(Id);
            if (objeto == null)
            {
                return NotFound();
            }
            return View(objeto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(TipoAplicacion tipoAplicacion)
        {
            if (tipoAplicacion == null)
            {
                return NotFound();
            }
            _context.TipoAplicacion.Remove(tipoAplicacion);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
