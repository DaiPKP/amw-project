using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class Admin_UserControl_uc_ManageRoom : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CategoryBO BO = new CategoryBO();
            List<SP_CITY_GET_CBOResult> listCity = new List<SP_CITY_GET_CBOResult>();
            listCity = BO.GetCity();
            ddlCity.DataSource = listCity;
            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "CityCode";
            ddlCity.DataBind();

            ListItem lstParent = new ListItem("--Chọn--", "");
            ddlCity.Items.Insert(0, lstParent);
            ddlCity.SelectedIndex = ddlCity.Items.IndexOf(lstParent);

            List<SP_CENTER_SEARCHResult> ListCenter = new List<SP_CENTER_SEARCHResult>();
            ListCenter = BO.SP_CENTER_SEARCH("", "", "", Char.Parse("Y")).ToList();
            ddlCenter.DataSource = ListCenter;
            ddlCenter.DataTextField = "CenterName";
            ddlCenter.DataValueField = "CenterCode";
            ddlCenter.DataBind();

            ddlCenter.Items.Insert(0, lstParent);
            ddlCenter.SelectedIndex = ddlCity.Items.IndexOf(lstParent);

            LoadRoomGrid("","", "", "", "Y");
        }
    }

    public void LoadRoomGrid(String RoomCode, String CityCode, string CenterCode, String RoomName, String Status)
    {
        Room refRoom = new Room();
        refRoom.RoomCode = RoomCode;
        refRoom.CenterCode = CenterCode;
        refRoom.RoomName = RoomName;
        refRoom.Status = Char.Parse(Status);

        CategoryBO BO = new CategoryBO();
        List<SP_ROOM_SEARCHResult> result = new List<SP_ROOM_SEARCHResult>();
        result = BO.RoomSearch(refRoom, CityCode);
        grdList.DataSource = result;
        grdList.DataBind();
    }

    public void Search(String RoomCode, string CityCode, string CenterCode, String RoomName, String Status)
    {
        Room refRoom = new Room();
        refRoom.RoomCode = RoomCode;
        refRoom.CenterCode = CenterCode;
        refRoom.RoomName = RoomName;
        refRoom.Status = Char.Parse(Status);

        CategoryBO BO = new CategoryBO();
        List<SP_ROOM_SEARCHResult> result = new List<SP_ROOM_SEARCHResult>();
        result = BO.RoomSearch(refRoom, CityCode);
        if (result.Count > 0)
        {
            lblAlerting.Text = string.Empty;
            grdList.DataSource = result;
            grdList.DataBind();
        }
        else
        {
            lblAlerting.Text = "Không có dữ liệu về thành phố phù hợp với yêu cầu tìm kiếm.";
            grdList.DataSource = result;
            grdList.DataBind();
        }

    }

    protected void grdList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblAlerting.Text = string.Empty;
        btSave.Text = "Cập nhật";
        txtRoomCode.Enabled = false;
        grdList.EditIndex = e.NewEditIndex;
        hdfId.Value = grdList.DataKeys[e.NewEditIndex].Value.ToString();
        string strCityCode = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lbCityCode")).Text;
        string strCenterCode = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lbCenterCode")).Text;
        string strRoomCode = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lbRoomCode")).Text; 
        string strRoomName = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lbRoomName")).Text;
        string strAmount = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lbAmount")).Text;
        string strStatus = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lbStatus")).Text;

        string strMorning = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lbMorning")).Text;
        string strAfternoon = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lbAfternoon")).Text;
        string strEvening = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lbEvening")).Text;
        string strWeekendMorning = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lbWeekendMorning")).Text;
        string strWeekendAfternoon = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lbWeekendAfternoon")).Text;
        string strWeekendEvening = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lbWeekendEvening")).Text;
        string strMonthly = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lbMonthly")).Text;

        ddlCity.SelectedValue = strCityCode;
        ddlCenter.SelectedValue = strCenterCode;
        txtRoomCode.Text = strRoomCode;
        txtRoomName.Text = strRoomName;
        txtAmount.Text = strAmount;
        txtPriceMorning.Text = strMorning;
        txtPriceAfternoon.Text = strAfternoon;
        txtPriceEvening.Text = strEvening;
        txtPriceWeekendMorning.Text = strWeekendMorning;
        txtPriceWeekendAfternoon.Text = strWeekendAfternoon;
        txtPriceWeekendEvening.Text = strWeekendEvening;
        txtBookingMonthly.Text = strMonthly;
        if (strStatus.Equals("Y"))
        {
            chkStatus.Checked = true;
        }
        else
        {
            chkStatus.Checked = false;
        }
    }
    protected void btClear_Click(object sender, EventArgs e)
    {
        lblAlerting.Text = string.Empty;
        btSave.Text = "Thêm Mới";
        ddlCity.SelectedValue = "";
        ddlCenter.SelectedValue = "";
        txtRoomCode.Enabled = true;
        txtRoomCode.Text = string.Empty;
        txtRoomName.Text = string.Empty;
        txtAmount.Text = string.Empty;
        chkStatus.Checked = false;

        txtPriceMorning.Text = string.Empty;
        txtPriceAfternoon.Text = string.Empty;
        txtPriceEvening.Text = string.Empty;
        txtPriceWeekendMorning.Text = string.Empty;
        txtPriceWeekendAfternoon.Text = string.Empty;
        txtPriceWeekendEvening.Text = string.Empty;
        txtBookingMonthly.Text = string.Empty;
    }
    protected void btSearch_Click(object sender, EventArgs e)
    {
        string strStatus = "";
        if (chkStatus.Checked)
        {
            strStatus = "Y";
        }
        else
        {
            strStatus = "N";
        }

        Search(txtRoomCode.Text.Trim(),ddlCity.SelectedValue.ToString(),ddlCenter.SelectedValue.ToString(), txtRoomName.Text.Trim(), strStatus);
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        if(ddlCenter.SelectedValue.ToString().Equals(""))
        {
            lblAlerting.Text = "Bạn chưa trung tâm.";
            return;
        }
        if (txtRoomCode.Text.Trim().Equals(string.Empty))
        {
            lblAlerting.Text = "Bạn chưa nhập mã phòng họp.";
            return;
        }
        if (txtRoomName.Text.Trim().Equals(string.Empty))
        {
            lblAlerting.Text = "Bạn chưa nhập tên phòng họp.";
            return;
        }
        Room refRoom = new Room();
        refRoom.CenterCode = ddlCenter.SelectedValue.ToString();
        refRoom.RoomCode = txtRoomCode.Text.Trim();
        refRoom.RoomName = txtRoomName.Text.Trim();
        refRoom.Amount = int.Parse(txtAmount.Text.Trim());
        string strStatus = string.Empty;
        if (chkStatus.Checked)
            strStatus = "Y";
        else
            strStatus = "N";
        refRoom.Status = Char.Parse(strStatus);

        refRoom.PriceMorning = double.Parse(txtPriceMorning.Text.Trim());
        refRoom.PriceAfternoon = double.Parse(txtPriceAfternoon.Text.Trim());
        refRoom.PriceEvening = double.Parse(txtPriceEvening.Text.Trim());
        refRoom.PriceWeekendMorning = double.Parse(txtPriceWeekendMorning.Text.Trim());
        refRoom.PriceWeekendAfternoon = double.Parse(txtPriceWeekendAfternoon.Text.Trim());
        refRoom.PriceWeekendEvening = double.Parse(txtPriceWeekendEvening.Text.Trim());
        refRoom.PriceBookingMonthly = double.Parse(txtBookingMonthly.Text.Trim());
        CategoryBO BO = new CategoryBO();

        if(btSave.Text.Equals("Thêm Mới"))
        {
            lblAlerting.Text = BO.RoomInsert(refRoom);
        }
        else
        {
            lblAlerting.Text = BO.RoomUpdate(refRoom);
        }
        LoadRoomGrid("","","", "", "Y");
    }
    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlCity.SelectedValue.ToString().Equals(""))
        {
            List<SP_CENTER_SEARCHResult> ListCenter = new List<SP_CENTER_SEARCHResult>();
            CategoryBO BO = new CategoryBO();
            ListCenter = BO.SP_CENTER_SEARCH("", "", "", Char.Parse("Y")).ToList();
            ddlCenter.DataSource = ListCenter;
            ddlCenter.DataTextField = "CenterName";
            ddlCenter.DataValueField = "CenterCode";
            ddlCenter.DataBind();

            ListItem lstParent = new ListItem("--Chọn--", "");
            ddlCenter.Items.Insert(0, lstParent);
            ddlCenter.SelectedIndex = ddlCity.Items.IndexOf(lstParent);
        }
        else
        {
            CategoryBO BO = new CategoryBO();

            List<SP_CENTER_GET_CBO_BY_CITYCODEResult> listCenter = new List<SP_CENTER_GET_CBO_BY_CITYCODEResult>();
            listCenter = BO.GetCenter(ddlCity.SelectedValue.ToString());
            ddlCenter.DataSource = listCenter;
            ddlCenter.DataTextField = "CenterName";
            ddlCenter.DataValueField = "CenterCode";
            ddlCenter.DataBind();
            ListItem lstParent = new ListItem("--Chọn--", "");
            ddlCenter.Items.Insert(0, lstParent);
            ddlCenter.SelectedIndex = ddlCity.Items.IndexOf(lstParent);
        }
    }
    protected void grdList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Search(txtRoomCode.Text.Trim(), ddlCity.SelectedValue.ToString(), ddlCenter.SelectedValue.ToString(), txtRoomName.Text.Trim(), "Y");
        grdList.PageIndex = e.NewPageIndex;
        grdList.DataBind();
    }
}