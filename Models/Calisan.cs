using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_Odev.Models
{
    public class Calisan
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Çalışan adı zorunludur.")]
        [Display(Name = "Ad")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Çalışan soyadı zorunludur.")]
        [Display(Name = "Soyad")]
        public string Soyad { get; set; }

        [Display(Name = "Uzmanlık Alanları")]
        public string Uzmanlik { get; set; } // Örneğin: "Saç Kesimi, Boya"

        public virtual ICollection<Randevu> Randevular { get; set; }
    }
}