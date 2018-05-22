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
    public class EstadoCliController : Controller
    {
        // GET: EstadoCli
        public ActionResult Index()
        {
            DBEstadoCli dbestadoCli = new DBEstadoCli();
            EstadoCli estadocli = new EstadoCli(dbestadoCli);
            var listaestado = estadocli.SelectAll();

            return View(listaestado);
        }

        public ActionResult Create()
        {
            ViewBag.Title = "Ingresar Estado de Cliente";

            return View();
        }

        [HttpPost]
        public ActionResult Create(EstadoCliViewModels datos)
        {
            ViewBag.Title = "Ingresar Estado de Empleado";

            DBEstadoCli dbestadoCli = new DBEstadoCli();
            EstadoCli estadocli = new EstadoCli(dbestadoCli);
            estadocli.Save(datos);

            return RedirectToAction("Index", "EstadoCli");
        }

        public ActionResult Delete(int id)
        {
            DBEstadoCli dbestadoCli = new DBEstadoCli();
            EstadoCli estadocli = new EstadoCli(dbestadoCli);
            estadocli.Delete(id);
            return RedirectToAction("Index", "EstadoCli");
        }

        public ActionResult Edit(int id)
        {
            DBEstadoCli dbestadoCli = new DBEstadoCli();
            EstadoCli estadocli = new EstadoCli(dbestadoCli);
            var estado = estadocli.SelectForId(id);
            return View(estado);
        }

        [HttpPost]
        public ActionResult Edit(EstadoCliViewModels datos)
        {
            DBEstadoCli dbestadoCli = new DBEstadoCli();
            EstadoCli estadocli = new EstadoCli(dbestadoCli);
            estadocli.Update(datos);
            return RedirectToAction("Index", "EstadoCli");
        }
    }
}