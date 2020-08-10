using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eclinicnew
{
    public partial class EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String cs = "Server=127.0.0.1; Port=3306; Database=eclinic; Uid=root; Pwd=root";

                if (!Page.IsPostBack)
                {
                    if (Request.Params["id"] != null)
                    {
                        int rowId;
                        if (!Int32.TryParse(Request.Params["id"], out rowId))
                        {
                            Response.Redirect("~/PickUser");
                        }
                        else
                        {
                            //odczyt z tablicy
                            using (MySqlConnection conn = new MySqlConnection(cs))
                            {
                                conn.Open();
                                String sql = "SELECT * FROM user WHERE id=" + rowId;
                                MySqlDataAdapter adapter = new MySqlDataAdapter();
                                adapter.SelectCommand = new MySqlCommand(sql, conn);
                                DataTable table = new DataTable();
                                adapter.Fill(table);
                                if (table.Rows.Count == 0)
                                {
                                    Response.Redirect("~/PickUser");
                                }
                                else
                                {
                                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                                    MySqlDataReader reader = cmd.ExecuteReader();

                                    reader.Read();
                                    tbUserLogin.Text = reader["login"].ToString();
                                    tbUserFname.Text = reader["fname"].ToString();
                                    tbUserLname.Text = reader["lname"].ToString();
                                    tbUserEmail.Text = reader["email"].ToString();
                                    tbUserPesel.Text = reader["pesel"].ToString();
                                    tbHiddenId.Value = rowId.ToString();
                                }
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("~/PickUser");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //RequiredFieldValidator1.Enabled = false;
            //RequiredFieldValidator2.Enabled = false;
            //RequiredFieldValidator3.Enabled = false;
            //RequiredFieldValidator4.Enabled = false;
            //RequiredFieldValidator5.Enabled = false;
            //RegularExpressionValidator1.Enabled = false;
            Response.Redirect("~/PickUser");
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                String cs = "Server=127.0.0.1; Port=3306; Database=eclinic; Uid=root; Pwd=root";

                String sql = @"UPDATE user SET 
                                login='{0}', fname='{1}', lname='{2}', email='{3}', pesel='{4}' WHERE id='{5}'";
                sql = String.Format(sql, tbUserLogin.Text, tbUserFname.Text,
                                    tbUserLname.Text, tbUserEmail.Text, tbUserPesel.Text, Convert.ToInt32(tbHiddenId.Value));
                using (MySqlConnection conn = new MySqlConnection(cs))
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    Response.Redirect("~/PickUser");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}