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

            jef = new Kok();
            jef.werkMaarOnafhankelijk();
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
    }
}
