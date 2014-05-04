using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Text.RegularExpressions;
using System.Globalization;

public partial class Meeting_UserControl_uc_OutSideCountryView : System.Web.UI.UserControl
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
        GetStatusMeetingRegisterCBO();
        btnSave.Text = "Cập nhật";
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
            lblORGANIZER_TELEPHONE.Text = result.ORGANIZER_TELEPHONE == null ? string.Empty : result.ORGANIZER_TELEPHONE;
            hdfORGANIZER_USERID.Value = result.ORGANIZER_USERID == null ? string.Empty : result.ORGANIZER_USERID.ToString();
            hdfORGANIZER_USERTYPEID.Value = result.ORGANIZER_USERTYPEID == null ? string.Empty : result.ORGANIZER_USERTYPEID.ToString();

            lblSPEAKER_ADAID_1.Text = result.SPEAKER_ADAID_1 == null ? string.Empty : result.SPEAKER_ADAID_1;
            lblSPEAKER_NAME_1.Text = result.SPEAKER_NAME_1 == null ? string.Empty : result.SPEAKER_NAME_1;
            lblSPEAKER_USERTYPENAME_1.Text = result.SPEAKER_USERTYPENAME_1 == null ? string.Empty : result.SPEAKER_USERTYPENAME_1;

            lblMEETINGNAME.Text = result.MEETINGNAME == null ? string.Empty : result.MEETINGNAME;
            lblMEETING_PLACE_NAME.Text = result.MEETING_PLACE_NAME == null ? string.Empty : result.MEETING_PLACE_NAME;
            lblMEETING_ADDRESS.Text = result.MEETING_ADDRESS == null ? string.Empty : result.MEETING_ADDRESS;
            lblMEETING_ENDDATE.Text = result.MEETING_ENDDATE == null ? string.Empty : result.STR_MEETING_ENDDATE;
            lblMEETING_STARTDATE.Text = result.MEETING_STARTDATE == null ? string.Empty : result.STR_MEETING_STARTDATE;

            lblDEPARTURE_DATE.Text = result.STR_DEPARTURE_DATE == null ? string.Empty : result.STR_DEPARTURE_DATE;
            lblARRIVAL_DATE.Text = result.STR_ARRIVAL_DATE == null ? string.Empty : result.STR_ARRIVAL_DATE;
            lblCOUNTRYNAME.Text = result.COUNTRYNAME == null ? string.Empty : result.COUNTRYNAME;
            txtCOMMENTS.Text = result.COMMENTS == null ? string.Empty : result.COMMENTS;
            hdfReported.Value = result.REPORTED == null ? "false" : result.REPORTED.ToString();
            ddlSTATUS_MEETING_REGISTERID.SelectedValue = result.STATUS_MEETING_REGISTERID == null ? "false" : result.STATUS_MEETING_REGISTERID.ToString();
            lblWarning.Text = result.WARNING == null ? string.Empty : result.WARNING;
            if (lblWarning.Text.Length > 0)
            {
                trWarning.Visible = true;
            }
            else
            {
                trWarning.Visible = false;
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
        btnSave.Visible = true;

        lblORGANIZER_ADAID.Text = string.Empty;
        hdfORGANIZER_USERID.Value = string.Empty;
        lblORGANIZER_NAME.Text = string.Empty;
        lblORGANIZER_EMAIL.Text = string.Empty;
        lblORGANIZER_TELEPHONE.Text = string.Empty;
        lblORGANIZER_USERTYPENAME.Text = string.Empty;
        hdfORGANIZER_USERTYPEID.Value = string.Empty;

        lblSPEAKER_ADAID_1.Text = string.Empty;
        lblSPEAKER_NAME_1.Text = string.Empty;
        lblSPEAKER_USERTYPENAME_1.Text = string.Empty;


        lblMEETINGNAME.Text = string.Empty;
        lblMEETING_PLACE_NAME.Text = string.Empty;
        lblMEETING_ADDRESS.Text = string.Empty;

        lblDEPARTURE_DATE.Text = string.Empty;
        lblARRIVAL_DATE.Text = string.Empty;

        lblMEETING_ENDDATE.Text = string.Empty;
        lblMEETING_STARTDATE.Text = string.Empty;
        lblCOUNTRYNAME.Text = string.Empty;
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
        obj.COMMENTS = txtCOMMENTS.Text.Trim();
        obj.UPDATEUSER = int.Parse(Session["UserID"].ToString());
        obj.ID = int.Parse(hdfID.Value);

        //Duyet 
        if (objBO.MeetingUpdateApproval(obj))
        {
            lblAlerting.Text = "Anh/Chị đã duyệt đăng ký thành công!";
            return;
        }
        else
        {
            lblAlerting.Text = "Duyệt đăng ký hội họp thất bại, bạn vui lòng thử lại!";
            return;
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