using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace MarketAutomation
{
    public partial class Form2 : Form
    {
          
        MySqlConnection con = new MySqlConnection(@"Server=localhost;Database=Market;Uid=root;Pwd='';");
        
        public Form2()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 frm = new Form1();
            frm.Show();
        }

       
        private void Form2_Load(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("Select * from kategoriler",con);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["CategoryName"]);
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!=""&& textBox2.Text != "" && textBox3.Text != "" && textBox5.Text != "" && textBox6.Text != "" )
            {
                string BarkodNo = textBox1.Text;
                string productName = textBox2.Text;
                string category = comboBox1.Text;
                string skt = Convert.ToString(dateTimePicker1.Value);
                string buying = textBox5.Text;
                string sales = textBox6.Text;
                string kdv = textBox3.Text;
                ConnectionClass.baglanti();
                ConnectionClass.Command("insert into product (BarkodNo,ProductName,SKT,buying,sales,kdv,category) values ('" + BarkodNo + "','" + productName + "','" + skt + "','" + buying + "','" + sales + "','" + kdv + "','" + category + "')");
                MessageBox.Show("kayıt başarılı");
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox5.Text = string.Empty;
                textBox6.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("eksik alan");
            }
            
        }
    }
}
