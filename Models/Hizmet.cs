using System.ComponentModel.DataAnnotations;

namespace Web_Odev.Models
{
    public class Hizmet
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Hizmet adı zorunludur.")]
        [Display(Name = "Hizmet Adı")]
        public string Ad { get; set; }

        [Display(Name = "Ücret")]
        public double Ucret { get; set; }

    }
}