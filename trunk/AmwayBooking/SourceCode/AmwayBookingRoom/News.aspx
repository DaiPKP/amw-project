<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div style="text-align:center; width:100%;">
    <div style="text-align:center;"><br />
        <span class="titleText">Thông Tin Mới</span><br /><br />
                <img src="/Images/line.gif" /><br />
    </div>
    <div style="text-align:left; padding-left:10px;">
        <asp:Label ID="lbThongTin" runat="server" Text="Label"></asp:Label>
    </div>
</div>
</asp:Content>

