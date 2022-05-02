using System;
using System.Collections.Generic;
using System.Text;

namespace VikingRejseApp
{
    public class Rejsearrangement
    {
        public Rejsearrangement(string Titel, string By, DateTime Startdato, DateTime Slutdato, decimal Pris, int Antal, string Beskrivelse, int Id=0)
        {
            this.Titel = Titel;
            this.By = By;
            this.Startdato = Startdato;
            this.Slutdato = Slutdato;
            this.Pris = Pris;
            this.Antal = Antal;
            this.Beskrivelse = Beskrivelse;
            this.Id = Id;
        }

        //public static RejseData RejseData { private get; set; }

        public string Titel { get; set; }
        public string By { get; set; }
        public DateTime Startdato { get; set; }
        public DateTime Slutdato { get; set; }
        public decimal Pris { get; set; }
        public int Antal { get; set; }
        public string Beskrivelse { get; set; }
        public int Id { get; set; }
        public int counter
        {
            get
            {
                int counter = 0;
                //foreach(Tilmelding tilmelding in RejseData.Tilmeldingsoversigt)
                //{
                //    if (tilmelding.Rejse.Id == Id)
                //    {

                //        counter++;
                //    }
                //}
                return counter;
            }
        }
        public Transportører Transportør { get; set; }
    }
}
