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
    public partial class emanet_ver : Form
    {
        public emanet_ver()
        {
            InitializeComponent();
        }

        private void emanet_ver_Load(object sender, EventArgs e)
        {
            ComboDoldur();
            ComboDoldur2();
        }
        void ComboDoldur()
        {
            string sql = "SELECT ID,Kitap_Adi FROM kitaplar WHERE Stok > 0";
            DataTable dt = Slave.BringData(sql);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Kitap_Adi";
            comboBox1.ValueMember = "ID";
            
        }
        void ComboDoldur2()
        {
            string sql = "SELECT lib_id,lib_name_surname FROM okuyucu_ekle";
            DataTable dt = Slave.BringData(sql);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "lib_name_surname";
            comboBox2.ValueMember = "lib_id";

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.Text = null;
            comboBox2.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string a = comboBox1.SelectedValue.ToString(); // kitap seç
                string b = comboBox2.SelectedValue.ToString();  // kullanıcı seç

                string sql = @"INSERT INTO emanet_kitap(e_kit_id,e_oku_id) VALUES("+a+","+b+")";
                Slave.SendData(sql);
                MessageBox.Show("Kitap Başarıyla Verildi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);

                // Stok azaltma
                // string azalt = @"SELECT * FROM kitaplar WHERE Kitap_Adi = "comboBox1.SelectedValue.ToString()" AND Stok";
            }
            catch
            {
                MessageBox.Show("Bir Hata Oluştu.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
         }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
