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

public partial class BookingRoom : System.Web.UI.Page
{
    public Connection con = new Connection();
    public DataTable data = new DataTable();
    public static string strRoomCode;
    public static string strCode;
    public static string strCityCode;
    public static string strCenterCode;
    public static string strYear;
    public static string strMonth;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            strRoomCode = Request.QueryString["RoomCode"].ToString();
            strCityCode = Request.QueryString["CityCode"].ToString();
            strCenterCode = Request.QueryString["CenterCode"].ToString();
            strMonth = Request.QueryString["Month"].ToString();
            strYear = Request.QueryString["Year"].ToString();
        }
        catch (Exception ex)
        {
            strRoomCode = "";
            strCityCode = "";
            strCenterCode = "";
            strYear = "";
            strMonth = "";
        }
        if (!IsPostBack)
        {
            string strQuery = "";
            DataTable table = new DataTable();

            if (!strRoomCode.Equals(""))
            {
                strQuery = "select CityCode,CityName from City where Status = 'Y'";
                table = new DataTable();
                table = con.ExcuteQuery(strQuery);
                ddlCity.DataSource = table;
                ddlCity.DataTextField = "CityName";
                ddlCity.DataValueField = "CityCode";
                ddlCity.DataBind();
                ddlCity.SelectedValue = strCityCode;

                strQuery = "select CenterCode,CenterName from Center where Status = 'Y'";
                table = con.ExcuteQuery(strQuery);
                ddlCenter.DataSource = table;
                ddlCenter.DataTextField = "CenterName";
                ddlCenter.DataValueField = "CenterCode";
                ddlCenter.DataBind();
                ddlCenter.SelectedValue = strCenterCode;

                strQuery = "select RoomCode,RoomName from Room where Status = 'Y'";
                table = con.ExcuteQuery(strQuery);
                ddlRoom.DataSource = table;
                ddlRoom.DataTextField = "RoomName";
                ddlRoom.DataValueField = "RoomCode";
                ddlRoom.DataBind();
                ddlRoom.SelectedValue = strRoomCode;

                ddlMonth.SelectedValue = strMonth;
                ddlYear.SelectedValue = strYear;

                CheckBookingRoom();
            }
            else
            {
                strQuery = "select CityCode,CityName from City where Status = 'Y'";
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
                ddlMonth.Text = DateTime.Today.Month.ToString();
                ddlYear.Text = DateTime.Today.Year.ToString();
            }
        }
    }
    public void CheckBookingRoom()
    {
        data.Columns.Add("Code1", typeof(string));
        data.Columns.Add("Code2", typeof(string));
        data.Columns.Add("Code3", typeof(string));
        data.Columns.Add("Ngay", typeof(string));
        data.Columns.Add("Ca1", typeof(string));
        data.Columns.Add("Ca2", typeof(string));
        data.Columns.Add("Ca3", typeof(string));
        data.Columns.Add("Weekend", typeof(string));
        data.Columns.Add("Paid1", typeof(string));
        data.Columns.Add("Paid2", typeof(string));
        data.Columns.Add("Paid3", typeof(string));
        int iNam = Int16.Parse(ddlYear.SelectedValue.ToString());
        int iThang = Int16.Parse(ddlMonth.SelectedValue.ToString());
        DateTime startdate = new DateTime(iNam, iThang, 1);
        int dateofmonth = DateTime.DaysInMonth(iNam, iThang);
        DateTime enddate = new DateTime(iNam, iThang, dateofmonth);
        DataTable tb = new DataTable();
        tb = con.ExcuteQuery(startdate, enddate, ddlRoom.SelectedValue.Trim());
        string strCode1 = "";
        string strCode2 = "";
        string strCode3 = "";
        string strCa1 = "";
        string strCa2 = "";
        string strCa3 = "";
        string strWeekend = "";
        string strPaid1 = "";
        string strPaid2 = "";
        string strPaid3 = "";
        for (DateTime i = startdate; i <= enddate; i = i.AddDays(1))
        {
            strCode1 = strCode2 = strCode3 = strPaid1 = strPaid2 = strPaid3 = strCa1 = strCa2 = strCa3 = "";
            if (i.DayOfWeek == DayOfWeek.Sunday || i.DayOfWeek == DayOfWeek.Saturday)
            {
                strWeekend = "Y";
            }
            else
            {
                strWeekend = "N";
            }
            if (tb.Rows.Count > 0)
            {
                
                foreach (DataRow row in tb.Rows)
                {
                    if (DateTime.Parse(row["Date"].ToString()) == i)
                    {
                        if (row["Section"].ToString().Equals("Ca Sáng"))
                        {
                            strCa1 = row["ADA_Name"].ToString().Trim();
                            strCode1 = row["Code"].ToString().Trim();
                            strPaid1 = row["Paid"].ToString().Trim();
                        }
                        if (row["Section"].ToString().Equals("Ca Chiều"))
                        {
                            strCa2 = row["ADA_Name"].ToString().Trim();
                            strCode2 = row["Code"].ToString().Trim();
                            strPaid2 = row["Paid"].ToString().Trim();
                        }
                        if (row["Section"].ToString().Equals("Ca Tối"))
                        {
                            strCa3 = row["ADA_Name"].ToString().Trim();
                            strCode3 = row["Code"].ToString().Trim();
                            strPaid3 = row["Paid"].ToString().Trim();
                        }
                    }
                }                
            }
            data.Rows.Add(strCode1, strCode2, strCode3, i.ToLongDateString(), strCa1, strCa2, strCa3, strWeekend, strPaid1, strPaid2, strPaid3);
        }
        repeat.DataSource = data;
        repeat.DataBind();
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
    protected void btXemLich_Click(object sender, EventArgs e)
    {
        strRoomCode = ddlRoom.SelectedValue.ToString();
        CheckBookingRoom();
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
                lbDate.Text =((DateTime)row["Date"]).ToString("dd/MM/yyyy");
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
        paras[5] = new SqlParameter("@RoomCode", ddlRoom.SelectedValue.Trim());
        DateTime date = DateTime.Parse(lbDate.Text.ToString());
        paras[6] = new SqlParameter("@Date", date.Date);
        paras[7] = new SqlParameter("@Section", lbSection.Text.ToString());
        paras[8] = new SqlParameter("@Type",ddlType.SelectedValue.ToString());
        string strWeekend;
        if(date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
        {
            strWeekend = "Y";
        }
        else
        {
            strWeekend = "N";
        }
        paras[9] = new SqlParameter("@Weekend",strWeekend);
        string strPaid;
        if(chkPaid.Checked == true)
        {
            strPaid = "Y";
        }
        else
        {
            strPaid = "N";
        }
        paras[10] = new SqlParameter("@Paid",strPaid);
        paras[11] = new SqlParameter("@Note",txtNote.Text.Trim());
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
        CheckBookingRoom();
    }
    protected void btThoat_Click(object sender, EventArgs e)
    {
        ClearField();
        popup.Hide();
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
        if(chkPaid.Checked == true)
        {
            strPaid = "Y";
        }
        else
        {
            strPaid = "N";
        }
        paras[7] = new SqlParameter("@Paid",strPaid);
        paras[8] = new SqlParameter("@Note",txtNote.Text.Trim());
        con.ExcuteNonQuery("sp_update_registry_room", paras);
        
        CheckBookingRoom();
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