<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Room.aspx.cs" Inherits="Room" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:UpdatePanel ID="update" runat="server">
<ContentTemplate>    
    <div style="text-align: center; width:100%; height:auto; float:right; color:#4c4c27; font-size:15px;">
        <div style="text-align: center;"><br />
            <span class="titleText">Thông Tin Phòng Họp 
                <asp:Label ID="lbRoomName" runat="server" Text="Label"></asp:Label></span> <br /><br />
            <img src="/Images/line.gif" /><br />
        </div>
        <div style="text-align: center; width:800px; float:right; border:0px; border-style:double;">
        <table style="text-align:left;" width="100%">
            <tr>
                <td style="font-weight:bold;">Mã phòng:</td>
                <td><asp:Label ID="lbMaPhong" runat="server" Text=""></asp:Label></td>
                <td style="font-weight:bold;">Tên phòng:</td>
                <td><asp:Label ID="lbTenPhong" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td style="font-weight:bold;">Số người:</td>
                <td><asp:Label ID="lbSucChua" runat="server" Text=""></asp:Label></td>
                <td style="font-weight:bold;">Giá thuê theo tháng:</td>
                <td><asp:Label ID="lbGiaThang" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td style="font-weight:bold;">Giá từ thứ 2 đến thứ 6, 8h-12h:</td>
                <td><asp:Label ID="lbGiaPhong" runat="server" Text=""></asp:Label></td>
                <td style="font-weight:bold;">Giá thứ 7 và chủ nhật, 8h-12h:</td>
                <td><asp:Label ID="lbGiaCuoiTuan" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td style="font-weight:bold;">Giá từ thứ 2 đến thứ 6, 13h-17h:</td>
                <td><asp:Label ID="lbGiaChieuThuong" runat="server" Text=""></asp:Label></td>
                <td style="font-weight:bold;">Giá thứ 7 và chủ nhật, 13h-17h:</td>
                <td><asp:Label ID="lbGiaChieuCuoi" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td style="font-weight:bold;">Giá từ thứ 2 đến thứ 6, 18h-22h:</td>
                <td><asp:Label ID="lbGiaToiThuong" runat="server" Text=""></asp:Label></td>
                <td style="font-weight:bold;">Giá thứ 7 và chủ nhật, 18h-22h:</td>
                <td><asp:Label ID="lbGiaToiCuoi" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>        
        <img src="/Images/line.gif" />
        <br />   
        </div>
        <div style="text-align: center; width:800px; float:right; font-family:Tahoma; color:#4c4c27; font-size:12px; font-weight:bold;">
            Chọn tháng&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:DropDownList ID="ddlThang" runat="server" BackColor="#4c4c27" 
                Font-Bold="True" Font-Size="12px" ForeColor="White" Height="20px">
                <asp:ListItem>01</asp:ListItem>
                <asp:ListItem>02</asp:ListItem>
                <asp:ListItem>03</asp:ListItem>
                <asp:ListItem>04</asp:ListItem>
                <asp:ListItem>05</asp:ListItem>
                <asp:ListItem>06</asp:ListItem>
                <asp:ListItem>07</asp:ListItem>
                <asp:ListItem>08</asp:ListItem>
                <asp:ListItem>09</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
            </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp; Chọn năm&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlNam" runat="server" BackColor="#4c4c27" 
                Font-Bold="True" Font-Size="12px" ForeColor="White" Height="20px">
                <asp:ListItem>2012</asp:ListItem>
                <asp:ListItem>2013</asp:ListItem>
                <asp:ListItem>2014</asp:ListItem>
                <asp:ListItem>2015</asp:ListItem>
                <asp:ListItem>2016</asp:ListItem>
                <asp:ListItem>2017</asp:ListItem>
                <asp:ListItem>2018</asp:ListItem>
                <asp:ListItem>2019</asp:ListItem>
                <asp:ListItem>2020</asp:ListItem>
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btXemLich" runat="server" BackColor="#4c4c27" Font-Bold="True" 
                Font-Size="12px" ForeColor="White" Height="20px" onclick="btXemLich_Click" 
                Text="Xem Lịch" />
        </div>
        <br />
        <div style="display:table;">
            <table border="0" width="100%" cellpadding="2" cellspacing="0" Class="borderTable">
            <asp:Repeater ID="repeat" runat="server">
            <HeaderTemplate>
                <tr style="background-color:#4c4c27; color:White;">
                    <th>
                        Ngày
                    </th>
                    <th>
                        Từ 8 giờ đến 12 giờ
                    </th>
                    <th>
                        Từ 13 giờ đến 17 giờ
                    </th>
                    <th>
                        Từ 18 giờ đến 22 giờ
                    </th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
            
                <!--<tr style= "background-color:White;  color:#4c4c27; "> -->
                <tr style= '<%# Eval("Weekend")=="Y"?"background-color:White;  color:red; ":"background-color:White;  color:#4c4c27;" %>'>  
                        
                    <td class="borderTD" style="text-align:right;">
                        <%# DataBinder.Eval(Container.DataItem, "Ngay")%>
                    </td>
                    <td class="borderTD">
                        <%# DataBinder.Eval(Container.DataItem, "Ca1")%>
                    </td>
                    <td class="borderTD">
                        <%# DataBinder.Eval(Container.DataItem, "Ca2")%>
                    </td>
                    <td class="borderTD">
                        <%# DataBinder.Eval(Container.DataItem, "Ca3")%>
                    </td>
                </tr>
            </ItemTemplate>
            </asp:Repeater> 
            </table>
            <br />
        </div>        
    </div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>


