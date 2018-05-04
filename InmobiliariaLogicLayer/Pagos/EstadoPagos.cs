using InmobiliariaViewModels.Cuotas;
using InmobiliariaViewModels.EstadoCuenta;
using InmobiliariaViewModels.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaLogicLayer.Persistence;

namespace InmobiliariaLogicLayer.Pagos
{
    public class EstadoPagos
    {
        private ISelectForId dbPago;
        private ISelectForId dbMora;

        public EstadoPagos(ISelectForId dbPago, ISelectForId dbMora)
        {
            this.dbPago = dbPago;
            this.dbMora = dbMora;
        }
        
        public List<EstadoPagosViewModels> ListaPagos(int id)
        {
            var listPagos = new List<EstadoPagosViewModels>();
            var estados = new EstadoPagosViewModels();

            var moras = (List<MoraViewModels>)dbMora.FindForId(id);
            var pagos = (List<PagosSelectViewModels>)dbPago.FindForId(id);

            foreach (var pago in pagos)
            {
                var estadoPagos = new EstadoPagosViewModels();
                estadoPagos.SaldoAnterior = pago.SaldoAnterior;
                estadoPagos.SaldoActual = pago.SaldoActual;
                estadoPagos.MontoPago = pago.Monto;
                estadoPagos.FechaPagar = pago.FechaPagar;
                estadoPagos.FechaCancelada = pago.FechaCancelada;

                foreach (var mora in moras)
                {
                    if (mora.Fecha == pago.FechaPagar)
                    {
                        estadoPagos.MontoMora = mora.Monto;
                        estadoPagos.Estado = mora.Estado;
                        moras.Remove(mora);
                        break;
                    }
                }
                estados = estadoPagos;
                listPagos.Add(estadoPagos);
            }

            foreach (var mora in moras)
            {
                listPagos.Add(new EstadoPagosViewModels()
                {
                    SaldoAnterior = estados.SaldoAnterior,
                    SaldoActual = estados.SaldoActual,
                    MontoPago = 0,
                    FechaPagar = mora.Fecha,
                    MontoMora = mora.Monto,
                    Estado = mora.Estado
                });
            }

            return listPagos;
        }
    }
}
