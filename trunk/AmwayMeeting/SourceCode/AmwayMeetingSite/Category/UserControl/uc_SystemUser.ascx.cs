using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class Category_UserControl_uc_SystemUser : System.Web.UI.UserControl
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
        SYS_AMW_USER_SYSTEM obj = new SYS_AMW_USER_SYSTEM();
        obj.USERSYSTEMNAME = string.Empty;
        obj.DESCRIPTION = string.Empty;
        obj.ACTIVE = chkActive.Checked;
        DisplaySystemInGrid(obj);
    }

    private void ClearTextBox()
    {

        hdfSystemId.Value = "-1";
        txtSystemName.Text = string.Empty;
        txtDescription.Text = string.Empty;
        chkActive.Checked = true;
        btnSave.Text = "Thêm mới";
        lblAlerting.Text = string.Empty;
    }
    protected void DisplaySystemInGrid(SYS_AMW_USER_SYSTEM obj)
    {
        CategoryBO objBO = new CategoryBO();
        List<PRC_SYS_AMW_USER_SYSTEM_SEARCHResult> lst = new List<PRC_SYS_AMW_USER_SYSTEM_SEARCHResult>();
        lst = objBO.User_SystemGet_Search(obj).ToList();
        grdList.DataSource = lst;
        if (lst.Count > 0)
        {
            grdList.PageIndex = 0;
        }
        grdList.DataBind();
    }    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        hdfSystemId.Value = "-1";
        lblAlerting.Text = string.Empty;
        LoadGrid();

    }
    protected void grdList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblAlerting.Text = string.Empty;
        btnSave.Text = "Cập nhật";
        grdList.EditIndex = e.NewEditIndex;
        hdfSystemId.Value = grdList.DataKeys[e.NewEditIndex].Value.ToString();
        string strSystemName = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingSystemName")).Text;
        string strDescription = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingDescription")).Text;
        bool Active = bool.Parse(((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingActive")).Text);

        // Bind len control
        txtSystemName.Text = strSystemName;
        txtDescription.Text = strDescription;
        chkActive.Checked = Active;

    }
    protected void btnXoaTrang_Click(object sender, EventArgs e)
    {
        ClearTextBox();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtSystemName.Text.Trim().Length <= 0)
        {
            lblAlerting.Text = "Bạn chưa nhập tên hệ thống!";
            return;
        }

        // Thuc hien Insert Update
        SYS_AMW_USER_SYSTEM obj = new SYS_AMW_USER_SYSTEM();
        obj.ID = int.Parse(hdfSystemId.Value);
        obj.USERSYSTEMNAME = txtSystemName.Text.Trim();
        obj.DESCRIPTION = txtDescription.Text.Trim();
        obj.ACTIVE = chkActive.Checked;

        obj.CREATEUSER = int.Parse(Session["UserID"].ToString());
        obj.UPDATEUSER = int.Parse(Session["UserID"].ToString());

        CategoryBO objBO = new CategoryBO();
        if (int.Parse(hdfSystemId.Value) <= 0)
        {
            hdfSystemId.Value = objBO.User_SystemInsert(obj).ToString();
            if (int.Parse(hdfSystemId.Value) > 0)
            {
                btnSave.Text = "Cập nhật";
                lblAlerting.Text = "Thêm mới hệ thống thành công!";
            }
            else
            {
                lblAlerting.Text = "Thêm mới hệ thống thất bại, bạn vui lòng thử lại!";
            }
        }
        else
            if (objBO.User_SystemUpdate(obj))
            {
                //btnSave.Text = "Cập nhật";
                lblAlerting.Text = "Cập nhật hệ thống thành công!";
            }
            else
            {
                lblAlerting.Text = "Cập nhật hệ thống thất bại, bạn vui lòng thử lại!";
            }
        LoadGrid();

    }
    private void LoadGrid()
    {
        SYS_AMW_USER_SYSTEM obj = new SYS_AMW_USER_SYSTEM();
        obj.USERSYSTEMNAME = txtSystemName.Text.Trim();
        obj.DESCRIPTION = txtDescription.Text.Trim();
        obj.ACTIVE = chkActive.Checked;
        DisplaySystemInGrid(obj);

    }


    protected void grdList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        LoadGrid();
        grdList.PageIndex = e.NewPageIndex;
        grdList.DataBind();
    }
}