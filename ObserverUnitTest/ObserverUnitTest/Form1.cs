using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObserverUnitTest
{
    public partial class Form1 : Form
    {
        private Kok jef;

        public Form1()
        {
            InitializeComponent();
            startKok();
           
        }

        internal void updateStatus(string v)
        {
            statuskok.Text = v;
        }

        private void bestellinggeplaatst_Click(object sender, EventArgs e)
        {
            bestelwachtlijst.Items.Add(comboBox1.SelectedItem);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.statuskok.Text = jef.watBenJeAanHetDoen();
        }

        delegate void SetVerwijderBestellingCallback(int i);
        internal void kokIsMetBestellingBezig(int v)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (bestelwachtlijst.InvokeRequired)
            {
                SetVerwijderBestellingCallback d = new SetVerwijderBestellingCallback(kokIsMetBestellingBezig);
                this.Invoke(d, new object[] { v });
            }
            else
            {
                bestelwachtlijst.Items.RemoveAt(v);
            }
        }

        delegate void SetTextboxCallback(String extragedachte);

        int lines = 0;
        Boolean magDenken = true;
        internal void kokDenkt(string v)
        {
            if (magDenken)
            {
                // InvokeRequired required compares the thread ID of the
                // calling thread to the thread ID of the creating thread.
                // If these threads are different, it returns true.
                if (textBox1.InvokeRequired)
                {
                    SetTextboxCallback d = new SetTextboxCallback(kokDenkt);
                    this.Invoke(d, new object[] { v });
                }
                else
                {
                    this.textBox1.AppendText("\r\n" + v);
                }
            }
        }

        public void pictureBox4_Click(object sender, EventArgs e)
        {
            this.statuskok.Text = jef.watBenJeAanHetDoen();
        }


        /**
        * De single responsibility van onze applicatie is nog niet in orde.
        *
        *   Er is geen scheiding tussen het beheren van de bestellingen en de weergave van de bestellingen
        *
        *   Beter zou zijn om een nieuwe klasse te maken die de bestellingen beheert, 
        *   en de GUI die deze inhoud uitleest en weergeeft.
        */
        public int hoeveelBestellingenZijnEr()
        {
            return this.bestelwachtlijst.Items.Count;
        }
        
        public void voegProductToe(string v)
        {
            this.bestelwachtlijst.Items.Add(v);
        }
        public String getStatusKok()
        {
            return jef.getStatus();
        }

        public void disableKokThinking()
        {
            magDenken = false;
        }

        public void startKok()
        {
            if (jef == null) // Not thread safe!
            {
                jef = new Kok(bestelwachtlijst, this);
                jef.werkMaarVerderOnafhankelijk();
            }
        }
    }
}
