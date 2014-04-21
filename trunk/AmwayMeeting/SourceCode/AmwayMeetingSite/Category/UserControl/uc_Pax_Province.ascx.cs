using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class Category_UserControl_uc_Pax : System.Web.UI.UserControl
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
        SYS_AMW_PAX_PROVINCE obj = new SYS_AMW_PAX_PROVINCE();
        obj. = string.Empty;
        obj.DESCRIPTION = string.Empty;
        obj.ACTIVE = chkActive.Checked;
        DisplayPaxInGrid(obj);
    }

    private void ClearTextBox()
    {

        hdfPaxId.Value = "-1";
        txtPaxName.Text = string.Empty;
        txtDescription.Text = string.Empty;
        chkActive.Checked = true;
        btnSave.Text = "Thêm mới";
        lblAlerting.Text = string.Empty;
    }
    protected void DisplayPaxInGrid(SYS_AMW_PAX obj)
    {
        CategoryBO objBO = new CategoryBO();
        List<PRC_SYS_AMW_PAX_SEARCHResult> lst = new List<PRC_SYS_AMW_PAX_SEARCHResult>();
        lst = objBO.PaxGet_Search(obj).ToList();
        grdList.DataSource = lst;
        if (lst.Count > 0)
        {
            grdList.PageIndex = 0;
        }
        grdList.DataBind();
    }    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        hdfPaxId.Value = "-1";
        lblAlerting.Text = string.Empty;
        LoadGrid();

    }
    protected void grdList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblAlerting.Text = string.Empty;
        btnSave.Text = "Cập nhật";
        grdList.EditIndex = e.NewEditIndex;
        hdfPaxId.Value = grdList.DataKeys[e.NewEditIndex].Value.ToString();
        string strPaxName = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingPaxName")).Text;
        string strDescription = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingDescription")).Text;
        bool Active = bool.Parse(((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingActive")).Text);

        // Bind len control
        txtPaxName.Text = strPaxName;
        txtDescription.Text = strDescription;
        chkActive.Checked = Active;

    }
    protected void btnXoaTrang_Click(object sender, EventArgs e)
    {
        ClearTextBox();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtPaxName.Text.Trim().Length <= 0)
        {
            lblAlerting.Text = "Bạn chưa nhập tên pax!";
            return;
        }

        // Thuc hien Insert Update
        SYS_AMW_PAX obj = new SYS_AMW_PAX();
        obj.ID = int.Parse(hdfPaxId.Value);
        obj.PAXNAME = txtPaxName.Text.Trim();
        obj.DESCRIPTION = txtDescription.Text.Trim();
        obj.ACTIVE = chkActive.Checked;

        CategoryBO objBO = new CategoryBO();
        if (int.Parse(hdfPaxId.Value) <= 0)
        {
            hdfPaxId.Value = objBO.PaxInsert(obj).ToString();
            if (int.Parse(hdfPaxId.Value) > 0)
            {
                btnSave.Text = "Cập nhật";
                lblAlerting.Text = "Thêm mới pax thành công!";
            }
            else
            {
                lblAlerting.Text = "Thêm mới pax thất bại, bạn vui lòng thử lại!";
            }
        }
        else
            if (objBO.PaxUpdate(obj))
            {
                //btnSave.Text = "Cập nhật";
                lblAlerting.Text = "Cập nhật pax thành công!";
            }
            else
            {
                lblAlerting.Text = "Cập nhật pax thất bại, bạn vui lòng thử lại!";
            }
        LoadGrid();

    }
    private void LoadGrid()
    {
        SYS_AMW_PAX obj = new SYS_AMW_PAX();
        obj.PAXNAME = txtPaxName.Text.Trim();
        obj.DESCRIPTION = txtDescription.Text.Trim();
        obj.ACTIVE = chkActive.Checked;
        DisplayPaxInGrid(obj);

    }


    protected void grdList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        LoadGrid();
        grdList.PageIndex = e.NewPageIndex;
        grdList.DataBind();
    }
}