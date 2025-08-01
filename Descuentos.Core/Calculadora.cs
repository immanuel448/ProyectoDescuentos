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

        public decimal CalcularPrecioConCantidad(decimal precioUnitario, int cantidad, int porcentajeDescuento)
        {
            if (porcentajeDescuento < 0 || porcentajeDescuento > 100)
                throw new ArgumentOutOfRangeException(nameof(porcentajeDescuento));
            if (cantidad <= 0)
                throw new ArgumentOutOfRangeException(nameof(cantidad));

            decimal totalBruto = precioUnitario * cantidad;
            decimal totalFinal = totalBruto * (1 - (porcentajeDescuento / 100m));
            return totalFinal;
        }

        public decimal CalcularPrecioConDescuentoFijo(decimal precioOriginal, decimal descuentoFijo)
        {
            if (descuentoFijo < 0 || descuentoFijo > precioOriginal)
                throw new ArgumentOutOfRangeException(nameof(descuentoFijo));

            return precioOriginal - descuentoFijo;
        }

        public decimal CalcularPrecioPorTipoCliente(decimal precioOriginal, string tipoCliente)
        {
            int porcentaje = tipoCliente.ToLower() switch
            {
                "vip" => 20,
                "regular" => 10,
                _ => 0
            };

            return CalcularPrecioFinal(precioOriginal, porcentaje);
        }


    }
}
