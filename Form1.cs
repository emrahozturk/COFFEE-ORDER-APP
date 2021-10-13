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
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.AutoSize = true;
            InitializeComponent();
            goster();
        }
        public class masa 
        {
            public static int masano { get; set; }
        }

        
        public static int  bakiye=0;

        SqlConnection baglanti = new SqlConnection("Server=DESKTOP-1CGIG1C;Database=kafe;Integrated Security=True");
        SqlCommand komut;
        private void Form1_Load(object sender, EventArgs e)
        {
            goster();
            
        }

        private void goster()
        {
            baglanti.Open();
            string sorgu = "Select * from menu";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();

            baglanti.Open();
            string sorgu2 = "Select * from siparis";
            SqlDataAdapter dr = new SqlDataAdapter(sorgu2, baglanti);
            DataTable ds = new DataTable();
            dr.Fill(ds);
            dataGridView2.DataSource = ds;
            baglanti.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            masa.masano = 1;
            Form2 yenisayfa = new Form2();
            yenisayfa.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            masa.masano = 2;
            Form2 yenisayfa = new Form2();
            yenisayfa.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            masa.masano = 3;
            Form2 yenisayfa = new Form2();
            yenisayfa.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
           masa.masano = 4;
            Form2 yenisayfa = new Form2();
            yenisayfa.Show();
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            masa.masano = 5;
            Form2 yenisayfa = new Form2();
            yenisayfa.Show();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            masa.masano = 6;
            Form2 yenisayfa = new Form2();
            yenisayfa.Show();
         
        }

        private void button7_Click(object sender, EventArgs e)
        {
            masa.masano = 7;
            Form2 yenisayfa = new Form2();
            yenisayfa.Show();
       
        }

        
        private void button8_Click(object sender, EventArgs e)
        {
            masa.masano = 8;   
            Form2 yenisayfa = new Form2();
            yenisayfa.Show();
         
        }

        private void button9_Click(object sender, EventArgs e)
        {
            masa.masano = 9;
            Form2 yenisayfa = new Form2();
            yenisayfa.Show();
           
        }

        private void button10_Click(object sender, EventArgs e)
        {
            masa.masano = 10;
            Form2 yenisayfa = new Form2();
            yenisayfa.Show();
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            masa.masano = 11;
            Form2 yenisayfa = new Form2();
            yenisayfa.Show();
          
        }

        private void button12_Click(object sender, EventArgs e)
        {
            masa.masano = 12;
            Form2 yenisayfa = new Form2();
            yenisayfa.Show();
          
        }

        
       
        
        private void siparissil(int siparisID)
        {
            string sql = "DELETE FROM siparis WHERE siparisID=@siparisID";
            komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@siparisID",siparisID);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            goster();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView2.SelectedRows)  //Seçili Satırları Silme
            {
                int siparisID = Convert.ToInt32(drow.Cells[0].Value);
                siparissil(siparisID);         
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            goster();
        }
    }
}
