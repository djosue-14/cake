using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InmobiliariaLogicLayer.Cuotas;
using InmobiliariaViewModels.Cuotas;

namespace Inmobiliaria.Controllers
{
    public class CuotaController : Controller
    {
        // GET: Cuota
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Details(CalcularCuotaViewModels data)
        {
            ViewBag.Message = "Tabla Financiamiento";
            CuotasPorFinanciamiento calcular = new CuotasPorFinanciamiento();
            var model = calcular.listaPorFinanciamiento(data);
            return View(model);
        }

        // POST: Cuota/Create
        [HttpPost]
        public ActionResult DetailMonths(CalcularCuotaViewModels data)
        {
            ViewBag.Message = "Tabla Cuotas";
            CuotasPorMes calcular = new CuotasPorMes();
            var model = calcular.listaPorMes(data);
            return View(model);
        }

        public ActionResult Calcular()
        {
            return View();
        }

    }
}
