using System;
using System.ComponentModel.DataAnnotations;

namespace Web_Odev.Models
{
    public class Randevu
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Randevu tarihi zorunludur.")]
        [Display(Name = "Tarih")]
        [DataType(DataType.Date)]
        public DateTime Tarih { get; set; }

        [Required(ErrorMessage = "Randevu saati zorunludur.")]
        [Display(Name = "Saat")]
        [DataType(DataType.Time)]
        public TimeSpan Saat { get; set; } // Sadece saati tutmak için TimeSpan kullandım.

        [Display(Name = "Durum")]
        public string Durum { get; set; } // Örn: "Onaylandı", "Beklemede", "Tamamlandı", "İptal Edildi"

        // İlişkiler
        public int CalisanId { get; set; }
        public virtual Calisan Calisan { get; set; }

        public int HizmetId { get; set; }
        public virtual Hizmet Hizmet { get; set; }

        public int KullaniciId { get; set; }
        public virtual Kullanici Kullanici { get; set; }
    }
}