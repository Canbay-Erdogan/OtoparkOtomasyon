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
    public partial class frmAracOtoparkYerleri : Form
    {
        public frmAracOtoparkYerleri()
        {
            InitializeComponent();
        }

       // SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=AracOtopark; Integrated Security=True");
        private void frmAracOtoparkYerleri_Load(object sender, EventArgs e)
        {
            BosParkYerleri();
            DoluParkYerleri();

            SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=AracOtopark; Integrated Security=True");
            connect.Open();
            SqlCommand command = new SqlCommand("select * from aracDurumu inner join aracOtoparkKaydi on aracOtoparkKaydi.Parkyeri=aracDurumu.Parkyeri", connect);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                foreach (Control item in Controls)
                {
                    if (item is Button)
                    {
                        if (item.Text == reader["Parkyeri"].ToString() && reader["durumu"].ToString() == "Dolu")
                        {
                            item.Text = reader["Plaka"].ToString();
                        }
                    }

                }
            }

        }

        private void DoluParkYerleri()
        {
            SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=AracOtopark; Integrated Security=True");
            connect.Open();
            SqlCommand command = new SqlCommand("select * from aracDurumu", connect);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                foreach (Control item in Controls)
                {
                    if (item is Button)
                    {
                        if (item.Text == reader["Parkyeri"].ToString() && reader["durumu"].ToString() == "Dolu")
                        {
                            item.BackColor = Color.Red;
                        }
                    }

                }
            }
            reader.Close();
            connect.Close();
        }
        private void BosParkYerleri()
        {
            int sayac = 1;
            foreach (Control item in Controls)
            {
                if (item is Button)
                {
                    item.Text = "P-" + sayac++;
                    item.Name = "P-" + sayac;
                }
            }
        }
    }
}
