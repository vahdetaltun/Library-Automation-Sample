using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kütüphane
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void kitapları_listele_ayar()
        {
            dataGridView1.Columns[0].HeaderText = "Sıralama";
            dataGridView1.Columns[1].HeaderText = "Barkod No";
            dataGridView1.Columns[2].HeaderText = "Kitap Adı";
            dataGridView1.Columns[3].HeaderText = "Yazar Adı";
            dataGridView1.Columns[4].HeaderText = "Yayın Evi";
            dataGridView1.Columns[5].HeaderText = "Kitap Türü";
            dataGridView1.Columns[6].HeaderText = "Stok";
            dataGridView1.Columns[7].HeaderText = "Alınan Tarih";
            dataGridView1.Columns[8].HeaderText = "Güncelleme Tarihi";
          //dataGridView1.Columns[6].HeaderText = "Kitap Konu";
          //dataGridView1.Columns[7].HeaderText = "Baskı Yeri";
          //dataGridView1.Columns[8].HeaderText = "Baskı Sayısı";
          //dataGridView1.Columns[9].HeaderText = "Baskı Tarihi";
           

            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 85;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 79;
           // dataGridView1.Columns[8].Width = 120; 
           // dataGridView1.Columns[8].Width = 85;
           // dataGridView1.Columns[10].Width = 50;
        }
        
        public void okuyucu_listesi_ayar()
        {
           
            dataGridView1.Columns[0].HeaderText = "Sıralama";
            dataGridView1.Columns[1].HeaderText = "Adı - Soyadı";
            dataGridView1.Columns[2].HeaderText = "TCKimlikNo";
            dataGridView1.Columns[3].HeaderText = "Telefon";
            dataGridView1.Columns[4].HeaderText = "Adres";
            dataGridView1.Columns[5].HeaderText = "Cinsiyet";
            dataGridView1.Columns[6].HeaderText = "DoğumTarihi";
            dataGridView1.Columns[7].HeaderText = "KayıtTarihi";
           
         // dataGridView1.Columns[4].HeaderText = "BarkodNo";
       
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].Width = 75;
            dataGridView1.Columns[6].Width = 120;
            dataGridView1.Columns[7].Width = 90;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            test = "basıldı";
            //kitaplar tablosunu çek.
            dataGridView1.DataSource = Slave.BringData("SELECT * FROM kitaplar ORDER BY ID ASC");
            kitapları_listele_ayar();
     
        }

        private void button2_Click(object sender, EventArgs e)
        {   // okuyucular tablosunu çek.
           dataGridView1.DataSource = Slave.BringData("SELECT * FROM okuyucu_ekle ORDER BY lib_id ASC");
           okuyucu_listesi_ayar();
        }

        private void button6_Click(object sender, EventArgs e)
        {
          

            

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public static int secim; // Global bir degisken update icin.

        string test = null; // Test degişkeni kitap seçmeden nasıl güncellicen sorusunun cevabıdır.Bunun için degisken ayarladık
       
        private void button10_Click(object sender, EventArgs e)
        {

            if (test == "basıldı")
            {
                //Burada dataGrid'de tıklanan Id'yi Kitap_guncelleye gönderir.
                secim = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
                kullanici_giris2 giris = new kullanici_giris2();
                giris.ShowDialog();
                //this.Hide();                
            }
            else
            {
                MessageBox.Show("Güncellemek için ilk olarak kitap seçiniz.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            
           
          
           

                   
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = Slave.BringData("SELECT KITAP_ADI,BARKOD_NO FROM KITAPLAR WHERE ID=" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value + "");
            label2.Text = dt.Rows[0]["BARKOD_NO"].ToString();
            label3.Text = dt.Rows[0]["KITAP_ADI"].ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button11_Click(object sender, EventArgs e)
        {
            kullanici_giris giris = new kullanici_giris();
            giris.ShowDialog();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kullanici_giris4 giris = new kullanici_giris4();
            giris.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            kullanici_giris3 giris = new kullanici_giris3();
            giris.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            emanet_ver emanet = new emanet_ver();
            emanet.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                /* dataGridView1.DataSource = Slave.BringData(@"SELECT lib_name_surname,Kitap_Adi,date FROM okuyucu_ekle,kitaplar,emanet_kitaplar
                                                           WHERE lib_id = em_oku_id AND em_kitp_id = ID");*/
                dataGridView1.DataSource = Slave.BringData(@"SELECT lib_name_surname,Kitap_Adi,DATEDIFF(CURRENT_DATE(),e_date) FROM emanet_kitap, okuyucu_ekle,kitaplar
                                                        WHERE lib_id = e_oku_id AND e_kit_id = ID");

                //Sütun ayarları........
                dataGridView1.Columns[0].HeaderText = "Adı Soyadı";
                dataGridView1.Columns[1].HeaderText = "Kitap İsmi";
                dataGridView1.Columns[2].HeaderText = "Geçen Gün Sayısı";

                dataGridView1.Columns[0].Width = 170;
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].Width = 150;
            }
            catch
            {
                MessageBox.Show("Bir Hata Oluştu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            emanet_ver emanet = new emanet_ver();
            emanet.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
