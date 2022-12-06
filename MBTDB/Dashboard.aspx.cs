using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace MBTDB
{
    public partial class Dashboard : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter sda = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            con.ConnectionString = "Data Source=DESKTOP-T6DPS83\\SQLEXPRESS; Initial Catalog = mbt_db; Integrated Security = True";
            con.Open();
            if (!Page.IsPostBack)
            {
                DataShow();
            }
        }

        public void DataShow()
        {
            ds = new DataSet();
            cmd.CommandText = "SELECT T.NAME AS \"Tank Name\", T.YEAR_M AS \"Year Introduced\", M.NAME AS \"Manufacturer\", C.NAME AS \"Origin\" FROM MBT T LEFT JOIN MANUFACTURER M ON T.ID_M = M.ID_M LEFT JOIN COUNTRY C ON M.ID_C = C.ID_C";
            cmd.Connection = con;
            sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            GridView1.DataSource = ds;
            GridView1.DataBind();
            con.Close();
        }

        protected void MBTForm_Click(object sender, EventArgs e)
        {
            Response.Redirect("MBTForm.aspx");
        }

        protected void MANUForm_Click(object sender, EventArgs e)
        {
            Response.Redirect("MANUForm.aspx");
        }

        protected void COUNTRYForm_Click(object sender, EventArgs e)
        {
            Response.Redirect("COUNTRYForm.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void Refresh_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "SELECT T.NAME AS \"Tank Name\", T.YEAR_M AS \"Year Introduced\", M.NAME AS \"Manufacturer\", C.NAME AS \"Origin\" FROM MBT T LEFT JOIN MANUFACTURER M ON T.ID_M = M.ID_M LEFT JOIN COUNTRY C ON M.ID_C = C.ID_C";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataShow();
        }
    }
}