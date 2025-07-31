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
    }
}
