using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

/// <summary>
/// Summary description for CategoryBO
/// </summary>
public class CategoryBO : AMW_MEETINGDataContext
{
    public CategoryBO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int ProvinceInsert(SYS_AMW_PROVINCE objProvince)
    {
        try
        {
            SYS_AMW_PROVINCE Province = new SYS_AMW_PROVINCE();
            Province = objProvince;
           return PRC_SYS_AMW_PROVINCE_INSERT(Province.PROVINCENAME, Province.DESCRIPTION,Province.ACTIVE);
            
        }
        catch
        {
            return -1;
        }
    }

    public bool ProvinceUpdate(SYS_AMW_PROVINCE objProvince)
    {
        try
        {
            SYS_AMW_PROVINCE Province = new SYS_AMW_PROVINCE();
            Province = objProvince;
            int result = PRC_SYS_AMW_PROVINCE_UPDATE(Province.ID, Province.PROVINCENAME, Province.DESCRIPTION, Province.ACTIVE);
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

    public List<PRC_SYS_AMW_PROVINCE_CBOResult> ProvinceGet_CBO()
    {
        try
        {
            List<PRC_SYS_AMW_PROVINCE_CBOResult> result = new List<PRC_SYS_AMW_PROVINCE_CBOResult>();
            result = PRC_SYS_AMW_PROVINCE_CBO().ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public List<PRC_SYS_AMW_PROVINCE_GETLISTBYIDResult> ProvinceGetListByID(int ID)
    {
        try
        {
            List<PRC_SYS_AMW_PROVINCE_GETLISTBYIDResult> result = new List<PRC_SYS_AMW_PROVINCE_GETLISTBYIDResult>();
            result = PRC_SYS_AMW_PROVINCE_GETLISTBYID(ID).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public List<PRC_SYS_AMW_PROVINCE_SEARCHResult> ProvinceGet_Search(SYS_AMW_PROVINCE objProvince)
    {
        try
        {
            List<PRC_SYS_AMW_PROVINCE_SEARCHResult> result = new List<PRC_SYS_AMW_PROVINCE_SEARCHResult>();
            result = PRC_SYS_AMW_PROVINCE_SEARCH(objProvince.PROVINCENAME, objProvince.DESCRIPTION, objProvince.ACTIVE).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }


    public int PaxInsert(SYS_AMW_PAX objPax)
    {
        try
        {
            SYS_AMW_PAX Pax = new SYS_AMW_PAX();
            Pax = objPax;
            return PRC_SYS_AMW_PAX_INSERT(Pax.PAXNAME, Pax.DESCRIPTION, Pax.ACTIVE);

        }
        catch
        {
            return -1;
        }
    }

    public bool PaxUpdate(SYS_AMW_PAX objPax)
    {
        try
        {
            SYS_AMW_PAX Pax = new SYS_AMW_PAX();
            Pax = objPax;
            int result = PRC_SYS_AMW_PAX_UPDATE(Pax.ID, Pax.PAXNAME, Pax.DESCRIPTION, Pax.ACTIVE);
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

    public List<PRC_SYS_AMW_PAX_GETLISTBYIDResult> PaxGetListByID(int ID)
    {
        try
        {
            List<PRC_SYS_AMW_PAX_GETLISTBYIDResult> result = new List<PRC_SYS_AMW_PAX_GETLISTBYIDResult>();
            result = PRC_SYS_AMW_PAX_GETLISTBYID(ID).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public List<PRC_SYS_AMW_PAX_CBOResult> PaxGet_CBO()
    {
        try
        {
            List<PRC_SYS_AMW_PAX_CBOResult> result = new List<PRC_SYS_AMW_PAX_CBOResult>();
            result = PRC_SYS_AMW_PAX_CBO().ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public List<PRC_SYS_AMW_PAX_SEARCHResult> PaxGet_Search(SYS_AMW_PAX objPax)
    {
        try
        {
            List<PRC_SYS_AMW_PAX_SEARCHResult> result = new List<PRC_SYS_AMW_PAX_SEARCHResult>();
            result = PRC_SYS_AMW_PAX_SEARCH(objPax.PAXNAME, objPax.DESCRIPTION, objPax.ACTIVE).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }




    public int UserTypeInsert(SYS_AMW_USERTYPE objUserType)
    {
        try
        {
            SYS_AMW_USERTYPE UserType = new SYS_AMW_USERTYPE();
            UserType = objUserType;
            return PRC_SYS_AMW_USERTYPE_INSERT(UserType.USERTYPENAME, UserType.DESCRIPTION, UserType.ACTIVE);

        }
        catch
        {
            return -1;
        }
    }

    public bool UserTypeUpdate(SYS_AMW_USERTYPE objUserType)
    {
        try
        {
            SYS_AMW_USERTYPE UserType = new SYS_AMW_USERTYPE();
            UserType = objUserType;
            int result = PRC_SYS_AMW_USERTYPE_UPDATE(UserType.ID, UserType.USERTYPENAME, UserType.DESCRIPTION, UserType.ACTIVE);
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

    public List<PRC_SYS_AMW_USERTYPE_GETLISTBYIDResult> UserTypeGetListByID(int ID)
    {
        try
        {
            List<PRC_SYS_AMW_USERTYPE_GETLISTBYIDResult> result = new List<PRC_SYS_AMW_USERTYPE_GETLISTBYIDResult>();
            result = PRC_SYS_AMW_USERTYPE_GETLISTBYID(ID).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public List<PRC_SYS_AMW_USERTYPE_CBOResult> UserTypeGet_CBO()
    {
        try
        {
            List<PRC_SYS_AMW_USERTYPE_CBOResult> result = new List<PRC_SYS_AMW_USERTYPE_CBOResult>();
            result = PRC_SYS_AMW_USERTYPE_CBO().ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public List<PRC_SYS_AMW_USERTYPE_SEARCHResult> UserTypeGet_Search(SYS_AMW_USERTYPE objUserType)
    {
        try
        {
            List<PRC_SYS_AMW_USERTYPE_SEARCHResult> result = new List<PRC_SYS_AMW_USERTYPE_SEARCHResult>();
            result = PRC_SYS_AMW_USERTYPE_SEARCH(objUserType.USERTYPENAME, objUserType.DESCRIPTION, objUserType.ACTIVE).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }



    public int UserType_LevelInsert(SYS_AMW_USERTYPE_LEVEL objUserType_Level)
    {
        try
        {
            SYS_AMW_USERTYPE_LEVEL UserType_Level = new SYS_AMW_USERTYPE_LEVEL();
            UserType_Level = objUserType_Level;
            return PRC_SYS_AMW_USERTYPE_LEVEL_INSERT(UserType_Level.USERTYPEID,UserType_Level.USERTYPE_LEVELNAME, UserType_Level.DESCRIPTION, UserType_Level.ACTIVE);

        }
        catch
        {
            return -1;
        }
    }

    public bool UserType_LevelUpdate(SYS_AMW_USERTYPE_LEVEL objUserType_Level)
    {
        try
        {
            SYS_AMW_USERTYPE_LEVEL UserType_Level = new SYS_AMW_USERTYPE_LEVEL();
            UserType_Level = objUserType_Level;
            int result = PRC_SYS_AMW_USERTYPE_LEVEL_UPDATE(UserType_Level.ID, UserType_Level.USERTYPEID, UserType_Level.USERTYPE_LEVELNAME, UserType_Level.DESCRIPTION, UserType_Level.ACTIVE);
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

    public List<PRC_SYS_AMW_USERTYPE_LEVEL_GETLISTBYIDResult> UserType_LevelGetListByID(int ID)
    {
        try
        {
            List<PRC_SYS_AMW_USERTYPE_LEVEL_GETLISTBYIDResult> result = new List<PRC_SYS_AMW_USERTYPE_LEVEL_GETLISTBYIDResult>();
            result = PRC_SYS_AMW_USERTYPE_LEVEL_GETLISTBYID(ID).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public List<PRC_SYS_AMW_USERTYPE_LEVEL_CBOResult> UserType_LevelGet_CBO()
    {
        try
        {
            List<PRC_SYS_AMW_USERTYPE_LEVEL_CBOResult> result = new List<PRC_SYS_AMW_USERTYPE_LEVEL_CBOResult>();
            result = PRC_SYS_AMW_USERTYPE_LEVEL_CBO().ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public List<PRC_SYS_AMW_USERTYPE_LEVEL_SEARCHResult> UserType_LevelGet_Search(SYS_AMW_USERTYPE_LEVEL objUserType_Level)
    {
        try
        {
            List<PRC_SYS_AMW_USERTYPE_LEVEL_SEARCHResult> result = new List<PRC_SYS_AMW_USERTYPE_LEVEL_SEARCHResult>();
            result = PRC_SYS_AMW_USERTYPE_LEVEL_SEARCH(objUserType_Level.USERTYPEID, objUserType_Level.USERTYPE_LEVELNAME, objUserType_Level.DESCRIPTION, objUserType_Level.ACTIVE).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}