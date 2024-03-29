﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Meeting_OutSideCountryView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["UserID"] == null) || (!CheckPermission("26")))
        {
            Response.Redirect("~/home");
        }
        else
        {
            int id = Convert.ToInt32(HttpContext.Current.Items["id"]);
            if (id<=0)
            {
                Response.Redirect("~/home");
            }
            else
            {
                uc_OutSideCountryView1._ID = id;
            }
           
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
}