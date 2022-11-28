using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GestaoFinanceira.Models
{
    public class Tipo
    {
        public int TipoId { get; set; }

        [Required]
        [Display(Name = "Tipo de Conta")]
        public string? Nome { get; set; }

        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        //public virtual ICollection<SelectListItem> Tipoes { get; set; }




    }
}
