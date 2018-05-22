using InmobiliariaDataLayer.Clientes;
using InmobiliariaViewModels.Clientes;
using InmobiliariaViewModels.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inmobiliaria.Controllers
{
    public class PagosController : Controller
    {
        // GET: Pagos
        public ActionResult Index()
        {
            return View();

        }

        public ActionResult Pagar(int id) {
            DBPagar dbpagar = new DBPagar();

            UltimoPagoViewModels pag = new UltimoPagoViewModels();
            pag = (UltimoPagoViewModels)dbpagar.UltimoPago(id);
            return View(pag);
        }

        public ActionResult VentaCliente(int id) {
            DBPagar dbpagar = new DBPagar();
            
            var pag = (List<ClientesPagarViewModels>)dbpagar.FindForId(id);

            return View(pag);
        }

        [HttpPost]
        public ActionResult Create(UltimoPagoViewModels datos)
        {
            DBPagar dbpagar = new DBPagar();

            if (datos.Cuota == datos.Monto)
            {
                datos.Fecha_Pagar.AddMonths(1);
                datos.Saldo_Anterior = datos.Saldo_Actual;
                datos.Saldo_Actual = datos.Saldo_Actual - datos.Monto;
                dbpagar.Save(datos);
            }

            return RedirectToAction("Pagar/"+datos.Venta_id, "Pagos");
        }

    }
}