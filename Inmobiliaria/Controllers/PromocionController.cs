using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InmobiliariaLogicLayer.Lotes;
using InmobiliariaDataLayer.Promociones;
using InmobiliariaViewModels;
using InmobiliariaViewModels.Lotificadora;
using InmobiliariaLogicLayer.Lotificadora;
using InmobiliariaDataLayer.Lotificadora;


namespace Inmobiliaria.Controllers
{
    public class PromocionController : Controller
    {
        // GET: Promocion
        public ActionResult Index()
        {
            var promociones = new PromoViewModels();
            Promocion promo = new Promocion();
            promo._SelectAll = new DBPromocion();
            promociones.Promociones = promo.GetAll();

            Lotificadora lt = new Lotificadora(new DBLotificadora());
            promociones.Lotificadoras = lt.SelectAll();
            return View(promociones);
        }

        public ActionResult Lotificadora(int id)
        {
            Promocion promo = new Promocion();
            promo._SelectAll = new DBPromocion();

            var promociones = promo.FindForLotificadora(id);
            return View(promociones);
        }


        public ActionResult Save()
        {
            Lotificadora lt = new Lotificadora(new DBLotificadora());
            var promo = new PromocionViewModels();
            promo.Lotificadoras = lt.SelectAll();
            return View(promo);
        }

        [HttpPost]
        public ActionResult Save(PromocionViewModels data)
        {
            Promocion promo = new Promocion();
            promo._Save = new DBPromocion();
            promo.Save(data);
            return RedirectToAction("Index", "Promocion");
        }

        public ActionResult Edit(int id)
        {
            var model = new PromocionViewModels();
            Promocion promo = new Promocion();
            promo._SelectForId = new DBPromocion();
            model = promo.SelectForId(id);
            Lotificadora lt = new Lotificadora(new DBLotificadora());
            model.Lotificadoras = lt.SelectAll();
            
            //var promocion = promo.SelectForId(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(PromocionViewModels data)
        {
            Promocion promo = new Promocion();
            promo._Update = new DBPromocion();
            promo.Update(data);
            return RedirectToAction("Index", "Promocion");
        }
    }
}