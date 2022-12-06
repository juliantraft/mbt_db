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
    public partial class MBTForm : System.Web.UI.Page
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
            cmd.CommandText = "SELECT ID_T AS \"ID\", NAME AS \"Name\", YEAR_M AS \"Year Introduced\", CREW AS \"Crew Number\", COST AS \"Cost (in million USD)\", ID_M AS \"Manufacturer ID\" FROM MBT WHERE VISIBLE = 1";
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
            cmd.CommandText = "SELECT ID_T AS \"ID\", NAME AS \"Name\", YEAR_M AS \"Year Introduced\", CREW AS \"Crew Number\", COST AS \"Cost (in million USD)\", ID_M AS \"Manufacturer ID\" FROM MBT WHERE VISIBLE = 1";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataShow();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtID_T.Text == "" || txtNAME.Text == "" || txtYEAR_M.Text == "" || txtCREW.Text == "" || txtCOST.Text == "" || txtID_M.Text == "") { Response.Write("Please fill all the form."); }
            else
            {
                dt = new DataTable();
                cmd.CommandText = "INSERT INTO MBT VALUES ('" + txtID_T.Text + "', '" + txtNAME.Text.ToString() + "','" + txtYEAR_M.Text + "','" + txtCREW.Text + "','" + txtCOST.Text + "','" + txtID_M.Text + "', 1)";
                cmd.Connection = con; ;
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
            cmd.CommandText = "UPDATE MBT SET VISIBLE = 0 WHERE ID_T = " + txtID_T.Text;
            cmd.Connection = con; cmd.ExecuteNonQuery(); DataShow();
        }

        protected void btnHardDelete_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "DELETE FROM MBT WHERE ID_T=" + txtID_T.Text;
            cmd.Connection = con; cmd.ExecuteNonQuery(); DataShow();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtID_T.Text == "" || txtNAME.Text == "" || txtYEAR_M.Text == "" || txtCREW.Text == "" || txtCOST.Text == "" || txtID_M.Text == "") { Response.Write("Please fill all the form."); }
            else
            {
                dt = new DataTable();
                cmd.CommandText = "UPDATE MBT SET NAME='" + txtNAME.Text.ToString() + "', YEAR_M='" + txtYEAR_M.Text + "', CREW='" + txtCREW.Text + "', COST='" + txtCOST.Text + "', ID_M='" + txtID_M.Text + "', VISIBLE=1 WHERE ID_T='" + txtID_T.Text + "'";
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
            cmd.CommandText = "UPDATE MBT SET VISIBLE=1 WHERE ID_T=" + txtID_T.Text;
            cmd.Connection = con; cmd.ExecuteNonQuery(); DataShow();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            cmd.CommandText = "SELECT ID_T AS \"ID\", NAME AS \"Name\", YEAR_M AS \"Year Introduced\", CREW AS \"Crew Number\", COST AS \"Cost (in million USD)\", ID_M AS \"Manufacturer ID\" FROM MBT WHERE VISIBLE = 1 AND NAME LIKE '%" + txtSEARCH.Text.ToString() + "%'";
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
            txtID_T.Text = null;
            txtNAME.Text = null;
            txtYEAR_M.Text = null;
            txtCREW.Text = null;
            txtCOST.Text = null;
            txtID_M.Text = null;
        }
    }
}