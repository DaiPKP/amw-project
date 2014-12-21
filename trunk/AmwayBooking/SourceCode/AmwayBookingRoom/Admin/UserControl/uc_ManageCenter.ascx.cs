using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class Admin_UserControl_uc_ManageCenter : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CategoryBO BO = new CategoryBO();
            List<SP_CITY_GET_CBOResult> listCity = new List<SP_CITY_GET_CBOResult>();
            listCity = BO.GetCity();
            ddlCity.DataSource = listCity;
            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "CityCode";
            ddlCity.DataBind();

            ListItem lstParent = new ListItem("--Chọn--", "");
            ddlCity.Items.Insert(0, lstParent);
            ddlCity.SelectedIndex = ddlCity.Items.IndexOf(lstParent);

            LoadCenterGrid("","", "", "Y");
        }
    }

    public void LoadCenterGrid(String CityCode, string CenterCode, String CenterName, String Status)
    {
        Center refCenter = new Center();
        refCenter.CityCode = CityCode;
        refCenter.CenterCode = CenterCode;
        refCenter.CenterName = CenterName;
        refCenter.Status = Char.Parse(Status);

        CategoryBO BO = new CategoryBO();
        List<SP_CENTER_SEARCHResult> result = new List<SP_CENTER_SEARCHResult>();
        result = BO.CenterSearch(refCenter);
        grdList.DataSource = result;
        grdList.DataBind();
    }

    public void Search(String CityCode, string CenterCode, String CenterName, String Status)
    {
        Center refCenter = new Center();
        refCenter.CityCode = CityCode;
        refCenter.CenterCode = CenterCode;
        refCenter.CenterName = CenterName;
        refCenter.Status = Char.Parse(Status);

        CategoryBO BO = new CategoryBO();
        List<SP_CENTER_SEARCHResult> result = new List<SP_CENTER_SEARCHResult>();
        result = BO.CenterSearch(refCenter);
        if (result.Count > 0)
        {
            lblAlerting.Text = string.Empty;
            grdList.DataSource = result;
            grdList.DataBind();
        }
        else
        {
            lblAlerting.Text = "Không có dữ liệu về thành phố phù hợp với yêu cầu tìm kiếm.";
            grdList.DataSource = result;
            grdList.DataBind();
        }

    }

    protected void grdList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblAlerting.Text = string.Empty;
        btSave.Text = "Cập nhật";
        txtCenterCode.Enabled = false;
        grdList.EditIndex = e.NewEditIndex;
        hdfId.Value = grdList.DataKeys[e.NewEditIndex].Value.ToString();
        string strCenterCode = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lbCenterCode")).Text;        
        string strCenterName = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lbCenterName")).Text;
        string strAddress = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lbAddress")).Text;
        string strStatus = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lbStatus")).Text;

        ddlCity.SelectedValue = hdfId.Value;
        txtCenterCode.Text = strCenterCode;
        txtCenterName.Text = strCenterName;
        txtAddress.Text = strAddress;
        if (strStatus.Equals("Y"))
        {
            chkStatus.Checked = true;
        }
        else
        {
            chkStatus.Checked = false;
        }
    }
    protected void btClear_Click(object sender, EventArgs e)
    {
        lblAlerting.Text = string.Empty;
        btSave.Text = "Thêm Mới";
        ddlCity.SelectedValue = "";
        txtCenterCode.Enabled = true;
        txtCenterCode.Text = string.Empty;
        txtCenterName.Text = string.Empty;
        txtAddress.Text = string.Empty;
        chkStatus.Checked = false;
    }
    protected void btSearch_Click(object sender, EventArgs e)
    {
        string strStatus = "";
        if (chkStatus.Checked)
        {
            strStatus = "Y";
        }
        else
        {
            strStatus = "N";
        }

        Search(ddlCity.SelectedValue.ToString(),txtCenterCode.Text.Trim(), txtCenterName.Text.Trim(), strStatus);
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        if(ddlCity.SelectedValue.ToString().Equals(""))
        {
            lblAlerting.Text = "Bạn chưa chọn thành phố.";
            return;
        }
        if (txtCenterCode.Text.Trim().Equals(string.Empty))
        {
            lblAlerting.Text = "Bạn chưa nhập mã trung tâm.";
            return;
        }
        if (txtCenterName.Text.Trim().Equals(string.Empty))
        {
            lblAlerting.Text = "Bạn chưa nhập tên trung tâm.";
            return;
        }
        Center refCenter = new Center();
        refCenter.CityCode = ddlCity.SelectedValue.ToString();
        refCenter.CenterCode = txtCenterCode.Text.Trim();
        refCenter.CenterName = txtCenterName.Text.Trim();
        refCenter.Address = txtAddress.Text.Trim();
        string strStatus = string.Empty;
        if (chkStatus.Checked)
            strStatus = "Y";
        else
            strStatus = "N";
        refCenter.Status = Char.Parse(strStatus);

        CategoryBO BO = new CategoryBO();

        if(btSave.Text.Equals("Thêm Mới"))
        {
            lblAlerting.Text = BO.CenterInsert(refCenter);
        }
        else
        {
            lblAlerting.Text = BO.CenterUpdate(refCenter);
        }
        LoadCenterGrid("","", "", "Y");
    }
}