<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/Home.master" AutoEventWireup="true"
    CodeFile="XuatUyQuyen.aspx.cs" Inherits="Meeting_XuatUyQuyen" %>

<%@ Register src="UserControl/uc_XuatUyQuyen.ascx" tagname="uc_XuatUyQuyen" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="Server">
  
    <uc1:uc_XuatUyQuyen ID="uc_XuatUyQuyen1" runat="server" />
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBoxLeft" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBoxRight" runat="Server">
</asp:Content>
