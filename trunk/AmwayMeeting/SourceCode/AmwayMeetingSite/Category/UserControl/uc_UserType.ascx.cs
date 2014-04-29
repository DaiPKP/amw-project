using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class Manager_UserControl_uc_UserType : System.Web.UI.UserControl
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
        SYS_AMW_USERTYPE obj = new SYS_AMW_USERTYPE();
        obj.USERTYPENAME = string.Empty;
        obj.DESCRIPTION = string.Empty;
        obj.ACTIVE = chkActive.Checked;
        DisplayUserTypeInGrid(obj);
    }

    private void ClearTextBox()
    {

        hdfUserTypeId.Value = "-1";
        txtUserTypeName.Text = string.Empty;
        txtDescription.Text = string.Empty;
        chkActive.Checked = true;
        btnSave.Text = "Thêm mới";
        lblAlerting.Text = string.Empty;
    }
    protected void DisplayUserTypeInGrid(SYS_AMW_USERTYPE obj)
    {
        CategoryBO objBO = new CategoryBO();
        List<PRC_SYS_AMW_USERTYPE_SEARCHResult> lst = new List<PRC_SYS_AMW_USERTYPE_SEARCHResult>();
        lst = objBO.UserTypeGet_Search(obj).ToList();
        grdList.DataSource = lst;
        if (lst.Count > 0)
        {
            grdList.PageIndex = 0;
        }
        grdList.DataBind();
    }    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        hdfUserTypeId.Value = "-1";
        lblAlerting.Text = string.Empty;
        LoadGrid();

    }
    protected void grdList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblAlerting.Text = string.Empty;
        btnSave.Text = "Cập nhật";
        grdList.EditIndex = e.NewEditIndex;
        hdfUserTypeId.Value = grdList.DataKeys[e.NewEditIndex].Value.ToString();
        string strUserTypeName = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingUserTypeName")).Text;
        string strDescription = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingDescription")).Text;
        bool Active = bool.Parse(((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingActive")).Text);

        // Bind len control
        txtUserTypeName.Text = strUserTypeName;
        txtDescription.Text = strDescription;
        chkActive.Checked = Active;

    }
    protected void btnXoaTrang_Click(object sender, EventArgs e)
    {
        ClearTextBox();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtUserTypeName.Text.Trim().Length <= 0)
        {
            lblAlerting.Text = "Bạn chưa nhập tên danh hiệu!";
            return;
        }

        // Thuc hien Insert Update
        SYS_AMW_USERTYPE objDep = new SYS_AMW_USERTYPE();
        objDep.ID = int.Parse(hdfUserTypeId.Value);
        objDep.USERTYPENAME = txtUserTypeName.Text.Trim();
        objDep.DESCRIPTION = txtDescription.Text.Trim();
        objDep.ACTIVE = chkActive.Checked;

        objDep.CREATEUSER = int.Parse(Session["UserID"].ToString());
        objDep.UPDATEUSER = int.Parse(Session["UserID"].ToString());
        CategoryBO objBO = new CategoryBO();
        if (int.Parse(hdfUserTypeId.Value) <= 0)
        {
            hdfUserTypeId.Value = objBO.UserTypeInsert(objDep).ToString();
            if (int.Parse(hdfUserTypeId.Value) > 0)
            {
                btnSave.Text = "Cập nhật";
                lblAlerting.Text = "Thêm mớidanh hiệu thành công!";
            }
            else
            {
                lblAlerting.Text = "Thêm mới danh hiệu thất bại, bạn vui lòng thử lại!";
            }
        }
        else
            if (objBO.UserTypeUpdate(objDep))
            {
                //btnSave.Text = "Cập nhật";
                lblAlerting.Text = "Cập nhật danh hiệu thành công!";
            }
            else
            {
                lblAlerting.Text = "Cập nhật danh hiệu thất bại, bạn vui lòng thử lại!";
            }
        LoadGrid();

    }
    private void LoadGrid()
    {
        SYS_AMW_USERTYPE obj = new SYS_AMW_USERTYPE();
        obj.USERTYPENAME = txtUserTypeName.Text.Trim();
        obj.DESCRIPTION = txtDescription.Text.Trim();
        obj.ACTIVE = chkActive.Checked;
        DisplayUserTypeInGrid(obj);

    }


    protected void grdList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        LoadGrid();
        grdList.PageIndex = e.NewPageIndex;
        grdList.DataBind();
    }
}