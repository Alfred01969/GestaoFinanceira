using System.ComponentModel.DataAnnotations;

namespace GestaoFinanceira.Models
{
    public class Tipo
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tipo de Conta")]
        public string? Nome { get; set; }

        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        

    }
}
