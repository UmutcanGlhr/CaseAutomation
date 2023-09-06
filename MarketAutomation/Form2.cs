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
            ConnectionClass.baglanti();
            ConnectionClass.Command("insert into product () values ()");
        }
    }
}
