using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Globalization;

public partial class Distributor_UserControl_uc_MyBooking : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CategoryBO BO = new CategoryBO();
            List<SP_ROOM_SEARCHResult> listRoom = new List<SP_ROOM_SEARCHResult>();
            listRoom = BO.SP_ROOM_SEARCH("", "", "", "", char.Parse("Y")).ToList();
            ddlRoom.DataSource = listRoom;
            ddlRoom.DataTextField = "RoomName";
            ddlRoom.DataValueField = "RoomCode";
            ddlRoom.DataBind();

            ddlRoomMove.DataSource = listRoom;
            ddlRoomMove.DataTextField = "RoomName";
            ddlRoomMove.DataValueField = "RoomCode";
            ddlRoomMove.DataBind();

            ListItem lstParent = new ListItem("--Chọn--", "");
            ddlRoom.Items.Insert(0, lstParent);
            ddlRoom.SelectedIndex = ddlRoom.Items.IndexOf(lstParent);

            ddlRoomMove.Items.Insert(0, lstParent);
            ddlRoomMove.SelectedIndex = ddlRoom.Items.IndexOf(lstParent);

            LoadBookingGrid("", "","", "Y","Y");
            btMove.Visible = false;
            MoveRoom.Visible = false;
        }
    }

    public void LoadBookingGrid(String BookingCode, String RoomCode, String ADA, string PaymentStatus, string BookingStatus)
    {
        RegistryRoomBO BO = new RegistryRoomBO();
        List<SP_REGISTYROOM_GET_BY_BOOKINGCODEResult> result = new List<SP_REGISTYROOM_GET_BY_BOOKINGCODEResult>();
        result = BO.SearchBooking(BookingCode, RoomCode, ADA, PaymentStatus, BookingStatus);
        grdList.DataSource = result;
        grdList.DataBind();
    }

    public void Search(String BookingCode, String RoomCode, String ADA, string PaymentStatus, string BookingStatus)
    {
        RegistryRoomBO BO = new RegistryRoomBO();
        List<SP_REGISTYROOM_GET_BY_BOOKINGCODEResult> result = new List<SP_REGISTYROOM_GET_BY_BOOKINGCODEResult>();
        result = BO.SearchBooking(BookingCode, RoomCode, ADA, PaymentStatus, BookingStatus);
        if (result.Count > 0)
        {
            lblAlerting.Text = string.Empty;
            grdList.DataSource = result;
            grdList.DataBind();
        }
        else
        {
            lblAlerting.Text = "Không có dữ liệu phù hợp với yêu cầu tìm kiếm.";
            grdList.DataSource = result;
            grdList.DataBind();
        }

    }
    protected void grdList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblAlerting.Text = string.Empty;
        btMove.Visible = true;
        MoveRoom.Visible = false;
        txtBookingCode.Enabled = false;
        txtADAID.Enabled = false;
        ddlRoom.Enabled = false;
        chkBookingStatus.Enabled = false;
        chkPaymentStatus.Enabled = false;
        grdList.EditIndex = e.NewEditIndex;
        hdfId.Value = grdList.DataKeys[e.NewEditIndex].Value.ToString();
        string strBookingCode = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lbBookingCode")).Text;
        string strRoomCode = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lbRoomCode")).Text;
        string strADAID = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lbADAID")).Text;
        string strADAName = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lbADAName")).Text;
        string strMeetingDate = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lbMeetingDate")).Text;
        string strSection = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lbSection")).Text;
        string strPrice = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lbPrice")).Text;
        string strBookingStatus = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lbBookingStatus")).Text;
        string strPaymentStatus = ((Label)grdList.Rows[e.NewEditIndex].FindControl("lbPaymentStatus")).Text;

        txtBookingCode.Text = strBookingCode;
        ddlRoom.SelectedValue = strRoomCode;
        txtADAID.Text = strADAID;
        lbADAName.Text = strADAName;
        lbMeetingDate.Text = strMeetingDate;
        lbSection.Text = strSection;
        lbPrice.Text = strPrice;
        if (strBookingStatus.Equals("Y"))
        {
            chkBookingStatus.Checked = true;
        }
        else
        {
            chkBookingStatus.Checked = false;
        }
        if(strPaymentStatus.Equals("Y"))
        {
            chkPaymentStatus.Checked = true;
        }
        else
        {
            chkPaymentStatus.Checked = false;
        }
    }
    protected void btClear_Click(object sender, EventArgs e)
    {
        lblAlerting.Text = string.Empty;
        btMove.Visible = false;
        MoveRoom.Visible = false;
        txtBookingCode.Enabled = true;
        txtBookingCode.Text = string.Empty;
        ddlRoom.Enabled = true;
        ddlRoom.SelectedValue = "";
        txtADAID.Enabled = true;
        txtADAID.Text = string.Empty;
        lbADAName.Text = string.Empty;
        lbMeetingDate.Text = string.Empty;
        lbSection.Text = string.Empty;
        lbPrice.Text = string.Empty;
        chkBookingStatus.Checked = false;
        chkPaymentStatus.Checked = false;
        chkBookingStatus.Enabled = true;
        chkPaymentStatus.Enabled = true;
    }
    protected void btSearch_Click(object sender, EventArgs e)
    {
        string strBookingStatus = "";
        string strPaymentStatus = "";
        if (chkBookingStatus.Checked)
        {
            strBookingStatus = "Y";
        }
        else
        {
            strBookingStatus = "N";
        }
        if (chkPaymentStatus.Checked)
        {
            strPaymentStatus = "Y";
        }
        else
        {
            strPaymentStatus = "N";
        }

        Search(txtBookingCode.Text.Trim(), ddlRoom.SelectedValue.ToString(), txtADAID.Text.Trim(), strPaymentStatus, strBookingStatus);
    }
    protected void btMove_Click(object sender, EventArgs e)
    {
        if (txtBookingCode.Text.Trim().Equals(string.Empty) && hdfId.Value == null)
        {
            lblAlerting.Text = "Bạn chưa nhập mã đặt phòng.";
            return;
        }
        DateTime date = DateTime.ParseExact(lbMeetingDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        DateTime currentDate = DateTime.Now;
        TimeSpan time = date - currentDate;
        int day = time.Days;
        if(day >= 2 && chkBookingStatus.Checked && chkPaymentStatus.Checked)
        {
            MoveRoom.Visible = true;
            btSave.Visible = true;
        }
        else
        {
            lblAlerting.Text = "Bạn chỉ được phép chuyển phòng trước ngày hội họp ít nhất 2 ngày, và chi phí đặt phòng phải được thanh toán.";
        }
    }
    protected void grdList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        string strBookingStatus = "";
        string strPaymentStatus = "";
        if (chkBookingStatus.Checked)
        {
            strBookingStatus = "Y";
        }
        else
        {
            strBookingStatus = "N";
        }
        if (chkPaymentStatus.Checked)
        {
            strPaymentStatus = "Y";
        }
        else
        {
            strPaymentStatus = "N";
        }

        Search(txtBookingCode.Text.Trim(), ddlRoom.SelectedValue.ToString(), txtADAID.Text.Trim(), strPaymentStatus, strBookingStatus);
        grdList.PageIndex = e.NewPageIndex;
        grdList.DataBind();
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        btSave.Visible = false;
        RegistryRoomBO BO = new RegistryRoomBO();
        DateTime MeetingDate = DateTime.ParseExact(txtMeetingDate.Text.Trim(), "MM/dd/yyyy", CultureInfo.InvariantCulture);

        int iResult = BO.MoveBooking(txtBookingCode.Text.Trim(), ddlRoomMove.SelectedValue.ToString(), ddlRoom.SelectedValue.ToString(), MeetingDate, ddlSection.SelectedValue.ToString());
        if(iResult == 1)
        {
            lblAlerting.Text = "Giao dịch đặt phòng hội họp mà bạn di chuyển không tồn tại.";
        }
        if(iResult == 2)
        {
            lblAlerting.Text = "Phòng họp mà bạn chọn đã được NPP khác đặt, vui lòng chọn phòng khác";
        }
        if(iResult == 0)
        {
            lblAlerting.Text = "Chuyển phòng thất bại, vui lòng thử lại sau.";
        }
        if(iResult > 2)
        {
            lblAlerting.Text = "Giao dịch chuyển phòng thành công, mã đặt phòng mới của bạn là : " + iResult.ToString() + "-" + ddlRoomMove.SelectedValue.ToString() + "-" + txtADAID.Text.Trim();
        }
    }
}