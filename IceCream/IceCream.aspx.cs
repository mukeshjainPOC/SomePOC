using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
namespace IceCream
{
    using System.Collections.ObjectModel;
    using System.Configuration;

    public partial class IceCream : System.Web.UI.Page
    {
        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnString"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetInitialRow();
            }

        }
        private void SetInitialRow()
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from item_sugrpMaster", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                DataTable dt = new DataTable();
                DataRow dr = null;
                dt.Columns.Add(new DataColumn("Quantity", typeof(string)));
                dt.Columns.Add(new DataColumn("Price", typeof(string)));
                dr = dt.NewRow();
                dr["Quantity"] = string.Empty;
                dr["Price"] = string.Empty;
                dt.Rows.Add(dr);
                //Store the DataTable in ViewState
                ViewState["CurrentTable"] = dt;
                BindGridview(dt);
                
            }
            finally
            {
                con.Close();
            }
        }

        protected void BindGridview(DataTable dt)
        {
            gv1.DataSource = dt;
            gv1.DataBind();
           
        }
        protected void gv1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    var ddl1 = (DropDownList)e.Row.FindControl("ddl1");
                    SqlCommand cmd = new SqlCommand("select * from item_sugrpMaster", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    con.Close();
                    ddl1.DataSource = ds;
                    ddl1.DataTextField = "item_subgrpname";
                    ddl1.DataValueField = "item_subgrpid";
                    ddl1.DataBind();
                    ddl1.Items.Insert(0, new ListItem("--Select--", "0"));
                }
                finally
                {
                    con.Close();
                }
            }
        }
        private void AddNewRowToGrid()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values
                        TextBox box1 = (TextBox)gv1.Rows[rowIndex].Cells[2].FindControl("TextBox1");
                        TextBox box2 = (TextBox)gv1.Rows[rowIndex].Cells[3].FindControl("TextBox2");
                        drCurrentRow = dtCurrentTable.NewRow();
                        dtCurrentTable.Rows[i - 1]["Quantity"] = box1.Text;
                        dtCurrentTable.Rows[i - 1]["Price"] = box2.Text;
                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;
                    gv1.DataSource = dtCurrentTable;
                    gv1.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            //Set Previous Data on Postbacks
            SetPreviousData();
        }
        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)gv1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)gv1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                        box1.Text = dt.Rows[i]["Quantity"].ToString();
                        box2.Text = dt.Rows[i]["Price"].ToString();
                        rowIndex++;
                    }
                }
            }
        }

        protected void ddl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList ddl1 = sender as DropDownList;
                GridViewRow currentRow = (GridViewRow)ddl1.NamingContainer;
                DropDownList ddl2 = (DropDownList)currentRow.FindControl("ddl2");
                int item_subgrpid = Convert.ToInt32(ddl1.SelectedValue);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from item_master where item_subgrpid=" + item_subgrpid, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                ddl2.DataSource = ds;
                ddl2.DataTextField = "item_name";
                ddl2.DataValueField = "item_id";
                ddl2.DataBind();
                ddl2.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            finally
            {
                con.Close();
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }
    }
}