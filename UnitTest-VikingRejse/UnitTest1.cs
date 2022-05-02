using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VikingRejseApp;

namespace UnitTest_VikingRejse
{
    [TestClass]
    public class UnitTest1
    {
        RejseFunc func = new RejseFunc();
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            Rejsearrangement rejse = func.NyRejse("Østersøen", "Øresund", new DateTime(2022, 4, 21), new DateTime(2022, 4, 23), 12, 30, "Det bliver godt!");
            Transportører transportør = func.NyTransportører("Jens", "Aalborg", 24544709, "Tjek hans promille");
            Kunder kunde = func.NyKunde("Claus", "Nørreport", 54644701);
            Kunder kunde1 = func.NyKunde("Emil", "Højvænget", 45675530);
            Kunder kunde2 = func.NyKunde("Lau", "Mejlby", 34432300);
            Kunder kunde3 = func.NyKunde("Lars", "Aarhus", 22344400);
            Kunder kunde4 = func.NyKunde("Kasper", "Aalborg", 64708090);
            // Act
            Tilmelding tilmeld = func.NyTilmelding(rejse, kunde);
            Tilmelding tilmeld1 = func.NyTilmelding(rejse, kunde1);
            Tilmelding tilmeld2 = func.NyTilmelding(rejse, kunde2);
            Tilmelding tilmeld3 = func.NyTilmelding(rejse, kunde3);
            Tilmelding tilmeld4 = func.NyTilmelding(rejse, kunde4);
            // Assert
            Assert.AreEqual(5, rejse.counter);
            func.SletTilmeld(tilmeld);
            func.SletTilmeld(tilmeld1);
            func.SletTilmeld(tilmeld2);
            func.SletTilmeld(tilmeld3);
            func.SletTilmeld(tilmeld4);
            func.SletRejse(rejse);
            func.SletKunde(kunde);
            func.SletKunde(kunde1);
            func.SletKunde(kunde2);
            func.SletKunde(kunde3);
            func.SletKunde(kunde4);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SameTele()
        {
            Kunder kunde = func.NyKunde("Claus", "Nørreport", 45675533);
            Kunder kunde1 = func.NyKunde("Emil", "Højvænget", 45675533);
            func.SletKunde(kunde);
            func.SletKunde(kunde1);
        }

    }
}
