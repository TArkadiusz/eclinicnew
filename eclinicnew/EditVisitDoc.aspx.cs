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
    public partial class EditVisitDoc : System.Web.UI.Page
    {
        String cs = "Server=127.0.0.1; Port=3306; Database=eclinic; Uid=root; Pwd=root";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblLogin.Text = Request.QueryString["Parameter"].ToString();
            if (!Page.IsPostBack)
            {
                if (Request.Params["id"] != null)
                {
                    int rowId;
                    if (!Int32.TryParse(Request.Params["id"], out rowId))
                    {
                        Response.Redirect("~/VisitDoctor.aspx");
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
                                Response.Redirect("~/VisitDoctor.aspx");
                            }
                            else
                            {
                                MySqlCommand cmd = new MySqlCommand(sql, conn);
                                MySqlDataReader reader = cmd.ExecuteReader();

                                tbHiddenId.Value = rowId.ToString();
                            }
                        }
                    }
                }
                else
                {
                    Response.Redirect("~/VisitDoctor.aspx");
                }
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                String sql = @"UPDATE visits SET status='{0}' WHERE id='{1}'";
                sql = String.Format(sql, ddlStatus.SelectedItem, Convert.ToInt32(tbHiddenId.Value));
                using (MySqlConnection conn = new MySqlConnection(cs))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    Response.Redirect("VisitDoctor.aspx?Parameter=" + lblLogin.Text);
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("VisitDoctor.aspx?Parameter=" + lblLogin.Text);
        }
    }
}