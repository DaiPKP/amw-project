using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

/// <summary>
/// Summary description for ReportBO
/// </summary>
public class ReportBO : AMW_MEETINGDataContext
{
	public ReportBO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public List<PRC_RPT_GET_TOTAL_COSTResult> GetTotalCost()
    {
        try
        {
            List<PRC_RPT_GET_TOTAL_COSTResult> result = new List<PRC_RPT_GET_TOTAL_COSTResult>();
            result = PRC_RPT_GET_TOTAL_COST().ToList();
            return result;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public List<PRC_RPT_GET_TOTAL_COST_BY_PAXResult> GetTotalCostByPax(int PeriodID)
    {
        try
        {
            List<PRC_RPT_GET_TOTAL_COST_BY_PAXResult> result = new List<PRC_RPT_GET_TOTAL_COST_BY_PAXResult>();
            result = PRC_RPT_GET_TOTAL_COST_BY_PAX(PeriodID).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public List<PRC_RPT_GET_TOTAL_COST_BY_DISTResult> GetTotalCostByDist(int PeriodID)
    {
        try
        {
            List<PRC_RPT_GET_TOTAL_COST_BY_DISTResult> result = new List<PRC_RPT_GET_TOTAL_COST_BY_DISTResult>();
            result = PRC_RPT_GET_TOTAL_COST_BY_DIST(PeriodID).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public List<PRC_RPT_GET_TOTAL_COST_BY_LOCATIONResult> GetTotalCostByLocation(int PeriodID)
    {
        try
        {
            List<PRC_RPT_GET_TOTAL_COST_BY_LOCATIONResult> result = new List<PRC_RPT_GET_TOTAL_COST_BY_LOCATIONResult>();
            result = PRC_RPT_GET_TOTAL_COST_BY_LOCATION(PeriodID).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public List<PRC_RPT_GET_TOTAL_COST_BY_PINResult> GetTotalCostByPin(int PeriodID)
    {
        try
        {
            List<PRC_RPT_GET_TOTAL_COST_BY_PINResult> result = new List<PRC_RPT_GET_TOTAL_COST_BY_PINResult>();
            result = PRC_RPT_GET_TOTAL_COST_BY_PIN(PeriodID).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public List<PRC_RPT_GET_TOTAL_COST_BY_PROVResult> GetTotalCostByProv(int PeriodID)
    {
        try
        {
            List<PRC_RPT_GET_TOTAL_COST_BY_PROVResult> result = new List<PRC_RPT_GET_TOTAL_COST_BY_PROVResult>();
            result = PRC_RPT_GET_TOTAL_COST_BY_PROV(PeriodID).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public List<PRC_RPT_GET_TOTAL_COST_BY_SYSTEMResult> GetTotalCostBySystem(int PeriodID)
    {
        try
        {
            List<PRC_RPT_GET_TOTAL_COST_BY_SYSTEMResult> result = new List<PRC_RPT_GET_TOTAL_COST_BY_SYSTEMResult>();
            result = PRC_RPT_GET_TOTAL_COST_BY_SYSTEM(PeriodID).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public List<PRC_RPT_LIST_MEETINGResult> GetMeetingList(DateTime FromDate, DateTime ToDate, int MeetingTypeID)
    {
        try
        {
            List<PRC_RPT_LIST_MEETINGResult> result = new List<PRC_RPT_LIST_MEETINGResult>();
            result = PRC_RPT_LIST_MEETING(FromDate, ToDate, MeetingTypeID).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public List<PRC_RPT_GET_SESSION_BY_PAXResult> GetSessionByPax(DateTime FromDate, DateTime ToDate)
    {
        try
        {
            List<PRC_RPT_GET_SESSION_BY_PAXResult> result = new List<PRC_RPT_GET_SESSION_BY_PAXResult>();
            result = PRC_RPT_GET_SESSION_BY_PAX(FromDate, ToDate).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public List<PRC_RPT_GET_SESSION_BY_PAX_PROVINCEResult> GetSessionByProvince(DateTime FromDate, DateTime ToDate, bool Foreigner)
    {
        try
        {
            List<PRC_RPT_GET_SESSION_BY_PAX_PROVINCEResult> result = new List<PRC_RPT_GET_SESSION_BY_PAX_PROVINCEResult>();
            result = PRC_RPT_GET_SESSION_BY_PAX_PROVINCE(FromDate, ToDate, Foreigner).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public List<PRC_RPT_GET_SESSION_BY_PAX_PROVINCE_DETAILResult> GetSessionByProvinceDetail(DateTime FromDate, DateTime ToDate, bool Foreigner)
    {
        try
        {
            List<PRC_RPT_GET_SESSION_BY_PAX_PROVINCE_DETAILResult> result = new List<PRC_RPT_GET_SESSION_BY_PAX_PROVINCE_DETAILResult>();
            result = PRC_RPT_GET_SESSION_BY_PAX_PROVINCE_DETAIL(FromDate, ToDate, Foreigner).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}