<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="WeeklyBooking.aspx.cs" Inherits="Manager_WeeklyBooking" %>

<%@ Register Src="~/Manager/UserControl/uc_WeeklyBooking.ascx" TagPrefix="uc1" TagName="uc_WeeklyBooking" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <uc1:uc_WeeklyBooking runat="server" ID="uc_WeeklyBooking" />
</asp:Content>
