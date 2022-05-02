using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace VikingRejseApp
{
    public class RejseFunc : INotifyPropertyChanged
    {
        RejseData Data = new RejseData();
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new
                PropertyChangedEventArgs(propName));
            }
        }
        public ObservableCollection<Kunder> Kundeoversigt
        {
            get
            {
                return Data.Kundeoversigt;
            }
        }
        public ObservableCollection<Rejsearrangement> Rejseoversigt
        {
            get
            {
                return Data.Rejseoversigt;
            }
        }
        public ObservableCollection<Tilmelding> Tilmeldingsoversigt
        {
            get
            {
                return Data.Tilmeldingsoversigt;
            }
        }
        public ObservableCollection<Transportører> Transportørsoversigt
        {
            get
            {
                return Data.Transportørsoversigt;
            }
        }
        public Kunder NyKunde(string Navn, string Adresse, int Telefon)
        {
            Kunder kunde = new Kunder(Navn, Adresse, Telefon);
            Data.NyKunde(kunde);
            RaisePropertyChanged("Kundeoversigt");
            return kunde;
        }
        public Transportører NyTransportører(string Navn, string Adresse, int Telefon, string Bemærkninger)
        {
            Transportører transportør = new Transportører( Navn, Adresse, Telefon, Bemærkninger);
            Data.NyTransportør(transportør);
            RaisePropertyChanged("Transportørsoversigt");
            return transportør;
        }
        public Rejsearrangement NyRejse(string Titel, string By, DateTime Startdato, DateTime Slutdato, decimal Pris, int Antal, string Beskrivelse)
        {
            Rejsearrangement rejse = new Rejsearrangement(Titel, By, Startdato, Slutdato, Pris, Antal, Beskrivelse);
            Data.NyRejse(rejse);
            RaisePropertyChanged("Rejseoversigt");
            return rejse;
        }
        public Tilmelding NyTilmelding(Rejsearrangement rejse, Kunder kunde)
        {
            Tilmelding tilmeld = new Tilmelding(0, kunde, rejse);
            Data.NyTilmelding(tilmeld);
            RaisePropertyChanged("Tilmeldingsoversigt");
            return tilmeld;
        }

        public void SletKunde(Kunder kunde)
        {
            Data.SletKunde(kunde);
            RaisePropertyChanged("Kundeoversigt");
        }
        public void SletRejse(Rejsearrangement rejse)
        {
            Data.SletRejse(rejse);
            RaisePropertyChanged("Rejseoversigt");
        }
        public void SletTilmeld(Tilmelding tilmeld)
        {
            Data.SletTilmeld(tilmeld);
            RaisePropertyChanged("Tilmeldingsoversigt");
        }
        public void SletTransportør(Transportører transportør)
        {
            Data.SletTransportør(transportør);
            RaisePropertyChanged("Transportørsoversigt");
        }
        public void TilknytTransportør(Rejsearrangement rejse, Transportører transportør)
        {
            Data.TilknytTransportør(rejse, transportør);
            RaisePropertyChanged("Rejseoversigt");
        }
    }
}
