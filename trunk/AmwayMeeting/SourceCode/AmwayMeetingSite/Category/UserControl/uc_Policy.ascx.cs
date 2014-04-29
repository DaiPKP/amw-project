using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class Category_UserControl_uc_Policy : System.Web.UI.UserControl
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
        SYS_AMW_POLICY obj = new SYS_AMW_POLICY();
        obj.PAXID = 0;
        obj.USERTYPEID = 0;
        obj.QUOTA = 0;
        obj.CONDITIONCOMBINED = 0;
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
    private void GetUserTypeCBO()
    {
        try
        {
            CategoryBO catebo = new CategoryBO();
            List<DAL.PRC_SYS_AMW_USERTYPE_CBOResult> lst = new List<DAL.PRC_SYS_AMW_USERTYPE_CBOResult>();
            lst = catebo.UserTypeGet_CBO().ToList();
            if (lst != null)
            {
                ddlUserType.DataSource = lst;
                ddlUserType.DataTextField = "USERTYPENAME";
                ddlUserType.DataValueField = "ID";
                ddlUserType.DataBind();

                ListItem lstParent = new ListItem("--Chọn--", "0");
                ddlUserType.Items.Insert(0, lstParent);
                ddlUserType.SelectedIndex = ddlUserType.Items.IndexOf(lstParent);

                
            }
        }
        catch
        {
        }
    }
    private void ClearTextBox()
    {

        GetPaxCBO();
        GetUserTypeCBO();
        hdfId.Value = "-1";
        ddlPax.SelectedValue = "0";
        ddlUserType.SelectedValue = "0";
        txtQuota.Text ="0";
        txtConditionCombined.Text = "0";
        btnSave.Text = "Thêm mới";
        lblAlerting.Text = string.Empty;
    }
    protected void DisplayPaxInGrid(SYS_AMW_POLICY obj)
    {
        CategoryBO objBO = new CategoryBO();
        List<PRC_SYS_AMW_POLICY_SEARCHResult> lst = new List<PRC_SYS_AMW_POLICY_SEARCHResult>();
        lst = objBO.PolicyGet_Search(obj).ToList();
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
        string strUserTypeId = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingUserTypeId")).Text;
        string strQuota = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingQuota")).Text;
        string strConditionCombined = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingConditionCombined")).Text;

        // Bind len control
        ddlPax.SelectedValue = strPaxId;
        ddlUserType.SelectedValue = strUserTypeId;
        txtQuota.Text = strQuota;
        txtConditionCombined.Text = strConditionCombined;

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

        if (int.Parse(ddlUserType.SelectedValue) <= 0)
        {
            lblAlerting.Text = "Bạn chưa chọn danh hiệu!";
            return;
        }
        if (txtQuota.Text.Trim().Length <= 0 || !CheckNumber(txtQuota.Text.Trim()))
        {
            lblAlerting.Text = "Bạn chưa nhập quota!";
            return;
        }
        if (txtConditionCombined.Text.Trim().Length <= 0 || !CheckNumber(txtConditionCombined.Text.Trim()))
        {
            lblAlerting.Text = "Bạn chưa nhập  điều kiện tổ chức!";
            return;
        }
        // Thuc hien Insert Update
        SYS_AMW_POLICY obj = new SYS_AMW_POLICY();
        obj.ID = int.Parse(hdfId.Value);
        obj.PAXID = int.Parse(ddlPax.SelectedValue);
        obj.USERTYPEID = int.Parse(ddlUserType.SelectedValue);
        obj.QUOTA = int.Parse(txtQuota.Text.Trim().Replace(",", ""));
        obj.CONDITIONCOMBINED = int.Parse(txtConditionCombined.Text.Trim().Replace(",", ""));

        obj.CREATEUSER = int.Parse(Session["UserID"].ToString());
        obj.UPDATEUSER = int.Parse(Session["UserID"].ToString());
        CategoryBO objBO = new CategoryBO();
        if (int.Parse(hdfId.Value) <= 0)
        {
            hdfId.Value = objBO.PolicyInsert(obj).ToString();
            if (int.Parse(hdfId.Value) > 0)
            {
                btnSave.Text = "Cập nhật";
                lblAlerting.Text = "Thêm mới policy thành công!";
            }
            else
            {
                lblAlerting.Text = "Thêm mới policy thất bại, bạn vui lòng thử lại!";
            }
        }
        else
            if (objBO.PolicyUpdate(obj))
            {
                //btnSave.Text = "Cập nhật";
                lblAlerting.Text = "Cập nhật policy thành công!";
            }
            else
            {
                lblAlerting.Text = "Cập nhật policy thất bại, bạn vui lòng thử lại!";
            }
        LoadGrid();

    }
    private void LoadGrid()
    {
        SYS_AMW_POLICY obj = new SYS_AMW_POLICY();
        obj.PAXID = int.Parse(ddlPax.SelectedValue);
        obj.USERTYPEID = int.Parse(ddlUserType.SelectedValue);
        obj.QUOTA = int.Parse(txtQuota.Text.Trim().Replace(",", ""));
        obj.CONDITIONCOMBINED = int.Parse(txtConditionCombined.Text.Trim().Replace(",", ""));
        DisplayPaxInGrid(obj);

    }

    private bool CheckNumber(string strValue)
    {
        try
        {
            int.Parse(strValue.Replace(",", ""));
            return true;
        }
        catch
        {
            return false;
        }
    }
    protected void grdList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        LoadGrid();
        grdList.PageIndex = e.NewPageIndex;
        grdList.DataBind();
    }
}