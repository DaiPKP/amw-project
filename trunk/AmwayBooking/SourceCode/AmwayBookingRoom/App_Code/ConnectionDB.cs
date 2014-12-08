using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace SaraWebsite.Controllers
{
    public class ConnectionDB
    {
        String ConStr = "";
        SqlConnection con;
        SqlCommand com;
        SqlDataAdapter da;


        public ConnectionDB()
        {
            ConStr = ConfigurationManager.ConnectionStrings["SaraDBConnectionString"].ConnectionString.ToString();
            con = new SqlConnection();
            con.ConnectionString = ConStr;
            com = con.CreateCommand();
            OpenConn();
        }
        void OpenConn()
        {
            con.Open();
        }
        void CloseConn()
        {
            con.Close();
            con.Dispose();
        }
        public DataTable ExcuteQuery(string str)
        {
            DataTable table = new DataTable();
            string sql = "select * from " + str;
            com.CommandText = sql;
            com.CommandType = CommandType.Text;
            da = new SqlDataAdapter(com);
            da.Fill(table);
            com.Dispose();
            return table;
        }

        public DataTable ExcuteQuerySort(string str, string name)
        {
            DataTable table = new DataTable();
            string sql = "select * from " + str + " order by " + name;
            com.CommandText = sql;
            com.CommandType = CommandType.Text;
            da = new SqlDataAdapter(com);
            da.Fill(table);
            com.Dispose();
            return table;
        }

      
        public bool InsertCategory(string table, string id, string name, string desc)
        {
            bool tam = false;
            SqlDataSource sqldatasource = new SqlDataSource();
            sqldatasource.ConnectionString = ConStr;
            sqldatasource.InsertCommandType = SqlDataSourceCommandType.Text;
            sqldatasource.InsertCommand = "insert into "+ table +" values " +
            "(" + id + ",N'" + name + "','',N'" + desc + "','','1')";
            tam = (sqldatasource.Insert() > 0);
            return tam;
        }

        public bool UpdateCategory(string table, string name, string name_con, string id, string id_con, string desc, string desc_con, string condition, string condition1)
        {
            bool tam = false;
            SqlDataSource sqldatasource = new SqlDataSource();
            sqldatasource.ConnectionString = ConStr;
            sqldatasource.UpdateCommandType = SqlDataSourceCommandType.Text;
            sqldatasource.UpdateCommand = "Update " + table + " set " + name + "='" + name_con + "', " + id + "=" + id_con + ", " + desc + "='" + desc_con + "' where " + condition + "=" + condition1;
            tam = (sqldatasource.Update() > 0);
            return tam;
        }

        public bool InsertType(string name, string desc)
        {
            bool tam = false;
            SqlDataSource sqldatasource = new SqlDataSource();
            sqldatasource.ConnectionString = ConStr;
            sqldatasource.InsertCommandType = SqlDataSourceCommandType.Text;
            sqldatasource.InsertCommand = "insert into Type values " +
            "(N'" + name + "','',N'" + desc + "','','1')";
            tam = (sqldatasource.Insert() > 0);
            return tam;
        }

        public bool UpdateType(string name, string desc, string condition)
        {
            bool tam = false;
            SqlDataSource sqldatasource = new SqlDataSource();
            sqldatasource.ConnectionString = ConStr;
            sqldatasource.UpdateCommandType = SqlDataSourceCommandType.Text;
            sqldatasource.UpdateCommand = "Update Type set Type_Name_Vi=N'" + name + "', Description_Vi=N'" + desc + "' where Type_ID='" + condition + "'";
            tam = (sqldatasource.Update() > 0);
            return tam;
        }

        public bool InsertInventory(string proid, string name, string quality, DateTime date)
        {
            bool tam = false;
            SqlDataSource sqldatasource = new SqlDataSource();
            sqldatasource.ConnectionString = ConStr;
            sqldatasource.InsertCommandType = SqlDataSourceCommandType.Text;
            sqldatasource.InsertCommand = "insert into Inventory values " +
            "(N'" + name + "'," + proid + "," + quality + ", '" + date + "')";
            tam = (sqldatasource.Insert() > 0);
            return tam;
        }

        public bool UpdateInventory(string name, string proid, string quality, DateTime date, string condition)
        {
            bool tam = false;
            SqlDataSource sqldatasource = new SqlDataSource();
            sqldatasource.ConnectionString = ConStr;
            sqldatasource.UpdateCommandType = SqlDataSourceCommandType.Text;
            sqldatasource.UpdateCommand = "Update Inventory set Inventory_id=N'" + name + "', product_id="+ proid+ ", quatity=" + quality + ", date_modified='"+ date + "' where ID='" + condition + "'";
            tam = (sqldatasource.Update() > 0);
            return tam;
        }

        public bool InsertProduct(string subid, string name, string desc, string re, string ws, string sara)
        {
            bool tam = false;
            SqlDataSource sqldatasource = new SqlDataSource();
            sqldatasource.ConnectionString = ConStr;
            sqldatasource.InsertCommandType = SqlDataSourceCommandType.Text;
            sqldatasource.InsertCommand = "insert into Products values " +
            "(" + subid + ", N'" + name + "','',N'" + desc + "',''," + re + "," + ws + "," + sara + ",'1')";
            tam = (sqldatasource.Insert() > 0);
            return tam;
        }

        public bool UpdateProduct(string subid, string name, string desc, string re, string ws, string sara, string condition)
        {
            bool tam = false;
            SqlDataSource sqldatasource = new SqlDataSource();
            sqldatasource.ConnectionString = ConStr;
            sqldatasource.UpdateCommandType = SqlDataSourceCommandType.Text;
            sqldatasource.UpdateCommand = "Update Products set sub_id=" + subid + ", Product_Name_Vi=N'" + 
            name + "', Description_Vi=N'" + desc + "', re_prize=" + re + ", ws_prize=" + ws + ", sara_prize=" + sara +
            " where product_ID='" + condition + "'";
            tam = (sqldatasource.Update() > 0);
            return tam;
        }

        public bool UpdateInvoice(string status, string condition)
        {
            bool tam = false;
            SqlDataSource sqldatasource = new SqlDataSource();
            sqldatasource.ConnectionString = ConStr;
            sqldatasource.UpdateCommandType = SqlDataSourceCommandType.Text;
            sqldatasource.UpdateCommand = "Update Invoice set Status='" + status + "' where Inv_ID='" + condition + "'";
            tam = (sqldatasource.Update() > 0);
            return tam;
        } 

        public bool FuncDelete(string mytable, string id, int id_con)
        {
            bool tam = false;
            SqlDataSource sqldatasource = new SqlDataSource();
            sqldatasource.ConnectionString = ConStr;
            sqldatasource.UpdateCommandType = SqlDataSourceCommandType.Text;
            sqldatasource.UpdateCommand = "update " + mytable + " set status = '0' where " + id + "=" + id_con;
            tam = (sqldatasource.Update() > 0);
            return tam;
        }


        public bool CheckPhone(TextBox textbox)
        {
            return Regex.IsMatch(textbox.Text, "^[0-9()-]+$");
        }

        public bool CheckDate(TextBox textbox)
        {
            return Regex.IsMatch(textbox.Text, "^(?:[0][1-9]|[1][0-2])\\/(?:[0-2][0-9]|[3][0|1])\\/(?:[0-9]{2}|[0-9]{4})$");
        }

        //Load GridView
        public DataTable GetDataTableGridview(string mytable)
        {
            DataTable datatable = new DataTable();
            com = new SqlCommand();
            com.CommandText = mytable;
            com.Connection = con;
            com.CommandType = CommandType.Text;
            da = new SqlDataAdapter(com);
            da.Fill(datatable);
            com.Dispose();
            da.Dispose();
            return datatable;
        }

        public DataTable GetCheckDataTable(string mytable, string colummname, string condition)
        {
            DataTable datatable = new DataTable();
            com = new SqlCommand();
            com.CommandText = "select * from " + mytable + " where " + colummname + "='" + condition + "' and Status = 1";
            com.Connection = con;
            com.CommandType = CommandType.Text;
            da = new SqlDataAdapter(com);
            da.Fill(datatable);
            com.Dispose();
            da.Dispose();
            return datatable;
        }

        public DataTable GetCheckDataTable2(string mytable, string colummname, string condition, string colummname1, string condition1)
        {
            DataTable datatable = new DataTable();
            com = new SqlCommand();
            com.CommandText = "select * from " + mytable + " where " + colummname + "=" + condition + " and " + colummname1 + "='" + condition1 + "'";
            com.Connection = con;
            com.CommandType = CommandType.Text;
            da = new SqlDataAdapter(com);
            da.Fill(datatable);
            com.Dispose();
            da.Dispose();
            return datatable;
        }

        public DataTable GetCheckUpdate(string mytable, string colummname, string condition, string id, string condition1)
        {
            DataTable datatable = new DataTable();
            com = new SqlCommand();
            com.CommandText = "select * from " + mytable + " where " + colummname + "='" + condition + "' and " + id + " not in('" + condition1 + "')";
            com.Connection = con;
            com.CommandType = CommandType.Text;
            da = new SqlDataAdapter(com);
            da.Fill(datatable);
            com.Dispose();
            da.Dispose();
            return datatable;
        }

        public DataTable GetCheckUpdate1(string mytable, string colummname, string condition, string colummname1, string condition1, string id, int condition2)
        {
            DataTable datatable = new DataTable();
            com = new SqlCommand();
            com.CommandText = "select * from " + mytable + " where " + colummname + "=" + condition + " and " + colummname1 + "='" + condition1 + "' and status='1' and " + id + " not in(" + condition2 + ")";
            com.Connection = con;
            com.CommandType = CommandType.Text;
            da = new SqlDataAdapter(com);
            da.Fill(datatable);
            com.Dispose();
            da.Dispose();
            return datatable;
        }

        public DataTable GetCheckUpdate2(string mytable, string colummname, string condition, string colummname1, string condition1, string id, string condition2)
        {
            DataTable datatable = new DataTable();
            com = new SqlCommand();
            com.CommandText = "select * from " + mytable + " where " + colummname + "='" + condition + "' and " + colummname1 + "='" + condition1 + "' and " + id + " not in('" + condition2 + "')";
            com.Connection = con;
            com.CommandType = CommandType.Text;
            da = new SqlDataAdapter(com);
            da.Fill(datatable);
            com.Dispose();
            da.Dispose();
            return datatable;
        }

        public DataTable GetCheckDataTable1(string mytable, string colummname, string condition)
        {
            DataTable datatable = new DataTable();
            com = new SqlCommand();
            com.CommandText = "select * from " + mytable + " where " + colummname + "='" + condition + "'";
            com.Connection = con;
            com.CommandType = CommandType.Text;
            da = new SqlDataAdapter(com);
            da.Fill(datatable);
            com.Dispose();
            da.Dispose();
            return datatable;
        }

        public DataTable GetDataTable(string mytable)
        {
            DataTable datatable = new DataTable();
            com = new SqlCommand();
            com.CommandText = "select * from " + mytable + " where status = '1'";
            com.Connection = con;
            com.CommandType = CommandType.Text;
            da = new SqlDataAdapter(com);
            da.Fill(datatable);
            com.Dispose();
            da.Dispose();
            return datatable;
        }

        public DataTable GetDataTable2(string mytable)
        {
            DataTable datatable = new DataTable();
            com = new SqlCommand();
            com.CommandText = "select * from " + mytable;
            com.Connection = con;
            com.CommandType = CommandType.Text;
            da = new SqlDataAdapter(com);
            da.Fill(datatable);
            com.Dispose();
            da.Dispose();
            return datatable;
        }

        public DataTable GetDataTable1(string mytable, string condi, string condi1)
        {
            DataTable datatable = new DataTable();
            com = new SqlCommand();
            com.CommandText = "select * from " + mytable + " where status = '1' and " + condi + "=" + condi1;
            com.Connection = con;
            com.CommandType = CommandType.Text;
            da = new SqlDataAdapter(com);
            da.Fill(datatable);
            com.Dispose();
            da.Dispose();
            
            return datatable;
        }

    }
}