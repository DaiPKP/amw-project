<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/Home.master" AutoEventWireup="true" CodeFile="SystemUser.aspx.cs" Inherits="Category_SystemUser" %>

<%@ Register src="UserControl/uc_SystemUser.ascx" tagname="uc_SystemUser" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" Runat="Server">

    <uc1:uc_SystemUser ID="uc_SystemUser1" runat="server" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBoxLeft" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBoxRight" Runat="Server">
</asp:Content>

