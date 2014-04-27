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


    public int Pax_ProvinceInsert(SYS_AMW_PAX_PROVINCE objPax_Province)
    {
        try
        {
            SYS_AMW_PAX_PROVINCE Pax_Province = new SYS_AMW_PAX_PROVINCE();
            Pax_Province = objPax_Province;
            return PRC_SYS_AMW_PAX_PROVINCE_INSERT( Pax_Province.PAXID, Pax_Province.PROVINCEID, Pax_Province.DESCRIPTION, Pax_Province.ACTIVE);

        }
        catch
        {
            return -1;
        }
    }

    public bool Pax_ProvinceUpdate(SYS_AMW_PAX_PROVINCE objPax_Province)
    {
        try
        {
            SYS_AMW_PAX_PROVINCE Pax_Province = new SYS_AMW_PAX_PROVINCE();
            Pax_Province = objPax_Province;
            int result = PRC_SYS_AMW_PAX_PROVINCE_UPDATE(Pax_Province.ID, Pax_Province.PAXID, Pax_Province.PROVINCEID, Pax_Province.DESCRIPTION, Pax_Province.ACTIVE);
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

    public List<PRC_SYS_AMW_PAX_PROVINCE_GETLISTBYIDResult> Pax_ProvinceGetListByID(int ID)
    {
        try
        {
            List<PRC_SYS_AMW_PAX_PROVINCE_GETLISTBYIDResult> result = new List<PRC_SYS_AMW_PAX_PROVINCE_GETLISTBYIDResult>();
            result = PRC_SYS_AMW_PAX_PROVINCE_GETLISTBYID(ID).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }   
    public List<PRC_SYS_AMW_PAX_PROVINCE_SEARCHResult> Pax_ProvinceGet_Search(SYS_AMW_PAX_PROVINCE objPax_Province)
    {
        try
        {
            List<PRC_SYS_AMW_PAX_PROVINCE_SEARCHResult> result = new List<PRC_SYS_AMW_PAX_PROVINCE_SEARCHResult>();
            result = PRC_SYS_AMW_PAX_PROVINCE_SEARCH(objPax_Province.PAXID, objPax_Province.PROVINCEID, objPax_Province.DESCRIPTION, objPax_Province.ACTIVE).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }


    public int PolicyInsert(SYS_AMW_POLICY objPolicy)
    {
        try
        {
            SYS_AMW_POLICY Policy = new SYS_AMW_POLICY();
            Policy = objPolicy;
            return PRC_SYS_AMW_POLICY_INSERT(Policy.PAXID, Policy.USERTYPEID, Policy.QUOTA, Policy.CONDITIONCOMBINED);

        }
        catch
        {
            return -1;
        }
    }

    public bool PolicyUpdate(SYS_AMW_POLICY objPolicy)
    {
        try
        {
            SYS_AMW_POLICY Policy = new SYS_AMW_POLICY();
            Policy = objPolicy;
            int result = PRC_SYS_AMW_POLICY_UPDATE(Policy.ID, Policy.PAXID, Policy.USERTYPEID, Policy.QUOTA, Policy.CONDITIONCOMBINED);
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

    public List<PRC_SYS_AMW_POLICY_GETLISTBYIDResult> PolicyGetListByID(int ID)
    {
        try
        {
            List<PRC_SYS_AMW_POLICY_GETLISTBYIDResult> result = new List<PRC_SYS_AMW_POLICY_GETLISTBYIDResult>();
            result = PRC_SYS_AMW_POLICY_GETLISTBYID(ID).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public List<PRC_SYS_AMW_POLICY_SEARCHResult> PolicyGet_Search(SYS_AMW_POLICY objPolicy)
    {
        try
        {
            List<PRC_SYS_AMW_POLICY_SEARCHResult> result = new List<PRC_SYS_AMW_POLICY_SEARCHResult>();
            result = PRC_SYS_AMW_POLICY_SEARCH(objPolicy.PAXID, objPolicy.USERTYPEID, objPolicy.QUOTA, objPolicy.CONDITIONCOMBINED).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }


    public int PeriodInsert(SYS_AMW_PERIOD objPeriod)
    {
        try
        {
            SYS_AMW_PERIOD Period = new SYS_AMW_PERIOD();
            Period = objPeriod;
            return PRC_SYS_AMW_PERIOD_INSERT(Period.PERIODNAME, Period.STARTDATE, Period.ENDDATE, Period.DESCRIPTION, Period.ACTIVE, Period.CREATEUSER);

        }
        catch
        {
            return -1;
        }
    }

    public bool PeriodUpdate(SYS_AMW_PERIOD objPeriod)
    {
        try
        {
            SYS_AMW_PERIOD Period = new SYS_AMW_PERIOD();
            Period = objPeriod;
            int result = PRC_SYS_AMW_PERIOD_UPDATE(Period.ID, Period.PERIODNAME, Period.STARTDATE, Period.ENDDATE, Period.DESCRIPTION, Period.ACTIVE, Period.UPDATEUSER);
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

    public List<PRC_SYS_AMW_PERIOD_GETLISTBYIDResult> PeriodGetListByID(int ID)
    {
        try
        {
            List<PRC_SYS_AMW_PERIOD_GETLISTBYIDResult> result = new List<PRC_SYS_AMW_PERIOD_GETLISTBYIDResult>();
            result = PRC_SYS_AMW_PERIOD_GETLISTBYID(ID).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public List<PRC_SYS_AMW_PERIOD_SEARCHResult> PeriodGet_Search(SYS_AMW_PERIOD objPeriod)
    {
        try
        {
            List<PRC_SYS_AMW_PERIOD_SEARCHResult> result = new List<PRC_SYS_AMW_PERIOD_SEARCHResult>();
            result = PRC_SYS_AMW_PERIOD_SEARCH(objPeriod.PERIODNAME, objPeriod.STARTDATE, objPeriod.ENDDATE, objPeriod.DESCRIPTION, objPeriod.ACTIVE).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public List<PRC_SYS_AMW_STATUS_FORMS_OF_PAYMENT_CBOResult> FormsOfPaymentGet_CBO()
    {
        try
        {
            List<PRC_SYS_AMW_STATUS_FORMS_OF_PAYMENT_CBOResult> result = new List<PRC_SYS_AMW_STATUS_FORMS_OF_PAYMENT_CBOResult>();
            result = PRC_SYS_AMW_STATUS_FORMS_OF_PAYMENT_CBO().ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public List<PRC_SYS_AMW_STATUS_INVITATION_CBOResult> InvitationGet_CBO()
    {
        try
        {
            List<PRC_SYS_AMW_STATUS_INVITATION_CBOResult> result = new List<PRC_SYS_AMW_STATUS_INVITATION_CBOResult>();
            result = PRC_SYS_AMW_STATUS_INVITATION_CBO().ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public List<PRC_SYS_AMW_STATUS_MEETING_PAYMENT_CBOResult> StatusMeetingPaymentGet_CBO()
    {
        try
        {
            List<PRC_SYS_AMW_STATUS_MEETING_PAYMENT_CBOResult> result = new List<PRC_SYS_AMW_STATUS_MEETING_PAYMENT_CBOResult>();
            result = PRC_SYS_AMW_STATUS_MEETING_PAYMENT_CBO().ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public List<PRC_SYS_AMW_STATUS_MEETING_REGISTER_CBOResult> StatusMeetingRegisterGet_CBO()
    {
        try
        {
            List<PRC_SYS_AMW_STATUS_MEETING_REGISTER_CBOResult> result = new List<PRC_SYS_AMW_STATUS_MEETING_REGISTER_CBOResult>();
            result = PRC_SYS_AMW_STATUS_MEETING_REGISTER_CBO().ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public List<PRC_SYS_AMW_STATUS_MEETING_REGISTER_APPROVAL_CBOResult> StatusMeetingRegisterGet_ApprovalCBO(int statusId)
    {
        try
        {
            List<PRC_SYS_AMW_STATUS_MEETING_REGISTER_APPROVAL_CBOResult> result = new List<PRC_SYS_AMW_STATUS_MEETING_REGISTER_APPROVAL_CBOResult>();
            result = PRC_SYS_AMW_STATUS_MEETING_REGISTER_APPROVAL_CBO(statusId).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public List<PRC_SYS_AMW_STATUS_BANNER_CBOResult> StatusBannerGet_CBO()
    {
        try
        {
            List<PRC_SYS_AMW_STATUS_BANNER_CBOResult> result = new List<PRC_SYS_AMW_STATUS_BANNER_CBOResult>();
            result = PRC_SYS_AMW_STATUS_BANNER_CBO().ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public List<PRC_SYS_AMW_MEETING_TYPE_CBOResult> MeetingType_CBO()
    {
        try
        {
            List<PRC_SYS_AMW_MEETING_TYPE_CBOResult> result = new List<PRC_SYS_AMW_MEETING_TYPE_CBOResult>();
            result = PRC_SYS_AMW_MEETING_TYPE_CBO().ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public List<PRC_SYS_AMW_PLACE_GETLISTBY_PROVINCEIDResult> PlaceGet_ByProvinceId(int provinceId)
    {
        try
        {
            List<PRC_SYS_AMW_PLACE_GETLISTBY_PROVINCEIDResult> result = new List<PRC_SYS_AMW_PLACE_GETLISTBY_PROVINCEIDResult>();
            result = PRC_SYS_AMW_PLACE_GETLISTBY_PROVINCEID(provinceId).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}