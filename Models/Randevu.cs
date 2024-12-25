namespace Web_Odev.Models
{
    public class Randevu
    {
        public int Id { get; set; }
        public int CalisanId { get; set; }
        public string MusteriAd { get; set; }
        public string MusteriEmail { get; set; }
        public DateTime Tarih { get; set; }
        public string Saat { get; set; }
        public string Hizmet { get; set; }
        public bool Onaylandi { get; set; } = false;
        public decimal Ucret { get; set; } // Ücret alanı eklendi

        public Calisan Calisan { get; set; }
    }
}
