using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Text.RegularExpressions;
using System.Globalization;

public partial class Meeting_UserControl_uc_OutsideCountryClone : System.Web.UI.UserControl
{
    public int _ID = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitData();

        }
    }
    private void InitData()
    {
        ClearTextBox();
        if (_ID > 0)
        {
            LoadData(_ID);
        }
        else
        {
            GetInfoUserLogin(int.Parse(Session["UserID"].ToString()));

        }
    }

    private void LoadData(int Id)
    {
        MeetingBO objBO = new MeetingBO();
        PRC_USR_AMW_MEETING_REGISTER_GETLISTBYIDResult result = new PRC_USR_AMW_MEETING_REGISTER_GETLISTBYIDResult();

        result = objBO.MeetingGet_ListByID(Id);
        if (result != null)
        {
            if ((int.Parse(Session["UserID"].ToString()) == result.ORGANIZER_USERID) && (result.ORGANIZER_USERID == result.CREATEUSER))
            {
                txtORGANIZER_ADAID.Text = result.ORGANIZER_ADAID == null ? string.Empty : result.ORGANIZER_ADAID;
                lblORGANIZER_NAME.Text = result.ORGANIZER_NAME == null ? string.Empty : result.ORGANIZER_NAME;
                lblORGANIZER_EMAIL.Text = result.ORGANIZER_EMAIL == null ? string.Empty : result.ORGANIZER_EMAIL;
                lblORGANIZER_TELEPHONE.Text = result.ORGANIZER_TELEPHONE == null ? string.Empty : result.ORGANIZER_TELEPHONE;
                hdfORGANIZER_USERID.Value = result.ORGANIZER_USERID == null ? string.Empty : result.ORGANIZER_USERID.ToString();
                hdfORGANIZER_USERTYPEID.Value = result.ORGANIZER_USERTYPEID == null ? string.Empty : result.ORGANIZER_USERTYPEID.ToString();

                txtSPEAKER_ADAID_1.Text = result.SPEAKER_ADAID_1 == null ? string.Empty : result.SPEAKER_ADAID_1;
                txtSPEAKER_NAME_1.Text = result.SPEAKER_NAME_1 == null ? string.Empty : result.SPEAKER_NAME_1;
                txtSPEAKER_USERTYPENAME_1.Text = result.SPEAKER_USERTYPENAME_1 == null ? string.Empty : result.SPEAKER_USERTYPENAME_1;
              
                txtMEETINGNAME.Text = result.MEETINGNAME == null ? string.Empty : result.MEETINGNAME;
                txtMEETING_PLACE_NAME.Text = result.MEETING_PLACE_NAME == null ? string.Empty : result.MEETING_PLACE_NAME;
                txtMEETING_ADDRESS.Text = result.MEETING_ADDRESS == null ? string.Empty : result.MEETING_ADDRESS;
                txtMEETING_ENDDATE.Text = result.MEETING_ENDDATE == null ? string.Empty : result.STR_MEETING_ENDDATE;
                txtMEETING_STARTDATE.Text = result.MEETING_STARTDATE == null ? string.Empty : result.STR_MEETING_STARTDATE;

                txtDEPARTURE_DATE.Text = result.STR_DEPARTURE_DATE == null ? string.Empty : result.STR_DEPARTURE_DATE;
                txtARRIVAL_DATE.Text = result.STR_ARRIVAL_DATE == null ? string.Empty : result.STR_ARRIVAL_DATE;
                txtCOUNTRYNAME.Text = result.COUNTRYNAME == null ? string.Empty : result.COUNTRYNAME;

                hdfReported.Value = result.REPORTED == null ? "false" : result.REPORTED.ToString();
                lblWarning.Text=result.WARNING == null ? string.Empty : result.WARNING;
                if (lblWarning.Text.Length > 0)
                {
                    trWarning.Visible = true;
                }
                else
                {
                    trWarning.Visible = false;
                }
                if (result.STATUS_MEETING_REGISTERID > 1)
                {
                    btnSave.Visible = false;

                }
                else
                {
                    btnSave.Visible = true;
                }
                if (hdfORGANIZER_USERID.Value.Length > 0)
                {
                    divORGANIZER_QUOTA.Visible = true;
                    ImgBtnORGANIZER_OK.Visible = true;
                    hdfORGANIZER_QUOTA_CHECK.Value = "true";
                    ImgBtnORGANIZER_ERROR.Visible = false;
                }
                btnClone.Visible = true;
            }
        }
        else
        {
            ClearTextBox();
        }

    }
    private void ClearTextBox()
    {
        lblAlerting.Text = string.Empty;
        hdfReported.Value = "false";
        hdfID.Value = "-1";
        btnSave.Text = "Đăng ký";
        btnClone.Visible = false;
        btnSave.Visible = true;
        trWarning.Visible = false;
        lblWarning.Text = string.Empty;
        txtORGANIZER_ADAID.ReadOnly = true;
        txtORGANIZER_ADAID.Text = string.Empty;
        hdfORGANIZER_USERID.Value = string.Empty;
        lblORGANIZER_NAME.Text = string.Empty;
        lblORGANIZER_EMAIL.Text = string.Empty;
        lblORGANIZER_TELEPHONE.Text = string.Empty;
        lblORGANIZER_USERTYPENAME.Text = string.Empty;
        hdfORGANIZER_USERTYPEID.Value = string.Empty;

        txtSPEAKER_ADAID_1.Text = string.Empty;
        txtSPEAKER_NAME_1.Text = string.Empty;
        txtSPEAKER_USERTYPENAME_1.Text = string.Empty;


        txtMEETINGNAME.Text = string.Empty;
        txtMEETING_PLACE_NAME.Text = string.Empty;
        txtMEETING_ADDRESS.Text = "Số..., Đường..., Phường/Xã..., Quận/Huyện..., Tỉnh/TP...";

        txtDEPARTURE_DATE.Text = string.Empty;
        txtARRIVAL_DATE.Text = string.Empty;

        txtMEETING_ENDDATE.Text = string.Empty;
        txtMEETING_STARTDATE.Text = string.Empty;
        txtCOUNTRYNAME.Text = string.Empty;
        ImgBtnORGANIZER_OK.Visible = false;
        ImgBtnORGANIZER_ERROR.Visible = false;
        hdfORGANIZER_QUOTA_CHECK.Value = "false";
        lblORGANIZER_OK.Text = string.Empty;
    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        // Kiem tra neu chua có báo cáo của cuộc họp trước thì không cho đăng ký nưa? (chua lam)

        USR_AMW_MEETING_REGISTER obj = new USR_AMW_MEETING_REGISTER();
        // Thuc hien Insert Update
        //Kiem tra lai nhap đủ dữ liệu chưa?

        if (txtORGANIZER_ADAID.Text.Trim().Length <= 0)
        {
            lblAlerting.Text = "Bạn chưa nhập mã số ADA của người đăng ký!";
            return;
        }

        if (hdfORGANIZER_USERID.Value.Trim().Length <= 0)
        {
            lblAlerting.Text = "Bạn chưa lấy thông tin của người đăng ký!";
            return;
        }
        if (txtSPEAKER_ADAID_1.Text.Trim().Length <= 0)
        {
            lblAlerting.Text = "Bạn chưa nhập mã số ADA của người tổ chức!";
            return;
        }

        if (txtSPEAKER_NAME_1.Text.Trim().Length <= 0)
        {
            lblAlerting.Text = "Bạn chưa nhập tên của người tổ chức!";
            return;
        }

        if (txtSPEAKER_USERTYPENAME_1.Text.Trim().Length <= 0)
        {
            lblAlerting.Text = "Bạn chưa nhập danh hiệu của người tổ chức!";
            return;
        }
        if (txtMEETINGNAME.Text.Trim().Length <= 0)
        {
            lblAlerting.Text = "Bạn chưa nhập tên cuộc họp!";
            return;
        }
       
        if (txtMEETING_PLACE_NAME.Text.Trim().Length <= 0)
        {
            lblAlerting.Text = "Bạn chưa nhập tên địa điểm họp!";
            return;
        }
        if (txtMEETING_ADDRESS.Text.Trim().Length <= 0)
        {
            lblAlerting.Text = "Bạn chưa nhập địa điểm họp!";
            return;
        }
        if (txtCOUNTRYNAME.Text.Trim().Length <= 0)
        {
            lblAlerting.Text = "Bạn chưa nhập tên quốc gia!";
            return;
        }
        if ((txtDEPARTURE_DATE.Text.Trim().Length <= 0) || (!CheckDate(txtDEPARTURE_DATE.Text)) || (txtARRIVAL_DATE.Text.Trim().Length <= 0) || (!CheckDate(txtARRIVAL_DATE.Text)))
        {
            lblAlerting.Text = "Bạn nhập ngày đi hoặc về không đúng!";
            return;
        }

        if ((txtMEETING_STARTDATE.Text.Trim().Length <= 0) || (!CheckDate(txtMEETING_STARTDATE.Text)) || (txtMEETING_ENDDATE.Text.Trim().Length <= 0) || (!CheckDate(txtMEETING_ENDDATE.Text)))
        {
            lblAlerting.Text = "Bạn nhập ngày họp không đúng!";
            return;
        }

        if ((txtMEETING_STARTDATE.Text.Trim().Length <= 0) || (!CheckQuota(txtMEETING_STARTDATE.Text)))
        {
            lblAlerting.Text = "Với ngày họp này, người đăng ký không còn đủ quota";
            return;
        }


        if (!CheckDateRegister(txtMEETING_STARTDATE.Text.Trim()))
        {
           trWarning.Visible=true;
           obj.WARNING = lblWarning.Text = "(*) Đối với cuộc họp này bạn phải đăng ký trước 30 ngày làm việc";
        }
        else
        {
            trWarning.Visible=false;
            obj.WARNING =lblWarning.Text= string.Empty;
        }

        // Kiem tra xem trong  pax nay số người đồng tổ chức đủ chưa?
        MeetingBO objBO = new MeetingBO();

      
        //Kiem tra người này có UserType la gi
        if(int.Parse(hdfORGANIZER_USERTYPEID.Value)<=0)
        {
            lblAlerting.Text = "Danh hiệu của bạn chưa đủ để đăng ký hội họp này!";
            return;
        }
        //Kiem tra xem no con quota ko?
        if (!(bool.Parse(hdfORGANIZER_QUOTA_CHECK.Value)))
        {
            lblAlerting.Text = "Bạn hết quota đăng ký cuộc họp này!";
            return;
        }
       
        //Thực hiên Insert

        obj.ID = int.Parse(hdfID.Value);
        obj.ORGANIZER_USERID = int.Parse(hdfORGANIZER_USERID.Value);
        obj.ORGANIZER_USERTYPEID = int.Parse(hdfORGANIZER_USERTYPEID.Value);
        obj.MEETINGNAME = txtMEETINGNAME.Text.Trim();
        obj.MEETING_PLACE_NAME = txtMEETING_PLACE_NAME.Text.Trim();
        obj.MEETING_ADDRESS = txtMEETING_ADDRESS.Text.Trim();

        obj.MEETING_STARTDATE = DateTime.ParseExact(txtMEETING_STARTDATE.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        obj.MEETING_ENDDATE = DateTime.ParseExact(txtMEETING_ENDDATE.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        obj.DEPARTURE_DATE = DateTime.ParseExact(txtDEPARTURE_DATE.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        obj.ARRIVAL_DATE = DateTime.ParseExact(txtARRIVAL_DATE.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        obj.COUNTRYNAME = txtCOUNTRYNAME.Text.Trim();
        
        obj.MEETINGTYPEID = 3;
        obj.STATUS_MEETING_REGISTERID = 1;
        obj.CREATEUSER = int.Parse(Session["UserID"].ToString());
        obj.CREATEUSER_USERTYPEID = int.Parse(hdfORGANIZER_USERTYPEID.Value);
        obj.FOREIGNER = false;
        obj.REPORTED = true;

        obj.SPEAKER_ADAID_1 = txtSPEAKER_ADAID_1.Text.Trim();
        obj.SPEAKER_USERTYPENAME_1 = txtSPEAKER_USERTYPENAME_1.Text.Trim();
        obj.SPEAKER_NAME_1 = txtSPEAKER_NAME_1.Text.Trim();
        obj.PAXID = 1;
        obj.CREATEUSER = int.Parse(Session["UserID"].ToString());
        obj.UPDATEUSER = int.Parse(Session["UserID"].ToString());
        if (int.Parse(hdfID.Value) <= 0)
        {
            hdfID.Value = objBO.MeetingInsert(obj).ToString();
            if (int.Parse(hdfID.Value) > 0)
            {
                btnClone.Visible = true;
                btnSave.Text = "Cập nhật";
                lblAlerting.Text = "Anh/Chị đã đăng ký thành công, Công ty Amway sẽ có thông báo đến Anh/Chị ngay sau khi hoàn thành việc xử lý hồ sơ đăng ký!";
                return;
            }
            else
            {
                lblAlerting.Text = "Đăng ký hội họp mới thất bại, bạn vui lòng thử lại!";
                return;
            }
        }
        else
        {
            //kiem tra xem cuộc họp này đã được duyệt chưa mà sửa
            if (objBO.MeetingGet_ListByID(int.Parse(hdfID.Value)).STATUS_MEETING_REGISTERID <= 1)
            {
                //Neu duyet roi thì được sửa
                if (objBO.MeetingUpdate(obj,1))
                {
                    lblAlerting.Text = "Anh/Chị đã cập nhật đăng ký thành công, Công ty Amway sẽ có thông báo đến Anh/Chị ngay sau khi hoàn thành việc xử lý hồ sơ đăng ký!!";
                    return;
                }
                else
                {
                    lblAlerting.Text = "Cập nhật đăng ký hội họp thất bại, bạn vui lòng thử lại!";
                    return;
                }
            }
            else
            {
                lblAlerting.Text = "Cập nhật đăng ký hội họp thất bại, đăng ký này đã được phê duyệt!";
                return;
            }
        }

    }
    public void GetInfoUserLogin(int UserID)
    {
        lblORGANIZER_OK.Text = string.Empty;
        lblAlerting.Text = string.Empty;
        hdfORGANIZER_USERID.Value = string.Empty;
        lblORGANIZER_NAME.Text = string.Empty;
        lblORGANIZER_USERTYPENAME.Text = string.Empty;
        lblORGANIZER_EMAIL.Text = string.Empty;
        lblORGANIZER_TELEPHONE.Text = string.Empty;
        hdfORGANIZER_USERTYPEID.Value = string.Empty;
        UserBO objBO = new UserBO();
        PRC_SYS_AMW_USER_GETLISTBYUSERIDResult result = new PRC_SYS_AMW_USER_GETLISTBYUSERIDResult();
        result = objBO.UserGetListByUserID(UserID);
        if (result != null)
        {
            txtORGANIZER_ADAID.Text = result.ADA;
            hdfORGANIZER_USERID.Value = result.USERID.ToString();
            lblORGANIZER_NAME.Text = result.FULLNAME;
            lblORGANIZER_USERTYPENAME.Text = result.USERTYPENAME;
            lblORGANIZER_EMAIL.Text = result.EMAIL;
            lblORGANIZER_TELEPHONE.Text = result.TELEPHONE;
            hdfORGANIZER_USERTYPEID.Value = result.USERTYPEID.ToString();
        }
        divORGANIZER_QUOTA.Visible = false;
        hdfORGANIZER_QUOTA_CHECK.Value = "false";
        ImgBtnORGANIZER_OK.Visible = false;
        ImgBtnORGANIZER_ERROR.Visible = false;
    }
    private bool CheckNumber(string strValue)
    {
        try
        {
            int.Parse(strValue.Replace(",", ""));
            return true;
        }
        catch
        {
            return false;
        }
    }
    private bool CheckDate(string strDate)
    {
        try
        {
            DateTime dt = DateTime.ParseExact(strDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            return true;
        }
        catch
        {
            return false;
        }
    }

    private bool CheckDateRegister(string strRegisterDate)
    {
        try
        {
            DateTime dt1 = DateTime.ParseExact(strRegisterDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dt2 = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            double day = (dt1- dt2).TotalDays;
            if (day > 30)
                return true;
            else return false;
        }
        catch
        {
            return false;
        }
    }

    public bool CheckQuota(string strNgayHoiHop)
    {
        divORGANIZER_QUOTA.Visible = false;
        hdfORGANIZER_QUOTA_CHECK.Value = "false";
        ImgBtnORGANIZER_OK.Visible = false;
        ImgBtnORGANIZER_ERROR.Visible = false;
        bool valueReturn = false;
        DateTime NgayHoiHop = DateTime.ParseExact(strNgayHoiHop, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            
        if (hdfORGANIZER_USERID.Value.Trim().Length > 0)
        {
            
            MeetingBO objMeeting = new MeetingBO();
            PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADA_OUTSIDEResult result1 = new PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADA_OUTSIDEResult();
            result1 = objMeeting.Meeting_CheckQuota_OutSide(int.Parse(hdfORGANIZER_USERID.Value), 1, NgayHoiHop);
            if (result1 != null)
            {
                divORGANIZER_QUOTA.Visible = true;
                hdfORGANIZER_QUOTA_CHECK.Value = result1.ISQUOTA.ToString();
                if (result1.ISQUOTA ?? false)
                {
                    valueReturn = true;
                    ImgBtnORGANIZER_OK.Visible = true;
                    ImgBtnORGANIZER_ERROR.Visible = false;
                    lblORGANIZER_OK.Text = "Đủ điều kiện";
                }
                else
                {
                    valueReturn = false;
                    ImgBtnORGANIZER_OK.Visible = false;
                    ImgBtnORGANIZER_ERROR.Visible = true;
                    lblORGANIZER_OK.Text = "Không đủ điều kiện";
                }
            }
        }
        return valueReturn;
    }

    protected void btnClone_Click(object sender, EventArgs e)
    {
        string strUrl = "../meeting/outsidecountrycloneR" + hdfID.Value;
        Response.Redirect(strUrl);
    }
}