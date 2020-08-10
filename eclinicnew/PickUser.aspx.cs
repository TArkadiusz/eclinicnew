using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eclinicnew
{
    public partial class PickUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main");
        }

        protected void btnEditDoctor_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PickDoctor");
        }

        protected void btnEditVisit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PickVisit");
        }

        String cs = "Server=127.0.0.1; Port=3306; Database=eclinic; Uid=root; Pwd=root";
        protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                //usuwać rekord
                int rowId = Convert.ToInt32(e.CommandArgument);
                using (MySqlConnection conn = new MySqlConnection(cs))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM user WHERE id=" + rowId, conn);
                    cmd.ExecuteNonQuery();

                    //odśwież grid
                    gridView.DataBind();
                }
            }
        }
    }
}