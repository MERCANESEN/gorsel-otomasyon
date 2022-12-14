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
    public partial class frmlogin : Form
    {
        
        public frmlogin()
        {
        InitializeComponent();
     
    }
        

        SqlConnection baglanti = new SqlConnection("Server=localhost\\SQLEXPRESS;Initial Catalog = 202503024; Integrated Security = True");
        public int sonuc = 0;
        public static string musteri_ad_tut;
        public static string danisman_ad_tut;
        public static string giren_kullanici;
        private void button1_Click(object sender, EventArgs e)
        {
          
            
            if (comboBox1.SelectedIndex == 0)
            {
                giren_kullanici = comboBox1.Text;
                if (textBox3.Text == sonuc.ToString())
                {
                    
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("Select * From tbl_login where (danisman_ad=@p1 and danisman_sifre=@p2)", baglanti);
                    komut.Parameters.AddWithValue("@p1", textBox1.Text);
                    komut.Parameters.AddWithValue("@p2", md5_şifreleme.MD5sifrele(textBox2.Text));
                    danisman_ad_tut = textBox1.Text;
                    
                    SqlDataReader dr = komut.ExecuteReader();


                    if (dr.Read())
                    {
                        MessageBox.Show("Giriş Başarılı.");
                        baglanti.Close();
                        formmusteri formmusteri = new formmusteri();
                        this.Hide();
                        formmusteri.Show();

                    }
                    else
                    {
                        MessageBox.Show("Ad veya Şifre Hatalı...");
                        baglanti.Close();

                    }
                }
                else
                {
                    label5.Visible = true;
                    label5.Text = "İşleminiz Hatalı !!";
                    
                }
                
            }
            else if(comboBox1 .SelectedIndex ==1)
            {
                giren_kullanici = comboBox1.Text;
                if (textBox3.Text == sonuc.ToString())
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("Select * From tbl_login where (musteri_ad=@p1 and musteri_sifre=@p2)", baglanti);
                    komut.Parameters.AddWithValue("@p1", textBox1.Text);
                    komut.Parameters.AddWithValue("@p2", md5_şifreleme.MD5sifrele(textBox2.Text));
                    musteri_ad_tut = textBox1.Text;
                    SqlDataReader dr = komut.ExecuteReader();


                    if (dr.Read())
                    {
                        baglanti.Close();
                        MessageBox.Show("Giriş Başarılı.");
                        formmusteri formmusteri = new formmusteri();
                        this.Hide();
                        formmusteri.Show();

                    }
                    else
                    {
                        baglanti.Close();
                        MessageBox.Show("Ad veya Şifre Hatalı...");


                    }
                }
                else
                {
                    label5.Visible = true;
                    label5.Text = "İşleminiz Hatalı !!";
                    
                }

            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            şifre_değiştir fr2 = new şifre_değiştir();
            fr2.ShowDialog();

        }

        private void frmlogin_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            int ilk = r.Next(0, 10);
            int ikinci = r.Next(0, 50);
            sonuc = ilk + ikinci;

            label4.Text = ilk.ToString ()+ "+" + ikinci.ToString();

           

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            basvurualım fr2 = new basvurualım();
            fr2.ShowDialog();
        }
    }
    }
    

