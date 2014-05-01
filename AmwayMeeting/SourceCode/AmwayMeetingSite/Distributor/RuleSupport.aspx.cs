using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Distributor_RuleSupport : System.Web.UI.Page
{
    public int iUserID, iRuleID;
    protected void Page_Load(object sender, EventArgs e)
    {
        iUserID = int.Parse(Session["UserID"].ToString());
        iRuleID = 2;
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
}