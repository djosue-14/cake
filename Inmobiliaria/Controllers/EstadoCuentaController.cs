using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InmobiliariaDataLayer.Pagos;
using InmobiliariaLogicLayer.Pagos;

namespace Inmobiliaria.Controllers
{
    public class EstadoCuentaController : Controller
    {
        // GET: EstadoCuenta
        public ActionResult Index()
        {
            DBPagos dbPagos = new DBPagos();
            DBMoras dbMoras = new DBMoras();

            EstadoPagos estadoPagos = new EstadoPagos(dbPagos, dbMoras);
            var listaPagos = estadoPagos.ListaPagos(1);
            return View(listaPagos);
        }
    }
}