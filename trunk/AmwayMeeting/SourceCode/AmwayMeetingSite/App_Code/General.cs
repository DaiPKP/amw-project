﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Configuration;
using System.Text;

/// <summary>
/// Summary description for General
/// </summary>
public class General
{
    public General()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static string EncryptPassword(string strPassword)
    {
        try
        {
            Byte[] clearBytes = new System.Text.UnicodeEncoding().GetBytes(strPassword);
            Byte[] hashedBytes = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(clearBytes);
            hashedBytes = ((HashAlgorithm)CryptoConfig.CreateFromName("SHA1")).ComputeHash(hashedBytes);

            return BitConverter.ToString(hashedBytes);
        }
        catch (Exception ex)
        {
            return string.Empty;
        }
    }
    public static void SetLicenseForAspose()
    {
        Aspose.Cells.License licCell = new Aspose.Cells.License();
        try
        {
            licCell.SetLicense("Aspose.Cells.lic");
        }
        catch (Exception ex)
        {
            //do ex
        }
    }
    public static string DateTimeName()
    {


        return DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();

    }
    public static bool SendMail(MailMessage mail)
    {
        try
        {
            string host = ConfigurationSettings.AppSettings["SmtpServer"].ToString();
            string password = ConfigurationSettings.AppSettings["ContactPass"].ToString();
            string userEmail = ConfigurationSettings.AppSettings["ContactEmail"].ToString();
            mail.From = new MailAddress(userEmail, "IT Dai Truong Phat");
            SmtpClient emailClient = new SmtpClient();
            System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(userEmail, password);
            emailClient.UseDefaultCredentials = false;
            emailClient.Credentials = SMTPUserInfo;
            emailClient.Port = 587;
            emailClient.Host = host;
            emailClient.EnableSsl = true;
            emailClient.Send(mail);

            return true;
        }
        catch (System.Exception ex)
        {
            return false;
        }
    }

}