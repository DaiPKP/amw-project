using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Text.RegularExpressions;

public partial class Manager_UserControl_uc_User : System.Web.UI.UserControl
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
        SYS_AMW_USER objUser = new SYS_AMW_USER();
        objUser.ADA = string.Empty;
        objUser.VICEGERENT = string.Empty;
        objUser.ADDRESS = string.Empty;
        objUser.TELEPHONE = string.Empty;
        objUser.MOBILE = string.Empty;
        objUser.EMAIL = string.Empty;
        objUser.USERTYPEID = 0;
        objUser.DEPARTMENTID = 0;
        objUser.HOMEPROVINCEID = 0;
        objUser.WORKPROVINCEID = 0;
        objUser.ACTIVE = chkActive.Checked;
        DisplayUsersInGrid(objUser);
    }

    private void ClearTextBox()
    {
        GetDepartmentCBO();
        GetAllUserType();
        GetAllProvince();
        hdfUserID.Value = "-1";
        txtADA.Text = string.Empty;
        txtViceGerent.Text = string.Empty;
        txtTelephone.Text = string.Empty;
        txtMobile.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtAddress.Text = string.Empty;
        ddlDepartment.SelectedValue = "0";
        ddlUserType.SelectedValue = "0";
        ddlHomeProvince.SelectedValue = "0";
        ddlWorkProvince.SelectedValue = "0";
        chkActive.Checked = true;
        btnSave.Text = "Thêm mới";
        lblAlerting.Text = string.Empty;
    }
    protected void DisplayUsersInGrid(SYS_AMW_USER objUser)
    {
        UserBO acc = new UserBO();
        List<PRC_SYS_AMW_USER_SEARCHResult> lst = new List<PRC_SYS_AMW_USER_SEARCHResult>();
        lst = acc.UserGet_Search(objUser).ToList();
        grdUserList.DataSource = lst;
        if (lst.Count > 0)
        {
            grdUserList.PageIndex = 0;
        }
        grdUserList.DataBind();
    }
    private void GetDepartmentCBO()
    {
        try
        {
            DepartmentBO objBO = new DepartmentBO();
            List<DAL.PRC_SYS_AMW_DEPARTMENT_CBOResult> lst = new List<DAL.PRC_SYS_AMW_DEPARTMENT_CBOResult>();
            lst = objBO.DepGet_CBO().ToList();
            if (lst != null)
            {
                ddlDepartment.DataSource = lst;
                ddlDepartment.DataTextField = "DEPARTMENTNAME";
                ddlDepartment.DataValueField = "ID";
                ddlDepartment.DataBind();

                ListItem lstParent = new ListItem("--Chọn--", "0");
                ddlDepartment.Items.Insert(0, lstParent);
                ddlDepartment.SelectedIndex = ddlDepartment.Items.IndexOf(lstParent);
            }
        }
        catch
        {
        }
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
    private void GetProvinceCBO()
    {
        try
        {
            CategoryBO catebo = new CategoryBO();
            List<DAL.PRC_SYS_AMW_PROVINCE_CBOResult> lst = new List<DAL.PRC_SYS_AMW_PROVINCE_CBOResult>();
            lst = catebo.ProvinceGet_CBO().ToList();
            if (lst != null)
            {
                ddlHomeProvince.DataSource = lst;
                ddlHomeProvince.DataTextField = "PROVINCENAME";
                ddlHomeProvince.DataValueField = "ID";
                ddlHomeProvince.DataBind();

                ListItem lstParent = new ListItem("--Chọn--", "0");
                ddlHomeProvince.Items.Insert(0, lstParent);
                ddlHomeProvince.SelectedIndex = ddlHomeProvince.Items.IndexOf(lstParent);

                ddlWorkProvince.DataSource = lst;
                ddlWorkProvince.DataTextField = "PROVINCENAME";
                ddlWorkProvince.DataValueField = "ID";
                ddlWorkProvince.DataBind();

                ddlWorkProvince.Items.Insert(0, lstParent);
                ddlWorkProvince.SelectedIndex = ddlWorkProvince.Items.IndexOf(lstParent);
            }
        }
        catch
        {
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        hdfUserID.Value = "-1";
        lblAlerting.Text = string.Empty;
        LoadGrid();
    }
    protected void grdUserList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblAlerting.Text = string.Empty;
        btnSave.Text = "Cập nhật";
        grdUserList.EditIndex = e.NewEditIndex;
        hdfUserID.Value = grdUserList.DataKeys[e.NewEditIndex].Value.ToString();
        string strADA = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingADA")).Text;
        string strViceGerent = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingViceGerent")).Text;
        string strTelephone = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingTelephone")).Text;
        string strMobile = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingMobile")).Text;
        string strEmail = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingEmail")).Text;
        string strAddress = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingAddress")).Text;
        string strDepartment = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingDepartmentId")).Text;
        string strUserType = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingUserTypeId")).Text;
        string strHomeProvince = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingHomeProvinceId")).Text;
        string strWorkProvince = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingWorkProvinceId")).Text;
        bool Active = bool.Parse(((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingActive")).Text);

        // Bind len control
        txtADA.Text = strADA;
        txtViceGerent.Text = strViceGerent;
        txtTelephone.Text = strTelephone;
        txtMobile.Text = strMobile;
        txtEmail.Text = strEmail;
        txtAddress.Text = strAddress;
        ddlDepartment.SelectedValue = strDepartment;
        ddlUserType.SelectedValue = strUserType;
        ddlHomeProvince.SelectedValue = strHomeProvince;
        ddlWorkProvince.SelectedValue = strWorkProvince;
        chkActive.Checked = Active;

    }
    protected void btnXoaTrang_Click(object sender, EventArgs e)
    {
        ClearTextBox();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtADA.Text.Trim().Length <= 0)
        {
            lblAlerting.Text = "Bạn chưa nhập mã số amway!";
            return;
        }
        if (txtViceGerent.Text.Trim().Length <= 0)
        {
            lblAlerting.Text = "Bạn chưa nhập người đại diện!";
            return;
        }
        if (txtAddress.Text.Trim().Length <= 0)
        {
            lblAlerting.Text = "Bạn chưa nhập địa chỉ!";
            return;
        }
        if (txtEmail.Text.Trim().Length <= 0)
        {
            lblAlerting.Text = "Bạn chưa nhập email của nhân viên!";
            return;
        }
        else
        {
            if (!CheckEmail(txtEmail.Text.Trim()))
            {
                lblAlerting.Text = "Email của nhân viên bạn nhập không đúng!";
                return;
            }
        }
        if (int.Parse(ddlUserType.SelectedValue) <= 0)
        {
            lblAlerting.Text = "Bạn chưa chọn loại người dùng!";
            return;
        }
        if (int.Parse(ddlDepartment.SelectedValue) <= 0)
        {
            lblAlerting.Text = "Bạn chưa chọn nhóm người dùng!";
            return;
        }
        if (int.Parse(ddlHomeProvince.SelectedValue) <= 0)
        {
            lblAlerting.Text = "Bạn chưa chọn tỉnh thành đang ở!";
            return;
        }
        if (int.Parse(ddlWorkProvince.SelectedValue) <= 0)
        {
            lblAlerting.Text = "Bạn chưa chọn tỉnh thành đang làm việc!";
            return;
        }

        // Thuc hien Insert Update
        SYS_AMW_USER objUser = new SYS_AMW_USER();
        objUser.USERID = int.Parse(hdfUserID.Value);
        objUser.ADA = txtADA.Text.Trim();
        objUser.VICEGERENT = txtViceGerent.Text.Trim();
        objUser.ADDRESS = txtAddress.Text.Trim();
        objUser.TELEPHONE = txtTelephone.Text.Trim();
        objUser.MOBILE = txtMobile.Text.Trim();
        objUser.EMAIL = txtEmail.Text.Trim();
        objUser.USERTYPEID = int.Parse(ddlUserType.SelectedValue);
        objUser.DEPARTMENTID = int.Parse(ddlDepartment.SelectedValue);
        objUser.HOMEPROVINCEID = int.Parse(ddlHomeProvince.SelectedValue);
        objUser.WORKPROVINCEID = int.Parse(ddlWorkProvince.SelectedValue);
        objUser.ACTIVE = chkActive.Checked;
        UserBO acc = new UserBO();
        if (int.Parse(hdfUserID.Value) <= 0)
        {
            objUser.PASSWORD = General.EncryptPassword("AMW@1234");
            hdfUserID.Value = acc.UserInsert(objUser).ToString();
            if (int.Parse(hdfUserID.Value) > 0)
            {
                btnSave.Text = "Cập nhật";
                lblAlerting.Text = "Thêm mới người dùng thành công!";
            }
            else
            {
                lblAlerting.Text = "Thêm mới người dùng thất bại, bạn vui lòng thử lại!";
            }
        }
        else
            if (acc.UserUpdate(objUser))
            {
                //btnSave.Text = "Cập nhật";
                lblAlerting.Text = "Cập nhật người dùng thành công!";
            }
            else
            {
                lblAlerting.Text = "Cập nhật người dùng thất bại, bạn vui lòng thử lại!";
            }
        LoadGrid();

    }
    private void LoadGrid()
    {
        SYS_AMW_USER objUser = new SYS_AMW_USER();
        objUser.USERID = int.Parse(hdfUserID.Value);
        objUser.ADA = txtADA.Text.Trim();
        objUser.VICEGERENT = txtViceGerent.Text.Trim();
        objUser.ADDRESS = txtAddress.Text.Trim();
        objUser.TELEPHONE = txtTelephone.Text.Trim();
        objUser.MOBILE = txtMobile.Text.Trim();
        objUser.EMAIL = txtEmail.Text.Trim();
        objUser.USERTYPEID = int.Parse(ddlUserType.SelectedValue);
        objUser.DEPARTMENTID = int.Parse(ddlDepartment.SelectedValue);
        objUser.HOMEPROVINCEID = int.Parse(ddlHomeProvince.SelectedValue);
        objUser.WORKPROVINCEID = int.Parse(ddlWorkProvince.SelectedValue);
        objUser.ACTIVE = chkActive.Checked;
        DisplayUsersInGrid(objUser);
    }


    protected void grdUserList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        LoadGrid();
        grdUserList.PageIndex = e.NewPageIndex;
        grdUserList.DataBind();
    }
    private bool CheckEmail(string strEmail)
    {
        string pattern = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
        Match match = Regex.Match(strEmail.Trim(), pattern, RegexOptions.IgnoreCase);

        if (match.Success)
            return true;
        else
            return false;
    }
    protected void grdUserList_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
}