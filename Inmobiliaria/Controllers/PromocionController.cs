using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InmobiliariaLogicLayer.Lotes;
using InmobiliariaDataLayer.Promociones;
using InmobiliariaViewModels;


namespace Inmobiliaria.Controllers
{
    public class PromocionController : Controller
    {
        // GET: Promocion
        public ActionResult Index()
        {
            Promocion promo = new Promocion();
            promo._SelectAll = new DBPromocion();

            var promociones = promo.GetAll();
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
            return View();
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
            Promocion promo = new Promocion();
            promo._SelectForId = new DBPromocion();
            var promocion = promo.SelectForId(id);
            return View(promocion);
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