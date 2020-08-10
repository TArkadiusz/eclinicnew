using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eclinicnew
{
    public partial class PassDoc : System.Web.UI.Page
    {
        
        private String HashPass(string pass)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(pass));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblLogin.Text = Request.QueryString["Parameter"].ToString();
        }

        String cs = "Server=127.0.0.1; Port=3306; Database=eclinic; Uid=root; Pwd=root";

        protected void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(tbDocPass.Text))
                {
                    lblResult.Text = "Wprowadź hasło";
                    return;
                }

                string hashPass = HashPass(tbDocPass.Text);

                String sql = @"UPDATE doctor SET 
                                password='{0}' WHERE login='{1}'";
                sql = String.Format(sql, hashPass, lblLogin.Text);
                using (MySqlConnection conn = new MySqlConnection(cs))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    lblResult.Text = "Zmiana hasła wykonana poprawnie";
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/VisitDoctor");
            Response.Redirect("VisitDoctor.aspx?Parameter=" + lblLogin.Text);
        }
    }
}