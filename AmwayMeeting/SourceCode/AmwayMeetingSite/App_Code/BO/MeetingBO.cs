﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

/// <summary>
/// Summary description for MeetingBO
/// </summary>
public class MeetingBO : AMW_MEETINGDataContext
{
    public MeetingBO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int MeetingInsert(USR_AMW_MEETING_REGISTER obj)
    {
        try
        {

            return PRC_USR_AMW_MEETING_REGISTER_INSERT(obj.ORGANIZER_USERID, obj.ORGANIZER_USERTYPEID, obj.ORGANIZER_ADDRESS_AUTHORIZED, obj.PAXID, obj.DISTRICTID, obj.PROVINCEID, obj.MEETINGNAME, obj.NUMBER_OF_PARTICIPANT, obj.MEETING_PLACE_NAME, obj.MEETING_ADDRESS, obj.COUNTRYNAME, obj.MEETING_DATE, obj.DEPARTURE_DATE, obj.ARRIVAL_DATE, obj.MEETING_STARTDATE, obj.MEETING_ENDDATE, obj.MEETING_TIME, obj.FORMS_OF_PAYMENTID, obj.INVITATIONID, obj.BANNERID, obj.SEND_INVITATION_DATE, obj.WATER, obj.WATER_PRICE, obj.FOOD, obj.FOOD_PRICE, obj.TOTAL_PAY, obj.AMWAY_PAY, obj.DISTRIBUTOR_PAY, obj.MEETINGTYPEID, obj.STATUS_MEETING_PAYMENTID, obj.STATUS_MEETING_REGISTERID, obj.CREATEUSER_USERTYPEID, obj.CREATEUSER, obj.FOREIGNER, obj.REPORTED, obj.CO_ORGANIZER_USERID_1, obj.CO_ORGANIZER_USERTYPEID_1, obj.CO_ORGANIZER_USERID_2, obj.CO_ORGANIZER_USERTYPEID_2, obj.CO_ORGANIZER_USERID_3, obj.CO_ORGANIZER_USERTYPEID_3, obj.SPEAKER_ADAID_1, obj.SPEAKER_USERTYPENAME_1, obj.SPEAKER_NAME_1, obj.SPEAKER_TITLE_1, obj.SPEAKER_NATION_1, obj.SPEAKER_ADAID_2, obj.SPEAKER_USERTYPENAME_2, obj.SPEAKER_NAME_2, obj.SPEAKER_TITLE_2, obj.SPEAKER_NATION_2, obj.COMMENTS, obj.WARNING, obj.PLACEID, obj.AGREE);

        }
        catch
        {
            return -1;
        }
    }

    public bool MeetingUpdate(USR_AMW_MEETING_REGISTER obj)
    {
        try
        {

            int result = PRC_USR_AMW_MEETING_REGISTER_UPDATE(obj.ID, obj.ORGANIZER_USERID, obj.ORGANIZER_USERTYPEID, obj.ORGANIZER_ADDRESS_AUTHORIZED, obj.PAXID, obj.DISTRICTID, obj.PROVINCEID, obj.MEETINGNAME, obj.NUMBER_OF_PARTICIPANT, obj.MEETING_PLACE_NAME, obj.MEETING_ADDRESS, obj.COUNTRYNAME, obj.MEETING_DATE, obj.DEPARTURE_DATE, obj.ARRIVAL_DATE, obj.MEETING_STARTDATE, obj.MEETING_ENDDATE, obj.MEETING_TIME, obj.FORMS_OF_PAYMENTID, obj.INVITATIONID, obj.BANNERID, obj.SEND_INVITATION_DATE, obj.WATER, obj.WATER_PRICE, obj.FOOD, obj.FOOD_PRICE, obj.TOTAL_PAY, obj.AMWAY_PAY, obj.DISTRIBUTOR_PAY, obj.MEETINGTYPEID, obj.STATUS_MEETING_PAYMENTID, obj.STATUS_MEETING_REGISTERID, obj.UPDATEUSER, obj.FOREIGNER, obj.REPORTED, obj.CO_ORGANIZER_USERID_1, obj.CO_ORGANIZER_USERTYPEID_1, obj.CO_ORGANIZER_USERID_2, obj.CO_ORGANIZER_USERTYPEID_2, obj.CO_ORGANIZER_USERID_3, obj.CO_ORGANIZER_USERTYPEID_3, obj.SPEAKER_ADAID_1, obj.SPEAKER_USERTYPENAME_1, obj.SPEAKER_NAME_1, obj.SPEAKER_TITLE_1, obj.SPEAKER_NATION_1, obj.SPEAKER_ADAID_2, obj.SPEAKER_USERTYPENAME_2, obj.SPEAKER_NAME_2, obj.SPEAKER_TITLE_2, obj.SPEAKER_NATION_2, obj.COMMENTS, obj.WARNING, obj.PLACEID, obj.AGREE);
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


    public int MeetingInsert_NotSupportCost(USR_AMW_MEETING_REGISTER obj)
    {
        try
        {

            return PRC_USR_AMW_MEETING_REGISTER_INSERT_NOTSUPPORTCOST(obj.ORGANIZER_USERID, obj.ORGANIZER_USERTYPEID, obj.ORGANIZER_ADDRESS_AUTHORIZED, obj.PAXID, obj.DISTRICTID, obj.PROVINCEID, obj.MEETINGNAME, obj.NUMBER_OF_PARTICIPANT, obj.MEETING_PLACE_NAME, obj.MEETING_ADDRESS, obj.COUNTRYNAME, obj.MEETING_DATE, obj.DEPARTURE_DATE, obj.ARRIVAL_DATE, obj.MEETING_STARTDATE, obj.MEETING_ENDDATE, obj.MEETING_TIME, obj.FORMS_OF_PAYMENTID, obj.INVITATIONID, obj.BANNERID, obj.SEND_INVITATION_DATE, obj.WATER, obj.WATER_PRICE, obj.FOOD, obj.FOOD_PRICE, obj.TOTAL_PAY, obj.AMWAY_PAY, obj.DISTRIBUTOR_PAY, obj.MEETINGTYPEID, obj.STATUS_MEETING_PAYMENTID, obj.STATUS_MEETING_REGISTERID, obj.CREATEUSER_USERTYPEID, obj.CREATEUSER, obj.FOREIGNER, obj.REPORTED, obj.CO_ORGANIZER_USERID_1, obj.CO_ORGANIZER_USERTYPEID_1, obj.CO_ORGANIZER_USERID_2, obj.CO_ORGANIZER_USERTYPEID_2, obj.CO_ORGANIZER_USERID_3, obj.CO_ORGANIZER_USERTYPEID_3, obj.SPEAKER_ADAID_1, obj.SPEAKER_USERTYPENAME_1, obj.SPEAKER_NAME_1, obj.SPEAKER_TITLE_1, obj.SPEAKER_NATION_1, obj.SPEAKER_ADAID_2, obj.SPEAKER_USERTYPENAME_2, obj.SPEAKER_NAME_2, obj.SPEAKER_TITLE_2, obj.SPEAKER_NATION_2, obj.COMMENTS, obj.WARNING, obj.PLACEID, obj.AGREE);

        }
        catch
        {
            return -1;
        }
    }

    public bool MeetingUpdate_NotSupportCost(USR_AMW_MEETING_REGISTER obj)
    {
        try
        {

            int result = PRC_USR_AMW_MEETING_REGISTER_UPDATE_NOTSUPPORTCOST(obj.ID, obj.ORGANIZER_USERID, obj.ORGANIZER_USERTYPEID, obj.ORGANIZER_ADDRESS_AUTHORIZED, obj.PAXID, obj.DISTRICTID, obj.PROVINCEID, obj.MEETINGNAME, obj.NUMBER_OF_PARTICIPANT, obj.MEETING_PLACE_NAME, obj.MEETING_ADDRESS, obj.COUNTRYNAME, obj.MEETING_DATE, obj.DEPARTURE_DATE, obj.ARRIVAL_DATE, obj.MEETING_STARTDATE, obj.MEETING_ENDDATE, obj.MEETING_TIME, obj.FORMS_OF_PAYMENTID, obj.INVITATIONID, obj.BANNERID, obj.SEND_INVITATION_DATE, obj.WATER, obj.WATER_PRICE, obj.FOOD, obj.FOOD_PRICE, obj.TOTAL_PAY, obj.AMWAY_PAY, obj.DISTRIBUTOR_PAY, obj.MEETINGTYPEID, obj.STATUS_MEETING_PAYMENTID, obj.STATUS_MEETING_REGISTERID, obj.UPDATEUSER, obj.FOREIGNER, obj.REPORTED, obj.CO_ORGANIZER_USERID_1, obj.CO_ORGANIZER_USERTYPEID_1, obj.CO_ORGANIZER_USERID_2, obj.CO_ORGANIZER_USERTYPEID_2, obj.CO_ORGANIZER_USERID_3, obj.CO_ORGANIZER_USERTYPEID_3, obj.SPEAKER_ADAID_1, obj.SPEAKER_USERTYPENAME_1, obj.SPEAKER_NAME_1, obj.SPEAKER_TITLE_1, obj.SPEAKER_NATION_1, obj.SPEAKER_ADAID_2, obj.SPEAKER_USERTYPENAME_2, obj.SPEAKER_NAME_2, obj.SPEAKER_TITLE_2, obj.SPEAKER_NATION_2, obj.COMMENTS, obj.WARNING, obj.PLACEID, obj.AGREE);
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

    public bool MeetingUpdateApproval(USR_AMW_MEETING_REGISTER obj)
    {
        try
        {

            int result = PRC_USR_AMW_MEETING_REGISTER_APPROVAL(obj.ID, obj.STATUS_MEETING_REGISTERID,obj.COMMENTS,obj.UPDATEUSER);
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
    public bool MeetingUpdateStatusPayment(USR_AMW_MEETING_REGISTER obj)
    {
        try
        {

            int result = PRC_USR_AMW_MEETING_REGISTER_APPROVAL_PAYMENT(obj.ID, obj.STATUS_MEETING_PAYMENTID, obj.UPDATEUSER);
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
    public PRC_SYS_AMW_USER_GETBY_ADAResult Meeting_GetDistributor_ByADA(string ADA)
    {
        try
        {
            PRC_SYS_AMW_USER_GETBY_ADAResult result = new PRC_SYS_AMW_USER_GETBY_ADAResult();
            result = PRC_SYS_AMW_USER_GETBY_ADA(ADA).SingleOrDefault();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public List<PRC_USR_AMW_MEETING_REGISTER_SEARCHResult> Meeting_Search(string strORGANIZER_ADAID, USR_AMW_MEETING_REGISTER obj, int foreigner, int report)
    {
        try
        {
            List<PRC_USR_AMW_MEETING_REGISTER_SEARCHResult> result = new List<PRC_USR_AMW_MEETING_REGISTER_SEARCHResult>();
            result = PRC_USR_AMW_MEETING_REGISTER_SEARCH(strORGANIZER_ADAID, obj.PAXID, obj.DISTRICTID, obj.PROVINCEID, obj.MEETINGTYPEID, obj.STATUS_MEETING_REGISTERID, foreigner, report).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADAResult Meeting_CheckQuota(string strADA, int paxId, int districtId)
    {
        try
        {
            PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADAResult result = new PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADAResult();
            result = PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADA(strADA, paxId, districtId).SingleOrDefault();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_USERIDResult Meeting_CheckQuota_ByUserId(int UserId, int paxId, int districtId)
    {
        try
        {
            PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_USERIDResult result = new PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_USERIDResult();
            result = PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_USERID(UserId, paxId, districtId).SingleOrDefault();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public V2_PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADAResult Meeting_CheckQuota_V2(string strADA, int paxId)
    {
        try
        {
            V2_PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADAResult result = new V2_PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADAResult();
            result = V2_PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADA(strADA, paxId).SingleOrDefault();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADA_PROVINCEResult Meeting_CheckQuota_Province(string strADA, int paxId, int provinceId)
    {
        try
        {
            PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADA_PROVINCEResult result = new PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADA_PROVINCEResult();
            result = PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADA_PROVINCE(strADA, paxId, provinceId).SingleOrDefault();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_USERID_PROVINCEResult Meeting_CheckQuota_ByUserId_Province(int UserId, int paxId, int provinceId)
    {
        try
        {
            PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_USERID_PROVINCEResult result = new PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_USERID_PROVINCEResult();
            result = PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_USERID_PROVINCE(UserId, paxId, provinceId).SingleOrDefault();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADA_NOTSUPPORTCOSTResult Meeting_CheckQuota_NotSupportCost(string strADA, int paxId)
    {
        try
        {
            PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADA_NOTSUPPORTCOSTResult result = new PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADA_NOTSUPPORTCOSTResult();
            result = PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADA_NOTSUPPORTCOST(strADA, paxId).SingleOrDefault();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

   
    public PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADA_OUTSIDEResult Meeting_CheckQuota_OutSide(int userId, int paxId)
    {
        try
        {
            PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADA_OUTSIDEResult result = new PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADA_OUTSIDEResult();
            result = PRC_USR_AMW_USER_DISTRIBUTOR_CHECKBY_ADA_OUTSIDE(userId, paxId).SingleOrDefault();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public int MeetingGet_ConditionCombine(int paxId, int provinceId)
    {
        try
        {
            PRC_SYS_AMW_POLICY_GETCONDITIONCOMBINEDResult result = new PRC_SYS_AMW_POLICY_GETCONDITIONCOMBINEDResult();
            result = PRC_SYS_AMW_POLICY_GETCONDITIONCOMBINED(paxId, provinceId).SingleOrDefault();
            return result.CONDITIONCOMBINED;
        }
        catch (Exception ex)
        {
            return 0;
        }
    }
    public int MeetingCheckRule(int userId, int meetingTypeId)
    {
        try
        {
            return PRC_USR_AMW_RULE_CHECK(userId, meetingTypeId);
        }
        catch (Exception ex)
        {
            return 0;
        }
    }
    public int MeetingGet_ConditionCombine_NotSupportCost(int paxId, int userTypeId)
    {
        try
        {
            PRC_SYS_AMW_POLICY_NOTSUPPORTCOST_GETCONDITIONCOMBINEDResult result = new PRC_SYS_AMW_POLICY_NOTSUPPORTCOST_GETCONDITIONCOMBINEDResult();
            result = PRC_SYS_AMW_POLICY_NOTSUPPORTCOST_GETCONDITIONCOMBINED(paxId, userTypeId).SingleOrDefault();
            return result.CONDITIONCOMBINED;
        }
        catch (Exception ex)
        {
            return 0;
        }
    }

    public int MeetingGet_MaxPayment(int paxId, int usertypeId)
    {
        try
        {
            return  PRC_SYS_AMW_MAX_PAYMENT_GETMAX(paxId, usertypeId);
        }
        catch (Exception ex)
        {
            return 0;
        }
    }

    public PRC_USR_AMW_MEETING_REGISTER_GETLISTBYIDResult MeetingGet_ListByID(int Id)
    {
        try
        {
            PRC_USR_AMW_MEETING_REGISTER_GETLISTBYIDResult result = new PRC_USR_AMW_MEETING_REGISTER_GETLISTBYIDResult();
            result = PRC_USR_AMW_MEETING_REGISTER_GETLISTBYID(Id).SingleOrDefault();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public List<PRC_USR_AMW_MEETING_REGISTER_GETLISTBYUSERIDResult> MeetingGet_ListByUserID(int Id)
    {
        try
        {
            List<PRC_USR_AMW_MEETING_REGISTER_GETLISTBYUSERIDResult> result = new List<PRC_USR_AMW_MEETING_REGISTER_GETLISTBYUSERIDResult>();
            result = PRC_USR_AMW_MEETING_REGISTER_GETLISTBYUSERID(Id).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

}