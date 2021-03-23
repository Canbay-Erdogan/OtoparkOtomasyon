using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace OtoparkOtomasyonu
{
   public class Connection
    {
        private SqlConnection connectionDb;// = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=AracOtopark; Integrated Security=True");
        public SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=AracOtopark; Integrated Security=True");
        public Connection()
        {
            connectionDb = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=AracOtopark; Integrated Security=True");
            //this.ConnectionOpen();
        }

        public SqlDataReader ConnectRead(string komut)
        {
            ConnectionOpen();
            SqlCommand command = new SqlCommand(komut, connectionDb);
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public void ConnectionOpen()
        {
            if (connectionDb.State != ConnectionState.Open)
            {
                connectionDb.Open();
            }
        }

        public void ConnectClose()
        {
            connectionDb.Close();
        }

    }
}
