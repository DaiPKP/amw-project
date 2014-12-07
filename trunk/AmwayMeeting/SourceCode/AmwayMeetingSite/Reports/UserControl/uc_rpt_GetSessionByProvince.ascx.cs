using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Data;
using System.Globalization;

public partial class Reports_UserControl_uc_rpt_GetSessionByProvince : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //GetMeetingTypeCBO();
        }
    }

    //private void GetMeetingTypeCBO()
    //{
    //    try
    //    {
    //        CategoryBO objBO = new CategoryBO();
    //        List<DAL.PRC_SYS_AMW_MEETING_TYPE_CBOResult> lst = new List<DAL.PRC_SYS_AMW_MEETING_TYPE_CBOResult>();
    //        lst = objBO.MeetingType_CBO().ToList();
    //        if (lst != null)
    //        {
    //            ddlMEETINGTYPEID.DataSource = lst;
    //            ddlMEETINGTYPEID.DataTextField = "MEETINGTYPENAME";
    //            ddlMEETINGTYPEID.DataValueField = "ID";
    //            ddlMEETINGTYPEID.DataBind();

    //            ListItem lstParent = new ListItem("--Tất cả--", "0");
    //            ddlMEETINGTYPEID.Items.Insert(0, lstParent);
    //            ddlMEETINGTYPEID.SelectedIndex = ddlMEETINGTYPEID.Items.IndexOf(lstParent);
    //        }
    //    }
    //    catch
    //    {
    //    }
    //}

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            lblAlerting.Text = "";
            if ((txtFROM_DATE.Text.Trim().Length <= 0) || (!CheckDate(txtFROM_DATE.Text)))
            {
                lblAlerting.Text = "Bạn nhập Từ Ngày không đúng!";
                return;
            }

            if ((txtFROM_DATE.Text.Trim().Length <= 0) || (!CheckDate(txtFROM_DATE.Text)))
            {
                lblAlerting.Text = "Bạn nhập Đến Ngày không đúng!";
                return;
            }

            Export export = new Export();
            ReportBO objBO = new ReportBO();
            List<PRC_RPT_GET_SESSION_BY_PAX_PROVINCEResult> lst1 = new List<PRC_RPT_GET_SESSION_BY_PAX_PROVINCEResult>();
            lst1 = objBO.GetSessionByProvince(DateTime.ParseExact(txtFROM_DATE.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture), DateTime.ParseExact(txtTO_DATE.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture), chk_FOREIGNER.Checked).ToList();
            DataTable report1 = General.ConvertToDataTable(lst1);

            List<PRC_RPT_GET_SESSION_BY_PAX_PROVINCE_DETAILResult> lst2 = new List<PRC_RPT_GET_SESSION_BY_PAX_PROVINCE_DETAILResult>();
            lst2 = objBO.GetSessionByProvinceDetail(DateTime.ParseExact(txtFROM_DATE.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture), DateTime.ParseExact(txtTO_DATE.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture), chk_FOREIGNER.Checked).ToList();
            DataTable report2 = General.ConvertToDataTable(lst2);

            report1.TableName = "Detail1";
            report2.TableName = "Detail2";
            DataTable[] arrTable = { report1, report2 };
            if(chk_FOREIGNER.Checked)
            {
                export.ExportExcel(Server.MapPath("~/Template/Excel/RPT_EXCEPTIONAL_CASE_FOREIGNER.xls"), arrTable, "_RPT_EXCEPTIONAL_CASE_FOREIGNER.xls");
            }
            else
            {
                export.ExportExcel(Server.MapPath("~/Template/Excel/RPT_EXCEPTIONAL_CASE.xls"), arrTable, "_RPT_EXCEPTIONAL_CASE.xls");
            }
            
        }
        catch (Exception ex)
        {
            lblAlerting.Text = "Xuất báo cáo thất bại, vui lòng thử lại sau...";
            return;
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