using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eclinicnew
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPatient_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserLogin");
        }

        protected void btnDoc_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DoctorLogin");
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminLogin");
        }
    }
}