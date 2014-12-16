using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;


public class CategoryBO: AMW_BookingDataContext
{
	public CategoryBO()
	{

	}

    public List<SP_CITY_GET_CBOResult> GetCity()
    {
        List<SP_CITY_GET_CBOResult> result = new List<SP_CITY_GET_CBOResult>();
        result = SP_CITY_GET_CBO().ToList();
        return result;
    }

    public List<SP_CENTER_GET_CBO_BY_CITYCODEResult> GetCenter(string CityCode)
    {
        List<SP_CENTER_GET_CBO_BY_CITYCODEResult> result = new List<SP_CENTER_GET_CBO_BY_CITYCODEResult>();
        result = SP_CENTER_GET_CBO_BY_CITYCODE(CityCode).ToList();
        return result;
    }

    public List<SP_ROOM_GET_CBO_BY_CENTERCODEResult> GetRoom(string CenterCode)
    {
        List<SP_ROOM_GET_CBO_BY_CENTERCODEResult> result = new List<SP_ROOM_GET_CBO_BY_CENTERCODEResult>();
        result = SP_ROOM_GET_CBO_BY_CENTERCODE(CenterCode).ToList();
        return result;
    }

    public List<SP_GET_ROOMLIST_BY_CITYCODEResult> GetRoomByCityCode(String CityCode)
    {
        return SP_GET_ROOMLIST_BY_CITYCODE(CityCode).ToList();
    }

    public List<SP_GET_CITYNAME_BY_CITYCODEResult> GetCityNameByCityCode(String CityCode)
    {
        return SP_GET_CITYNAME_BY_CITYCODE(CityCode).ToList();
    }

    public List<SP_GET_ROOM_BY_ROOMCODEResult> GetRoomByRoomCode(String RoomCode)
    {
        return SP_GET_ROOM_BY_ROOMCODE(RoomCode).ToList();
    }

    public List<SP_GET_INFORMATIONResult> GetInformation()
    {
        return SP_GET_INFORMATION().ToList();
    }
}