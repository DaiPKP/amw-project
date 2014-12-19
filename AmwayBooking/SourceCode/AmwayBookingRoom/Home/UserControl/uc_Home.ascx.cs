﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Home_UserControl_uc_Home : System.Web.UI.UserControl
{
    public Connection con = new Connection();
    public Functions func = new Functions();
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable tb = new DataTable();
        string strQuery = "SELECT * FROM [City] WHERE [Status] = 'Y'";
        tb = con.ExcuteQuery(strQuery);
        listView.DataSource = tb;
        listView.DataBind();
        strQuery = "select * from Information where [Status] = 'Y'";
        tb = con.ExcuteQuery(strQuery);
        if (tb.Rows.Count > 0)
        {
            foreach (DataRow row in tb.Rows)
            {
                if (row["Code"].ToString().Trim().Equals("LienHe"))
                {
                    lbLienHe.Text = row["Content"].ToString();
                }
            }
        }
        lbSum.Text = "  " + func.ReadXML("~/Count.xml").ToString();
        lbOnline.Text = "  " + Application.Get("demOnline").ToString();
    }
}