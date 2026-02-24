namespace TestesXUnitCobranca.Dominio.Models
{
    public class Cobranca
    {
        public decimal ValorOriginal { get; set; }
        public int DiasAtraso { get; set; }
        public decimal PercentualMulta { get; set; }
        public decimal PercentualJurosDia { get; set; }
        public decimal PercentualMaxDesconto { get; set; }
    }
}