using System;
using System.Collections.Generic;
using System.Text;

namespace VikingRejseApp
{
    public class Transportører
    {
        public Transportører(string Navn, string Adresse, int Telefon, string Bemærkninger, int Id=0)
        {
            this.Id = Id;
            this.Navn = Navn;
            this.Adresse = Adresse;
            this.Telefon = Telefon;
            this.Bemærkninger = Bemærkninger;
        }
        public int Id { get; set; }
        public string Navn { get; set; }
        public string Adresse { get; set; }
        public int Telefon { get; set; }
        public string Bemærkninger { get; set; }
    }
}
