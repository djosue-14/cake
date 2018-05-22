using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InmobiliariaDataLayer.Empleados;
using InmobiliariaLogicLayer.Empleados;
using InmobiliariaViewModels.Empleados;

namespace Inmobiliaria.Controllers
{
    public class ReferenciaEmpController : Controller
    {
        public ActionResult Index()
        {
            DBReferenciaEmp dbReferenciaEmp = new DBReferenciaEmp();
            ReferenciaEmp refemp = new ReferenciaEmp(dbReferenciaEmp);
            var listarefemp = refemp.SelectAll();

            return View(listarefemp);
        }
        public ActionResult EnviarId(int Id)
        {
            TempData["EmpId"] = Id;
            return RedirectToAction("Create", "ReferenciaEmp");
        }
        public ActionResult Create()
        {
            ViewBag.Title = "Ingresar Referencia de Empleado";
            return View();
        }

        [HttpPost]
        public ActionResult Create(ReferenciaEmpViewModels datos)
        {
            ViewBag.Title = "Ingresar Referencia de Empleado";

            DBReferenciaEmp dbReferenciaEmp = new DBReferenciaEmp();
            ReferenciaEmp refemp = new ReferenciaEmp(dbReferenciaEmp);
            datos.id_emp = Convert.ToInt16(TempData["EmpId"]);
            refemp.Save(datos);
            return RedirectToAction("Index", "Empleado");
        }

        public ActionResult Edit(int id)
        {
            DBReferenciaEmp dbReferenciaEmp = new DBReferenciaEmp();
            ReferenciaEmp refemp = new ReferenciaEmp(dbReferenciaEmp);

            var referenciaemp = refemp.SelectForId(id);
            return View(referenciaemp);
        }

        [HttpPost]
        public ActionResult Edit(ReferenciaEmpViewModels datos)
        {
            DBReferenciaEmp dbReferenciaEmp = new DBReferenciaEmp();
            ReferenciaEmp refemp = new ReferenciaEmp(dbReferenciaEmp);
            refemp.Update(datos);
            return RedirectToAction("Index", "Empleado");
        }

        public ActionResult Delete(int id)
        {
            DBReferenciaEmp dbReferenciaEmp = new DBReferenciaEmp();
            ReferenciaEmp refemp = new ReferenciaEmp(dbReferenciaEmp);
            refemp.Delete(id);
            return RedirectToAction("Index", "Empleado");
        }

        public ActionResult RefForEmp(int id)
        {
            DBReferenciaEmp dbReferenciaEmp = new DBReferenciaEmp();
            ReferenciaEmp refemp = new ReferenciaEmp(dbReferenciaEmp);
            var lista = refemp.FindForEmp(id);
            
            return View(lista);
        }
    }
}