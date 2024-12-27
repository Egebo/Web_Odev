using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_Odev.Models
{
    public class Kuaför
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kuaför adı zorunludur.")]
        [Display(Name = "Kuaför Adı")]
        public string Ad { get; set; }

        [Display(Name = "Adres")]
        public string Adres { get; set; }

        [Display(Name = "Çalışma Saatleri")]
        public string CalismaSaatleri { get; set; }

        // İlişkiler
        public virtual ICollection<Calisan> Calisanlar { get; set; }
        public virtual ICollection<Hizmet> Hizmetler { get; set; }
    }
}