using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eclinicnew
{
    public partial class VisitUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblLogin.Text = Request.QueryString["Parameter"].ToString();
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