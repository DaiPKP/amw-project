using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Manager_BookingWeekly : System.Web.UI.Page
{
    public Connection con = new Connection();
    public DataTable data = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string strQuery = "select CityCode,CityName from City where Status = 'Y'";
            DataTable table = new DataTable();
            table = con.ExcuteQuery(strQuery);
            ddlCity.DataSource = table;
            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "CityCode";
            ddlCity.DataBind();
            strQuery = "select CenterCode,CenterName from Center where Status = 'Y' and CityCode = '" + ddlCity.SelectedValue.ToString() + "'";
            table = con.ExcuteQuery(strQuery);
            ddlCenter.DataSource = table;
            ddlCenter.DataTextField = "CenterName";
            ddlCenter.DataValueField = "CenterCode";
            ddlCenter.DataBind();
            strQuery = "select RoomCode,RoomName from Room where Status = 'Y' and CenterCode = '" + ddlCenter.SelectedValue.ToString() + "'";
            table = con.ExcuteQuery(strQuery);
            ddlRoom.DataSource = table;
            ddlRoom.DataTextField = "RoomName";
            ddlRoom.DataValueField = "RoomCode";
            ddlRoom.DataBind();
        }
    }
    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strQuery = "select CenterCode,CenterName from Center where Status = 'Y' and CityCode = '" + ddlCity.SelectedValue.ToString() + "'";
        DataTable table = new DataTable();
        table = con.ExcuteQuery(strQuery);
        ddlCenter.DataSource = table;
        ddlCenter.DataTextField = "CenterName";
        ddlCenter.DataValueField = "CenterCode";
        ddlCenter.DataBind();
        strQuery = "select RoomCode,RoomName from Room where Status = 'Y' and CenterCode = '" + ddlCenter.SelectedValue.ToString() + "'";
        table = con.ExcuteQuery(strQuery);
        ddlRoom.DataSource = table;
        ddlRoom.DataTextField = "RoomName";
        ddlRoom.DataValueField = "RoomCode";
        ddlRoom.DataBind();
    }
    protected void ddlCenter_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strQuery = "select RoomCode,RoomName from Room where Status = 'Y' and CenterCode = '" + ddlCenter.SelectedValue.ToString() + "'";
        DataTable table = new DataTable();
        table = con.ExcuteQuery(strQuery);
        ddlRoom.DataSource = table;
        ddlRoom.DataTextField = "RoomName";
        ddlRoom.DataValueField = "RoomCode";
        ddlRoom.DataBind();
    }
    protected void btDatPhong_Click(object sender, EventArgs e)
    {
        btDatPhong.Enabled = false;
        data.Columns.Add("Date", typeof(DateTime));
        data.Columns.Add("Section", typeof(string));
        int iNam = Int16.Parse(ddlYear.SelectedValue.ToString());
        int iThang = Int16.Parse(ddlMonth.SelectedValue.ToString());
        DateTime startdate = new DateTime(iNam, iThang, 1);
        int dateofmonth = DateTime.DaysInMonth(iNam, iThang);
        DateTime enddate = new DateTime(iNam, iThang, dateofmonth);
        DataTable tb = new DataTable();
        tb = con.ExcuteQuery(startdate, enddate, ddlRoom.SelectedValue.Trim());
        string strStatus = "";
        string strWeekend = "N";
        string strSection = ddlSection.SelectedValue.ToString();
        DayOfWeek day = DayOfWeek.Sunday;
        switch(ddlDayorWeek.SelectedValue.ToString())
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
                foreach (DataRow row in tb.Rows)
                {
                    if (DateTime.Parse(row["Date"].ToString()) == i && row["Section"].ToString().Trim().Equals(strSection))
                    {
                        strStatus = "N";
                    }
                }
                if(strStatus.Equals("Y"))
                {
                    data.Rows.Add(i.Date, strSection);
                }
            }
        }

        SqlParameter[] paras = new SqlParameter[12];
        paras[0] = new SqlParameter("@ADA_ID", txtADAID.Text.Trim());
        paras[1] = new SqlParameter("@ADA_Name", txtName.Text.Trim());
        paras[2] = new SqlParameter("@Phone", txtPhone.Text.Trim());
        paras[3] = new SqlParameter("@Email", txtEmail.Text.Trim());
        paras[4] = new SqlParameter("@Address", txtAddress.Text.Trim());
        paras[5] = new SqlParameter("@RoomCode", ddlRoom.SelectedValue.Trim());
        paras[6] = new SqlParameter("@Type", ddlType.SelectedValue.ToString());
        string strPaid;
        if (chkPaid.Checked == true)
        {
            strPaid = "Y";
        }
        else
        {
            strPaid = "N";
        }
        paras[7] = new SqlParameter("@Paid", strPaid);
        paras[8] = new SqlParameter("@Note", txtNote.Text.Trim());
        paras[9] = new SqlParameter("@DateSection", data);
        paras[10] = new SqlParameter("@Weekend", strWeekend);
        paras[11] = new SqlParameter("@Section", strSection);
        con.ExcuteNonQuery("sp_weekly_booking", paras);
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