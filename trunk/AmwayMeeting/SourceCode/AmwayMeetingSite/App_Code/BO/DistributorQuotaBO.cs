using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

/// <summary>
/// Summary description for DistributorQuotaBO
/// </summary>
public class DistributorQuotaBO: AMW_MEETINGDataContext
{
	public DistributorQuotaBO()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<PRC_SYS_AMW_DISTRIBUTOR_QUOTA_GETBY_USERIDResult> GetDistributorQuota(int UserID)
    {
        
        try
        {
            List<PRC_SYS_AMW_DISTRIBUTOR_QUOTA_GETBY_USERIDResult> result = new List<PRC_SYS_AMW_DISTRIBUTOR_QUOTA_GETBY_USERIDResult>();
            result = PRC_SYS_AMW_DISTRIBUTOR_QUOTA_GETBY_USERID(UserID).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
        
    }
}