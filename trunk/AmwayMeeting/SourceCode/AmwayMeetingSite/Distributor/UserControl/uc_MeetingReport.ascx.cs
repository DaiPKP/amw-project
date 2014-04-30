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
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        USR_AMW_MEETING_REPORT report = new USR_AMW_MEETING_REPORT();
        report.MEETING_ID = 1;
        report.INVITE_QUANTITY = int.Parse(txtINVITE_QUANTITY.Text.Trim());
        report.WATER_QUANTITY = int.Parse(txtWATER_QUANTITY.Text.Trim());
        report.FOOD_QUANTITY = int.Parse(txtFOOD_QUANTITY.Text.Trim());
        report.SUMMARY_WATER = int.Parse(txtSUMMARY_WATER.Text.Trim());
        report.SUMMARY_FOOD = int.Parse(txtSUMMARY_FOOD.Text.Trim());
        report._20_PERCENT = int.Parse(txt20_PERCENT.Text.Trim());
        report.PRINTING_INVITATION = int.Parse(txtPRINTING_INVITATION.Text.Trim());
        report.OTHER_1 = int.Parse(txtOTHER1.Text.Trim());
        report.OTHER_2 = int.Parse(txtOTHER2.Text.Trim());
        report.OTHER_3 = int.Parse(txtOTHER3.Text.Trim());
        report.OTHER_4 = int.Parse(txtOTHER4.Text.Trim());
        report.OTHER_5 = int.Parse(txtOTHER5.Text.Trim());
        report.RATING_OVERVIEW = int.Parse(hdfRATING_OVERVIEW.Value);
        report.RATING_ROOM = int.Parse(hdfRATING_ROOM.Value);
        report.RATING_SUPPORT_USE = int.Parse(hdfRATING_SUPPORT_USE.Value);
        report.RATING_SUPPORT_CHANGE = int.Parse(hdfRATING_SUPPORT_CHANGE.Value);
        report.RATING_SUMMARY = int.Parse(hdfRATING_SUMMARY.Value);
        report.OTHER_COMMENT_ROOM = txtOTHER_COMMENT_ROOM.Text.Trim();
        report.OTHER_COMMENT_STAFT = txtOTHER_COMMENT_STAFT.Text.Trim();
        MeetingReportBO reportBO = new MeetingReportBO();
        int result = reportBO.InsertMeetingReport(report);
        if (result == 0)
        {
            lbMess.Text = "Báo cáo sau hội họp thất bại";
        }
        else
        {
            lbMess.Text = "Báo cáo sau hội họp thành công";
            btnSave.Text = "Cập Nhật";
        }
    }
}