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
        GetAllDepartment(-1);
        GetAllLoaiNguoiDung(-1);
        GetAllTinhThanh(-1);
        hdfUserID.Value = "-1";
        txtADA.Text = string.Empty;
        txtNguoiDaiDien.Text = string.Empty;
        txtSoDTBan.Text = string.Empty;
        txtSoDTDD.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtDiaChi.Text = string.Empty;
        ddlNhomNguoiDung.SelectedValue = "0";
        ddlLoaiNguoiDung.SelectedValue = "0";
        ddlTinhThanhDangO.SelectedValue = "0";
        ddlTinhThanhLamViec.SelectedValue = "0";
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
    private void GetAllDepartment(int id)
    {
        try
        {
            DepartmentBO bphanbo = new DepartmentBO();
            List<DAL.PRC_SYS_AMW_DEPARTMENT_GETLISTBYIDResult> lst = new List<DAL.PRC_SYS_AMW_DEPARTMENT_GETLISTBYIDResult>();
            lst = bphanbo.DepGetListByID(id).ToList();
            if (lst != null)
            {
                ddlNhomNguoiDung.DataSource = lst;
                ddlNhomNguoiDung.DataTextField = "DEPARTMENTNAME";
                ddlNhomNguoiDung.DataValueField = "ID";
                ddlNhomNguoiDung.DataBind();

                ListItem lstParent = new ListItem("--Chọn--", "0");
                ddlNhomNguoiDung.Items.Insert(0, lstParent);
                ddlNhomNguoiDung.SelectedIndex = ddlNhomNguoiDung.Items.IndexOf(lstParent);
            }
        }
        catch
        {
        }
    }

    private void GetAllLoaiNguoiDung(int id)
    {
        try
        {
            CategoryBO catebo = new CategoryBO();
            List<DAL.PRC_SYS_AMW_USERTYPE_GETLISTBYIDResult> lst = new List<DAL.PRC_SYS_AMW_USERTYPE_GETLISTBYIDResult>();
            lst = catebo.UserTypeGetListByID(id).ToList();
            if (lst != null)
            {
                ddlLoaiNguoiDung.DataSource = lst;
                ddlLoaiNguoiDung.DataTextField = "USERTYPENAME";
                ddlLoaiNguoiDung.DataValueField = "ID";
                ddlLoaiNguoiDung.DataBind();

                ListItem lstParent = new ListItem("--Chọn--", "0");
                ddlLoaiNguoiDung.Items.Insert(0, lstParent);
                ddlLoaiNguoiDung.SelectedIndex = ddlLoaiNguoiDung.Items.IndexOf(lstParent);
            }
        }
        catch
        {
        }
    }
    private void GetAllTinhThanh(int id)
    {
        try
        {
            CategoryBO catebo = new CategoryBO();
            List<DAL.PRC_SYS_AMW_PROVINCE_GETLISTBYIDResult> lst = new List<DAL.PRC_SYS_AMW_PROVINCE_GETLISTBYIDResult>();
            lst = catebo.ProvinceGetListByID(id).ToList();
            if (lst != null)
            {
                ddlTinhThanhDangO.DataSource = lst;
                ddlTinhThanhDangO.DataTextField = "PROVINCENAME";
                ddlTinhThanhDangO.DataValueField = "ID";
                ddlTinhThanhDangO.DataBind();

                ListItem lstParent = new ListItem("--Chọn--", "0");
                ddlTinhThanhDangO.Items.Insert(0, lstParent);
                ddlTinhThanhDangO.SelectedIndex = ddlTinhThanhDangO.Items.IndexOf(lstParent);

                ddlTinhThanhLamViec.DataSource = lst;
                ddlTinhThanhLamViec.DataTextField = "PROVINCENAME";
                ddlTinhThanhLamViec.DataValueField = "ID";
                ddlTinhThanhLamViec.DataBind();

                ddlTinhThanhLamViec.Items.Insert(0, lstParent);
                ddlTinhThanhLamViec.SelectedIndex = ddlTinhThanhLamViec.Items.IndexOf(lstParent);
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
        string strNguoiDaiDien = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingNguoiDaiDien")).Text;
        string strSoDTBan = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingSoDTBan")).Text;
        string strSoDTDD = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingSoDTDD")).Text;
        string strEmail = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingEmail")).Text;
        string strDiaChi = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingDiaChi")).Text;
        string strNhomNguoiDung = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingNhomNguoiDung")).Text;
        string strLoaiNguoiDung = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingLoaiNguoiDung")).Text;
        string strTinhThanhDangO = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingTinhThanhDangO")).Text;
        string strTinhThanhLamViec = ((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingTinhThanhLamViec")).Text;
        bool Active = bool.Parse(((Label)grdUserList.Rows[e.NewEditIndex].FindControl("lblListingActive")).Text);

        // Bind len control
        txtADA.Text = strADA;
        txtNguoiDaiDien.Text = strNguoiDaiDien;
        txtSoDTBan.Text = strSoDTBan;
        txtSoDTDD.Text = strSoDTDD;
        txtEmail.Text = strEmail;
        txtDiaChi.Text = strDiaChi;
        ddlNhomNguoiDung.SelectedValue = strNhomNguoiDung;
        ddlLoaiNguoiDung.SelectedValue = strLoaiNguoiDung;
        ddlTinhThanhDangO.SelectedValue = strTinhThanhDangO;
        ddlTinhThanhLamViec.SelectedValue = strTinhThanhLamViec;
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
        if (txtNguoiDaiDien.Text.Trim().Length <= 0)
        {
            lblAlerting.Text = "Bạn chưa nhập người đại diện!";
            return;
        }
        if (txtDiaChi.Text.Trim().Length <= 0)
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
        if (int.Parse(ddlLoaiNguoiDung.SelectedValue) <= 0)
        {
            lblAlerting.Text = "Bạn chưa chọn loại người dùng!";
            return;
        }
        if (int.Parse(ddlNhomNguoiDung.SelectedValue) <= 0)
        {
            lblAlerting.Text = "Bạn chưa chọn nhóm người dùng!";
            return;
        }
        if (int.Parse(ddlTinhThanhDangO.SelectedValue) <= 0)
        {
            lblAlerting.Text = "Bạn chưa chọn tỉnh thành đang ở!";
            return;
        }
        if (int.Parse(ddlTinhThanhLamViec.SelectedValue) <= 0)
        {
            lblAlerting.Text = "Bạn chưa chọn tỉnh thành đang làm việc!";
            return;
        }

        // Thuc hien Insert Update
        SYS_AMW_USER objUser = new SYS_AMW_USER();
        objUser.USERID = int.Parse(hdfUserID.Value);
        objUser.ADA = txtADA.Text.Trim();
        objUser.VICEGERENT = txtNguoiDaiDien.Text.Trim();
        objUser.ADDRESS = txtDiaChi.Text.Trim();
        objUser.TELEPHONE = txtSoDTBan.Text.Trim();
        objUser.MOBILE = txtSoDTDD.Text.Trim();
        objUser.EMAIL = txtEmail.Text.Trim();
        objUser.USERTYPEID = int.Parse(ddlLoaiNguoiDung.SelectedValue);
        objUser.DEPARTMENTID = int.Parse(ddlNhomNguoiDung.SelectedValue);
        objUser.HOMEPROVINCEID = int.Parse(ddlTinhThanhDangO.SelectedValue);
        objUser.WORKPROVINCEID = int.Parse(ddlTinhThanhLamViec.SelectedValue);
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
        objUser.VICEGERENT = txtNguoiDaiDien.Text.Trim();
        objUser.ADDRESS = txtDiaChi.Text.Trim();
        objUser.TELEPHONE = txtSoDTBan.Text.Trim();
        objUser.MOBILE = txtSoDTDD.Text.Trim();
        objUser.EMAIL = txtEmail.Text.Trim();
        objUser.USERTYPEID = int.Parse(ddlLoaiNguoiDung.SelectedValue);
        objUser.DEPARTMENTID = int.Parse(ddlNhomNguoiDung.SelectedValue);
        objUser.HOMEPROVINCEID = int.Parse(ddlTinhThanhDangO.SelectedValue);
        objUser.WORKPROVINCEID = int.Parse(ddlTinhThanhLamViec.SelectedValue);
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