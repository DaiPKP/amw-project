﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Text.RegularExpressions;
using System.Globalization;

public partial class Meeting_UserControl_uc_SupportCostForeigner : System.Web.UI.UserControl
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
                ddlPROVINCEID.SelectedValue = result.PROVINCEID == null ? string.Empty : result.PROVINCEID.ToString();
                hdfMAXPAYMENT.Value = GetMaxPayment().ToString();
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
                ddlWATER.SelectedValue = result.WATER.ToString();
                ddlFOOD.SelectedValue = result.FOOD.ToString();
                txtWATER_PRICE.Text = result.WATER_PRICE == null ? string.Empty : string.Format("{0:N0}", result.WATER_PRICE);
                txtFOOD_PRICE.Text = result.FOOD_PRICE == null ? string.Empty : string.Format("{0:N0}", result.FOOD_PRICE);
                txtSPEAKER_TITLE_1.Text = result.SPEAKER_TITLE_1 == null ? string.Empty : result.SPEAKER_TITLE_1;
                txtSPEAKER_ADAID_1.Text = result.SPEAKER_ADAID_1 == null ? string.Empty : result.SPEAKER_ADAID_1;
                txtSPEAKER_NAME_1.Text = result.SPEAKER_NAME_2 == null ? string.Empty : result.SPEAKER_NAME_1;
                txtSPEAKER_USERTYPENAME_1.Text = result.SPEAKER_USERTYPENAME_1 == null ? string.Empty : result.SPEAKER_USERTYPENAME_1;
                txtSPEAKER_NATION_1.Text = result.SPEAKER_NATION_1 == null ? string.Empty : result.SPEAKER_NATION_1;
                txtSPEAKER_TITLE_2.Text = result.SPEAKER_TITLE_2 == null ? string.Empty : result.SPEAKER_TITLE_2;
                txtSPEAKER_ADAID_2.Text = result.SPEAKER_ADAID_2 == null ? string.Empty : result.SPEAKER_ADAID_2;
                txtSPEAKER_NAME_2.Text = result.SPEAKER_NAME_2 == null ? string.Empty : result.SPEAKER_NAME_2;
                txtSPEAKER_USERTYPENAME_2.Text = result.SPEAKER_USERTYPENAME_2 == null ? string.Empty : result.SPEAKER_USERTYPENAME_2;
                txtSPEAKER_NATION_2.Text = result.SPEAKER_NATION_2 == null ? string.Empty : result.SPEAKER_NATION_2;
                txtTOTAL_PAY.Text = result.TOTAL_PAY == null ? string.Empty : string.Format("{0:N0}", result.TOTAL_PAY);
                lblAMWAY_PAY.Text = result.AMWAY_PAY == null ? string.Empty : string.Format("{0:N0}", result.TOTAL_PAY);
                lblDISTRIBUTOR_PAY.Text = result.DISTRIBUTOR_PAY == null ? string.Empty : string.Format("{0:N0}", result.DISTRIBUTOR_PAY);
                hdfReported.Value = result.REPORTED == null ? "false" : result.REPORTED.ToString();
                hdfCO_ORGANIZER_USERID_1.Value = result.CO_ORGANIZER_USERID_1 == null ? string.Empty : result.CO_ORGANIZER_USERID_1.ToString();
                hdfCO_ORGANIZER_USERID_2.Value = result.CO_ORGANIZER_USERID_1 == null ? string.Empty : result.CO_ORGANIZER_USERID_1.ToString();
                hdfCO_ORGANIZER_USERID_3.Value = result.CO_ORGANIZER_USERID_1 == null ? string.Empty : result.CO_ORGANIZER_USERID_1.ToString();
                hdfORGANIZER_USERID.Value = result.ORGANIZER_USERID == null ? string.Empty : result.ORGANIZER_USERID.ToString();
                hdfORGANIZER_USERTYPEID.Value = result.ORGANIZER_USERTYPEID == null ? string.Empty : result.ORGANIZER_USERTYPEID.ToString();
                hdfCO_ORGANIZER_USERTYPEID_1.Value = result.CO_ORGANIZER_USERTYPEID_1 == null ? string.Empty : result.CO_ORGANIZER_USERTYPEID_1.ToString();
                hdfCO_ORGANIZER_USERTYPEID_2.Value = result.CO_ORGANIZER_USERTYPEID_2 == null ? string.Empty : result.CO_ORGANIZER_USERTYPEID_2.ToString();
                hdfCO_ORGANIZER_USERTYPEID_3.Value = result.CO_ORGANIZER_USERTYPEID_3 == null ? string.Empty : result.CO_ORGANIZER_USERTYPEID_3.ToString();
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


                hdfORGANIZER_QUOTA_CHECK.Value = "true";
                divORGANIZER_QUOTA_BTN.Visible = true;
                ImgBtnORGANIZER_CHECK.Visible = true;
                ImgBtnORGANIZER_OK.Visible = true;
                ImgBtnORGANIZER_ERROR.Visible = false;
                divORGANIZER_QUOTA.Visible = true;


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
        GetPlaceCBO(0);
        GetFormOfPaymentCBO();
        lblAlerting.Text = string.Empty;
        hdfReported.Value = "false";
        hdfID.Value = "-1";
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
        ddlPROVINCE_PLACE.SelectedIndex = 0;
        ddlPLACE.SelectedIndex = 0;
        txtMEETING_PLACE_NAME.Text = string.Empty;
        txtMEETING_ADDRESS.Text = string.Empty;
        txtMEETING_DATE.Text = string.Empty;
        txtMEETING_TIME.Text = string.Empty;

        ddlINVITATIONID.SelectedIndex = 0;
        ddlBANNERID.SelectedIndex = 0;
        txtSEND_INVITATION_DATE.Text = string.Empty;

        txtWATER_PRICE.Text = string.Empty;
        txtFOOD_PRICE.Text = string.Empty;

        txtSPEAKER_TITLE_1.Text = string.Empty;
        txtSPEAKER_ADAID_1.Text = string.Empty;
        txtSPEAKER_USERTYPENAME_1.Text = string.Empty;
        txtSPEAKER_NATION_1.Text = string.Empty;

        txtSPEAKER_TITLE_2.Text = string.Empty;
        txtSPEAKER_ADAID_2.Text = string.Empty;
        txtSPEAKER_USERTYPENAME_2.Text = string.Empty;
        txtSPEAKER_NATION_2.Text = string.Empty;

        divCO_ORGANIZER_QUOTA_1.Visible = false;
        ImgBtnCO_ORGANIZER_OK_1.Visible = false;
        ImgBtnCO_ORGANIZER_ERROR_1.Visible = false;

        divCO_ORGANIZER_QUOTA_2.Visible = false;
        ImgBtnCO_ORGANIZER_OK_2.Visible = false;
        ImgBtnCO_ORGANIZER_ERROR_2.Visible = false;

        divCO_ORGANIZER_QUOTA_3.Visible = false;
        ImgBtnCO_ORGANIZER_OK_3.Visible = false;
        ImgBtnCO_ORGANIZER_ERROR_3.Visible = false;

        divORGANIZER_QUOTA_BTN.Visible = false;
        ImgBtnORGANIZER_OK.Visible = false;
        ImgBtnORGANIZER_ERROR.Visible = false;
        hdfORGANIZER_QUOTA_CHECK.Value = "false";
        hdfCO_ORGANIZER_QUOTA_CHECK_1.Value = "false";
        hdfCO_ORGANIZER_QUOTA_CHECK_2.Value = "false";
        hdfCO_ORGANIZER_QUOTA_CHECK_3.Value = "false";


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

                ddlPROVINCE_PLACE.DataSource = lst;
                ddlPROVINCE_PLACE.DataTextField = "PROVINCENAME";
                ddlPROVINCE_PLACE.DataValueField = "ID";
                ddlPROVINCE_PLACE.DataBind();

                ListItem lstParent1 = new ListItem("--Tất cả--", "0");
                ddlPROVINCE_PLACE.Items.Insert(0, lstParent1);
                ddlPROVINCE_PLACE.SelectedIndex = ddlPROVINCE_PLACE.Items.IndexOf(lstParent1);
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

        if (txtMEETINGNAME.Text.Trim().Length <= 0)
        {
            lblAlerting.Text = "Bạn chưa nhập tên cuộc họp!";
            return;
        }
        if ((txtNUMBER_OF_PARTICIPANT.Text.Trim().Length <= 0) || !(CheckNumber(txtNUMBER_OF_PARTICIPANT.Text.Trim())))
        {
            lblAlerting.Text = "Bạn chưa nhập số lượng người tham gia cuộc họp!";
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
        if (int.Parse(ddlFORMS_OF_PAYMENTID.SelectedValue) <= 0)
        {
            lblAlerting.Text = "Bạn chưa chọn hình thức thanh toán!";
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

        // Kiem tra xem trong  pax nay số người đồng tổ chức đủ chưa?
        MeetingBO objBO = new MeetingBO();

        int ConditionCombine = objBO.MeetingGet_ConditionCombine(int.Parse(ddlPAXID.SelectedValue), int.Parse(hdfORGANIZER_USERTYPEID.Value));
        int quantity = 0;
        if (bool.Parse(hdfORGANIZER_QUOTA_CHECK.Value)) quantity++;
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
            if ((hdfORGANIZER_USERTYPEID.Value != hdfCO_ORGANIZER_USERTYPEID_1.Value) || (hdfORGANIZER_USERTYPEID.Value != hdfCO_ORGANIZER_USERTYPEID_2.Value) || (hdfCO_ORGANIZER_USERTYPEID_2.Value != hdfCO_ORGANIZER_USERTYPEID_3.Value))
            {
                lblAlerting.Text = "Bạn nhập người đồng tổ chức cùng danh hiệu!";
                return;
            }
            //Kiem tra xem no con quota ko?
            if (!(bool.Parse(hdfCO_ORGANIZER_QUOTA_CHECK_1.Value)) || !(bool.Parse(hdfCO_ORGANIZER_QUOTA_CHECK_2.Value)) || !(bool.Parse(hdfCO_ORGANIZER_QUOTA_CHECK_3.Value)))
            {
                lblAlerting.Text = "Người đồng tổ chức không còn đủ quota!";
                return;
            }
            obj.CO_ORGANIZER_USERID_1 = int.Parse(hdfCO_ORGANIZER_USERID_1.Value);
            obj.CO_ORGANIZER_USERTYPEID_1 = int.Parse(hdfCO_ORGANIZER_USERTYPEID_1.Value);
            obj.CO_ORGANIZER_USERID_2 = int.Parse(hdfCO_ORGANIZER_USERID_3.Value);
            obj.CO_ORGANIZER_USERTYPEID_2 = int.Parse(hdfCO_ORGANIZER_USERTYPEID_2.Value);
            obj.CO_ORGANIZER_USERID_3 = int.Parse(hdfCO_ORGANIZER_USERID_3.Value);
            obj.CO_ORGANIZER_USERTYPEID_3 = int.Parse(hdfCO_ORGANIZER_USERTYPEID_3.Value);
        }
        else
        {
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
        obj.MEETINGNAME = txtMEETINGNAME.Text.Trim();
        obj.NUMBER_OF_PARTICIPANT = int.Parse(txtNUMBER_OF_PARTICIPANT.Text.Trim().Replace(",", ""));
        obj.MEETING_PLACE_NAME = txtMEETING_PLACE_NAME.Text.Trim();
        obj.MEETING_ADDRESS = txtMEETING_ADDRESS.Text.Trim();

        obj.MEETING_DATE = DateTime.ParseExact(txtMEETING_DATE.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        obj.MEETING_TIME = txtMEETING_TIME.Text.Trim();
        obj.FORMS_OF_PAYMENTID=int.Parse(ddlFORMS_OF_PAYMENTID.SelectedValue);
        obj.INVITATIONID = int.Parse(ddlPROVINCEID.SelectedValue);
        obj.BANNERID = int.Parse(ddlBANNERID.SelectedValue);
        obj.SEND_INVITATION_DATE = DateTime.ParseExact(txtSEND_INVITATION_DATE.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        obj.WATER = bool.Parse(ddlWATER.SelectedValue);
        if (CheckNumber(txtWATER_PRICE.Text.Trim()))
        {
            obj.WATER_PRICE = int.Parse(txtWATER_PRICE.Text.Trim().Replace(",", ""));
        }

        obj.FOOD = bool.Parse(ddlFOOD.SelectedValue);
        if (CheckNumber(txtFOOD_PRICE.Text.Trim()))
        {
            obj.FOOD_PRICE = int.Parse(txtFOOD_PRICE.Text.Trim().Replace(",", ""));
        }

        obj.MEETINGTYPEID = 2;
        obj.STATUS_MEETING_REGISTERID = 1;
        obj.CREATEUSER = int.Parse(Session["UserID"].ToString());
        obj.CREATEUSER_USERTYPEID = int.Parse(hdfORGANIZER_USERTYPEID.Value);
        obj.FOREIGNER = true;
        obj.REPORTED = bool.Parse(hdfReported.Value);
        obj.SPEAKER_ADAID_1 = txtSPEAKER_ADAID_1.Text.Trim();
        obj.SPEAKER_USERTYPENAME_1 = txtSPEAKER_USERTYPENAME_1.Text.Trim();
        obj.SPEAKER_NAME_1 = txtSPEAKER_NAME_1.Text.Trim();
        obj.SPEAKER_TITLE_1 = txtSPEAKER_TITLE_1.Text.Trim();
        obj.SPEAKER_NATION_1 = txtSPEAKER_NATION_1.Text.Trim();
        obj.SPEAKER_ADAID_2 = txtSPEAKER_ADAID_2.Text.Trim();
        obj.SPEAKER_USERTYPENAME_2 = txtSPEAKER_USERTYPENAME_2.Text.Trim();
        obj.SPEAKER_NAME_2 = txtSPEAKER_NAME_2.Text.Trim();
        obj.SPEAKER_TITLE_2 = txtSPEAKER_TITLE_2.Text.Trim();
        obj.SPEAKER_NATION_2 = txtSPEAKER_NATION_2.Text.Trim();
        obj.CREATEUSER = int.Parse(Session["UserID"].ToString());
        obj.UPDATEUSER = int.Parse(Session["UserID"].ToString());
        
        if (CheckNumber(txtTOTAL_PAY.Text.Trim()))
        {
            double TOTAL_PAY = double.Parse(txtTOTAL_PAY.Text.Trim().Replace(",", ""));
            double AMWAY_PAY = 0;
            double DISTRIBUTOR_PAY = 0;
            // tinh tien theo 80%
            AMWAY_PAY = TOTAL_PAY * 0.8;
            if(AMWAY_PAY > double.Parse(hdfMAXPAYMENT.Value))
            {
                AMWAY_PAY=double.Parse(hdfMAXPAYMENT.Value);
            }
            DISTRIBUTOR_PAY = TOTAL_PAY - AMWAY_PAY;
            obj.TOTAL_PAY = (decimal)TOTAL_PAY;
            obj.AMWAY_PAY = (decimal)AMWAY_PAY;
            obj.DISTRIBUTOR_PAY = (decimal)DISTRIBUTOR_PAY;
        }
        lblAMWAY_PAY.Text=string.Format("{0:N0}",obj.AMWAY_PAY);
        lblDISTRIBUTOR_PAY.Text = string.Format("{0:N0}", obj.DISTRIBUTOR_PAY);
        if (int.Parse(hdfID.Value) <= 0)
        {
            hdfID.Value = objBO.MeetingInsert(obj).ToString();
            if (int.Parse(hdfID.Value) > 0)
            {
                btnSave.Text = "Cập nhật";
                lblAlerting.Text = "Đăng ký hội họp mới thành công!";
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
                if (objBO.MeetingUpdate(obj))
                {
                    lblAlerting.Text = "Cập nhật đăng ký hội họp thành công!";
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
        lblAlerting.Text = string.Empty;
        hdfCO_ORGANIZER_USERID_1.Value = string.Empty;
        lblCO_ORGANIZER_NAME_1.Text = string.Empty;
        lblCO_ORGANIZER_USERTYPENAME_1.Text = string.Empty;
        hdfCO_ORGANIZER_USERTYPEID_1.Value = string.Empty;
        divCO_ORGANIZER_QUOTA_1.Visible = false;
        hdfCO_ORGANIZER_QUOTA_CHECK_1.Value = "false";
        ImgBtnCO_ORGANIZER_OK_1.Visible = false;
        ImgBtnCO_ORGANIZER_ERROR_1.Visible = false;

        if (txtCO_ORGANIZER_ADAID_1.Text.Trim().Length > 0)
        {

            MeetingBO objBO = new MeetingBO();
            PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADAResult result = new PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADAResult();
            result = objBO.Meeting_CheckQuota(txtCO_ORGANIZER_ADAID_1.Text.Trim(), int.Parse(ddlPAXID.SelectedValue), int.Parse(ddlPROVINCEID.SelectedValue));
            if (result != null)
            {
                hdfCO_ORGANIZER_USERID_1.Value = result.USERID.ToString();
                lblCO_ORGANIZER_NAME_1.Text = result.FULLNAME;
                lblCO_ORGANIZER_USERTYPENAME_1.Text = result.USERTYPENAME;
                hdfCO_ORGANIZER_USERTYPEID_1.Value = result.USERTYPEID.ToString();
                divCO_ORGANIZER_QUOTA_1.Visible = true;
                hdfCO_ORGANIZER_QUOTA_CHECK_1.Value = result.ISQUOTA.ToString();
                if (result.ISQUOTA ?? false)
                {
                    ImgBtnCO_ORGANIZER_OK_1.Visible = true;
                    ImgBtnCO_ORGANIZER_ERROR_1.Visible = false;
                }
                else
                {
                    ImgBtnCO_ORGANIZER_OK_1.Visible = false;
                    ImgBtnCO_ORGANIZER_ERROR_1.Visible = true;
                }
            }
        }
    }
    protected void ImgBtnCO_ORGANIZER_ADA2_CHECK_Click(object sender, ImageClickEventArgs e)
    {
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
            PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADAResult result = new PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADAResult();
            result = objBO.Meeting_CheckQuota(txtCO_ORGANIZER_ADAID_2.Text.Trim(), int.Parse(ddlPAXID.SelectedValue), int.Parse(ddlPROVINCEID.SelectedValue));
            if (result != null)
            {
                hdfCO_ORGANIZER_USERID_2.Value = result.USERID.ToString();
                lblCO_ORGANIZER_NAME_2.Text = result.FULLNAME;
                lblCO_ORGANIZER_USERTYPENAME_2.Text = result.USERTYPENAME;
                hdfCO_ORGANIZER_USERTYPEID_2.Value = result.USERTYPEID.ToString();
                divCO_ORGANIZER_QUOTA_2.Visible = true;
                hdfCO_ORGANIZER_QUOTA_CHECK_2.Value = result.ISQUOTA.ToString();
                if (result.ISQUOTA ?? false)
                {
                    ImgBtnCO_ORGANIZER_OK_2.Visible = true;
                    ImgBtnCO_ORGANIZER_ERROR_2.Visible = false;
                }
                else
                {
                    ImgBtnCO_ORGANIZER_OK_2.Visible = false;
                    ImgBtnCO_ORGANIZER_ERROR_2.Visible = true;
                }
            }
        }
    }
    protected void ImgBtnCO_ORGANIZER_ADA3_CHECK_Click(object sender, ImageClickEventArgs e)
    {
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
            PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADAResult result = new PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADAResult();
            result = objBO.Meeting_CheckQuota(txtCO_ORGANIZER_ADAID_3.Text.Trim(), int.Parse(ddlPAXID.SelectedValue), int.Parse(ddlPROVINCEID.SelectedValue));
            if (result != null)
            {
                hdfCO_ORGANIZER_USERID_3.Value = result.USERID.ToString();
                lblCO_ORGANIZER_NAME_3.Text = result.FULLNAME;
                lblCO_ORGANIZER_USERTYPENAME_3.Text = result.USERTYPENAME;
                hdfCO_ORGANIZER_USERTYPEID_3.Value = result.USERTYPEID.ToString();
                divCO_ORGANIZER_QUOTA_3.Visible = true;
                hdfCO_ORGANIZER_QUOTA_CHECK_3.Value = result.ISQUOTA.ToString();
                if (result.ISQUOTA ?? false)
                {
                    ImgBtnCO_ORGANIZER_OK_3.Visible = true;
                    ImgBtnCO_ORGANIZER_ERROR_3.Visible = false;
                }
                else
                {
                    ImgBtnCO_ORGANIZER_OK_3.Visible = false;
                    ImgBtnCO_ORGANIZER_ERROR_3.Visible = true;
                }
            }
        }
    }
    protected void ddlPROVINCEID_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblAlerting.Text = string.Empty;
        divORGANIZER_QUOTA.Visible = false;
        ImgBtnORGANIZER_OK.Visible = false;
        ImgBtnORGANIZER_ERROR.Visible = false;
        hdfORGANIZER_QUOTA_CHECK.Value = "false";
        hdfMAXPAYMENT.Value = "0";
        if ((int.Parse(ddlPROVINCEID.SelectedValue) > 0) && (int.Parse(ddlPAXID.SelectedValue) > 0))
        {
            hdfMAXPAYMENT.Value = GetMaxPayment().ToString();
            divORGANIZER_QUOTA_BTN.Visible = true;
        }
        else
        {
            divORGANIZER_QUOTA_BTN.Visible = false;
        }

    }
    private int GetMaxPayment()
    {
        MeetingBO objBO = new MeetingBO();
        return objBO.MeetingGet_MaxPayment(int.Parse(ddlPAXID.SelectedValue), int.Parse(ddlPROVINCEID.SelectedValue));
    }
    protected void ddlPAXID_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblAlerting.Text = string.Empty;
        divORGANIZER_QUOTA.Visible = false;
        ImgBtnORGANIZER_OK.Visible = false;
        ImgBtnORGANIZER_ERROR.Visible = false;
        hdfORGANIZER_QUOTA_CHECK.Value = "false";
        hdfMAXPAYMENT.Value = "0";
        if ((int.Parse(ddlPROVINCEID.SelectedValue) > 0) && (int.Parse(ddlPAXID.SelectedValue) > 0))
        {
            hdfMAXPAYMENT.Value = GetMaxPayment().ToString();
            divORGANIZER_QUOTA_BTN.Visible = true;
        }
        else
        {
            divORGANIZER_QUOTA_BTN.Visible = false;
        }
    }
    protected void ImgBtnORGANIZER_CHECK_Click(object sender, ImageClickEventArgs e)
    {

        if (txtORGANIZER_ADAID.Text.Trim().Length > 0)
        {
            lblAlerting.Text = string.Empty;
            MeetingBO objBO = new MeetingBO();
            PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADAResult result = new PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADAResult();
            result = objBO.Meeting_CheckQuota(txtORGANIZER_ADAID.Text.Trim(), int.Parse(ddlPAXID.SelectedValue), int.Parse(ddlPROVINCEID.SelectedValue));
            if (result != null)
            {
                divORGANIZER_QUOTA.Visible = true;
                hdfORGANIZER_QUOTA_CHECK.Value = result.ISQUOTA.ToString();
                if (result.ISQUOTA ?? false)
                {
                    ImgBtnORGANIZER_OK.Visible = true;
                    ImgBtnORGANIZER_ERROR.Visible = false;
                }
                else
                {
                    ImgBtnORGANIZER_OK.Visible = false;
                    ImgBtnORGANIZER_ERROR.Visible = true;
                }
            }
        }
    }
    protected void ddlPROVINCE_PLACE_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblAlerting.Text = string.Empty;
        GetPlaceCBO(int.Parse(ddlPROVINCE_PLACE.SelectedValue));
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

}