using System.ComponentModel.DataAnnotations;

namespace Stiven_Santana_P1_AP1.Modelo
{
    public class Aportes
    {
        [Key]

        [Required(ErrorMessage ="Este campo es requerido.")]
        public int AporteId { get; set; }

        [Required(ErrorMessage ="Este campo es requerido.")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage ="Este campo es requerido.")]
        public string Persona { get; set; }

        [Required(ErrorMessage ="Este campo es requerido.")]
        public string Observacion { get; set; }

        [Required(ErrorMessage ="Este campo es requerido.")]
        public decimal Monto { get; set; }


    }
}
