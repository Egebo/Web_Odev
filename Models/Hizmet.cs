namespace Web_Odev.Models
{
    public class Hizmet
    {
        public int Id { get; set; }
        public string Ad { get; set; } // Hizmet adı (ör. Saç Kesimi)
        public decimal Ucret { get; set; } // Hizmet ücreti

        public int CalisanId { get; set; }
        public Calisan Calisan { get; set; }
    }
}
