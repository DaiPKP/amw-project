using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Information : System.Web.UI.Page
{
    public Connection con = new Connection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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
                        FCKeditorLich.Value = row["Content"].ToString();
                    }
                    if (row["Code"].ToString().Trim().Equals("ThongTin"))
                    {
                        FCKeditorThongTin.Value = row["Content"].ToString();
                    }
                    if (row["Code"].ToString().Trim().Equals("LienHe"))
                    {
                        FCKeditorLienHe.Value = row["Content"].ToString();
                    }
                }
            }
        }
    }
    protected void btLuuLich_Click(object sender, EventArgs e)
    {
        SqlParameter[] paras = new SqlParameter[2];
        paras[0] = new SqlParameter("@Code", "HuanLuyen");
        paras[1] = new SqlParameter("@Content", FCKeditorLich.Value);
        con.ExcuteNonQuery("sp_update_information", paras);
    }
    protected void btLuuThongTin_Click(object sender, EventArgs e)
    {
        SqlParameter[] paras = new SqlParameter[2];
        paras[0] = new SqlParameter("@Code", "ThongTin");
        paras[1] = new SqlParameter("@Content", FCKeditorThongTin.Value);
        con.ExcuteNonQuery("sp_update_information", paras);
    }
    protected void btLuuTTLienHe_Click(object sender, EventArgs e)
    {
        SqlParameter[] paras = new SqlParameter[2];
        paras[0] = new SqlParameter("@Code", "LienHe");
        paras[1] = new SqlParameter("@Content", FCKeditorLienHe.Value);
        con.ExcuteNonQuery("sp_update_information", paras);
    }
}