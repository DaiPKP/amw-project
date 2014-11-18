using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class Category_UserControl_uc_UserTypeEnhance : System.Web.UI.UserControl
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
        SYS_AMW_USERTYPE_ENHANCE obj = new SYS_AMW_USERTYPE_ENHANCE();
        obj.USERTYPE_ENHANCENAME = string.Empty;
        obj.USERTYPEID = 0;
        obj.DESCRIPTION = string.Empty;
        obj.ACTIVE = chkActive.Checked;
        DisplayUserTypeEnhanceInGrid(obj);
    }

    private void GetUserTypeBO()
    {
        try
        {
            CategoryBO catebo = new CategoryBO();
            List<DAL.PRC_SYS_AMW_USERTYPE_CBOResult> lst = new List<DAL.PRC_SYS_AMW_USERTYPE_CBOResult>();
            lst = catebo.UserTypeGet_CBO().ToList();
            if (lst != null)
            {
                ddlUserTypeID.DataSource = lst;
                ddlUserTypeID.DataTextField = "USERTYPENAME";
                ddlUserTypeID.DataValueField = "ID";
                ddlUserTypeID.DataBind();

                ListItem lstParent = new ListItem("--Chọn--", "0");
                ddlUserTypeID.Items.Insert(0, lstParent);
                ddlUserTypeID.SelectedIndex = ddlUserTypeID.Items.IndexOf(lstParent);
            }
        }
        catch
        {
        }
    }
    
    private void ClearTextBox()
    {

        GetUserTypeBO();
        hdfId.Value = "-1";
        ddlUserTypeID.SelectedIndex = 0;
        txtUserTypeEnhanceName.Text = string.Empty;
        txtDescription.Text = string.Empty;
        chkActive.Checked = true;
        btnSave.Text = "Thêm mới";
        lblAlerting.Text = string.Empty;
    }
    protected void DisplayUserTypeEnhanceInGrid(SYS_AMW_USERTYPE_ENHANCE obj)
    {
        CategoryBO objBO = new CategoryBO();
        List<PRC_SYS_AMW_USERTYPE_ENHANCE_SEARCHResult> lst = new List<PRC_SYS_AMW_USERTYPE_ENHANCE_SEARCHResult>();
        lst = objBO.UserType_Enhance_Get_Search(obj).ToList();
        grdList.DataSource = lst;
        if (lst.Count > 0)
        {
            grdList.PageIndex = 0;
        }
        grdList.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        hdfId.Value = "-1";
        lblAlerting.Text = string.Empty;
        LoadGrid();

    }
    protected void grdList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblAlerting.Text = string.Empty;
        btnSave.Text = "Cập nhật";
        grdList.EditIndex = e.NewEditIndex;
        hdfId.Value = grdList.DataKeys[e.NewEditIndex].Value.ToString();
        string strUserTypeEnhanceName = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingUserTypeEnhanceName")).Text;
        string strUserTypeId = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingUserTypeId")).Text;
        string strDescription = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingDescription")).Text;
        bool Active = bool.Parse(((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingActive")).Text);

        // Bind len control
        txtUserTypeEnhanceName.Text = strUserTypeEnhanceName;
        ddlUserTypeID.SelectedValue = strUserTypeId;
        txtDescription.Text = strDescription;
        chkActive.Checked = Active;

    }
    protected void btnXoaTrang_Click(object sender, EventArgs e)
    {
        ClearTextBox();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtUserTypeEnhanceName.Text.Trim().Length <= 0)
        {
            lblAlerting.Text = "Bạn chưa nhập tên danh hiệu!";
            return;
        }
        if (int.Parse(ddlUserTypeID.SelectedValue) <= 0)
        {
            lblAlerting.Text = "Bạn chưa chọn nhóm danh hiệu!";
            return;
        }

       
        // Thuc hien Insert Update
        SYS_AMW_USERTYPE_ENHANCE obj = new SYS_AMW_USERTYPE_ENHANCE();
        obj.ID = int.Parse(hdfId.Value);
        obj.USERTYPE_ENHANCENAME = txtUserTypeEnhanceName.Text.Trim();
        obj.USERTYPEID = int.Parse(ddlUserTypeID.SelectedValue);
        obj.DESCRIPTION = txtDescription.Text.Trim();
        obj.ACTIVE = chkActive.Checked;
        obj.CREATEUSER = int.Parse(Session["UserID"].ToString());
        obj.UPDATEUSER = int.Parse(Session["UserID"].ToString());
        CategoryBO objBO = new CategoryBO();
        if (int.Parse(hdfId.Value) <= 0)
        {
            hdfId.Value = objBO.UserType_EnhanceInsert(obj).ToString();
            if (int.Parse(hdfId.Value) > 0)
            {
                btnSave.Text = "Cập nhật";
                lblAlerting.Text = "Thêm mới danh hiệu thành công!";
            }
            else
            {
                lblAlerting.Text = "Thêm mới danh hiệu thất bại, bạn vui lòng thử lại!";
            }
        }
        else
            if (objBO.UserType_EnhanceUpdate(obj))
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
        SYS_AMW_USERTYPE_ENHANCE obj = new SYS_AMW_USERTYPE_ENHANCE();
        obj.USERTYPE_ENHANCENAME = txtUserTypeEnhanceName.Text.Trim();
        obj.USERTYPEID = int.Parse(ddlUserTypeID.SelectedValue);
        obj.DESCRIPTION = txtDescription.Text.Trim();
        obj.ACTIVE = chkActive.Checked;
        DisplayUserTypeEnhanceInGrid(obj);

    }
   
    protected void grdList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        LoadGrid();
        grdList.PageIndex = e.NewPageIndex;
        grdList.DataBind();
    }
}