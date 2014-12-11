using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Data;
using System.Globalization;

public partial class Reports_UserControl_uc_rpt_Summary_Spend : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }

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
            List<PRC_RPT_SUMMARY_SPENDResult> lst = new List<PRC_RPT_SUMMARY_SPENDResult>();
            lst = objBO.GetSummarySpend(DateTime.ParseExact(txtFROM_DATE.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture), DateTime.ParseExact(txtTO_DATE.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture)).ToList();
            DataTable report = General.ConvertToDataTable(lst);
            report.TableName = "Detail";
            DataTable[] arrTable = { report };
            export.ExportExcel(Server.MapPath("~/Template/Excel/RPT_SUMMARY_SPEND.xls"), arrTable, "_RPT_SUMMARY_SPEND.xls");
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