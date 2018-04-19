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

            var moras = (List<MoraSelectViewModels>)dbMora.FindForId(id);
            var pagos = (List<PagosSelectViewModels>)dbPago.FindForId(id);

            foreach (var pago in pagos)
            {
                var estadoPagos = new EstadoPagosViewModels();
                estadoPagos.saldo_anterior = pago.saldo_anterior;
                estadoPagos.saldo_actual = pago.saldo_actual;
                estadoPagos.monto_pago = pago.monto;
                estadoPagos.fecha_pagar = pago.fecha_pagar;
                estadoPagos.fecha_cancelada = pago.fecha_cancelada;

                foreach (var mora in moras)
                {
                    if (mora.fecha == pago.fecha_pagar)
                    {
                        estadoPagos.monto_mora = mora.monto;
                        estadoPagos.estado = mora.estado;
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
                    saldo_anterior = estados.saldo_anterior,
                    saldo_actual = estados.saldo_actual,
                    monto_pago = 0,
                    fecha_pagar = mora.fecha,
                    monto_mora = mora.monto,
                    estado = mora.estado
                });
            }

            return listPagos;
        }
    }
}
