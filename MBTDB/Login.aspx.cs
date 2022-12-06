using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace MBTDB
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();

        protected void Submit_Click(object sender, EventArgs e)
        {
            try
            {

                con.ConnectionString = "Data Source=DESKTOP-T6DPS83\\SQLEXPRESS; Initial Catalog = mbt_db; Integrated Security = True";
                string user = txtUSER.Text;
                string pass = txtPASS.Text;
                con.Open();
                string qry = "SELECT * from USERS where NAME='" + user + "' AND PASS='" + pass + "'";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    Response.Redirect("Dashboard.aspx");
                }
                else
                {
                    Label4.Text = "Incorrect Credentials!";

                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}