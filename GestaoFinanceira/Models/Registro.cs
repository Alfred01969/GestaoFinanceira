using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoFinanceira.Models
{
    public class Registro
    {
        public int Id { get; set; }

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int RegistroId { get; set; }

        [Display(Name = "valor despesa")]
        public int Valor { get; set; }

        public DateTime Data { get; set; }

        public int TipoId { get; set; }

        public Tipo? Tipo { get; set; }

        //[Required]
        //public 

        //public Registro() { }





    }
}
