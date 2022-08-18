using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace binbin
{
    public class musteri
    {

        public bool Kontrol(string deneme,string deneme2)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=AHMET\\SQLEXPRESS01;Initial Catalog=Kitaplik;Integrated Security=True");
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select *from binbinMusteri where mail='" + deneme + "'or kadi='" + deneme2+ "'", baglanti);
            SqlDataReader oku = cmd.ExecuteReader();
            if (oku.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
            oku.Close();
            baglanti.Close();

        }



        public   List<musteri>musteriler=new List<musteri>();




     
        private string _ad;
        private string _soyad;
        private DateTime _dogum;
        private string _sehir;
        private string _mail;
        private string _sifre;
        private string _kadi;

        public string ad
        {
            get { return _ad; }



            set {
                if (value == "")
                {

                }
                else
                {
                    _ad = value;
                }
            }
        }
        public string soyad
        {
            get
            {
                return _soyad;      
            }
            set
            {
                _soyad = value;
            }
        }
        public DateTime dogum
        {
            get
            {
                return _dogum;           
            }
            set
            {
               if(DateTime.Now.Year-value.Year<18)
                {
                  
                }
                else
                {
                    _dogum= value;  
                }
            }
        }
        public string sehir
        {
            get
            {
                return _sehir;
            }
            set
            {
                _sehir = value;  
            }
        }
       
        public string mail
        {

            get
            {
                return _mail;
            }
            set {
               
                    _mail = value;
                  
            }

        }

        public string sifre
        {
            get
            {
                return _sifre;
            }
            set {
            _sifre= value;  
            
            }
        }
        public string kadi
        {
            get
            {
                return _kadi;   
            }
            set
            {
                _kadi = value;   
            }
        }


    }
}
