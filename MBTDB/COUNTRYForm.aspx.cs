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
    public partial class COUNTRYForm : System.Web.UI.Page
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
            cmd.CommandText = "SELECT ID_C AS \"ID\", NAME AS \"Name\", CONTINENT AS \"Continent\", GDP_CAPITA \"GDP per Capita (USD)\" FROM COUNTRY WHERE VISIBLE=1";
            cmd.Connection = con;
            sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            GridView1.DataSource = ds;
            GridView1.DataBind();
            con.Close();
        }

        protected void Dashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }

        protected void Refresh_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "SELECT ID_C AS \"ID\", NAME AS \"Name\", CONTINENT AS \"Continent\", GDP_CAPITA \"GDP per Capita (USD)\" FROM COUNTRY WHERE VISIBLE=1";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataShow();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtID_C.Text == "" || txtNAME.Text == "" || txtCONTINENT.Text == "" || txtGDP.Text == "") { Response.Write("Please fill all the form."); }
            else
            {
                dt = new DataTable();
                cmd.CommandText = "INSERT INTO COUNTRY VALUES ('" + txtID_C.Text + "','" + txtNAME.Text.ToString() + "','" + txtCONTINENT.Text.ToString() + "','" + txtGDP.Text + "',1)";
                cmd.Connection = con;
                try { cmd.ExecuteNonQuery(); DataShow(); }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }

        protected void btnSoftDelete_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "UPDATE COUNTRY SET VISIBLE = 0 WHERE ID_C = " + txtID_C.Text;
            cmd.Connection = con; cmd.ExecuteNonQuery(); DataShow();
        }

        protected void btnHardDelete_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "DELETE FROM COUNTRY WHERE ID_C=" + txtID_C.Text;
            cmd.Connection = con; cmd.ExecuteNonQuery(); DataShow();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtID_C.Text == "" || txtNAME.Text == "" || txtCONTINENT.Text == "" || txtGDP.Text == "") { Response.Write("Please fill all the form."); }
            else
            {
                dt = new DataTable();
                cmd.CommandText = "UPDATE COUNTRY NAME='" + txtNAME.Text.ToString() + "',CONTINENT='" + txtCONTINENT.Text.ToString() + "', GDP_CAPITA='" + txtGDP.Text + "', VISIBLE=1 WHERE ID_C='" + txtID_C.Text + "'";
                cmd.Connection = con;
                try { cmd.ExecuteNonQuery(); DataShow(); }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }

        protected void btnRestore_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "UPDATE COUNTRY SET VISIBLE=1 WHERE ID_C=" + txtID_C.Text;
            cmd.Connection = con; cmd.ExecuteNonQuery(); DataShow();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            cmd.CommandText = "SELECT ID_C AS \"ID\", NAME AS \"Name\", CONTINENT AS \"Continent\", GDP_CAPITA AS \"GDP per Capita (USD)\" FROM COUNTRY WHERE VISIBLE=1 AND NAME LIKE '%" + txtSEARCH.Text.ToString() + "%'";
            cmd.Connection = con;
            sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            GridView1.DataSource = ds;
            GridView1.DataBind();
            con.Close();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtID_C.Text = null;
            txtNAME.Text = null;
            txtCONTINENT.Text = null;
            txtGDP.Text = null;
        }
    }
}