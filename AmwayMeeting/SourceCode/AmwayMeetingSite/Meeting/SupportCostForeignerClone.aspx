<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/Home.master" AutoEventWireup="true"
    CodeFile="SupportCostForeignerClone.aspx.cs" Inherits="Meeting_SupportCostForeignerClone" %>

<%@ Register src="UserControl/uc_SupportCostForeignerClone.ascx" tagname="uc_SupportCostForeignerClone" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="Server">
   
    
  
    <uc1:uc_SupportCostForeignerClone ID="uc_SupportCostForeignerClone1" runat="server" />
   
    
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBoxLeft" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBoxRight" runat="Server">
</asp:Content>
