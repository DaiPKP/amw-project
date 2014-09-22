using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

/// <summary>
/// Summary description for UserBO
/// </summary>
public class UserBO : AMW_MEETINGDataContext
{
    public UserBO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool UserCheckEmail(string strEmail)
    {
        try
        {
            int result = PRC_SYS_AMW_USER_CHECKEMAIL(strEmail);
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

    public int UserInsert(SYS_AMW_USER objUser)
    {
        try
        {
            SYS_AMW_USER Acc = new SYS_AMW_USER();
            Acc = objUser;
            return PRC_SYS_AMW_USER_INSERT(Acc.ADA, Acc.PASSWORD,Acc.FIRSTNAME,Acc.LASTNAME,Acc.RELATIVE_FIRSTNAME,Acc.RELATIVE_LASTNAME, Acc.ADDRESS, Acc.TELEPHONE,Acc.CODE,Acc.FAX, Acc.EMAIL,Acc.ACCBANK,Acc.DESCRIPTION ,Acc.USERTYPEID,Acc.DEPARTMENTID,Acc.ACTIVE,Acc.WORKDISTRICTID,Acc.WORKPROVINCEID,Acc.CREATEUSER,Acc.USER_SYSTEMID,Acc.USERTYPE_ENHANCEID);

        }
        catch
        {
            return -1;
        }
    }

    public bool UserUpdateEmailAddress(int UserID, string Email, string Address)
    {
        try
        {
            SYS_AMW_USER Acc = new SYS_AMW_USER();
            int result = PRC_SYS_AMW_USER_UPDATE_Email_Address(UserID, Address, Email);
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

    public bool UserUpdate(SYS_AMW_USER objUser)
    {
        try
        {
            SYS_AMW_USER Acc = new SYS_AMW_USER();
            Acc = objUser;
            int result = PRC_SYS_AMW_USER_UPDATE(Acc.USERID, Acc.ADA, Acc.FIRSTNAME, Acc.LASTNAME, Acc.RELATIVE_FIRSTNAME, Acc.RELATIVE_LASTNAME, Acc.ADDRESS, Acc.TELEPHONE, Acc.CODE, Acc.FAX, Acc.EMAIL, Acc.ACCBANK, Acc.DESCRIPTION, Acc.USERTYPEID, Acc.DEPARTMENTID, Acc.ACTIVE, Acc.WORKDISTRICTID, Acc.WORKPROVINCEID, Acc.UPDATEUSER, Acc.USER_SYSTEMID, Acc.USERTYPE_ENHANCEID);
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
    public bool UserUpdatePasswordByEmail(string email, string pass)
    {
        try
        {
            int result = PRC_SYS_AMW_USER_UPDATEBYEMAIL(email, pass);
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
    public bool UserUpdatePasswordByADA(string ADA, string pass)
    {
        try
        {
            int result = PRC_SYS_AMW_USER_UPDATEBYADA(ADA, pass);
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
    public PRC_SYS_AMW_USER_GETLISTBYUSERIDResult UserGetListByUserID(int UserID)
    {
        try
        {
            PRC_SYS_AMW_USER_GETLISTBYUSERIDResult result = new PRC_SYS_AMW_USER_GETLISTBYUSERIDResult();
            result = PRC_SYS_AMW_USER_GETLISTBYUSERID(UserID).SingleOrDefault();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public PRC_SYS_AMW_USER_GETLISTResult UserGetList(SYS_AMW_USER objUser)
    {
        try
        {
            PRC_SYS_AMW_USER_GETLISTResult result = new PRC_SYS_AMW_USER_GETLISTResult();
            result = PRC_SYS_AMW_USER_GETLIST(objUser.ADA, objUser.PASSWORD).SingleOrDefault();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public List<PRC_SYS_AMW_USER_GETALLResult> UserGetAll()
    {
        try
        {
            List<PRC_SYS_AMW_USER_GETALLResult> result = new List<PRC_SYS_AMW_USER_GETALLResult>();
            result = PRC_SYS_AMW_USER_GETALL().ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public List<PRC_TEMP_GETALLResult> UserGetAll_Temp()
    {
        try
        {
            List<PRC_TEMP_GETALLResult> result = new List<PRC_TEMP_GETALLResult>();
            result = PRC_TEMP_GETALL().ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }


    public List<PRC_SYS_AMW_USER_SEARCHResult> UserGet_Search(SYS_AMW_USER objUser)
    {
        try
        {
            SYS_AMW_USER Acc = new SYS_AMW_USER();
            Acc = objUser;
            List<PRC_SYS_AMW_USER_SEARCHResult> result = new List<PRC_SYS_AMW_USER_SEARCHResult>();
            result = PRC_SYS_AMW_USER_SEARCH(Acc.ADA, Acc.FIRSTNAME, Acc.LASTNAME, Acc.RELATIVE_FIRSTNAME, Acc.RELATIVE_LASTNAME, Acc.ADDRESS, Acc.TELEPHONE, Acc.CODE, Acc.FAX, Acc.EMAIL, Acc.ACCBANK, Acc.DESCRIPTION, Acc.USERTYPEID, Acc.DEPARTMENTID, Acc.ACTIVE, Acc.WORKDISTRICTID, Acc.WORKPROVINCEID, Acc.USER_SYSTEMID, Acc.USERTYPE_ENHANCEID).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public bool UserConvertPass(int userId, string strPass)
    {
        try
        {
           
            int result = SYS_CONVERT_PASS(userId, strPass);
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