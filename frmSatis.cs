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
    public partial class frmSatis : Form
    {
        public SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=AracOtopark; Integrated Security=True");
        DataSet data = new DataSet();

        public frmSatis()
        {
            InitializeComponent();
        }

        private void frmSatis_Load(object sender, EventArgs e)
        {
            SatislariListele();

            connect.Open();
            SqlCommand command = new SqlCommand("select sum(tutar) from Satis",connect);
            label1.Text = "Toplam Tutar = "+command.ExecuteScalar()+" ₺" ;
            connect.Close();

        }

        private void SatislariListele()
        {
            connect.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from satis", connect);
            dataAdapter.Fill(data, "satis");
            dataGridView1.DataSource = data.Tables["satis"];
            connect.Close();
        }
    }
}
