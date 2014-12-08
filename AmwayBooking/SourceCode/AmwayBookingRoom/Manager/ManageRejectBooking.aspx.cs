using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ManageBookingRoom : System.Web.UI.Page
{
    public static string strCode;
    public Connection con = new Connection();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        panel.Visible = true;
        popup.Show();
    }
    protected void Edit(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            txtADAID.Text = row.Cells[2].Text.ToString();
            txtName.Text = row.Cells[3].Text.ToString();
            txtPhone.Text = row.Cells[4].Text.ToString();
            txtEmail.Text = row.Cells[5].Text.ToString();
            txtAddress.Text = row.Cells[6].Text.ToString();
            lbRoomCode.Text = row.Cells[7].Text.ToString();
            lbSection.Text = row.Cells[8].Text.ToString();
            lbDate.Text = row.Cells[1].Text.ToString();
            ddlStatus.Text = row.Cells[9].Text.ToString();
            strCode = row.Cells[10].Text.ToString();
            popup.Show();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        SqlParameter[] paras = new SqlParameter[7];
        paras[0] = new SqlParameter("@ADA_ID", txtADAID.Text.Trim());
        paras[1] = new SqlParameter("@ADA_Name", txtName.Text.Trim());
        paras[2] = new SqlParameter("@Phone", txtPhone.Text.Trim());
        paras[3] = new SqlParameter("@Email", txtEmail.Text.Trim());
        paras[4] = new SqlParameter("@Address", txtAddress.Text.Trim());
        paras[5] = new SqlParameter("@Status", ddlStatus.Text);
        paras[6] = new SqlParameter("@Code", Int16.Parse(strCode));
        con.ExcuteNonQuery("sp_update_registry_room", paras);
        GridView1.DataBind();
        popup.Hide();
    }
}