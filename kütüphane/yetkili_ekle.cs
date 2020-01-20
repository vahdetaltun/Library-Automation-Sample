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
    public partial class yetkili_ekle : Form
    {
        public yetkili_ekle()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (textBox2.Text == ""))
            {
                MessageBox.Show("Boş alanları doldurunuz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string query = @"INSERT INTO yetkililer(yet_isim,yet_sifre) VALUES('" + textBox1.Text + "','" + textBox2.Text + "')";
                Slave.SendData(query);
                MessageBox.Show("Yetkili kişi başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = null;
                textBox2.Text = null;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
