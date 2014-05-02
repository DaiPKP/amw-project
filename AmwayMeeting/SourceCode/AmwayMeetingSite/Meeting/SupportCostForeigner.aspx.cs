using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Meeting_SupportCostForeigner : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["UserID"] == null) || (!CheckPermission("27")) || (!CheckRegister(2)))
        {
            Response.Redirect("~/home");
        }
        else
        {
            if (!(CheckRegister(2)))
            {
                Response.Redirect("../distributor/rulesupport");
            }
            else
            {

                int id = Convert.ToInt32(HttpContext.Current.Items["id"]);

                uc_SupportCostForeigner1._ID = id;
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