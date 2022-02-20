using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rocosa.Data;
using Rocosa.Models;

namespace Rocosa.Controllers
{
    public class ProductoController : Controller
    {

        private readonly ApplicationDbContext _context;
        public ProductoController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var producto = _context.Producto.Include(c=>c.Categoria)
                                            .Include(t=>t.TipoAplicacion).ToList();
            return View(producto);
            
        }
        public IActionResult Upsert(int? Id)
        {
            //Lleno la lista Categoria
            IEnumerable<SelectListItem> categoriaDropDown = _context.Categoria.Select(c => new SelectListItem
            {
                Text= c.NombreCategoria,
                Value=c.Id.ToString()
            });
            ViewBag.categoriaDropDown = categoriaDropDown;

            //Lleno la lista Aplicacion Tipo
            IEnumerable<SelectListItem> tipoaplicacionDropDown = _context.TipoAplicacion.Select(c => new SelectListItem
            {
                Text = c.Nombre,
                Value = c.Id.ToString()
            });
            ViewBag.tipoaplicacionDropDown = tipoaplicacionDropDown;

            //Inicializo el nuevo producto
            Producto producto=new Producto();
            if (Id == null)  //Es nuevo Reg
            {
                return View(producto);
            }
            else
            {
                producto = _context.Producto.Find(Id);
                if (producto == null)
                {
                    return NotFound();
                }
                return View(producto);
            }
        }
    }
}
