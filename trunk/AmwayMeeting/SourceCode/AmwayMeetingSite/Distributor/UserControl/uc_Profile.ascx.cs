using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Text.RegularExpressions;
using System.Net.Mail;

public partial class Distributor_UserControl_uc_Profile : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitData();
            txtEmail.Enabled = false;
            txtAddress.Enabled = false;
        }
    }
    private void InitData()
    {
        SYS_AMW_USER objUser = new SYS_AMW_USER();
        objUser.ADA = string.Empty;
        objUser.FIRSTNAME = string.Empty;
        objUser.LASTNAME = string.Empty;
        objUser.RELATIVE_FIRSTNAME = string.Empty;
        objUser.RELATIVE_LASTNAME = string.Empty;
        objUser.CODE = string.Empty;
        objUser.ACCBANK = string.Empty;
        objUser.TELEPHONE = string.Empty;
        objUser.FAX = string.Empty;
        objUser.ADDRESS = string.Empty;
        objUser.EMAIL = string.Empty;
        objUser.USERTYPEID = 0;
        objUser.DEPARTMENTID = 0;
        objUser.WORKDISTRICTID = 0;
        objUser.WORKPROVINCEID = 0;
        objUser.DESCRIPTION = string.Empty;
        objUser.ACTIVE = true;
        LoadDistributorInfo(int.Parse(Session["UserID"].ToString()));
        DisplayQuotaInGrid(int.Parse(Session["UserID"].ToString()));
        DisplayMeetingHistory(int.Parse(Session["UserID"].ToString()));
    }
    private void LoadDistributorInfo(int DistID)
    {
        UserBO bo = new UserBO();
        PRC_SYS_AMW_USER_GETLISTBYUSERIDResult dist = new PRC_SYS_AMW_USER_GETLISTBYUSERIDResult();
        dist = bo.PRC_SYS_AMW_USER_GETLISTBYUSERID(DistID).SingleOrDefault();
        lbADA.Text = dist.ADA;
        lbName.Text = dist.FULLNAME;
        lbTelephone.Text = dist.TELEPHONE;
        txtEmail.Text = dist.EMAIL;
        txtAddress.Text = dist.ADDRESS;
        lbUserType.Text = dist.USERTYPENAME;
        lbWorkProvince.Text = dist.WORKPROVINCENAME;
        lbWorkDistrict.Text = dist.WORKDISTRICTNAME;
        if (txtEmail.Text.Equals(""))
        {
            lbMess.Text = "Vui lòng cập nhật địa chỉ email...";
        }
    }
    private void DisplayQuotaInGrid(int DistID)
    {
        DistributorQuotaBO quota = new DistributorQuotaBO();
        List<PRC_SYS_AMW_DISTRIBUTOR_QUOTA_GETBY_USERIDResult> list = new List<PRC_SYS_AMW_DISTRIBUTOR_QUOTA_GETBY_USERIDResult>();
        list = quota.GetDistributorQuota(DistID).ToList();
        grdQuotaList.DataSource = list;
        if (list.Count > 0)
        {
            grdQuotaList.PageIndex = 0;
        }
        grdQuotaList.DataBind();
    }
    private void DisplayMeetingHistory(int DistID)
    {
        MeetingBO meeting = new MeetingBO();
        List<PRC_USR_AMW_MEETING_REGISTER_GETLISTBYUSERIDResult> list = new List<PRC_USR_AMW_MEETING_REGISTER_GETLISTBYUSERIDResult>();
        list = meeting.MeetingGet_ListByUserID(DistID).ToList();
        grdMeetingList.DataSource = list;
        if (list.Count > 0)
        {
            grdMeetingList.PageIndex = 0;
        }
        grdMeetingList.DataBind();
    }

    protected void grdMeetingList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DisplayMeetingHistory(int.Parse(Session["UserID"].ToString()));
        grdMeetingList.PageIndex = e.NewPageIndex;
        grdMeetingList.DataBind();
    }
    protected void grdMeetingList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdMeetingList.EditIndex = e.NewEditIndex;
        hdfMeetingID.Value = grdMeetingList.DataKeys[e.NewEditIndex].Value.ToString();
        MeetingBO objBO = new MeetingBO();
        PRC_USR_AMW_MEETING_REGISTER_GETLISTBYIDResult result = new PRC_USR_AMW_MEETING_REGISTER_GETLISTBYIDResult();
        result = objBO.MeetingGet_ListByID(int.Parse(hdfMeetingID.Value));
        if (result != null)
        {
            string strUrl = string.Empty;

            int MeetingType = result.MEETINGTYPEID ?? 0;
            bool Foreigner = result.FOREIGNER ?? false;
            if (MeetingType == 1)
            {
                if (Foreigner)
                {
                    strUrl = "../meeting/notsupportcostforeignerR" + hdfMeetingID.Value;
                }
                else
                {

                    strUrl = "../meeting/notsupportcostR" + hdfMeetingID.Value;
                }

            }
            if (MeetingType == 2)
            {
                if (Foreigner)
                {
                    strUrl = "../meeting/supportcostforeignerR" + hdfMeetingID.Value;
                }
                else
                {

                    strUrl = "../meeting/supportcostR" + hdfMeetingID.Value;
                }

            }
            if (MeetingType == 3)
            {

                strUrl = "../meeting/outsidecountryR" + hdfMeetingID.Value;


            }
            Response.Redirect(strUrl);
        }
    }
    private bool CheckEmail(string strEmail)
    {
        //string pattern = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
        //Match match = Regex.Match(strEmail.Trim(), pattern, RegexOptions.IgnoreCase);

        //if (match.Success)
          //  return true;
        //else
          //  return false;

        try
        {
            MailAddress m = new MailAddress(strEmail);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }



    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (btnEdit.Text.Equals("Cập Nhật"))
        {
            txtAddress.Enabled = true;
            txtEmail.Enabled = true;
            lbMess.Text = "";
            btnEdit.Text = "Lưu";
        }
        else
        {
            if (txtEmail.Text.Trim().Length > 0)
            {
                if (!CheckEmail(txtEmail.Text.Trim()))
                {
                    lbMess.Text = "Địa chỉ email không hợp lệ";
                    return;
                }
            }
            UserBO bo = new UserBO();
            if (bo.UserUpdateEmailAddress(int.Parse(Session["UserID"].ToString()), txtEmail.Text.Trim(), txtAddress.Text.Trim()))
            {
                txtAddress.Enabled = false;
                txtEmail.Enabled = false;
                btnEdit.Text = "Cập Nhật";
                if (txtEmail.Text.Trim().Equals(""))
                {
                    lbMess.Text = "Cập nhật thông tin thành công <br/> Vui lòng cập nhật địa chỉ email...";
                }
                else
                {
                    lbMess.Text = "Cập nhật thông tin thành công";
                }
            }
            else
            {
                lbMess.Text = "Cập nhật thông tin thất bại";
            }
        }
    }
}