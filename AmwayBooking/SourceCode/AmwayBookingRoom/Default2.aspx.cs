using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    public Connection con = new Connection();
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable tb = new DataTable();
        string strQuery = "select * from Information where [Status] = 'Y'";
        tb = con.ExcuteQuery(strQuery);
        if (tb.Rows.Count > 0)
        {
            foreach (DataRow row in tb.Rows)
            {
                if (row["Code"].ToString().Trim().Equals("HuanLuyen"))
                {
                    lbLichHuanLuyen.Text = row["Content"].ToString();
                }
                if (row["Code"].ToString().Trim().Equals("ThongTin"))
                {
                    lbThongTin.Text = row["Content"].ToString();
                }
            }
        }
    }
}
