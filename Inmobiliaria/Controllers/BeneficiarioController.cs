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
    public class BeneficiarioController : Controller
    {
        // GET: Beneficiario
        public ActionResult Index()
        {
            DBBeneficiario dbbeneficiario = new DBBeneficiario();
            Beneficiario beneficiario = new Beneficiario(dbbeneficiario);
            var lista = beneficiario.SelectAllBeneficiario();
            return View(lista);
        }
        public ActionResult Create()
        {
            ViewBag.Title = "Ingresar Beneficiario";
            return View();
        }

        [HttpPost]
        public ActionResult Create(BeneficiarioViewModels datos) 
        {
            ViewBag.Title = "Ingresar Beneficiario";
            DBBeneficiario dbbeneficiario = new DBBeneficiario();
            Beneficiario beneficiario = new Beneficiario(dbbeneficiario);
            beneficiario.Save(datos);
            return RedirectToAction("Index", "Beneficiario");
            
        }


    }
}