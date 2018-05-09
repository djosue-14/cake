using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InmobiliariaDataLayer.Clientes;
using InmobiliariaLogicLayer.Clientes;
using InmobiliariaViewModels.Clientes;

namespace Inmobiliaria.Controllers
{
    public class ReferenciaController : Controller
    {
        // GET: Referencia
        public ActionResult Index()
        {
            DBReferencia dbreferencia = new DBReferencia();
            Referencia referencia = new Referencia(dbreferencia);
            var lista = referencia.SelectAllReferencia();
            return View(lista);
        }

        public ActionResult Create()
        {
            ViewBag.Title = "Ingresar Referencia";
            return View();
        }

        [HttpPost]
        public ActionResult Create (ClienteReferenciaViewModels datos)
        {
            ViewBag.Title = "Ingresar Referencia";
            DBReferencia dbreferencia = new DBReferencia();
            Referencia referencia = new Referencia(dbreferencia);
            referencia.Save(datos);


            return RedirectToAction("Index", "Referencia");
        }
    }
}