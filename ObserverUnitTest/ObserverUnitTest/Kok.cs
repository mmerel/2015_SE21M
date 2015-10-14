using System;
using System.Threading;
using System.Windows.Forms;

namespace ObserverUnitTest
{
    internal class Kok
    {
        System.Threading.Thread newThread;
        
        static String status_bezig_met_bestelling = "bezig met bestelling";
        static String status_niets = "dromen...";

        String watBenIkAanhetDoen = "juist begonnen...";

        // An AutoReset event that allows the main thread to block
        // until an exiting thread has decremented the count.
        //
        private static EventWaitHandle signaalWaaropIkWacht =
            new EventWaitHandle(false, EventResetMode.AutoReset);
        private ListBox bestelwachtlijst;

        private Form1 form1;

        public Kok()
        {

        }

        public Kok(ListBox bestelwachtlijst)
        {
            this.bestelwachtlijst = bestelwachtlijst;
        }

        public Kok(ListBox bestelwachtlijst, Form1 form1) : this(bestelwachtlijst)
        {
            this.form1 = form1;
        }

        public String watBenJeAanHetDoen()
        {
            form1.kokDenkt("Iemand roept wat ik aan het doen ben...");
            werkMaarVerderOnafhankelijk();

            return watBenIkAanhetDoen;
        }

        internal void werkMaarVerderOnafhankelijk()
        {
            if (newThread == null)
            {
                newThread =
                    new Thread(new ParameterizedThreadStart(doIets));
                newThread.Start();
            }

            if(newThread.ThreadState != ThreadState.Running )
            {
                signaalWaaropIkWacht.Set();
            }
        }

        // This method demonstrates a pattern for making thread-safe
        // calls on a Windows Forms control. 
        //
        // If the calling thread is different from the thread that
        // created the TextBox control, this method creates a
        // SetTextCallback and calls itself asynchronously using the
        // Invoke method.
        //
        // If the calling thread is the same as the thread that created
        // the TextBox control, the Text property is set directly. 

        private void IkBehandelDeVolgendeBestelling(int b)
        {
            form1.kokIsMetBestellingBezig(b);
        }

        private void doIets(object data)
        {
            while (true)
            {
                if (watBenIkAanhetDoen == "juist begonnen..." || watBenIkAanhetDoen == status_niets)
                {
                    form1.kokDenkt("Staat er me iets te doen op het lijstje?");

                    if (bestelwachtlijst.Items.Count > 0)
                    {
                        watBenIkAanhetDoen = bestelwachtlijst.Items[0].ToString();
                        IkBehandelDeVolgendeBestelling(0);
                    } else
                    {
                        form1.kokDenkt("Genoeg gewerkt, ik wacht tot iemand me wakker maakt...");
                        watBenIkAanhetDoen = status_niets;
                        signaalWaaropIkWacht.WaitOne();
                    }
                }

                // Afhankelijk van het type gerecht, ga ik langer of
                // korter hieraan werken.
                if (watBenIkAanhetDoen.Equals("appelmoes met frietjes"))
                {
                    doe("appelmoes met frietjes", 1000);
                }

                if (watBenIkAanhetDoen.Equals("dame blanche"))
                {
                    doe("dame blanche", 5000);
                }

                if (watBenIkAanhetDoen.Equals("steak met curry saus"))
                {
                    doe("steak met curry saus", 8000);
                }
            }
        }

        internal string getStatus()
        {
            return this.watBenIkAanhetDoen;
        }

        private void doe(string werk, int tijd)
        {
            form1.kokDenkt("Even beginnen aan " + werk + " te maken. Ben ik weer "+ (tijd/1000) + "s mee bezig.");
            watBenIkAanhetDoen = werk+" te maken";
            Thread.Sleep(tijd); // Ik werk hier 10 seconden aan...
            watBenIkAanhetDoen = status_niets;
        }
    }

   
}