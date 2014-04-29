<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/Home.master" AutoEventWireup="true"
    CodeFile="OutSideCountry.aspx.cs" Inherits="Meeting_OutSideCountry" %>

<%@ Register src="UserControl/uc_OutSideCountry.ascx" tagname="uc_OutSideCountry" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="Server">
 
    <uc1:uc_OutSideCountry ID="uc_OutSideCountry1" runat="server" />
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBoxLeft" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBoxRight" runat="Server">
</asp:Content>
