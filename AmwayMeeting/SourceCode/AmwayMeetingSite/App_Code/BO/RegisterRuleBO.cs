using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

/// <summary>
/// Summary description for RegisterRuleBO
/// </summary>
public class RegisterRuleBO: AMW_MEETINGDataContext
{
	public RegisterRuleBO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int InsertRegisterRule(int UserID, int RuleID)
    {
        try
        {
            return PRC_USR_AMW_REGISTER_RULE_INSERT(UserID, RuleID);
        }
        catch
        {
            return -1;
        }
    }
}