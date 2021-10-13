using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

 
namespace kafe_otomasyonu
{
    public partial class Form2 : Form
    {
        int []fiyat = new int[16];
        int adet=1;
        int tutar = 0;
        int i=0;
        string a;
        public int ID;
        public int siparisID;

       
        
        public Form2()
        {
            this.AutoSize = true;
            InitializeComponent();
           
        }

        /*baglanti= new SqlConnection("Data Source = DESKTOP - 1CGIG1C; Initial Catalog = kafe; Integrated Security = True");*/
        SqlConnection baglanti = new SqlConnection("Server=DESKTOP-1CGIG1C;Database=kafe;Integrated Security=True");
        SqlCommand komut = new SqlCommand();
        SqlDataAdapter da;
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            a=comboBox1.SelectedIndex.ToString();


           /* int index = comboref.Items.IndexOf("string");*/
        }

        private void Form2_Load(object sender, EventArgs e)
        {


            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from menu", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
               
                comboBox1.Items.Add(read["urunad"]);
                fiyat[i] = Convert.ToInt32(read["fiyat"]);
                i++;
                
            }
            baglanti.Close();
            comboBox1.SelectedIndex = 0;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
             adet = Convert.ToInt32(comboBox2.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int d = Convert.ToInt32(a);
            tutar =tutar+fiyat[d] * adet;
            textBox1.Text = Convert.ToString(tutar);
   
         baglanti.Open();
        string sorgu2 = "INSERT INTO  siparis (musteriID,urunistek,adet,siparistutar,menuID) VALUES (@musteriID,@urunistek,@adet,@siparistutar,@menuID)";
            komut = new SqlCommand(sorgu2, baglanti);
            
            komut.Parameters.AddWithValue("@musteriID",textBox2.Text);
            komut.Parameters.AddWithValue("@urunistek", comboBox1.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@adet", comboBox2.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@siparistutar", textBox1.Text.ToString());
            komut.Parameters.AddWithValue("@menuID", 1);

            komut.ExecuteNonQuery();
            komut.Parameters.Clear();
            baglanti.Close();
           /* if (f == 1)
            {
                MessageBox.Show("EKLENDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("EKLENEMEDİ", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */


            siparislerigoster();


        }
        private void siparislerigoster() 
        {

            SqlConnection baglanti = new SqlConnection("Server=DESKTOP-1CGIG1C;Database=kafe;Integrated Security=True");
            baglanti.Open();
            /*da = new SqlDataAdapter("Select *From siparis", baglanti);*/
            da = new SqlDataAdapter("select *from musteri m ,siparis s where s.musteriID=m.ID", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();

            /*baglanti.Open();
            da = new SqlDataAdapter("select *from musteri m ,siparis s where s.musteriID,=m.musteriID", baglanti);
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
            */
        }

         void siparissil(int siparisID)
        {
            
            string sql = "DELETE FROM siparis WHERE siparisID=@siparisID";
            baglanti.Open();
            komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@siparisID", siparisID);
            komut.ExecuteNonQuery();
            baglanti.Close();

            
        }
        void musterisil(int ID)
        {
            string sql = "DELETE FROM musteri WHERE ID=@ID";
            baglanti.Open();
            komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@ID", ID);
            komut.ExecuteNonQuery();
            baglanti.Close();
            siparissil(siparisID);

        }
      

        private string ToString(string v)
        {
            throw new NotImplementedException();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
             ID = Convert.ToInt32(textBox2.Text);
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

       /* private void button2_Click(object sender, EventArgs e)
        {
           

        }*/

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  
            {
                siparisID = Convert.ToInt32(drow.Cells[0].Value);
                siparissil(siparisID);

            }

            Form1.bakiye += tutar;

                musterisil(ID);


            MessageBox.Show("HESAP ÖDENDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

           
                

            this.Close();

        }

        

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            /*textBox3.Text = Form1.masano.ToString();*/
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu1 = "INSERT INTO  musteri(ID,musteriad) VALUES (@ID,@musteriad)";
            komut = new SqlCommand(sorgu1, baglanti);

            komut.Parameters.AddWithValue("@ID", textBox2.Text);
            komut.Parameters.AddWithValue("@musteriad",textBox4.Text);

           
            komut.ExecuteNonQuery();

            baglanti.Close();
            
        }
    }
}
