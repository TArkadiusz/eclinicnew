using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace eclinicnew
{
    public partial class AddVisit : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            lblLogin.Text = Request.QueryString["Parameter"].ToString();
            String cs = "Server=127.0.0.1; Port=3306; Database=eclinic; Uid=root; Pwd=root";
            //Wypisanie danych użytkownika
            try
            {
                //odczyt danych użytkownika
                using (MySqlConnection conn = new MySqlConnection(cs))
                {
                    conn.Open();
                    String sql = @"SELECT id, fname, lname, email, pesel
                                    FROM user WHERE login='{0}'";
                    sql = String.Format(sql, lblLogin.Text);
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = new MySqlCommand(sql, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    if (table.Rows.Count == 0)
                    {
                        Response.Redirect("VisitUser.aspx?Parameter=" + lblLogin.Text);
                    }
                    else
                    {
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        reader.Read();
                        hfUserId.Value = Convert.ToString(reader["id"]);
                        lblFname.Text = reader["fname"].ToString();
                        lblLname.Text = reader["lname"].ToString();
                        lblEmailUser.Text = reader["email"].ToString();
                        lblPesel.Text = reader["pesel"].ToString();
                        
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            
        }
        public void LoadDataDoctor()
        {

            try
            {
                String cs = "Server=127.0.0.1; Port=3306; Database=eclinic; Uid=root; Pwd=root";
                using (MySqlConnection conn = new MySqlConnection(cs))
                {
                    conn.Open();
                    String sql = @"SELECT id, email
                                    FROM doctor WHERE full_name='{0}'";
                    sql = String.Format(sql, ddlDoctor.Text);
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = new MySqlCommand(sql, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    if (table.Rows.Count == 0)
                    {
                        Response.Redirect("VisitUser.aspx?Parameter=" + lblLogin.Text);
                    }
                    else
                    {
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        reader.Read();
                        hfDocId.Value = Convert.ToString(reader["id"]);
                        hfDocEmail.Value = Convert.ToString(reader["email"]);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("VisitUser.aspx?Parameter=" + lblLogin.Text);
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            LoadDataDoctor();
            string dateTime = String.Format("{0} {1}", tbDate.Text, tbTime.Text);
            String filename = null;
            bool isOK = true;
            if (fuImage.HasFile)
            {
                if (fuImage.PostedFile.ContentType == "image/png")
                {
                    if (fuImage.PostedFile.ContentLength < 500000)
                    {
                        //upload do wskazanego miejsca w aplikacji
                        filename = Guid.NewGuid().ToString("N") + "-" +
                            Path.GetFileName(fuImage.FileName);
                        fuImage.SaveAs(Server.MapPath("~/uploads/") + filename);
                        lblResult.Text = "Wszystko OK";
                        lblResult.ForeColor = Color.Black;
                    }
                    else
                    {
                        lblResult.Text = "Plik za duży";
                        lblResult.ForeColor = Color.Red;
                        isOK = false;
                    }
                }
                else
                {
                    lblResult.Text = "Plik w niepoprawnym formacie";
                    lblResult.ForeColor = Color.Red;
                    isOK = false;
                }
            }

            if (isOK)
            {
                //rozpocznij zapis do bazy
                String cs = "Server=127.0.0.1; Port=3306; Database=eclinic; Uid=root; Pwd=root";
                using (MySqlConnection conn = new MySqlConnection(cs))
                {
                    conn.Open();
                    String sql = @"INSERT INTO visits
                                (user_id, doctor_id, fname, lname, email_user, pesel, doctor, email_doc, visit_date, descr, image)
                                VALUES
                                (@user_id, @doctor_id, @fname, @lname, @email_user, @pesel, @doctor, @email_doc, @visit_date, @descr, @image)
                                ";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.Add("@user_id", MySqlDbType.Int32, 11).Value = Convert.ToInt32(hfUserId.Value);
                    cmd.Parameters.Add("@doctor_id", MySqlDbType.Int32, 11).Value = Convert.ToInt32(hfDocId.Value);
                    cmd.Parameters.Add("@fname", MySqlDbType.VarChar, 50).Value = lblFname.Text;
                    cmd.Parameters.Add("@lname", MySqlDbType.VarChar, 50).Value = lblLname.Text;
                    cmd.Parameters.Add("@email_user", MySqlDbType.VarChar, 255).Value = lblEmailUser.Text;
                    cmd.Parameters.Add("@pesel", MySqlDbType.VarChar, 20).Value = lblPesel.Text;
                    cmd.Parameters.Add("@doctor", MySqlDbType.VarChar, 50).Value = ddlDoctor.SelectedItem;
                    cmd.Parameters.Add("@email_doc", MySqlDbType.VarChar, 255).Value = hfDocEmail.Value;
                    cmd.Parameters.Add("@visit_date", MySqlDbType.DateTime).Value = Convert.ToDateTime(dateTime);
                    cmd.Parameters.Add("@descr", MySqlDbType.MediumText).Value = tbDescr.Text;
                    cmd.Parameters.Add("@image", MySqlDbType.VarChar, 1024).Value = filename;

                    cmd.ExecuteNonQuery();
                    btnOK.Enabled = false;
                    lblResult.Text = "Dziękujemy za zgłoszenie";
                }
            }
        }
    }
}