using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace binbin
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string bilgi = "";



        private void button1_Click(object sender, EventArgs e)
        {
            kayit frm = new kayit();
            this.Hide();
            frm.Show();

        }
        public string bilgi2 = "";

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=AHMET\\SQLEXPRESS01;Initial Catalog=Kitaplik;Integrated Security=True");

            baglanti.Open();

            SqlCommand cmd = new SqlCommand("select kadi from binbinMusteri where kadi='" + textBox1.Text + "'and sifre='" + textBox2.Text + "'", baglanti);
            SqlDataReader read = cmd.ExecuteReader();
            if(read.Read())
            {
                anaEkran a = new anaEkran();

                a.mesaj = textBox1.Text;

                a.Show();

                this.Hide();
               
                read.Close();
                
                baglanti.Close();

    }
            else
            {
                MessageBox.Show("Girilen bilgilere uygun kayıt bulunamadı");

            }

            baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox1.BackColor = Color.FromArgb(30, 204, 212, 230);
        }
    }
}
