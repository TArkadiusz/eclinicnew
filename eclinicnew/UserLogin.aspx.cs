using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eclinicnew
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

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

        protected void btnReg_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Registration");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main");
        }

        String cs = "Server=127.0.0.1; Port=3306; Database=eclinic; Uid=root; Pwd=root";

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbLogin.Text) || String.IsNullOrEmpty(tbPass.Text))
            {
                lblResult.Text = "Podaj login i hasło";
                return;
            }
            string hashPass = HashPass(tbPass.Text);
            String sql = "SELECT * FROM user WHERE login=@login AND password=@pass";
            using (MySqlConnection conn = new MySqlConnection(cs))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.Add("@login", MySqlDbType.VarChar, 50).Value = tbLogin.Text;
                cmd.Parameters.Add("@pass", MySqlDbType.VarChar, 255).Value = hashPass;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    lblResult.Text = "Nieznany użytkownik/hasło";
                }
                else
                {
                    Response.Redirect("VisitUser.aspx?Parameter=" + tbLogin.Text);
                }
            }
        }
    }
}