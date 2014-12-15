<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewBooking.aspx.cs" Inherits="Manager_ViewBooking" %>

<%@ Register Src="~/Manager/UserControl/uc_ViewBooking.ascx" TagPrefix="uc1" TagName="uc_ViewBooking" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <uc1:uc_ViewBooking runat="server" ID="uc_ViewBooking" />
</asp:Content>

