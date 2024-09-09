using Aplicacion.Repositories;
using Aplicacion.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CajeroAutomatico.Controllers
{
    public class DispensacionController : Controller
    {
        private readonly DispensacionRepository dispensacionRepository;
        public DispensacionController()
        {
            dispensacionRepository = new DispensacionRepository();

        }
       // Mostar la pantalla que permitira seleccionar el modo de dispensacion 
        public IActionResult Configurar()
        {
            var modoActual = dispensacionRepository.GetMode();
            var modo = new DispensacionViewModel { SeleccionarModo = modoActual };
            return View(modo);
        }
        // con esta accion se guardara el modo seleccionado
        [HttpPost]
        public IActionResult Configurar(DispensacionViewModel models)
        {
            dispensacionRepository.SetMode(models.SeleccionarModo);

            return Redirect("Configurar");
        }

	}
}
