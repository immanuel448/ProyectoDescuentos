using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Descuentos.Core
{
    public class Calculadora
    {
        public decimal CalcularPrecioFinal(decimal precioOriginal, int porcentajeDescuento)
        {
            if (porcentajeDescuento < 0 || porcentajeDescuento > 100)
                throw new ArgumentOutOfRangeException(nameof(porcentajeDescuento));

            return precioOriginal * (1 - (porcentajeDescuento / 100m));
        }
    }
}
