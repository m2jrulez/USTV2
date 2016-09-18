using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomLibrary;

namespace USTV2.Lib
{
   public static class PublicModule
    {
        public static int UserID { get; set; }
        public static string UserName { get; set; }

        public static string Server = "";
        public static string DataSource = "";
        public static string Password = "";

        public static string conStr = Server + ";" + DataSource + ";" + Password;

        public static string messageBoxCaption = "نظام إدارة المخزون - UST";

        public static void FillCMB(this ComboBox comboBox, string tableName, string displayMember, string valueMember, int index = -1, string whereFilter = "")
        {

            try
            {
                using (var con = new SqlConnection(conStr))
                {
                    var sda = new SqlDataAdapter("Select " + displayMember + " , " + valueMember + " " +
                                                 "From " + tableName + " " +
                                                  whereFilter + " " +
                                                 "Order by " + displayMember, con);
                    var dt = new DataTable();
                    sda.Fill(dt);
                    comboBox.ValueMember = valueMember;
                    comboBox.DisplayMember = displayMember;
                    comboBox.DataSource = dt;
                    comboBox.SelectedIndex = index;

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }



        }
        public static void FillDT(this DataTable dt, string query)
        {
            {
                using (var con = new SqlConnection(conStr))
                {
                    var sda = new SqlDataAdapter(query, con);
                    sda.Fill(dt);
                }
            }
        }

        public static void FillCMB(this ComboBox comboBox, DataTable dt, string displayMember, string valueMember, string RowFilter = "")
        {
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = RowFilter;
                comboBox.DataSource = null;
                comboBox.ValueMember = valueMember;
                comboBox.DisplayMember = displayMember;
                comboBox.DataSource = dv;
                comboBox.SelectedIndex = -1;
            }
        }
        public static void FillCMBFromDataTable(this ComboBox comboBox, DataTable dt, string displayMember, string valueMember, int index)
        {
            {
                using (var con = new SqlConnection(conStr))
                {

                    comboBox.ValueMember = valueMember;
                    comboBox.DisplayMember = displayMember;
                    comboBox.DataSource = dt;
                    comboBox.SelectedIndex = index;
                }
            }
        }

        public static void Clear(this ComboBox cmb)
        {
            cmb.DataSource = null;
            cmb.Items.Clear();
        }
        public static int GetCurrentYear()
        {
            try
            {
                using (var con = new SqlConnection(PublicModule.conStr))
                {
                    var cmd = new SqlCommand("select year(GetDate());", con);
                    con.Open();
                    var currentYear = cmd.ExecuteScalar().ToInt();
                    return currentYear;
                }
            }

            catch (Exception ex)
            {
                GeneralUI.ErrorMsg("An error occured!: " + ex.Message);
                return -1;
            }
        }

        public static DateTime? GetCurrentDate()
        {
            try
            {
                using (var con = new SqlConnection(PublicModule.conStr))
                {
                    var cmd = new SqlCommand("select GetDate();", con);
                    con.Open();
                    var currentDate = cmd.ExecuteScalar().ToDate();
                    return currentDate;
                }
            }

            catch (Exception ex)
            {
                GeneralUI.ErrorMsg("An error occured!: " + ex.Message);
                return null;
            }
        }
        public static object ExecuteScalar(string query, SqlCommand cmd)
        {
            try
            {
                if (cmd.IsNull())
                {
                    SqlCommand command = new SqlCommand();
                    using (var con = new SqlConnection(PublicModule.conStr))
                    {
                        command.Connection = con;
                        command.CommandText = query;
                        con.Open();
                        return command.ExecuteScalar();
                    }
                }
                else
                {
                    return cmd.ExecuteScalar();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static void AppLyLeave(this ComboBox cmb)
        {
            cmb.Leave += new EventHandler(cmb_Leave);
        }

        private static void cmb_Leave(object sender, EventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            if (cmb.IsNull())
                return;

            if (cmb.Text.IsEmpty())
            {
                cmb.SelectedIndex = -1;
                return;
            }

            if (cmb.FindStringExact(cmb.Text) == -1)
            {
                cmb.SelectedIndex = -1;
                cmb.Text = "";
            }
        }


        public static bool IsServerConnected(string connectionString)
        {

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
            builder.ConnectTimeout = 1;


            using (SqlConnection connection = new SqlConnection(builder.ToString()))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {

                    return false;
                }
            }
        }

   }


}
