using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

/// <summary>
/// Summary description for DepartmentBO
/// </summary>
public class DepartmentBO : AMW_BookingDataContext
{
    public DepartmentBO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    
    public List<PRC_SYS_AMW_DEPARTMENT_CBOResult> DepGet_CBO()
    {
        try
        {
            List<PRC_SYS_AMW_DEPARTMENT_CBOResult> result = new List<PRC_SYS_AMW_DEPARTMENT_CBOResult>();
            result = PRC_SYS_AMW_DEPARTMENT_CBO().ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
   

}