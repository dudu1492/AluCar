using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    [Table("Enderecos")]
    public class Endereco
    {
        public Endereco()
        {
            CriadoEm = DateTime.Now;
        }
        [Key]
        public int EnderecoId { get; set; }

        [Display(Name = "Rua:")]
        public string address { get; set; }

        [Display(Name = "CEP:")]
        public string code { get; set; }

        [Display(Name = "Bairro:")]
        public string district { get; set; }

        [Display(Name = "Cidade:")]
        public string city { get; set; }

        [Display(Name = "Estado:")]
        public string state { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
