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
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            BdClientes bdClientes = new BdClientes();
            Cliente cliente = new Cliente(bdClientes);
            var lista = cliente.SelectAllCliente();

            return View(lista);
        }

        public ActionResult GetForId(int id)
        {
            Cliente _cliente = new Cliente(new BdClientes());
            Referencia _referencia = new Referencia(new DBReferencia());

            var cliente = _cliente.SelectForId(id);
            cliente.referencias = _referencia.RefForCliente(id);

            return View(cliente);
        }

        public ActionResult Create()
        {
            ViewBag.Title = "Ingresar Cliente";
            return View(); 
        }

        [HttpPost]
        public ActionResult Create (ClienteInsertViewModels datos)
        {
            ViewBag.Title = "Ingresar Cliente";

            BdClientes bdClientes = new BdClientes();
            Cliente cliente = new Cliente(bdClientes);
            cliente.Save(datos);

            return RedirectToAction("Index", "Cliente");
        }

        public ActionResult Edit(int id)
        {
            BdClientes bdClientes = new BdClientes();
            Cliente cliente = new Cliente(bdClientes);
            var cli = cliente.SelectForId(id);
            
                
            return View(cli);
        }

        [HttpPost]
        public ActionResult Edit (ClienteInsertViewModels datos)
        {
            BdClientes bdClientes = new BdClientes();
            Cliente cliente = new Cliente(bdClientes);
            cliente.Update(datos);
            return RedirectToAction("Index", "Cliente");
        }
    }
}