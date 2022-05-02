using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.Text;

namespace VikingRejseApp
{
    public class RejseData
    {
        SqlAccess sqlAccess = new SqlAccess();
        TableToObjectConverter converter;
        public RejseData()
        {
            sqlAccess = new SqlAccess();
            converter = new TableToObjectConverter(sqlAccess);
            //Rejsearrangement.RejseData = this;
        }
        public ObservableCollection<Kunder> Kundeoversigt
        {
            get
            {
                return converter.GetKunder(sqlAccess.ExecuteSql("select * from Kunder"));
            }
        }
        public ObservableCollection<Rejsearrangement> Rejseoversigt
        {
            get
            {
                return converter.GetRejser(sqlAccess.ExecuteSql("select * from Rejser"));
            }
        }
        public ObservableCollection<Tilmelding> Tilmeldingsoversigt
        {
            get
            {
                return converter.GetTilmeldinger(sqlAccess.ExecuteSql("select * from Tilmelding"));
            }
        }
        public ObservableCollection<Transportører> Transportørsoversigt
        {
            get
            {
                return converter.GetTransportør(sqlAccess.ExecuteSql("select * from Transportører"));
            }
        }
        public void NyKunde(Kunder kunde)
        {
            foreach(Kunder k in Kundeoversigt)
            {
                if(k.Telefon == kunde.Telefon)
                {
                    throw new Exception("Der er allerede en kunder med dette telefon nummer");
                }
            }
            sqlAccess.ExecuteSql($"insert into Kunder (navn, adresse, telefon) values ('{kunde.Navn}', '{kunde.Adresse}', '{kunde.Telefon}')");
            // Find det sidste Id der er blevet oprettet og tilføj det til kunden.
            kunde.Id = (int) sqlAccess.ExecuteSql("select Max(Id) from Kunder").Rows[0].ItemArray[0];
        }
        public void NyTransportør(Transportører transportør)
        {
            sqlAccess.ExecuteSql($"insert into Transportører (Navn, Adresse, Telefon, Bemærkninger) values ('{transportør.Navn}', '{transportør.Adresse}', '{transportør.Telefon}', '{transportør.Bemærkninger}')");
            transportør.Id = (int)sqlAccess.ExecuteSql("select Max(Id) from Transportører").Rows[0].ItemArray[0];
        }
        public void SletKunde(Kunder kunde)
        {
            sqlAccess.ExecuteSql($"Delete from Kunder where Id={kunde.Id}");
        }

        public void NyRejse(Rejsearrangement rejse)
        {
            sqlAccess.ExecuteSql($"insert into Rejser (Titel, [By], Startdato, Slutdato, Pris, Antal, Beskrivelse) values ('{rejse.Titel}', '{rejse.By}', '{rejse.Startdato.ToString(CultureInfo.InvariantCulture)}', '{rejse.Slutdato.ToString(CultureInfo.InvariantCulture)}', {rejse.Pris}, {rejse.Antal}, '{rejse.Beskrivelse}')");
            rejse.Id = (int)sqlAccess.ExecuteSql("select Max(Id) from Rejser").Rows[0].ItemArray[0];
        }
        public void SletRejse(Rejsearrangement rejse)
        {
            sqlAccess.ExecuteSql($"Delete from Rejser where Id={rejse.Id}");
        }
        public void NyTilmelding(Tilmelding tilmeld)
        {
            sqlAccess.ExecuteSql($"insert into Tilmelding (RejseId, KundeId) values ('{tilmeld.Rejse.Id}', '{tilmeld.Kunde.Id}')");
            tilmeld.Id = (int)sqlAccess.ExecuteSql("select Max(Id) from Tilmelding").Rows[0].ItemArray[0];
        }
        public void SletTilmeld(Tilmelding tilmeld)
        {
            sqlAccess.ExecuteSql($"Delete from Tilmelding where Id={tilmeld.Id}");
        }
        public void SletTransportør(Transportører transportør)
        {
            sqlAccess.ExecuteSql($"Delete from Transportører where Id={transportør.Id}");
        }
        public void TilknytTransportør(Rejsearrangement rejse, Transportører transportør)
        {
            sqlAccess.ExecuteSql($"Update [Rejser] set TransportørId = {transportør.Id} where {rejse.Id} = Id");
            rejse.Transportør = transportør;
        }
    }
}
