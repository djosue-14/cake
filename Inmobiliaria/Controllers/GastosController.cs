using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InmobiliariaDataLayer.Lotificadora;
using InmobiliariaLogicLayer.Lotificadora;
using InmobiliariaViewModels.Lotificadora;
using InmobiliariaDataLayer.Empleados;
using InmobiliariaLogicLayer.Empleados;

namespace Inmobiliaria.Controllers
{
    public class GastosController : Controller
    {
        // GET: Gastos
        public ActionResult Index()
        {
            DBGastos dbgastos = new DBGastos();
            Gastos gasto = new Gastos(dbgastos);
            var listagastos = gasto.SelectAll();

            return View(listagastos);
        }

        public ActionResult Create()
        {
            ViewBag.Title = "Ingresar Gastos";

            DBLotificadora dblotificadora = new DBLotificadora();
            Lotificadora lotifi = new Lotificadora(dblotificadora);

            DBEmpleados dbempleados = new DBEmpleados();
            Empleados empleado = new Empleados(dbempleados);
            
            GastosViewModels gast = new GastosViewModels();
            gast.lotificadoras = lotifi.SelectAll();
            gast.empleados = empleado.SelectAll();

            return View(gast);
        }
    

        [HttpPost]
        public ActionResult Create(GastosViewModels datos)
        {
            ViewBag.Title = "Ingresar Gastos";

            DBGastos dbgastos = new DBGastos();
            Gastos gasto = new Gastos(dbgastos);
            gasto.Save(datos);

            return RedirectToAction("Index", "Gastos");
        }

        public ActionResult Delete(int id)
        {
            DBGastos dbgastos = new DBGastos();
            Gastos gasto = new Gastos(dbgastos);
            gasto.Delete(id);
            return RedirectToAction("Index", "Gastos");
        }

        public ActionResult Edit(int id)
        {
            DBGastos dbgastos = new DBGastos();
            Gastos gasto = new Gastos(dbgastos);
            DBLotificadora dblotificadora = new DBLotificadora();
            Lotificadora lotifi = new Lotificadora(dblotificadora);
            DBEmpleados dbempleados = new DBEmpleados();
            Empleados empleado = new Empleados(dbempleados);

            GastosViewModels gasto2 = new GastosViewModels();
            
            gasto2 = gasto.SelectForId(id);
            gasto2.lotificadoras = lotifi.SelectAll();
            gasto2.empleados = empleado.SelectAll();

            return View(gasto2);

        }

        [HttpPost]
        public ActionResult Edit(GastosViewModels datos)
        {
            DBGastos dbgastos = new DBGastos();
            Gastos gasto = new Gastos(dbgastos);
            gasto.Update(datos);
            return RedirectToAction("Index","Gastos");
        }
    }
}