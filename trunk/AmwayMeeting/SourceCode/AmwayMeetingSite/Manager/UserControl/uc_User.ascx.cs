using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Text.RegularExpressions;
using System.Net.Mail;

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
        objUser.FIRSTNAME = string.Empty;
        objUser.LASTNAME = string.Empty;
        objUser.RELATIVE_FIRSTNAME = string.Empty;
        objUser.RELATIVE_LASTNAME = string.Empty;
        objUser.CODE = string.Empty;
        objUser.ACCBANK = string.Empty;
        objUser.TELEPHONE = string.Empty;
        objUser.FAX = string.Empty;
        objUser.ADDRESS = string.Empty;
        objUser.EMAIL = string.Empty;
        objUser.USERTYPEID = 0;
        objUser.DEPARTMENTID = 0;
        objUser.WORKDISTRICTID = 0;
        objUser.WORKPROVINCEID = 0;
        objUser.DESCRIPTION = string.Empty;
        objUser.ACTIVE = chkActive.Checked;
        DisplayUsersInGrid(objUser);
    }

    private void ClearTextBox()
    {
        GetDepartmentCBO();
        GetUserTypeBO();
        GetProvinceCBO();
        GetDistrictCBO(0);
        hdfUserID.Value = "-1";
        txtADA.Text = string.Empty;
        txtFirstName.Text = string.Empty;
        txtLastName.Text = string.Empty;
        txtRelativeFirstName.Text = string.Empty;
        txtRelativeLastName.Text = string.Empty;
        txtCode.Text = string.Empty;
        txtAccBank.Text = string.Empty;
        txtTelephone.Text = string.Empty;
        txtFax.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtAddress.Text = string.Empty;
        ddlDepartment.SelectedValue = "0";
        ddlUserType.SelectedValue = "0";
        ddlWorkDistrict.SelectedValue = "0";
        ddlWorkProvince.SelectedValue = "0";
        txtDescription.Text = string.Empty;
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
                ddlWorkProvince.DataSource = lst;
                ddlWorkProvince.DataTextField = "PROVINCENAME";
                ddlWorkProvince.DataValueField = "ID";
                ddlWorkProvince.DataBind();
                ListItem lstParent = new ListItem("--Chọn--", "0");
                ddlWorkProvince.Items.Insert(0, lstParent);
                ddlWorkProvince.SelectedIndex = ddlWorkProvince.Items.IndexOf(lstParent);
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
                    ddlWorkDistrict.DataSource = lst;
                    ddlWorkDistrict.DataTextField = "DISTRICTNAME";
                    ddlWorkDistrict.DataValueField = "ID";
                    ddlWorkDistrict.DataBind();

                    ddlWorkDistrict.Items.Insert(0, lstParent);
                    ddlWorkDistrict.SelectedIndex = ddlWorkProvince.Items.IndexOf(lstParent);
                }
            }
            else
            {
                List<DAL.PRC_SYS_AMW_DISTRICT_CBOResult> lst = new List<DAL.PRC_SYS_AMW_DISTRICT_CBOResult>();
                ListItem lstParent = new ListItem("--Chọn--", "0");
                ddlWorkDistrict.Items.Add(lstParent);
                ddlWorkDistrict.SelectedIndex = ddlWorkDistrict.Items.IndexOf(lstParent);
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
        string strFirstName = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingFirstName")).Text;
        string strLastName = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingLastName")).Text;
        string strRelativeFirstName = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingRelativeFirstName")).Text;
        string strRelativeLastName = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingRelativeLastName")).Text;
        string strCode = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingCode")).Text;
        string strAccBank = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingAccBank")).Text;
        string strTelephone = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingTelephone")).Text;
        string strFax = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingFax")).Text;
        string strEmail = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingEmail")).Text;
        string strAddress = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingAddress")).Text;
        string strDepartment = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingDepartmentId")).Text;
        string strUserType = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingUserTypeId")).Text;
        string strWorkDistrict = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingWorkDistrictId")).Text;
        string strWorkProvince = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingWorkProvinceId")).Text;
        bool Active = bool.Parse(((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingActive")).Text);
        string strDescription = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingDescription")).Text;

        // Bind len control

        txtADA.Text = strADA;
        txtFirstName.Text = strFirstName;
        txtLastName.Text = strLastName;
        txtRelativeFirstName.Text = strRelativeFirstName;
        txtRelativeLastName.Text = strRelativeLastName;
        txtCode.Text = strCode;
        txtAccBank.Text = strAccBank;
        txtTelephone.Text = strTelephone;
        txtFax.Text = strFax;
        txtEmail.Text = strEmail;
        txtAddress.Text = strAddress;
        ddlDepartment.SelectedValue = strDepartment;
        ddlUserType.SelectedValue = strUserType;
        ddlWorkProvince.SelectedValue = strWorkProvince;
        GetDistrictCBO(int.Parse( strWorkProvince));
        ddlWorkDistrict.SelectedValue = strWorkDistrict;
        chkActive.Checked = Active;
        txtDescription.Text = strDescription;

    }
    protected void btnXoaTrang_Click(object sender, EventArgs e)
    {
        ClearTextBox();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtADA.Text.Trim().Length <= 0)
        {
            lblAlerting.Text = "Bạn chưa nhập mã số ADA!";
            return;
        }
        //if (txtLastName.Text.Trim().Length <= 0)
        //{
        //    lblAlerting.Text = "Bạn chưa nhập họ và tên đệm!";
        //    return;
        //}
        if (txtFirstName.Text.Trim().Length <= 0)
        {
            lblAlerting.Text = "Bạn chưa nhập tên!";
            return;
        }
        //if (txtAddress.Text.Trim().Length <= 0)
        //{
        //    lblAlerting.Text = "Bạn chưa nhập địa chỉ!";
        //    return;
        //}
        //if (txtEmail.Text.Trim().Length <= 0)
        //{
        //    lblAlerting.Text = "Bạn chưa nhập email của nhân viên!";
        //    return;
        //}
        //else
        //{
        //    if (!CheckEmail(txtEmail.Text.Trim()))
        //    {
        //        lblAlerting.Text = "Email của nhân viên bạn nhập không đúng!";
        //        return;
        //    }
        //}
        if (int.Parse(ddlUserType.SelectedValue) <= 0)
        {
            lblAlerting.Text = "Bạn chưa chọn danh hiệu của người dùng!";
            return;
        }
        if (int.Parse(ddlDepartment.SelectedValue) <= 0)
        {
            lblAlerting.Text = "Bạn chưa chọn nhóm người dùng!";
            return;
        }

        if (int.Parse(ddlWorkProvince.SelectedValue) <= 0)
        {
            lblAlerting.Text = "Bạn chưa chọn tỉnh thành đang làm việc!";
            return;
        }
        if (int.Parse(ddlWorkDistrict.SelectedValue) <= 0)
        {
            lblAlerting.Text = "Bạn chưa chọn quận huyện đang làm việc!";
            return;
        }

        // Thuc hien Insert Update
        SYS_AMW_USER objUser = new SYS_AMW_USER();
        objUser.USERID = int.Parse(hdfUserID.Value);
        objUser.ADA = txtADA.Text.Trim();
        objUser.FIRSTNAME = txtFirstName.Text.Trim();
        objUser.LASTNAME = txtLastName.Text.Trim();
        objUser.RELATIVE_FIRSTNAME = txtRelativeFirstName.Text.Trim();
        objUser.RELATIVE_FIRSTNAME = txtRelativeLastName.Text.Trim();
        objUser.CODE = txtCode.Text.Trim();
        objUser.ACCBANK = txtAccBank.Text.Trim();
        objUser.TELEPHONE = txtTelephone.Text.Trim();
        objUser.FAX = txtFax.Text.Trim();
        objUser.ADDRESS = txtAddress.Text.Trim();
        objUser.DESCRIPTION = txtDescription.Text.Trim();
        objUser.EMAIL = txtEmail.Text.Trim();
        objUser.USERTYPEID = int.Parse(ddlUserType.SelectedValue);
        objUser.DEPARTMENTID = int.Parse(ddlDepartment.SelectedValue);
        objUser.WORKDISTRICTID = int.Parse(ddlWorkDistrict.SelectedValue);
        objUser.WORKPROVINCEID = int.Parse(ddlWorkProvince.SelectedValue);

        objUser.CREATEUSER = int.Parse(Session["UserID"].ToString());
        objUser.UPDATEUSER = int.Parse(Session["UserID"].ToString());

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
        objUser.FIRSTNAME = txtFirstName.Text.Trim();
        objUser.LASTNAME = txtLastName.Text.Trim();
        objUser.RELATIVE_FIRSTNAME = txtRelativeFirstName.Text.Trim();
        objUser.RELATIVE_LASTNAME = txtRelativeLastName.Text.Trim();
        objUser.CODE = txtCode.Text.Trim();
        objUser.ACCBANK = txtAccBank.Text.Trim();
        objUser.TELEPHONE = txtTelephone.Text.Trim();
        objUser.FAX = txtFax.Text.Trim();
        objUser.ADDRESS = txtAddress.Text.Trim();
        objUser.DESCRIPTION = txtDescription.Text.Trim();
        objUser.EMAIL = txtEmail.Text.Trim();
        objUser.USERTYPEID = int.Parse(ddlUserType.SelectedValue);
        objUser.DEPARTMENTID = int.Parse(ddlDepartment.SelectedValue);
        objUser.WORKDISTRICTID = int.Parse(ddlWorkDistrict.SelectedValue);
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
        //string pattern = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
        //Match match = Regex.Match(strEmail.Trim(), pattern, RegexOptions.IgnoreCase);

        //if (match.Success)
        //    return true;
        //else
        //    return false;
        try
        {
            MailAddress m = new MailAddress(strEmail);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }

    protected void ddlWorkProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDistrictCBO(int.Parse(ddlWorkProvince.SelectedValue));
    }
}