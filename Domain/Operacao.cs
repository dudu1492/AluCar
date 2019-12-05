using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("Operação")]
    public class Operacao
    {
        public Operacao()
        {
            DataInicial = DateTime.Now;
        }

        [Key]
        public int OperacaoId { get; set; }

        [Display(Name = "Veiculo:")]
        public Veiculo Veiculo { get; set; }

        [Display(Name = "Funcionario:")]
        public Funcionario Funcionario { get; set; }

        [Display(Name = "Cliente:")]
        public Cliente Cliente { get; set; }

        [Display(Name = "Data Inicial:")]
        public DateTime DataInicial { get; set; }

        [Display(Name = "Data Prevista:")]
        public DateTime DataPrevista { get; set; }

        [Display(Name = "Data Final:")]
        public string DataFinal { get; set; }

        [Display(Name = "Obs:")]
        public string Obs { get; set; }

        [Display(Name = "KmRodado:")]
        public int KmRodado { get; set; }

        [Display(Name = "Valor Esperado:")]
        public double ValorEsperado { get; set; }

        [Display(Name = "Valor Juros:")]
        public double ValorJuros { get; set; }

        [Display(Name = "Valor Pago:")]
        public double ValorPago { get; set; }
        public bool Finalizado { get; set; }

        public override string ToString()
        {
            return "OperacaoId: " + OperacaoId;
        }

    }
}