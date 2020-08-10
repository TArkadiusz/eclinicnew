using MySql.Data.MySqlClient;
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
    public partial class Registration : System.Web.UI.Page
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("~/UserLogin");
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                String cs = "Server=127.0.0.1; Port=3306; Database=eclinic; Uid=root; Pwd=root";

                string hashPass = HashPass(tbRegPass.Text);
                using (MySqlConnection conn = new MySqlConnection(cs))
                {
                    conn.Open();
                    String sql = @"INSERT INTO user
                                (login, password, fname, lname, email, pesel)
                                VALUES
                                (@login, @pass, @fname, @lname, @email, @pesel)
                                ";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.Add("@login", MySqlDbType.VarChar, 50).Value = tbRegLogin.Text;
                    cmd.Parameters.Add("@pass", MySqlDbType.VarChar, 255).Value = hashPass;
                    cmd.Parameters.Add("@fname", MySqlDbType.VarChar, 50).Value = tbRegFname.Text;
                    cmd.Parameters.Add("@lname", MySqlDbType.VarChar, 50).Value = tbRegLname.Text;
                    cmd.Parameters.Add("@email", MySqlDbType.VarChar, 255).Value = tbRegEmail.Text;
                    cmd.Parameters.Add("@pesel", MySqlDbType.VarChar, 20).Value = tbRegPesel.Text;


                    cmd.ExecuteNonQuery();
                    lblResult.Text = "Rejestracja wykonana prawidłowo";

                    tbRegLogin.Text = "";
                    tbRegPass.Text = "";
                    tbRegFname.Text = "";
                    tbRegLname.Text = "";
                    tbRegEmail.Text = "";
                    tbRegPesel.Text = "";

                }
            }



            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
