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
    public partial class anaEkran : Form
    {
        public anaEkran()
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true;
        }
        public string mesaj;
        SqlConnection baglanti = new SqlConnection("Data Source=AHMET\\SQLEXPRESS01;Initial Catalog=Kitaplik;Integrated Security=True");

        private void anaEkran_Load(object sender, EventArgs e)
        {
            Form1 a = new Form1();
        
            
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Select * from binbinMusteri where kadi='" + mesaj + "'", baglanti);
            SqlDataReader oku = cmd.ExecuteReader();
            while(oku.Read())
                {
                string ag = oku["isim"].ToString()+oku["soyisim"].ToString();
                label8.Text = ag;
            }
            oku.Close();

            SqlCommand h = new SqlCommand("Select * from binbinBilgiler",baglanti);
            SqlDataReader h1 = h.ExecuteReader();
            
            while(h1.Read())
            {
                comboBox1.Items.Add(h1["binbinId"].ToString());
                    
            }

            h1.Close();
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder adres = new StringBuilder();
            string cadde = textBox7.Text;
            string sehir = textBox8.Text;
            
            adres.Append("http://google.com/maps?q=");
            if(cadde !=string.Empty)
            {
                adres.Append(cadde + "," + "+");
            }
            if (sehir != string.Empty)
            {
                adres.Append(sehir + "," + "+");
            }
          
            webBrowser1.Navigate(adres.ToString());
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
       
          
            }

        private void button3_Click(object sender, EventArgs e)
        {
            bilgi  bilgiForm=new bilgi();
            bilgiForm.gelen = mesaj;
            bilgiForm.Show();
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
           
           
            Form1 kayitEkran = new Form1();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete  from binbinMusteri where kadi='" + mesaj + "'",baglanti);
            komut.ExecuteNonQuery();
            
            baglanti.Close();
            this.Hide();

            kayitEkran.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            musteriKart musteri = new musteriKart();
            musteri.kartIsim = textBox1.Text;
            musteri.kartNumara = textBox2.Text;
            musteri.kartSkt = textBox3.Text + "/" + textBox4.Text;
            musteri.kartCvv = int.Parse(textBox5.Text);

            SqlCommand komut = new SqlCommand("insert into musteriKartBilgi (kartIsim,kartNo,kartSkt,kartCvv,musteriId) values (@p1,@p2,@p3,@p4,@p5)", baglanti);
            komut.Parameters.AddWithValue("@p1", musteri.kartIsim);
            komut.Parameters.AddWithValue("@p2", musteri.kartNumara);
            komut.Parameters.AddWithValue("@p3", musteri.kartSkt);
            komut.Parameters.AddWithValue("@p4", musteri.kartCvv);
            SqlCommand k4 = new SqlCommand("Select *from binbinMusteri where kadi=@o8",baglanti);
            
            k4.Parameters.AddWithValue("@o8", mesaj);
            SqlDataReader oku = k4.ExecuteReader();
            while(oku.Read())
            {
                string y = oku["id"].ToString();
                komut.Parameters.AddWithValue("@p5", int.Parse(y));
            }
            oku.Close();
            komut.ExecuteNonQuery();


            baglanti.Close();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Select * from binbinBilgiler where binbinId='" + comboBox1.SelectedItem + "'",baglanti);
            SqlDataReader oku = cmd.ExecuteReader();
            while(oku.Read())
            {
                label18.Text = oku["sarj"].ToString();
                label19.Text = oku["fiyat"].ToString();
                label20.Text = oku["ortalamaHiz"].ToString();

            }
            oku.Close();
            baglanti.Close();
            


        }
        
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            float ucret;
            ucret = 1.50f +float.Parse(label19.Text) * float.Parse(textBox6.Text);
            label13.Text= ucret.ToString(); 
        }
    }
}
