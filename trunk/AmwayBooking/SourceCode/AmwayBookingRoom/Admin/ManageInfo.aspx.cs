using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ManageInfo : System.Web.UI.Page
{
    Connection con = new Connection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string strQuery = "select CityCode,CityName from City where Status = 'Y'";
            DataTable table = new DataTable();
            table = con.ExcuteQuery(strQuery);
            ddlCenterCity.DataSource = table;
            ddlCenterCity.DataTextField = "CityName";
            ddlCenterCity.DataValueField = "CityCode";
            ddlCenterCity.DataBind();
            DataTable tb = new DataTable();
            String strQuery2 = "Select * from Center where [Status] = 'Y'";
            tb = con.ExcuteQuery(strQuery2);
            ddlCenter.DataSource = tb;
            ddlCenter.DataTextField = "CenterName";
            ddlCenter.DataValueField = "CenterCode";
            ddlCenter.DataBind();
        }
    }
    protected void gridview1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gridviewCity.SelectedRow;
        txtCityCode.Text = row.Cells[1].Text.ToString();
        txtCityName.Text = HttpUtility.HtmlDecode(row.Cells[2].Text.ToString());
        ddlStatus.Text = row.Cells[3].Text.ToString();
        txtCityCode.Enabled = false;
    }
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        SqlParameter[] paras = new SqlParameter[3];
        paras[0] = new SqlParameter("@CityCode", txtCityCode.Text.Trim());
        paras[1] = new SqlParameter("@CityName", txtCityName.Text.Trim());
        paras[2] = new SqlParameter("@Status", ddlStatus.Text);
        con.ExcuteNonQuery("sp_insert_city", paras);
        txtCityCode.Text = "";
        txtCityName.Text = "";
        gridviewCity.DataBind();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        SqlParameter[] paras = new SqlParameter[3];
        paras[0] = new SqlParameter("@CityCode", txtCityCode.Text.Trim());
        paras[1] = new SqlParameter("@CityName", txtCityName.Text.Trim());
        paras[2] = new SqlParameter("@Status", ddlStatus.Text);
        con.ExcuteNonQuery("sp_update_city", paras);
        txtCityCode.Text = "";
        txtCityName.Text = "";
        gridviewCity.DataBind();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtCityCode.Text = "";
        txtCityName.Text = "";
        txtCityCode.Enabled = true;
    }
    protected void GridViewRoom_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridViewRoom.SelectedRow;
        txtRoomCode.Text = row.Cells[1].Text.ToString();
        txtRoomName.Text = HttpUtility.HtmlDecode( row.Cells[2].Text.ToString());
        ddlCenter.SelectedValue = row.Cells[3].Text.ToString();
        txtAmount.Text = row.Cells[4].Text.ToString();
        txtPriceMorning.Text = row.Cells[5].Text.ToString();
        txtPriceAfternoon.Text = row.Cells[6].Text.ToString();
        txtPriceEvening.Text = row.Cells[7].Text.ToString();
        txtPriceWeenkendMorning.Text = row.Cells[8].Text.ToString();
        txtPriceWeekendAfternoon.Text = row.Cells[9].Text.ToString();
        txtPriceWeekendEvening.Text = row.Cells[10].Text.ToString();
        txtPriceBookingMonthly.Text = row.Cells[11].Text.ToString();
        ddlRoomStatus.Text = row.Cells[12].Text.ToString();
        txtRoomCode.Enabled = false;
    }
    protected void btnInsertRoom_Click(object sender, EventArgs e)
    {
        SqlParameter[] paras = new SqlParameter[12];
        paras[0] = new SqlParameter("@RoomCode", txtRoomCode.Text.Trim());
        paras[1] = new SqlParameter("@RoomName", txtRoomName.Text.Trim());
        paras[2] = new SqlParameter("@CenterCode", ddlCenter.SelectedValue.Trim());
        paras[3] = new SqlParameter("@Amount", Int16.Parse(txtAmount.Text.Trim()));
        paras[4] = new SqlParameter("@PriceMorning", float.Parse(txtPriceMorning.Text.Trim()));
        paras[5] = new SqlParameter("@PriceAfternoon", float.Parse(txtPriceAfternoon.Text.Trim()));
        paras[6] = new SqlParameter("@PriceEvening", float.Parse(txtPriceEvening.Text.Trim()));
        paras[7] = new SqlParameter("@PriceWeekendMorning", float.Parse(txtPriceWeenkendMorning.Text.Trim()));
        paras[8] = new SqlParameter("@PriceWeekendAfternoon", float.Parse(txtPriceWeekendAfternoon.Text.Trim()));
        paras[9] = new SqlParameter("@PriceWeekendEvening", float.Parse(txtPriceWeekendEvening.Text.Trim()));
        paras[10] = new SqlParameter("@PriceBookingMonthly", float.Parse(txtPriceBookingMonthly.Text.Trim()));
        paras[11] = new SqlParameter("@Status", ddlRoomStatus.Text);
        con.ExcuteNonQuery("sp_insert_room", paras);
        GridViewRoom.DataBind();
        txtRoomCode.Text = "";
        txtRoomName.Text = "";
        txtAmount.Text = "0";
        txtPriceMorning.Text = "0";
        txtPriceAfternoon.Text = "0";
        txtPriceEvening.Text = "0";
        txtPriceWeenkendMorning.Text = "0";
        txtPriceWeekendAfternoon.Text = "0";
        txtPriceWeekendEvening.Text = "0";
        txtPriceBookingMonthly.Text = "0";
    }
    protected void btnUpdateRoom_Click(object sender, EventArgs e)
    {
        SqlParameter[] paras = new SqlParameter[12];
        paras[0] = new SqlParameter("@RoomCode", txtRoomCode.Text.Trim());
        paras[1] = new SqlParameter("@RoomName", txtRoomName.Text.Trim());
        paras[2] = new SqlParameter("@CenterCode", ddlCenter.SelectedValue.Trim());
        paras[3] = new SqlParameter("@Amount", Int16.Parse(txtAmount.Text.Trim()));
        paras[4] = new SqlParameter("@PriceMorning", float.Parse(txtPriceMorning.Text.Trim()));
        paras[5] = new SqlParameter("@PriceAfternoon", float.Parse(txtPriceAfternoon.Text.Trim()));
        paras[6] = new SqlParameter("@PriceEvening", float.Parse(txtPriceEvening.Text.Trim()));
        paras[7] = new SqlParameter("@PriceWeekendMorning", float.Parse(txtPriceWeenkendMorning.Text.Trim()));
        paras[8] = new SqlParameter("@PriceWeekendAfternoon", float.Parse(txtPriceWeekendAfternoon.Text.Trim()));
        paras[9] = new SqlParameter("@PriceWeekendEvening", float.Parse(txtPriceWeekendEvening.Text.Trim()));
        paras[10] = new SqlParameter("@PriceBookingMonthly", float.Parse(txtPriceBookingMonthly.Text.Trim()));
        paras[11] = new SqlParameter("@Status", ddlRoomStatus.Text);
        con.ExcuteNonQuery("sp_update_room", paras);
        GridViewRoom.DataBind();
    }
    protected void btnClearRoom_Click(object sender, EventArgs e)
    {
        txtRoomCode.Enabled = true;
        txtRoomCode.Text = "";
        txtRoomName.Text = "";
        txtAmount.Text = "0";
        txtPriceMorning.Text = "0";
        txtPriceAfternoon.Text = "0";
        txtPriceEvening.Text = "0";
        txtPriceWeenkendMorning.Text = "0";
        txtPriceWeekendAfternoon.Text = "0";
        txtPriceWeekendEvening.Text = "0";
        txtPriceBookingMonthly.Text = "0";
    }
    protected void GridViewCenter_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridViewCenter.SelectedRow;
        txtCenterCode.Text = row.Cells[1].Text.ToString();
        txtCenterCode.Enabled = false;
        ddlCenterCity.SelectedValue = row.Cells[2].Text.ToString();
        txtCenterName.Text = HttpUtility.HtmlDecode( row.Cells[3].Text.ToString());
        txtAddress.Text = HttpUtility.HtmlDecode(row.Cells[4].Text.ToString());
        ddlCenterStatus.Text = row.Cells[5].Text.ToString();
    }
    protected void btnInsertCenter_Click(object sender, EventArgs e)
    {
        SqlParameter[] paras = new SqlParameter[4];
        paras[0] = new SqlParameter("@CenterCode", txtCenterCode.Text.Trim());
        paras[1] = new SqlParameter("@CenterName", txtCenterName.Text.Trim());
        paras[2] = new SqlParameter("@CityCode", ddlCenterCity.SelectedValue.ToString());
        paras[3] = new SqlParameter("@Address", txtAddress.Text.Trim());
        con.ExcuteNonQuery("sp_insert_center", paras);
        GridViewCenter.DataBind();
        txtCenterCode.Text = "";
        txtCenterName.Text = "";
        txtAddress.Text = "";
    }
    protected void btnUpdateCenter_Click(object sender, EventArgs e)
    {
        SqlParameter[] paras = new SqlParameter[5];
        paras[0] = new SqlParameter("@CenterCode", txtCenterCode.Text.Trim());
        paras[1] = new SqlParameter("@CenterName", txtCenterName.Text.Trim());
        paras[2] = new SqlParameter("@CityCode", ddlCenterCity.SelectedValue.ToString());
        paras[3] = new SqlParameter("@Address", txtAddress.Text.Trim());
        paras[4] = new SqlParameter("@Status", ddlCenterStatus.Text);
        con.ExcuteNonQuery("sp_update_center", paras);
        GridViewCenter.DataBind();
        txtCenterCode.Enabled = true;
    }
    protected void btnClearCenter_Click(object sender, EventArgs e)
    {
        txtCenterCode.Enabled = true;
        txtCenterCode.Text = "";
        txtCenterName.Text = "";
        txtAddress.Text = "";
    }
}