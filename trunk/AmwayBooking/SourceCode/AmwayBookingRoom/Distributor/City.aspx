<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="City.aspx.cs" Inherits="Distributor_City" %>

<%@ Register Src="~/Distributor/UserControl/uc_City.ascx" TagPrefix="uc1" TagName="uc_City" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <uc1:uc_City runat="server" ID="uc_City" />
</asp:Content>

