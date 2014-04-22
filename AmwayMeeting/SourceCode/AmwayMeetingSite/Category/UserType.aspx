<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/Home.master" AutoEventWireup="true" CodeFile="UserType.aspx.cs" Inherits="Category_UserType" %>

<%@ Register src="UserControl/uc_UserType.ascx" tagname="uc_UserType" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" Runat="Server">
   
 
   
    <uc1:uc_UserType ID="uc_UserType1" runat="server" />
   
 
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBoxLeft" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBoxRight" Runat="Server">
</asp:Content>

