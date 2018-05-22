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
    public class ManzanaLoteController : Controller
    {
        // GET: ManzanaLote
        public ActionResult Index()
        {
            DBManzana dbmanzana = new DBManzana();
            Manzana manzana = new Manzana(dbmanzana);
            var lista = manzana.SelectAll();
            return View(lista);
        }

        public ActionResult Create()
        {
            ViewBag.Title = "Ingresar Manzana";
            return View();
        }
        [HttpPost]
        public ActionResult Create (ManzanaLoteViewModels datos)
        {
            ViewBag.Title = "Ingresar Manzana";
            DBManzana dbmanzana = new DBManzana();
            Manzana manzana = new Manzana(dbmanzana);
            manzana.Save(datos);
            return RedirectToAction("Index", "ManzanaLote");
        }

        public ActionResult Delete(int id)
        {
            DBManzana dbmanzana = new DBManzana();
            Manzana manzana = new Manzana(dbmanzana);
            manzana.Delete(id);
            return RedirectToAction("Index", "ManzanaLote");
        }
        public ActionResult Edit (int id)
        {
            DBManzana dbmanzana = new DBManzana();
            Manzana manzana = new Manzana(dbmanzana);
            var datos = manzana.SelectForId(id);
            return View(datos);

        }
        [HttpPost]
        public ActionResult Edit (ManzanaLoteViewModels datos)
        {
            DBManzana dbmanzana = new DBManzana();
            Manzana manzana = new Manzana(dbmanzana);
            manzana.Update(datos);
            return RedirectToAction("Index","ManzanaLote");
        }
               
    }
}