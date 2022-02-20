using System.ComponentModel.DataAnnotations;

namespace Rocosa.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La nombre de categoria es requerido")]
        public string NombreCategoria { get; set; }

        [Required(ErrorMessage = "Ingrese un valor numerico")]
        [Range(1, int.MaxValue,ErrorMessage ="El orden debe ser mayor a 0.")]
        public int MostrarOrden { get; set; }

    }
}
