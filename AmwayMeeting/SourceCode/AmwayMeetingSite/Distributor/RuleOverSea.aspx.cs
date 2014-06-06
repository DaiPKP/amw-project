using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Distributor_RuleOverSea : System.Web.UI.Page
{
    public int iUserID, iRuleID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            iUserID = int.Parse(Session["UserID"].ToString());
            iRuleID = 3;
            if (!IsPostBack)
            {

                if (!(CheckRegister(3)))
                {
                    btnSave.Visible = true;
                    btn_registy_oversea.Visible = false;
                    chkConfirm.Checked = false;
                    chkConfirm.Enabled = true;
                }
                else
                {
                    btnSave.Visible = false;
                    btn_registy_oversea.Visible = true;
                    chkConfirm.Checked = true;
                    chkConfirm.Enabled = false;
                }
            }
        }
        else
        {
            Response.Redirect("~/home");
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (chkConfirm.Checked == false)
            {
                lbMess.Text = "Vui lòng xác nhận bạn đã đọc và hiểu qui định";
            }
            else
            {
                RegisterRuleBO registry = new RegisterRuleBO();
                int result = registry.InsertRegisterRule(iUserID, iRuleID);
                if (result == 1)
                {
                    RedirectTo("../meeting/outsidecountry");
                }
                else
                {
                    lbMess.Text = "Bạn đăng ký qui định thất bại";
                }
            }
        }
        catch (Exception ex)
        {
            lbMess.Text = "Bạn đăng ký qui định thất bại";
        }
    }
    private void RedirectTo(string url)
    {

        string redirectURL = Page.ResolveClientUrl(url);

        string script = "window.location = '" + redirectURL + "';";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "RedirectTo", script, true);

    }    
    protected void btn_registy_oversea_Click(object sender, EventArgs e)
    {
          RedirectTo("../meeting/outsidecountry");
    }
}