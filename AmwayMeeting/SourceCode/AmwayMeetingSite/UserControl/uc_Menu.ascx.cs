using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_uc_Menu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitData();
        }
    }
    private void InitData()
    {
        if (Session["UserID"] != null)
        {
            //get menu cua User nay
            MenuBO menu = new MenuBO();
            List<DAL.PRC_SYS_AMW_MENUPARENT_GETBY_USERIDResult> result = new List<DAL.PRC_SYS_AMW_MENUPARENT_GETBY_USERIDResult>();
            result = menu.Menu_GetParentBy_UserID(int.Parse(Session["UserID"].ToString()));
            repMenuParent.DataSource = result;
            repMenuParent.DataBind();

            // get data off menu con
            GetMenuChild();
        }

    }
    private void GetMenuChild()
    {
        //tao ra 1 session chua quyen
        // if (Session["Permission"] 
        string strQuyen="";      
        MenuBO menu = new MenuBO();
        foreach (RepeaterItem item in repMenuParent.Items)
        {
            string MSMENU = ((HiddenField)item.FindControl("hdfMenuParent")).Value;
            string GroupMenu = ((HiddenField)item.FindControl("hdfGroupMenu")).Value;
            List<DAL.PRC_SYS_AMW_MENU_GETBY_USERID_AND_MENUPARENTIDResult> resultChild = new List<DAL.PRC_SYS_AMW_MENU_GETBY_USERID_AND_MENUPARENTIDResult>();
            resultChild = menu.Menu_GetBy_UserIDAndMenuParentId(int.Parse(Session["UserID"].ToString()), int.Parse(MSMENU));

            Repeater repMenu = (Repeater)item.FindControl("repMenu");
            repMenu.DataSource = resultChild;
            repMenu.DataBind();
            if(resultChild!=null && resultChild.Count>0)
            {
                for (int i = 0; i < resultChild.Count; i++)
                {
                     strQuyen += resultChild[i].ID + ",";
                }
            }
        }
        Session["Permission"] = strQuyen.Substring(0, strQuyen.Length-1);
        Session.Timeout = 60;
    }
}