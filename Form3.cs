using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kafe_otomasyonu
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Server=DESKTOP-1CGIG1C;Database=kafe;Integrated Security=True");
        
       

        private void Form3_Load(object sender, EventArgs e)
        {
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ka = textBox1.Text;
            string sifre = textBox2.Text;
            baglanti.Open();
           
            string sql = "select *from  kullanici where kullaniciadi=@kullaniciadi and sifre=@sifre";
            SqlCommand komut = new SqlCommand(sql,baglanti);
            
            komut.Parameters.Add(new SqlParameter("@kullaniciadi", ka));
            komut.Parameters.Add(new SqlParameter("@sifre", sifre));

            SqlDataReader reader = komut.ExecuteReader();
            if (reader.Read())
            {

                MessageBox.Show("KASA : " +Form1.bakiye +" TL ");

                

            }
            else
            {
                MessageBox.Show("Hatalı giriş yapıldı !!");
            }
           
            baglanti.Close();

            
        }
    }
}
