using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Manager_UserControl_uc_Payment : System.Web.UI.UserControl
{
    public Connection con = new Connection();
    public DataTable data = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lbDay.Text = lbday2.Text = DateTime.Today.Day.ToString();
            lbMonth.Text = lbMonth2.Text = DateTime.Today.Month.ToString();
            lbYear.Text = lbYear2.Text = DateTime.Today.Year.ToString();
            DataTable tb = new DataTable();
            string strQuery = "select * from City where [Status] = 'Y'";
            tb = con.ExcuteQuery(strQuery);
            ddlCity.DataSource = tb;
            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "CityCode";
            ddlCity.DataBind();
        }
    }

    public void MessageBox(string message)
    {
        string scriptstring = "alert('" + message + "');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscript", scriptstring, true);
    }
    protected void btLapPhieuThu_Click(object sender, EventArgs e)
    {
        data.Columns.Add("RoomName", typeof(string));
        data.Columns.Add("Date", typeof(string));
        data.Columns.Add("Time", typeof(string));
        data.Columns.Add("Price", typeof(float));

        string strQuery = "select * from v_Payment where Paid = 'N' and [Status] = 'Y' and CityCode = '" + ddlCity.SelectedValue.ToString() + "' and ADA_ID = '" + txtADAID.Text.Trim() + "' and [Date] >= '" + txtFormDate.Text + "' and [Date] <= '" + txtToDate.Text + "' order by [Date]";
        DataTable tb = new DataTable();
        tb = con.ExcuteQuery(strQuery);
        if (tb.Rows.Count > 0)
        {
            lbADAID.Text = txtADAID.Text.Trim();
            lbDistributor.Text = tb.Rows[0]["ADA_Name"].ToString();
            string strRoomName = "";
            string strDate = "";
            string strTime = "";
            float fPrice;
            foreach (DataRow row in tb.Rows)
            {
                strRoomName = row["RoomName"].ToString().Trim();
                strDate = ((DateTime)row["Date"]).ToString("dd/MM/yyyy");
                strTime = row["Section"].ToString();
                if (strTime.Equals("Ca Sáng"))
                {
                    strTime = "Từ 8 giờ đến 12 giờ";
                }
                if (strTime.Equals("Ca Chiều"))
                {
                    strTime = "Từ 13 giờ đến 17 giờ";
                }
                if (strTime.Equals("Ca Tối"))
                {
                    strTime = "Từ 18 giờ đến 22 giờ";
                }
                fPrice = float.Parse(row["Price"].ToString());
                data.Rows.Add(strRoomName, strDate, strTime, fPrice);
            }
            panelPhieuThu.Visible = true;
            float fTotal = 0;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                fTotal = fTotal + float.Parse(data.Rows[i]["Price"].ToString());
            }
            lbTotal.Text = string.Format("{0:0,0 VNĐ}", fTotal);
            lbCenterName.Text = ddlCity.SelectedItem.Text.Trim();
            repeat.DataSource = data;
            repeat.DataBind();
        }
        else
        {
            panelPhieuThu.Visible = false;
            MessageBox("Không có kết quả phù hợp với điều kiện lập phiếu thu...");
        }
    }
    protected void btPrint_Click(object sender, EventArgs e)
    {
        Session["ctrl"] = panelPhieuThu;
        Page.ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('Print.aspx','PrintMe','height=300px,width=300px,scrollbars=1');</script>");
    }
}