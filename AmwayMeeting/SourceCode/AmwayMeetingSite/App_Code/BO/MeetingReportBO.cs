using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

/// <summary>
/// Summary description for MeetingReportBO
/// </summary>
public class MeetingReportBO: AMW_MEETINGDataContext
{
	public MeetingReportBO()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int InsertMeetingReport(USR_AMW_MEETING_REPORT objMEETINGREPORT)
    {
        try
        { 
            USR_AMW_MEETING_REPORT report = new USR_AMW_MEETING_REPORT();
            report = objMEETINGREPORT;
            return PRC_USR_AMW_MEETING_REPORT_INSERT(report.MEETING_ID, report.INVITE_QUANTITY, report.WATER_QUANTITY, report.FOOD_QUANTITY, report.SUMMARY_WATER, report.SUMMARY_FOOD, report._20_PERCENT, report.PRINTING_INVITATION, report.OTHER_1, report.OTHER_2, report.OTHER_3, report.OTHER_4, report.OTHER_5, report.RATING_OVERVIEW, report.RATING_ROOM, report.RATING_SUPPORT_USE, report.RATING_SUPPORT_CHANGE, report.RATING_SUMMARY, report.OTHER_COMMENT_ROOM, report.OTHER_COMMENT_STAFT);
        }
        catch
        {
            return -1;
        }
    }

    public bool UpdateMeetingReport(USR_AMW_MEETING_REPORT objMEETINGREPORT)
    {
        try
        {
            USR_AMW_MEETING_REPORT report = new USR_AMW_MEETING_REPORT();
            report = objMEETINGREPORT;
            int result = PRC_USR_AMW_MEETING_REPORT_UPDATE(report.ID, report.INVITE_QUANTITY, report.WATER_QUANTITY, report.FOOD_QUANTITY, report.SUMMARY_WATER, report.SUMMARY_FOOD, report._20_PERCENT, report.PRINTING_INVITATION, report.OTHER_1, report.OTHER_2, report.OTHER_3, report.OTHER_4, report.OTHER_5, report.RATING_OVERVIEW, report.RATING_ROOM, report.RATING_SUPPORT_USE, report.RATING_SUPPORT_CHANGE, report.RATING_SUMMARY, report.OTHER_COMMENT_ROOM, report.OTHER_COMMENT_STAFT);
            if (result == 1)
                return true;
            else
                return false;
        }
        catch
        {
            return false;
        }
    }
}