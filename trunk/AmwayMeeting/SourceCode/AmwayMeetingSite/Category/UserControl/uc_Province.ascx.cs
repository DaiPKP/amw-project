using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class Category_UserControl_uc_Province : System.Web.UI.UserControl
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
        SYS_AMW_PROVINCE obj = new SYS_AMW_PROVINCE();
        obj.PROVINCENAME = string.Empty;
        obj.DESCRIPTION = string.Empty;
        obj.ACTIVE = chkActive.Checked;
        DisplayProvinceInGrid(obj);
    }

    private void ClearTextBox()
    {

        hdfProvinceId.Value = "-1";
        txtProvinceName.Text = string.Empty;
        txtDescription.Text = string.Empty;
        chkActive.Checked = true;
        btnSave.Text = "Thêm mới";
        lblAlerting.Text = string.Empty;
    }
    protected void DisplayProvinceInGrid(SYS_AMW_PROVINCE obj)
    {
        CategoryBO objBO = new CategoryBO();
        List<PRC_SYS_AMW_PROVINCE_SEARCHResult> lst = new List<PRC_SYS_AMW_PROVINCE_SEARCHResult>();
        lst = objBO.ProvinceGet_Search(obj).ToList();
        grdList.DataSource = lst;
        if (lst.Count > 0)
        {
            grdList.PageIndex = 0;
        }
        grdList.DataBind();
    }    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        hdfProvinceId.Value = "-1";
        lblAlerting.Text = string.Empty;
        LoadGrid();

    }
    protected void grdList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblAlerting.Text = string.Empty;
        btnSave.Text = "Cập nhật";
        grdList.EditIndex = e.NewEditIndex;
        hdfProvinceId.Value = grdList.DataKeys[e.NewEditIndex].Value.ToString();
        string strProvinceName = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingProvinceName")).Text;
        string strDescription = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingDescription")).Text;
        bool Active = bool.Parse(((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingActive")).Text);

        // Bind len control
        txtProvinceName.Text = strProvinceName;
        txtDescription.Text = strDescription;
        chkActive.Checked = Active;

    }
    protected void btnXoaTrang_Click(object sender, EventArgs e)
    {
        ClearTextBox();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtProvinceName.Text.Trim().Length <= 0)
        {
            lblAlerting.Text = "Bạn chưa nhập tên nhóm!";
            return;
        }

        // Thuc hien Insert Update
        SYS_AMW_PROVINCE obj = new SYS_AMW_PROVINCE();
        obj.ID = int.Parse(hdfProvinceId.Value);
        obj.PROVINCENAME = txtProvinceName.Text.Trim();
        obj.DESCRIPTION = txtDescription.Text.Trim();
        obj.ACTIVE = chkActive.Checked;

        CategoryBO objBO = new CategoryBO();
        if (int.Parse(hdfProvinceId.Value) <= 0)
        {
            hdfProvinceId.Value = objBO.ProvinceInsert(obj).ToString();
            if (int.Parse(hdfProvinceId.Value) > 0)
            {
                btnSave.Text = "Cập nhật";
                lblAlerting.Text = "Thêm mới tỉnh thành thành công!";
            }
            else
            {
                lblAlerting.Text = "Thêm mới tỉnh thành thất bại, bạn vui lòng thử lại!";
            }
        }
        else
            if (objBO.ProvinceUpdate(obj))
            {
                //btnSave.Text = "Cập nhật";
                lblAlerting.Text = "Cập nhật tỉnh thành thành công!";
            }
            else
            {
                lblAlerting.Text = "Cập nhật tỉnh thành thất bại, bạn vui lòng thử lại!";
            }
        LoadGrid();

    }
    private void LoadGrid()
    {
        SYS_AMW_PROVINCE obj = new SYS_AMW_PROVINCE();
        obj.PROVINCENAME = txtProvinceName.Text.Trim();
        obj.DESCRIPTION = txtDescription.Text.Trim();
        obj.ACTIVE = chkActive.Checked;
        DisplayProvinceInGrid(obj);

    }


    protected void grdList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        LoadGrid();
        grdList.PageIndex = e.NewPageIndex;
        grdList.DataBind();
    }
}