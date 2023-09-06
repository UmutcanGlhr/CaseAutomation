using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace MarketAutomation
{
    public partial class personelAdd : Form
    {
        public personelAdd()
        {
            InitializeComponent();
            ConnectionClass.baglanti();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="" && textBox2.Text!="")
            {
                string sifre = MD5Hash(textBox2.Text);
                ConnectionClass.Command("insert into personel (name,password) values ('" + textBox1.Text + "','" + sifre + "')");
                MessageBox.Show("Başarıyla yeni kullanıcı oluşturuldu");
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Boş Alan");
            }
           
            
        }

        public static string MD5Hash(string text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] dizi = Encoding.UTF8.GetBytes(text);
            dizi = md5.ComputeHash(dizi);
            StringBuilder sb = new StringBuilder();
            foreach (byte ba in dizi)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }
            return sb.ToString();
        }
    }
}
