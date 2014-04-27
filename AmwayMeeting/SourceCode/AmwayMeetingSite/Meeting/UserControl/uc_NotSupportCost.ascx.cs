using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Text.RegularExpressions;
using System.Globalization;

public partial class Meeting_UserControl_uc_NotSupportCost : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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

        hdfID.Value = "-1";
        btnSave.Visible = false;
        txtORGANIZER_ADAID.Text = string.Empty;
        lblORGANIZER_NAME.Text = string.Empty;
        lblORGANIZER_EMAIL.Text = string.Empty;
        lblORGANIZER_ADDRESS.Text = string.Empty;
        lblORGANIZER_TELEPHONE.Text = string.Empty;
        ddlPAXID.SelectedIndex = 0;
        ddlPROVINCEID.SelectedIndex = 0;

        txtCO_ORGANIZER_ADAID_1.Text = string.Empty;
        lblCO_ORGANIZER_NAME_1.Text = string.Empty;
        lblCO_ORGANIZER_USERTYPENAME_1.Text = string.Empty;

        txtCO_ORGANIZER_ADAID_2.Text = string.Empty;
        lblCO_ORGANIZER_NAME_2.Text = string.Empty;
        lblCO_ORGANIZER_USERTYPENAME_2.Text = string.Empty;

        txtCO_ORGANIZER_ADAID_3.Text = string.Empty;
        lblCO_ORGANIZER_NAME_3.Text = string.Empty;
        lblCO_ORGANIZER_USERTYPENAME_3.Text = string.Empty;

        txtMEETINGNAME.Text = string.Empty;
        txtNUMBER_OF_PARTICIPANT.Text = string.Empty;
        ddlPROVINCE_PLACE.SelectedIndex = 0;
        ddlPLACE.SelectedIndex = 0;
        txtMEETING_PLACE_NAME.Text = string.Empty;
        txtMEETING_ADDRESS.Text = string.Empty;
        txtMEETING_ENDDATE.Text = string.Empty;
        txtMEETING_STARTDATE.Text = string.Empty;
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

    private void GetPlaceCBO(int provinceId)
    {
        try
        {
            CategoryBO objBO = new CategoryBO();
            List<DAL.PRC_SYS_AMW_PLACE_GETLISTBY_PROVINCEIDResult> lst = new List<DAL.PRC_SYS_AMW_PLACE_GETLISTBY_PROVINCEIDResult>();
            lst = objBO.PlaceGet_ByProvinceId(provinceId).ToList();
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
        if (bool.Parse(hdfORGANIZER_QUOTA_CHECK.Value))
        {
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
            if ((txtMEETING_STARTDATE.Text.Trim().Length <= 0) || (!CheckDate(txtMEETING_STARTDATE.Text)) || (txtMEETING_ENDDATE.Text.Trim().Length <= 0) || (!CheckDate(txtMEETING_ENDDATE.Text)))
            {
                lblAlerting.Text = "Bạn nhập ngày họp không đúng!";
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

            // Kiem tra xem trong  pax nay số người đồng tổ chức đủ chưa?
            MeetingBO objBO = new MeetingBO();

            int ConditionCombine = objBO.MeetingGet_ConditionCombine(int.Parse(ddlPAXID.SelectedValue), int.Parse(hdfORGANIZER_USERTYPEID.Value));
            int quantity = 0;
            if (hdfCO_ORGANIZER_ADAID_1.Value.Length > 0) quantity++;
            if (hdfCO_ORGANIZER_ADAID_2.Value.Length > 0) quantity++;
            if (hdfCO_ORGANIZER_ADAID_3.Value.Length > 0) quantity++;

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
                obj.CO_ORGANIZER_ADAID_1 = hdfCO_ORGANIZER_ADAID_1.Value;
                obj.CO_ORGANIZER_USERTYPENAME_1 = lblCO_ORGANIZER_USERTYPENAME_1.Text.Trim();
                obj.CO_ORGANIZER_NAME_1 = lblCO_ORGANIZER_NAME_1.Text.Trim();
                obj.CO_ORGANIZER_ADAID_2 = hdfCO_ORGANIZER_ADAID_2.Value;
                obj.CO_ORGANIZER_USERTYPENAME_2 = lblCO_ORGANIZER_USERTYPENAME_2.Text.Trim();
                obj.CO_ORGANIZER_NAME_2 = lblCO_ORGANIZER_NAME_2.Text.Trim();
                obj.CO_ORGANIZER_ADAID_3 = hdfCO_ORGANIZER_ADAID_3.Value;
                obj.CO_ORGANIZER_USERTYPENAME_3 = lblCO_ORGANIZER_USERTYPENAME_3.Text.Trim();
                obj.CO_ORGANIZER_NAME_3 = lblCO_ORGANIZER_NAME_3.Text.Trim();

            }
            else
            {
                if(quantity>0)
                {
                    lblAlerting.Text = "Cuộc họp này không cần người đồng tổ chức!";
                    return;
                }
            }
            

            //Thực hiên Insert

            obj.ID = int.Parse(hdfID.Value);
            obj.ORGANIZER_ADAID = hdfORGANIZER_ADAID.Value;
            obj.ORGANIZER_USERTYPENAME = lblORGANIZER_USERTYPENAME.Text.Trim();
            obj.ORGANIZER_NAME = lblORGANIZER_NAME.Text.Trim();
            obj.ORGANIZER_EMAIL = lblORGANIZER_EMAIL.Text.Trim();
            obj.ORGANIZER_ADDRESS = lblORGANIZER_ADDRESS.Text.Trim();
            obj.ORGANIZER_TELEPHONE = lblORGANIZER_TELEPHONE.Text.Trim();
            obj.PAXID = int.Parse(ddlPAXID.SelectedValue);
            obj.PROVINCEID = int.Parse(ddlPROVINCEID.SelectedValue);
            obj.MEETINGNAME = txtMEETINGNAME.Text.Trim();
            obj.NUMBER_OF_PARTICIPANT = int.Parse(txtNUMBER_OF_PARTICIPANT.Text.Trim().Replace(",", ""));
            obj.MEETING_PLACE_NAME = txtMEETING_PLACE_NAME.Text.Trim();
            obj.MEETING_ADDRESS = txtMEETING_ADDRESS.Text.Trim();

            obj.MEETING_STARTDATE = DateTime.ParseExact(txtMEETING_STARTDATE.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            obj.MEETING_ENDDATE = DateTime.ParseExact(txtMEETING_ENDDATE.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            obj.MEETING_TIME = txtMEETING_TIME.Text.Trim();
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

            obj.MEETINGTYPEID = 1;
            obj.STATUS_MEETING_REGISTERID = 1;
            obj.CREATEUSER = int.Parse(Session["UserID"].ToString());
            obj.FOREIGNER = chkForeigner.Checked;
            obj.REPORTED = false;
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
    }
    protected void ImgBtnORGANIZER_ADA_CHECK_Click(object sender, ImageClickEventArgs e)
    {
        hdfORGANIZER_ADAID.Value = string.Empty;
        lblORGANIZER_NAME.Text = string.Empty;
        lblORGANIZER_USERTYPENAME.Text = string.Empty;
        lblORGANIZER_EMAIL.Text = string.Empty;
        lblORGANIZER_TELEPHONE.Text = string.Empty;
        lblORGANIZER_ADDRESS.Text = string.Empty;
        hdfORGANIZER_USERTYPEID.Value = string.Empty;
        if (txtORGANIZER_ADAID.Text.Trim().Length > 0)
        {

            MeetingBO objBO = new MeetingBO();
            PRC_SYS_AMW_USER_GETBY_ADAResult result = new PRC_SYS_AMW_USER_GETBY_ADAResult();
            result = objBO.Meeting_GetDistributor_ByADA(txtORGANIZER_ADAID.Text.Trim());
            if (result != null)
            {
                hdfORGANIZER_ADAID.Value = result.ADA;
                lblORGANIZER_NAME.Text = result.FULLNAME;
                lblORGANIZER_USERTYPENAME.Text = result.USERTYPENAME;
                lblORGANIZER_EMAIL.Text = result.EMAIL;
                lblORGANIZER_TELEPHONE.Text = result.TELEPHONE;
                lblORGANIZER_ADDRESS.Text = result.ADDRESS;
                hdfORGANIZER_USERTYPEID.Value = result.USERTYPEID.ToString();
            }
        }
    }
    protected void ImgBtnCO_ORGANIZER_ADA1_CHECK_Click(object sender, ImageClickEventArgs e)
    {
        hdfCO_ORGANIZER_ADAID_1.Value = string.Empty;
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
                hdfCO_ORGANIZER_ADAID_1.Value = result.ADA;
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
        hdfCO_ORGANIZER_ADAID_2.Value = string.Empty;
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
                hdfCO_ORGANIZER_ADAID_2.Value = result.ADA;
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
        hdfCO_ORGANIZER_ADAID_3.Value = string.Empty;
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
                hdfCO_ORGANIZER_ADAID_3.Value = result.ADA;
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
        divORGANIZER_QUOTA.Visible = false;
        ImgBtnORGANIZER_OK.Visible = false;
        ImgBtnORGANIZER_ERROR.Visible = false;
        hdfORGANIZER_QUOTA_CHECK.Value = "false";
        if ((int.Parse(ddlPROVINCEID.SelectedValue) > 0) && (int.Parse(ddlPAXID.SelectedValue) > 0))
        {
            divORGANIZER_QUOTA_BTN.Visible = true;
        }
        else
        {
            divORGANIZER_QUOTA_BTN.Visible = false;
        }

    }
    protected void ddlPAXID_SelectedIndexChanged(object sender, EventArgs e)
    {
        divORGANIZER_QUOTA.Visible = false;
        ImgBtnORGANIZER_OK.Visible = false;
        ImgBtnORGANIZER_ERROR.Visible = false;
        hdfORGANIZER_QUOTA_CHECK.Value = "false";
        if ((int.Parse(ddlPROVINCEID.SelectedValue) > 0) && (int.Parse(ddlPAXID.SelectedValue) > 0))
        {
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
                    btnSave.Visible = true;
                }
                else
                {
                    ImgBtnORGANIZER_OK.Visible = false;
                    ImgBtnORGANIZER_ERROR.Visible = true;
                    btnSave.Visible = false;
                }
            }
        }
    }
    protected void ddlPROVINCE_PLACE_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetPlaceCBO(int.Parse(ddlPROVINCE_PLACE.SelectedValue));
    }
    protected void ddlPLACE_SelectedIndexChanged(object sender, EventArgs e)
    {
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