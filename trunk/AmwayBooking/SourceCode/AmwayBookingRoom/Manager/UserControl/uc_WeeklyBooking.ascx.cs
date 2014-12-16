using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DAL;

public partial class Manager_UserControl_uc_WeeklyBooking : System.Web.UI.UserControl
{
    public Connection con = new Connection();
    public DataTable data = new DataTable();
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

            List<SP_CENTER_GET_CBO_BY_CITYCODEResult> listCenter = new List<SP_CENTER_GET_CBO_BY_CITYCODEResult>();
            listCenter = BO.GetCenter(ddlCity.SelectedValue.ToString());
            ddlCenter.DataSource = listCenter;
            ddlCenter.DataTextField = "CenterName";
            ddlCenter.DataValueField = "CenterCode";
            ddlCenter.DataBind();

            List<SP_ROOM_GET_CBO_BY_CENTERCODEResult> listRoom = new List<SP_ROOM_GET_CBO_BY_CENTERCODEResult>();
            listRoom = BO.GetRoom(ddlCenter.SelectedValue.ToString());
            ddlRoom.DataSource = listRoom;
            ddlRoom.DataTextField = "RoomName";
            ddlRoom.DataValueField = "RoomCode";
            ddlRoom.DataBind();
        }
    }

    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        CategoryBO BO = new CategoryBO();

        List<SP_CENTER_GET_CBO_BY_CITYCODEResult> listCenter = new List<SP_CENTER_GET_CBO_BY_CITYCODEResult>();
        listCenter = BO.GetCenter(ddlCity.SelectedValue.ToString());
        ddlCenter.DataSource = listCenter;
        ddlCenter.DataTextField = "CenterName";
        ddlCenter.DataValueField = "CenterCode";
        ddlCenter.DataBind();

        List<SP_ROOM_GET_CBO_BY_CENTERCODEResult> listRoom = new List<SP_ROOM_GET_CBO_BY_CENTERCODEResult>();
        listRoom = BO.GetRoom(ddlCenter.SelectedValue.ToString());
        ddlRoom.DataSource = listRoom;
        ddlRoom.DataTextField = "RoomName";
        ddlRoom.DataValueField = "RoomCode";
        ddlRoom.DataBind();
    }
    protected void ddlCenter_SelectedIndexChanged(object sender, EventArgs e)
    {
        CategoryBO BO = new CategoryBO();

        List<SP_ROOM_GET_CBO_BY_CENTERCODEResult> listRoom = new List<SP_ROOM_GET_CBO_BY_CENTERCODEResult>();
        listRoom = BO.GetRoom(ddlCenter.SelectedValue.ToString());
        ddlRoom.DataSource = listRoom;
        ddlRoom.DataTextField = "RoomName";
        ddlRoom.DataValueField = "RoomCode";
        ddlRoom.DataBind();
    }
    protected void btDatPhong_Click(object sender, EventArgs e)
    {
        string strData = string.Empty;
        btDatPhong.Enabled = false;
        int iNam = Int16.Parse(ddlYear.SelectedValue.ToString());
        int iThang = Int16.Parse(ddlMonth.SelectedValue.ToString());
        DateTime startdate = new DateTime(iNam, iThang, 1);
        int dateofmonth = DateTime.DaysInMonth(iNam, iThang);
        DateTime enddate = new DateTime(iNam, iThang, dateofmonth);
        RegistryRoomBO BO = new RegistryRoomBO();
        List<SP_REGISTYROOM_GETLISTResult> listBooking = new List<SP_REGISTYROOM_GETLISTResult>();
        listBooking = BO.GetListBooking(ddlRoom.SelectedValue.Trim(), startdate, enddate);
        string strStatus = "";
        string strWeekend = "N";
        string strSection = ddlSection.SelectedValue.ToString();
        DayOfWeek day = DayOfWeek.Sunday;
        switch (ddlDayorWeek.SelectedValue.ToString())
        {
            case "Monday":
                day = DayOfWeek.Monday;
                strWeekend = "N";
                break;
            case "Tuesday":
                day = DayOfWeek.Tuesday;
                strWeekend = "N";
                break;
            case "Wednesday":
                day = DayOfWeek.Wednesday;
                strWeekend = "N";
                break;
            case "Thursday":
                day = DayOfWeek.Thursday;
                strWeekend = "N";
                break;
            case "Friday":
                day = DayOfWeek.Friday;
                strWeekend = "N";
                break;
            case "Saturday":
                day = DayOfWeek.Saturday;
                strWeekend = "Y";
                break;
            case "Sunday":
                day = DayOfWeek.Sunday;
                strWeekend = "Y";
                break;
        }
        for (DateTime i = startdate; i <= enddate; i = i.AddDays(1))
        {
            if (i.DayOfWeek == day)
            {
                strStatus = "Y";
                foreach (SP_REGISTYROOM_GETLISTResult row in listBooking)
                {
                    if (row.Date == i && row.Section.ToString().Trim().Equals(strSection))
                    {
                        strStatus = "N";
                    }
                }
                if (strStatus.Equals("Y"))
                {
                    strData=strData+i.Date.ToString()+"@";
                }
            }
        }

        Char strPaid;
        if (chkPaid.Checked == true)
        {
            strPaid = 'Y';
        }
        else
        {
            strPaid = 'N';
        }
        RegistryRoom refRoom = new RegistryRoom();
        RegistryRoomBO refRoomBO = new RegistryRoomBO();
        refRoom.ADA_ID= txtADAID.Text.Trim();
        refRoom.ADA_Name= txtName.Text.Trim();
        refRoom.Phone= txtPhone.Text.Trim();
        refRoom.Email= txtEmail.Text.Trim();
        refRoom.Address= txtAddress.Text.Trim();
        refRoom.RoomCode= ddlRoom.SelectedValue.Trim();
        refRoom.Type= ddlType.SelectedValue.ToString();
        refRoom.Paid= strPaid;
        refRoom.Weekend= Char.Parse(strWeekend);
        refRoom.Section = strSection; 
        refRoom.Note=txtNote.Text.Trim();

        refRoomBO.InsertWeeklyBooking(strData,refRoom);
        txtADAID.Text = "";
        txtName.Text = "";
        txtPhone.Text = "";
        txtEmail.Text = "";
        txtAddress.Text = "";
        txtNote.Text = "";
        chkPaid.Checked = false;
        btDatPhong.Enabled = true;
        Response.Redirect("/Manager/BookingRoom.aspx?RoomCode=" + ddlRoom.SelectedValue.ToString() + "&CityCode=" + ddlCity.SelectedValue.ToString() + "&CenterCode=" + ddlCenter.SelectedValue.ToString() + "&Month=" + ddlMonth.SelectedValue.ToString() + "&Year=" + ddlYear.SelectedValue.ToString());
    }
}