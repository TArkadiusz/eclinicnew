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
    public partial class VisitUser : System.Web.UI.Page
    {
        public void LoadDataUser()
        {

            try
            {
                String cs = "Server=127.0.0.1; Port=3306; Database=eclinic; Uid=root; Pwd=root";
                using (MySqlConnection conn = new MySqlConnection(cs))
                {
                    conn.Open();
                    String sql = @"SELECT id
                                    FROM user WHERE login='{0}'";
                    sql = String.Format(sql, lblLogin.Text);
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = new MySqlCommand(sql, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    if (table.Rows.Count == 0)
                    {
                        Response.Redirect("~/Main");
                    }
                    else
                    {
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        reader.Read();
                        hfId.Value = Convert.ToString(reader["id"]);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblLogin.Text = Request.QueryString["Parameter"].ToString();
            LoadDataUser();
            SqlDataSource.SelectCommand = String.Format("SELECT id, fname, lname, doctor, email_doc, visit_date, descr, image, status FROM visits WHERE user_id='{0}'", hfId.Value);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAddVisit_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddVisit.aspx?Parameter=" + lblLogin.Text);
        }

        protected void btnEditUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateUser.aspx?Parameter=" + lblLogin.Text);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main");
        }
    }
}