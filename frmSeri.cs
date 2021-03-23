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
    public partial class frmSeri : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=AracOtopark; Integrated Security=True");

        public frmSeri()
        {
            InitializeComponent();
        }

        private void frmSeri_Load(object sender, EventArgs e)
        {
            MarkaGetir();
        }

        private void MarkaGetir()
        {
            connect.Open();
            SqlCommand command = new SqlCommand("select marka from markaBilgileri", connect);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cbxMarka.Items.Add(reader["marka"].ToString());
            }
            reader.Close();
            connect.Close();
        }

        private void btnSeriEkle_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand command = new SqlCommand("insert into seriBilgileri (seri,marka) values (@seri,@marka)", connect);
            command.Parameters.AddWithValue("@seri", txtSeri.Text);
            command.Parameters.AddWithValue("@marka", cbxMarka.SelectedItem.ToString());
            command.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Seri eklendi");
            txtSeri.Clear();
            cbxMarka.Text = "";
        }
    }
}
