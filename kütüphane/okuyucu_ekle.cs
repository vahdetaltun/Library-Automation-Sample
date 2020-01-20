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
    public partial class okuyucu_ekle : Form
    {
        public okuyucu_ekle()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            comboBox1.Text = null;
        }

        private void okuyucu_ekle_Load(object sender, EventArgs e)
        {
            string[] doldur = new string[2];

            doldur[0] = "Erkek";
            doldur[1] = "Kadın";

            for (int i = 0; i < doldur.Length; i++)
            {
                comboBox1.Items.Add(doldur[i]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text =="")
            {
                MessageBox.Show("Boş alanları doldurunuz","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                string sql = @"INSERT INTO okuyucu_ekle(lib_name_surname,lib_tc,lib_tel,lib_adres,lib_cinsiyet,lib_dogum) 
            VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "','" + textBox5.Text + "')";
                Slave.SendData(sql);
                MessageBox.Show("Okuyucu başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;
                textBox5.Text = null;
                comboBox1.Text = null;
            }
        }
    }
}
