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

            jef = new Kok(bestelwachtlijst, this);
            jef.werkMaarVerderOnafhankelijk();
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
        internal void kokDenkt(string v)
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
                this.textBox1.AppendText("\r\n"+v);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.statuskok.Text = jef.watBenJeAanHetDoen();
        }
    }
}
