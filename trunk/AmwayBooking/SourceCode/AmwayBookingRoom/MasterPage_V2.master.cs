using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public Connection con = new Connection();
    public Functions func = new Functions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserID"] != null)
            {
                divLogined.Attributes.Add("style", "display:block;");
                container.Attributes.Add("style", "display:none;");
            }
            else
            {
                divLogined.Attributes.Add("style", "display:none;");
                container.Attributes.Add("style", "display:block;");
            }
        }
    }
}
    