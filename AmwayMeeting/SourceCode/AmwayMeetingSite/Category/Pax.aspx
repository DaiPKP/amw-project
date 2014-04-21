<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/Home.master" AutoEventWireup="true" CodeFile="Pax.aspx.cs" Inherits="Category_Pax" %>

<%@ Register src="UserControl/uc_Pax.ascx" tagname="uc_Pax" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <uc1:uc_Pax ID="uc_Pax1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBoxLeft" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBoxRight" Runat="Server">
</asp:Content>

