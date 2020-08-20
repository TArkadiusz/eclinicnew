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
    public partial class VisitDoctor : System.Web.UI.Page
    {
        public void LoadDataDoctor()
        {

            try
            {
                String cs = "Server=127.0.0.1; Port=3306; Database=eclinic; Uid=root; Pwd=root";
                using (MySqlConnection conn = new MySqlConnection(cs))
                {
                    conn.Open();
                    String sql = @"SELECT id
                                    FROM doctor WHERE login='{0}'";
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
            LoadDataDoctor();
            SqlDataSource.SelectCommand = 
                String.Format("SELECT id, fname, lname, email_user, pesel, visit_date, descr, image, status FROM visits WHERE doctor_id='{0}'", hfId.Value);

            
        }

        protected void btnEditPass_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/PassDoc");
            Response.Redirect("PassDoc.aspx?Parameter=" + lblLogin.Text);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main");
        }
    }
}