using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Text.RegularExpressions;
using System.Globalization;

public partial class Meeting_UserControl_uc_SupportCostForeignerView : System.Web.UI.UserControl
{
    public int _ID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitData();

        }
    }

    private void InitData()
    {

        hdfID.Value = _ID.ToString();
        GetStatusMeetingRegisterCBO();
        GetStatusMeetingPaymentCBO();
        LoadData(int.Parse(hdfID.Value));
    }
    private void GetStatusMeetingRegisterCBO()
    {
        try
        {
            CategoryBO objBO = new CategoryBO();
            List<DAL.PRC_SYS_AMW_STATUS_MEETING_REGISTER_CBOResult> lst = new List<DAL.PRC_SYS_AMW_STATUS_MEETING_REGISTER_CBOResult>();
            lst = objBO.StatusMeetingRegisterGet_CBO().ToList();
            if (lst != null)
            {
                ddlSTATUS_MEETING_REGISTERID.DataSource = lst;
                ddlSTATUS_MEETING_REGISTERID.DataTextField = "STATUSNAME";
                ddlSTATUS_MEETING_REGISTERID.DataValueField = "ID";
                ddlSTATUS_MEETING_REGISTERID.DataBind();

                ListItem lstParent = new ListItem("--Chọn--", "0");
                ddlSTATUS_MEETING_REGISTERID.Items.Insert(0, lstParent);
                ddlSTATUS_MEETING_REGISTERID.SelectedIndex = ddlSTATUS_MEETING_REGISTERID.Items.IndexOf(lstParent);
            }
        }
        catch
        {
        }
    } 
    private void GetStatusMeetingPaymentCBO()
    {
        try
        {
            CategoryBO objBO = new CategoryBO();
            List<DAL.PRC_SYS_AMW_STATUS_MEETING_PAYMENT_CBOResult> lst = new List<DAL.PRC_SYS_AMW_STATUS_MEETING_PAYMENT_CBOResult>();
            lst = objBO.StatusMeetingPaymentGet_CBO().ToList();
            if (lst != null)
            {
                ddlSTATUS_MEETING_PAYMENTID.DataSource = lst;
                ddlSTATUS_MEETING_PAYMENTID.DataTextField = "STATUSNAME";
                ddlSTATUS_MEETING_PAYMENTID.DataValueField = "ID";
                ddlSTATUS_MEETING_PAYMENTID.DataBind();

                ListItem lstParent = new ListItem("--Chọn--", "0");
                ddlSTATUS_MEETING_PAYMENTID.Items.Insert(0, lstParent);
                ddlSTATUS_MEETING_PAYMENTID.SelectedIndex = ddlSTATUS_MEETING_PAYMENTID.Items.IndexOf(lstParent);
            }
        }
        catch
        {
        }
    }
    private void LoadData(int Id)
    {
        MeetingBO objBO = new MeetingBO();
        PRC_USR_AMW_MEETING_REGISTER_GETLISTBYIDResult result = new PRC_USR_AMW_MEETING_REGISTER_GETLISTBYIDResult();

        result = objBO.MeetingGet_ListByID(Id);
        if (result != null)
        {

            lblORGANIZER_ADAID.Text = result.ORGANIZER_ADAID == null ? string.Empty : result.ORGANIZER_ADAID;
            lblORGANIZER_NAME.Text = result.ORGANIZER_NAME == null ? string.Empty : result.ORGANIZER_NAME;
            lblORGANIZER_EMAIL.Text = result.ORGANIZER_EMAIL == null ? string.Empty : result.ORGANIZER_EMAIL;
            lblORGANIZER_ADDRESS.Text = result.ORGANIZER_ADDRESS == null ? string.Empty : result.ORGANIZER_ADDRESS;
            lblORGANIZER_TELEPHONE.Text = result.ORGANIZER_TELEPHONE == null ? string.Empty : result.ORGANIZER_TELEPHONE;
            lblORGANIZER_USERTYPENAME.Text = result.ORGANIZER_USERTYPENAME == null ? string.Empty : result.ORGANIZER_USERTYPENAME;
            lblPAXNAME.Text = result.PAXNAME == null ? string.Empty : result.PAXNAME;
            lblPROVINCENAME.Text = result.PROVINCENAME == null ? string.Empty : result.PROVINCENAME;
            lblCO_ORGANIZER_ADAID_1.Text = result.CO_ORGANIZER_ADAID_1 == null ? string.Empty : result.CO_ORGANIZER_ADAID_1;
            lblCO_ORGANIZER_NAME_1.Text = result.CO_ORGANIZER_NAME_1 == null ? string.Empty : result.CO_ORGANIZER_NAME_1;
            lblCO_ORGANIZER_USERTYPENAME_1.Text = result.CO_ORGANIZER_USERTYPENAME_1 == null ? string.Empty : result.CO_ORGANIZER_USERTYPENAME_1;
            lblCO_ORGANIZER_ADAID_2.Text = result.CO_ORGANIZER_ADAID_2 == null ? string.Empty : result.CO_ORGANIZER_ADAID_2;
            lblCO_ORGANIZER_NAME_2.Text = result.CO_ORGANIZER_NAME_2 == null ? string.Empty : result.CO_ORGANIZER_NAME_2;
            lblCO_ORGANIZER_USERTYPENAME_2.Text = result.CO_ORGANIZER_USERTYPENAME_2 == null ? string.Empty : result.CO_ORGANIZER_USERTYPENAME_2;
            lblCO_ORGANIZER_ADAID_3.Text = result.CO_ORGANIZER_ADAID_3 == null ? string.Empty : result.CO_ORGANIZER_ADAID_3;
            lblCO_ORGANIZER_NAME_3.Text = result.CO_ORGANIZER_NAME_3 == null ? string.Empty : result.CO_ORGANIZER_NAME_3;
            lblCO_ORGANIZER_USERTYPENAME_3.Text = result.CO_ORGANIZER_USERTYPENAME_3 == null ? string.Empty : result.CO_ORGANIZER_USERTYPENAME_3;
            lblMEETINGNAME.Text = result.MEETINGNAME == null ? string.Empty : result.MEETINGNAME;
            lblNUMBER_OF_PARTICIPANT.Text = result.NUMBER_OF_PARTICIPANT == null ? string.Empty : string.Format("{0:N0}", result.NUMBER_OF_PARTICIPANT);
            lblMEETING_PLACE_NAME.Text = result.MEETING_PLACE_NAME == null ? string.Empty : result.MEETING_PLACE_NAME;
            lblMEETING_ADDRESS.Text = result.MEETING_ADDRESS == null ? string.Empty : result.MEETING_ADDRESS;
            lblMEETING_DATE.Text = result.MEETING_DATE == null ? string.Empty : result.STR_MEETING_DATE;
            lblMEETING_TIME.Text = result.MEETING_TIME == null ? string.Empty : result.MEETING_TIME;
            lblFORMS_OF_PAYMENT.Text = result.FORMS_OF_PAYMENT == null ? string.Empty : result.FORMS_OF_PAYMENT;
            lblINVITATIONNAME.Text = result.INVITATIONNAME == null ? string.Empty : result.INVITATIONNAME;
            lblBANNERNAME.Text = result.BANNERNAME == null ? string.Empty : result.BANNERNAME;
            lblSEND_INVITATION_DATE.Text = result.SEND_INVITATION_DATE == null ? string.Empty : result.STR_SEND_INVITATION_DATE;
            lblDISTRICTNAME.Text = result.DISTRICTNAME == null ? string.Empty : result.DISTRICTNAME;
            txtCOMMENTS.Text = result.COMMENTS == null ? string.Empty : result.COMMENTS;
            lblWarning.Text = result.WARNING == null ? string.Empty : result.WARNING;
            chkAgree.Checked = result.AGREE == null ? false : result.AGREE ?? false;
            lblWarning.Text = result.WARNING == null ? string.Empty : result.WARNING;
            if (lblWarning.Text.Length > 0)
            {
                trWarning.Visible = true;
            }
            else
            {
                trWarning.Visible = false;
            }
            if (lblWarning.Text.Length > 0)
            {
                trWarning.Visible = true;
            }
            else
            {
                trWarning.Visible = false;
            }
            if (result.WATER ?? false == true)
            {
                lblWATER.Text = "Có";
            }
            else
            {
                lblWATER.Text = "Không";
            }
            if (result.FOOD ?? false == true)
            {
                lblFOOD.Text = "Có";
            }
            else
            {
                lblFOOD.Text = "Không";
            }

            lblWATER_PRICE.Text = result.WATER_PRICE == null ? string.Empty : string.Format("{0:N0}", result.WATER_PRICE);
            lblFOOD_PRICE.Text = result.FOOD_PRICE == null ? string.Empty : string.Format("{0:N0}", result.FOOD_PRICE);
            lblSPEAKER_TITLE_1.Text = result.SPEAKER_TITLE_1 == null ? string.Empty : result.SPEAKER_TITLE_1;
            lblSPEAKER_ADAID_1.Text = result.SPEAKER_ADAID_1 == null ? string.Empty : result.SPEAKER_ADAID_1;
            lblSPEAKER_NAME_1.Text = result.SPEAKER_NAME_2 == null ? string.Empty : result.SPEAKER_NAME_1;
            lblSPEAKER_USERTYPENAME_1.Text = result.SPEAKER_USERTYPENAME_1 == null ? string.Empty : result.SPEAKER_USERTYPENAME_1;
            lblSPEAKER_TITLE_2.Text = result.SPEAKER_TITLE_2 == null ? string.Empty : result.SPEAKER_TITLE_2;
            lblSPEAKER_ADAID_2.Text = result.SPEAKER_ADAID_2 == null ? string.Empty : result.SPEAKER_ADAID_2;
            lblSPEAKER_NAME_2.Text = result.SPEAKER_NAME_2 == null ? string.Empty : result.SPEAKER_NAME_2;
            lblSPEAKER_USERTYPENAME_2.Text = result.SPEAKER_USERTYPENAME_2 == null ? string.Empty : result.SPEAKER_USERTYPENAME_2;
            lblTOTAL_PAY.Text = result.TOTAL_PAY == null ? string.Empty : string.Format("{0:N0}", result.TOTAL_PAY);
            lblAMWAY_PAY.Text = result.AMWAY_PAY == null ? string.Empty : string.Format("{0:N0}", result.AMWAY_PAY);
            lblDISTRIBUTOR_PAY.Text = result.DISTRIBUTOR_PAY == null ? string.Empty : string.Format("{0:N0}", result.DISTRIBUTOR_PAY);
            ddlSTATUS_MEETING_REGISTERID.SelectedValue = result.STATUS_MEETING_REGISTERID.ToString();
            ddlSTATUS_MEETING_PAYMENTID.SelectedValue = result.STATUS_MEETING_PAYMENTID==null ? "0" : result.STATUS_MEETING_PAYMENTID.ToString();

            lblSPEAKER_NATION_1.Text = result.SPEAKER_NATION_1 == null ? string.Empty : result.SPEAKER_NATION_1;
            lblSPEAKER_NATION_2.Text = result.SPEAKER_NATION_2 == null ? string.Empty : result.SPEAKER_NATION_2;

            btnReport.Visible = bool.Parse(result.REPORTED.ToString());
        }


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        USR_AMW_MEETING_REGISTER obj = new USR_AMW_MEETING_REGISTER();
        MeetingBO objBO = new MeetingBO();
        //Kiem tra lai nhap đủ dữ liệu chưa?
        if (int.Parse(ddlSTATUS_MEETING_REGISTERID.SelectedValue) <= 0)
        {
            lblAlerting.Text = "Bạn chưa chọn duyệt cho đăng ký hội họp này!";
            return;
        }
        obj.STATUS_MEETING_REGISTERID = int.Parse(ddlSTATUS_MEETING_REGISTERID.SelectedValue);
        obj.STATUS_MEETING_PAYMENTID = int.Parse(ddlSTATUS_MEETING_PAYMENTID.SelectedValue);
        obj.COMMENTS = txtCOMMENTS.Text.Trim();
        obj.UPDATEUSER = int.Parse(Session["UserID"].ToString());
        obj.ID = int.Parse(hdfID.Value);

        //Duyet 
        if (objBO.MeetingUpdateApproval(obj))
        {
            if (int.Parse(ddlSTATUS_MEETING_PAYMENTID.SelectedValue) > 0)
            {
                objBO.MeetingUpdateStatusPayment(obj);
            }
            lblAlerting.Text = "Anh/Chị đã duyệt đăng ký thành công!";
            
            return;
        }
        else
        {
            lblAlerting.Text = "Duyệt đăng ký hội họp thất bại, bạn vui lòng thử lại!";
            return;
        }

    }

    protected void btnReport_Click(object sender, EventArgs e)
    {
        string strUrl = "../distributor/reportR" + hdfID.Value;
        Response.Redirect(strUrl);
    }
}