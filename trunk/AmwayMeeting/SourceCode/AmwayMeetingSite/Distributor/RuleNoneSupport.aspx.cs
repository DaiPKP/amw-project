using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Distributor_RuleNoneSupport : System.Web.UI.Page
{
    public int iUserID, iRuleID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (!IsPostBack)
            {
                iUserID = int.Parse(Session["UserID"].ToString());
                iRuleID = 1;
                if (!(CheckRegister(1)))
                {
                    btnSave.Visible = true;
                    btn_registry_foregner.Visible = false;
                    btn_registy_vn.Visible = false;
                }
                else
                {
                    btnSave.Visible = false;
                    btn_registry_foregner.Visible = true;
                    btn_registy_vn.Visible = true;
                    chkConfirm.Checked = true;
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
                    lbMess.Text = "Bạn đã đăng ký qui định thành công";
                    btnSave.Visible = true;
                    btn_registry_foregner.Visible = true;
                    btn_registy_vn.Visible = true;
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
    protected void btn_registry_foregner_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/meeting/NotSupportCostForeigner.aspx");
    }
    protected void btn_registy_vn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/meeting/NotSupportCost.aspx");
    }
}