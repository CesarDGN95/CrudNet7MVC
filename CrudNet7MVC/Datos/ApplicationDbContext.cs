using CrudNet7MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudNet7MVC.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //AGREGAR LOS MODELOS AQUI - MANTENIENDO EL NOMBRE DE LA TABLA CONTACTOS
        public DbSet<Contacto> Contactos { get; set; }  
    }
}
