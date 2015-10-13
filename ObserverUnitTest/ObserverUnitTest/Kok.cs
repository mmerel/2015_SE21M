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

        String watBenIkAanhetDoen = status_niets;

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
            Console.WriteLine("Iemand roept wat ik aan het doen ben...");
            werkMaarOnafhankelijk();

            return watBenIkAanhetDoen;
        }

        internal void werkMaarOnafhankelijk()
        {
            if (newThread == null)
            {
                newThread =
                    new Thread(new ParameterizedThreadStart(doIets));
                newThread.Start();
            }

            if(newThread.ThreadState != ThreadState.Running )
            {
                Console.WriteLine("Ik ga  kijken of ik iets kan doen...");
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
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (bestelwachtlijst.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(IkBehandelDeVolgendeBestelling);
                form1.Invoke(d, new object[] { b });
            }
            else
            {
                bestelwachtlijst.Items.RemoveAt(b);
            }
        }

        private void doIets(object data)
        {
            while (true)
            {
                if (watBenIkAanhetDoen == status_niets)
                {
                    Console.WriteLine("Staat er me iets te doen op het lijstje?");

                    if (bestelwachtlijst.Items.Count > 0)
                    {
                        watBenIkAanhetDoen = bestelwachtlijst.Items[0].ToString();
                        IkBehandelDeVolgendeBestelling(0);
                    } else
                    {
                        Console.WriteLine("Genoeg gewerkt, ik wacht tot iemand me wakker maakt...");
                        watBenIkAanhetDoen = status_niets;
                        signaalWaaropIkWacht.WaitOne();
                    }
                }

                // Afhankelijk van het type gerecht, ga ik langer of
                // korter hieraan werken.
                if (watBenIkAanhetDoen == "appelmoes met frietjes")
                {
                    watBenIkAanhetDoen = "appelmoes met frietjes te maken";
                    Thread.Sleep(10000); // Ik werk hier 10 seconden aan...
                    watBenIkAanhetDoen = status_niets;
                }

                if (watBenIkAanhetDoen == "dame blanche")
                {
                    watBenIkAanhetDoen = "een dame blanche te maken";
                    Thread.Sleep(20000); // Ik werk hier 20 seconden aan...
                    watBenIkAanhetDoen = status_niets;
                }

                if (watBenIkAanhetDoen == "steak met curry saus")
                {
                    watBenIkAanhetDoen = "een steak met curry saus te maken";
                    Thread.Sleep(30000); // Ik werk hier 30 seconden aan...
                    watBenIkAanhetDoen = status_niets;
                }
            }
        }
    }

    delegate void SetTextCallback(int i);
}