using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

/// <summary>
/// Summary description for RegistryRoomBO
/// </summary>
public class RegistryRoomBO:AMW_BookingDataContext
{
	public RegistryRoomBO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int InsertWeeklyBooking(string DSdatetimeValue,  RegistryRoom refRoom)
    {
        return sp_weekly_booking(DSdatetimeValue,refRoom.ADA_ID, refRoom.ADA_Name, refRoom.Phone, refRoom.Email, refRoom.Address, refRoom.RoomCode, refRoom.Type, refRoom.Paid, refRoom.Weekend, refRoom.Section, refRoom.Note);
    }
    public int InsertMonthlyBooking(string DSdatetimeValue, string DSsetion, RegistryRoom refRoom)
    {
        return sp_monthly_booking(DSdatetimeValue,DSsetion, refRoom.ADA_ID, refRoom.ADA_Name, refRoom.Phone, refRoom.Email, refRoom.Address, refRoom.RoomCode, refRoom.Type, refRoom.Paid, refRoom.Note);
    }

    public List<SP_REGISTYROOM_GETLISTResult> GetListBooking(string RoomCode, DateTime FromDate, DateTime ToDate)
    {
        List<SP_REGISTYROOM_GETLISTResult> result = new List<SP_REGISTYROOM_GETLISTResult>();
        result = SP_REGISTYROOM_GETLIST(RoomCode, FromDate, ToDate).ToList();
        return result;
    }

    public List<SP_REGISTYROOM_GET_BY_CODEResult> GetBookingByCode(int Code)
    {
        List<SP_REGISTYROOM_GET_BY_CODEResult> result = new List<SP_REGISTYROOM_GET_BY_CODEResult>();
        result = SP_REGISTYROOM_GET_BY_CODE(Code).ToList();
        return result;
    }

    public int InsertBooking(RegistryRoom refRoom)
    {
        return sp_registry_room(refRoom.ADA_ID, refRoom.ADA_Name, refRoom.Phone, refRoom.Email, refRoom.Address, refRoom.RoomCode, refRoom.Date, refRoom.Section, refRoom.Type, refRoom.Weekend, refRoom.Paid, refRoom.Note);
    }

    public void UpdateBooking(RegistryRoom refRoom)
    {
        sp_update_registry_room(refRoom.Code, refRoom.ADA_ID, refRoom.ADA_Name, refRoom.Phone, refRoom.Email, refRoom.Address, refRoom.Status, refRoom.Paid, refRoom.Note);
    }

    public List<SP_REGISTYROOM_GET_BY_BOOKINGCODEResult> SearchBooking(string BookingCode, string RoomCode, string ADAID, string PaymentStatus, string BookingStatus)
    {
        return SP_REGISTYROOM_GET_BY_BOOKINGCODE(BookingCode, RoomCode, ADAID,char.Parse(PaymentStatus), char.Parse(BookingStatus)).ToList();
    }

    public string UpdateBookingStatus(int Code, string BookingStatus, string PaymentStatus)
    {
        int resutlt = SP_REGISTYROOM_UPDATE_PAYMENT_STATUS(Code, char.Parse(BookingStatus), char.Parse(PaymentStatus));
        if (resutlt == 1)
        {
            return "Mã đặt phòng này không tồn tại.";
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