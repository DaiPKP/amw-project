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

    public List<SP_GET_REGISTRYROOM_REPORTResult> GetRegistryRoomReport(DateTime FromDate, DateTime ToDate)
    {
        return SP_GET_REGISTRYROOM_REPORT(FromDate, ToDate).ToList();
    }

    public List<SP_GET_REGISTRYROOM_USED_REPORTResult> GetRegistryRoomUsedReport(DateTime FromDate, DateTime ToDate)
    {
        return SP_GET_REGISTRYROOM_USED_REPORT(FromDate, ToDate).ToList();
    }

    //City Action
    
    public List<SP_CITY_SEARCHResult> CitySearch(City refCity)
    {
        return SP_CITY_SEARCH(refCity.CityCode, refCity.CityName, refCity.Status).ToList();
    }

    public string CityInsert(City refCity)
    {
        int resutlt = SP_CITY_INSERT(refCity.CityCode, refCity.CityName, refCity.Status);
        if(resutlt == 1)
        {
            return "Mã thành phố này đã được sử dụng trước đó, vui lòng chọn mã khác.";
        }
        else if(resutlt == 2)
        {
            return "Thêm mới thành phố thành công.";
        }
        else
        {
            return "Thêm mới thành phố thất bại, vui lòng thử lại.";
        }
    }

    public string CityUpdate(City refCity)
    {
        int resutlt = SP_CITY_UPDATE(refCity.CityCode, refCity.CityName, refCity.Status);
        if (resutlt == 1)
        {
            return "Mã thành phố này chưa có, vui lòng tạo mới.";
        }
        else if (resutlt == 2)
        {
            return "Cập nhật thành công.";
        }
        else
        {
            return "Cập nhật thất bại, vui lòng thử lại.";
        }
    }

    //Center Action

    public List<SP_CENTER_SEARCHResult> CenterSearch(Center refCenter)
    {
        return SP_CENTER_SEARCH(refCenter.CenterCode, refCenter.CityCode, refCenter.CenterName, refCenter.Status).ToList();
    }

    public string CenterInsert(Center refCenter)
    {
        int resutlt = SP_CENTER_INSERT(refCenter.CenterCode, refCenter.CityCode, refCenter.CenterName, refCenter.Address, refCenter.Status);
        if (resutlt == 1)
        {
            return "Mã trung tâm này đã được sử dụng trước đó, vui lòng chọn mã khác.";
        }
        else if (resutlt == 2)
        {
            return "Thêm mới trung tâm thành công.";
        }
        else
        {
            return "Thêm mới trung tâm thất bại, vui lòng thử lại.";
        }
    }

    public string CenterUpdate(Center refCenter)
    {
        int resutlt = SP_CENTER_UPDATE(refCenter.CenterCode, refCenter.CityCode, refCenter.CenterName, refCenter.Address, refCenter.Status);
        if (resutlt == 1)
        {
            return "Mã trung tâm này chưa có, vui lòng tạo mới.";
        }
        else if (resutlt == 2)
        {
            return "Cập nhật thành công.";
        }
        else
        {
            return "Cập nhật thất bại, vui lòng thử lại.";
        }
    }

    //Room Action

    public List<SP_ROOM_SEARCHResult> RoomSearch(Room refRoom)
    {
        return SP_ROOM_SEARCH(refRoom.RoomCode, refRoom.CenterCode, refRoom.RoomName, refRoom.Status).ToList();
    }

    public string RoomInsert(Room refRoom)
    {
        int resutlt = SP_ROOM_INSERT(refRoom.RoomCode, refRoom.CenterCode, refRoom.RoomName, refRoom.Amount, refRoom.PriceMorning, refRoom.PriceAfternoon, refRoom.PriceEvening, refRoom.PriceWeekendMorning, refRoom.PriceWeekendAfternoon, refRoom.PriceWeekendEvening, refRoom.PriceBookingMonthly, refRoom.Status);
        if (resutlt == 1)
        {
            return "Mã phòng họp này đã được sử dụng trước đó, vui lòng chọn mã khác.";
        }
        else if (resutlt == 2)
        {
            return "Thêm mới phòng họp thành công.";
        }
        else
        {
            return "Thêm mới phòng họp thất bại, vui lòng thử lại.";
        }
    }

    public string RoomUpdate(Room refRoom)
    {
        int resutlt = SP_ROOM_UPDATE(refRoom.RoomCode, refRoom.CenterCode, refRoom.RoomName, refRoom.Amount, refRoom.PriceMorning, refRoom.PriceAfternoon, refRoom.PriceEvening, refRoom.PriceWeekendMorning, refRoom.PriceWeekendAfternoon, refRoom.PriceWeekendEvening, refRoom.PriceBookingMonthly, refRoom.Status);
        if (resutlt == 1)
        {
            return "Mã phòng họp này chưa có, vui lòng tạo mới.";
        }
        else if (resutlt == 2)
        {
            return "Cập nhật thành công.";
        }
        else
        {
            return "Cập nhật thất bại, vui lòng thử lại.";
        }
    }
}