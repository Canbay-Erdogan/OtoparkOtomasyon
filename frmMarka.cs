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
    public partial class frmMarka : Form
    {
        public frmMarka()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=AracOtopark; Integrated Security=True");
        private void frmMarka_Load(object sender, EventArgs e)
        {

        }

        private void btnMarkaEkle_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand command = new SqlCommand("insert into markaBilgileri (marka) values (@marka)",connect);
            command.Parameters.AddWithValue("@marka", txtMarka.Text);
            command.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("marka eklendi");
        }
    }
}
