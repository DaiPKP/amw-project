﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Meeting_OutSideCountry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["UserID"] == null) || (!CheckPermission("22")) || (!CheckRegister(3)))
        {
            Response.Redirect("~/home");
        }
        else
        {
            int id = Convert.ToInt32(HttpContext.Current.Items["id"]);

            uc_OutSideCountry1._ID = id;
        }

    }
    private bool CheckPermission(string func)
    {
        if (Session["Permission"] != null)
        {
            foreach (string item in Session["Permission"].ToString().Split(','))
            {
                if (item == func)
                {
                    return true;
                }
            }
            return false;
        }
        else
        {
            return false;
        }

    }
    private bool CheckRegister(int meetingTypeId)
    {

        if (Session["UserID"] != null)
        {
            MeetingBO obj = new MeetingBO();
            int result = obj.MeetingCheckRule(int.Parse(Session["UserID"].ToString()), meetingTypeId);
            if (result > 0)
                return true;
            else
                return false;
        }
        else
        {
            return false;
        }

    }
}