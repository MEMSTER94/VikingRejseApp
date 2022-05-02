using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

namespace VikingRejseApp
{
    class TableToObjectConverter
    {
        SqlAccess sqlAccess;

        public TableToObjectConverter(SqlAccess sqlAccess)
        {
            this.sqlAccess = sqlAccess;
        }
        public ObservableCollection<Kunder> GetKunder(DataTable table)
        {
            ObservableCollection<Kunder> liste = new ObservableCollection<Kunder>();
            foreach (DataRow row in table.Rows)
            {
                Kunder kunde = GetKunde(row);
                liste.Add(kunde);
            }
            return liste;
        }
        public ObservableCollection<Transportører> GetTransportør(DataTable table)
        {
            ObservableCollection<Transportører> liste = new ObservableCollection<Transportører>();
            foreach (DataRow row in table.Rows)
            {
                Transportører transportør = GetTransportør(row);
                liste.Add(transportør);
            }
            return liste;
        }
        public ObservableCollection<Rejsearrangement> GetRejser(DataTable table)
        {
            ObservableCollection<Rejsearrangement> liste = new ObservableCollection<Rejsearrangement>();
            foreach (DataRow row in table.Rows)
            {
                Rejsearrangement rejse = GetRejse(row);
                liste.Add(rejse);
            }
            return liste;
        }
        public ObservableCollection<Tilmelding> GetTilmeldinger(DataTable table)
        {
            ObservableCollection<Tilmelding> liste = new ObservableCollection<Tilmelding>();
            foreach (DataRow row in table.Rows)
            {
                Tilmelding tilmelding = GetTilmelding(row);
                liste.Add(tilmelding);
            }
            return liste;
        }
        private Kunder GetKunde(DataRow row)
        {
            Kunder kunde = new Kunder((string)row["navn"], (string)row["adresse"], (int)row["telefon"], (int)row["Id"]);
            return kunde;
        }
        private Rejsearrangement GetRejse(DataRow row)
        {
            Rejsearrangement rejse = new Rejsearrangement((string)row["Titel"], (string)row["By"], (DateTime)row["Startdato"], (DateTime)row["Slutdato"], (decimal)row["Pris"], (int)row["Antal"], (string)row["Beskrivelse"], (int)row["Id"]);
            if (row["TransportørId"].ToString() != "")
            {
                rejse.Transportør = GetTransportør(GetTransportørRow(row["TransportørId"].ToString()));
            }
            return rejse;
        }
        private Transportører GetTransportør(DataRow row)
        {
            Transportører transportør = new Transportører((string)row["Navn"], (string)row["Adresse"], (int)row["Telefon"], (string)row["Bemærkninger"], (int)row["Id"]);
            return transportør;
        }
        private DataRow GetKundeRow(string KundeId)
        {
            return sqlAccess.ExecuteSql($"select * from Kunder where Id = {KundeId}").Rows[0];
        }
        private DataRow GetRejseRow(string RejserId)
        {
            return sqlAccess.ExecuteSql($"select * from Rejser where Id = {RejserId}").Rows[0];
        }
        private DataRow GetTransportørRow(string TransportørId)
        {
            return sqlAccess.ExecuteSql($"select * from Transportører where Id = {TransportørId}").Rows[0];
        }
        private Tilmelding GetTilmelding(DataRow row)
        {
            Tilmelding tilmelding = new Tilmelding((int)row["Id"],
                GetKunde(GetKundeRow(row["KundeId"].ToString())),
                GetRejse(GetRejseRow(row["RejseId"].ToString())));
            return tilmelding;
        }
    }
}
