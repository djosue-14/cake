using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InmobiliariaDataLayer.Lote;
using InmobiliariaLogicLayer.Lotes;
using InmobiliariaViewModels.Lotes;

namespace Inmobiliaria.Controllers
{
    public class LoteController : Controller
    {
        // GET: Lote
        public ActionResult Index()
        {
            DBLote dbLote = new DBLote();
            Lote lote = new Lote(dbLote);
            var listasLote = lote.SelectAllLote();

            return View(listasLote);
        }

        public ActionResult Create()
        {
            ViewBag.Title = "Ingresar Lote";
            return View();
        }

        [HttpPost]
        public ActionResult Create (LoteIngresoViewModels datos)
        {
            ViewBag.Title = "Ingresar Lote";
            DBLote dbLote = new DBLote();
            Lote lote = new Lote(dbLote);
            lote.Save(datos);
            return RedirectToAction("Index", "Lote");
        }

    }
}