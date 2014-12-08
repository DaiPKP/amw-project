<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default2.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div style="width:100%; margin-left:5px; text-align:center;">
    <span class="titleText">Lịch Huấn Luyện</span><br />
    <img src="/Images/line.gif" /><br />
    <div style="text-align:left;">
        <asp:Label ID="lbLichHuanLuyen" runat="server" Text="Label"></asp:Label><br />
    </div>
    
    <span class="titleText">Thông Tin Mới</span><br />
    <img src="/Images/line.gif" /><br />
    <div style="text-align:left;">
        <asp:Label ID="lbThongTin" runat="server" Text="Label"></asp:Label>
    </div>
    
</div>    
</asp:Content>
