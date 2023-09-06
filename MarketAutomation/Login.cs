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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            try
            {
                ConnectionClass.baglanti();
                
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text !="" && textBox2.Text !="")
            {
                
                object result =  ConnectionClass.Command("Select name from personel Where name ='"+textBox1.Text+"'AND password ='"+textBox2.Text+"'");
                if (result != null)
                {
                    string name = Convert.ToString(result);
                    Form1 frm = new Form1();
                    frm.Show();
                    frm.prfal(textBox1.Text);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kişi Bulunamadı");
                }
            }
            else
            {
                MessageBox.Show("Eksik veya Hatalı giriş");
            }

           

            
        }
    }
}
