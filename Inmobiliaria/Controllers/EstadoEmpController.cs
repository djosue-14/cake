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
    public class EstadoEmpController : Controller
        // GET: EstadoEmp
    {
        public ActionResult Index()
        {
            DBEstadoEmp dbestadoEmp = new DBEstadoEmp();
            EstadoEmp estadoemp = new EstadoEmp(dbestadoEmp);
            var listaestado = estadoemp.SelectAll();

            return View(listaestado);
        }

        public ActionResult Create()
        {
            ViewBag.Title = "Ingresar Estado de Empleado";

            return View();
        }

        [HttpPost]
        public ActionResult Create(EstadoEmpViewModels datos)
        {
            ViewBag.Title = "Ingresar Estado de Empleado";

            DBEstadoEmp dbestadoEmp = new DBEstadoEmp();
            EstadoEmp estadoemp = new EstadoEmp(dbestadoEmp);
            estadoemp.Save(datos);

            return RedirectToAction("Index", "EstadoEmp");
        }

        public ActionResult Delete(int id)
        {
            DBEstadoEmp dbestadoEmp = new DBEstadoEmp();
            EstadoEmp estadoemp = new EstadoEmp(dbestadoEmp);
            estadoemp.Delete(id);
            return RedirectToAction("Index", "EstadoEmp");
        }

        public ActionResult Edit(int id)
        {
            DBEstadoEmp dbestadoEmp = new DBEstadoEmp();
            EstadoEmp estadoemp = new EstadoEmp(dbestadoEmp);
            var estado = estadoemp.SelectForId(id);
            return View(estado);
        }

        [HttpPost]
        public ActionResult Edit(EstadoEmpViewModels datos)
        {
            DBEstadoEmp dbestadoEmp = new DBEstadoEmp();
            EstadoEmp estadoemp = new EstadoEmp(dbestadoEmp);
            estadoemp.Update(datos);
            return RedirectToAction("Index", "EstadoEmp");
        }
    }
}