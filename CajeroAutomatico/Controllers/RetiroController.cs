using Aplicacion.Repositories;
using Aplicacion.Service;
using Aplicacion.ViewModels;
using Microsoft.AspNetCore.Mvc;

public class RetiroController : Controller
{
    private readonly DispensacionRepository dispensacionRepository;
    private readonly RetiroService retiroService;

    public RetiroController()
    {
        dispensacionRepository = new DispensacionRepository();
        retiroService = new RetiroService();
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult RetirarDinero(RetirarViewModel model)
    {
        if (model.Monto % 100 != 0)
        {
            ModelState.AddModelError("", "Solo puedes retirar múltiplos de 100.");
            return View("Index", model);
        }

        var modoActual = dispensacionRepository.GetMode();
        var resultado = retiroService.ProcesoRetiro(model.Monto, modoActual);

        if (resultado == null)
        {
            ModelState.AddModelError("", $"El modo actual solo permite cantidades compatibles con {modoActual}.");
            return View("Index", model);
        }

        return View("Resultado", resultado);
    }
}
