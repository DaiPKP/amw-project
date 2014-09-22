using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Data;

public partial class Meeting_UserControl_uc_SupportCost : System.Web.UI.UserControl
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
        hdfID.Value = _ID.ToString();

        SetEnable(true);
        if (_ID > 0)
        {
            btnSave.Text = "Cập nhật";
            LoadData(int.Parse(hdfID.Value));
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
                lblORGANIZER_ADDRESS.Text = result.ORGANIZER_ADDRESS == null ? string.Empty : result.ORGANIZER_ADDRESS;
                lblORGANIZER_TELEPHONE.Text = result.ORGANIZER_TELEPHONE == null ? string.Empty : result.ORGANIZER_TELEPHONE;
                lblORGANIZER_USERTYPENAME.Text = result.ORGANIZER_USERTYPENAME == null ? string.Empty : result.ORGANIZER_USERTYPENAME;
                ddlPAXID.SelectedValue = result.PAXID == null ? string.Empty : result.PAXID.ToString();
                hdfPAXID_OLD.Value = result.PAXID == null ? string.Empty : result.PAXID.ToString();
                GetProvinceCBO();
                ddlPROVINCEID.SelectedValue = result.PROVINCEID == null ? string.Empty : result.PROVINCEID.ToString();
                GetBannerCBO();
                GetInvitationCBO();
                GetDistrictCBO(int.Parse(ddlPROVINCEID.SelectedValue));
                GetPlaceCBO(int.Parse(ddlDISTRICTID.SelectedValue));

                txtCO_ORGANIZER_ADAID_1.Text = result.CO_ORGANIZER_ADAID_1 == null ? string.Empty : result.CO_ORGANIZER_ADAID_1;
                lblCO_ORGANIZER_NAME_1.Text = result.CO_ORGANIZER_NAME_1 == null ? string.Empty : result.CO_ORGANIZER_NAME_1;
                lblCO_ORGANIZER_USERTYPENAME_1.Text = result.CO_ORGANIZER_USERTYPENAME_1 == null ? string.Empty : result.CO_ORGANIZER_USERTYPENAME_1;
                txtCO_ORGANIZER_ADAID_2.Text = result.CO_ORGANIZER_ADAID_2 == null ? string.Empty : result.CO_ORGANIZER_ADAID_2;
                lblCO_ORGANIZER_NAME_2.Text = result.CO_ORGANIZER_NAME_2 == null ? string.Empty : result.CO_ORGANIZER_NAME_2;
                lblCO_ORGANIZER_USERTYPENAME_2.Text = result.CO_ORGANIZER_USERTYPENAME_2 == null ? string.Empty : result.CO_ORGANIZER_USERTYPENAME_2;
                txtCO_ORGANIZER_ADAID_3.Text = result.CO_ORGANIZER_ADAID_3 == null ? string.Empty : result.CO_ORGANIZER_ADAID_3;
                lblCO_ORGANIZER_NAME_3.Text = result.CO_ORGANIZER_NAME_3 == null ? string.Empty : result.CO_ORGANIZER_NAME_3;
                lblCO_ORGANIZER_USERTYPENAME_3.Text = result.CO_ORGANIZER_USERTYPENAME_3 == null ? string.Empty : result.CO_ORGANIZER_USERTYPENAME_3;
                txtMEETINGNAME.Text = result.MEETINGNAME == null ? string.Empty : result.MEETINGNAME;
                txtNUMBER_OF_PARTICIPANT.Text = result.NUMBER_OF_PARTICIPANT == null ? string.Empty : string.Format("{0:N0}", result.NUMBER_OF_PARTICIPANT);
                txtMEETING_PLACE_NAME.Text = result.MEETING_PLACE_NAME == null ? string.Empty : result.MEETING_PLACE_NAME;
                txtMEETING_ADDRESS.Text = result.MEETING_ADDRESS == null ? string.Empty : result.MEETING_ADDRESS;
                txtMEETING_DATE.Text = result.MEETING_DATE == null ? string.Empty : result.STR_MEETING_DATE;
                txtMEETING_TIME.Text = result.MEETING_TIME == null ? string.Empty : result.MEETING_TIME;
                ddlFORMS_OF_PAYMENTID.SelectedValue = result.FORMS_OF_PAYMENTID == null ? string.Empty : result.FORMS_OF_PAYMENTID.ToString();
                ddlINVITATIONID.SelectedValue = result.INVITATIONID == null ? string.Empty : result.INVITATIONID.ToString();
                ddlBANNERID.SelectedValue = result.BANNERID == null ? string.Empty : result.BANNERID.ToString();
                txtSEND_INVITATION_DATE.Text = result.SEND_INVITATION_DATE == null ? string.Empty : result.STR_SEND_INVITATION_DATE;
                hdfReported.Value = result.REPORTED == null ? "false" : result.REPORTED.ToString();
                ddlWATER.SelectedValue = result.WATER.ToString();
                ddlFOOD.SelectedValue = result.FOOD.ToString();
                txtWATER_PRICE.Text = result.WATER_PRICE == null ? string.Empty : string.Format("{0:N0}", result.WATER_PRICE);
                txtFOOD_PRICE.Text = result.FOOD_PRICE == null ? string.Empty : string.Format("{0:N0}", result.FOOD_PRICE);
                txtSPEAKER_TITLE_1.Text = result.SPEAKER_TITLE_1 == null ? string.Empty : result.SPEAKER_TITLE_1;
                txtSPEAKER_ADAID_1.Text = result.SPEAKER_ADAID_1 == null ? string.Empty : result.SPEAKER_ADAID_1;
                txtSPEAKER_NAME_1.Text = result.SPEAKER_NAME_2 == null ? string.Empty : result.SPEAKER_NAME_1;
                txtSPEAKER_USERTYPENAME_1.Text = result.SPEAKER_USERTYPENAME_1 == null ? string.Empty : result.SPEAKER_USERTYPENAME_1;
                txtSPEAKER_TITLE_2.Text = result.SPEAKER_TITLE_2 == null ? string.Empty : result.SPEAKER_TITLE_2;
                txtSPEAKER_ADAID_2.Text = result.SPEAKER_ADAID_2 == null ? string.Empty : result.SPEAKER_ADAID_2;
                txtSPEAKER_NAME_2.Text = result.SPEAKER_NAME_2 == null ? string.Empty : result.SPEAKER_NAME_2;
                txtSPEAKER_USERTYPENAME_2.Text = result.SPEAKER_USERTYPENAME_2 == null ? string.Empty : result.SPEAKER_USERTYPENAME_2;
                txtTOTAL_PAY.Text = result.TOTAL_PAY == null ? string.Empty : string.Format("{0:N0}", result.TOTAL_PAY);
                lblAMWAY_PAY.Text = result.AMWAY_PAY == null ? string.Empty : string.Format("{0:N0}", result.AMWAY_PAY);
                lblDISTRIBUTOR_PAY.Text = result.DISTRIBUTOR_PAY == null ? string.Empty : string.Format("{0:N0}", result.DISTRIBUTOR_PAY);

                hdfCO_ORGANIZER_USERID_1.Value = result.CO_ORGANIZER_USERID_1 == null ? string.Empty : result.CO_ORGANIZER_USERID_1.ToString();
                hdfCO_ORGANIZER_USERID_2.Value = result.CO_ORGANIZER_USERID_2 == null ? string.Empty : result.CO_ORGANIZER_USERID_2.ToString();
                hdfCO_ORGANIZER_USERID_3.Value = result.CO_ORGANIZER_USERID_3 == null ? string.Empty : result.CO_ORGANIZER_USERID_3.ToString();
                hdfORGANIZER_USERID.Value = result.ORGANIZER_USERID == null ? string.Empty : result.ORGANIZER_USERID.ToString();
                hdfORGANIZER_USERTYPEID.Value = result.ORGANIZER_USERTYPEID == null ? string.Empty : result.ORGANIZER_USERTYPEID.ToString();
                hdfCO_ORGANIZER_USERTYPEID_1.Value = result.CO_ORGANIZER_USERTYPEID_1 == null ? string.Empty : result.CO_ORGANIZER_USERTYPEID_1.ToString();
                hdfCO_ORGANIZER_USERTYPEID_2.Value = result.CO_ORGANIZER_USERTYPEID_2 == null ? string.Empty : result.CO_ORGANIZER_USERTYPEID_2.ToString();
                hdfCO_ORGANIZER_USERTYPEID_3.Value = result.CO_ORGANIZER_USERTYPEID_3 == null ? string.Empty : result.CO_ORGANIZER_USERTYPEID_3.ToString();
                ddlDISTRICTID.SelectedValue = result.DISTRICTID == null ? string.Empty : result.DISTRICTID.ToString();
                chkAgree.Checked = result.AGREE == null ? false : result.AGREE ?? false;
                lblWarning.Text = result.WARNING == null ? string.Empty : result.WARNING;
                hdfMAXPAYMENT.Value = GetMaxPayment().ToString();

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
                if (hdfCO_ORGANIZER_USERID_1.Value.Length > 0)
                {
                    divCO_ORGANIZER_QUOTA_1.Visible = true;
                    ImgBtnCO_ORGANIZER_OK_1.Visible = true;
                    hdfCO_ORGANIZER_QUOTA_CHECK_1.Value = "true";
                    ImgBtnCO_ORGANIZER_ERROR_1.Visible = false;
                }
                if (hdfCO_ORGANIZER_USERID_2.Value.Length > 0)
                {
                    divCO_ORGANIZER_QUOTA_2.Visible = true;
                    ImgBtnCO_ORGANIZER_OK_2.Visible = true;
                    hdfCO_ORGANIZER_QUOTA_CHECK_2.Value = "true";
                    ImgBtnCO_ORGANIZER_ERROR_2.Visible = false;
                }
                if (hdfCO_ORGANIZER_USERID_3.Value.Length > 0)
                {
                    divCO_ORGANIZER_QUOTA_3.Visible = true;
                    ImgBtnCO_ORGANIZER_OK_3.Visible = true;
                    hdfCO_ORGANIZER_QUOTA_CHECK_3.Value = "true";
                    ImgBtnCO_ORGANIZER_ERROR_3.Visible = false;
                }

                if (result.STATUS_MEETING_REGISTERID > 1)
                {
                    SetEnable(false);

                }
                else
                {
                    SetEnable(true);
                }


            }
        }
        else
        {
            ClearTextBox();
        }

    }
    private void ClearTextBox()
    {
        GetPaxCBO();
        GetProvinceCBO();
        GetBannerCBO();
        GetInvitationCBO();
        GetDistrictCBO(0);
        GetPlaceCBO(0);
        GetFormOfPaymentCBO();
        lblAlerting.Text = string.Empty;
        hdfReported.Value = "false";
        hdfID.Value = "-1";
        hdfPAXID_OLD.Value = "-1";
        btnSave.Text = "Đăng ký";
        btnSave.Visible = true;
        txtORGANIZER_ADAID.ReadOnly = true;
        txtORGANIZER_ADAID.Text = string.Empty;
        hdfORGANIZER_USERID.Value = string.Empty;
        lblORGANIZER_NAME.Text = string.Empty;
        lblORGANIZER_EMAIL.Text = string.Empty;
        lblORGANIZER_ADDRESS.Text = string.Empty;
        lblORGANIZER_TELEPHONE.Text = string.Empty;
        lblORGANIZER_USERTYPENAME.Text = string.Empty;
        hdfORGANIZER_USERTYPEID.Value = string.Empty;
        ddlPAXID.SelectedIndex = 0;
        ddlPROVINCEID.SelectedIndex = 0;

        txtCO_ORGANIZER_ADAID_1.Text = string.Empty;
        hdfCO_ORGANIZER_USERID_1.Value = string.Empty;
        lblCO_ORGANIZER_NAME_1.Text = string.Empty;
        lblCO_ORGANIZER_USERTYPENAME_1.Text = string.Empty;
        hdfCO_ORGANIZER_USERTYPEID_1.Value = string.Empty;

        txtCO_ORGANIZER_ADAID_2.Text = string.Empty;
        hdfCO_ORGANIZER_USERID_2.Value = string.Empty;
        lblCO_ORGANIZER_NAME_2.Text = string.Empty;
        lblCO_ORGANIZER_USERTYPENAME_2.Text = string.Empty;
        hdfCO_ORGANIZER_USERTYPEID_2.Value = string.Empty;

        txtCO_ORGANIZER_ADAID_3.Text = string.Empty;
        hdfCO_ORGANIZER_USERID_3.Value = string.Empty;
        lblCO_ORGANIZER_NAME_3.Text = string.Empty;
        lblCO_ORGANIZER_USERTYPENAME_3.Text = string.Empty;
        hdfCO_ORGANIZER_USERTYPEID_3.Value = string.Empty;

        txtMEETINGNAME.Text = string.Empty;
        txtNUMBER_OF_PARTICIPANT.Text = string.Empty;
        ddlFORMS_OF_PAYMENTID.SelectedIndex = 0;
        ddlPLACE.SelectedIndex = 0;
        txtMEETING_PLACE_NAME.Text = string.Empty;
        txtMEETING_ADDRESS.Text = "Số..., Đường..., Phường/Xã..., Quận/Huyện..., Tỉnh/TP...";
        txtMEETING_DATE.Text = string.Empty;
        txtMEETING_TIME.Text = "00h00 – 00h00";

        ddlINVITATIONID.SelectedIndex = 0;
        ddlBANNERID.SelectedIndex = 0;
        txtSEND_INVITATION_DATE.Text = string.Empty;

        txtWATER_PRICE.Text = string.Empty;
        txtFOOD_PRICE.Text = string.Empty;

        txtSPEAKER_TITLE_1.Text = string.Empty;
        txtSPEAKER_ADAID_1.Text = string.Empty;
        txtSPEAKER_USERTYPENAME_1.Text = string.Empty;

        txtSPEAKER_TITLE_2.Text = string.Empty;
        txtSPEAKER_ADAID_2.Text = string.Empty;
        txtSPEAKER_USERTYPENAME_2.Text = string.Empty;

        divCO_ORGANIZER_QUOTA_1.Visible = false;
        ImgBtnCO_ORGANIZER_OK_1.Visible = false;
        ImgBtnCO_ORGANIZER_ERROR_1.Visible = false;

        divCO_ORGANIZER_QUOTA_2.Visible = false;
        ImgBtnCO_ORGANIZER_OK_2.Visible = false;
        ImgBtnCO_ORGANIZER_ERROR_2.Visible = false;

        divCO_ORGANIZER_QUOTA_3.Visible = false;
        ImgBtnCO_ORGANIZER_OK_3.Visible = false;
        ImgBtnCO_ORGANIZER_ERROR_3.Visible = false;


        hdfCO_ORGANIZER_QUOTA_CHECK_1.Value = "false";
        hdfCO_ORGANIZER_QUOTA_CHECK_2.Value = "false";
        hdfCO_ORGANIZER_QUOTA_CHECK_3.Value = "false";
        lblCO_ORGANIZER_OK_1.Text = string.Empty;
        lblCO_ORGANIZER_OK_2.Text = string.Empty;
        lblCO_ORGANIZER_OK_3.Text = string.Empty;

    }
    private void SetEnable(bool bolValue)
    {

        trSave.Visible = bolValue;
        btnSave.Visible = bolValue;
        trReport.Visible = !bolValue;
        btnReport.Visible = !bolValue;
        txtORGANIZER_ADAID.Enabled = bolValue;

        ddlPAXID.Enabled = bolValue;
        ddlPROVINCEID.Enabled = bolValue;
        ddlDISTRICTID.Enabled = bolValue;
        txtCO_ORGANIZER_ADAID_1.Enabled = bolValue;
        txtCO_ORGANIZER_ADAID_2.Enabled = bolValue;

        txtCO_ORGANIZER_ADAID_3.Enabled = bolValue;
        txtMEETINGNAME.Enabled = bolValue;
        txtNUMBER_OF_PARTICIPANT.Enabled = bolValue;
        ddlFORMS_OF_PAYMENTID.Enabled = bolValue;
        ddlPLACE.Enabled = bolValue;
        txtMEETING_PLACE_NAME.Enabled = bolValue;
        txtMEETING_ADDRESS.Enabled = bolValue;
        txtMEETING_DATE.Enabled = bolValue;
        txtMEETING_TIME.Enabled = bolValue;

        ddlINVITATIONID.Enabled = bolValue;
        ddlBANNERID.Enabled = bolValue;
        txtSEND_INVITATION_DATE.Enabled = bolValue;

        txtWATER_PRICE.Enabled = bolValue;
        txtFOOD_PRICE.Enabled = bolValue;

        txtSPEAKER_TITLE_1.Enabled = bolValue;
        txtSPEAKER_ADAID_1.Enabled = bolValue;
        txtSPEAKER_USERTYPENAME_1.Enabled = bolValue;
        txtSPEAKER_NAME_1.Enabled = bolValue;
        txtSPEAKER_NAME_2.Enabled = bolValue;
        txtSPEAKER_TITLE_2.Enabled = bolValue;
        txtSPEAKER_ADAID_2.Enabled = bolValue;
        txtSPEAKER_USERTYPENAME_2.Enabled = bolValue;
        ImgBtnCO_ORGANIZER_ADA1_CHECK.Enabled = bolValue;
        ImgBtnCO_ORGANIZER_ADA2_CHECK.Enabled = bolValue;
        ImgBtnCO_ORGANIZER_ADA3_CHECK.Enabled = bolValue;
        txtTOTAL_PAY.Enabled = bolValue;
    }
    private void GetInvitationCBO()
    {
        try
        {
            CategoryBO objBO = new CategoryBO();
            List<DAL.PRC_SYS_AMW_STATUS_INVITATION_CBOResult> lst = new List<DAL.PRC_SYS_AMW_STATUS_INVITATION_CBOResult>();
            lst = objBO.InvitationGet_CBO().ToList();
            if (lst != null)
            {
                ddlINVITATIONID.DataSource = lst;
                ddlINVITATIONID.DataTextField = "STATUSNAME";
                ddlINVITATIONID.DataValueField = "ID";
                ddlINVITATIONID.DataBind();

                ListItem lstParent = new ListItem("--Chọn--", "0");
                ddlINVITATIONID.Items.Insert(0, lstParent);
                ddlINVITATIONID.SelectedIndex = ddlINVITATIONID.Items.IndexOf(lstParent);
            }
        }
        catch
        {
        }
    }


    private void GetFormOfPaymentCBO()
    {
        try
        {
            CategoryBO objBO = new CategoryBO();
            List<DAL.PRC_SYS_AMW_STATUS_FORMS_OF_PAYMENT_CBOResult> lst = new List<DAL.PRC_SYS_AMW_STATUS_FORMS_OF_PAYMENT_CBOResult>();
            lst = objBO.FormsOfPaymentGet_CBO().ToList();
            if (lst != null)
            {
                ddlFORMS_OF_PAYMENTID.DataSource = lst;
                ddlFORMS_OF_PAYMENTID.DataTextField = "STATUSNAME";
                ddlFORMS_OF_PAYMENTID.DataValueField = "ID";
                ddlFORMS_OF_PAYMENTID.DataBind();

                ListItem lstParent = new ListItem("--Chọn--", "0");
                ddlFORMS_OF_PAYMENTID.Items.Insert(0, lstParent);
                ddlFORMS_OF_PAYMENTID.SelectedIndex = ddlFORMS_OF_PAYMENTID.Items.IndexOf(lstParent);
            }
        }
        catch
        {
        }
    }
    private void GetPlaceCBO(int districtId)
    {
        try
        {
            CategoryBO objBO = new CategoryBO();
            List<DAL.PRC_SYS_AMW_PLACE_GETLISTBY_DISTRICTIDResult> lst = new List<DAL.PRC_SYS_AMW_PLACE_GETLISTBY_DISTRICTIDResult>();
            lst = objBO.PlaceGet_ByDistrictId(districtId).ToList();
            if (lst != null)
            {
                ddlPLACE.DataSource = lst;
                ddlPLACE.DataTextField = "PLACENAME";
                ddlPLACE.DataValueField = "PLACEADDRESS";
                ddlPLACE.DataBind();

                ListItem lstParent = new ListItem("--Chọn--", "0");
                ddlPLACE.Items.Insert(0, lstParent);
                ddlPLACE.SelectedIndex = ddlPLACE.Items.IndexOf(lstParent);
            }
        }
        catch
        {
        }
    }

    private void GetBannerCBO()
    {
        try
        {
            CategoryBO objBO = new CategoryBO();
            List<DAL.PRC_SYS_AMW_STATUS_BANNER_CBOResult> lst = new List<DAL.PRC_SYS_AMW_STATUS_BANNER_CBOResult>();
            lst = objBO.StatusBannerGet_CBO().ToList();
            if (lst != null)
            {
                ddlBANNERID.DataSource = lst;
                ddlBANNERID.DataTextField = "STATUSNAME";
                ddlBANNERID.DataValueField = "ID";
                ddlBANNERID.DataBind();

                ListItem lstParent = new ListItem("--Chọn--", "0");
                ddlBANNERID.Items.Insert(0, lstParent);
                ddlBANNERID.SelectedIndex = ddlBANNERID.Items.IndexOf(lstParent);
            }
        }
        catch
        {
        }
    }
    private void GetPaxCBO()
    {
        try
        {
            CategoryBO catebo = new CategoryBO();
            List<DAL.PRC_SYS_AMW_PAX_CBOResult> lst = new List<DAL.PRC_SYS_AMW_PAX_CBOResult>();
            lst = catebo.PaxGet_CBO().ToList();
            if (lst != null)
            {
                ddlPAXID.DataSource = lst;
                ddlPAXID.DataTextField = "PAXNAME";
                ddlPAXID.DataValueField = "ID";
                ddlPAXID.DataBind();

                ListItem lstParent = new ListItem("--Chọn--", "0");
                ddlPAXID.Items.Insert(0, lstParent);
                ddlPAXID.SelectedIndex = ddlPAXID.Items.IndexOf(lstParent);
            }
        }
        catch
        {
        }
    }
    private void GetDistrictCBO(int provinceId)
    {
        try
        {
            if (provinceId > 0)
            {
                CategoryBO catebo = new CategoryBO();
                List<DAL.PRC_SYS_AMW_DISTRICT_CBOResult> lst = new List<DAL.PRC_SYS_AMW_DISTRICT_CBOResult>();
                lst = catebo.DistrictGet_CBO(provinceId).ToList();
                if (lst != null)
                {

                    ListItem lstParent = new ListItem("--Chọn--", "0");
                    ddlDISTRICTID.DataSource = lst;
                    ddlDISTRICTID.DataTextField = "DISTRICTNAME";
                    ddlDISTRICTID.DataValueField = "ID";
                    ddlDISTRICTID.DataBind();

                    ddlDISTRICTID.Items.Insert(0, lstParent);
                    ddlDISTRICTID.SelectedIndex = ddlDISTRICTID.Items.IndexOf(lstParent);
                }
            }
            else
            {
                ListItem lstParent = new ListItem("--Chọn--", "0");
                ddlDISTRICTID.Items.Add(lstParent);
                ddlDISTRICTID.SelectedIndex = ddlDISTRICTID.Items.IndexOf(lstParent);
            }
        }
        catch
        {
        }
    }
    private void GetProvinceCBO()
    {
        try
        {

            CategoryBO catebo = new CategoryBO();
            List<DAL.PRC_SYS_AMW_PROVINCE_CBOResult> lst = new List<DAL.PRC_SYS_AMW_PROVINCE_CBOResult>();
            lst = catebo.ProvinceGet_CBO().ToList();
            if (lst != null)
            {
                ddlPROVINCEID.DataSource = lst;
                ddlPROVINCEID.DataTextField = "PROVINCENAME";
                ddlPROVINCEID.DataValueField = "ID";
                ddlPROVINCEID.DataBind();

                ListItem lstParent = new ListItem("--Chọn--", "0");
                ddlPROVINCEID.Items.Insert(0, lstParent);
                ddlPROVINCEID.SelectedIndex = ddlPROVINCEID.Items.IndexOf(lstParent);

            }
        }

        catch
        {
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        USR_AMW_MEETING_REGISTER obj = new USR_AMW_MEETING_REGISTER();
        // Thuc hien Insert Update
        //Kiem tra lai nhap đủ dữ liệu chưa?

        if (txtORGANIZER_ADAID.Text.Trim().Length <= 0)
        {
            lblAlerting.Text = "Bạn chưa nhập mã số ADA của người tổ chức!";
            return;
        }

        if (lblORGANIZER_NAME.Text.Trim().Length <= 0)
        {
            lblAlerting.Text = "Bạn chưa lấy thông tin của người tổ chức!";
            return;
        }

        if (int.Parse(ddlPAXID.SelectedValue) <= 0)
        {
            lblAlerting.Text = "Bạn chưa chọn loại phòng hội họp!";
            return;
        }


        if (int.Parse(ddlPROVINCEID.SelectedValue) <= 0)
        {
            lblAlerting.Text = "Bạn chưa chọn tỉnh thành tổ chức hội họp!";
            return;
        }
        if (int.Parse(ddlDISTRICTID.SelectedValue) <= 0)
        {
            lblAlerting.Text = "Bạn chưa chọn quận huyện tổ chức hội họp!";
            return;
        }

        if (hdfCO_ORGANIZER_USERID_1.Value.Length <= 0)
        {
            lblAlerting.Text = "Bạn chưa nhập mã số ADA của người đăng ký hội họp!";
            return;
        }

        if (txtMEETINGNAME.Text.Trim().Length <= 0)
        {
            lblAlerting.Text = "Bạn chưa nhập tên cuộc họp!";
            return;
        }
        if ((txtNUMBER_OF_PARTICIPANT.Text.Trim().Length <= 0) || !(CheckNumber(txtNUMBER_OF_PARTICIPANT.Text.Trim())))
        {
            lblAlerting.Text = "Bạn nhập số lượng người tham gia cuộc họp không đúng!";
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
        if ((txtMEETING_DATE.Text.Trim().Length <= 0) || (!CheckDate(txtMEETING_DATE.Text)))
        {
            lblAlerting.Text = "Bạn nhập ngày họp không đúng!";
            return;
        }
        if ((txtMEETING_DATE.Text.Trim().Length <= 0) || (!CheckQuota(txtMEETING_DATE.Text)))
        {
            lblAlerting.Text = "Với ngày họp này, người (đồng) tổ chức không còn đủ quota. Bạn có thể xem lại ở trên!";
            return;
        }
        if (int.Parse(ddlFORMS_OF_PAYMENTID.SelectedValue) <= 0)
        {
            lblAlerting.Text = "Bạn chưa chọn hình thức thanh toán!";
            return;
        }

        if (txtMEETING_TIME.Text.Trim().Length <= 0)
        {
            lblAlerting.Text = "Bạn chưa nhập thời gian hội họp!";
            return;
        }
        if (int.Parse(ddlINVITATIONID.SelectedValue) <= 0)
        {
            lblAlerting.Text = "Bạn chưa chọn loại giấy mời!";
            return;
        }

        if (int.Parse(ddlBANNERID.SelectedValue) <= 0)
        {
            lblAlerting.Text = "Bạn chưa chọn loại biểu ngữ!";
            return;
        }

        if ((txtSEND_INVITATION_DATE.Text.Trim().Length <= 0) || (!CheckDate(txtSEND_INVITATION_DATE.Text)))
        {
            lblAlerting.Text = "Bạn nhập ngày phát giấy mời không đúng!";
            return;
        }
        if ((txtTOTAL_PAY.Text.Trim().Length <= 0) || !(CheckNumber(txtTOTAL_PAY.Text.Trim())))
        {
            lblAlerting.Text = "Bạn chưa nhập tổng chi phí!";
            return;
        }
        if (bool.Parse(ddlFOOD.SelectedValue))
        {
            if ((txtFOOD_PRICE.Text.Trim().Length > 0) && (!CheckNumberMax(txtFOOD_PRICE.Text, 30000)))
            {
                lblAlerting.Text = "Bạn số tiền thức ăn không đúng!";
                return;
            }
        }
        if (bool.Parse(ddlWATER.SelectedValue))
        {
            if ((txtWATER_PRICE.Text.Trim().Length > 0) && (!CheckNumberMax(txtWATER_PRICE.Text, 25000)))
            {
                lblAlerting.Text = "Bạn số tiền nước uống không đúng!";
                return;
            }
        }
        if (!CheckProvinceOrDistrict(ddlPAXID.SelectedValue, ddlPROVINCEID.SelectedValue, ddlDISTRICTID.SelectedValue))
        {
            trWarning.Visible = true;
            obj.WARNING = lblWarning.Text = "(*) Bạn chọn tỉnh thành(quận/huyện) tổ chức không đúng qui định";


        }
        else
        {
            trWarning.Visible = false;
            obj.WARNING = lblWarning.Text = string.Empty;
        }
        if (!CheckDateRegister(txtMEETING_DATE.Text.Trim()))
        {
            if (lblWarning.Text.Length > 0)
            {
                obj.WARNING = lblWarning.Text = lblWarning.Text + ", đối với cuộc họp này bạn phải đăng ký trước 10 ngày làm việc";
            }
            else
            {
                trWarning.Visible = true;
                obj.WARNING = lblWarning.Text = "(*) Đối với cuộc họp này bạn phải đăng ký trước 10 ngày làm việc";
            }

        }
        else
        {
            if (lblWarning.Text.Length <= 0)
            {
                trWarning.Visible = false;
                obj.WARNING = lblWarning.Text = string.Empty;
            }
        }


        if (!chkAgree.Checked)
        {
            lblAlerting.Text = "Bạn chưa cam kết với dữ liệu nhập ở trên!";
            return;
        }

        // kiem tra xem la thang Nguoi dang ky co quota ko?

        if (!(bool.Parse(hdfCO_ORGANIZER_QUOTA_CHECK_1.Value)))
        {
            lblAlerting.Text = "Người tổ chức không còn đủ quota!";
            return;
        }
        else
        {
            obj.CO_ORGANIZER_USERID_1 = int.Parse(hdfCO_ORGANIZER_USERID_1.Value);
            obj.CO_ORGANIZER_USERTYPEID_1 = int.Parse(hdfCO_ORGANIZER_USERTYPEID_1.Value);
        }
        // Kiem tra xem trong  pax nay số người đồng tổ chức đủ chưa?
        MeetingBO objBO = new MeetingBO();

        int ConditionCombine = objBO.MeetingGet_ConditionCombine(int.Parse(ddlPAXID.SelectedValue), int.Parse(hdfCO_ORGANIZER_USERTYPEID_1.Value));
        int quantity = 0;
        if (bool.Parse(hdfCO_ORGANIZER_QUOTA_CHECK_1.Value)) quantity++;
        if (bool.Parse(hdfCO_ORGANIZER_QUOTA_CHECK_2.Value)) quantity++;
        if (bool.Parse(hdfCO_ORGANIZER_QUOTA_CHECK_3.Value)) quantity++;

        if (ConditionCombine > 0)
        {
            //Kiem tra xem nhung thang dong to chuc co du DK ko?
            //Kiểm tra xem có du quantity voi ConditionCombine ko
            if (ConditionCombine != quantity)
            {
                lblAlerting.Text = "Bạn nhập số lượng người đồng tổ chức không đủ!";
                return;
            }
            //Kiem tra xem nhung thang dong to chuc co cung usertype hay ko?
            if ((bool.Parse(hdfCO_ORGANIZER_QUOTA_CHECK_1.Value)) && (bool.Parse(hdfCO_ORGANIZER_QUOTA_CHECK_2.Value)) && (!bool.Parse(hdfCO_ORGANIZER_QUOTA_CHECK_3.Value)))
            {
                if ((hdfCO_ORGANIZER_USERTYPEID_1.Value != hdfCO_ORGANIZER_USERTYPEID_2.Value))
                {
                    lblAlerting.Text = "Bạn nhập người đồng tổ chức không cùng danh hiệu!";
                    return;
                }
            }
            if ((bool.Parse(hdfCO_ORGANIZER_QUOTA_CHECK_1.Value)) && (bool.Parse(hdfCO_ORGANIZER_QUOTA_CHECK_2.Value)) && (bool.Parse(hdfCO_ORGANIZER_QUOTA_CHECK_3.Value)))
            {

                if ((hdfCO_ORGANIZER_USERTYPEID_1.Value != hdfCO_ORGANIZER_USERTYPEID_2.Value) || (hdfCO_ORGANIZER_USERTYPEID_2.Value != hdfCO_ORGANIZER_USERTYPEID_3.Value))
                {
                    lblAlerting.Text = "Bạn nhập người đồng tổ chức không cùng danh hiệu!";
                    return;
                }
            }
            //Kiem tra xem no con quota ko?
            if ((bool.Parse(hdfCO_ORGANIZER_QUOTA_CHECK_1.Value)) && (bool.Parse(hdfCO_ORGANIZER_QUOTA_CHECK_2.Value)) && (!bool.Parse(hdfCO_ORGANIZER_QUOTA_CHECK_3.Value)))
            {
                if (!(bool.Parse(hdfCO_ORGANIZER_QUOTA_CHECK_1.Value)) || !(bool.Parse(hdfCO_ORGANIZER_QUOTA_CHECK_2.Value)))
                {
                    lblAlerting.Text = "Người đồng tổ chức không còn đủ quota!";
                    return;
                }
            }
            if ((bool.Parse(hdfCO_ORGANIZER_QUOTA_CHECK_1.Value)) && (bool.Parse(hdfCO_ORGANIZER_QUOTA_CHECK_2.Value)) && (bool.Parse(hdfCO_ORGANIZER_QUOTA_CHECK_3.Value)))
            {

                if (!(bool.Parse(hdfCO_ORGANIZER_QUOTA_CHECK_1.Value)) || !(bool.Parse(hdfCO_ORGANIZER_QUOTA_CHECK_2.Value)) || !(bool.Parse(hdfCO_ORGANIZER_QUOTA_CHECK_3.Value)))
                {
                    lblAlerting.Text = "Người đồng tổ chức không còn đủ quota!";
                    return;
                }
            }
            if (bool.Parse(hdfCO_ORGANIZER_QUOTA_CHECK_2.Value))
            {
                obj.CO_ORGANIZER_USERID_2 = int.Parse(hdfCO_ORGANIZER_USERID_2.Value);
                obj.CO_ORGANIZER_USERTYPEID_2 = int.Parse(hdfCO_ORGANIZER_USERTYPEID_2.Value);
            }
            if (bool.Parse(hdfCO_ORGANIZER_QUOTA_CHECK_3.Value))
            {
                obj.CO_ORGANIZER_USERID_3 = int.Parse(hdfCO_ORGANIZER_USERID_3.Value);
                obj.CO_ORGANIZER_USERTYPEID_3 = int.Parse(hdfCO_ORGANIZER_USERTYPEID_3.Value);
            }


        }
        else
        {
            if (quantity < 1)
            {
                lblAlerting.Text = "Bạn không có quota để đăng ký hội họp!";
                return;
            }
            if (quantity > 1)
            {
                lblAlerting.Text = "Cuộc họp này không cần người đồng tổ chức!";
                return;
            }
        }


        //Thực hiên Insert

        obj.ID = int.Parse(hdfID.Value);
        obj.ORGANIZER_USERID = int.Parse(hdfORGANIZER_USERID.Value);
        obj.ORGANIZER_USERTYPEID = int.Parse(hdfORGANIZER_USERTYPEID.Value);
        obj.PAXID = int.Parse(ddlPAXID.SelectedValue);
        obj.PROVINCEID = int.Parse(ddlPROVINCEID.SelectedValue);
        obj.DISTRICTID = int.Parse(ddlDISTRICTID.SelectedValue);
        obj.MEETINGNAME = txtMEETINGNAME.Text.Trim();
        obj.NUMBER_OF_PARTICIPANT = int.Parse(txtNUMBER_OF_PARTICIPANT.Text.Trim().Replace(",", ""));
        obj.MEETING_PLACE_NAME = txtMEETING_PLACE_NAME.Text.Trim();
        obj.MEETING_ADDRESS = txtMEETING_ADDRESS.Text.Trim();

        obj.MEETING_DATE = DateTime.ParseExact(txtMEETING_DATE.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        obj.MEETING_TIME = txtMEETING_TIME.Text.Trim();
        obj.FORMS_OF_PAYMENTID = int.Parse(ddlFORMS_OF_PAYMENTID.SelectedValue);
        obj.INVITATIONID = int.Parse(ddlINVITATIONID.SelectedValue);
        obj.BANNERID = int.Parse(ddlBANNERID.SelectedValue);
        obj.SEND_INVITATION_DATE = DateTime.ParseExact(txtSEND_INVITATION_DATE.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        obj.WATER = bool.Parse(ddlWATER.SelectedValue);
        if (bool.Parse(ddlWATER.SelectedValue))
        {
            if (CheckNumber(txtWATER_PRICE.Text.Trim()))
            {
                obj.WATER_PRICE = int.Parse(txtWATER_PRICE.Text.Trim().Replace(",", ""));
            }
        }
        obj.FOOD = bool.Parse(ddlFOOD.SelectedValue);
        if (bool.Parse(ddlFOOD.SelectedValue))
        {
            if (CheckNumber(txtFOOD_PRICE.Text.Trim()))
            {
                obj.FOOD_PRICE = int.Parse(txtFOOD_PRICE.Text.Trim().Replace(",", ""));
            }

        }

        obj.MEETINGTYPEID = 2;
        obj.STATUS_MEETING_REGISTERID = 1;
        obj.CREATEUSER = int.Parse(Session["UserID"].ToString());
        obj.CREATEUSER_USERTYPEID = int.Parse(hdfORGANIZER_USERTYPEID.Value);
        obj.FOREIGNER = false;
        obj.AGREE = chkAgree.Checked;
        obj.REPORTED = bool.Parse(hdfReported.Value);
        obj.SPEAKER_ADAID_1 = txtSPEAKER_ADAID_1.Text.Trim();
        obj.SPEAKER_USERTYPENAME_1 = txtSPEAKER_USERTYPENAME_1.Text.Trim();
        obj.SPEAKER_NAME_1 = txtSPEAKER_NAME_1.Text.Trim();
        obj.SPEAKER_TITLE_1 = txtSPEAKER_TITLE_1.Text.Trim();
        obj.SPEAKER_ADAID_2 = txtSPEAKER_ADAID_2.Text.Trim();
        obj.SPEAKER_USERTYPENAME_2 = txtSPEAKER_USERTYPENAME_2.Text.Trim();
        obj.SPEAKER_NAME_2 = txtSPEAKER_NAME_2.Text.Trim();
        obj.SPEAKER_TITLE_2 = txtSPEAKER_TITLE_2.Text.Trim();
        obj.CREATEUSER = int.Parse(Session["UserID"].ToString());
        obj.UPDATEUSER = int.Parse(Session["UserID"].ToString());

        if (CheckNumber(txtTOTAL_PAY.Text.Trim()))
        {
            double TOTAL_PAY = double.Parse(txtTOTAL_PAY.Text.Trim().Replace(",", ""));
            double AMWAY_PAY = 0;
            double DISTRIBUTOR_PAY = 0;
            // tinh tien theo 80%
            AMWAY_PAY = TOTAL_PAY * 0.8;
            if (AMWAY_PAY > double.Parse(hdfMAXPAYMENT.Value))
            {
                AMWAY_PAY = double.Parse(hdfMAXPAYMENT.Value);
            }
            DISTRIBUTOR_PAY = TOTAL_PAY - AMWAY_PAY;
            obj.TOTAL_PAY = (decimal)TOTAL_PAY;
            obj.AMWAY_PAY = (decimal)AMWAY_PAY;
            obj.DISTRIBUTOR_PAY = (decimal)DISTRIBUTOR_PAY;
        }
        lblAMWAY_PAY.Text = string.Format("{0:N0}", obj.AMWAY_PAY);
        lblDISTRIBUTOR_PAY.Text = string.Format("{0:N0}", obj.DISTRIBUTOR_PAY);
        if (int.Parse(hdfID.Value) <= 0)
        {
            hdfID.Value = objBO.MeetingInsert(obj).ToString();
            if (int.Parse(hdfID.Value) > 0)
            {
                hdfPAXID_OLD.Value = obj.PAXID.ToString();
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
                if (objBO.MeetingUpdate(obj, int.Parse(hdfPAXID_OLD.Value)))
                {
                    lblAlerting.Text = "Anh/Chị đã cập nhật đăng ký thành công, Công ty Amway sẽ có thông báo đến Anh/Chị ngay sau khi hoàn thành việc xử lý hồ sơ đăng ký!!";
                    hdfPAXID_OLD.Value = obj.PAXID.ToString();
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

        lblAlerting.Text = string.Empty;
        hdfORGANIZER_USERID.Value = string.Empty;
        lblORGANIZER_NAME.Text = string.Empty;
        lblORGANIZER_USERTYPENAME.Text = string.Empty;
        lblORGANIZER_EMAIL.Text = string.Empty;
        lblORGANIZER_TELEPHONE.Text = string.Empty;
        lblORGANIZER_ADDRESS.Text = string.Empty;
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
            lblORGANIZER_ADDRESS.Text = result.ADDRESS;
            hdfORGANIZER_USERTYPEID.Value = result.USERTYPEID.ToString();
        }
    }
    protected void ImgBtnCO_ORGANIZER_ADA1_CHECK_Click(object sender, ImageClickEventArgs e)
    {
        lblCO_ORGANIZER_OK_1.Text = string.Empty;
        lblAlerting.Text = string.Empty;
        hdfCO_ORGANIZER_USERID_1.Value = string.Empty;
        lblCO_ORGANIZER_NAME_1.Text = string.Empty;
        lblCO_ORGANIZER_USERTYPENAME_1.Text = string.Empty;
        hdfCO_ORGANIZER_USERTYPEID_1.Value = string.Empty;
        divCO_ORGANIZER_QUOTA_1.Visible = false;
        hdfCO_ORGANIZER_QUOTA_CHECK_1.Value = "false";
        ImgBtnCO_ORGANIZER_OK_1.Visible = false;
        ImgBtnCO_ORGANIZER_ERROR_1.Visible = false;
        hdfMAXPAYMENT.Value = "0";
        if (txtCO_ORGANIZER_ADAID_1.Text.Trim().Length > 0)
        {

            MeetingBO objBO = new MeetingBO();
            PRC_SYS_AMW_USER_GETBY_ADAResult result = new PRC_SYS_AMW_USER_GETBY_ADAResult();
            result = objBO.Meeting_GetDistributor_ByADA(txtCO_ORGANIZER_ADAID_1.Text.Trim());
            if (result != null)
            {
                hdfCO_ORGANIZER_USERID_1.Value = result.USERID.ToString();
                lblCO_ORGANIZER_NAME_1.Text = result.FULLNAME;
                lblCO_ORGANIZER_USERTYPENAME_1.Text = result.USERTYPENAME;
                hdfCO_ORGANIZER_USERTYPEID_1.Value = result.USERTYPEID.ToString();

                if ((int.Parse(ddlDISTRICTID.SelectedValue) > 0) && (int.Parse(ddlPAXID.SelectedValue) > 0))
                {
                    hdfMAXPAYMENT.Value = GetMaxPayment().ToString();
                }
                else
                {
                    hdfMAXPAYMENT.Value = "0";
                }

            }

        }
    }
    protected void ImgBtnCO_ORGANIZER_ADA2_CHECK_Click(object sender, ImageClickEventArgs e)
    {
        lblCO_ORGANIZER_OK_2.Text = string.Empty;
        lblAlerting.Text = string.Empty;
        hdfCO_ORGANIZER_USERID_2.Value = string.Empty;
        lblCO_ORGANIZER_NAME_2.Text = string.Empty;
        lblCO_ORGANIZER_USERTYPENAME_2.Text = string.Empty;
        hdfCO_ORGANIZER_USERTYPEID_2.Value = string.Empty;
        divCO_ORGANIZER_QUOTA_2.Visible = false;
        hdfCO_ORGANIZER_QUOTA_CHECK_2.Value = "false";
        ImgBtnCO_ORGANIZER_OK_2.Visible = false;
        ImgBtnCO_ORGANIZER_ERROR_2.Visible = false;

        if (txtCO_ORGANIZER_ADAID_2.Text.Trim().Length > 0)
        {
            MeetingBO objBO = new MeetingBO();
            PRC_SYS_AMW_USER_GETBY_ADAResult result = new PRC_SYS_AMW_USER_GETBY_ADAResult();
            result = objBO.Meeting_GetDistributor_ByADA(txtCO_ORGANIZER_ADAID_2.Text.Trim());
            if (result != null)
            {
                hdfCO_ORGANIZER_USERID_2.Value = result.USERID.ToString();
                lblCO_ORGANIZER_NAME_2.Text = result.FULLNAME;
                lblCO_ORGANIZER_USERTYPENAME_2.Text = result.USERTYPENAME;
                hdfCO_ORGANIZER_USERTYPEID_2.Value = result.USERTYPEID.ToString();
            }
        }

    }
    protected void ImgBtnCO_ORGANIZER_ADA3_CHECK_Click(object sender, ImageClickEventArgs e)
    {
        lblCO_ORGANIZER_OK_3.Text = string.Empty;
        lblAlerting.Text = string.Empty;
        hdfCO_ORGANIZER_USERID_3.Value = string.Empty;
        lblCO_ORGANIZER_NAME_3.Text = string.Empty;
        lblCO_ORGANIZER_USERTYPENAME_3.Text = string.Empty;
        hdfCO_ORGANIZER_USERTYPEID_3.Value = string.Empty;
        divCO_ORGANIZER_QUOTA_3.Visible = false;
        hdfCO_ORGANIZER_QUOTA_CHECK_3.Value = "false";
        ImgBtnCO_ORGANIZER_OK_3.Visible = false;
        ImgBtnCO_ORGANIZER_ERROR_3.Visible = false;

        if (txtCO_ORGANIZER_ADAID_3.Text.Trim().Length > 0)
        {
            MeetingBO objBO = new MeetingBO();
            PRC_SYS_AMW_USER_GETBY_ADAResult result = new PRC_SYS_AMW_USER_GETBY_ADAResult();
            result = objBO.Meeting_GetDistributor_ByADA(txtCO_ORGANIZER_ADAID_3.Text.Trim());
            if (result != null)
            {
                hdfCO_ORGANIZER_USERID_3.Value = result.USERID.ToString();
                lblCO_ORGANIZER_NAME_3.Text = result.FULLNAME;
                lblCO_ORGANIZER_USERTYPENAME_3.Text = result.USERTYPENAME;
                hdfCO_ORGANIZER_USERTYPEID_3.Value = result.USERTYPEID.ToString();

            }
        }
    }
    protected void ddlPROVINCEID_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblAlerting.Text = string.Empty;
        hdfCO_ORGANIZER_USERID_1.Value = string.Empty;
        lblCO_ORGANIZER_NAME_1.Text = string.Empty;
        lblCO_ORGANIZER_USERTYPENAME_1.Text = string.Empty;
        hdfCO_ORGANIZER_USERTYPEID_1.Value = string.Empty;
        divCO_ORGANIZER_QUOTA_1.Visible = false;
        hdfCO_ORGANIZER_QUOTA_CHECK_1.Value = "false";
        ImgBtnCO_ORGANIZER_OK_1.Visible = false;
        ImgBtnCO_ORGANIZER_ERROR_1.Visible = false;

        hdfCO_ORGANIZER_USERID_2.Value = string.Empty;
        lblCO_ORGANIZER_NAME_2.Text = string.Empty;
        lblCO_ORGANIZER_USERTYPENAME_2.Text = string.Empty;
        hdfCO_ORGANIZER_USERTYPEID_2.Value = string.Empty;
        divCO_ORGANIZER_QUOTA_2.Visible = false;
        hdfCO_ORGANIZER_QUOTA_CHECK_2.Value = "false";
        ImgBtnCO_ORGANIZER_OK_2.Visible = false;
        ImgBtnCO_ORGANIZER_ERROR_2.Visible = false;


        hdfCO_ORGANIZER_USERID_3.Value = string.Empty;
        lblCO_ORGANIZER_NAME_3.Text = string.Empty;
        lblCO_ORGANIZER_USERTYPENAME_3.Text = string.Empty;
        hdfCO_ORGANIZER_USERTYPEID_3.Value = string.Empty;
        divCO_ORGANIZER_QUOTA_3.Visible = false;
        hdfCO_ORGANIZER_QUOTA_CHECK_3.Value = "false";
        ImgBtnCO_ORGANIZER_OK_3.Visible = false;
        ImgBtnCO_ORGANIZER_ERROR_3.Visible = false;
        if (int.Parse(ddlPAXID.SelectedValue) > 0 && int.Parse(ddlPROVINCEID.SelectedValue) > 0)
        {
            GetDistrictCBO(int.Parse(ddlPROVINCEID.SelectedValue));
        }

    }
    private int GetMaxPayment()
    {
        MeetingBO objBO = new MeetingBO();
        return objBO.MeetingGet_MaxPayment(int.Parse(ddlPAXID.SelectedValue), int.Parse(hdfCO_ORGANIZER_USERTYPEID_1.Value));
    }

    protected void ddlPLACE_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblAlerting.Text = string.Empty;
        if (!ddlPLACE.SelectedValue.Equals("0"))
        {
            txtMEETING_PLACE_NAME.Text = ddlPLACE.SelectedItem.Text;
            txtMEETING_ADDRESS.Text = ddlPLACE.SelectedItem.Value;
        }
        else
        {
            txtMEETING_PLACE_NAME.Text = string.Empty;
            txtMEETING_ADDRESS.Text = string.Empty;
        }
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

    protected void ddlDISTRICTID_SelectedIndexChanged(object sender, EventArgs e)
    {
        hdfCO_ORGANIZER_USERID_1.Value = string.Empty;
        lblCO_ORGANIZER_NAME_1.Text = string.Empty;
        lblCO_ORGANIZER_USERTYPENAME_1.Text = string.Empty;
        hdfCO_ORGANIZER_USERTYPEID_1.Value = string.Empty;
        divCO_ORGANIZER_QUOTA_1.Visible = false;
        hdfCO_ORGANIZER_QUOTA_CHECK_1.Value = "false";
        ImgBtnCO_ORGANIZER_OK_1.Visible = false;
        ImgBtnCO_ORGANIZER_ERROR_1.Visible = false;

        hdfCO_ORGANIZER_USERID_2.Value = string.Empty;
        lblCO_ORGANIZER_NAME_2.Text = string.Empty;
        lblCO_ORGANIZER_USERTYPENAME_2.Text = string.Empty;
        hdfCO_ORGANIZER_USERTYPEID_2.Value = string.Empty;
        divCO_ORGANIZER_QUOTA_2.Visible = false;
        hdfCO_ORGANIZER_QUOTA_CHECK_2.Value = "false";
        ImgBtnCO_ORGANIZER_OK_2.Visible = false;
        ImgBtnCO_ORGANIZER_ERROR_2.Visible = false;


        hdfCO_ORGANIZER_USERID_3.Value = string.Empty;
        lblCO_ORGANIZER_NAME_3.Text = string.Empty;
        lblCO_ORGANIZER_USERTYPENAME_3.Text = string.Empty;
        hdfCO_ORGANIZER_USERTYPEID_3.Value = string.Empty;
        divCO_ORGANIZER_QUOTA_3.Visible = false;
        hdfCO_ORGANIZER_QUOTA_CHECK_3.Value = "false";
        ImgBtnCO_ORGANIZER_OK_3.Visible = false;
        ImgBtnCO_ORGANIZER_ERROR_3.Visible = false;

        GetPlaceCBO(int.Parse(ddlDISTRICTID.SelectedValue));
    }
    private bool CheckDateRegister(string strRegisterDate)
    {
        try
        {
            DateTime dt1 = DateTime.ParseExact(strRegisterDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dt2 = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            double day = (dt1 - dt2).TotalDays;
            if (day > 10)
                return true;
            else return false;
        }
        catch
        {
            return false;
        }
    }

    private bool CheckProvinceOrDistrict(string PaxId, string ProvinceId, string DistrictId)
    {
        try
        {

            MeetingBO objBO = new MeetingBO();
            if (txtCO_ORGANIZER_ADAID_1.Text.Trim().Length > 0)
            {
                if (int.Parse(PaxId) > 4)
                {

                    PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_USERID_PROVINCEResult result = new PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_USERID_PROVINCEResult();
                    result = objBO.Meeting_CheckQuota_ByUserId_Province(int.Parse(hdfCO_ORGANIZER_USERID_1.Value), int.Parse(PaxId), int.Parse(ProvinceId));
                    if (result != null)
                    {
                        if (!result.ISQUOTA ?? false)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_USERIDResult result = new PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_USERIDResult();
                    result = objBO.Meeting_CheckQuota_ByUserId(int.Parse(hdfCO_ORGANIZER_USERID_1.Value), int.Parse(PaxId), int.Parse(DistrictId));
                    if (result != null)
                    {
                        if (!result.ISQUOTA ?? false)
                        {
                            return false;
                        }
                    }
                }
            }

            if (txtCO_ORGANIZER_ADAID_2.Text.Trim().Length > 0)
            {
                if (int.Parse(PaxId) > 4)
                {

                    PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_USERID_PROVINCEResult result = new PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_USERID_PROVINCEResult();
                    result = objBO.Meeting_CheckQuota_ByUserId_Province(int.Parse(hdfCO_ORGANIZER_USERID_2.Value), int.Parse(PaxId), int.Parse(ProvinceId));
                    if (result != null)
                    {
                        if (!result.ISQUOTA ?? false)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_USERIDResult result = new PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_USERIDResult();
                    result = objBO.Meeting_CheckQuota_ByUserId(int.Parse(hdfCO_ORGANIZER_USERID_2.Value), int.Parse(PaxId), int.Parse(DistrictId));
                    if (result != null)
                    {
                        if (!result.ISQUOTA ?? false)
                        {
                            return false;
                        }
                    }
                }
            }

            if (txtCO_ORGANIZER_ADAID_3.Text.Trim().Length > 0)
            {
                if (int.Parse(PaxId) > 4)
                {

                    PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_USERID_PROVINCEResult result = new PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_USERID_PROVINCEResult();
                    result = objBO.Meeting_CheckQuota_ByUserId_Province(int.Parse(hdfCO_ORGANIZER_USERID_3.Value), int.Parse(PaxId), int.Parse(ProvinceId));
                    if (result != null)
                    {
                        if (!result.ISQUOTA ?? false)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_USERIDResult result = new PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_USERIDResult();
                    result = objBO.Meeting_CheckQuota_ByUserId(int.Parse(hdfCO_ORGANIZER_USERID_3.Value), int.Parse(PaxId), int.Parse(DistrictId));
                    if (result != null)
                    {
                        if (!result.ISQUOTA ?? false)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
        catch
        {
            return false;
        }
    }

    private bool CheckNumberMax(string strValue, int MaxValue)
    {
        try
        {
            if (MaxValue < int.Parse(strValue.Replace(",", "")))
                return false;
            else
                return true;
        }
        catch
        {
            return false;
        }
    }
    protected void ddlPAXID_SelectedIndexChanged(object sender, EventArgs e)
    {
        hdfCO_ORGANIZER_USERID_1.Value = string.Empty;
        lblCO_ORGANIZER_NAME_1.Text = string.Empty;
        lblCO_ORGANIZER_USERTYPENAME_1.Text = string.Empty;
        hdfCO_ORGANIZER_USERTYPEID_1.Value = string.Empty;
        divCO_ORGANIZER_QUOTA_1.Visible = false;
        hdfCO_ORGANIZER_QUOTA_CHECK_1.Value = "false";
        ImgBtnCO_ORGANIZER_OK_1.Visible = false;
        ImgBtnCO_ORGANIZER_ERROR_1.Visible = false;

        hdfCO_ORGANIZER_USERID_2.Value = string.Empty;
        lblCO_ORGANIZER_NAME_2.Text = string.Empty;
        lblCO_ORGANIZER_USERTYPENAME_2.Text = string.Empty;
        hdfCO_ORGANIZER_USERTYPEID_2.Value = string.Empty;
        divCO_ORGANIZER_QUOTA_2.Visible = false;
        hdfCO_ORGANIZER_QUOTA_CHECK_2.Value = "false";
        ImgBtnCO_ORGANIZER_OK_2.Visible = false;
        ImgBtnCO_ORGANIZER_ERROR_2.Visible = false;


        hdfCO_ORGANIZER_USERID_3.Value = string.Empty;
        lblCO_ORGANIZER_NAME_3.Text = string.Empty;
        lblCO_ORGANIZER_USERTYPENAME_3.Text = string.Empty;
        hdfCO_ORGANIZER_USERTYPEID_3.Value = string.Empty;
        divCO_ORGANIZER_QUOTA_3.Visible = false;
        hdfCO_ORGANIZER_QUOTA_CHECK_3.Value = "false";
        ImgBtnCO_ORGANIZER_OK_3.Visible = false;
        ImgBtnCO_ORGANIZER_ERROR_3.Visible = false;
        lblAlerting.Text = string.Empty;
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        string strUrl = "../distributor/reportR" + hdfID.Value;
        Response.Redirect(strUrl);
    }
    private int GetValuePaxId(int paxId)
    {
        try
        {
            if (paxId == 2) return 50;
            else if (paxId == 3) return 100;
            else if (paxId == 4) return 500;
            else if (paxId == 5) return 1000;
            else if (paxId == 6) return 2000;
            else return 0;
        }
        catch
        {
            return 0;
        }
    }
    private bool CheckQuantityJoin(int paxId, string strValue)
    {
        try
        {
            int value = int.Parse(strValue.Replace(",", ""));
            if (value <= GetValuePaxId(paxId))
                return true;
            else return false;
        }
        catch
        {
            return false;
        }
    }
    private bool CheckQuota(string strNgayHoiHop)
    {
        try
        {
            bool valueReturn = false;
            DateTime NgayHoiHop = DateTime.ParseExact(strNgayHoiHop, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            MeetingBO objBO = new MeetingBO();
            if (txtCO_ORGANIZER_ADAID_1.Text.Trim().Length > 0)
            {
                lblCO_ORGANIZER_OK_1.Text = string.Empty;
                lblAlerting.Text = string.Empty;
                divCO_ORGANIZER_QUOTA_1.Visible = false;
                hdfCO_ORGANIZER_QUOTA_CHECK_1.Value = "false";
                ImgBtnCO_ORGANIZER_OK_1.Visible = false;
                ImgBtnCO_ORGANIZER_ERROR_1.Visible = false;
                if (txtCO_ORGANIZER_ADAID_1.Text.Trim().Length > 0)
                {

                    V2_PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADAResult result = new V2_PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADAResult();
                    if (hdfPAXID_OLD.Value == null || hdfPAXID_OLD.Value.Length <= 0) hdfPAXID_OLD.Value = "-1";
                    result = objBO.Meeting_CheckQuota_V2(txtCO_ORGANIZER_ADAID_1.Text.Trim(), int.Parse(ddlPAXID.SelectedValue), int.Parse(hdfPAXID_OLD.Value),NgayHoiHop);
                    if (result != null)
                    {

                        divCO_ORGANIZER_QUOTA_1.Visible = true;
                        hdfCO_ORGANIZER_QUOTA_CHECK_1.Value = result.ISQUOTA.ToString();

                        if (result.ISQUOTA ?? false)
                        {
                            valueReturn = true;
                            ImgBtnCO_ORGANIZER_OK_1.Visible = true;
                            ImgBtnCO_ORGANIZER_ERROR_1.Visible = false;
                            lblCO_ORGANIZER_OK_1.Text = "Đủ điều kiện";
                        }
                        else
                        {
                            valueReturn = false;
                            ImgBtnCO_ORGANIZER_OK_1.Visible = false;
                            ImgBtnCO_ORGANIZER_ERROR_1.Visible = true;
                            lblCO_ORGANIZER_OK_1.Text = "Không đủ điều kiện";
                        }
                    }

                }
            }

            if (txtCO_ORGANIZER_ADAID_2.Text.Trim().Length > 0)
            {
                lblCO_ORGANIZER_OK_2.Text = string.Empty;
                lblAlerting.Text = string.Empty;
                divCO_ORGANIZER_QUOTA_2.Visible = false;
                hdfCO_ORGANIZER_QUOTA_CHECK_2.Value = "false";
                ImgBtnCO_ORGANIZER_OK_2.Visible = false;
                ImgBtnCO_ORGANIZER_ERROR_2.Visible = false;

                if (txtCO_ORGANIZER_ADAID_2.Text.Trim().Length > 0)
                {
                    V2_PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADAResult result = new V2_PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADAResult();
                    if (hdfPAXID_OLD.Value == null || hdfPAXID_OLD.Value.Length <= 0) hdfPAXID_OLD.Value = "-1";
                    result = objBO.Meeting_CheckQuota_V2(txtCO_ORGANIZER_ADAID_2.Text.Trim(), int.Parse(ddlPAXID.SelectedValue), int.Parse(hdfPAXID_OLD.Value), NgayHoiHop);
                    if (result != null)
                    {
                        divCO_ORGANIZER_QUOTA_2.Visible = true;
                        hdfCO_ORGANIZER_QUOTA_CHECK_2.Value = result.ISQUOTA.ToString();
                        if (result.ISQUOTA ?? false)
                        {
                            valueReturn = true;
                            ImgBtnCO_ORGANIZER_OK_2.Visible = true;
                            ImgBtnCO_ORGANIZER_ERROR_2.Visible = false;
                            lblCO_ORGANIZER_OK_2.Text = "Đủ điều kiện";
                        }
                        else
                        {
                            valueReturn = false;
                            ImgBtnCO_ORGANIZER_OK_2.Visible = false;
                            ImgBtnCO_ORGANIZER_ERROR_2.Visible = true;
                            lblCO_ORGANIZER_OK_2.Text = "Không đủ điều kiện";
                        }
                    }
                }
            }

            if (txtCO_ORGANIZER_ADAID_3.Text.Trim().Length > 0)
            {

                lblCO_ORGANIZER_OK_3.Text = string.Empty;
                lblAlerting.Text = string.Empty;
                divCO_ORGANIZER_QUOTA_3.Visible = false;
                hdfCO_ORGANIZER_QUOTA_CHECK_3.Value = "false";
                ImgBtnCO_ORGANIZER_OK_3.Visible = false;
                ImgBtnCO_ORGANIZER_ERROR_3.Visible = false;

                if (txtCO_ORGANIZER_ADAID_3.Text.Trim().Length > 0)
                {
                    V2_PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADAResult result = new V2_PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADAResult();
                    if (hdfPAXID_OLD.Value == null || hdfPAXID_OLD.Value.Length <= 0) hdfPAXID_OLD.Value = "-1";
                    result = objBO.Meeting_CheckQuota_V2(txtCO_ORGANIZER_ADAID_3.Text.Trim(), int.Parse(ddlPAXID.SelectedValue), int.Parse(hdfPAXID_OLD.Value), NgayHoiHop);
                    if (result != null)
                    {

                        divCO_ORGANIZER_QUOTA_3.Visible = true;
                        hdfCO_ORGANIZER_QUOTA_CHECK_3.Value = result.ISQUOTA.ToString();
                        if (result.ISQUOTA ?? false)
                        {
                            valueReturn = true;
                            ImgBtnCO_ORGANIZER_OK_3.Visible = true;
                            ImgBtnCO_ORGANIZER_ERROR_3.Visible = false;
                            lblCO_ORGANIZER_OK_3.Text = "Đủ điều kiện";
                        }
                        else
                        {
                            valueReturn = false;
                            ImgBtnCO_ORGANIZER_OK_3.Visible = false;
                            ImgBtnCO_ORGANIZER_ERROR_3.Visible = true;
                            lblCO_ORGANIZER_OK_3.Text = "Không đủ điều kiện";
                        }
                    }
                }
            }

            return valueReturn;
        }
        catch
        {
            return false;
        }

    }


    protected void btnXuatUyQuyen_Click(object sender, EventArgs e)
    {
         Export export = new Export();
        DataTable dTable = new DataTable();

        DataColumn column = new DataColumn();
        column.DataType = System.Type.GetType("System.String");
        column.ColumnName = "NEWVALUE";
        dTable.Columns.Add(column);

        DataRow row0 = dTable.NewRow();
        row0["NEWVALUE"] = hdfID.Value+"/ SA/ "+DateTime.Now.Year.ToString();
        dTable.Rows.Add(row0);
        DataRow row1 = dTable.NewRow();
        row1["NEWVALUE"] = DateTime.Now.Day >= 10 ? DateTime.Now.Day.ToString() : "0" + DateTime.Now.Day.ToString();
        dTable.Rows.Add(row1);
        DataRow row2 = dTable.NewRow();
        row2["NEWVALUE"] = DateTime.Now.Month >= 10 ? DateTime.Now.Month.ToString() : "0" + DateTime.Now.Month.ToString();
        dTable.Rows.Add(row2);
         DataRow row3 = dTable.NewRow();
         row3["NEWVALUE"] = DateTime.Now.Year.ToString();
        dTable.Rows.Add(row3);
        DataRow row4 = dTable.NewRow();
        row4["NEWVALUE"] = lblCO_ORGANIZER_NAME_1.Text;
        dTable.Rows.Add(row4);
        DataRow row5 = dTable.NewRow();
        row5["NEWVALUE"] = txtCO_ORGANIZER_ADAID_1.Text;
        dTable.Rows.Add(row5);
        DataRow row6 = dTable.NewRow();
        row6["NEWVALUE"] = txtMEETING_ADDRESS.Text;
        dTable.Rows.Add(row6);
        DataRow row7 = dTable.NewRow();
        row7["NEWVALUE"] = txtMEETING_TIME.Text;
        dTable.Rows.Add(row7);
        DataRow row8 = dTable.NewRow();
        row8["NEWVALUE"] = txtMEETING_DATE.Text;
        dTable.Rows.Add(row8);
        DataRow row9 = dTable.NewRow();
        row9["NEWVALUE"] = txtNUMBER_OF_PARTICIPANT.Text;
        dTable.Rows.Add(row9);
        export.ExportWord(MapPath("~/Template/Word/UQ_HTCP.doc"), dTable, "_UQ_HTCP.doc");
    }
}