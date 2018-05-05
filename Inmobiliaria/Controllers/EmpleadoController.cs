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
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            DBEmpleados dbEmpleados = new DBEmpleados();
            Empleados emp = new Empleados(dbEmpleados);
            var listaemp = emp.SelectAll();

            return View(listaemp);
        }

        public ActionResult GetForId(int id)
        {
            Empleados _empleado = new Empleados(new DBEmpleados());
            ReferenciaEmp _refemp = new ReferenciaEmp(new DBReferenciaEmp());
            var empleado = _empleado.SelectForId(id);
            empleado.referencias = _refemp.FindForEmp(id);
            return View(empleado);
        }

        public ActionResult Create()
        {
            ViewBag.Title = "Ingresar Empleado";

            DBCargoEmp  dbcargo = new DBCargoEmp();
            CargoEmp cargo = new CargoEmp(dbcargo);
            DBEstadoEmp dbestadoemp = new DBEstadoEmp();
            EstadoEmp estado = new EstadoEmp(dbestadoemp);

            EmpleadosIngresoViewModels emp = new EmpleadosIngresoViewModels();
            emp.estados = estado.SelectAll();
            emp.cargos = cargo.SelectAll();
            return View(emp);
        }

        [HttpPost]
        public ActionResult Create(EmpleadosIngresoViewModels datos)
        {
            ViewBag.Title = "Ingresar Empleado";

            DBEmpleados dbEmpleados = new DBEmpleados();
            Empleados emp = new Empleados(dbEmpleados);
            emp.Save(datos);

            return RedirectToAction("Index", "Empleado");
        }

        //[HttpPost, ActionName("Delete")]
       
        public ActionResult Delete(int id)
        {
            DBEmpleados dbEmpleados = new DBEmpleados();
            Empleados emp = new Empleados(dbEmpleados);
            emp.Delete(id);
            return RedirectToAction("Index", "Empleado");
        }

        public ActionResult Edit(int id) {
            DBEmpleados dbEmpleados = new DBEmpleados();
            Empleados emp = new Empleados(dbEmpleados);
            DBCargoEmp dbcargo = new DBCargoEmp();
            CargoEmp cargo = new CargoEmp(dbcargo);
            DBEstadoEmp dbestadoemp = new DBEstadoEmp();
            EstadoEmp estadoemp = new EstadoEmp(dbestadoemp);

            EmpleadosIngresoViewModels emp2 = new EmpleadosIngresoViewModels();
            
            emp2 = emp.SelectForId(id);
            emp2.cargos = cargo.SelectAll();
            emp2.estados = estadoemp.SelectAll();

            return View(emp2);
        }

        [HttpPost]
        public ActionResult Edit(EmpleadosIngresoViewModels datos) {
            DBEmpleados dbEmpleados = new DBEmpleados();
            Empleados emp = new Empleados(dbEmpleados);
            emp.Update(datos);
            return RedirectToAction("Index", "Empleado");
        }
    }
}