using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ReportUtilization : System.Web.UI.Page
{
    public Connection con = new Connection();
    public DataTable data = new DataTable();
    public static string strRoomCode;
    public static string strCode;
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
            //strQuery = "select RoomCode,RoomName from Room where Status = 'Y' and CenterCode = '" + ddlCenter.SelectedValue.ToString() + "'";
            //table = con.ExcuteQuery(strQuery);
            //ddlRoom.DataSource = table;
            //ddlRoom.DataTextField = "RoomName";
            //ddlRoom.DataValueField = "RoomCode";
            //ddlRoom.DataBind();
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
        //strQuery = "select RoomCode,RoomName from Room where Status = 'Y' and CenterCode = '" + ddlCenter.SelectedValue.ToString() + "'";
        //table = con.ExcuteQuery(strQuery);
        //ddlRoom.DataSource = table;
        //ddlRoom.DataTextField = "RoomName";
        //ddlRoom.DataValueField = "RoomCode";
        //ddlRoom.DataBind();
    }
    //protected void ddlCenter_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string strQuery = "select RoomCode,RoomName from Room where Status = 'Y' and CenterCode = '" + ddlCenter.SelectedValue.ToString() + "'";
    //    DataTable table = new DataTable();
    //    table = con.ExcuteQuery(strQuery);
    //    ddlRoom.DataSource = table;
    //    ddlRoom.DataTextField = "RoomName";
    //    ddlRoom.DataValueField = "RoomCode";
    //    ddlRoom.DataBind();
    //}
    protected void btXemBaoCao_Click(object sender, EventArgs e)
    {
        report.Visible = true;
        data.Columns.Add("RoomName", typeof(string));
        data.Columns.Add("NomalMorning", typeof(int));
        data.Columns.Add("NomalAfternoon", typeof(int));
        data.Columns.Add("NomalEvening", typeof(int));
        data.Columns.Add("WeekendMorning", typeof(int));
        data.Columns.Add("WeekendAfternoon", typeof(int));
        data.Columns.Add("WeekendEvening", typeof(int));
        data.Columns.Add("TotalSession", typeof(int));
        data.Columns.Add("Utilization", typeof(float));
        data.Columns.Add("VND", typeof(float));
        data.Columns.Add("USD", typeof(float));
        string strQuery = "select RoomCode,RoomName from Room where Status = 'Y' and CenterCode = '" + ddlCenter.SelectedValue.ToString() + "'";
        DataTable tbRooms = new DataTable();
        tbRooms = con.ExcuteQuery(strQuery);
        strQuery = "select * from RegistryRoom where [Status] = 'Y' and [Date] >= '" + txtFromDate.Text.Trim() + "' and [Date] <= '" + txtToDate.Text.Trim() + "'";
        DataTable tbSection = new DataTable();
        tbSection = con.ExcuteQuery(strQuery);
        int iNomalMorning, iNomalAfternoon, iNomalEvening, iWeekendlMorning, iWeekendAfternoon, iWeekendEvening, iTotalSection;
        float fUtilization, fVND, fUSD;
        int iNomalPlanSection, iWeekendPlanSection, iPlanTotal;
        iNomalPlanSection = iWeekendPlanSection = iPlanTotal = 0;
        for (DateTime i = DateTime.Parse(txtFromDate.Text.Trim()); i <= DateTime.Parse(txtToDate.Text.Trim()); i = i.AddDays(1))
        {
            if (i.DayOfWeek == DayOfWeek.Saturday || i.DayOfWeek == DayOfWeek.Sunday)
            {
                iWeekendPlanSection++;
            }
            else
            {
                iNomalPlanSection++;
            }
        }
        iPlanTotal = iNomalPlanSection * 3 + iWeekendPlanSection * 3;
        lbNonalMorning.Text = lbNomalAfternoon.Text = lbNomalEvening.Text = iNomalPlanSection.ToString();
        lbWeekendMorning.Text = lbWeekendAfternoon.Text = lbWeekendEvening.Text = iWeekendPlanSection.ToString();
        lbTotal.Text = iPlanTotal.ToString();
        foreach (DataRow rowRoom in tbRooms.Rows)
        {
            iNomalMorning = iNomalAfternoon = iNomalEvening = iWeekendlMorning = iWeekendAfternoon = iWeekendEvening = iTotalSection = 0;
            fUtilization = fVND = fUSD = 0;
            foreach (DataRow rowSection in tbSection.Rows)
            {
                if (rowRoom["RoomCode"].ToString().Equals(rowSection["RoomCode"].ToString()))
                {
                    fVND = fVND + float.Parse(rowSection["Price"].ToString());
                    if (rowSection["Section"].ToString().Equals("Ca Sáng"))
                    {
                        if (rowSection["Weekend"].ToString().Equals("N"))
                        {
                            iNomalMorning++;
                        }
                        else
                        {
                            iWeekendlMorning++;
                        }
                    }
                    if (rowSection["Section"].ToString().Equals("Ca Chiều"))
                    {
                        if (rowSection["Weekend"].ToString().Equals("N"))
                        {
                            iNomalAfternoon++;
                        }
                        else
                        {
                            iWeekendAfternoon++;
                        }
                    }
                    if (rowSection["Section"].ToString().Equals("Ca Tối"))
                    {
                        if (rowSection["Weekend"].ToString().Equals("N"))
                        {
                            iNomalEvening++;
                        }
                        else
                        {
                            iWeekendEvening++;
                        }
                    }
                }
            }
            iTotalSection = iNomalMorning + iNomalAfternoon + iNomalEvening + iWeekendlMorning + iWeekendAfternoon + iWeekendEvening;
            data.Rows.Add(rowRoom["RoomName"].ToString().Trim(), iNomalMorning, iNomalAfternoon, iNomalEvening, iWeekendlMorning, iWeekendAfternoon, iWeekendEvening, iTotalSection, iTotalSection * 100 / iPlanTotal, fVND, fVND / int.Parse(txtExchangeRate.Text));
            data.Rows.Add("% Utilization by session", iNomalMorning * 100 / iNomalPlanSection, iNomalAfternoon * 100 / iNomalPlanSection, iNomalEvening * 100 / iNomalPlanSection, iWeekendlMorning * 100 / iWeekendPlanSection, iWeekendAfternoon * 100 / iWeekendPlanSection, iWeekendEvening * 100 / iWeekendPlanSection, 0, 0, 0, 0);
        }
        int iNomalMorningTotal, iNomalAfternoonTotal, iNomalEveningTotal, iWeekendlMorningTotal, iWeekendAfternoonTotal, iWeekendEveningTotal, iTotalSectionTotal;
        iNomalMorningTotal = iNomalAfternoonTotal = iNomalEveningTotal = iWeekendlMorningTotal = iWeekendAfternoonTotal = iWeekendEveningTotal = iTotalSectionTotal = 0;
        float fTotalVND = 0;
        float fTotalUSD = 0;
        int iCount = 0;
        for (int i = 0; i < data.Rows.Count; i = i + 2)
        {
            iNomalMorningTotal = iNomalMorningTotal + (int)data.Rows[i]["NomalMorning"];
            iNomalAfternoonTotal = iNomalAfternoonTotal + (int)data.Rows[i]["NomalAfternoon"];
            iNomalEveningTotal = iNomalEveningTotal + (int)data.Rows[i]["NomalEvening"];
            iWeekendlMorningTotal = iWeekendlMorningTotal + (int)data.Rows[i]["WeekendMorning"];
            iWeekendAfternoonTotal = iWeekendAfternoonTotal + (int)data.Rows[i]["WeekendAfternoon"];
            iWeekendEveningTotal = iWeekendEveningTotal + (int)data.Rows[i]["WeekendEvening"];
            iTotalSectionTotal = iTotalSectionTotal + (int)data.Rows[i]["TotalSession"];
            fTotalVND = fTotalVND + (float)data.Rows[i]["VND"];
            iCount++;
        }
        lbTotalNomalMorning.Text = iNomalMorningTotal.ToString();
        lbTotalNomalAfternoon.Text = iNomalAfternoonTotal.ToString();
        lbTotalNomalEvening.Text = iNomalEveningTotal.ToString();
        lbTotalWeekendMorning.Text = iWeekendlMorningTotal.ToString();
        lbTotalWeekendAternoon.Text = iWeekendAfternoonTotal.ToString();
        lbTotalWeekendEvening.Text = iWeekendEveningTotal.ToString();
        lbTotalofTotal.Text = iTotalSectionTotal.ToString();
        //lbTotalVND.Text = fTotalVND.ToString();
        //fTotalUSD = fTotalVND / int.Parse(txtExchangeRate.Text.Trim());
        //lbTotalUSD.Text = fTotalUSD.ToString();
        lbNM.Text = ((iNomalMorningTotal * 100) / (iNomalPlanSection * iCount)).ToString() + "%";
        lbNA.Text = ((iNomalAfternoonTotal * 100) / (iNomalPlanSection * iCount)).ToString() + "%";
        lbNE.Text = ((iNomalEveningTotal * 100) / (iNomalPlanSection * iCount)).ToString() + "%";
        lbWM.Text = ((iWeekendlMorningTotal * 100) / (iWeekendPlanSection * iCount)).ToString() + "%";
        lbWA.Text = ((iWeekendAfternoonTotal * 100) / (iWeekendPlanSection * iCount)).ToString() + "%";
        lbWE.Text = ((iWeekendEveningTotal * 100) / (iWeekendPlanSection * iCount)).ToString() + "%";
        lbTB.Text = ((iTotalSectionTotal * 100) / (iPlanTotal * iCount)).ToString() + "%";
        repeat.DataSource = data;
        repeat.DataBind();
    }
}