using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DAL;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public Connection con = new Connection();
    public Functions func = new Functions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CategoryBO BO = new CategoryBO();
            List<SP_CITY_GET_CBOResult> listCity = new List<SP_CITY_GET_CBOResult>();
            listCity = BO.GetCity();
            listView.DataSource = listCity;
            listView.DataBind();

            List<SP_GET_INFORMATIONResult> listInfo = new List<SP_GET_INFORMATIONResult>();
            listInfo = BO.GetInformation();
            if (listInfo.Count > 0)
            {
                foreach (SP_GET_INFORMATIONResult row in listInfo)
                {
                    if (row.Code.ToString().Trim().Equals("LienHe"))
                    {
                        lbLienHe.Text = row.Content.ToString();
                    }
                }
            }
            lbSum.Text = "  " + func.ReadXML("~/Count.xml").ToString();
            lbOnline.Text = "  " + Application.Get("demOnline").ToString();
        }
    }
}
