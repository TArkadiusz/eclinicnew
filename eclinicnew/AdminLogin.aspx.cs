using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eclinicnew
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                String cs = "Server=127.0.0.1;Port=3306;Database=eclinic;Uid={0};Pwd={1}";


                if (String.IsNullOrEmpty(tbLogin.Text) || String.IsNullOrEmpty(tbPass.Text))
                {
                    lblResult.Text = "Podaj login i hasło";
                    return;
                }

                cs = String.Format(cs, tbLogin.Text.Trim(), tbPass.Text.Trim());

                MySqlConnection conn = new MySqlConnection(cs);
                conn.Open();

                Response.Redirect("~/PickUser");
            }

            catch (Exception)
            {
                throw;
            }

        }
    }
}