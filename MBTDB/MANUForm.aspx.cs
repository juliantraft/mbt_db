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
    public partial class MANUForm : System.Web.UI.Page
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
            cmd.CommandText = "SELECT ID_M AS \"ID\", NAME AS \"Name\", FOUNDED AS \"Year Founded\", CEO, ID_C AS \"Country ID\" FROM MANUFACTURER WHERE VISIBLE=1";
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
            cmd.CommandText = "SELECT ID_M AS \"ID\", NAME AS \"Name\", FOUNDED AS \"Year Founded\", CEO, ID_C AS \"Country ID\" FROM MANUFACTURER WHERE VISIBLE=1";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataShow();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtID_M.Text == "" || txtNAME.Text == "" || txtFOUNDED.Text == "" || txtCEO.Text == "" || txtID_C.Text == "") { Response.Write("Please fill all the form."); }
            else
            {
                dt = new DataTable();
                cmd.CommandText = "INSERT INTO MANUFACTURER VALUES ('" + txtID_M.Text + "','" + txtNAME.Text.ToString() + "','" + txtFOUNDED.Text + "','" + txtCEO.Text.ToString() + "','" + txtID_C.Text + "', 1)";
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
            cmd.CommandText = "UPDATE MANUFACTURER SET VISIBLE = 0 WHERE ID_M = " + txtID_M.Text;
            cmd.Connection = con; cmd.ExecuteNonQuery(); DataShow();
        }

        protected void btnHardDelete_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "DELETE FROM MANUFACTURER WHERE ID_M=" + txtID_M.Text;
            cmd.Connection = con; cmd.ExecuteNonQuery(); DataShow();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtID_M.Text == "" || txtNAME.Text == "" || txtFOUNDED.Text == "" || txtCEO.Text == "" || txtID_C.Text == "") { Response.Write("Please fill all the form."); }
            else
            {
                dt = new DataTable();
                cmd.CommandText = "UPDATE MANUFACTURER NAME='" + txtNAME.Text.ToString() + "', FOUNDED='" + txtFOUNDED.Text + "', CEO='" + txtCEO.Text.ToString() + "', ID_C='" + txtID_C.Text + "', VISIBLE=1 WHERE ID_M='" + txtID_M.Text + "'";
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
            cmd.CommandText = "UPDATE MANUFACTURER SET VISIBLE=1 WHERE ID_M=" + txtID_M.Text;
            cmd.Connection = con; cmd.ExecuteNonQuery(); DataShow();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            cmd.CommandText = "SELECT ID_M AS \"ID\", NAME AS \"Name\", FOUNDED AS \"Year Founded\", CEO, ID_C AS \"Country ID\" FROM MANUFACTURER WHERE VISIBLE=1 AND NAME LIKE '%" + txtSEARCH.Text.ToString() + "%'";
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
            txtID_M.Text = null;
            txtNAME.Text = null;
            txtFOUNDED.Text = null;
            txtCEO.Text = null;
            txtID_C.Text = null;
        }
    }
}