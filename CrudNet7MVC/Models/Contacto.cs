using System.ComponentModel.DataAnnotations;

namespace CrudNet7MVC.Models
{
    public class Contacto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El telefono es obligatorio")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El celular es obligatorio")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        public string Email { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
