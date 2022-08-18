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
using System.Net;
using System.Net.Mail;


namespace binbin
{
    public partial class kayit : Form
    {
        private bool sifreKontrol(string a,string b)
        {
         if(a==b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public kayit()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=AHMET\\SQLEXPRESS01;Initial Catalog=Kitaplik;Integrated Security=True");
        public List<musteri> musteriler = new List<musteri>();   
        private void button1_Click(object sender, EventArgs e)
        {
            bool kontrol = true;
            musteri temp = new musteri();
            baglanti.Open();

            SqlCommand komut = new SqlCommand("insert into binbinMusteri (isim,soyisim,dogumYil,sehir,mail,sifre,kadi) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)", baglanti);
            
            temp.ad = textBox1.Text;
            temp.soyad = textBox2.Text;
            temp.dogum = dateTimePicker1.Value;
            temp.sehir = comboBox1.Text;
            temp.sifre = textBox4.Text;
            
            SqlCommand k1 = new SqlCommand();
            k1.Connection = baglanti;
            k1.CommandText = "select mail from binbinMusteri where mail=@o1";
            k1.Parameters.AddWithValue("@o1", textBox3.Text);
            SqlDataReader read = k1.ExecuteReader();
            if (read.Read())
            {
                MessageBox.Show("Mail zaten var");
                kontrol = false;
               
            }
            else
            {
               
                    temp.mail = textBox3.Text;
                    kontrol = true;

                
            }
            read.Close();



            SqlCommand k2 = new SqlCommand("select kadi from binbinMusteri where kadi=@o2",baglanti);
            k2.Parameters.AddWithValue("@o2", textBox6.Text);
            SqlDataReader read2 = k2.ExecuteReader();
           

            if(read2.Read())
            {
                MessageBox.Show("Kullancı adı zaten kayıtlı");
                kontrol = false;
              
            }
            else
            {
               
                    temp.kadi = textBox6.Text;
                    kontrol = true;
                
            }
            read2.Close();


            if(!sifreKontrol(textBox5.Text,textBox4.Text))
            {
                kontrol= false;
                label9.Text = "Şifreler uyuşmuyor";
            }
            if (kontrol == true)
            {
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.Parameters.AddWithValue("@p2", textBox2.Text);
                komut.Parameters.AddWithValue("@p3", dateTimePicker1.Value);
                komut.Parameters.AddWithValue("@p4", comboBox1.Text);
                komut.Parameters.AddWithValue("@p5", textBox3.Text);
                komut.Parameters.AddWithValue("@p6", textBox4.Text);
                komut.Parameters.AddWithValue("@p7", textBox6.Text);

                musteriler.Add(temp);
               

                komut.ExecuteNonQuery();

                baglanti.Close();
                MessageBox.Show("Kayıt Oluştu");


            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 giris = new Form1();
            this.Hide();
            giris.Show();
            
        }
    }
}
