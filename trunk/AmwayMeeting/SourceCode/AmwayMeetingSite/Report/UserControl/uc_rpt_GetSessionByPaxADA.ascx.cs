using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Data;
using System.Globalization;

public partial class Reports_UserControl_uc_rpt_GetSessionByPaxADA : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //GetMeetingTypeCBO();
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

            if(txtADA.Text.Trim().Equals(""))
            {
                lblAlerting.Text = "Bạn chưa nhập ADA!";
                return;
            }

            Export export = new Export();
            ReportBO objBO = new ReportBO();
            List<PRC_RPT_GET_SESSION_BY_PAX_ADAResult> lst1 = new List<PRC_RPT_GET_SESSION_BY_PAX_ADAResult>();
            lst1 = objBO.GetSessionByPaxADA(DateTime.ParseExact(txtFROM_DATE.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture), DateTime.ParseExact(txtTO_DATE.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture), txtADA.Text.Trim()).ToList();
            DataTable report1 = General.ConvertToDataTable(lst1);

            List<PRC_RPT_GET_SESSION_BY_PAX_ADA_DETAILResult> lst2 = new List<PRC_RPT_GET_SESSION_BY_PAX_ADA_DETAILResult>();
            lst2 = objBO.GetSessionByPaxADADetail(DateTime.ParseExact(txtFROM_DATE.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture), DateTime.ParseExact(txtTO_DATE.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture), txtADA.Text.Trim()).ToList();
            DataTable report2 = General.ConvertToDataTable(lst2);

            report1.TableName = "Detail1";
            report2.TableName = "Detail2";
            DataTable[] arrTable = { report1, report2 };

            export.ExportExcel(Server.MapPath("~/Template/Excel/RPT_SUMMARY_LIST_MEETING_BY_ADA.xls"), arrTable, "_RPT_SUMMARY_LIST_MEETING_BY_ADA.xls");
            
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