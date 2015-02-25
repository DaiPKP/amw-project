﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DAL;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public Connection con = new Connection();
    public Functions func = new Functions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserID"] != null)
            {
                getInfoUserLogin(int.Parse(Session["UserID"].ToString()));                
                divLogined.Attributes.Add("style", "display:block;");
                container.Attributes.Add("style", "display:none;");
            }
            else
            {
                divLogined.Attributes.Add("style", "display:none;");
                container.Attributes.Add("style", "display:block;");
            }
        }
    }
    private void getInfoUserLogin(int UserID)
    {
        UserBO objUser = new UserBO();
        PRC_SYS_AMW_USER_GETLISTBYUSERIDResult result = new PRC_SYS_AMW_USER_GETLISTBYUSERIDResult();
        result = objUser.UserGetListByUserID(UserID);
        lbNickName.Text = result.FULLNAME;
        
    }
}
    