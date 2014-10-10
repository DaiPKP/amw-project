<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/Home.master" AutoEventWireup="true"
    CodeFile="OutSideCountryClone.aspx.cs" Inherits="Meeting_OutSideCountryClone" %>

<%@ Register src="UserControl/uc_OutsideCountryClone.ascx" tagname="uc_OutsideCountryClone" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="Server">
 
    <uc1:uc_OutsideCountryClone ID="uc_OutsideCountryClone1" runat="server" />
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBoxLeft" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBoxRight" runat="Server">
</asp:Content>
