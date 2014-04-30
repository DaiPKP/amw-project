using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Text.RegularExpressions;
using System.Globalization;

public partial class Distributor_UserControl_uc_MeetingReport : System.Web.UI.UserControl
{
    public int iMeetingID = 0;
    public int iID = 0;
    public string strAction = "V";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hdfID.Value = "1";
            InitData();
        }
    }

    private void InitData()
    {
        //iMeetingID = int.Parse(hdfMEETING_ID.Value);
        if (strAction.Equals("V"))
        {
            btnSave.Text = "Cập Nhật";
            LoadMeetingReportInfo();
        }
        else
        {
            btnSave.Text = "Báo Cáo";
        }
    }

    private void LoadMeetingReportInfo()
    {
        PRC_USR_AMW_MEETING_REPORT_GETLISTBYIDResult report = new PRC_USR_AMW_MEETING_REPORT_GETLISTBYIDResult();
        MeetingReportBO reportBO = new MeetingReportBO();
        report = reportBO.GetMeetingReportByID(iMeetingID);
        hdfMEETING_ID.Value = report.MEETING_ID.ToString();
        hdfID.Value = report.ID.ToString();
        txtINVITE_QUANTITY.Text = report.INVITE_QUANTITY.ToString();
        txtWATER_QUANTITY.Text = report.WATER_QUANTITY.ToString();
        txtFOOD_QUANTITY.Text = report.FOOD_QUANTITY.ToString();
        txtSUMMARY_WATER.Text = report.SUMMARY_WATER.ToString();
        txtSUMMARY_FOOD.Text = report.SUMMARY_FOOD.ToString();
        txt20_PERCENT.Text = report._20_PERCENT.ToString();
        txtPRINTING_INVITATION.Text = report.PRINTING_INVITATION.ToString();
        txtOTHER1.Text = report.OTHER_1.ToString();
        txtOTHER2.Text = report.OTHER_2.ToString();
        txtOTHER3.Text = report.OTHER_3.ToString();
        txtOTHER4.Text = report.OTHER_4.ToString();
        txtOTHER5.Text = report.OTHER_5.ToString();
        hdfRATING_OVERVIEW.Value = report.RATING_OVERVIEW.ToString();
        hdfRATING_ROOM.Value = report.RATING_ROOM.ToString();
        hdfRATING_SUPPORT_USE.Value = report.RATING_SUPPORT_USE.ToString();
        hdfRATING_SUPPORT_CHANGE.Value = report.RATING_SUPPORT_CHANGE.ToString();
        hdfRATING_SUMMARY.Value = report.RATING_SUMMARY.ToString();
        txtOTHER_COMMENT_ROOM.Text = report.OTHER_COMMENT_ROOM.ToString();
        txtOTHER_COMMENT_STAFT.Text = report.OTHER_COMMENT_STAFT.ToString();   
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (chkConfirm.Checked == false)
        {
            lbMess.Text = "Vui lòng xác nhận thông tin báo cáo của bạn là đúng sự thật và chịu trách nhiệm với báo cáo này.";
        }
        else
        {
            USR_AMW_MEETING_REPORT report = new USR_AMW_MEETING_REPORT();
            report.MEETING_ID = iMeetingID;
            report.INVITE_QUANTITY = int.Parse(txtINVITE_QUANTITY.Text.Trim().Replace(",", ""));
            report.WATER_QUANTITY = int.Parse(txtWATER_QUANTITY.Text.Trim().Replace(",", ""));
            report.FOOD_QUANTITY = int.Parse(txtFOOD_QUANTITY.Text.Trim().Replace(",", ""));
            report.SUMMARY_WATER = int.Parse(txtSUMMARY_WATER.Text.Trim().Replace(",", ""));
            report.SUMMARY_FOOD = int.Parse(txtSUMMARY_FOOD.Text.Trim().Replace(",", ""));
            report._20_PERCENT = int.Parse(txt20_PERCENT.Text.Trim().Replace(",", ""));
            report.PRINTING_INVITATION = int.Parse(txtPRINTING_INVITATION.Text.Trim().Replace(",", ""));
            report.OTHER_1 = int.Parse(txtOTHER1.Text.Trim().Replace(",", ""));
            report.OTHER_2 = int.Parse(txtOTHER2.Text.Trim().Replace(",", ""));
            report.OTHER_3 = int.Parse(txtOTHER3.Text.Trim().Replace(",", ""));
            report.OTHER_4 = int.Parse(txtOTHER4.Text.Trim().Replace(",", ""));
            report.OTHER_5 = int.Parse(txtOTHER5.Text.Trim().Replace(",", ""));
            report.RATING_OVERVIEW = int.Parse(hdfRATING_OVERVIEW.Value);
            report.RATING_ROOM = int.Parse(hdfRATING_ROOM.Value);
            report.RATING_SUPPORT_USE = int.Parse(hdfRATING_SUPPORT_USE.Value);
            report.RATING_SUPPORT_CHANGE = int.Parse(hdfRATING_SUPPORT_CHANGE.Value);
            report.RATING_SUMMARY = int.Parse(hdfRATING_SUMMARY.Value);
            report.OTHER_COMMENT_ROOM = txtOTHER_COMMENT_ROOM.Text.Trim();
            report.OTHER_COMMENT_STAFT = txtOTHER_COMMENT_STAFT.Text.Trim();
            MeetingReportBO reportBO = new MeetingReportBO();
            if (btnSave.Text.Equals("Báo Cáo"))
            {
                int result = reportBO.InsertMeetingReport(report);
                if (result == 0)
                {
                    lbMess.Text = "Báo cáo sau hội họp thất bại";
                }
                else
                {
                    hdfID.Value = result.ToString();
                    lbMess.Text = "Báo cáo sau hội họp thành công";
                    btnSave.Text = "Cập Nhật";
                }
            }
            else
            {
                report.ID = int.Parse(hdfID.Value);
                bool result = reportBO.UpdateMeetingReport(report);
                if (result)
                {
                    lbMess.Text = "Cập nhật báo cáo sau hội họp thành công";
                }
                else
                {
                    lbMess.Text = "Cập nhật báo cáo sau hội họp thất bại";
                }
            }
            
        }
    }
}