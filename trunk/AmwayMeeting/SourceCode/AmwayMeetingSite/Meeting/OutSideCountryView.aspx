﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/Home.master" AutoEventWireup="true"
    CodeFile="OutSideCountryView.aspx.cs" Inherits="Meeting_OutSideCountryView" %>

<%@ Register src="UserControl/uc_OutSideCountryView.ascx" tagname="uc_OutSideCountryView" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="Server">
  
    <uc1:uc_OutSideCountryView ID="uc_OutSideCountryView1" runat="server" />
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBoxLeft" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBoxRight" runat="Server">
</asp:Content>
