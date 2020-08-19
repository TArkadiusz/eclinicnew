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
    public partial class AddDoctor : System.Web.UI.Page
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

        protected void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                String cs = "Server=127.0.0.1; Port=3306; Database=eclinic; Uid=root; Pwd=root";


                string hashPass = HashPass(tbDocPass.Text);
                using (MySqlConnection conn = new MySqlConnection(cs))
                {
                    conn.Open();
                    String sql = @"INSERT INTO doctor
                                (login, password, full_name, email)
                                VALUES
                                (@login, @pass, @full_name, @email)
                                ";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.Add("@login", MySqlDbType.VarChar, 50).Value = tbDocLogin.Text;
                    cmd.Parameters.Add("@pass", MySqlDbType.VarChar, 255).Value = hashPass;
                    cmd.Parameters.Add("@full_name", MySqlDbType.VarChar, 50).Value = tbDocFullName.Text;
                    cmd.Parameters.Add("@email", MySqlDbType.VarChar, 255).Value = tbDocEmail.Text;


                    cmd.ExecuteNonQuery();
                    lblResult.Text = "Dodano nowego lekarza";

                    tbDocLogin.Text = "";
                    tbDocPass.Text = "";
                    tbDocFullName.Text = "dr ";
                    tbDocEmail.Text = "";
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            RequiredFieldValidator1.Enabled = false;
            RequiredFieldValidator6.Enabled = false;
            RequiredFieldValidator2.Enabled = false;
            RequiredFieldValidator4.Enabled = false;
            RegularExpressionValidator1.Enabled = false;
            Response.Redirect("~/PickDoctor");
        }
    }
}