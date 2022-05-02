using System;
using System.Collections.Generic;
using System.Text;

namespace VikingRejseApp
{
    public class Tilmelding
    {
        public Tilmelding(int Id, Kunder Kunde, Rejsearrangement Rejse)
        {
            this.Id = Id;
            this.Kunde = Kunde;
            this.Rejse = Rejse;
        }
        public int Id { get; set; }
        public Kunder Kunde { get; set; }
        public Rejsearrangement Rejse { get; set; }
    }
}
