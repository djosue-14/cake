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
using InmobiliariaViewModels.Empleados;

namespace Inmobiliaria.Controllers
{
    public class ViaticosController : Controller
    {
        // GET: Gastos
        public ActionResult Index()
        {
            DBViaticos dbviaticos = new DBViaticos();
            Viaticos viati = new Viaticos(dbviaticos);
            var listaviati = viati.SelectAll();

            return View(listaviati);
        }

        public ActionResult Create()
        {
            ViewBag.Title = "Ingresar Viaticos";

            DBLotificadora dblotificadora = new DBLotificadora();
            Lotificadora lotifi = new Lotificadora(dblotificadora);

            DBEmpleados dbempleados = new DBEmpleados();
            Empleados empleado = new Empleados(dbempleados);
            
            ViaticosViewModels via = new ViaticosViewModels();
            via.lotificadoras = lotifi.SelectAll();
            via.empleados = empleado.SelectAll();

            return View(via);
        }
    

        [HttpPost]
        public ActionResult Create(ViaticosViewModels datos)
        {
            ViewBag.Title = "Ingresar Viaticos";

            DBViaticos dbviati = new DBViaticos();
            Viaticos viati = new Viaticos(dbviati);
            viati.Save(datos);

            return RedirectToAction("Index", "Viaticos");
        }

        public ActionResult Delete(int id)
        {
            DBViaticos dbviati = new DBViaticos();
            Viaticos viati = new Viaticos(dbviati);
            viati.Delete(id);
            return RedirectToAction("Index", "Viaticos");
        }

        public ActionResult Edit(int id)
        {
            DBViaticos dbviati = new DBViaticos();
            Viaticos viati = new Viaticos(dbviati);
            DBLotificadora dblotificadora = new DBLotificadora();
            Lotificadora lotifi = new Lotificadora(dblotificadora);
            DBEmpleados dbempleados = new DBEmpleados();
            Empleados empleado = new Empleados(dbempleados);

            ViaticosViewModels viati2 = new ViaticosViewModels();
            
            viati2 = viati.SelectForId(id);
            viati2.lotificadoras = lotifi.SelectAll();
            viati2.empleados = empleado.SelectAll();

            return View(viati2);

        }

        [HttpPost]
        public ActionResult Edit(ViaticosViewModels datos)
        {
            DBViaticos dbviati = new DBViaticos();
            Viaticos viati = new Viaticos(dbviati);
            viati.Update(datos);
            return RedirectToAction("Index","Viaticos");
        }
    }
}