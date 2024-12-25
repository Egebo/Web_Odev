using System.Collections.Generic;

namespace Web_Odev.Models
{
    public class Calisan
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Uzmanlik { get; set; }

        // Çalışanın sunduğu hizmetler
        public ICollection<Hizmet> Hizmetler { get; set; }
    }
}
