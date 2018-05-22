using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InmobiliariaDataLayer.Pagos;
using InmobiliariaLogicLayer.Pagos;
using InmobiliariaLogicLayer.Cuotas.Moras;
using InmobiliariaViewModels.Cuotas;
using InmobiliariaViewModels.Pagos;
using Inmobiliaria.Reports;
using System.IO;

namespace Inmobiliaria.Controllers
{
    public class EstadoCuentaController : Controller
    {
        private static List<EstadoPagosViewModels> sourcePagos;
        // GET: EstadoCuenta
        public ActionResult Index()
        {
            EstadoPagos estadoPagos = new EstadoPagos(new DBPagos(), new DBMoras());
            SetMoras(1);
            var listaPagos = estadoPagos.ListaPagos(1);
            return View(listaPagos);
        }

        public ActionResult ShowEstadoPagos(int id)
        {
            EstadoPagos estadoPagos = new EstadoPagos(new DBPagos(), new DBMoras());
            SetMoras(id);
            var listaPagos = estadoPagos.ListaPagos(id);
            sourcePagos = listaPagos;
            return View(listaPagos);
        }

        private void SetMoras(int id)
        {
            Moras mora = new Moras();
            
            //Selecciona la ultima cuota cancelada
            mora.DbForId = new DBCalcMora();
            var ultimaCuota =  mora.FindForId(id);
            
            //Selecciona la fecha de la ultima mora calculada
            //mora.DbForId = new DBMoras();
            //var ultimaFechaMora = mora.FechaUltimaMora(id);

            //calcula la mora y la guarda en la base de datos
            mora.CalcularMora(ultimaCuota);
        }

        public FileStreamResult ShowEstadoPagosReport()
        {
            CreateReport cr = new CreateReport();
            string path = Path.Combine(Server.MapPath("~/Reports/EstadoCuenta/EstadoPagosReport.rpt"));
            FileStreamResult fsr = new FileStreamResult(cr.StreamReport(path, SourcePagos()), "application/pdf");
            return fsr;
        }

        public ActionResult DownloadEstadoPagosReport()
        {
            CreateReport cr = new CreateReport();
            string path = Path.Combine(Server.MapPath("~/Reports/EstadoCuenta/EstadoPagosReport.rpt"));
            Stream stream = cr.StreamReport(path, SourcePagos());
            return File(stream, "application/pdf", "estadopagos.pdf");
        }

        private List<ReportEstadoPagosViewModels> SourcePagos()
        {
            var listPagos = new List<ReportEstadoPagosViewModels>();
            foreach (var item in sourcePagos)
            {
                listPagos.Add(new ReportEstadoPagosViewModels() {
                    SaldoAnterior = item.SaldoAnterior,
                    SaldoActual = item.SaldoActual,
                    MontoPago = item.MontoPago,
                    FechaPagar = item.FechaPagar.ToString("yyyy-MM-dd"),
                    FechaCancelada = item.FechaCancelada.ToString("yyyy-MM-dd") == "0001-01-01" ? "" : item.FechaCancelada.ToString("yyyy-MM-dd"),
                    MontoMora = item.MontoMora,
                    Estado = item.Estado == 1 || item.MontoMora == 0 ? "Cancelada" : "Sin Pagar",
                });
            }
            return listPagos;
        }
    }
}