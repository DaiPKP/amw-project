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
}