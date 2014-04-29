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
        SYS_AMW_PAX_DISTRICT obj = new SYS_AMW_PAX_DISTRICT();
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
    private void GetDistrictCBO(int provinceId)
    {
        try
        {
            if (provinceId > 0)
            {
                CategoryBO catebo = new CategoryBO();
                List<DAL.PRC_SYS_AMW_DISTRICT_CBOResult> lst = new List<DAL.PRC_SYS_AMW_DISTRICT_CBOResult>();
                lst = catebo.DistrictGet_CBO(provinceId).ToList();
                if (lst != null)
                {

                    ListItem lstParent = new ListItem("--Chọn--", "0");
                    ddlDistrict.DataSource = lst;
                    ddlDistrict.DataTextField = "DISTRICTNAME";
                    ddlDistrict.DataValueField = "ID";
                    ddlDistrict.DataBind();

                    ddlDistrict.Items.Insert(0, lstParent);
                    ddlDistrict.SelectedIndex = ddlDistrict.Items.IndexOf(lstParent);
                }
            }
            else
            {
                List<DAL.PRC_SYS_AMW_DISTRICT_CBOResult> lst = new List<DAL.PRC_SYS_AMW_DISTRICT_CBOResult>();
                ListItem lstParent = new ListItem("--Chọn--", "0");
                ddlDistrict.Items.Add(lstParent);
                ddlDistrict.SelectedIndex = ddlDistrict.Items.IndexOf(lstParent);
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
        GetDistrictCBO(0);
        hdfId.Value = "-1";
        ddlPax.SelectedIndex = 0;
        ddlProvince.SelectedIndex = 0;
        ddlProvince.SelectedIndex = 0;
        txtDescription.Text = string.Empty;
        chkActive.Checked = true;
        btnSave.Text = "Thêm mới";
        lblAlerting.Text = string.Empty;
    }
    protected void DisplayPaxInGrid(SYS_AMW_PAX_DISTRICT obj)
    {
        CategoryBO objBO = new CategoryBO();
        List<PRC_SYS_AMW_PAX_DISTRICT_SEARCHResult> lst = new List<PRC_SYS_AMW_PAX_DISTRICT_SEARCHResult>();
        lst = objBO.Pax_DistrictGet_Search(obj).ToList();
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
        string strPaxId = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingPaxId")).Text;
        string strProvinceId = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingProvinceId")).Text;
        string strDistrictId = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingDistrictId")).Text;
        string strDescription = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingDescription")).Text;
        bool Active = bool.Parse(((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingActive")).Text);

        // Bind len control
        ddlPax.SelectedValue = strPaxId;
        ddlProvince.SelectedValue = strProvinceId;
        GetDistrictCBO(int.Parse(strProvinceId));
        ddlDistrict.SelectedValue = strDistrictId;
        txtDescription.Text = strDescription;
        chkActive.Checked = Active;

    }
    protected void btnXoaTrang_Click(object sender, EventArgs e)
    {
        ClearTextBox();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (int.Parse(ddlPax.SelectedValue) <= 0)
        {
            lblAlerting.Text = "Bạn chưa chọn pax!";
            return;
        }

        if (int.Parse(ddlProvince.SelectedValue) <= 0)
        {
            lblAlerting.Text = "Bạn chưa chọn tỉnh thành!";
            return;
        }
        // Thuc hien Insert Update
        SYS_AMW_PAX_DISTRICT obj = new SYS_AMW_PAX_DISTRICT();
        obj.ID = int.Parse(hdfId.Value);
        obj.PAXID = int.Parse(ddlPax.SelectedValue);
        obj.PROVINCEID = int.Parse(ddlProvince.SelectedValue);
        obj.DISTRICTID = int.Parse(ddlDistrict.SelectedValue);
        obj.DESCRIPTION = txtDescription.Text.Trim();
        obj.ACTIVE = chkActive.Checked;
        obj.CREATEUSER = int.Parse(Session["UserID"].ToString());
        obj.UPDATEUSER = int.Parse(Session["UserID"].ToString());
        CategoryBO objBO = new CategoryBO();
        if (int.Parse(hdfId.Value) <= 0)
        {
            hdfId.Value = objBO.Pax_DistrictInsert(obj).ToString();
            if (int.Parse(hdfId.Value) > 0)
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
            if (objBO.Pax_DistrictUpdate(obj))
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
        SYS_AMW_PAX_DISTRICT obj = new SYS_AMW_PAX_DISTRICT();
        obj.PAXID = int.Parse(ddlPax.SelectedValue);
        obj.PROVINCEID = int.Parse(ddlProvince.SelectedValue);
        obj.DESCRIPTION = txtDescription.Text.Trim();
        obj.ACTIVE = chkActive.Checked;
        DisplayPaxInGrid(obj);

    }
    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDistrictCBO(int.Parse(ddlProvince.SelectedValue));
    }

    protected void grdList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        LoadGrid();
        grdList.PageIndex = e.NewPageIndex;
        grdList.DataBind();
    }
}