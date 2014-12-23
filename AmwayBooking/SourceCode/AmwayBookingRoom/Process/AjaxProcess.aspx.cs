using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Configuration;
using DAL;


using System.Text;
public partial class Process_AjaxProcess : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


    }
    [System.Web.Services.WebMethod]
    public static bool LoginUser(string username, string password)
    {
        try
        {
            Process_AjaxProcess objPro = new Process_AjaxProcess();
            return objPro.CheckLoginUserCallByAjax(username, password);
        }
        catch (Exception)
        {

            return false;
        }

    }
    

    [System.Web.Services.WebMethod]
    public static bool ChangePass(string oldpass, string newpass, string renewpass)
    {
        try
        {
            Process_AjaxProcess objPro = new Process_AjaxProcess();
            bool result= objPro.ChangePassCallByAjax(oldpass, newpass, renewpass);
            objPro.RemoveSessionCallByAjax("UserID");
            return result;
        }
        catch (Exception)
        {

            return false;
        }
    }
    [System.Web.Services.WebMethod]
    public static bool RemoveSession()
    {
        try
        {
            Process_AjaxProcess objPro = new Process_AjaxProcess();
            objPro.RemoveSessionCallByAjax("Permission");
            return objPro.RemoveSessionCallByAjax("UserID");

        }
        catch (Exception)
        {

            return false;
        }

    }
    

    private bool CheckLoginUserCallByAjax(string username, string password)
    {
        try
        {
            UserBO objAcc = new UserBO();
            PRC_SYS_AMW_USER_GETLISTResult result = new PRC_SYS_AMW_USER_GETLISTResult();
            result = objAcc.UserGetList(username, General.EncryptPassword(password));
            if (result != null)
            {
                Session["UserID"] = result.USERID;
                Session.Timeout = 60;
                return true;
            }

            else
            {
                return false;
            }
        }
        catch (Exception)
        {

            return false;
        }

    }
    public bool RemoveSessionCallByAjax(string name)
    {
        try
        {
            Session[name] = null;
            return true;
        }
        catch (Exception)
        {

            return false;
        }

    }
    private bool ChangePassCallByAjax(string oldpass, string newpass, string renewpass)
    {
        try
        {
            if (newpass == renewpass)
            {
                UserBO objAcc = new UserBO();
                return objAcc.UserChangePass(int.Parse(Session["UserID"].ToString()), General.EncryptPassword(oldpass), General.EncryptPassword(newpass));

            }
            else
            {
                return false;
            }

        }
        catch (Exception)
        {

            return false;
        }

    }

}