using InmobiliariaDataLayer.Clientes;
using InmobiliariaDataLayer.Empleados;
using InmobiliariaDataLayer.Lote;
using InmobiliariaDataLayer.Lotificadora;
using InmobiliariaDataLayer.Pagos;
using InmobiliariaDataLayer.Venta;
using InmobiliariaLogicLayer.Clientes;
using InmobiliariaLogicLayer.Cuotas;
using InmobiliariaLogicLayer.Empleados;
using InmobiliariaLogicLayer.Lotes;
using InmobiliariaLogicLayer.Lotificadora;
using InmobiliariaLogicLayer.Venta;
using InmobiliariaViewModels.Clientes;
using InmobiliariaViewModels.Cuotas;
using InmobiliariaViewModels.Empleados;
using InmobiliariaViewModels.Lotes;
using InmobiliariaViewModels.Pagos;
using InmobiliariaViewModels.Venta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inmobiliaria.Controllers
{
    public class VentaController : Controller
    {
        private static ClienteInsertViewModels cliente;
        private static EmpleadosIngresoViewModels empleado;
        private static LoteIngresoViewModels lote;
        private static CuotaVentaViewModels cuota_venta;
        // GET: Venta
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IdCliente(int id) {
            var venta = new VentaViewModels();
            Cliente _cliente = new Cliente(new BdClientes());
            venta.Cliente = _cliente.SelectForId(id);
            cliente = venta.Cliente;
            
            Empleados emp = new Empleados(new DBEmpleados());
            venta.Empleados = emp.SelectAll();

            return View(venta);
        }

        public ActionResult IdLote(VentaViewModels datos)
        {
            var venta = new VentaViewModels();

            Lote lote = new Lote(new DBLote());
            venta.Lotes = lote.FindEstadoLoti();

            //Cliente _cliente = new Cliente(new BdClientes());
            //venta.Cliente = _cliente.SelectForId(datos.ClienteId);
            venta.Cliente = cliente;

            Empleados emp = new Empleados(new DBEmpleados());
            venta.Empleado = emp.SelectForId(datos.EmpVentaId);
            empleado = venta.Empleado;

            return View(venta);
        }

        public ActionResult CuotasVenta(VentaViewModels datos)
        {
            var venta = new VentaViewModels();
            Lote lt = new Lote(new DBLote());
            venta.Lote = lt.SelectForId(datos.LoteId);
            lote = venta.Lote;
            venta.Cliente = cliente;
            venta.Empleado = empleado;

            return View(venta);
        }

        public ActionResult CalcularVenta(VentaViewModels datos)
        {
            var venta = new VentaViewModels();
            venta.Cliente = cliente;
            venta.Empleado = empleado;
            venta.Lote = lote;

            datos.Cuota.cantidad = lote.precio_lote;
            Lotificadora lotificadora = new Lotificadora(new DBLotificadora());
            var loti = lotificadora.SelectForId(lote.lotificadora_id);
            datos.Cuota.interes = loti.tasa_interes;

            CuotaVenta cuota = new CuotaVenta();
            if (datos.Cuota.descuento != 0)
            {
                venta.Cuota = cuota.CalcularDescuento(datos.Cuota);
                cuota_venta = venta.Cuota;
            }
            else
            {
                venta.Cuota = cuota.CalcularSinDescuento(datos.Cuota);
                cuota_venta = venta.Cuota;
            }
            
            return View(venta);
        }

        public ActionResult SaveVentaContado()
        {
            //Seleccionar tipo de venta
            var tipov = new TipoVenta(new DBTipoVenta());
            int tipoventa_id = tipov.GetId("Contado");

            VentaViewModels venta = new VentaViewModels();

            //asignamos datos de encabezado
            venta.ClienteId = cliente.id;
            venta.EmpVentaId = empleado.id;
            venta.TipoVentaId = tipoventa_id;

            //insertar venta
            DBVenta dbventa = new DBVenta();
            dbventa.Save(venta);

            DBLastVenta dbLastVenta = new DBLastVenta();
            int ventaId = (int)dbLastVenta.FindAll();

            DetalleVenta(ventaId);
            EstadoLote();

            Pagos(ventaId, cuota_venta.cantidad);
            if (cuota_venta.descuento > 0)
            {
                Descuentos(ventaId);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult SaveVentaCredito()
        {
            //Seleccionar tipo de venta
            var tipov = new TipoVenta(new DBTipoVenta());
            int tipoventa_id = tipov.GetId("Credito");

            VentaViewModels venta = new VentaViewModels();

            //asignamos datos de encabezado
            venta.ClienteId = cliente.id;
            venta.EmpVentaId = empleado.id;
            venta.TipoVentaId = tipoventa_id;

            //insertar venta
            DBVenta dbventa = new DBVenta();
            dbventa.Save(venta);

            DBLastVenta dbLastVenta = new DBLastVenta();
            int ventaId = (int)dbLastVenta.FindAll();

            DetalleVenta(ventaId);
            EstadoLote();
            Pagos(ventaId, 0);
            FinanVenta(ventaId);
            if(cuota_venta.descuento > 0)
            {
                Descuentos(ventaId);
            }

            return RedirectToAction("Index", "Home");
        }

        private void DetalleVenta(int ventaId)
        {
            DBDetalleVenta dbDetalle = new DBDetalleVenta();
            DetalleVentaViewModels detalle = new DetalleVentaViewModels();
            detalle.VentaId = ventaId;
            detalle.PrecioInicial = lote.precio_lote;
            detalle.PrecioFinal = cuota_venta.cantidad;
            detalle.LoteId = lote.id;
            dbDetalle.Save(detalle);
        }

        private void Pagos(int ventaId, double montopago)
        {
            DBPagos dbPagos = new DBPagos();
            PagosViewModels pagos = new PagosViewModels();

            pagos.SaldoAnterior = cuota_venta.cantidad;
            pagos.SaldoActual = cuota_venta.cantidad;
            pagos.Monto = montopago;
            pagos.VentaId = ventaId;

            dbPagos.Save(pagos);
        }

        private void FinanVenta(int ventaId)
        {
            DBFinanVenta dbFinanVenta = new DBFinanVenta();
            FinanVentaViewModels finanVenta = new FinanVentaViewModels();
            Lotificadora lotificadora = new Lotificadora(new DBLotificadora());
            var loti = lotificadora.SelectForId(lote.lotificadora_id);

            finanVenta.Tiempo = cuota_venta.tiempo;
            finanVenta.Cuota = cuota_venta.cuota;
            finanVenta.TasaInteres = loti.tasa_interes;
            finanVenta.Mora = loti.tasa_mora;
            finanVenta.VentaId = ventaId;
            dbFinanVenta.Save(finanVenta);
        }

        private void Descuentos(int ventaId)
        {
            DBDescuento dbDescuento = new DBDescuento();
            DescuentoViewModels descuento = new DescuentoViewModels();

            descuento.Cantidad = cuota_venta.descuento;
            descuento.VentaId = ventaId;

            dbDescuento.Save(descuento);
        }

        private void EstadoLote()
        {
            Lote loteLogic = new Lote(new DBLote());
            var lt = lote;
            lt.estado_id = 2;
            loteLogic.Update(lt);
        }
    }
}