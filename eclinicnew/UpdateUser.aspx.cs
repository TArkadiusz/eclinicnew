using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eclinicnew
{
    public partial class UpdateUser : System.Web.UI.Page
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
            tbEditLogin.Text = Request.QueryString["Parameter"].ToString();

            try
            {
                String cs = "Server=127.0.0.1; Port=3306; Database=eclinic; Uid=root; Pwd=root";
                //odczyt z tablicy
                using (MySqlConnection conn = new MySqlConnection(cs))
                {
                    conn.Open();
                    String sql = "SELECT * FROM user WHERE login='{0}'";
                    sql = String.Format(sql, tbEditLogin.Text);
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = new MySqlCommand(sql, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    if (table.Rows.Count == 0)
                    {
                        Response.Redirect("VisitUser.aspx?Parameter=" + tbEditLogin.Text);
                    }
                    else
                    {
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        reader.Read();
                        //tbEditLogin.Text = reader["login"].ToString();
                        tbHiddenId.Value = reader["id"].ToString();
                        tbEditFname.Text = reader["fname"].ToString();
                        tbEditLname.Text = reader["lname"].ToString();
                        tbEditEmail.Text = reader["email"].ToString();
                        tbEditPesel.Text = reader["pesel"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                String cs = "Server=127.0.0.1; Port=3306; Database=eclinic; Uid=root; Pwd=root";

                string hashPass = HashPass(tbEditPass.Text);

                String sql = @"UPDATE user SET 
                                login='{0}', password='{1}', fname='{2}', lname='{3}', email='{4}', pesel='{5}'
                                WHERE id='{6}'";
                sql = String.Format(sql, tbEditLogin.Text, hashPass, tbEditFname.Text,
                                    tbEditLname.Text, tbEditEmail.Text, tbEditPesel.Text, Convert.ToInt32(tbHiddenId.Value));
                using (MySqlConnection conn = new MySqlConnection(cs))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    Response.Redirect("VisitUser.aspx?Parameter=" + tbEditLogin.Text);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("VisitUser.aspx?Parameter=" + tbEditLogin.Text);
        }
    }
}