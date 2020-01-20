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
    public partial class kitap_ekle : Form
    {
        public kitap_ekle()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = @"INSERT INTO kitaplar(Barkod_No,Kitap_Adi,Yazar_Adi,Yayin_Evi,Kitap_Turu,Stok,Alinan_tarih) 
                VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + DateTime.Now + "')";
                Slave.SendData(sql);
                MessageBox.Show("Kitap başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;
                textBox5.Text = null;
                textBox6.Text = null;
            }
            catch
            {
                MessageBox.Show("Önce Kitap Bilgilerini Giriniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
