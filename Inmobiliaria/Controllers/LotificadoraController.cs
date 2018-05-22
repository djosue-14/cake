using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InmobiliariaDataLayer.Lotificadora;
using InmobiliariaLogicLayer.Lotificadora;
using InmobiliariaViewModels.Lotificadora;

namespace Inmobiliaria.Controllers
{
    public class LotificadoraController : Controller
    {
        // GET: Lotificadora
        public ActionResult Index()
        {
            DBLotificadora dblotificadora = new DBLotificadora();
            Lotificadora lotifi = new Lotificadora(dblotificadora);
            var listalotifi = lotifi.SelectAll();

            return View(listalotifi);
        }

        public ActionResult Create()
        {
            ViewBag.Title = "Ingresar Lotificadora";

            return View();
        }

        [HttpPost]
        public ActionResult Create(LotificadoraViewModels datos)
        {
            ViewBag.Title = "Ingresar Lotificadora";

            DBLotificadora dblotificadora = new DBLotificadora();
            Lotificadora lotifi = new Lotificadora(dblotificadora);
            lotifi.Save(datos);

            return RedirectToAction("Index", "Lotificadora");
        }

        public ActionResult Delete(int id)
        {
            DBLotificadora dblotificadora = new DBLotificadora();
            Lotificadora lotifi = new Lotificadora(dblotificadora);
            lotifi.Delete(id);
            return RedirectToAction("Index", "Lotificadora");
        }

        public ActionResult Edit(int id)
        {
            DBLotificadora dblotificadora = new DBLotificadora();
            Lotificadora lotifi = new Lotificadora(dblotificadora);
            var lotifica = lotifi.SelectForId(id);
            return View(lotifica);
        }

        [HttpPost]
        public ActionResult Edit(LotificadoraViewModels datos)
        {
            DBLotificadora dblotificadora = new DBLotificadora();
            Lotificadora lotifi = new Lotificadora(dblotificadora);
            lotifi.Update(datos);
            return RedirectToAction("Index", "Lotificadora");
        }
    }
}