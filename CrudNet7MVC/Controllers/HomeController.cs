using CrudNet7MVC.Datos;
using CrudNet7MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CrudNet7MVC.Controllers
{
    public class HomeController : Controller
    {
        // AGREGANDO NUESTRO CONTEXTO TENGO ACCESO A LOS MODELOS
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contactos.ToListAsync());
        }
        
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Contacto contacto)
        {
            // ModelState quiere decir que todos los campos del modelo estan bien
            if(ModelState.IsValid)
            {
                //.Add es un metodo de Entity - Pasamos el modelo a Entity
                _context.Contactos.Add(contacto);
                // Guardarmos el modelo en la DB
                await _context.SaveChangesAsync();
                // Retornamos a la pagina principal
                return RedirectToAction("Index");   
            }
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id) 
        { 
            if(id == null)
            {
                return NotFound();
            }
          
            //obtengo el modelo con el Id
            var contacto = _context.Contactos.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Contacto contacto)
        {
            // ModelState quiere decir que todos los campos del modelo estan bien
            if (ModelState.IsValid)
            {
                //.Update es un metodo de Entity - Pasamos el modelo a Entity
                _context.Contactos.Update(contacto);
                // Guardarmos el modelo en la DB
                await _context.SaveChangesAsync();
                // Retornamos a la pagina principal
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //obtengo el modelo con el Id
            var contacto = _context.Contactos.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);


        }

        [HttpGet]

        public IActionResult Borrar(int? id)
        {
            var contacto = _context.Contactos.Find(id);
            if(contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

        //BORRAR USUARIO
        [HttpPost, ActionName("Borrar")] // Borrar es el action en el formulario
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarContacto(int? id)
        {
            var contacto = await _context.Contactos.FindAsync(id);
            if (contacto == null)
            {
                return View();
            }
            _context.Contactos.Remove(contacto);
            await _context.SaveChangesAsync(); //GUARDAMOS LOS CAMBIOS
            return RedirectToAction("index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
