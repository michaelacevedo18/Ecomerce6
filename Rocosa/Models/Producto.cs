using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rocosa.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Nombre de producto es requerido")]
        public string NombreProducto { get; set; }

        [Required(ErrorMessage = "Ingrese una Descripcion")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Ingrese una descripcion larga")]
        public string DescripcionLarga { get; set; }

        [Required(ErrorMessage = "Ingrese un precio")]
        [Range(1,double.MaxValue,ErrorMessage ="El precio debe ser mayor a cero")]
        public double Precio { get; set; }

        public string ImagenUrl { get; set; }

        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; }

        public int TipoAplicacionId { get; set; }
        [ForeignKey("TipoAplicacionId")]
        public virtual TipoAplicacion TipoAplicacion { get; set; }

    }
}
