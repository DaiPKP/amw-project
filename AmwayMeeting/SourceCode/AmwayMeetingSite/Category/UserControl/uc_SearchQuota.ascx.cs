using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class Category_UserControl_uc_SearchQuota : System.Web.UI.UserControl
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
        GetPaxCBO();
        GetPerviodCBO();
        hdfId.Value = "-1";
        txtADA.Text = string.Empty;
        ddlPAXID.SelectedValue = "0";
        ddlPERIODID.SelectedValue = "0";
        lbUserName.Text = string.Empty;
        lbUserType.Text = string.Empty;
        lbUsedQuota.Text = string.Empty;
        txtQuota.Text = string.Empty;
        btnSave.Text = "Thêm Mới";
        lblAlerting.Text = string.Empty;
    }

    private void GetPerviodCBO()
    {
        try
        {
            CategoryBO catebo = new CategoryBO();
            List<DAL.PRC_SYS_AMW_PERIOD_CBOResult> lst = new List<DAL.PRC_SYS_AMW_PERIOD_CBOResult>();
            lst = catebo.PeriodGet_CBO().ToList();
            if (lst != null)
            {
                ddlPERIODID.DataSource = lst;
                ddlPERIODID.DataTextField = "PERIODNAME";
                ddlPERIODID.DataValueField = "ID";
                ddlPERIODID.DataBind();

                ListItem lstParent = new ListItem("--Tất cả--", "0");
                ddlPERIODID.Items.Insert(0, lstParent);
                ddlPERIODID.SelectedIndex = ddlPAXID.Items.IndexOf(lstParent);
            }
        }
        catch
        {
        }
    }

    private void GetPaxCBO()
    {
        try
        {
            CategoryBO catebo = new CategoryBO();
            List<DAL.PRC_SYS_AMW_PAX_CBO_ALLResult> lst = new List<DAL.PRC_SYS_AMW_PAX_CBO_ALLResult>();
            lst = catebo.PaxGet_CBO_ALL().ToList();
            if (lst != null)
            {
                ddlPAXID.DataSource = lst;
                ddlPAXID.DataTextField = "PAXNAME";
                ddlPAXID.DataValueField = "ID";
                ddlPAXID.DataBind();

                ListItem lstParent = new ListItem("--Tất cả--", "0");
                ddlPAXID.Items.Insert(0, lstParent);
                ddlPAXID.SelectedIndex = ddlPAXID.Items.IndexOf(lstParent);
            }
        }
        catch
        {
        }
    }
    protected void DisplayInGrid(string ADA,int PaxID, int PeriodID)
    {
        CategoryBO catebo = new CategoryBO();
        List<PRC_SYS_AMW_DISTRIBUTOR_QUOTA_SEARCHResult> lst = new List<PRC_SYS_AMW_DISTRIBUTOR_QUOTA_SEARCHResult>();
        lst = catebo.Distributor_Quota_Search(ADA, PaxID, PeriodID).ToList();
        grdList.DataSource = lst;
        if (lst.Count > 0)
        {
            grdList.PageIndex = 0;
        }
        else
        {
            lblAlerting.Text = "Không tìm thấy kết quả với điều kiện tìm kiếm này";
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
        hdfId.Value = grdList.DataKeys[e.NewEditIndex].Value.ToString();
        string strDistName = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingDistributor")).Text;
        string strLevel = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingUserTypeName")).Text;
        string strQuota = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingQuota")).Text;
        string strUsedQuota = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingUsedQuota")).Text;
        lbUserName.Text = strDistName;
        lbUserType.Text = strLevel;
        txtQuota.Text = strQuota;
        lbUsedQuota.Text = strUsedQuota;
        btnSave.Text = "Cập Nhật";
    }
    protected void btnXoaTrang_Click(object sender, EventArgs e)
    {
        ClearTextBox();
    }

    private void LoadGrid()
    {
        DisplayInGrid(txtADA.Text.Trim(), int.Parse(ddlPAXID.SelectedValue), int.Parse(ddlPERIODID.SelectedValue));
    }


    protected void grdList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        LoadGrid();
        grdList.PageIndex = e.NewPageIndex;
        grdList.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtQuota.Text.Trim().Equals(""))
        {
            lblAlerting.Text = "Bạn chưa nhập quota";
            return;
        }
        else
        {
            CategoryBO catebo = new CategoryBO();
            if (btnSave.Text.Equals("Thêm Mới"))
            {
                if (txtADA.Text.Trim().Equals(""))
                {
                    lblAlerting.Text = "Bạn chưa nhập ADA ID";
                    return;
                }
                if (ddlPAXID.SelectedValue.ToString().Equals("0"))
                {
                    lblAlerting.Text = "Bạn chưa chọn PAX";
                    return;
                }
                if (ddlPERIODID.SelectedValue.ToString().Equals("0"))
                {
                    lblAlerting.Text = "Bạn chưa chọn quí tài chính";
                    return;
                }
                lblAlerting.Text = catebo.Distributor_Quota_Insert(int.Parse(ddlPERIODID.SelectedValue.ToString()), int.Parse(Session["UserID"].ToString()), txtADA.Text.Trim(), int.Parse(ddlPAXID.SelectedValue.ToString()), int.Parse(txtQuota.Text.Trim()));
            }
            else
            {
                if (hdfId.Value.ToString().Equals("-1"))
                {
                    lblAlerting.Text = "Bạn chưa chọn quota để cập nhật";
                    return;
                }
                lblAlerting.Text = catebo.Distributor_Quota_Update(int.Parse(hdfId.Value.ToString()), int.Parse(Session["UserID"].ToString()), int.Parse(txtQuota.Text.Trim()));

            }

        }
        
    }
}