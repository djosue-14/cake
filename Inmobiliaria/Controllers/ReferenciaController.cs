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

        public ActionResult EnviarId(int Id)
        {
            TempData["ClienteId"] = Id;
            return RedirectToAction("Create", "Referencia");
            
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
            datos.ClienteId = Convert.ToInt32(TempData["ClienteId"]);
            referencia.Save(datos);


            return RedirectToAction("Index", "Cliente");
        }

        public ActionResult Edit (int id)
        {
            DBReferencia dbreferencia = new DBReferencia();
            Referencia referencia = new Referencia(dbreferencia);
            var reff = referencia.SelectForId(id);
            return View(reff);

        }

        [HttpPost]
        public ActionResult Edit (ClienteReferenciaViewModels datos)
        {
            DBReferencia dbreferencia = new DBReferencia();
            Referencia referencia = new Referencia(dbreferencia);
            referencia.Update(datos);
            return RedirectToAction("Index", "Cliente");
        }

        public ActionResult Delete (int id)
        {
            DBReferencia dbreferencia = new DBReferencia();
            Referencia referencia = new Referencia(dbreferencia);
            referencia.Delete(id);
            return RedirectToAction("Index", "Cliente");
        }

    }
}