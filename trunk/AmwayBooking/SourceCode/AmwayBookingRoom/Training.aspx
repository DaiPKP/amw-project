<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Training.aspx.cs" Inherits="Training" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div style="text-align:center; width:100%;">
    <div style="text-align:center;"><br />
        <span class="titleText">Lịch Huấn Luyện</span><br /><br />
                <img src="/Images/line.gif" /><br />
    </div>
    <div style="text-align:left; padding-left:10px;">
        <asp:Label ID="lbLichHuanLuyen" runat="server" Text="Label"></asp:Label>
    </div>
</div>
</asp:Content>

