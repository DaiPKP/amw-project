using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DAL;

public partial class Manager_UserControl_uc_MonthlyBooking : System.Web.UI.UserControl
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
        string strDSDateTime = string.Empty;
        string strDSSection = string.Empty;
        btDatPhong.Enabled = false;
        data.Columns.Add("Date", typeof(DateTime));
        data.Columns.Add("Section", typeof(string));
        int iNam = Int16.Parse(ddlYear.SelectedValue.ToString());
        int iThang = Int16.Parse(ddlMonth.SelectedValue.ToString());
        DateTime startdate = new DateTime(iNam, iThang, 1);
        int dateofmonth = DateTime.DaysInMonth(iNam, iThang);
        DateTime enddate = new DateTime(iNam, iThang, dateofmonth);

        RegistryRoomBO BO = new RegistryRoomBO();
        List<SP_REGISTYROOM_GETLISTResult> listBooking = new List<SP_REGISTYROOM_GETLISTResult>();
        listBooking = BO.GetListBooking(ddlRoom.SelectedValue.Trim(), startdate, enddate);

        string strCa1 = "";
        string strCa2 = "";
        for (DateTime i = startdate; i <= enddate; i = i.AddDays(1))
        {
            strCa1 = strCa2 = "Y";
            if (i.DayOfWeek != DayOfWeek.Sunday && i.DayOfWeek != DayOfWeek.Saturday)
            {
                foreach (SP_REGISTYROOM_GETLISTResult row in listBooking)
                {
                    if (row.Date == i)
                    {
                        if (row.Section.ToString().Equals("Ca Sáng"))
                        {
                            strCa1 = "N";
                        }
                        if (row.Section.ToString().Equals("Ca Chiều"))
                        {
                            strCa2 = "N";
                        }
                    }
                }

                if (strCa1.Equals("Y"))
                {
                    strDSDateTime = strDSDateTime + i.Date.ToString() + "@";
                    strDSSection = strDSSection + "Ca Sáng@";
                }
                if (strCa2.Equals("Y"))
                {
                    strDSDateTime = strDSDateTime + i.Date.ToString() + "@";
                    strDSSection = strDSSection + "Ca Chiều@";
                }
            }
        }
        string strPaid;
        if (chkPaid.Checked == true)
        {
            strPaid = "Y";
        }
        else
        {
            strPaid = "N";
        }

        RegistryRoom refRoom = new RegistryRoom();
        RegistryRoomBO refRoomBO = new RegistryRoomBO();
        refRoom.ADA_ID = txtADAID.Text.Trim();
        refRoom.ADA_Name = txtName.Text.Trim();
        refRoom.Phone = txtPhone.Text.Trim();
        refRoom.Email = txtEmail.Text.Trim();
        refRoom.Address = txtAddress.Text.Trim();
        refRoom.RoomCode = ddlRoom.SelectedValue.Trim();
        refRoom.Type = ddlType.SelectedValue.ToString();
        refRoom.Paid = Char.Parse(strPaid);
        refRoom.Note = txtNote.Text.Trim();
        refRoomBO.InsertMonthlyBooking(strDSDateTime, strDSSection, refRoom);

        txtADAID.Text = "";
        txtName.Text = "";
        txtPhone.Text = "";
        txtEmail.Text = "";
        txtAddress.Text = "";
        txtNote.Text = "";
        chkPaid.Checked = false;
        btDatPhong.Enabled = true;
        //Response.Redirect("/Manager/BookingRoom.aspx?RoomCode=" + ddlRoom.SelectedValue.Trim());
        Response.Redirect("/Manager/BookingRoom.aspx?RoomCode=" + ddlRoom.SelectedValue.ToString() + "&CityCode=" + ddlCity.SelectedValue.ToString() + "&CenterCode=" + ddlCenter.SelectedValue.ToString() + "&Month=" + ddlMonth.SelectedValue.ToString() + "&Year=" + ddlYear.SelectedValue.ToString());
    }
}