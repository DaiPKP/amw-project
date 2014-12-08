<%@ WebHandler Language="C#" Class="ImageHandler" %>

using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class ImageHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) 
    {
        
        Connection connect = new Connection();
        SqlDataReader reader = null;
        string strTable = context.Request.QueryString["table"].ToString();
        string strColumn = context.Request.QueryString["column"].ToString();
        string strValue = context.Request.QueryString["ID"].ToString();
        if (strTable.Equals("detail"))
        {
            reader = connect.GetListImages(context.Request.QueryString["ID"]);
        }
        else
        {
            reader = connect.GetThunbnais(strValue, strTable, strColumn);
        }
        
        while (reader.Read())
        {
            context.Response.ContentType = "Image/jpg";
            context.Response.BinaryWrite((byte[])reader["Image"]);
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}