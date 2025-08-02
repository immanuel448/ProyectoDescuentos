using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Descuentos.Core
{
    public class Calculadora
    {
        // Calcula el precio final aplicando un porcentaje de descuento.
        public decimal CalcularPrecioFinal(decimal precioOriginal, int porcentajeDescuento)
        {
            // Validación: el porcentaje debe estar entre 0 y 100.
            if (porcentajeDescuento < 0 || porcentajeDescuento > 100)
                throw new ArgumentOutOfRangeException(nameof(porcentajeDescuento));

            // Aplica el descuento y devuelve el resultado.
            return precioOriginal * (1 - (porcentajeDescuento / 100m));
        }

        // Calcula el precio total para una cantidad de productos, aplicando un porcentaje de descuento.
        public decimal CalcularPrecioConCantidad(decimal precioUnitario, int cantidad, int porcentajeDescuento)
        {
            // Validaciones básicas.
            if (porcentajeDescuento < 0 || porcentajeDescuento > 100)
                throw new ArgumentOutOfRangeException(nameof(porcentajeDescuento));
            if (cantidad <= 0)
                throw new ArgumentOutOfRangeException(nameof(cantidad));

            // Multiplica el precio unitario por la cantidad para obtener el total bruto.
            decimal totalBruto = precioUnitario * cantidad;

            // Aplica el descuento al total bruto.
            decimal totalFinal = totalBruto * (1 - (porcentajeDescuento / 100m));

            return totalFinal;
        }

        // Calcula el precio final restando un descuento fijo en dinero.
        public decimal CalcularPrecioConDescuentoFijo(decimal precioOriginal, decimal descuentoFijo)
        {
            // Validación: el descuento fijo no puede ser negativo ni mayor al precio original.
            if (descuentoFijo < 0 || descuentoFijo > precioOriginal)
                throw new ArgumentOutOfRangeException(nameof(descuentoFijo));

            // Resta el descuento fijo y devuelve el resultado.
            return precioOriginal - descuentoFijo;
        }

        // Calcula el precio con descuento según el tipo de cliente.
        public decimal CalcularPrecioPorTipoCliente(decimal precioOriginal, string tipoCliente)
        {
            // Asigna un porcentaje según el tipo de cliente (VIP, Regular, otros).
            int porcentaje = tipoCliente.ToLower() switch
            {
                "vip" => 20,
                "regular" => 10,
                _ => 0 // Clientes no reconocidos no reciben descuento.
            };

            // Usa el método CalcularPrecioFinal para aplicar el porcentaje.
            return CalcularPrecioFinal(precioOriginal, porcentaje);
        }
    }
}
