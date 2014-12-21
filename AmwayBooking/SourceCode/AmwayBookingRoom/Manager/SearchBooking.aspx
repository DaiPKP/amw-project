<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SearchBooking.aspx.cs" Inherits="Manager_SearchBooking" %>

<%@ Register Src="~/Manager/UserControl/uc_SearchBooking.ascx" TagPrefix="uc1" TagName="uc_SearchBooking" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <uc1:uc_SearchBooking runat="server" ID="uc_SearchBooking" />
</asp:Content>

