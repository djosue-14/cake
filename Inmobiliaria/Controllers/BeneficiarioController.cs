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

        public ActionResult EnviarId(int Id)
        {
            TempData["CliBenef"] = Id;
            return RedirectToAction("Create", "Beneficiario");

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
            datos.ClienteId = Convert.ToInt32(TempData["CliBenef"]);
            beneficiario.Save(datos);
            return RedirectToAction("Index", "Cliente");
            
        }

        public ActionResult Edit(int id)
        {
            DBBeneficiario dbbeneficiario = new DBBeneficiario();
            Beneficiario beneficiario = new Beneficiario(dbbeneficiario);
            var benefi = beneficiario.SelectForId(id);
            return View(benefi);
        }
        [HttpPost]
        public ActionResult Edit (BeneficiarioViewModels datos)
        {
            DBBeneficiario dbbeneficiario = new DBBeneficiario();
            Beneficiario beneficiario = new Beneficiario(dbbeneficiario);
            beneficiario.Update(datos);
            return RedirectToAction("Index", "Cliente");
        }
        
        public ActionResult Delete (int id)
        {
            DBBeneficiario dbbeneficiario = new DBBeneficiario();
            Beneficiario beneficiario = new Beneficiario(dbbeneficiario);
            beneficiario.Delete(id);
            return RedirectToAction("Index", "Cliente");

        }


    }
}