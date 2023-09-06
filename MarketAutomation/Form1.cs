using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketAutomation
{
    public partial class Form1 : Form
    {
        public string ad;
        public Form1()
        {
            InitializeComponent();
        }

        private void ürünlerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ürünEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }

        private void tümÜrünleriGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stok stk = new Stok();
            stk.Show();
            this.Hide();
        }

        private void satışİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void prfal(string name)
        {
          ad = name;
          label2.Text = ad;
        }

        private void kasiyerEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            personelAdd add = new personelAdd();
            add.Show();
            this.Hide();
        }
    }
}
