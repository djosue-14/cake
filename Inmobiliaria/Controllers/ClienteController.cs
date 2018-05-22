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
           Beneficiario _beneficiario = new Beneficiario(new DBBeneficiario());
            var cliente = _cliente.SelectForId(id);
          //  var beneficiario = _beneficiario.SelectForId(id);
            cliente.referencias = _referencia.RefForCliente(id);
            cliente.beneficiario = _beneficiario.BenefForCliente(id);

            return View(cliente);
        }

        public ActionResult Create()
        {
            ViewBag.Title = "Ingresar Cliente";

            DBEstadoCli dbestadocli = new DBEstadoCli();
            EstadoCli estado = new EstadoCli(dbestadocli);

            ClienteInsertViewModels cli = new ClienteInsertViewModels();
            cli.estados = estado.SelectAll();
            return View(cli); 
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
            DBEstadoCli dbestadocli = new DBEstadoCli();
            EstadoCli estado = new EstadoCli(dbestadocli);

            ClienteInsertViewModels cli2 = new ClienteInsertViewModels();

            cli2 = cliente.SelectForId(id);
            cli2.estados = estado.SelectAll();
              
            return View(cli2);
        }

        [HttpPost]
        public ActionResult Edit (ClienteInsertViewModels datos)
        {
            BdClientes bdClientes = new BdClientes();
            Cliente cliente = new Cliente(bdClientes);
            cliente.Update(datos);
            return RedirectToAction("Index", "Cliente");
        }

        public ActionResult Delete (int id)
        {
            BdClientes bdcliente = new BdClientes();
            Cliente cliente = new Cliente(bdcliente);
            cliente.Delete(id);
            return RedirectToAction("Index", "Cliente");
        }
    }
}