using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;



public class Connection
{
    public String ConStr="";
    SqlConnection con;
    SqlCommand com;
    SqlDataAdapter da;

	public Connection()
	{
        ConStr = ConfigurationManager.ConnectionStrings["AmwayBookingRoomDBConnectionString"].ConnectionString.ToString();
        con = new SqlConnection();
        con.ConnectionString = ConStr;
        com = con.CreateCommand();
        OpenConn();
	}
    void OpenConn()
    {
        try
        {
            con.Open();
        }
        catch (Exception)
        {
            SqlConnection.ClearAllPools();
            con.Open();
        }
    }
    void CloseConn()
    {
        con.Close();
        con.Dispose();
    }
    public Boolean ExcuteNonQuery(string proceducename,SqlParameter[] paras)
    {
        Boolean flag = false;
        com.Parameters.Clear();
        try
        {
            com.CommandText = proceducename;
            com.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter para in paras)
            {
                com.Parameters.Add(para);
            }
            com.ExecuteNonQuery();
            com.Dispose();
            flag = true;
        }
        catch(Exception ex)
        {
 
        }
        return flag;
    }
    public int InsertAndGetID(string proceducename, SqlParameter[] paras,string field)
    {
        com.Parameters.Clear();        
        com.CommandText = proceducename;
        com.CommandType = CommandType.StoredProcedure;
        foreach (SqlParameter para in paras)
        {
            com.Parameters.Add(para);
        }
        //com.Parameters.Add(new SqlParameter("@ID_CongTrinh", SqlDbType.TinyInt, 10));
        com.Parameters[field].Direction = ParameterDirection.Output;
        com.ExecuteNonQuery();
        return Int32.Parse(com.Parameters[field].Value.ToString());        
    }
    public DataTable ExcuteQuery(string strQuery)
    {
        DataTable table=new DataTable();
        string sql = strQuery;
        com.CommandText = sql;
        com.CommandType = CommandType.Text;
        da = new SqlDataAdapter(com);
        da.Fill(table);
        com.Dispose();
        return table;
    }
    public DataTable ExcuteQuery(DateTime fromDate, DateTime toDate, string strRoomCode)
    {
        DataTable table = new DataTable();
        com.Parameters.Clear();
        com.CommandType = CommandType.Text;
        com.CommandText = "select * from RegistryRoom where [Date] >= @fromDate and [Date] <= @toDate and RoomCode = @RoomCode and [Status] = 'Y'";
        com.Parameters.Add("@fromDate", SqlDbType.Date);
        com.Parameters.Add("@toDate", SqlDbType.Date);
        com.Parameters.Add("@RoomCode", SqlDbType.NChar, 10);
        com.Parameters["@fromDate"].Value = fromDate.Date;
        com.Parameters["@toDate"].Value = toDate.Date;
        com.Parameters["@RoomCode"].Value = strRoomCode;
        da = new SqlDataAdapter(com);
        da.Fill(table);
        com.Dispose();
        return table;
    }
    public SqlDataReader GetThunbnais(string value, string table, string column)
    {
        SqlDataReader reader;
        string sql = "select Image from " + table + " where " + column + " = '" + value + "'";
        com.CommandText = sql;
        com.CommandType = CommandType.Text;
        reader = com.ExecuteReader();
        com.Dispose();
        return reader;
    }
    public SqlDataReader GetListImages(string Image_ID)
    {
        SqlDataReader reader;
        string sql = "select Image from Images where Image_ID = '" + Image_ID + "'";
        com.CommandText = sql;
        com.CommandType = CommandType.Text;
        reader = com.ExecuteReader();
        com.Dispose();
        return reader;
    }
    public SqlDataReader GetMenu(string querystring)
    {
        SqlDataReader reader;        
        com.CommandText = querystring;
        com.CommandType = CommandType.Text;
        reader = com.ExecuteReader();
        com.Dispose();
        return reader;
    }
    public void UpdateQuery(string value)
    {
        string sql = "update CongTrinh set TrangThai='N' where ID_CongTrinh = " + value;
        com.CommandText = sql;
        com.CommandType = CommandType.Text;
        com.ExecuteNonQuery();
        com.Dispose();
    }
    public void UpdateQuery(string Ten,String MatKhau)
    {
        string sql = "update [User] set MatKhau = '" + MatKhau + "' where Ten = '" + Ten+"'";
        com.CommandText = sql;
        com.CommandType = CommandType.Text;
        com.ExecuteNonQuery();
        com.Dispose();
    }
    public DataTable ExcuteQuery(string tablename, string column, string value)
    {
        DataTable table = new DataTable();
        string sql = "select * from " + tablename + " where " + column + " = " + value+" and TrangThai='Y'";
        com.CommandText = sql;
        com.CommandType = CommandType.Text;
        da = new SqlDataAdapter(com);
        da.Fill(table);
        com.Dispose();
        return table;
    }

    public DataTable QueryPicture(string tablename, string column, string value)
    {
        string sql = "select top 10 * from " + tablename + " where " + column + " = " + value;
        DataTable table = new DataTable();

        com.CommandText = sql;
        com.CommandType = CommandType.Text;
        da = new SqlDataAdapter(com);
        da.Fill(table);
        com.Dispose();
        return table;
    }

    public DataTable QueryPictureM(string tablename, string column, string value)
    {
        string sql = "select * from " + tablename + " where " + column + " = " + value;
        DataTable table = new DataTable();

        com.CommandText = sql;
        com.CommandType = CommandType.Text;
        da = new SqlDataAdapter(com);
        da.Fill(table);
        com.Dispose();
        return table;
    }

    public DataTable QueryInfo(String value)
    {
        string sql = "select Ten_DichVu,ChuDauTu,DiaDiem,YTuong from CongTrinh,DichVu where DichVu.ID_DichVu=CongTrinh.ID_DichVu and CongTrinh.ID_CongTrinh= "+ value;
        DataTable table = new DataTable();

        com.CommandText = sql;
        com.CommandType = CommandType.Text;
        da = new SqlDataAdapter(com);
        da.Fill(table);
        com.Dispose();
        return table;
    }
    
    public void DeleteQuery(string id)
    {
        string sql = "delete Hinh where ID_Hinh = " + id;
        com.CommandText = sql;
        com.CommandType = CommandType.Text;
        com.ExecuteNonQuery();
        com.Dispose();
    }

    internal DataTable ExcuteQuery(DataTable table)
    {
        throw new NotImplementedException();
    }
}
