using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObserverUnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObserverUnitTest.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void MustHave_Kok_handelt_bijgekomen_bestellingen_binnen_voorziene_tijd_af_Zonder_observer()
        {
            // -Maak een lege bestellijst
            Form1 form = new Form1();

            // Ik probeer er eerst zeker van te zijn dat de kok aan het indommelen is.
            Assert.AreEqual(0, form.hoeveelBestellingenZijnEr());
            Assert.AreEqual("dromen...", form.getStatusKok());

            // Testen mislukt als de GUI geupdate wordt:
            //      Invoke of BeginInvoke kan niet op een besturingselement worden aangeroepen tot de vensterkoppeling is gemaakt.
            //      Zorg er dus voor dat je kunt testen zonder GUI (!!)
            //          Vieze work-around: zet het denken van de kok af
            form.disableKokThinking();

            //- Zet er meerdere producten in en je WEET zelf de tijd die nodig is
            form.voegProductToe("steak met curry saus"); // Is de langste van 8 seconden
            form.voegProductToe("dame blanche"); // Een korte van 5 seconden
            Assert.AreEqual(2, form.hoeveelBestellingenZijnEr());

            // Foute test: moet verschillend van dromen zijn bij ECHTE observer..
            Assert.AreEqual("dromen...", form.getStatusKok()); 

            // Foute actie: Druk op de knop (bij ECHTE observer is deze stap niet nodig)
            form.pictureBox4_Click(null, null);

            //- Wacht voor een verwachtte tijd
            // Eerste manier: test thread laat ik 13s slapen
            // Tweede manier: ik wacht tot mijn systeem klok zegt dat er 13 s voorbij zijn
            long timestamp = Environment.TickCount + 13000;

           while(Environment.TickCount < timestamp)
            {
                // wacht wacht wacht
            }

            //-Is mijn bestellijst leeg ?
            int aantal = form.hoeveelBestellingenZijnEr();

            Assert.AreEqual(0, aantal); // Test je test: als je Click wegneemt, faalt je test dan?
        }
    }
}