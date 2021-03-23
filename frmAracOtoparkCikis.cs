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
    public partial class frmAracOtoparkCikis : Form
    {
        public SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=AracOtopark; Integrated Security=True");

        public frmAracOtoparkCikis()
        {
            InitializeComponent();
        }

        private void frmAracOtoparkCikis_Load(object sender, EventArgs e)
        {
            DoluYerler();
            Plakalar();
            timer1.Enabled = true;
        }

        private void Plakalar()
        {
            connect.Open();
            SqlCommand command = new SqlCommand("select * from aracOtoparkKaydi", connect);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cbxPlaka.Items.Add(reader["Plaka"].ToString());
            }
            reader.Close();
            connect.Close();
        }

        private void DoluYerler()
        {
            connect.Open();
            SqlCommand command = new SqlCommand("select * from aracDurumu where durumu ='Dolu'", connect);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cbxParkYeri.Items.Add(reader["Parkyeri"].ToString());
            }
            reader.Close();
            connect.Close();
        }
        private void cbxPlaka_SelectedIndexChanged(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand command = new SqlCommand("select * from aracOtoparkKaydi where Plaka=@plaka ", connect);
            command.Parameters.AddWithValue("@plaka", cbxPlaka.SelectedItem.ToString());
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                txtParkYeri.Text=reader["Parkyeri"].ToString();
            }
            reader.Close();
            connect.Close();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxParkYeri_SelectedIndexChanged(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand command = new SqlCommand("select * from aracOtoparkKaydi where Parkyeri=@parkyeri ", connect);
            command.Parameters.AddWithValue("@parkyeri", cbxParkYeri.SelectedItem.ToString());
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                txtParkYeri2.Text = reader["Parkyeri"].ToString();
                txtTc.Text = reader["Tc"].ToString();
                txtAd.Text = reader["Ad"].ToString();
                txtSoyad.Text = reader["Soyad"].ToString();
                txtMarka.Text = reader["Marka"].ToString();
                txtSeri.Text = reader["Seri"].ToString();
                lblGelis.Text = reader["Tarih"].ToString();
            }

            reader.Close();
            connect.Close();

            DateTime gelis, cikis;
            gelis = DateTime.Parse(lblGelis.Text);
            cikis = DateTime.Parse(lblCikis.Text);
            TimeSpan fark = cikis - gelis;
            lblSure.Text = fark.TotalHours.ToString("0.00");
            lblTotal.Text = ((double)(Convert.ToDouble(lblSure.Text) * 0.7)).ToString("0.00");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblCikis.Text = DateTime.Now.ToString();
        }

        private void btnAracCikis_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand command = new SqlCommand("delete from aracOtoparkKaydi where Plaka = @plaka", connect);
            command.Parameters.AddWithValue("@plaka", cbxPlaka.SelectedItem.ToString());
            command.ExecuteNonQuery();

            SqlCommand command2 = new SqlCommand("update aracDurumu set durumu = 'Bos' where Parkyeri = @Parkyeri ", connect);
            command2.Parameters.AddWithValue("@Parkyeri", txtParkYeri2.Text);
            command2.ExecuteNonQuery();

            SqlCommand command3 = new SqlCommand("insert into satis(Parkyeri,plaka,GelisTarihi,CikisTarihi,Sure,tutar) values(@Parkyeri,@plaka,@GelisTarihi,@CikisTarihi,@Sure,@tutar)", connect);
            command3.Parameters.AddWithValue("@Parkyeri", txtParkYeri.Text);
            command3.Parameters.AddWithValue("@plaka", cbxPlaka.Text);
            command3.Parameters.AddWithValue("@GelisTarihi", lblGelis.Text);
            command3.Parameters.AddWithValue("@CikisTarihi", lblCikis.Text);
            command3.Parameters.AddWithValue("@Sure", double.Parse(lblSure.Text));
            command3.Parameters.AddWithValue("@tutar",double.Parse( lblTotal.Text));

            command3.ExecuteNonQuery();

            connect.Close();
            MessageBox.Show("Arac cikisi yapıldı");
            frmAracOtoparkCikis otoparkCikis = new frmAracOtoparkCikis();
            var a = otoparkCikis.Controls;
            foreach (Control item in groupBox2.Controls)
            {
                item.Text = "";
            }
        }
    }
}
