using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace kütüphane
{
    public partial class kitap_guncelle : Form
    {
        public kitap_guncelle()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            try
            {
                string sql = @"UPDATE kitaplar SET Barkod_No='" + textBox1.Text + "', Kitap_Adi='" + textBox2.Text + @"', 
                Yazar_Adi='" + textBox3.Text + "', Yayin_Evi='" + textBox4.Text + "', Kitap_Turu='" + textBox5.Text + @"', 
                Stok=" + Convert.ToInt32(textBox6.Text) + ",Güncellenen_tarih='"+DateTime.Now+"' WHERE ID=" + Form1.secim + "";
                Slave.SendData(sql);
                MessageBox.Show("Başarıyla Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch 
            {
                MessageBox.Show("Güncelleme başarısız.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kitap_guncelle_Load(object sender, EventArgs e)
        {
            //Kitap_guncelle ye veri çektik.
            string sql = "SELECT * FROM kitaplar WHERE ID = "+Form1.secim+"";
            DataTable dt = Slave.BringData(sql);
            textBox1.Text = dt.Rows[0]["Barkod_No"].ToString();
            textBox2.Text = dt.Rows[0]["Kitap_Adi"].ToString();
            textBox3.Text = dt.Rows[0]["Yazar_Adi"].ToString();
            textBox4.Text = dt.Rows[0]["Yayin_Evi"].ToString();
            textBox5.Text = dt.Rows[0]["Kitap_Turu"].ToString();
            textBox6.Text = dt.Rows[0]["Stok"].ToString();
        }
    }
}
