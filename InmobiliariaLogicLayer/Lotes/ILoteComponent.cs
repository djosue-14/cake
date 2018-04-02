﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaLogicLayer.Lotes
{
    public interface ILoteComponent
    {
        double calcularMonto();
        double calcularSaldo();
    }
}
