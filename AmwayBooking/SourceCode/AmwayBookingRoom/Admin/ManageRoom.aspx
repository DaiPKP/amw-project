<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageRoom.aspx.cs" Inherits="Admin_ManageRoom" %>

<%@ Register Src="~/Admin/UserControl/uc_ManageRoom.ascx" TagPrefix="uc1" TagName="uc_ManageRoom" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <uc1:uc_ManageRoom runat="server" id="uc_ManageRoom" />
</asp:Content>

