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
    public partial class EditVisit : System.Web.UI.Page
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
                            Response.Redirect("~/PickVisit");
                        }
                        else
                        {
                            //odczyt z tablicy
                            using (MySqlConnection conn = new MySqlConnection(cs))
                            {
                                conn.Open();
                                String sql = "SELECT * FROM visits WHERE id=" + rowId;
                                MySqlDataAdapter adapter = new MySqlDataAdapter();
                                adapter.SelectCommand = new MySqlCommand(sql, conn);
                                DataTable table = new DataTable();
                                adapter.Fill(table);
                                if (table.Rows.Count == 0)
                                {
                                    Response.Redirect("~/PickVisit");
                                }
                                else
                                {
                                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                                    MySqlDataReader reader = cmd.ExecuteReader();

                                    reader.Read();
                                    lblFname.Text = reader["fname"].ToString();
                                    lblLname.Text = reader["lname"].ToString();
                                    tbDescr.Text = reader["descr"].ToString();
                                    tbHiddenId.Value = rowId.ToString();
                                }
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("~/PickVisit");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void LoadDataDoctor()
        {

            try
            {
                String cs = "Server=127.0.0.1; Port=3306; Database=eclinic; Uid=root; Pwd=root";
                using (MySqlConnection conn = new MySqlConnection(cs))
                {
                    conn.Open();
                    String sql = @"SELECT email
                                    FROM doctor WHERE full_name='{0}'";
                    sql = String.Format(sql, ddlDoctor.Text);
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = new MySqlCommand(sql, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    if (table.Rows.Count == 0)
                    {
                        Response.Redirect("~/PickVisit");
                    }
                    else
                    {
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        reader.Read();
                        hfDocEmail.Value = Convert.ToString(reader["email"]);
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
                if (tbDate.Text == "" || tbDate.Text == null
                    || tbTime.Text == "" || tbTime.Text == null)
                {
                    lblResult.Text = "Wprowadź datę i czas";
                }
                else
                {
                    LoadDataDoctor();
                    string dateTime = String.Format("{0} {1}", tbDate.Text, tbTime.Text);
                    String cs = "Server=127.0.0.1; Port=3306; Database=eclinic; Uid=root; Pwd=root";

                    String sql = @"UPDATE visits SET 
                                doctor='{0}', email_doc='{1}', visit_date='{2}', descr='{3}', status='{4}' 
                                WHERE id='{5}'";
                    sql = String.Format(sql, ddlDoctor.SelectedItem, hfDocEmail.Value, dateTime,
                                        tbDescr.Text, ddlStatus.SelectedItem, Convert.ToInt32(tbHiddenId.Value));
                    using (MySqlConnection conn = new MySqlConnection(cs))
                    {
                        conn.Open();

                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                        Response.Redirect("~/PickVisit");
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
            Response.Redirect("~/PickVisit");
        }
    }
}