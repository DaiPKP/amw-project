<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MonthlyBooking.aspx.cs" Inherits="Manager_MonthlyBooking" %>

<%@ Register Src="~/Manager/UserControl/uc_MonthlyBooking.ascx" TagPrefix="uc1" TagName="uc_MonthlyBooking" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <uc1:uc_MonthlyBooking runat="server" ID="uc_MonthlyBooking" />
</asp:Content>

