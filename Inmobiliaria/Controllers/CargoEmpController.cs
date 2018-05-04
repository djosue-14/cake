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
    public class CargoEmpController : Controller
    {
        // GET: CargoEmp
        public ActionResult Index()
        {
            DBCargoEmp dbcargoEmp = new DBCargoEmp();
            CargoEmp cargoemp = new CargoEmp(dbcargoEmp);
            var listacargo = cargoemp.SelectAll();

            return View(listacargo);
        }

        public ActionResult Create()
        {
            ViewBag.Title = "Ingresar Cargo";

            return View();
        }

        [HttpPost]
        public ActionResult Create(CargoEmpViewModels datos)
        {
            ViewBag.Title = "Ingresar Cargo";

            DBCargoEmp dbcargoEmp = new DBCargoEmp();
            CargoEmp cargoemp = new CargoEmp(dbcargoEmp);
            cargoemp.Save(datos);

            return RedirectToAction("Index", "CargoEmp");
        }

        public ActionResult Delete(int id)
        {
            DBCargoEmp dbcargoEmp = new DBCargoEmp();
            CargoEmp cargoemp = new CargoEmp(dbcargoEmp);
            cargoemp.Delete(id);
            return RedirectToAction("Index", "CargoEmp");
        }

        public ActionResult Edit(int id)
        {
            DBCargoEmp dbcargoEmp = new DBCargoEmp();
            CargoEmp cargoemp = new CargoEmp(dbcargoEmp);
            var cargo = cargoemp.SelectForId(id);
            return View(cargo);
        }

        [HttpPost]
        public ActionResult Edit(CargoEmpViewModels datos)
        {
            DBCargoEmp dbcargoEmp = new DBCargoEmp();
            CargoEmp cargoemp = new CargoEmp(dbcargoEmp);
            cargoemp.Update(datos);
            return RedirectToAction("Index", "CargoEmp");
        }
    }
}