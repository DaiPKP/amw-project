﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Distributor_Room : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["UserID"] == null) || (Session["ADA"] == null) || (!CheckPermission("48")))
        {
            Response.Redirect("~/home");
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