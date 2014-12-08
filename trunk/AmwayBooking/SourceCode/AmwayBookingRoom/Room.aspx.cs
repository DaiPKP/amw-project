using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Room : System.Web.UI.Page
{
    public Connection con = new Connection();
    public DataTable data = new DataTable();
    public string strRoomCode = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        strRoomCode = Request.QueryString["RoomCode"].ToString();
        if (!IsPostBack)
        {
            DataTable tb = new DataTable();
            string strQuery = "Select * from Room where RoomCode = '" + strRoomCode + "'";
            tb = con.ExcuteQuery(strQuery);
            if (tb.Rows.Count > 0)
            {
                lbMaPhong.Text = tb.Rows[0]["RoomCode"].ToString();
                lbTenPhong.Text = tb.Rows[0]["RoomName"].ToString();
                lbSucChua.Text = tb.Rows[0]["Amount"].ToString() + " người";
                lbGiaThang.Text = string.Format("{0:0,0 VNĐ}", tb.Rows[0]["PriceBookingMonthly"]);
                lbGiaPhong.Text = string.Format("{0:0,0 VNĐ}", tb.Rows[0]["PriceMorning"]);
                lbGiaCuoiTuan.Text = string.Format("{0:0,0 VNĐ}", tb.Rows[0]["PriceWeekendMorning"]);
                lbGiaChieuThuong.Text = string.Format("{0:0,0 VNĐ}", tb.Rows[0]["PriceAfternoon"]);
                lbGiaChieuCuoi.Text = string.Format("{0:0,0 VNĐ}", tb.Rows[0]["PriceWeekendAfternoon"]);
                lbGiaToiThuong.Text = string.Format("{0:0,0 VNĐ}", tb.Rows[0]["PriceEvening"]);
                lbGiaToiCuoi.Text = string.Format("{0:0,0 VNĐ}", tb.Rows[0]["PriceWeekendEvening"]);
            }
            strQuery = "select RoomName from Room where RoomCode = '" + strRoomCode + "'";
            tb = con.ExcuteQuery(strQuery);
            if (tb.Rows.Count > 0)
            {
                lbRoomName.Text = tb.Rows[0]["RoomName"].ToString();
            }
            ddlThang.Text = DateTime.Today.Month.ToString();
            ddlNam.Text = DateTime.Today.Year.ToString();
        }
    }
    protected void btXemLich_Click(object sender, EventArgs e)
    {
        data.Columns.Add("Ngay", typeof(string));
        data.Columns.Add("Ca1", typeof(string));
        data.Columns.Add("Ca2", typeof(string));
        data.Columns.Add("Ca3", typeof(string));
        data.Columns.Add("Weekend", typeof(string));
        int iNam = Int16.Parse(ddlNam.SelectedValue.ToString());
        int iThang = Int16.Parse(ddlThang.SelectedValue.ToString());
        DateTime startdate;
        if (DateTime.Today.Month == iThang && DateTime.Today.Year == iNam)
        {
            startdate = DateTime.Today;
        }
        else
        {
            startdate = new DateTime(iNam, iThang, 1);
        }
        
        int dateofmonth = DateTime.DaysInMonth(iNam, iThang);
        DateTime enddate = new DateTime(iNam,iThang,dateofmonth);
        DataTable tb = new DataTable();
        tb = con.ExcuteQuery(startdate,enddate,strRoomCode);
        string strCa1 = "";
        string strCa2 = "";
        string strCa3 = "";
        string strNgay = "";
        string strThu = "";
        string strWeekend = "";
        for (DateTime i = startdate; i <= enddate;i= i.AddDays(1))
        {
            switch(i.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    strThu = "Chủ nhật, ";
                    strWeekend = "Y";
                    break;
                case DayOfWeek.Monday:
                    strThu = "Thứ 2, ";
                    strWeekend = "N";
                    break;
                case DayOfWeek.Tuesday:
                    strThu = "Thứ 3, ";
                    strWeekend = "N";
                    break;
                case DayOfWeek.Wednesday:
                    strThu = "Thứ 4, ";
                    strWeekend = "N";
                    break;
                case DayOfWeek.Thursday:
                    strThu = "Thứ 5, ";
                    strWeekend = "N";
                    break;
                case DayOfWeek.Friday:
                    strThu = "Thứ 6, ";
                    strWeekend = "N";
                    break;
                case DayOfWeek.Saturday:
                    strThu = "Thứ 7, ";
                    strWeekend = "Y";
                    break;
            }
            if (tb.Rows.Count > 0)
            {
                strCa1 = strCa2 = strCa3 = "";
                foreach (DataRow row in tb.Rows)
                {
                    if (DateTime.Parse(row["Date"].ToString()) == i)
                    {
                        if (row["Section"].ToString().Equals("Ca Sáng"))
                        {
                            strCa1 = "Đã Đặt";
                        }
                        if (row["Section"].ToString().Equals("Ca Chiều"))
                        {
                            strCa2 = "Đã Đặt";
                        }
                        if (row["Section"].ToString().Equals("Ca Tối"))
                        {
                            strCa3 = "Đã Đặt";
                        }                        
                    }
                }
                data.Rows.Add(strThu + i.ToString("dd/MM/yyyy"), strCa1, strCa2, strCa3,strWeekend);
            }
            else
            {
                data.Rows.Add(strThu + i.ToString("dd/MM/yyyy"), "", "", "",strWeekend);
            }            
        }
        repeat.DataSource = data;
        repeat.DataBind();
    }
}