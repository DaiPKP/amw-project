<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/Home.master" AutoEventWireup="true"
    CodeFile="SupportCostForeigner.aspx.cs" Inherits="Meeting_SupportCostForeigner" %>

<%@ Register src="UserControl/uc_SupportCostForeigner.ascx" tagname="uc_SupportCostForeigner" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="Server">
   
    
  
    <uc1:uc_SupportCostForeigner ID="uc_SupportCostForeigner1" runat="server" />
   
    
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBoxLeft" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBoxRight" runat="Server">
</asp:Content>
