using TestesXUnitCobranca.Models;

namespace TestesXUnitCobranca.Servicos
{
    public class CalculadoraCobranca
    {
        public decimal CalcularMulta(Cobranca cobranca)
        {
            if (cobranca.DiasAtraso <= 0)
                return 0;

            return cobranca.ValorOriginal * cobranca.PercentualMulta / 100;
        }

        public decimal CalcularJuros(Cobranca cobranca)
        {
            if (cobranca.DiasAtraso <= 0)
                return 0;

            return cobranca.ValorOriginal * cobranca.PercentualJurosDia / 100 * cobranca.DiasAtraso;
        }

        public decimal AplicarDesconto(decimal valorAtual, decimal percentualDesconto)
        {
            if (percentualDesconto < 0)
                throw new ArgumentException("Desconto inválido");

            return valorAtual - (valorAtual * percentualDesconto / 100);
        }

        public decimal CalcularValorAtualizado(Cobranca cobranca)
        {
            var multa = CalcularMulta(cobranca);
            var juros = CalcularJuros(cobranca);

            return cobranca.ValorOriginal + multa + juros;
        }
    }
}