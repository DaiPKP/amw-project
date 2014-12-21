<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyBooking.aspx.cs" Inherits="Distributor_MyBooking" %>

<%@ Register Src="~/Distributor/UserControl/uc_MyBooking.ascx" TagPrefix="uc1" TagName="uc_MyBooking" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <uc1:uc_MyBooking runat="server" ID="uc_MyBooking" />
</asp:Content>

