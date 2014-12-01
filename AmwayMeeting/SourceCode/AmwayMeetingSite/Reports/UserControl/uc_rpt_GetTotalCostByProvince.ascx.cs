using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Data;

public partial class Reports_UserControl_uc_rpt_GetTotalCostByProvince : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetPerviodCBO();
        }
    }

    private void GetPerviodCBO()
    {
        try
        {
            CategoryBO catebo = new CategoryBO();
            List<DAL.PRC_SYS_AMW_PERIOD_CBOResult> lst = new List<DAL.PRC_SYS_AMW_PERIOD_CBOResult>();
            lst = catebo.PeriodGet_CBO().ToList();
            if (lst != null)
            {
                ddlPERIODID.DataSource = lst;
                ddlPERIODID.DataTextField = "PERIODNAME";
                ddlPERIODID.DataValueField = "ID";
                ddlPERIODID.DataBind();
            }
        }
        catch
        {
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Export export = new Export();
            ReportBO objBO = new ReportBO();
            List<PRC_RPT_GET_TOTAL_COST_BY_PROVResult> lst = new List<PRC_RPT_GET_TOTAL_COST_BY_PROVResult>();
            lst = objBO.GetTotalCostByProv(int.Parse(ddlPERIODID.SelectedValue.ToString())).ToList();
            DataTable report = General.ConvertToDataTable(lst);
            report.TableName = "Detail";
            DataTable[] arrTable = { report };
            export.ExportExcel(Server.MapPath("~/Template/Excel/RPT_GETTOTALCOST_by_PROVINCE.xls"), arrTable, "_RPT_GETTOTALCOST_by_PROVINCE.xls");
        }
        catch (Exception ex)
        {
            lblAlerting.Text = "Xuất báo cáo thất bại, vui lòng thử lại sau...";
            return;
        }
    }
}