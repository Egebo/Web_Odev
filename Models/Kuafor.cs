using System.Collections.Generic;

namespace Web_Odev.Models
{
    public class Kuafor
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Adres { get; set; }
        public ICollection<Calisan> Calisanlar { get; set; }
    }
}
