<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/Home.master" AutoEventWireup="true" CodeFile="UserTypeEnhance.aspx.cs" Inherits="Category_UserTypeEnhance" %>

<%@ Register src="UserControl/uc_UserTypeEnhance.ascx" tagname="uc_UserTypeEnhance" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" Runat="Server">
  
    <uc1:uc_UserTypeEnhance ID="uc_UserTypeEnhance1" runat="server" />
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBoxLeft" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBoxRight" Runat="Server">
</asp:Content>

