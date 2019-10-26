using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            var connectionBuilder = new SqlConnectionStringBuilder();
            connectionBuilder.ConnectionString = @"Server=DESKTOP-TALUG4B\SQLEXPRESS;Database=SalesDb;Trusted_Connection=True;";
            using (var connection = new SqlConnection(connectionBuilder.ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        transaction.Commit();
                    }
                    catch (SqlException exception)
                    {
                        transaction.Rollback();
                    }
                }
            }
            TextBox.Text = "Есть подключение, хозяин";
        }
    }
}
