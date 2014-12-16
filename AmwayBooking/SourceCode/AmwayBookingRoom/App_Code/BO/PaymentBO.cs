using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

public class PaymentBO : AMW_BookingDataContext
{
	public PaymentBO()
	{

	}

    public List<SP_GET_PAYMENTResult> GetPayment(String CityCode, String ADA_ID, DateTime FromDate, DateTime ToDate)
    {
        List<SP_GET_PAYMENTResult> result = new List<SP_GET_PAYMENTResult>();
        result = SP_GET_PAYMENT(CityCode, ADA_ID, FromDate, ToDate).ToList();
        return result;
    }
}