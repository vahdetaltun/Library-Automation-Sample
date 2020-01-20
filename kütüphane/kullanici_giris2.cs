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
    public partial class kullanici_giris2 : Form
    {
        public kullanici_giris2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM yetkililer WHERE yet_isim ='" + textBox1.Text.Trim() + "' AND yet_sifre = '" + textBox2.Text.Trim() + "'";
            DataTable dt = Slave.BringData(query);
            if (dt.Rows.Count == 1)
            {
                kitap_guncelle güncelle = new kitap_guncelle();
                güncelle.Hide();
                güncelle.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bilgilerinizi kontrol edip tekrar deneyiniz !", "Giriş Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //checkBox işaretli ise
            if (checkBox1.Checked)
            {
                //karakteri göster.
                textBox2.PasswordChar = '\0';
            }
            //değilse karakterlerin yerine * koy.
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
