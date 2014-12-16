using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAL;

public partial class Distributor_UserControl_uc_City : System.Web.UI.UserControl
{
    public Connection con = new Connection();
    public string strCityCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        strCityCode = Request.QueryString["CityCode"].ToString();
        if (!IsPostBack)
        {
            List<SP_GET_ROOMLIST_BY_CITYCODEResult> listRoom = new List<SP_GET_ROOMLIST_BY_CITYCODEResult>();
            CategoryBO BO = new CategoryBO();
            listRoom = BO.SP_GET_ROOMLIST_BY_CITYCODE(strCityCode).ToList();
            listViewRoom.DataSource = listRoom;
            listViewRoom.DataBind();

            List<SP_GET_CITYNAME_BY_CITYCODEResult> listCity = new List<SP_GET_CITYNAME_BY_CITYCODEResult>();
            listCity = BO.GetCityNameByCityCode(strCityCode);
            if (listCity.Count > 0)
            {
                lbCityName.Text = listCity[0].CityName.ToString();
            }
        }
    }
}