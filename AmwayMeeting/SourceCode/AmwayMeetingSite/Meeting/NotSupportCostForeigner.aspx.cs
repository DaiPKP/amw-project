using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Meeting_NotSupportCostForeigner : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["UserID"] == null) || (!CheckPermission("28")))
        {
            Response.Redirect("~/home");
        }
        else
        {
            if (!(CheckRegister(1)))
            {
                Response.Redirect("../distributor/rulenonesupport");
            }
            else
            {
                int id = Convert.ToInt32(HttpContext.Current.Items["id"]);

                uc_NotSupportCostForeigner1._ID = id;
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