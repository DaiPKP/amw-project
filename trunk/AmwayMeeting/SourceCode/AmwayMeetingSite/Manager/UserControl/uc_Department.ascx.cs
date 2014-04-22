using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class Manager_UserControl_uc_Department : System.Web.UI.UserControl
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
        SYS_AMW_DEPARTMENT objDep = new SYS_AMW_DEPARTMENT();
        objDep.DEPARTMENTNAME = string.Empty;
        objDep.DESCRIPTION = string.Empty;
        objDep.ACTIVE = chkActive.Checked;
        DisplayDepartmentInGrid(objDep);
    }

    private void ClearTextBox()
    {

        hdfDepartmentId.Value = "-1";
        txtDepartmentName.Text = string.Empty;
        txtDescription.Text = string.Empty;
        chkActive.Checked = true;
        btnSave.Text = "Thêm mới";
        lblAlerting.Text = string.Empty;
    }
    protected void DisplayDepartmentInGrid(SYS_AMW_DEPARTMENT objDep)
    {
        DepartmentBO bphan = new DepartmentBO();
        List<PRC_SYS_AMW_DEPARTMENT_SEARCHResult> lst = new List<PRC_SYS_AMW_DEPARTMENT_SEARCHResult>();
        lst = bphan.DepGet_Search(objDep).ToList();
        grdDepartmentList.DataSource = lst;
        if (lst.Count > 0)
        {
            grdDepartmentList.PageIndex = 0;
        }
        grdDepartmentList.DataBind();
    }    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        hdfDepartmentId.Value = "-1";
        lblAlerting.Text = string.Empty;
        LoadGrid();

    }
    protected void grdDepartmentList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblAlerting.Text = string.Empty;
        btnSave.Text = "Cập nhật";
        grdDepartmentList.EditIndex = e.NewEditIndex;
        hdfDepartmentId.Value = grdDepartmentList.DataKeys[e.NewEditIndex].Value.ToString();
        string strDepartmentName = ((Label)grdDepartmentList.Rows[e.NewEditIndex].FindControl("lblListingDepartmentName")).Text;
        string strDescription = ((Label)grdDepartmentList.Rows[e.NewEditIndex].FindControl("lblListingDescription")).Text;
        bool Active = bool.Parse(((Label)grdDepartmentList.Rows[e.NewEditIndex].FindControl("lblListingActive")).Text);

        // Bind len control
        txtDepartmentName.Text = strDepartmentName;
        txtDescription.Text = strDescription;
        chkActive.Checked = Active;

    }
    protected void btnXoaTrang_Click(object sender, EventArgs e)
    {
        ClearTextBox();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtDepartmentName.Text.Trim().Length <= 0)
        {
            lblAlerting.Text = "Bạn chưa nhập tên nhóm người dùng!";
            return;
        }

        // Thuc hien Insert Update
        SYS_AMW_DEPARTMENT objDep = new SYS_AMW_DEPARTMENT();
        objDep.ID = int.Parse(hdfDepartmentId.Value);
        objDep.DEPARTMENTNAME = txtDepartmentName.Text.Trim();
        objDep.DESCRIPTION = txtDescription.Text.Trim();
        objDep.ACTIVE = chkActive.Checked;

        DepartmentBO bphan = new DepartmentBO();
        if (int.Parse(hdfDepartmentId.Value) <= 0)
        {
            hdfDepartmentId.Value = bphan.DepInsert(objDep).ToString();
            if (int.Parse(hdfDepartmentId.Value) > 0)
            {
                btnSave.Text = "Cập nhật";
                lblAlerting.Text = "Thêm mới nhóm người dùng thành công!";
            }
            else
            {
                lblAlerting.Text = "Thêm mới nhóm người dùng thất bại, bạn vui lòng thử lại!";
            }
        }
        else
            if (bphan.DepUpdate(objDep))
            {
                //btnSave.Text = "Cập nhật";
                lblAlerting.Text = "Cập nhật nhóm người dùng thành công!";
            }
            else
            {
                lblAlerting.Text = "Cập nhật nhóm người dùng thất bại, bạn vui lòng thử lại!";
            }
        LoadGrid();

    }
    private void LoadGrid()
    {
        SYS_AMW_DEPARTMENT objDep = new SYS_AMW_DEPARTMENT();
        objDep.DEPARTMENTNAME = txtDepartmentName.Text.Trim();
        objDep.DESCRIPTION = txtDescription.Text.Trim();
        objDep.ACTIVE = chkActive.Checked;
        DisplayDepartmentInGrid(objDep);

    }


    protected void grdDepartmentList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        LoadGrid();
        grdDepartmentList.PageIndex = e.NewPageIndex;
        grdDepartmentList.DataBind();
    }
}