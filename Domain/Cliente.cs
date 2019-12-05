﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Cliente")]
    public class Cliente
    {
        public Cliente()
        {
            CriadoEm = DateTime.Now;
        }

        [Key]
        public int ClienteId { get; set; }

        [Display(Name = "Nome do Cliente:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Nome { get; set; }

        [Display(Name = "CPF do Cliente:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string CPF { get; set; }

        [Display(Name = "E-mail:")]
        [EmailAddress]
        public string Email { get; set; }


        [Display(Name = "Senha:")]
        public string Senha { get; set; }

        [Display(Name = "Confirmação da senha:")]
        [NotMapped]
        [Compare("Senha", ErrorMessage = "Os campos não coincidem!")]
        public string ConfirmacaoSenha { get; set; }

        public Endereco Endereco { get; set; }
        public DateTime CriadoEm { get; set; }

        public override string ToString()
        {
            return "Nome: " + Nome + " | Endereço: " + Endereco + " | CPF: " + CPF + " | E-mail " + Email;
        }
    }
}
