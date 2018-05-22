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
    public class EstadoLoteController : Controller
    {
        // GET: EstadoLote
        public ActionResult Index()
        {
            DBEstadoLote dbestado = new DBEstadoLote();
            EstadoLote estado = new EstadoLote(dbestado);
            var lista = estado.SelectAll();

            return View(lista);
        }

        public ActionResult Create()
        {
            ViewBag.Title = "Ingresar Estado";
            return View();
        }


        [HttpPost]
        public ActionResult Create(EstadoLoteViewModels datos)
        {
            ViewBag.Title = "Ingresar Estado";

            DBEstadoLote dbestado = new DBEstadoLote();
            EstadoLote estado = new EstadoLote(dbestado);
            estado.Save(datos);

            return RedirectToAction("Index", "EstadoLote");
        }

        public ActionResult  Edit (int id)
        {
            DBEstadoLote dbestado = new DBEstadoLote();
            EstadoLote estado = new EstadoLote(dbestado);
            var datos = estado.SelectForId(id);
            return View(datos);

        }

        [HttpPost]
        public ActionResult Edit(EstadoLoteViewModels datos)
        {
            DBEstadoLote dbestado = new DBEstadoLote();
            EstadoLote estado = new EstadoLote(dbestado);
            estado.Update(datos);
            return RedirectToAction("Index", "EstadoLote");

        }

        public ActionResult Delete (int id)
        {
            DBEstadoLote dbestado = new DBEstadoLote();
            EstadoLote estado = new EstadoLote(dbestado);
            estado.Delete(id);
            return RedirectToAction("Index", "EstadoLote");
        }


    }
}