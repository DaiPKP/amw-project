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
using DAL;
using System.Globalization;

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
            CategoryBO BO = new CategoryBO();
            List<SP_GET_ROOM_BY_ROOMCODEResult> listRoom = new List<SP_GET_ROOM_BY_ROOMCODEResult>();
            listRoom = BO.GetRoomByRoomCode(strRoomCode).ToList();
            if (listRoom.Count > 0)
            {
                lbMaPhong.Text = listRoom[0].RoomCode.ToString();
                lbTenPhong.Text = listRoom[0].RoomName.ToString();
                lbSucChua.Text = listRoom[0].Amount.ToString() + " người";
                lbGiaThang.Text = string.Format("{0:0,0 VNĐ}", listRoom[0].PriceBookingMonthly);
                lbGiaPhong.Text = string.Format("{0:0,0 VNĐ}", listRoom[0].PriceMorning);
                lbGiaCuoiTuan.Text = string.Format("{0:0,0 VNĐ}", listRoom[0].PriceWeekendMorning);
                lbGiaChieuThuong.Text = string.Format("{0:0,0 VNĐ}", listRoom[0].PriceAfternoon);
                lbGiaChieuCuoi.Text = string.Format("{0:0,0 VNĐ}", listRoom[0].PriceWeekendAfternoon);
                lbGiaToiThuong.Text = string.Format("{0:0,0 VNĐ}", listRoom[0].PriceEvening);
                lbGiaToiCuoi.Text = string.Format("{0:0,0 VNĐ}", listRoom[0].PriceWeekendEvening);
                lbRoomName.Text = listRoom[0].RoomName.ToString();
            }
            ddlThang.Text = DateTime.Today.Month.ToString();
            ddlNam.Text = DateTime.Today.Year.ToString();
        }
    }
    protected void btXemLich_Click(object sender, EventArgs e)
    {
        CheckBooking();
    }

    protected void CheckBooking()
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
        RegistryRoomBO BO = new RegistryRoomBO();
        List<SP_REGISTYROOM_GETLISTResult> listBooking = new List<SP_REGISTYROOM_GETLISTResult>();
        listBooking = BO.GetListBooking(strRoomCode, startdate, enddate);
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
            if (listBooking.Count > 0)
            {
                strCa1 = strCa2 = strCa3 = "";
                foreach (SP_REGISTYROOM_GETLISTResult row in listBooking)
                {
                    if (DateTime.Parse(row.Date.ToString()) == i)
                    {
                        if (row.Section.ToString().Equals("Ca Sáng"))
                        {
                            strCa1 = "Đã Đặt";
                        }
                        if (row.Section.ToString().Equals("Ca Chiều"))
                        {
                            strCa2 = "Đã Đặt";
                        }
                        if (row.Section.ToString().Equals("Ca Tối"))
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
            LoadInfo();
        }
        if (e.CommandName.ToString() == "Ca2")
        {
            lbDate.Text =e.CommandArgument.ToString();
            lbSection.Text = "Ca Chiều";
            btCapNhat.Visible = false;
            LoadInfo();
        }
        if (e.CommandName.ToString() == "Ca3")
        {
            lbDate.Text = e.CommandArgument.ToString();
            lbSection.Text = "Ca Tối";
            btCapNhat.Visible = false;
            LoadInfo();
        }
        if (e.CommandName.ToString() == "Update")
        {
            btDatPhong.Visible = false;
            ddlType.Enabled = false;
            strCode = e.CommandArgument.ToString();
            RegistryRoomBO BO = new RegistryRoomBO();
            List<SP_REGISTYROOM_GET_BY_CODEResult> listBooking = new List<SP_REGISTYROOM_GET_BY_CODEResult>();
            listBooking = BO.GetBookingByCode(int.Parse(strCode));
            if (listBooking.Count > 0)
            {
                ddlType.SelectedValue = listBooking[0].Type.ToString().Trim();
                txtADAID.Text = listBooking[0].ADA_ID.ToString();
                txtName.Text = listBooking[0].ADA_Name.ToString();
                txtAddress.Text = listBooking[0].Address.ToString();
                txtEmail.Text = listBooking[0].Email.ToString();
                txtPhone.Text = listBooking[0].Phone.ToString();
                lbDate.Text = listBooking[0].Date.ToString("dd/MM/yyyy");
                lbSection.Text = listBooking[0].Section.ToString();
                txtNote.Text = listBooking[0].Note.ToString();
                if (listBooking[0].Paid.ToString().Equals("Y"))
                {
                    chkPaid.Checked = true;
                }
                else
                {
                    chkPaid.Checked = false;
                }
                ddlStatus.SelectedValue = listBooking[0].Status.ToString();
            }
        }
        popup.Show();
    }
    private void LoadInfo()
    {
        UserBO BO = new UserBO();
        PRC_SYS_AMW_USER_GETLISTBYUSERIDResult info = new PRC_SYS_AMW_USER_GETLISTBYUSERIDResult();
        info = BO.UserGetListByUserID(int.Parse(Session["UserID"].ToString()));

        ddlType.Enabled = false;
        txtADAID.Text = info.ADA;
        txtADAID.Enabled = false;
        txtName.Text = info.FULLNAME;
        txtName.Enabled = false;
        txtAddress.Text = info.ADDRESS;
        txtEmail.Text = info.EMAIL;
        txtPhone.Text = info.TELEPHONE;

        ddlStatus.Enabled = false;
        chkPaid.Enabled = false;
    }
    protected void btDatPhong_Click(object sender, EventArgs e)
    {
        RegistryRoomBO BO = new RegistryRoomBO();
        RegistryRoom booking = new RegistryRoom();
        booking.ADA_ID = txtADAID.Text.Trim();
        booking.ADA_Name = txtName.Text.Trim();
        booking.Phone = txtPhone.Text.Trim();
        booking.Email = txtEmail.Text.Trim();
        booking.Address = txtAddress.Text.Trim();
        booking.RoomCode = strRoomCode;
        string strDate=lbDate.Text.Trim().Substring(lbDate.Text.Trim().Length-10,10);
        booking.Date = DateTime.ParseExact(strDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        booking.Section = lbSection.Text.ToString();
        booking.Type = ddlType.SelectedValue.ToString();
        btDatPhong.Enabled = false;
        DateTime date = DateTime.ParseExact(strDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        string strWeekend;
        if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
        {
            strWeekend = "Y";
        }
        else
        {
            strWeekend = "N";
        }
        booking.Weekend = Char.Parse(strWeekend);
        string strPaid;
        if (chkPaid.Checked == true)
        {
            strPaid = "Y";
        }
        else
        {
            strPaid = "N";
        }
        booking.Paid = Char.Parse(strPaid);
        booking.Note = txtNote.Text.Trim();
        int result=BO.InsertBooking(booking);

        string strGia = "";
        string strSection = "";
        if(strWeekend.Equals("N"))
        {
            switch(lbSection.Text.ToString())
            {
                case "Ca Sáng":
                    strSection = "Từ 8 giờ đến 12 giờ";
                    strGia = lbGiaPhong.Text.ToString();
                    break;
                case "Ca Chiều":
                    strSection = "Từ 13 giờ đến 17 giờ";
                    strGia = lbGiaChieuThuong.Text.ToString();
                    break;
                case "Ca Tối":
                    strSection = "Từ 18 giờ đến 22 giờ";
                    strGia = lbGiaToiThuong.Text.ToString();
                    break;
            }
        }
        else
        {
            switch (lbSection.Text.ToString())
            {
                case "Ca Sáng":
                    strSection = "Từ 8 giờ đến 12 giờ";
                    strGia = lbGiaCuoiTuan.Text.ToString();
                    break;
                case "Ca Chiều":
                    strSection = "Từ 13 giờ đến 17 giờ";
                    strGia = lbGiaChieuCuoi.Text.ToString();
                    break;
                case "Ca Tối":
                    strSection = "Từ 18 giờ đến 22 giờ";
                    strGia = lbGiaToiCuoi.Text.ToString();
                    break;
            }
        }
        //Begin send email
        //Load Row
        StreamReader srRow = new StreamReader(Server.MapPath("~/Row.txt"));
        srRow = File.OpenText(Server.MapPath("~/Row.txt"));
        string strRow = srRow.ReadToEnd();
        srRow.Close();
        strRow = strRow.Replace("[Room]", lbTenPhong.Text.Trim());
        strRow = strRow.Replace("[MeetingDate]", date.Date.ToString("dd/MM/yyyy"));
        strRow = strRow.Replace("[MeetingTime]", strSection);
        strRow = strRow.Replace("[Money]", strGia);
        //End Load Row
        StreamReader sr = new StreamReader(Server.MapPath("~/EmailTemplate.htm"));
        sr = File.OpenText(Server.MapPath("~/EmailTemplate.htm"));
        string content = sr.ReadToEnd();
        sr.Close();
        content = content.Replace("[Name]", txtName.Text.Trim());
        content = content.Replace("[ADA]", txtADAID.Text.Trim());
        content = content.Replace("[Room]", lbTenPhong.Text.Trim());
        content = content.Replace("[Content]", strRow);
        content = content.Replace("[TotalMoney]", strGia);
        content = content.Replace("[Date]", DateTime.Now.AddDays(1).Date.ToString("dd/MM/yyyy"));
        SendMail("Amway - Thông báo phí thuê phòng hội họp", content, txtEmail.Text.Trim(), true, true);
        // End
        popup.Hide();
        ClearField();
        CheckBooking();
    }
    protected void btThoat_Click(object sender, EventArgs e)
    {
        ClearField();
        popup.Hide();
    }

    protected void btCapNhat_Click(object sender, EventArgs e)
    {
        btCapNhat.Enabled = false;
        RegistryRoom booking = new RegistryRoom();
        RegistryRoomBO BO = new RegistryRoomBO();

        booking.ADA_ID = txtADAID.Text.Trim();
        booking.ADA_Name = txtName.Text.Trim();
        booking.Phone = txtPhone.Text.Trim();
        booking.Email = txtEmail.Text.Trim();
        booking.Address = txtAddress.Text.Trim();
        booking.Status = Char.Parse(ddlStatus.Text);
        booking.Code = Int16.Parse(strCode);
        string strPaid;
        if (chkPaid.Checked == true)
        {
            strPaid = "Y";
        }
        else
        {
            strPaid = "N";
        }
        booking.Paid = Char.Parse(strPaid);
        booking.Note = txtNote.Text.Trim();

        BO.UpdateBooking(booking);
        CheckBooking();
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
            client.UseDefaultCredentials = false;
            client.Send(mail);
        }

        return "Send email successful!";
    }
}