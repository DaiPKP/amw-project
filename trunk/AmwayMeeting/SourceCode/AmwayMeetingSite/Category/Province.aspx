<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/Home.master" AutoEventWireup="true" CodeFile="Province.aspx.cs" Inherits="Category_Province" %>

<%@ Register src="UserControl/uc_Province.ascx" tagname="uc_Province" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" Runat="Server">
   
    <uc1:uc_Province ID="uc_Province1" runat="server" />
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBoxLeft" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBoxRight" Runat="Server">
</asp:Content>

