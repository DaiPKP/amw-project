using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class MaterPage_Home : System.Web.UI.MasterPage
{
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
        if ((result.DEPARTMENTID==3) && (result.EMAIL == null || result.EMAIL.Length <= 0))
        {
            string script = "AlertMsgLink('Nhắc nhở','<p>* Email của bạn chưa được nhập trước đó, bạn cập nhật email','../distributor/profile');";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "RedirectTo", script, true);
        }
    }
}
