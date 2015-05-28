using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;
using System.Web.Security;
using System.Collections;
using AjaxControlToolkit;
namespace IceCream
{
    using System.Collections;
    using System.Configuration;
    using System.Data.SqlClient;

    public partial class IceCreamNew : System.Web.UI.Page
    {
        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnString"].ToString());
        SqlCommand cmd;
        string qry;
        ArrayList myArrayList = new ArrayList();
        TextBox txtQuantity = new TextBox();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindDropDownList();
                SetInitialRow();
                //findid();
            }
        }
        protected void findid()
        {
            qry = "select MAX (Production_No) from  BOMM";
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                if (dr.GetValue(0).ToString() == "")
                {
                    txtproductionno.Text = "1";
                }

                else
                {
                    txtproductionno.Text = Convert.ToString(Convert.ToInt32(dr.GetValue(0).ToString()) + 1);
                }
                dr.Close();
            }
        }
        protected void BindGridview()
        {
            if (con.State == ConnectionState.Closed)
            {

                con.Open();
            }

            SqlCommand cmd = new SqlCommand("select * from item_sugrpMaster", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (con.State == ConnectionState.Open)
            {

                con.Close();
            }

            gv1.DataSource = ds;
            gv1.DataBind();
        }
        private void BindDropDownList()
        {
            //SqlConnection con = new SqlConnection(qry);
            string com = "Select * from item_master where saleItem='Y'";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            ddlfinishgood.DataSource = ds;
            ddlfinishgood.DataBind();
            ddlfinishgood.DataTextField = "item_name";
            ddlfinishgood.DataValueField = "item_id";
            ddlfinishgood.DataBind();
            ddlfinishgood.Items.Insert(0, new ListItem(" select", "0"));

            string com1 = "Select * from UnitMaster ";
            SqlDataAdapter adpt1 = new SqlDataAdapter(com1, con);
            DataSet ds1 = new DataSet();
            adpt1.Fill(ds1);
            ddlunit.DataSource = ds1;
            ddlunit.DataBind();
            ddlunit.DataTextField = "UnitName";
            ddlunit.DataValueField = "UnitId";
            ddlunit.DataBind();
            ddlunit.Items.Insert(0, new ListItem(" select", "0"));

            //Adding "Please select" option in dropdownlist for validation



        }
        private ArrayList GetDummyData()
        {

            ArrayList arr = new ArrayList();
            arr.Add(new ListItem("Item1", "1"));
            arr.Add(new ListItem("Item2", "2"));
            arr.Add(new ListItem("Item3", "3"));
            arr.Add(new ListItem("Item4", "4"));
            arr.Add(new ListItem("Item5", "5"));
            return arr;
        }

        private void FillDropDownListUnit(DropDownList ddl)
        {
            string cmdtstr = "select * from UnitMaster";
            SqlCommand cmd = new SqlCommand(cmdtstr, con);
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            ddl.DataSource = dt;
            ddl.DataTextField = "UnitName";
            ddl.DataValueField = "UnitId";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("--Select--", "0"));
            //foreach (ListItem item in arr)
            //{
            //    ddl.Items.Add(item);


        }
        //}
        private void itemsubgrp(DropDownList ddr)
        {
            string cmdtstr = "select * from item_sugrpMaster";
            //  SqlCommand cmd = new SqlCommand(cmdtstr, con);
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmdtstr, con);
            adp.Fill(dt);
            ddr.DataSource = dt;
            ddr.DataTextField = "item_subgrpname";
            ddr.DataValueField = "item_subgrpid";
            ddr.DataBind();
            ddr.Items.Insert(0, new ListItem("--Select--", "0"));
            //foreach (ListItem item in arr)
            //{
            //    ddl.Items.Add(item);
            //}
        }

        private void itemgrp(DropDownList ddr1)
        {
            string cmdtstr = "select * from item_master";
            //  SqlCommand cmd = new SqlCommand(cmdtstr, con);
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmdtstr, con);
            adp.Fill(dt);
            ddr1.DataSource = dt;
            ddr1.DataTextField = "item_name";
            ddr1.DataValueField = "item_id";
            ddr1.DataBind();
            ddr1.Items.Insert(0, new ListItem("--Select--", "0"));
            //foreach (ListItem item in arr)
            //{
            //    ddl.Items.Add(item);
            //}
        }




        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;

            //Define the Columns
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));
            dt.Columns.Add(new DataColumn("Column3", typeof(string)));
            dt.Columns.Add(new DataColumn("Column4", typeof(string)));
            dt.Columns.Add(new DataColumn("Column5", typeof(string)));


            //Add a Dummy Data on Initial Load
            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dt.Rows.Add(dr);

            //Store the DataTable in ViewState
            ViewState["CurrentTable"] = dt;
            //Bind the DataTable to the Grid
            gv1.DataSource = dt;
            gv1.DataBind();

            //Extract and Fill the DropDownList with Data
            DropDownList ddl1 = (DropDownList)gv1.Rows[0].Cells[1].FindControl("ddlitemsubgrp");
            DropDownList ddl2 = (DropDownList)gv1.Rows[0].Cells[2].FindControl("ddlitemgrp");
            TextBox box1 = (TextBox)gv1.Rows[0].Cells[4].FindControl("txtQuantity");
            DropDownList ddl3 = (DropDownList)gv1.Rows[0].Cells[3].FindControl("ddlunit1");
            TextBox box2 = (TextBox)gv1.Rows[0].Cells[5].FindControl("txtProductionDiscription");
            itemsubgrp(ddl1);
            itemgrp(ddl2);
            //FillDropDownListUnit(ddl3);

        }





        private void AddNewRowToGrid()
        {

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;
                    //add new row to DataTable
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    //Store the current data to ViewState
                    ViewState["CurrentTable"] = dtCurrentTable;

                    for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
                    {

                        //extract the DropDownList Selected Items
                        DropDownList ddl1 = (DropDownList)gv1.Rows[i].Cells[1].FindControl("ddlitemsubgrp");
                        DropDownList ddl2 = (DropDownList)gv1.Rows[i].Cells[2].FindControl("ddlitemgrp");
                        TextBox box1 = (TextBox)gv1.Rows[i].Cells[4].FindControl("txtQuantity");
                        DropDownList ddl3 = (DropDownList)gv1.Rows[i].Cells[3].FindControl("ddlunit1");
                        TextBox box2 = (TextBox)gv1.Rows[i].Cells[5].FindControl("txtProductionDiscription");

                        dtCurrentTable.Rows[i]["Column1"] = ddl1.SelectedItem.Text;
                        dtCurrentTable.Rows[i]["Column2"] = ddl2.SelectedItem.Text;
                        dtCurrentTable.Rows[i]["Column4"] = ddl3.SelectedItem.Text;
                        dtCurrentTable.Rows[i]["Column3"] = box1.Text;
                        dtCurrentTable.Rows[i]["Column5"] = box2.Text;
                    }

                    //Rebind the Grid with the current data
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
                        TextBox box1 = (TextBox)gv1.Rows[i].Cells[3].FindControl("txtQuantity");
                        TextBox box2 = (TextBox)gv1.Rows[i].Cells[5].FindControl("txtProductionDiscription");
                        //Set the Previous Selected Items on Each DropDownList on Postbacks
                        DropDownList ddl1 = (DropDownList)gv1.Rows[rowIndex].Cells[1].FindControl("ddlitemsubgrp");
                        DropDownList ddl2 = (DropDownList)gv1.Rows[rowIndex].Cells[3].FindControl("ddlitemgrp");
                        // TextBox txt1 = (TextBox)gv1.Rows[rowIndex].Cells[3].FindControl("txtQuantity");
                        DropDownList ddl3 = (DropDownList)gv1.Rows[rowIndex].Cells[4].FindControl("ddlunit1");
                        // TextBox txt2 = (TextBox)gv1.Rows[rowIndex].Cells[5].FindControl("txtProductionDiscription");
                        itemsubgrp(ddl1);
                        // itemsubgrp(ddl1);
                        itemgrp(ddl2);
                        FillDropDownListUnit(ddl3);


                        if (i < dt.Rows.Count - 1)
                        {
                            box1.Text = dt.Rows[i]["Column3"].ToString();
                            box2.Text = dt.Rows[i]["Column5"].ToString();
                            ddl1.ClearSelection();
                            ddl1.Items.FindByText(dt.Rows[i]["Column1"].ToString()).Selected = true;

                            ddl2.ClearSelection();
                            ddl2.Items.FindByText(dt.Rows[i]["Column2"].ToString()).Selected = true;

                            ddl3.ClearSelection();
                            ddl3.Items.FindByText(dt.Rows[i]["Column4"].ToString()).Selected = true;
                        }

                        rowIndex++;
                    }
                }
            }
        }
        protected void btnAddRow_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }

        protected void gv1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }



        protected void btnsave_Click(object sender, EventArgs e)
        {
            DropDownList ddlitemgrp;
            DropDownList ddlitemsubgrp;
            TextBox txtQuantity;
            TextBox txtProductionDiscription;
            foreach (GridViewRow row in gv1.Rows)
            {
                ddlitemsubgrp = row.FindControl("ddlitemsubgrp") as DropDownList;
                ddlitemgrp = row.FindControl("ddlitemgrp") as DropDownList;
                txtQuantity = row.FindControl("txtQuantity") as TextBox;
                txtProductionDiscription = row.FindControl("txtQuantity") as TextBox;
                cmd = new SqlCommand("insert into BOMD (BomMId,ItemId,Item_Description,Item_Quantity)values('" + ddlitemsubgrp.SelectedValue + "','" + ddlitemgrp.SelectedValue + "','" + txtQuantity.Text + "','" + txtProductionDiscription.Text + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();

            }
            cmd = new SqlCommand("insert into BOMM (Production_No,FinishGood_Quantity,Production_Discription,Bom_Type,item_finishgoodid,unitId)values('" + txtproductionno.Text + "','" + txtqua1.Text + "','" + txtdiscription.Text + "','" + ddlbom.SelectedItem + "','" + ddlfinishgood.SelectedValue + "','" + ddlunit.SelectedValue + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }


        protected void ddlitemsubgrp_SelectedIndexChanged(object sender, EventArgs e)
        {

            DropDownList ddlitemsubgrp = sender as DropDownList;
            GridViewRow currentRow = (GridViewRow)ddlitemsubgrp.NamingContainer;
            DropDownList ddlitemgrp = (DropDownList)currentRow.FindControl("ddlitemgrp");
            int item_subgrpid = Convert.ToInt32(ddlitemsubgrp.SelectedValue);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from item_master where item_subgrpid=" + item_subgrpid, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            ddlitemgrp.DataSource = ds;
            ddlitemgrp.DataTextField = "item_name";
            ddlitemgrp.DataValueField = "item_id";
            ddlitemgrp.DataBind();
            ddlitemgrp.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        protected void gv1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable"] = dt;
                    gv1.DataSource = dt;
                    gv1.DataBind();

                    for (int i = 0; i < gv1.Rows.Count - 1; i++)
                    {
                        gv1.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    }
                    SetPreviousData();
                }
            }

        }
    }
}