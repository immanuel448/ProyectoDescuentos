using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Descuentos.Core;

namespace Descuentos.Tests
{
    public class CalculadoraTests
    {
        [Fact]
        public void DescuentoDel10_DeberiaDevolver90()
        {
            var calc = new Calculadora();
            var resultado = calc.CalcularPrecioFinal(100, 10);
            Assert.Equal(90, resultado);
        }

        [Fact]
        public void DescuentoMayorA100_DeberiaLanzarExcepcion()
        {
            var calc = new Calculadora();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                calc.CalcularPrecioFinal(100, 120));
        }

        [Fact]
        public void CompraDe5ProductosCon10Porciento_DeberiaSer450()
        {
            var calc = new Calculadora();
            var resultado = calc.CalcularPrecioConCantidad(100, 5, 10);
            Assert.Equal(450, resultado);
        }

        [Fact]
        public void CantidadInvalida_DeberiaLanzarExcepcion()
        {
            var calc = new Calculadora();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                calc.CalcularPrecioConCantidad(100, 0, 10));
        }

        [Fact]
        public void DescuentoFijo_DeberiaRestarCantidad()
        {
            var calc = new Calculadora();
            var resultado = calc.CalcularPrecioConDescuentoFijo(100, 15);
            Assert.Equal(85, resultado);
        }

        [Fact]
        public void DescuentoTipoClienteVIP_DeberiaAplicar20()
        {
            var calc = new Calculadora();
            var resultado = calc.CalcularPrecioPorTipoCliente(100, "vip");
            Assert.Equal(80, resultado);
        }


    }
}
