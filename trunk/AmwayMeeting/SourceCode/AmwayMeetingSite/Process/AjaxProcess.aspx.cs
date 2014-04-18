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
    public static bool CheckEmail(string email)
    {
        try
        {
            UserBO rsAcc = new UserBO();
            return rsAcc.UserCheckEmail(email);

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
    [System.Web.Services.WebMethod]
    public static bool SendMail(string email)
    {
        try
        {
            UserBO objAcc = new UserBO();
            Random rand = new Random();
            string pass ="DTP@"+rand.Next(1000, 9999).ToString();
            if (objAcc.UserUpdatePasswordByEmail(email, General.EncryptPassword(pass)))
            {
                Process_AjaxProcess objPro = new Process_AjaxProcess();
                return objPro.SendMailForgetPassword(email, pass,ConfigurationManager.AppSettings["AbsoluteUri"]+"home/");
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
    private bool SendMailForgetPassword(string email, string Pass, string website)
    {
        try
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.SubjectEncoding = Encoding.UTF8;
            mail.BodyEncoding = Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.From = new MailAddress(ConfigurationManager.AppSettings["ContactEmail"].ToString(), "IT DAI TRUONG PHAT");
            mail.Subject = "[DTP] Thông tin mật khẩu mới!";

            using (System.IO.StreamReader reader = new System.IO.StreamReader(Server.MapPath("~/Email/QuenMatKhau.html")))
            {
                mail.Body = reader.ReadToEnd();
                mail.Body = mail.Body.Replace("##password##", Pass);
                mail.Body = mail.Body.Replace("##ActiveUrl##", website);
            }
            return General.SendMail(mail);
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
            SYS_AMW_USER objUser = new SYS_AMW_USER();
            UserBO objAcc = new UserBO();
            objUser.ADA = username;
            objUser.PASSWORD = General.EncryptPassword(password);
            PRC_SYS_AMW_USER_GETLISTResult result = new PRC_SYS_AMW_USER_GETLISTResult();
            result = objAcc.UserGetList(objUser);
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