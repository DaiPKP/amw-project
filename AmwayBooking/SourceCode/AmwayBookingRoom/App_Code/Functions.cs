using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;


class CartItem
{
    public string strProductID;
    public string strProductName;
    public int iPrice;
    public int iAmount;
    public CartItem(string ProductID, string ProductName, int Price, int Amount)
    {
        strProductID = ProductID;
        strProductName = ProductName;
        iPrice = Price;
        iAmount = Amount;
    }
}
public class Functions
{
    public ArrayList listCart = new ArrayList();
    Connection con = new Connection();
	public Functions()
	{
		
	}
    public string AddCart(string ProductID,string Role)
    {
        CartItem item = null;
        Boolean checkExist = false;
        string strResult = "";
        for (int i = 0; i < listCart.Count; i++)
        {
            item = (CartItem)listCart[i];
            if (item.strProductID.Equals(ProductID))
            {
                checkExist = true;
                break;
            }
        }
        if (checkExist)
        {
            strResult = "Sản phẩm đã tồn tại trong giỏ hàng...";
        }
        else
        {
            string strQuery = "select a.Product_ID,a.Product_Name_Vi,a.Product_Name_En,a.RE_Prize,a.WS_Prize,a.Sara_Prize from Products a where a.Product_ID = " + ProductID;
            DataTable data = con.ExcuteQuery(strQuery);
            if (data.Rows.Count > 0)
            {
                int iPrice = 0;
                if(Role.Equals("Wholesaler"))
                {
                    iPrice = Int32.Parse(data.Rows[0]["WS_Prize"].ToString());
                }
                else
                {
                    iPrice = Int32.Parse(data.Rows[0]["Sara_Prize"].ToString());
                }
                item = new CartItem(data.Rows[0]["Product_ID"].ToString(), data.Rows[0]["Product_Name_Vi"].ToString(), iPrice, 1);
                listCart.Add(item);
            }
            strResult = "Thêm sản phẩm vào giỏ hàng thành công...";
        }
        return strResult;
    }
    public DataTable ConvertToDataTable()
    {
        DataTable table = new DataTable();
        table.Columns.Add("STT", System.Type.GetType("System.String"));
        table.Columns.Add("Product_ID", System.Type.GetType("System.String"));
        table.Columns.Add("Product_Name", System.Type.GetType("System.String"));
        table.Columns.Add("Amount", System.Type.GetType("System.String"));
        table.Columns.Add("Price", System.Type.GetType("System.String"));
        table.Columns.Add("TotalMoney", System.Type.GetType("System.String"));

        CartItem item = null;
        DataRow RowItem;
        for (int i = 0; i < listCart.Count; i++)
        {
            item = (CartItem)listCart[i];
            RowItem = table.NewRow();
            RowItem["STT"] = i + 1;
            RowItem["Product_ID"] = item.strProductID;
            RowItem["Product_Name"] = item.strProductName;
            RowItem["Amount"] = item.iAmount;
            RowItem["Price"] = string.Format("{0:0,0 VNĐ}", item.iPrice);
            RowItem["TotalMoney"] = string.Format("{0:0,0 VNĐ}", item.iPrice * item.iAmount);
            table.Rows.Add(RowItem);
        }
        return table;
    }
    public void UpdateListCart(string ID, int Amount)
    {
        CartItem item = null;
        for (int i = 0; i < listCart.Count; i++)
        {
            item = (CartItem)listCart[i];
            if(item.strProductID.Equals(ID))
            {
                item.iAmount = Amount;
                break;
            }
        }
    }
    public void RemoveItem(string ID)
    {
        CartItem item = null;
        for (int i = 0; i < listCart.Count; i++)
        {
            item = (CartItem)listCart[i];
            if (item.strProductID.Equals(ID))
            {
                listCart.RemoveAt(i);
                break;
            }
        }
    }
    public void RemoveAll()
    {
        listCart.Clear();
    }
    public int TotalMonney()
    {
        int itotal = 0;
        CartItem item = null;
        for (int i = 0; i < listCart.Count; i++)
        {
            item = (CartItem)listCart[i];
            itotal = itotal + (item.iAmount * item.iPrice);
        }
        return itotal;
    }
    public void OrderCart(string User_Name,string Delivery_Add)
    {
        SqlParameter[] para = new SqlParameter[6];        
        para[0] = new SqlParameter("@User_Name", User_Name);
        para[1] = new SqlParameter("@Date",DateTime.Now);
        para[2] = new SqlParameter("@Delivery_Add",Delivery_Add);
        para[3] = new SqlParameter("@Total",TotalMonney());
        para[4] = new SqlParameter("@Status", "Pending");
        para[5] = new SqlParameter("@Inv_ID",SqlDbType.TinyInt, 10);        
        CartItem item = null;
        int iInv_ID = con.InsertAndGetID("sp_InsertInvoice", para, "@Inv_ID");
        for (int i=0; i < listCart.Count; i++)
        {
            item = (CartItem)listCart[i];
            SqlParameter[] paras = new SqlParameter[5];
            paras[0] = new SqlParameter("@Inv_ID", iInv_ID);
            paras[1] = new SqlParameter("@Date_Modified", DateTime.Now);
            paras[2] = new SqlParameter("@Product_ID", item.strProductID);
            paras[3] = new SqlParameter("@Quantity", item.iAmount);
            paras[4] = new SqlParameter("@Total", item.iPrice*item.iAmount);
            con.ExcuteNonQuery("sp_Insert_Invoice_Detail", paras);
        }
    }
    public string LoadMenu()
    {
        string strMenu = "";
        SqlDataAdapter adapterType = new SqlDataAdapter("select * from Type where Status = 1", con.ConStr);
        SqlDataAdapter adapterCat = new SqlDataAdapter("select * from Category where Status = 1", con.ConStr);
        SqlDataAdapter adapterSubCat = new SqlDataAdapter("select * from SubCategory where Status = 1", con.ConStr);
        DataSet ds = new DataSet();
        adapterType.Fill(ds, "Type");
        adapterCat.Fill(ds, "Category");
        adapterSubCat.Fill(ds, "SubCategory");
        DataColumn colType = ds.Tables["Type"].Columns["Type_ID"];
        DataColumn colCatType = ds.Tables["Category"].Columns["Type_ID"];
        DataColumn colCatSub = ds.Tables["Category"].Columns["Cate_ID"];
        DataColumn colSubCat = ds.Tables["SubCategory"].Columns["Cate_ID"];
        DataRelation relTypeCat = new DataRelation("Type_Category", colType, colCatType,false);
        DataRelation relCateSub = new DataRelation("Category_SubCategory", colCatSub, colSubCat,false);
        ds.Relations.Add(relTypeCat);
        ds.Relations.Add(relCateSub);
        strMenu = "<div id= mainNav><ul id = nav>";
        foreach (DataRow TypeRow in ds.Tables["Type"].Rows)
        {
            strMenu += "<li><div class = \"DefaultStyle\" onmouseover=\"this.className='HoverStyle'\" onmouseout=\"this.className='DefaultStyle'\"><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"ProductType.aspx?ProductTypeID=" + TypeRow["Type_ID"].ToString() + "\">";
            strMenu += TypeRow["Type_Name_Vi"].ToString() + "</a></div>";
            DataRow[] CateRows = TypeRow.GetChildRows("Type_Category");
            if (CateRows.Length > 0)
            {
                strMenu += "<ul>";
                foreach (DataRow CateRow in CateRows)
                {
                    strMenu += "<li><div class = \"DefaultStyle\" onmouseover=\"this.className='HoverStyle'\" onmouseout=\"this.className='DefaultStyle'\"><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"ProductCate.aspx?ProductCateID=" + CateRow["Cate_ID"].ToString() + "\">" + CateRow["Cate_Name_Vi"].ToString() + "</a></div>";
                    DataRow[] SubCateRows = CateRow.GetChildRows("Category_SubCategory");
                    if (SubCateRows.Length > 0)
                    {
                        strMenu += "<ul>";
                        foreach (DataRow SubCateRow in SubCateRows)
                        {
                            strMenu += "<li><div class = \"DefaultStyle\" onmouseover=\"this.className='HoverStyle'\" onmouseout=\"this.className='DefaultStyle'\"><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"ProductSub.aspx?ProductSubID=" + SubCateRow["Sub_ID"].ToString() + "\">" + SubCateRow["Sub_Name_Vi"].ToString() + "</a></div></li>";
                        }
                        strMenu += "</ul>";
                    }
                    strMenu += "</li>";
                }
                strMenu += "</ul>";
            }
            strMenu += "</li>";
        }
        strMenu += "</ul></div>";        
        return strMenu;
    }
    public string ReadXML(string path)
    {
        string str = "";
        string file = HttpContext.Current.Server.MapPath(path);
        XmlTextReader reader = new XmlTextReader(file);
        reader.Read();
        reader.ReadStartElement("TongTruyCap");

        str = reader.ReadElementString("Tong").ToString();
        reader.Close();
        return str;
    }
    public void Write(string path, int sum)
    {

        string file = HttpContext.Current.Server.MapPath(path);
        XmlTextWriter writer = new XmlTextWriter(file, null);
        sum++;
        writer.WriteStartDocument();
        writer.WriteComment("Created @ :" + DateTime.Now.ToString());
        writer.WriteStartElement("TongTruyCap");
        writer.WriteElementString("Tong", sum.ToString());
        writer.WriteEndElement();
        writer.Close();
    }
}