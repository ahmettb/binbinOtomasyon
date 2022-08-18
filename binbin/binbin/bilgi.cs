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
    public partial class bilgi : Form
    {
        public bilgi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=AHMET\\SQLEXPRESS01;Initial Catalog=Kitaplik;Integrated Security=True");
        public string gelen;
        private void bilgi_Load(object sender, EventArgs e)
        {
            textBox8.Enabled = false;
            baglanti.Open();

            SqlCommand komut = new SqlCommand("Select * from binbinMusteri where kadi=@p5", baglanti);
            komut.Parameters.AddWithValue("@p5", gelen);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())

            {

                textBox1.Text = oku["isim"].ToString();
                textBox2.Text = oku["soyisim"].ToString();
                textBox3.Text = oku["dogumYil"].ToString();
                textBox4.Text = oku["sehir"].ToString();
                textBox5.Text = oku["mail"].ToString();
                textBox6.Text = oku["kadi"].ToString();
                textBox7.Text = oku["sifre"].ToString();
                textBox8.Text = oku["id"].ToString();
            }
            oku.Close();

            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            musteri temp = new musteri();
            if (temp.Kontrol(textBox5.Text,textBox6.Text))
            {
                MessageBox.Show("Kayıtlı bilgi var");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("update binbinMusteri set isim=@p1,soyisim=@p2,dogumYil=@p3,sehir=@p4,mail=@p5,sifre=@p6,kadi=@p7 where kadi=@p19", baglanti);
                cmd.Parameters.AddWithValue("@p19", gelen);

                cmd.Parameters.AddWithValue("@p1", textBox1.Text);
                cmd.Parameters.AddWithValue("@p2", textBox2.Text);

                cmd.Parameters.AddWithValue("@p3", DateTime.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@p4", textBox4.Text);
                cmd.Parameters.AddWithValue("@p5", textBox5.Text);
                cmd.Parameters.AddWithValue("@p6", textBox6.Text);
                cmd.Parameters.AddWithValue("@p7", textBox7.Text);
                cmd.ExecuteNonQuery();
            }

            baglanti.Close();
        }
    }
}
