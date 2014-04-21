using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

/// <summary>
/// Summary description for DepartmentBO
/// </summary>
public class DepartmentBO : AMW_MEETINGDataContext
{
    public DepartmentBO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int DepInsert(SYS_AMW_DEPARTMENT objDep)
    {
        try
        {
            SYS_AMW_DEPARTMENT Dep = new SYS_AMW_DEPARTMENT();
            Dep = objDep;
           return PRC_SYS_AMW_DEPARTMENT_INSERT(Dep.DEPARTMENTNAME, Dep.DESCRIPTION,Dep.ACTIVE);
            
        }
        catch
        {
            return -1;
        }
    }

    public bool DepUpdate(SYS_AMW_DEPARTMENT objDep)
    {
        try
        {
            SYS_AMW_DEPARTMENT Dep = new SYS_AMW_DEPARTMENT();
            Dep = objDep;
            int result = PRC_SYS_AMW_DEPARTMENT_UPDATE(Dep.ID, Dep.DEPARTMENTNAME, Dep.DESCRIPTION, Dep.ACTIVE);
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
    public List<PRC_SYS_AMW_DEPARTMENT_GETLISTBYIDResult> DepGetListByID(int ID)
    {
        try
        {
            List<PRC_SYS_AMW_DEPARTMENT_GETLISTBYIDResult> result = new List<PRC_SYS_AMW_DEPARTMENT_GETLISTBYIDResult>();
            result = PRC_SYS_AMW_DEPARTMENT_GETLISTBYID(ID).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public List<PRC_SYS_AMW_DEPARTMENT_SEARCHResult> DepGet_Search(SYS_AMW_DEPARTMENT objDep)
    {
        try
        {
            List<PRC_SYS_AMW_DEPARTMENT_SEARCHResult> result = new List<PRC_SYS_AMW_DEPARTMENT_SEARCHResult>();
            result = PRC_SYS_AMW_DEPARTMENT_SEARCH(objDep.DEPARTMENTNAME, objDep.DESCRIPTION, objDep.ACTIVE).ToList();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

}