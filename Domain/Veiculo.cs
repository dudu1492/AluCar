using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    [Table("Veiculos")]
    public class Veiculo
    {
        public Veiculo()
        {
            CriadoEm = DateTime.Now;
            Quilometragem = 0;
            Alugado = false;
            Manutencao = false;
            ProxManut = 30000;
        }

        [Key]
        public int VeiculoId { get; set; }

        [Display(Name = "Nome do Veiculo:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Nome { get; set; }

        [Display(Name = "Placa do Veiculo:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Placa { get; set; }

        [Display(Name = "Ano do Veiculo:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public int Ano { get; set; }
        public DateTime CriadoEm { get; set; }

        [Display(Name = "Marca do Veiculo:")]
        public Marca Marca { get; set; }
        public int Quilometragem { get; set; }

        [Display(Name = "Potência do Veiculo (cv):")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public int Potencia { get; set; }

        [Display(Name = "Valor do Veiculo para aluguel:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public double? Valor { get; set; }
        public bool Alugado { get; set; }
        public bool Manutencao { get; set; }
        public int ProxManut { get; set; }
        public string Imagem { get; set; }
        
        public override string ToString()
        {
            return "Nome: " + Nome + " | Placa: " + Placa + " | Ano: " + Ano + " | Marca: " + Marca.Nome;
        }
        
    }
}
