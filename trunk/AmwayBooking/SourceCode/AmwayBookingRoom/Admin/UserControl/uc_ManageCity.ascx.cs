using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class Admin_UserControl_uc_ManageCity : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCityGrid("", "", "Y");
        }
    }

    public void LoadCityGrid(String CityCode, String CityName, String Status)
    {
        City refCity = new City();
        refCity.CityCode = CityCode;
        refCity.CityName = CityName;
        refCity.Status = Char.Parse(Status);

        CategoryBO BO = new CategoryBO();
        List<SP_CITY_SEARCHResult> result = new List<SP_CITY_SEARCHResult>();
        result = BO.CitySearch(refCity);
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
        txtCityCode.Enabled = false;
        grdList.EditIndex = e.NewEditIndex;
        hdfId.Value = grdList.DataKeys[e.NewEditIndex].Value.ToString();
        string strCityCode = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lbCityCode")).Text;
        string strCityName = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lbCityName")).Text;
        string strStatus = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lbStatus")).Text;

        txtCityCode.Text = strCityCode;
        txtCityName.Text = strCityName;
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
        txtCityCode.Enabled = true;
        txtCityCode.Text = string.Empty;
        txtCityName.Text = string.Empty;
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

        LoadCityGrid(txtCityCode.Text.Trim(), txtCityName.Text.Trim(), strStatus);
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        if (txtCityCode.Text.Trim().Equals(string.Empty))
        {
            lblAlerting.Text = "Bạn chưa nhập mã thành phố.";
            return;
        }
        if (txtCityName.Text.Trim().Equals(string.Empty))
        {
            lblAlerting.Text = "Bạn chưa nhập tên thành phố.";
            return;
        }
        City refCity = new City();
        refCity.CityCode = txtCityCode.Text.Trim();
        refCity.CityName = txtCityName.Text.Trim();
        string strStatus = string.Empty;
        if (chkStatus.Checked)
            strStatus = "Y";
        else
            strStatus = "N";
        refCity.Status = Char.Parse(strStatus);

        CategoryBO BO = new CategoryBO();

        if(btSave.Text.Equals("Thêm Mới"))
        {
            lblAlerting.Text = BO.CityInsert(refCity);
        }
        else
        {
            lblAlerting.Text = BO.CityUpdate(refCity);
        }
        LoadCityGrid("", "", "Y");
    }
}