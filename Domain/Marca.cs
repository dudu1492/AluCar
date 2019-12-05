using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("Marcas")]
    public class Marca
    {
        public Marca()
        {

        }

        [Key]
        public int MarcaId { get; set; }

        [Display(Name = "Nome da Marca:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Nome { get; set; }

        [Display(Name = "Detalhes da Marca:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Detalhes { get; set; }

        public override string ToString()
        {
            return "Nome: " + Nome;
        }
    }
}