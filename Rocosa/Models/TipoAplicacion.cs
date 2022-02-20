using System.ComponentModel.DataAnnotations;

namespace Rocosa.Models
{
    public class TipoAplicacion
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo nombre es requerido")]
        public string Nombre { get; set; }
    }
}
