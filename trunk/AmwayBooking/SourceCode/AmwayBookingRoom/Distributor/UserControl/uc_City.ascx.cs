using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Distributor_UserControl_uc_City : System.Web.UI.UserControl
{
    public Connection con = new Connection();
    public string strCityCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        strCityCode = Request.QueryString["CityCode"].ToString();
        if (!IsPostBack)
        {
            DataTable tb = new DataTable();
            string strQuery = "select * from Center b, Room c where c.Status = 'Y' and b.Status = 'Y' and c.CenterCode = b.CenterCode and b.CityCode = '" + strCityCode + "' order by b.CenterName";
            tb = con.ExcuteQuery(strQuery);
            listViewRoom.DataSource = tb;
            listViewRoom.DataBind();
            strQuery = "select CityName from City where CityCode = '" + strCityCode + "'";
            tb = con.ExcuteQuery(strQuery);
            if (tb.Rows.Count > 0)
            {
                lbCityName.Text = tb.Rows[0]["CityName"].ToString();
            }
        }
    }
}