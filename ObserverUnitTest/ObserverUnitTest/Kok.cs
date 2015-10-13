using System;
using System.Threading;

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

        public Kok()
        {

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

        private void doIets(object data)
        {
            while (true)
            {
                if (watBenIkAanhetDoen == status_bezig_met_bestelling)
                {
                    // Afhankelijk van het type gerecht, ga ik langer of
                    // korter hieraan werken.
                }

                Console.WriteLine("Genoeg gewerkt, ik wacht tot er nog eens iets gebeurt...");

                signaalWaaropIkWacht.WaitOne();
                Console.WriteLine("Belletje rinkelt...");
            }
        }
    }
}