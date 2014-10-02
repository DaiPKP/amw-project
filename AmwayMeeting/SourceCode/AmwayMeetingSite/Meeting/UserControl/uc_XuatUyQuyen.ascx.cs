using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Data;
using System.Globalization;

public partial class Meeting_UserControl_uc_XuatUyQuyen : System.Web.UI.UserControl
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
        USR_AMW_MEETING_REGISTER obj = new USR_AMW_MEETING_REGISTER();
        obj.MEETINGTYPEID = int.Parse(ddlMEETINGTYPEID.SelectedValue);
        obj.STATUS_MEETING_REGISTERID = int.Parse(ddlSTATUS_MEETING_REGISTERID.SelectedValue);
    }

    private void ClearTextBox()
    {

        GetMeetingTypeCBO();
        GetStatusMeetingRegisterCBO();
        txtStartDate.Text = "";
        txtEndDate.Text = "";
        txtADA.Text = "";
        ddlMEETINGTYPEID.SelectedValue = "0";
        ddlSTATUS_MEETING_REGISTERID.SelectedValue = "0";
    }
    private void GetMeetingTypeCBO()
    {
        try
        {
            CategoryBO objBO = new CategoryBO();
            List<DAL.PRC_SYS_AMW_MEETING_TYPE_NOT_FOREIGN_CBOResult> lst = new List<DAL.PRC_SYS_AMW_MEETING_TYPE_NOT_FOREIGN_CBOResult>();
            lst = objBO.MeetingType_Not_Foreign_CBO().ToList();
            if (lst != null)
            {
                ddlMEETINGTYPEID.DataSource = lst;
                ddlMEETINGTYPEID.DataTextField = "MEETINGTYPENAME";
                ddlMEETINGTYPEID.DataValueField = "ID";
                ddlMEETINGTYPEID.DataBind();

                ListItem lstParent = new ListItem("--Chọn--", "0");
                ddlMEETINGTYPEID.Items.Insert(0, lstParent);
                ddlMEETINGTYPEID.SelectedIndex = ddlMEETINGTYPEID.Items.IndexOf(lstParent);
            }
        }
        catch
        {
        }
    }

    private void GetStatusMeetingRegisterCBO()
    {
        try
        {
            CategoryBO objBO = new CategoryBO();
            List<DAL.PRC_SYS_AMW_STATUS_MEETING_REGISTER_CBOResult> lst = new List<DAL.PRC_SYS_AMW_STATUS_MEETING_REGISTER_CBOResult>();
            lst = objBO.StatusMeetingRegisterGet_CBO().ToList();
            if (lst != null)
            {
                ddlSTATUS_MEETING_REGISTERID.DataSource = lst;
                ddlSTATUS_MEETING_REGISTERID.DataTextField = "STATUSNAME";
                ddlSTATUS_MEETING_REGISTERID.DataValueField = "ID";
                ddlSTATUS_MEETING_REGISTERID.DataBind();

                ListItem lstParent = new ListItem("--Tất cả--", "0");
                ddlSTATUS_MEETING_REGISTERID.Items.Insert(0, lstParent);
                ddlSTATUS_MEETING_REGISTERID.SelectedIndex = ddlSTATUS_MEETING_REGISTERID.Items.IndexOf(lstParent);
            }
        }
        catch
        {
        }
    }

    protected void DisplayInGrid(string  strADA, int MeetingTypeId, int Status_Meeting_RegisterId, DateTime TuNgay, DateTime DenNgay)
    {
        MeetingBO objBO = new MeetingBO();
        List<PRC_USR_AMW_MEETING_REGISTER_GETLIST_UYQUYENResult> lst = new List<PRC_USR_AMW_MEETING_REGISTER_GETLIST_UYQUYENResult>();
        lst = objBO.Meeting_UyQuyen_Search(strADA, MeetingTypeId, Status_Meeting_RegisterId, TuNgay, DenNgay).ToList();
        grdList.DataSource = lst;
        if (lst.Count > 0)
        {
            grdList.PageIndex = 0;
        }
        grdList.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lblAlerting.Text = string.Empty;
        LoadGrid();

    }
    protected void btnXoaTrang_Click(object sender, EventArgs e)
    {
        ClearTextBox();
    }

    private void LoadGrid()
    {
        List<PRC_USR_AMW_MEETING_REGISTER_GETLIST_UYQUYENResult> lst = new List<PRC_USR_AMW_MEETING_REGISTER_GETLIST_UYQUYENResult>();

        grdList.DataSource = lst;
        grdList.DataBind();
        USR_AMW_MEETING_REGISTER obj = new USR_AMW_MEETING_REGISTER();
        if (txtADA.Text.Length<= 0)
        {
            lblAlerting.Text = "Bạn chưa nhập mã ADA!";
            return;
        }
        if (int.Parse(ddlMEETINGTYPEID.SelectedValue) <= 0)
        {
            lblAlerting.Text = "Bạn chưa chọn loại đăng ký hội họp!";
            return;
        }

        DateTime TuNgay;
        DateTime DenNgay;
        try
        {
            TuNgay = DateTime.ParseExact(txtStartDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DenNgay = DateTime.ParseExact(txtStartDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        catch
        {
            TuNgay = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DenNgay = DateTime.ParseExact("01/01/2900", "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        DisplayInGrid(txtADA.Text, int.Parse(ddlMEETINGTYPEID.SelectedValue), int.Parse(ddlSTATUS_MEETING_REGISTERID.SelectedValue), TuNgay, DenNgay);

    }

    protected void btnXuatUyQuyen_Click(object sender, EventArgs e)
    {
        if (txtADA.Text.Length <= 0)
        {
            lblAlerting.Text = "Bạn chưa nhập mã ADA!";
            return;
        }
        if (int.Parse(ddlMEETINGTYPEID.SelectedValue) <= 0)
        {
            lblAlerting.Text = "Bạn chưa chọn loại đăng ký hội họp!";
            return;
        }
        try
        {
            lblAlerting.Text = string.Empty;
            bool check = false;

            for (int i = 0; i < grdList.Rows.Count; i++)
            {
                // Cell 9 la checkbox, cell 10 la textbox
                CheckBox chkSave = ((CheckBox)grdList.Rows[i].Cells[9].FindControl("chkSave"));

                if (chkSave.Checked)
                {
                    check = true;
                    break;
                }
            }
            if (!check)
            {
                lblAlerting.Text = "Không có dữ liệu xuất ủy quyền!";
                return;
            }
            //   
            try
            {
                DataTable dtData = new DataTable();

                DataColumn column4 = new DataColumn();
                column4.DataType = System.Type.GetType("System.String");
                column4.ColumnName = "NGAYHOP";
                dtData.Columns.Add(column4);
                DataColumn column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "MEETINGTYPEID";
                dtData.Columns.Add(column);
                DataColumn column1 = new DataColumn();
                column1.DataType = System.Type.GetType("System.String");
                column1.ColumnName = "DIADIEMHOP";
                dtData.Columns.Add(column1);
                DataColumn column2 = new DataColumn();
                column2.DataType = System.Type.GetType("System.String");
                column2.ColumnName = "SONGUOI";
                dtData.Columns.Add(column2);
                DataColumn column3 = new DataColumn();
                column3.DataType = System.Type.GetType("System.String");
                column3.ColumnName = "PAX";
                dtData.Columns.Add(column3);
                DataColumn column5 = new DataColumn();
                column5.DataType = System.Type.GetType("System.String");
                column5.ColumnName = "ID";
                dtData.Columns.Add(column5);
                DataColumn column55 = new DataColumn();
                column55.DataType = System.Type.GetType("System.String");
                column55.ColumnName = "GIOHOP";
                dtData.Columns.Add(column55);
                
                for (int i = 0; i < grdList.Rows.Count; i++)
                {
                    // Cell 9 la checkbox, cell 10 la textbox
                    CheckBox chkSave = ((CheckBox)grdList.Rows[i].Cells[9].FindControl("chkSave"));
                    if (chkSave.Checked)
                    {
                        DataRow row0 = dtData.NewRow();
                        row0["MEETINGTYPEID"] = ((Label)grdList.Rows[i].Cells[5].FindControl("lblListingMeetingTypeID")).Text;
                        row0["DIADIEMHOP"] = ((Label)grdList.Rows[i].Cells[6].FindControl("lblListingDIADIEMHOP")).Text;                        
                        row0["GIOHOP"] = ((Label)grdList.Rows[i].Cells[3].FindControl("lblListingGIOHOP")).Text;
                        row0["NGAYHOP"] = ((Label)grdList.Rows[i].Cells[4].FindControl("lblListingNGAYHOP")).Text;
                        row0["SONGUOI"] = string.Format("{0:N0}",((Label)grdList.Rows[i].Cells[7].FindControl("lblListingSONGUOI")).Text);
                        row0["ID"] = ((Label)grdList.Rows[i].Cells[10].FindControl("lblListingID")).Text;
                        dtData.Rows.Add(row0);
                    }



                }

                // Neu la Meeting type la ko chi phi - thi kiem tra tiep no phai in 1 phieu ko?
                if (int.Parse(dtData.Rows[0]["MEETINGTYPEID"].ToString()) == 1)
                {
                    if (dtData.Rows.Count > 1)
                    {
                        lblAlerting.Text = "Với loại hội họp này, một phiếu ủy quyền chỉ xuất cho một đơn đăng ký!";
                        return;
                    }
                    else
                    {
                        Export export = new Export();
                        DataTable dTable = new DataTable();
                        MeetingBO obj = new MeetingBO();
                        PRC_USR_AMW_MEETING_REGISTER_GETLISTBYIDResult result = new PRC_USR_AMW_MEETING_REGISTER_GETLISTBYIDResult();
                        result = obj.MeetingGet_ListByID(int.Parse(dtData.Rows[0]["ID"].ToString()));
                        DataColumn column6 = new DataColumn();
                        column6.DataType = System.Type.GetType("System.String");
                        column6.ColumnName = "NEWVALUE";
                        dTable.Columns.Add(column6);

                        DataRow row0 = dTable.NewRow();
                        row0["NEWVALUE"] = result.ID + "/ SA/ " + DateTime.Now.Year.ToString();
                        dTable.Rows.Add(row0);
                        DataRow row1 = dTable.NewRow();
                        row1["NEWVALUE"] = DateTime.Now.Day >= 10 ? DateTime.Now.Day.ToString() : "0" + DateTime.Now.Day.ToString();
                        dTable.Rows.Add(row1);
                        DataRow row2 = dTable.NewRow();
                        row2["NEWVALUE"] = DateTime.Now.Month >= 10 ? DateTime.Now.Month.ToString() : "0" + DateTime.Now.Month.ToString();
                        dTable.Rows.Add(row2);
                        DataRow row3 = dTable.NewRow();
                        row3["NEWVALUE"] = DateTime.Now.Year.ToString();
                        dTable.Rows.Add(row3);
                        DataRow row4 = dTable.NewRow();
                        row4["NEWVALUE"] = result.ORGANIZER_NAME;
                        dTable.Rows.Add(row4);
                        DataRow row5 = dTable.NewRow();
                        row5["NEWVALUE"] = result.ORGANIZER_ADAID;
                        dTable.Rows.Add(row5);
                        DataRow row6 = dTable.NewRow();
                        row6["NEWVALUE"] = result.MEETING_ADDRESS;
                        dTable.Rows.Add(row6);
                        DataRow row7 = dTable.NewRow();
                        row7["NEWVALUE"] = result.MEETING_TIME;
                        dTable.Rows.Add(row7);
                        DataRow row8 = dTable.NewRow();
                        row8["NEWVALUE"] = string.Format("{0:N0}", result.NUMBER_OF_PARTICIPANT);
                        dTable.Rows.Add(row8);
                        DataRow row9 = dTable.NewRow();
                        row9["NEWVALUE"] = result.STR_MEETING_STARTDATE;
                        dTable.Rows.Add(row9);
                        DataRow row10 = dTable.NewRow();
                        row10["NEWVALUE"] = result.STR_MEETING_ENDDATE;
                        dTable.Rows.Add(row10);
                        export.ExportWord(MapPath("~/Template/Word/UQ_KHTCP.doc"), dTable, "_UQ_KHTCP.doc");
                    }
                }
                // Neu la Meeting type la  chi phi - thi kiem tra tiep no phai in 1 phieu hay nhiu phieu?
                if (int.Parse(dtData.Rows[0]["MEETINGTYPEID"].ToString()) == 2)
                {
                    if (dtData.Rows.Count > 1)
                    {
                        bool checkDiaDiem = true;
                        string strDIADIEM = dtData.Rows[0]["DIADIEMHOP"].ToString();
                        // kiem tra xem co cung dia diem to chuc hay ko
                        for (int i = 1; i < dtData.Rows.Count; i++)
                        {
                            if (strDIADIEM!=dtData.Rows[i]["DIADIEMHOP"].ToString())
                            {
                                checkDiaDiem = false;
                                break;
                            }
                        }
                        if (checkDiaDiem)
                        {
                            Export export = new Export();
                            DataTable dtMater = new DataTable();
                            MeetingBO obj = new MeetingBO();
                            PRC_USR_AMW_MEETING_REGISTER_GETLISTBYIDResult result = new PRC_USR_AMW_MEETING_REGISTER_GETLISTBYIDResult();
                            result = obj.MeetingGet_ListByID(int.Parse(dtData.Rows[0]["ID"].ToString()));
                            DataColumn column10 = new DataColumn();
                            column10.DataType = System.Type.GetType("System.String");
                            column10.ColumnName = "YEAR";
                            dtMater.Columns.Add(column10);

                            DataColumn column11 = new DataColumn();
                            column11.DataType = System.Type.GetType("System.String");
                            column11.ColumnName = "MONTH";
                            dtMater.Columns.Add(column11);
                            DataColumn column12 = new DataColumn();
                            column12.DataType = System.Type.GetType("System.String");
                            column12.ColumnName = "DAY";
                            dtMater.Columns.Add(column12);
                            DataColumn column13 = new DataColumn();
                            column13.DataType = System.Type.GetType("System.String");
                            column13.ColumnName = "FULLLNAME";
                            dtMater.Columns.Add(column13);
                            DataColumn column14 = new DataColumn();
                            column14.DataType = System.Type.GetType("System.String");
                            column14.ColumnName = "DIACHI";
                            dtMater.Columns.Add(column14);
                            DataColumn column15 = new DataColumn();
                            column15.DataType = System.Type.GetType("System.String");
                            column15.ColumnName = "ADA";
                            dtMater.Columns.Add(column15);

                            DataRow row = dtMater.NewRow();
                            row["ID"] = dtData.Rows[0]["ID"].ToString();
                            row["YEAR"] = DateTime.Now.Year.ToString();
                            row["MONTH"] = DateTime.Now.Month >= 10 ? DateTime.Now.Month.ToString() : "0" + DateTime.Now.Month.ToString();
                            row["DAY"] = DateTime.Now.Day >= 10 ? DateTime.Now.Day.ToString() : "0" + DateTime.Now.Day.ToString();
                            row["FULLLNAME"] = result.ORGANIZER_NAME;
                            row["DIACHI"] = result.MEETING_ADDRESS;
                            row["ADA"] = result.ORGANIZER_ADAID;
                            dtMater.Rows.Add(row);
                            dtData.TableName = "Detail";
                            dtMater.TableName = "Master";
                            DataTable[] arrTable = { dtData, dtMater};
                            export.ExportExcel(Server.MapPath("~/Template/Excel/UQ_HTCP.xls"), arrTable, "_UQ_HTCP.xls");

                        }
                        else
                        {
                            lblAlerting.Text = "Xuất ủy quyền thất bại, các đơn đăng ký không cùng địa điểm!";
                            return;
                        }
                    }
                    else
                    {
                        Export export = new Export();
                        DataTable dTable = new DataTable();

                        MeetingBO obj = new MeetingBO();
                        PRC_USR_AMW_MEETING_REGISTER_GETLISTBYIDResult result = new PRC_USR_AMW_MEETING_REGISTER_GETLISTBYIDResult();
                        result = obj.MeetingGet_ListByID(int.Parse(dtData.Rows[0]["ID"].ToString()));
                        DataColumn column6 = new DataColumn();
                        column6.DataType = System.Type.GetType("System.String");
                        column6.ColumnName = "NEWVALUE";
                        dTable.Columns.Add(column6);

                        DataRow row0 = dTable.NewRow();
                        row0["NEWVALUE"] = result.ID + "/ SA/ " + DateTime.Now.Year.ToString();
                        dTable.Rows.Add(row0);
                        DataRow row1 = dTable.NewRow();
                        row1["NEWVALUE"] = DateTime.Now.Day >= 10 ? DateTime.Now.Day.ToString() : "0" + DateTime.Now.Day.ToString();
                        dTable.Rows.Add(row1);
                        DataRow row2 = dTable.NewRow();
                        row2["NEWVALUE"] = DateTime.Now.Month >= 10 ? DateTime.Now.Month.ToString() : "0" + DateTime.Now.Month.ToString();
                        dTable.Rows.Add(row2);
                        DataRow row3 = dTable.NewRow();
                        row3["NEWVALUE"] = DateTime.Now.Year.ToString();
                        dTable.Rows.Add(row3);
                        DataRow row4 = dTable.NewRow();
                        row4["NEWVALUE"] = result.ORGANIZER_NAME;
                        dTable.Rows.Add(row4);
                        DataRow row5 = dTable.NewRow();
                        row5["NEWVALUE"] = result.ORGANIZER_ADAID;
                        dTable.Rows.Add(row5);
                        DataRow row6 = dTable.NewRow();
                        row6["NEWVALUE"] = result.MEETING_ADDRESS;
                        dTable.Rows.Add(row6);
                        DataRow row7 = dTable.NewRow();
                        row7["NEWVALUE"] = result.MEETING_TIME;
                        dTable.Rows.Add(row7);
                        DataRow row8 = dTable.NewRow();
                        row8["NEWVALUE"] = result.STR_MEETING_DATE;
                        dTable.Rows.Add(row8);
                        DataRow row9 = dTable.NewRow();
                        row9["NEWVALUE"] = string.Format("{0:N0}", result.NUMBER_OF_PARTICIPANT);
                        dTable.Rows.Add(row9);
                        export.ExportWord(MapPath("~/Template/Word/UQ_HTCP.doc"), dTable, "_UQ_HTCP.doc");
                    }
                }

            }
            catch
            {

                lblAlerting.Text = "Xuất ủy quyền thất bại, bạn vui lòng thử lại!";
                return;
            }

        }
        catch
        {


        }
    }
    private int GetValuePax(int paxId)
    {
        switch (paxId)
        {
            case 2:
                {
                    return 50;
                }
            case 3:
                {
                    return 100;
                }
            case 4:
                {
                    return 500;
                }
            case 5:
                {
                    return 1000;
                }
            case 6:
                {
                    return 2000;
                }
            default:
                return 0;
        }
    }

}