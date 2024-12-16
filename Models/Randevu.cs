using System;
using Web_Odev.Models;

namespace Web_Odev.Models
{
    public class Randevu
    {
        public int Id { get; set; }
        public DateTime Tarih { get; set; }
        public string Islem { get; set; }
        public decimal Ucret { get; set; }
        public int CalisanId { get; set; }
        public Calisan Calisan { get; set; }
    }
}
