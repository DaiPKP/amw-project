using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Data;

public partial class Reports_UserControl_uc_rpt_GetTotalCost : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Export export = new Export();
            ReportBO objBO = new ReportBO();
            List<PRC_RPT_GET_TOTAL_COSTResult> lst = new List<PRC_RPT_GET_TOTAL_COSTResult>();
            lst = objBO.GetTotalCost().ToList();
            DataTable report = General.ConvertToDataTable(lst);
            report.TableName = "Detail";
            DataTable[] arrTable = { report };
            export.ExportExcel(Server.MapPath("~/Template/Excel/RPT_GETTOTALCOST.xls"), arrTable, "_RPT_GETTOTALCOST.xls");
        }
        catch(Exception ex)
        {
            lblAlerting.Text = "Xuất báo cáo thất bại, vui lòng thử lại sau...";
            return;
        }
        
    }
}