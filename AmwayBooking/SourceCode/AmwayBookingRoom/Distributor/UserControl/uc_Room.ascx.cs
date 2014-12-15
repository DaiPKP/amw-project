using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Configuration;
using System.Net.Mail;
using System.IO;

public partial class Distributor_UserControl_uc_Room : System.Web.UI.UserControl
{
    public Connection con = new Connection();
    public DataTable data = new DataTable();
    public string strRoomCode = "";
    public static string strCode;
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
        DateTime enddate = new DateTime(iNam, iThang, dateofmonth);
        DataTable tb = new DataTable();
        tb = con.ExcuteQuery(startdate, enddate, strRoomCode);
        string strCa1 = "";
        string strCa2 = "";
        string strCa3 = "";
        string strNgay = "";
        string strThu = "";
        string strWeekend = "";
        for (DateTime i = startdate; i <= enddate; i = i.AddDays(1))
        {
            switch (i.DayOfWeek)
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
                data.Rows.Add(strThu + i.ToString("dd/MM/yyyy"), strCa1, strCa2, strCa3, strWeekend);
            }
            else
            {
                data.Rows.Add(strThu + i.ToString("dd/MM/yyyy"), "", "", "", strWeekend);
            }
        }
        repeat.DataSource = data;
        repeat.DataBind();
    }

    protected void repeat_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "Ca1")
        {
            lbDate.Text = e.CommandArgument.ToString();
            lbSection.Text = "Ca Sáng";
            btCapNhat.Visible = false;
        }
        if (e.CommandName.ToString() == "Ca2")
        {
            lbDate.Text = e.CommandArgument.ToString();
            lbSection.Text = "Ca Chiều";
            btCapNhat.Visible = false;
        }
        if (e.CommandName.ToString() == "Ca3")
        {
            lbDate.Text = e.CommandArgument.ToString();
            lbSection.Text = "Ca Tối";
            btCapNhat.Visible = false;
        }
        if (e.CommandName.ToString() == "Update")
        {
            btDatPhong.Visible = false;
            ddlType.Enabled = false;
            strCode = e.CommandArgument.ToString();
            DataTable tb = new DataTable();
            string strQuery = "select * from RegistryRoom where Code = " + strCode;
            tb = con.ExcuteQuery(strQuery);
            if (tb.Rows.Count > 0)
            {
                DataRow row = tb.Rows[0];
                ddlType.SelectedValue = row["Type"].ToString().Trim();
                txtADAID.Text = row["ADA_ID"].ToString();
                txtName.Text = row["ADA_Name"].ToString();
                txtAddress.Text = row["Address"].ToString();
                txtEmail.Text = row["Email"].ToString();
                txtPhone.Text = row["Phone"].ToString();
                lbDate.Text = ((DateTime)row["Date"]).ToString("dd/MM/yyyy");
                lbSection.Text = row["Section"].ToString();
                txtNote.Text = row["Note"].ToString();
                if (row["Paid"].ToString().Equals("Y"))
                {
                    chkPaid.Checked = true;
                }
                else
                {
                    chkPaid.Checked = false;
                }
                ddlStatus.SelectedValue = row["Status"].ToString();
            }
        }
        popup.Show();
    }
    protected void btDatPhong_Click(object sender, EventArgs e)
    {
        btDatPhong.Enabled = false;
        SqlParameter[] paras = new SqlParameter[12];
        paras[0] = new SqlParameter("@ADA_ID", txtADAID.Text.Trim());
        paras[1] = new SqlParameter("@ADA_Name", txtName.Text.Trim());
        paras[2] = new SqlParameter("@Phone", txtPhone.Text.Trim());
        paras[3] = new SqlParameter("@Email", txtEmail.Text.Trim());
        paras[4] = new SqlParameter("@Address", txtAddress.Text.Trim());
        paras[5] = new SqlParameter("@RoomCode", strRoomCode);
        DateTime date = DateTime.Parse(lbDate.Text.ToString());
        paras[6] = new SqlParameter("@Date", date.Date);
        paras[7] = new SqlParameter("@Section", lbSection.Text.ToString());
        paras[8] = new SqlParameter("@Type", ddlType.SelectedValue.ToString());
        string strWeekend;
        if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
        {
            strWeekend = "Y";
        }
        else
        {
            strWeekend = "N";
        }
        paras[9] = new SqlParameter("@Weekend", strWeekend);
        string strPaid;
        if (chkPaid.Checked == true)
        {
            strPaid = "Y";
        }
        else
        {
            strPaid = "N";
        }
        paras[10] = new SqlParameter("@Paid", strPaid);
        paras[11] = new SqlParameter("@Note", txtNote.Text.Trim());
        con.ExcuteNonQuery("sp_registry_room", paras);

        //if (ddlType.SelectedItem.Text.Equals("Distributor") && !txtEmail.Text.Trim().Equals(""))
        //{
        //    DataTable table = new DataTable();
        //    table = con.ExcuteQuery("Select * from Room where RoomCode = '" + ddlRoom.SelectedValue.Trim() + "'");
        //    string strGia = "";
        //    string strSection = "";
        //    if (strWeekend.Equals("N"))
        //    {
        //        switch (lbSection.Text.ToString())
        //        {
        //            case "Ca Sáng":
        //                strSection = "Từ 8 giờ đến 12 giờ";
        //                strGia = string.Format("{0:0,0 VNĐ}", table.Rows[0]["PriceMorning"]);
        //                break;
        //            case "Ca Chiều":
        //                strSection = "Từ 13 giờ đến 17 giờ";
        //                strGia = string.Format("{0:0,0 VNĐ}", table.Rows[0]["PriceAfternoon"]);
        //                break;
        //            case "Ca Tối":
        //                strSection = "Từ 18 giờ đến 22 giờ";
        //                strGia = string.Format("{0:0,0 VNĐ}", table.Rows[0]["PriceEvening"]);
        //                break;
        //        }
        //    }
        //    else
        //    {
        //        switch (lbSection.Text.ToString())
        //        {
        //            case "Ca Sáng":
        //                strSection = "Từ 8 giờ đến 12 giờ";
        //                strGia = string.Format("{0:0,0 VNĐ}", table.Rows[0]["PriceWeekendMorning"]);
        //                break;
        //            case "Ca Chiều":
        //                strSection = "Từ 13 giờ đến 17 giờ";
        //                strGia = string.Format("{0:0,0 VNĐ}", table.Rows[0]["PriceWeekendAfternoon"]);
        //                break;
        //            case "Ca Tối":
        //                strSection = "Từ 18 giờ đến 22 giờ";
        //                strGia = string.Format("{0:0,0 VNĐ}", table.Rows[0]["PriceWeekendEvening"]);
        //                break;
        //        }
        //    }
        //    //Begin send email
        //    //Load Row
        //    StreamReader srRow = new StreamReader(Server.MapPath("Row.txt"));
        //    srRow = File.OpenText(Server.MapPath("Row.txt"));
        //    string strRow = srRow.ReadToEnd();
        //    srRow.Close();
        //    strRow = strRow.Replace("[Room]", ddlCenter.SelectedItem.Text.Trim());
        //    strRow = strRow.Replace("[MeetingDate]", date.Date.ToString("dd/MM/yyyy"));
        //    strRow = strRow.Replace("[MeetingTime]", strSection);
        //    strRow = strRow.Replace("[Money]", strGia);
        //    //End Load Row
        //    StreamReader sr = new StreamReader(Server.MapPath("EmailTemplate.htm"));
        //    sr = File.OpenText(Server.MapPath("EmailTemplate.htm"));
        //    string content = sr.ReadToEnd();
        //    sr.Close();
        //    content = content.Replace("[Name]", txtName.Text.Trim());
        //    content = content.Replace("[ADA]", txtADAID.Text.Trim());
        //    content = content.Replace("[Room]", ddlCenter.SelectedItem.Text.Trim());
        //    content = content.Replace("[Content]", strRow);
        //    content = content.Replace("[TotalMoney]", strGia);
        //    content = content.Replace("[Date]", DateTime.Now.AddDays(1).Date.ToString("dd/MM/yyyy"));
        //    SendMail("Amway - Thông báo phí thuê phòng hội họp", content, txtEmail.Text.Trim(), true, true);
        //    // End
        //}
        popup.Hide();
        ClearField();
        //CheckBookingRoom();
    }
    protected void btThoat_Click(object sender, EventArgs e)
    {
        ClearField();
        popup.Hide();
    }

    protected void btCapNhat_Click(object sender, EventArgs e)
    {
        btCapNhat.Enabled = false;
        SqlParameter[] paras = new SqlParameter[9];
        paras[0] = new SqlParameter("@ADA_ID", txtADAID.Text.Trim());
        paras[1] = new SqlParameter("@ADA_Name", txtName.Text.Trim());
        paras[2] = new SqlParameter("@Phone", txtPhone.Text.Trim());
        paras[3] = new SqlParameter("@Email", txtEmail.Text.Trim());
        paras[4] = new SqlParameter("@Address", txtAddress.Text.Trim());
        paras[5] = new SqlParameter("@Status", ddlStatus.Text);
        paras[6] = new SqlParameter("@Code", Int16.Parse(strCode));
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
        con.ExcuteNonQuery("sp_update_registry_room", paras);

        //CheckBookingRoom();
        ClearField();
    }
    public void ClearField()
    {
        ddlType.Enabled = true;
        txtADAID.Text = "";
        txtName.Text = "";
        txtPhone.Text = "";
        txtEmail.Text = "";
        txtAddress.Text = "";
        lbDate.Text = "";
        lbSection.Text = "";
        txtNote.Text = "";
        chkPaid.Checked = false;
        btCapNhat.Visible = true;
        btDatPhong.Visible = true;
        btCapNhat.Enabled = true;
        btDatPhong.Enabled = true;
    }
    // Mail
    public static String FormAddress
    {
        get
        {
            SmtpSection cfg = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            return cfg.Network.UserName;
        }
    }
    public string SendMail(string subject, string body, string to, bool isHtml, bool isSSL)
    {
        using (MailMessage mail = new MailMessage())
        {
            mail.From = new MailAddress(FormAddress, "Amway Booking Room");

            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = isHtml;
            SmtpClient client = new SmtpClient();
            client.EnableSsl = isSSL;
            client.Send(mail);
        }

        return "Send email successful!";
    }
}