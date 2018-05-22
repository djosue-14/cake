using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InmobiliariaDataLayer.Lote;
using InmobiliariaLogicLayer.Lotes;
using InmobiliariaViewModels.Lotes;
using InmobiliariaLogicLayer.Lotificadora;
using InmobiliariaDataLayer.Lotificadora;

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
            DBLotificadora dblotificadora = new DBLotificadora();
            Lotificadora lotifi = new Lotificadora(dblotificadora);
            DBManzana dbmanzana = new DBManzana();
            Manzana manzana = new Manzana(dbmanzana);
            DBEstadoLote dbestado = new DBEstadoLote();
            EstadoLote estado = new EstadoLote(dbestado);

            LoteIngresoViewModels lote = new LoteIngresoViewModels();
            lote.lotificadoras = lotifi.SelectAll();
            lote.manzanas = manzana.SelectAll();
            lote.estados = estado.SelectAll();
            
            return View(lote);            
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

        public ActionResult Edit(int id)
        {
            DBLote dblote = new DBLote();
            Lote lote = new Lote(dblote);
            DBLotificadora dblotificadora = new DBLotificadora();
            Lotificadora lotifi = new Lotificadora(dblotificadora);
            DBManzana dbmanzana = new DBManzana();
            Manzana manzana = new Manzana(dbmanzana);
            DBEstadoLote dbestado = new DBEstadoLote();
            EstadoLote estado = new EstadoLote(dbestado);

            LoteIngresoViewModels lote2 = new LoteIngresoViewModels();

            lote2 = lote.SelectForId(id);
            lote2.lotificadoras = lotifi.SelectAll();
            lote2.manzanas = manzana.SelectAll();
            lote2.estados = estado.SelectAll();
            return View(lote2);
        }

        [HttpPost]
        public ActionResult Edit (LoteIngresoViewModels datos)
        {
            DBLote dblote = new DBLote();
            Lote lote = new Lote(dblote);
            lote.Update(datos);
            return RedirectToAction("Index", "Lote");
        }

        public ActionResult Delete(int id)
        {
            DBLote dblote = new DBLote();
            Lote lote = new Lote(dblote);
            lote.Delete(id);
            return RedirectToAction("Index", "Lote");
        }

        public ActionResult GetForId (int id)
        {
            Lote _lote = new Lote(new DBLote());
            Manzana manzana = new Manzana(new DBManzana());
            var lote = _lote.SelectForId(id);
            //lote.manzanas = manzana.ManzanaForLote(id);
            return View(lote);
        }

        public ActionResult FindLoti(string lotificadora)
        {
            Lote _lote = new Lote(new DBLote());
            var lote = _lote.FindLoti(lotificadora);
            return View(lote);
        }

    }
}