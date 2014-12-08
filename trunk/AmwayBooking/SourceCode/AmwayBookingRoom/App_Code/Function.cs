using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using System.IO;

namespace SaraWebsite.Controllers
{
    public class Function
    {
        ConnectionDB connect = new ConnectionDB();
        public void LoadDropDown(DropDownList ddl, string table, string selectvalue, string id, string name)
        {
            DataTable tb = new DataTable();
            tb = connect.ExcuteQuery(table);
            ddl.DataSource = tb;
            ddl.DataTextField = name;
            ddl.DataValueField = id;
            ddl.DataBind();
            if (selectvalue != "")
            {
                ddl.SelectedValue = selectvalue;
            }
        }

        public void LoadDropDownSort(DropDownList ddl, string table, string selectvalue, string id, string name)
        {
            DataTable tb = new DataTable();
            tb = connect.ExcuteQuerySort(table, name);
            ddl.DataSource = tb;
            ddl.DataTextField = name;
            ddl.DataValueField = id;
            ddl.DataBind();
            if (selectvalue != "")
            {
                ddl.SelectedValue = selectvalue;
            }
        }

        //Load vo Gridview
        public void LoadDataToGridView(DataTable datatable, GridView gridView)
        {
            if (datatable != null)
            {
                gridView.DataSource = datatable;
            }
            else
                gridView.DataSource = null;
            gridView.DataBind();
        }

        //Load vo dropdown 2 kieu
        public void LoadDataForDropDownList(DropDownList dropDownList, string mytable, string name,
                                                                     string selectedValue, string id)
        {
            DataTable datatable = connect.GetDataTable(mytable);
            if (datatable != null)
            {
                dropDownList.DataSource = datatable;
                dropDownList.DataTextField = name;
                dropDownList.DataValueField = id;
            }
            else
                dropDownList.DataSource = null;
            dropDownList.DataBind();
            if (selectedValue != "")
                dropDownList.SelectedValue = selectedValue;
        }

        public void LoadDataForDropDownList1(DropDownList dropDownList, string mytable, string name,
                                                                     string selectedValue, string id, string condi, string condi1)
        {
            DataTable datatable = connect.GetDataTable1(mytable, condi, condi1);
            if (datatable != null)
            {
                dropDownList.DataSource = datatable;
                dropDownList.DataTextField = name;
                dropDownList.DataValueField = id;
            }
            else
                dropDownList.DataSource = null;
            dropDownList.DataBind();
            if (selectedValue != "")
                dropDownList.SelectedValue = selectedValue;
        }

        public void LoadDataForDropDownList2(DropDownList dropDownList, string mytable, string name,
                                                                     string selectedValue, string id)
        {
            DataTable datatable = connect.GetDataTable2(mytable);
            if (datatable != null)
            {
                DataRow dataRow = datatable.NewRow();
                string firstshow = "";
                firstshow = "All...";
                dataRow[0] = 0;
                dataRow[1] = firstshow;
                datatable.Rows.InsertAt(dataRow, 0);
                dropDownList.DataSource = datatable;
                dropDownList.DataTextField = name;
                dropDownList.DataValueField = id;
            }
            else
                dropDownList.DataSource = null;
            dropDownList.DataBind();
            if (selectedValue != "")
                dropDownList.SelectedValue = selectedValue;
        }
    }
}