using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class Meeting_UserControl_uc_SearchMeeting : System.Web.UI.UserControl
{
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
        USR_AMW_MEETING_REGISTER obj = new USR_AMW_MEETING_REGISTER();
        obj.PAXID = int.Parse(ddlPAXID.SelectedValue);
        obj.PROVINCEID = int.Parse(ddlPROVINCEID.SelectedValue);
        obj.DISTRICTID = int.Parse(ddlDISTRICTID.SelectedValue);
        obj.MEETINGTYPEID = int.Parse(ddlMEETINGTYPEID.SelectedValue);
        obj.STATUS_MEETING_REGISTERID = int.Parse(ddlSTATUS_MEETING_REGISTERID.SelectedValue);
        obj.REPORTED = chkIsReport.Checked;
        obj.FOREIGNER = chkHaveForeign.Checked;
        DisplayInGrid(string.Empty, obj);
    }

    private void ClearTextBox()
    {
        GetPaxCBO();
        GetMeetingTypeCBO();
        GetStatusMeetingRegisterCBO();
        GetProvinceCBO();
        GetDistrictCBO(0);
        hdfId.Value = "-1";
        txtADA.Text = string.Empty;
        ddlPAXID.SelectedValue = "0";
        ddlPROVINCEID.SelectedValue = "0";
        ddlMEETINGTYPEID.SelectedValue = "0";
        ddlSTATUS_MEETING_REGISTERID.SelectedValue = "0";
        chkHaveForeign.Checked = false;
        chkIsReport.Checked = false;
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

                    ListItem lstParent = new ListItem("--Tất cả--", "0");
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
                List<DAL.PRC_SYS_AMW_DISTRICT_CBOResult> lst = new List<DAL.PRC_SYS_AMW_DISTRICT_CBOResult>();
                ListItem lstParent = new ListItem("--Tất cả--", "0");
                ddlDISTRICTID.Items.Add(lstParent);
                ddlDISTRICTID.SelectedIndex = ddlDISTRICTID.Items.IndexOf(lstParent);
            }
        }
        catch
        {
        }
    }
    private void GetMeetingTypeCBO()
    {
        try
        {
            CategoryBO objBO = new CategoryBO();
            List<DAL.PRC_SYS_AMW_MEETING_TYPE_CBOResult> lst = new List<DAL.PRC_SYS_AMW_MEETING_TYPE_CBOResult>();
            lst = objBO.MeetingType_CBO().ToList();
            if (lst != null)
            {
                ddlMEETINGTYPEID.DataSource = lst;
                ddlMEETINGTYPEID.DataTextField = "MEETINGTYPENAME";
                ddlMEETINGTYPEID.DataValueField = "ID";
                ddlMEETINGTYPEID.DataBind();

                ListItem lstParent = new ListItem("--Tất cả--", "0");
                ddlMEETINGTYPEID.Items.Insert(0, lstParent);
                ddlMEETINGTYPEID.SelectedIndex = ddlMEETINGTYPEID.Items.IndexOf(lstParent);
            }
        }
        catch
        {
        }
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

                ListItem lstParent = new ListItem("--Tất cả--", "0");
                ddlSTATUS_MEETING_REGISTERID.Items.Insert(0, lstParent);
                ddlSTATUS_MEETING_REGISTERID.SelectedIndex = ddlSTATUS_MEETING_REGISTERID.Items.IndexOf(lstParent);
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

                ListItem lstParent = new ListItem("--Tất cả--", "0");
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

                ListItem lstParent = new ListItem("--Tất cả--", "0");
                ddlPROVINCEID.Items.Insert(0, lstParent);
                ddlPROVINCEID.SelectedIndex = ddlPROVINCEID.Items.IndexOf(lstParent);

            }
        }
        catch
        {
        }
    }
    protected void DisplayInGrid(string strADA, USR_AMW_MEETING_REGISTER obj)
    {
        MeetingBO objBO = new MeetingBO();
        List<PRC_USR_AMW_MEETING_REGISTER_SEARCHResult> lst = new List<PRC_USR_AMW_MEETING_REGISTER_SEARCHResult>();
        lst = objBO.Meeting_Search(strADA, obj).ToList();
        grdList.DataSource = lst;
        if (lst.Count > 0)
        {
            grdList.PageIndex = 0;
        }
        grdList.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        hdfId.Value = "-1";
        lblAlerting.Text = string.Empty;
        LoadGrid();

    }
    protected void grdList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblAlerting.Text = string.Empty;
        grdList.EditIndex = e.NewEditIndex;
        hdfId.Value = grdList.DataKeys[e.NewEditIndex].Value.ToString();
        //kiem tra xem no thuoc loai hoi hop gi nua?
        MeetingBO objBO = new MeetingBO();
        PRC_USR_AMW_MEETING_REGISTER_GETLISTBYIDResult result = new PRC_USR_AMW_MEETING_REGISTER_GETLISTBYIDResult();
        result = objBO.MeetingGet_ListByID(int.Parse(hdfId.Value));
        if (result != null)
        {
            string strUrl = string.Empty;

            int MeetingType = result.MEETINGTYPEID ?? 0;
            bool Foreigner = result.FOREIGNER ?? false;
            if (MeetingType == 1)
            {
                if (Foreigner)
                {
                    strUrl = "../meeting/notsupportcostforeignerviewR" + hdfId.Value;
                }
                else
                {

                    strUrl = "../meeting/notsupportcostviewR" + hdfId.Value;
                }

            }
            if (MeetingType == 2)
            {
                if (Foreigner)
                {
                    strUrl = "../meeting/supportcostforeignerviewR" + hdfId.Value;
                }
                else
                {

                    strUrl = "../meeting/supportcostviewR" + hdfId.Value;
                }

            }
            if (MeetingType == 3)
            {
                
                    strUrl = "../meeting/outsidecountryviewR" + hdfId.Value;
                

            }
            Response.Redirect(strUrl);
        }
    }
    protected void btnXoaTrang_Click(object sender, EventArgs e)
    {
        ClearTextBox();
    }

    private void LoadGrid()
    {
        USR_AMW_MEETING_REGISTER obj = new USR_AMW_MEETING_REGISTER();

        obj.PAXID = int.Parse(ddlPAXID.SelectedValue);
        obj.PROVINCEID = int.Parse(ddlPROVINCEID.SelectedValue);
        obj.DISTRICTID = int.Parse(ddlDISTRICTID.SelectedValue);
        obj.MEETINGTYPEID = int.Parse(ddlMEETINGTYPEID.SelectedValue);
        obj.STATUS_MEETING_REGISTERID = int.Parse(ddlSTATUS_MEETING_REGISTERID.SelectedValue);
        obj.REPORTED = chkIsReport.Checked;
        obj.FOREIGNER = chkHaveForeign.Checked;
        DisplayInGrid(txtADA.Text.Trim(), obj);
    }


    protected void grdList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        LoadGrid();
        grdList.PageIndex = e.NewPageIndex;
        grdList.DataBind();
    }
}