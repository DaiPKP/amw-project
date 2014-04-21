using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class Category_UserControl_uc_Pax_Province : System.Web.UI.UserControl
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
        obj.PAXID = 0;
        obj.PROVINCEID = 0;
        obj.DESCRIPTION = string.Empty;
        obj.ACTIVE = chkActive.Checked;
        DisplayPaxInGrid(obj);
    }

    private void GetPaxCBO()
    {
        try
        {
            CategoryBO catebo = new CategoryBO();
            List<DAL.PRC_SYS_AMW_PAX_CBOResult> lst = new List<DAL.PRC_SYS_AMW_PAX_CBOResult>();
            lst = catebo.PaxGet_CBO().ToList();
            if (lst != null)
            {
                ddlPax.DataSource = lst;
                ddlPax.DataTextField = "PAXNAME";
                ddlPax.DataValueField = "ID";
                ddlPax.DataBind();

                ListItem lstParent = new ListItem("--Chọn--", "0");
                ddlPax.Items.Insert(0, lstParent);
                ddlPax.SelectedIndex = ddlPax.Items.IndexOf(lstParent);


            }
        }
        catch
        {
        }
    }
    private void GetProvinceCBO()
    {
        try
        {
            CategoryBO catebo = new CategoryBO();
            List<DAL.PRC_SYS_AMW_PROVINCE_CBOResult> lst = new List<DAL.PRC_SYS_AMW_PROVINCE_CBOResult>();
            lst = catebo.ProvinceGet_CBO().ToList();
            if (lst != null)
            {
                ddlProvince.DataSource = lst;
                ddlProvince.DataTextField = "PROVINCENAME";
                ddlProvince.DataValueField = "ID";
                ddlProvince.DataBind();

                ListItem lstParent = new ListItem("--Chọn--", "0");
                ddlProvince.Items.Insert(0, lstParent);
                ddlProvince.SelectedIndex = ddlProvince.Items.IndexOf(lstParent);

                
            }
        }
        catch
        {
        }
    }
    private void ClearTextBox()
    {

        GetPaxCBO();
        GetProvinceCBO();
        hdfPaxId.Value = "-1";
        ddlPax.Text = "0";
        ddlProvince.Text = "0";
        txtDescription.Text = string.Empty;
        chkActive.Checked = true;
        btnSave.Text = "Thêm mới";
        lblAlerting.Text = string.Empty;
    }
    protected void DisplayPaxInGrid(SYS_AMW_PAX_PROVINCE obj)
    {
        CategoryBO objBO = new CategoryBO();
        List<PRC_SYS_AMW_PAX_PROVINCE_SEARCHResult> lst = new List<PRC_SYS_AMW_PAX_PROVINCE_SEARCHResult>();
        lst = objBO.Pax_ProvinceGet_Search(obj).ToList();
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
        string strPaxId = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingPaxId")).Text;
        string strProvinceId = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingProvinceId")).Text;
        string strDescription = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingDescription")).Text;
        bool Active = bool.Parse(((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingActive")).Text);

        // Bind len control
        ddlPax.SelectedValue = strPaxId;
        ddlProvince.SelectedValue = strProvinceId;
        txtDescription.Text = strDescription;
        chkActive.Checked = Active;

    }
    protected void btnXoaTrang_Click(object sender, EventArgs e)
    {
        ClearTextBox();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddlPax.Text.Trim().Length <= 0)
        {
            lblAlerting.Text = "Bạn chưa chọn pax!";
            return;
        }

        if (ddlProvince.Text.Trim().Length <= 0)
        {
            lblAlerting.Text = "Bạn chưa chọn tỉnh thành!";
            return;
        }
        // Thuc hien Insert Update
        SYS_AMW_PAX_PROVINCE obj = new SYS_AMW_PAX_PROVINCE();
        obj.ID = int.Parse(hdfPaxId.Value);
        obj.PAXID = int.Parse(ddlPax.SelectedValue);
        obj.PROVINCEID = int.Parse(ddlProvince.SelectedValue);
        obj.DESCRIPTION = txtDescription.Text.Trim();
        obj.ACTIVE = chkActive.Checked;

        CategoryBO objBO = new CategoryBO();
        if (int.Parse(hdfPaxId.Value) <= 0)
        {
            hdfPaxId.Value = objBO.Pax_ProvinceInsert(obj).ToString();
            if (int.Parse(hdfPaxId.Value) > 0)
            {
                btnSave.Text = "Cập nhật";
                lblAlerting.Text = "Thêm mới pax-tỉnh thành thành công!";
            }
            else
            {
                lblAlerting.Text = "Thêm mới pax-tỉnh thành thất bại, bạn vui lòng thử lại!";
            }
        }
        else
            if (objBO.Pax_ProvinceUpdate(obj))
            {
                //btnSave.Text = "Cập nhật";
                lblAlerting.Text = "Cập nhật pax-tỉnh thành thành công!";
            }
            else
            {
                lblAlerting.Text = "Cập nhật pax-tỉnh thành thất bại, bạn vui lòng thử lại!";
            }
        LoadGrid();

    }
    private void LoadGrid()
    {
        SYS_AMW_PAX_PROVINCE obj = new SYS_AMW_PAX_PROVINCE();
        obj.PAXID = int.Parse(ddlPax.SelectedValue);
        obj.PROVINCEID = int.Parse(ddlProvince.SelectedValue);
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