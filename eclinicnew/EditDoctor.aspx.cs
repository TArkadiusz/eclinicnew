using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eclinicnew
{
    public partial class EditDoctor : System.Web.UI.Page
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
                                Response.Redirect("~/PickDoctor");
                            }
                            else
                            {
                                //odczyt z tablicy
                                using (MySqlConnection conn = new MySqlConnection(cs))
                                {
                                    conn.Open();
                                    String sql = "SELECT * FROM doctor WHERE id=" + rowId;
                                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                                    adapter.SelectCommand = new MySqlCommand(sql, conn);
                                    DataTable table = new DataTable();
                                    adapter.Fill(table);
                                    if (table.Rows.Count == 0)
                                    {
                                        Response.Redirect("~/PickDoctor");
                                    }
                                    else
                                    {
                                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                                        MySqlDataReader reader = cmd.ExecuteReader();

                                        reader.Read();
                                        tbDocLogin.Text = reader["login"].ToString();
                                        tbDocFname.Text = reader["fname"].ToString();
                                        tbDocLname.Text = reader["lname"].ToString();
                                        tbDocEmail.Text = reader["email"].ToString();
                                        tbHiddenId.Value = rowId.ToString();
                                    }
                                }
                            }
                        }
                        else
                        {
                            Response.Redirect("~/PickDoctor");
                        }
                    }                                  
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                String cs = "Server=127.0.0.1; Port=3306; Database=eclinic; Uid=root; Pwd=root";

                
                String sql = @"UPDATE doctor SET 
                                login='{0}', fname='{1}', lname='{2}', email='{3}' WHERE id='{4}'";
                sql = String.Format(sql, tbDocLogin.Text, tbDocFname.Text,
                                    tbDocLname.Text, tbDocEmail.Text, Convert.ToInt32(tbHiddenId.Value));
                using (MySqlConnection conn = new MySqlConnection(cs))
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                        Response.Redirect("~/PickDoctor");
                    }
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            RequiredFieldValidator1.Enabled = false;
            RequiredFieldValidator2.Enabled = false;
            RequiredFieldValidator3.Enabled = false;
            RequiredFieldValidator4.Enabled = false;
            RegularExpressionValidator1.Enabled = false;
            Response.Redirect("~/PickDoctor");
        }
    }
}