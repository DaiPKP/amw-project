<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/Home.master" AutoEventWireup="true"
    CodeFile="NotSupportCostForeigner.aspx.cs" Inherits="Meeting_NotSupportCostForeigner" %>

<%@ Register src="UserControl/uc_NotSupportCostForeigner.ascx" tagname="uc_NotSupportCostForeigner" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="Server">
   
  
    <uc1:uc_NotSupportCostForeigner ID="uc_NotSupportCostForeigner1" runat="server" />
   
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBoxLeft" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBoxRight" runat="Server">
</asp:Content>
