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

namespace _202503024__Mercan_Esen_
{
    public partial class formmusteri : Form
    {
        public formmusteri()
        {
            InitializeComponent();
        }
        public string sqlsorgu = ("Server=localhost\\SQLEXPRESS;Initial Catalog = 202503024; Integrated Security = True");
        SqlConnection baglanti;
        private void button1_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into table_musteri (musteri_ad,musteri_soyad,musteri_mail,musteri_telefon,musteri_tipi) values (@p1,@p2,@p3,@p4,@p5)", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox10.Text);
            komut.Parameters.AddWithValue("@p2", textBox9.Text);
            komut.Parameters.AddWithValue("@p3", textBox8.Text);
            komut.Parameters.AddWithValue("@p4", textBox7.Text);
            komut.Parameters.AddWithValue("@p5", comboBox2.Text);
          
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Eklendi");
            bilgi_getir2();        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
           
        {
           
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("update table_musteri set musteri_ad=@a1,musteri_soyad=@a2,musteri_mail=@a3,musteri_telefon=@a4,musteri_tipi=@a5 where musteri_id=@a6", baglanti);
            komutguncelle.Parameters.AddWithValue("@a1", textBox4.Text);
            komutguncelle.Parameters.AddWithValue("@a2", textBox3.Text);
            komutguncelle.Parameters.AddWithValue("@a3", textBox2.Text);
            komutguncelle.Parameters.AddWithValue("@a4", textBox1.Text);
            komutguncelle.Parameters.AddWithValue("@a5", comboBox1.Text);
            komutguncelle.Parameters.AddWithValue("@a6", textBox5.Text);

           
            komutguncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Bilgisi Güncellendi");
            bilgi_getir3();

        }
        public void bilgi_getir1()
        {


            baglanti = new SqlConnection(sqlsorgu);
            baglanti.Open();

            SqlDataAdapter dr = new SqlDataAdapter("select * from table_musteri", baglanti);

            DataSet ds = new DataSet();

            dr.Fill(ds, "table_musteri");

            dataGridView1.DataSource = ds.Tables["table_musteri"];
            baglanti.Close();

        }
        public void bilgi_getir2()
        {
            baglanti = new SqlConnection(sqlsorgu);
            baglanti.Open();

            SqlDataAdapter dr = new SqlDataAdapter("select * from table_musteri", baglanti);

            DataSet ds = new DataSet();

            dr.Fill(ds, "table_musteri");

            dataGridView2.DataSource = ds.Tables["table_musteri"];
            baglanti.Close();
        }
        public void bilgi_getir3()
        {
            baglanti = new SqlConnection(sqlsorgu);
            baglanti.Open();

            SqlDataAdapter dr = new SqlDataAdapter("select * from table_musteri", baglanti);

            DataSet ds = new DataSet();

            dr.Fill(ds, "table_musteri");

            dataGridView3.DataSource = ds.Tables["table_musteri"];
            baglanti.Close();
        }

        private void formmusteri_Load(object sender, EventArgs e)
        {
            
            bilgi_getir2();
             bilgi_getir3();
            bilgi_getir1();



        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            baglanti = new SqlConnection(sqlsorgu);

            baglanti.Open();

            SqlCommand komutsil = new SqlCommand("delete from table_musteri where musteri_id=@k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1", label1.Text);

            komutsil.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Kayıt Silindi");
            bilgi_getir1();            
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }
        
        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
          

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
           

        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            textBox4.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
            textBox1.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString();
            comboBox1.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            label1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

            

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        SqlConnection con;
        SqlDataAdapter da;
        SqlDataReader dr;
        SqlCommand cmd;
        DataSet ds;
        public string SqlCon = "Server=localhost\\SQLEXPRESS;Initial Catalog = 202503024; Integrated Security = True";

        private void button2_Click_1(object sender, EventArgs e)
        {
            if(eskisifrekontrol())
            {
                if (textBox11.Text == textBox6.Text)
                {
                  if(frmlogin.giren_kullanici=="Danışman Girişi")
                    {
                        SqlConnection baglanti = new SqlConnection(SqlCon);
                        baglanti.Open();

                        SqlCommand cmd = new SqlCommand("update tbl_login set danisman_sifre=@p3 where danisman_ad=@p4", baglanti);
                        
                        cmd.Parameters.AddWithValue("@p4", frmlogin.danisman_ad_tut);
                        cmd.Parameters.AddWithValue("@p3", md5_şifreleme.MD5sifrele(textBox11.Text));

                        cmd.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Şifreniz Başarıyla Güncellendi");
                    }
                  else if(frmlogin.giren_kullanici=="Yönetici Girişi")

                    {
                        SqlConnection baglanti = new SqlConnection(SqlCon);
                        baglanti.Open();

                        SqlCommand cmd = new SqlCommand("update tbl_login set musteri_sifre=@p3 where musteri_ad=@p4", baglanti);

                        cmd.Parameters.AddWithValue("@p4", frmlogin.musteri_ad_tut);
                        cmd.Parameters.AddWithValue("@p3", md5_şifreleme.MD5sifrele(textBox11.Text));

                        cmd.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Şifreniz Başarıyla Güncellendi");

                    }      

                }
                else
                {
                    MessageBox.Show("Şifre tekrarı hatalı");
                }
            }
            else
            {
                MessageBox.Show("Eski şifrenizi hatalı girdiniz");
            }

        }
        public bool eskisifrekontrol()
        {
            

            if (frmlogin.giren_kullanici == "Danışman Girişi")
            {
                con = new SqlConnection(SqlCon);
                cmd = new SqlCommand("select * from tbl_login where danisman_ad=@user1 and danisman_sifre=@pass1", con);
                cmd.Parameters.AddWithValue("@user1", frmlogin.danisman_ad_tut);
                cmd.Parameters.AddWithValue("@pass1", md5_şifreleme.MD5sifrele(textBox12.Text));
                con.Open();

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    con.Close();
                    return true;
                    
                }
                else
                {
                    con.Close();
                    return false;
                    
                }
                
            }
            else if(frmlogin.giren_kullanici=="Yönetici Girişi")
            {
                con = new SqlConnection(SqlCon);
                cmd = new SqlCommand("select * from tbl_login where musteri_ad=@user2 and musteri_sifre=@pass2", con);
               
                cmd.Parameters.AddWithValue("@user2", frmlogin.musteri_ad_tut);
                cmd.Parameters.AddWithValue("@pass2", md5_şifreleme.MD5sifrele(textBox12.Text));

                con.Open();

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    con.Close();
                    return true;
                }
                else
                {
                    con.Close();
                    return false;
                }
            }
            return false;

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }
        void gridDoldur(string sql)
        {
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter(sql, con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "table_musteri");
            dataGridView2.DataSource = ds.Tables["table_musteri"];
            con.Close();

        }
        public string sqlsorgu2;

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                //isme göre
                sqlsorgu2="select * from table_musteri where musteri_ad like '%"+ textBox13.Text +"%'";
                gridDoldur(sqlsorgu2);
            }
            else if (radioButton2.Checked)
            {
                sqlsorgu2 = "select * from table_musteri where musteri_telefon like '%" + textBox13.Text + "%'";
                gridDoldur(sqlsorgu2);
             

            }
        }
    }
}
