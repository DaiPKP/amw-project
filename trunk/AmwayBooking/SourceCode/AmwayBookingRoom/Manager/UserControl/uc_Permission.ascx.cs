using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class Manager_UserControl_uc_Permission : System.Web.UI.UserControl
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
        ClearTextBox();
    }

    private void ClearTextBox()
    {
        GetDepartmentCBO();
        ddlDEPARTMENTID.SelectedValue = "0";
        lblAlerting.Text = string.Empty;
    }
    protected void DisplayPermissionInGrid()
    {
        MenuBO menu = new MenuBO();
        List<PRC_SYS_AMW_MENU_GETPERMISSIONResult> lst = new List<PRC_SYS_AMW_MENU_GETPERMISSIONResult>();

        if (int.Parse(ddlDEPARTMENTID.SelectedValue) > 0)
        {
            lst = menu.Menu_Get_Permission(int.Parse(ddlDEPARTMENTID.SelectedValue));
            repPermissionList.DataSource = lst;
            repPermissionList.DataBind();
        }
        else
        {
            repPermissionList.DataSource = lst;
            repPermissionList.DataBind();
        }
    }
    protected void DisplayPermissionDetailInGrid()
    {
        MenuBO menu = new MenuBO();
        foreach (RepeaterItem item in repPermissionList.Items)
        {
            string MENUCHAID = ((HiddenField)item.FindControl("hdfMenuChaID")).Value;

            List<PRC_SYS_AMW_MENU_PERMISSION_GETCHILD_BY_MENUIDResult> lst = new List<PRC_SYS_AMW_MENU_PERMISSION_GETCHILD_BY_MENUIDResult>();
            lst = menu.Menu_Get_Permission_Detail(int.Parse(MENUCHAID), int.Parse(ddlDEPARTMENTID.SelectedValue));
            Repeater repPermissionDetail = (Repeater)item.FindControl("repPermissionDetail");
            repPermissionDetail.DataSource = lst;
            repPermissionDetail.DataBind();
        }

    }
    private void GetDepartmentCBO()
    {
        try
        {
            DepartmentBO objBO = new DepartmentBO();
            List<DAL.PRC_SYS_AMW_DEPARTMENT_CBOResult> lst = new List<DAL.PRC_SYS_AMW_DEPARTMENT_CBOResult>();
            lst = objBO.DepGet_CBO();
            if (lst != null)
            {
                ddlDEPARTMENTID.DataSource = lst;
                ddlDEPARTMENTID.DataTextField = "DEPARTMENTNAME";
                ddlDEPARTMENTID.DataValueField = "ID";
                ddlDEPARTMENTID.DataBind();

                ListItem lstParent = new ListItem("--Chọn--", "0");
                ddlDEPARTMENTID.Items.Insert(0, lstParent);
                ddlDEPARTMENTID.SelectedIndex = ddlDEPARTMENTID.Items.IndexOf(lstParent);
            }
        }
        catch
        {
        }
    }

    protected void btnXoaTrang_Click(object sender, EventArgs e)
    {
        ClearTextBox();
        DisplayPermissionInGrid();
        DisplayPermissionDetailInGrid();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string DSMenuID = string.Empty;
        if (int.Parse(ddlDEPARTMENTID.SelectedValue) <= 0)
        {
            lblAlerting.Text = "Bạn chưa chọn nhóm người dùng!";
            return;
        }
        if (repPermissionList.Items.Count <= 0)
        {
            lblAlerting.Text = "Bạn chưa chọn chức năng cho nhóm người dùng này!";
            return;
        }
        if (repPermissionList.Items.Count <= 0)
        {
            lblAlerting.Text = "Bạn chưa chọn chức năng cho nhóm người dùng này!";
            return;
        }
        
        // thuc hien giao tac get tat cac cac MenuID dc check
        MenuBO menu = new MenuBO();

        foreach (RepeaterItem item in repPermissionList.Items)
        {
            Repeater repPermissionDetail = (Repeater)item.FindControl("repPermissionDetail");
            foreach (RepeaterItem it in repPermissionDetail.Items)
            {
                bool checkvalue = ((CheckBox)it.FindControl("chkSelectMenu")).Checked;
                if (checkvalue)
                {
                    DSMenuID += ((HiddenField)it.FindControl("hdfMenuID")).Value + "@";
                }
            }
        }
        // thuc hien save 
        int result = menu.Menu_Properties_Insert(int.Parse(ddlDEPARTMENTID.SelectedValue), DSMenuID);
        if (result > 0)
        {
            lblAlerting.Text = "Lưu thành công!";
        }
        else
        {
            lblAlerting.Text = "Lưư thất bại!";
        }

        DisplayPermissionInGrid();
        DisplayPermissionDetailInGrid();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DisplayPermissionInGrid();
        DisplayPermissionDetailInGrid();
    }
}