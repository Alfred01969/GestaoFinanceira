using System.ComponentModel.DataAnnotations;

namespace GestaoFinanceira.Models
{
    public class Registro
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "ID Tipo de Conta")]
        public int IdConta { get; set; }

        public int Valor { get; set; }

        public DateTime Data { get; set; }

        //[Required]
        //public 

        //public Registro() { }





    }
}
