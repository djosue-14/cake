using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InmobiliariaLogicLayer.Cuotas;
using InmobiliariaViewModels.Cuotas;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using Inmobiliaria.Reports;

namespace Inmobiliaria.Controllers
{
    public class CuotaController : Controller
    {
        private static List<CuotasPorFinanciamientoViewModels> sourceFinan;
        private static List<CuotasPorMesViewModels> sourceMes;
        // GET: Cuota
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Details(CalcularCuotaViewModels data)
        {
            ViewBag.Message = "Tabla Financiamiento";
            CuotasPorFinanciamiento calcular = new CuotasPorFinanciamiento();
            data.tiempo = 12;
            var model = calcular.listaPorFinanciamiento(data);
            sourceFinan = model;
            return View(model);
        }

        // POST: Cuota/Create
        [HttpPost]
        public ActionResult DetailMonths(CalcularCuotaViewModels data)
        {
            ViewBag.Message = "Tabla Cuotas";
            CuotasPorMes calcular = new CuotasPorMes();
            var model = calcular.listaPorMes(data);
            sourceMes = model;
            return View(model);
        }

        public ActionResult Calcular()
        {
            return View();
        }

        
        public FileStreamResult ShowFinanciamientoReport()
        {
            CreateReport cr = new CreateReport();
            string path = Path.Combine(Server.MapPath("~/Reports/Cuotas/CuotaPorFinanciamietoReport.rpt"));
            FileStreamResult fsr = new FileStreamResult(cr.StreamReport(path, sourceFinan), "application/pdf");
            return fsr;
        }

        public ActionResult DownloadFinanciamientoReport()
        {
            CreateReport cr = new CreateReport();
            string path = Path.Combine(Server.MapPath("~/Reports/Cuotas/CuotaPorFinanciamietoReport.rpt"));
            Stream stream = cr.StreamReport(path, sourceFinan);
            return File(stream, "application/pdf", "cuotaporfinanciamiento.pdf");
        }
        
        public FileStreamResult ShowMesReport()
        {
            CreateReport cr = new CreateReport();
            string path = Path.Combine(Server.MapPath("~/Reports/Cuotas/CuotaPorMesReport.rpt"));
            FileStreamResult fsr = new FileStreamResult(cr.StreamReport(path, sourceMes), "application/pdf");
            return fsr;
        }

        public ActionResult DownloadMesReport()
        {
            CreateReport cr = new CreateReport();
            string path = Path.Combine(Server.MapPath("~/Reports/Cuotas/CuotaPorMesReport.rpt"));
            Stream stream = cr.StreamReport(path, sourceMes);
            return File(stream, "application/pdf", "cuotapormes.pdf");
        }
    }
}
