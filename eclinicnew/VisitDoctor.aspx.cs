using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eclinicnew
{
    public partial class VisitDoctor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblLogin.Text = Request.QueryString["Parameter"].ToString();
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