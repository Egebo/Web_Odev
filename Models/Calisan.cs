﻿namespace Web_Odev.Models
{
    public class Calisan
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Uzmanlik { get; set; }
        public int KuaforId { get; set; }
        public Kuafor Kuafor { get; set; }
    }
}