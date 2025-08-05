using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Descuentos.Core;
using System.Runtime.InteropServices.Marshalling;


namespace Descuentos.Tests
{
    public class CalculadoraDescuentosTests
    {
        [Fact(DisplayName = "Debe aplicar descuento correctamente")]
        public void AplicarDescuento_CasoNormal()
        {
            // Arrange
            var calc = new CalculadoraDescuentos();
            decimal precio = 100m;
            decimal porcentaje = 20;

            // Act
            decimal resultado = calc.AplicarDescuento(precio, porcentaje);

            // Assert
            Assert.Equal(80m, resultado);
        }

        [Theory(DisplayName = "Debe lanzar excepción si porcentaje es inválido")]
        [InlineData(-5)]
        [InlineData(150)]
        public void AplicarDescuento_PorcentajeInvalido(decimal porcentaje)
        {
            var calc = new CalculadoraDescuentos();

            Assert.Throws<ArgumentException>(() => calc.AplicarDescuento(100m, porcentaje));
        }

        [Fact(DisplayName = "Debe lanzar excepción si precio es negativo")]
        public void AplicarDescuento_PrecioNegativo()
        {
            var calc = new CalculadoraDescuentos();

            Assert.Throws<ArgumentException>(() => calc.AplicarDescuento(-100m, 10));
        }
    }



    // Esta clase contiene pruebas unitarias para la clase Calculadora.
    public class CalculadoraTests
    {
        // Prueba que un descuento del 10% sobre 100 dé como resultado 90.
        [Fact]
        public void DescuentoDel10_DeberiaDevolver90()
        {
            var calc = new Calculadora(); // Instancia de la clase Calculadora
            var resultado = calc.CalcularPrecioFinal(100, 10); // Aplica 10% de descuento
            Assert.Equal(90, resultado); // Verifica que el resultado sea 90
        }

        // Prueba que un porcentaje de descuento mayor a 100 lance una excepción.
        [Fact]
        public void DescuentoMayorA100_DeberiaLanzarExcepcion()
        {
            var calc = new Calculadora();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                calc.CalcularPrecioFinal(100, 120)); // 120% no es válido
        }

        // Prueba que comprar 5 productos de 100 con 10% de descuento dé 450.
        [Fact]
        public void CompraDe5ProductosCon10Porciento_DeberiaSer450()
        {
            var calc = new Calculadora();
            var resultado = calc.CalcularPrecioConCantidad(100, 5, 10); // 100 * 5 = 500 - 10% = 450
            Assert.Equal(450, resultado);
        }

        // Prueba que pasar una cantidad inválida (0) lance una excepción.
        [Fact]
        public void CantidadInvalida_DeberiaLanzarExcepcion()
        {
            var calc = new Calculadora();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                calc.CalcularPrecioConCantidad(100, 0, 10)); // Cantidad 0 no es válida
        }

        // Prueba que se reste correctamente un descuento fijo del precio original.
        [Fact]
        public void DescuentoFijo_DeberiaRestarCantidad()
        {
            var calc = new Calculadora();
            var resultado = calc.CalcularPrecioConDescuentoFijo(100, 15); // 100 - 15 = 85
            Assert.Equal(85, resultado);
        }

        // Prueba que al tipo de cliente "vip" se le aplique 20% de descuento.
        [Fact]
        public void DescuentoTipoClienteVIP_DeberiaAplicar20()
        {
            var calc = new Calculadora();
            var resultado = calc.CalcularPrecioPorTipoCliente(100, "vip"); // 100 - 20% = 80
            Assert.Equal(80, resultado);
        }
    }
}
