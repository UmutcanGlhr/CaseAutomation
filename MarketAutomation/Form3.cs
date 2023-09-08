using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
namespace MarketAutomation
{
    public partial class Form3 : Form
    {
        DataTable tablo = new DataTable();
        public Form3()
        {
            InitializeComponent();
            ConnectionClass.baglanti();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                object name = ConnectionClass.Command("select ProductName from product where BarkodNo = '" + textBox1.Text + "'");
                object sales = ConnectionClass.Command("select sales from product where BarkodNo = '" + textBox1.Text + "'");
                string productname = Convert.ToString(name);
                double fiyat = Convert.ToDouble(sales);
                tablo.Rows.Add(productname, fiyat);
                dataGridView1.DataSource = tablo;
            }
            else
            {
                MessageBox.Show("boş alan");
            }
           
        }
        private void Form3_Load(object sender, EventArgs e)
        {

            tablo.Columns.Add("ürün adı", typeof(string));
            tablo.Columns.Add("ürün fiyatı", typeof(double));
            dataGridView1.DataSource = tablo;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            double toplam = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
            }
            label4.Text = toplam.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] fatura = new string[dataGridView1.Rows.Count];
            for (int i = 1; i < dataGridView1.Rows.Count; ++i)
            {
                string ad = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
                string fiyat = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                string result = ad + " " + fiyat;
                fatura[i] = result;       
            }
            iTextSharp.text.Document faturam = new iTextSharp.text.Document();
            PdfWriter.GetInstance(faturam, new FileStream("C:Fatura2.pdf", FileMode.Create));
            faturam.AddAuthor("sdas");
            faturam.AddCreationDate();
            faturam.AddCreator("sadas");
            faturam.AddSubject("sadas");
            faturam.AddKeywords("safdasdfas");
            if (faturam.IsOpen() == false)
            {
                faturam.Open();
            }
            faturam.Add(new Paragraph(fatura.ToString));// burda hata var 
            faturam.Close();

        }
    }
}
