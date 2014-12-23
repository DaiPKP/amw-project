using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

/// <summary>
/// Summary description for MenuBO
/// </summary>
public class MenuBO : AMW_BookingDataContext
{
    public MenuBO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<PRC_SYS_AMW_MENU_GETBY_USERID_AND_MENUPARENTIDResult> Menu_GetBy_UserIDAndMenuParentId(int UserID, int MenuParentId)
    {
        try
        {
            List<PRC_SYS_AMW_MENU_GETBY_USERID_AND_MENUPARENTIDResult> result = new List<PRC_SYS_AMW_MENU_GETBY_USERID_AND_MENUPARENTIDResult>();
            result = PRC_SYS_AMW_MENU_GETBY_USERID_AND_MENUPARENTID(UserID, MenuParentId).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public List<PRC_SYS_AMW_MENUPARENT_GETBY_USERIDResult> Menu_GetParentBy_UserID(int UserID)
    {
        try
        {
            List<PRC_SYS_AMW_MENUPARENT_GETBY_USERIDResult> result = new List<PRC_SYS_AMW_MENUPARENT_GETBY_USERIDResult>();
            result = PRC_SYS_AMW_MENUPARENT_GETBY_USERID(UserID).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public List<PRC_SYS_AMW_MENU_GETPERMISSIONResult> Menu_Get_Permission(int DepId)
    {
        try
        {
            List<PRC_SYS_AMW_MENU_GETPERMISSIONResult> result = new List<PRC_SYS_AMW_MENU_GETPERMISSIONResult>();
            result = PRC_SYS_AMW_MENU_GETPERMISSION(DepId).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    
    public int Menu_Properties_Insert(int DepId, string DSMenuID)
    {
        try
        {
            return PRC_SYS_AMW_MENU_PROPERTIES_INSERT(DepId, DSMenuID);

        }
        catch
        {
            return -1;
        }
    }
    public List<PRC_SYS_AMW_MENU_PERMISSION_GETCHILD_BY_MENUIDResult> Menu_Get_Permission_Detail(int menuParentId, int DepId)
    {
        try
        {
            List<PRC_SYS_AMW_MENU_PERMISSION_GETCHILD_BY_MENUIDResult> result = new List<PRC_SYS_AMW_MENU_PERMISSION_GETCHILD_BY_MENUIDResult>();
            result = PRC_SYS_AMW_MENU_PERMISSION_GETCHILD_BY_MENUID(menuParentId, DepId).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

}