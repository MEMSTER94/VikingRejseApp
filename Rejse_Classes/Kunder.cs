using System;
using System.Collections.Generic;
using System.Text;

namespace VikingRejseApp
{
    public class Kunder
    {
        public Kunder(string Navn, string Adresse, int Telefon, int Id = 0)
        {
            this.Navn = Navn;
            this.Adresse = Adresse;
            this.Telefon = Telefon;
            this.Id = Id;
        }
        public string Navn { get; set; }
        public string Adresse { get; set; }
        public int Telefon { get; set; }
        public int Id { get; set; }
    }
}
