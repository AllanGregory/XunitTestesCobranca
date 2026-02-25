using TestesXUnitCobranca.Models;
using TestesXUnitCobranca.Servicos;

namespace TextesXUnitCobranca.Tests
{
    public class CalculadoraCobrancaTests
    {
        private readonly CalculadoraCobranca _calc = new();

        [Fact]
        public void NaoDeveAplicarMultaSemAtraso()
        {
            var cobranca = new Cobranca
            {
                ValorOriginal = 100,
                DiasAtraso = 0,
                PercentualMulta = 2
            };

            var multa = _calc.CalcularMulta(cobranca);

            Assert.Equal(0, multa);
        }

        [Theory]
        [InlineData(100, 2, 2)] //valor, atraso, multa
        [InlineData(200, 2, 4)]
        [InlineData(350, 2, 7)]
        public void DeveCalcularMultaCorretamente(decimal valor, int dias, decimal multaEsperada)
        {
            var cobranca = new Cobranca
            {
                ValorOriginal = valor,
                DiasAtraso = dias,
                PercentualMulta = 2
            };

            var multa = _calc.CalcularMulta(cobranca);

            Assert.Equal(multaEsperada, multa);
        }

        [Theory]
        [InlineData(100, 1, 1, 1)]
        [InlineData(100, 10, 1, 10)]
        [InlineData(250, 2, 1, 5)]
        public void DeveCalcularJurosCorretamente(decimal valor, int dias, decimal jurosDia, decimal esperado)
        {
            var cobranca = new Cobranca
            {
                ValorOriginal = valor,
                DiasAtraso = dias,
                PercentualJurosDia = jurosDia
            };

            var juros = _calc.CalcularJuros(cobranca);

            Assert.Equal(esperado, juros);
        }

        [Fact]
        public void DeveAplicarDesconto()
        {
            var valor = _calc.AplicarDesconto(100, 10);

            Assert.Equal(90, valor);
        }

        [Fact]
        public void DeveLancarErroParaDescontoNegativo()
        {
            Assert.Throws<ArgumentException>(() => _calc.AplicarDesconto(100, -5));
        }

        [Fact]
        public void DeveAplicarMultaQuandoHouverAtraso()
        {
            var cobranca = new Cobranca
            {
                ValorOriginal = 100,
                DiasAtraso = 5,
                PercentualMulta = 2
            };

            var multa = _calc.CalcularMulta(cobranca);

            Assert.Equal(2, multa);
        }

        [Fact]
        public void NaoDeveGerarJurosQuandoDiasAtrasoForZero()
        {
            var cobranca = new Cobranca
            {
                ValorOriginal = 100,
                DiasAtraso = 0,
                PercentualJurosDia = 1
            };

            var juros = _calc.CalcularJuros(cobranca);

            Assert.Equal(0, juros);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void NaoDeveAceitarValorNegativo(decimal valor)
        {
            Assert.Throws<ArgumentException>(() => _calc.AplicarDesconto(valor, 10));
        }

        [Fact]
        public void DeveLancarErroQuandoDescontoForNegativo()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                _calc.AplicarDesconto(100, -10));

            Assert.Equal("Desconto inválido", ex.Message);
        }

        [Theory]
        [InlineData(100, 10, 90)]
        [InlineData(200, 10, 180)]
        [InlineData(350, 20, 280)]
        public void DeveAplicarDescontoCorretamente(decimal valor, decimal desconto, decimal esperado)
        {
            var resultado = _calc.AplicarDesconto(valor, desconto);

            Assert.Equal(esperado, resultado);
        }

        [Fact]
        public void ValorFinalNuncaDeveSerNegativo()
        {
            var resultado = _calc.AplicarDesconto(100, 200);

            Assert.True(resultado >= 0);
        }

        [Fact]
        public void DeveArredondarParaDuasCasasDecimais()
        {
            var valor = _calc.AplicarDesconto(100.555m, 0);

            Assert.Equal(100.56m, valor);
        }
    }
}
