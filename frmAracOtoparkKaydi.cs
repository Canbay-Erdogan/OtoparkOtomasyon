using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OtoparkOtomasyonu
{
    public partial class frmAracOtoparkKaydiDesigner : Form
    {
        Connection connection = new Connection();
        public SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=AracOtopark; Integrated Security=True");

        public frmAracOtoparkKaydiDesigner()
        {
            InitializeComponent();
        }
        private void frmAracOtoparkKaydi_Load(object sender, EventArgs e)
        {
            BosAraclar();
            MarkalariYukle();
        }

        private void MarkalariYukle()
        {
            connect.Open();
            SqlCommand command = new SqlCommand("select * from markaBilgileri",connect);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cbxMarka.Items.Add(reader["marka"].ToString());
            }
            reader.Close();
            connect.Close();
        }
        private void BosAraclar()
        {
            connect.Open();
            SqlCommand command = new SqlCommand("select * from aracDurumu where durumu = 'Bos'", connect);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cbxParkyeri.Items.Add(reader["Parkyeri"].ToString());
            }
            reader.Close();
            connect.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string AddKomut = "insert into aracOtoparkKaydi (TC,Ad,Soyad,Telefon,Email,Plaka,Marka,Seri,Renk,Parkyeri,Tarih) Values (@TC,@Ad,@Soyad,@Telefon,@Email,@Plaka,@Marka,@Seri,@Renk,@Parkyeri,@Tarih)";
            string SetKomut = "update aracDurumu set durumu = 'Dolu' where Parkyeri = '"+cbxParkyeri.SelectedItem+"' ";

            SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=AracOtopark; Integrated Security=True");
            connect.Open();

            SqlCommand command = new SqlCommand(AddKomut,connect);
            
            command.Parameters.AddWithValue("@TC", txtTc.Text);
            command.Parameters.AddWithValue("@Ad", txtAd.Text);
            command.Parameters.AddWithValue("@Soyad", txtSoyad.Text);
            command.Parameters.AddWithValue("@Telefon", txtTelefon.Text);
            command.Parameters.AddWithValue("@Email", txtEmail.Text);
            command.Parameters.AddWithValue("@Plaka", txtPlaka.Text);
            command.Parameters.AddWithValue("@Marka", cbxMarka.Text);
            command.Parameters.AddWithValue("@Seri", cbxSeri.Text);
            command.Parameters.AddWithValue("@Renk", txtRenk.Text);
            command.Parameters.AddWithValue("@Parkyeri", cbxParkyeri.SelectedItem);
            command.Parameters.AddWithValue("@Tarih", DateTime.Now);

            command.ExecuteNonQuery();


            command = new SqlCommand(SetKomut,connect);
            command.ExecuteNonQuery();

            connect.Close();
            MessageBox.Show("Kayıt yapıldı", "tamam");
            cbxParkyeri.Items.Clear();
            this.BosAraclar();

            foreach (Control item in grpKisi.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            foreach (Control item in grpArac.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            foreach (Control item in grpArac.Controls)
            {
                if (item is ComboBox)
                {
                    item.Text = "";
                }
            }
        }

        private void btnMarka_Click(object sender, EventArgs e)
        {
            frmMarka marka = new frmMarka();
            marka.ShowDialog();
        }

        private void btnSeri_Click(object sender, EventArgs e)
        {
            frmSeri seri = new frmSeri();
            seri.ShowDialog();
        }

        private void cbxMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxSeri.Text = "seri seçiniz";
            cbxSeri.Items.Clear();
            connect.Open();
            SqlCommand command = new SqlCommand("select seri from seriBilgileri where marka = @marka", connect); //'"+cbxMarka.SelectedItem+"'" şeklinde de yazılabilirdi
            command.Parameters.AddWithValue("@marka", cbxMarka.SelectedItem);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                    cbxSeri.Items.Add(reader["seri"].ToString());
            }
            reader.Close();
            connect.Close();
        }

    }
}
