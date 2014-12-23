using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

/// <summary>
/// Summary description for UserBO
/// </summary>
public class UserBO : AMW_BookingDataContext
{
    public UserBO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    

    public bool UserChangePass(int UserID, string oldPass, string newPass)
    {
        try
        {
            int result = PRC_SYS_AMW_USER_CHANGEPASS(UserID, oldPass, newPass);
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

   
    public PRC_SYS_AMW_USER_GETLISTResult UserGetList(string ADA, string pass )
    {
        try
        {
            PRC_SYS_AMW_USER_GETLISTResult result = new PRC_SYS_AMW_USER_GETLISTResult();
            result = PRC_SYS_AMW_USER_GETLIST(ADA, pass).SingleOrDefault();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
   
}