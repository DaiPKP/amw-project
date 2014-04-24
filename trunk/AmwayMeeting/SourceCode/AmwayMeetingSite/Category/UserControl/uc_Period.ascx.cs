using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class Category_UserControl_uc_Period : System.Web.UI.UserControl
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
        SYS_AMW_PERIOD obj = new SYS_AMW_PERIOD();
        obj.PERIODNAME = string.Empty;
        obj.STARTDATE = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", CultureInfo.InvariantCulture);
        obj.ENDDATE = DateTime.ParseExact("01/01/2900", "dd/MM/yyyy", CultureInfo.InvariantCulture);
        obj.DESCRIPTION = string.Empty;
        obj.ACTIVE = chkActive.Checked;
        DisplayPaxInGrid(obj);
    }



    private void ClearTextBox()
    {

        hdfId.Value = "-1";
        txtPeriodName.Text = string.Empty;
        txtStartDate.Text = string.Empty;
        txtEndDate.Text = string.Empty;
        txtDescription.Text = string.Empty;
        chkActive.Checked = true;
        btnSave.Text = "Thêm mới";
        lblAlerting.Text = string.Empty;
    }
    protected void DisplayPaxInGrid(SYS_AMW_PERIOD obj)
    {
        CategoryBO objBO = new CategoryBO();
        List<PRC_SYS_AMW_PERIOD_SEARCHResult> lst = new List<PRC_SYS_AMW_PERIOD_SEARCHResult>();
        lst = objBO.PeriodGet_Search(obj).ToList();
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
        string strPeriodName = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingPeriodName")).Text;
        string strStartDate = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingStartDate")).Text;
        string strEndDate = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingEndDate")).Text;
        string strDescription = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingDescription")).Text;
        bool isActive = bool.Parse(((Label)grdList.Rows[e.NewEditIndex].FindControl("lblListingActive")).Text);

        // Bind len control
        txtPeriodName.Text = strPeriodName;
        txtStartDate.Text = strStartDate;
        txtEndDate.Text = strEndDate;
        txtDescription.Text = strDescription;
        chkActive.Checked = isActive;

    }
    protected void btnXoaTrang_Click(object sender, EventArgs e)
    {
        ClearTextBox();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtPeriodName.Text.Trim().Length <= 0)
        {
            lblAlerting.Text = "Bạn chưa nhập tên chu kỳ!";
            return;
        }

        if ((txtStartDate.Text.Trim().Length <= 0) || (!CheckDate(txtStartDate.Text)))
        {
            lblAlerting.Text = "Bạn nhập từ ngày không đúng!";
            return;
        }
        if ((txtEndDate.Text.Trim().Length <= 0) || (!CheckDate(txtEndDate.Text)))
        {
            lblAlerting.Text = "Bạn nhập đến ngày không đúng!";
            return;
        }
        // Thuc hien Insert Update
        SYS_AMW_PERIOD obj = new SYS_AMW_PERIOD();
        obj.ID = int.Parse(hdfId.Value);
        obj.PERIODNAME = txtPeriodName.Text.Trim();
        obj.STARTDATE = DateTime.ParseExact(txtStartDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        obj.ENDDATE = DateTime.ParseExact(txtEndDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        obj.DESCRIPTION = txtDescription.Text.Trim();
        obj.ACTIVE = chkActive.Checked;
        obj.CREATEUSER = int.Parse(Session["UserID"].ToString());
        obj.UPDATEUSER = int.Parse(Session["UserID"].ToString());

        CategoryBO objBO = new CategoryBO();
        if (int.Parse(hdfId.Value) <= 0)
        {
            hdfId.Value = objBO.PeriodInsert(obj).ToString();
            if (int.Parse(hdfId.Value) > 0)
            {
                btnSave.Text = "Cập nhật";
                lblAlerting.Text = "Thêm mới chu kỳ thành công!";
            }
            else
            {
                lblAlerting.Text = "Thêm mới chu kỳ thất bại, bạn vui lòng thử lại!";
            }
        }
        else
            if (objBO.PeriodUpdate(obj))
            {
                //btnSave.Text = "Cập nhật";
                lblAlerting.Text = "Cập nhật chu kỳ thành công!";
            }
            else
            {
                lblAlerting.Text = "Cập nhật chu kỳ thất bại, bạn vui lòng thử lại!";
            }
        LoadGrid();

    }
    private void LoadGrid()
    {
        SYS_AMW_PERIOD obj = new SYS_AMW_PERIOD();
        obj.PERIODNAME = txtPeriodName.Text.Trim();
        if (CheckDate(txtStartDate.Text.Trim()))
        { 
        obj.STARTDATE = DateTime.ParseExact(txtStartDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        else
        {

            obj.STARTDATE = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            
        }
        if (CheckDate(txtEndDate.Text.Trim()))
        {
            obj.ENDDATE = DateTime.ParseExact(txtEndDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        else
        {
            obj.ENDDATE = DateTime.ParseExact("01/01/2900", "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        
        obj.DESCRIPTION = txtDescription.Text.Trim();
        obj.ACTIVE = chkActive.Checked;
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

    private bool CheckDate(string strDate)
    {
        try
        {
            DateTime dt = DateTime.ParseExact(strDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            return true;
        }
        catch
        {
            return false;
        }
    }

}