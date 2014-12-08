<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReportCost.aspx.cs" Inherits="Reports" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div style="text-align: center; width:100%; height:auto; float:right; font-size:12px; font-family:Tahoma; color:#4c4c27;">
<asp:UpdatePanel ID="update" runat="server">
    <ContentTemplate> 
    <div>
        <span class="titleText">Summary Meeting by Cost Report</span><br />
        <img src="/Images/line.gif" />
    </div>
    <div style="font-size:12px; font-family:Tahoma; color:#4c4c27;">         
        Chọn Thành Phố 
            <asp:DropDownList ID="ddlCity" runat="server" BackColor="#4c4c27" 
                Font-Size="12px" ForeColor="White" AutoPostBack="True" 
                onselectedindexchanged="ddlCity_SelectedIndexChanged">
            </asp:DropDownList>
&nbsp; Chọn Trung Tâm
            <asp:DropDownList ID="ddlCenter" runat="server" BackColor="#4c4c27" 
                Font-Size="12px" ForeColor="White">
            </asp:DropDownList>
<%--&nbsp; Chọn Phòng
            <asp:DropDownList ID="ddlRoom" runat="server" BackColor="#4c4c27" 
                Font-Size="12px" ForeColor="White">
            </asp:DropDownList>--%>
<br /> Từ ngày
        <asp:TextBox ID="txtFromDate" runat="server" BackColor="#4c4c27" 
                Font-Size="12px" ForeColor="White" Style = "Width=100px;"></asp:TextBox>
        <asp:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" 
            Enabled="True" TargetControlID="txtFromDate">
        </asp:CalendarExtender>
&nbsp; Đến ngày
        <asp:TextBox ID="txtToDate" runat="server" BackColor="#4c4c27" 
                Font-Size="12px" ForeColor="White" Style = "Width=100px;"></asp:TextBox>    
        <asp:CalendarExtender ID="txtToDate_CalendarExtender" runat="server" 
            Enabled="True" TargetControlID="txtToDate">
        </asp:CalendarExtender>
&nbsp; Tỉ giá USD
        <asp:TextBox ID="txtExchangeRate" runat="server" BackColor="#4c4c27" 
                Font-Size="12px" ForeColor="White" Style = "Width=100px;">21800</asp:TextBox>            
        <asp:NumericUpDownExtender ID="txtExchangeRate_NumericUpDownExtender" 
            runat="server" Enabled="True" Maximum="1.7976931348623157E+308" 
            Minimum="0" RefValues="" ServiceDownMethod="" 
            ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" 
            TargetButtonUpID="" TargetControlID="txtExchangeRate" Width="150">
        </asp:NumericUpDownExtender>
&nbsp;
            <asp:Button ID="btXemBaoCao" runat="server" Text="Xem Báo Cáo" BackColor="#4c4c27" 
                Font-Size="12px" ForeColor="White" onclick="btXemBaoCao_Click"/>            
        </div>
        <img src="/Images/line.gif" />
        <asp:Panel ID="report" runat="server" Visible="false">
        <table width="100%" border="0" cellpadding="2" cellspacing="0" style="border:1px; border-style:solid; border-color:#4c4c27">        
             <tr style="background-color:#4c4c27; color:White; font-weight:bold;">
                <td style="border-bottom:1px; border-bottom-style:solid; border-bottom-color:White;"></td>
                <td  colspan="6" style="border-bottom:1px; border-bottom-style:solid; border-bottom-color:White;">SESSION</td>
                <td style="border-bottom:1px; border-bottom-style:solid; border-bottom-color:White;"></td>
                <td style="border-bottom:1px; border-bottom-style:solid; border-bottom-color:White;"></td>
                <td  colspan="2" style="border-bottom:1px; border-bottom-style:solid; border-bottom-color:White;">CASH</td>
            </tr>
            <tr style="background-color:#4c4c27; color:White; font-weight:bold;">
                <td></td>
                <td colspan="3">
                    Normal day
                </td>
                <td colspan="3">
                    Weekend 
                </td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr style="background-color:#4c4c27; color:White; font-weight:bold;">
                <td>
                    Room Type
                </td>
                <td>
                    Morning
                </td>
                <td>
                    Afternoom
                </td>
                <td>
                    Evening
                </td>
                <td>
                    Morning
                </td>
                <td>
                    Afternoom
                </td>
                <td>
                    Evening
                </td>
                <td>
                    Total session
                </td>
                <td>
                    % Utilization
                </td>
                <td>
                    VND
                </td>
                <td>
                    USD
                </td>
            </tr>
            <tr style="background-color:#CCCC00; color:Red;">
                <td>
                    Capacity/01 room
                </td>
                <td>
                    <asp:Label ID="lbNonalMorning" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbNomalAfternoon" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbNomalEvening" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbWeekendMorning" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbWeekendAfternoon" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbWeekendEvening" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbTotal" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    
                </td>
                <td>
                    VND
                </td>
                <td>
                    USD
                </td>
            </tr>
        <asp:Repeater ID="repeat" runat="server">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "RoomName")%>
                </td>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "NomalMorning")%>
                </td>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "NomalAfternoon")%>
                </td>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "NomalEvening")%>
                </td>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "WeekendMorning")%>
                </td>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "WeekendAfternoon")%>
                </td>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "WeekendEvening")%>
                </td>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "TotalSession")%>
                </td>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "Utilization") + "%"%>
                </td>
                <td>
                    <%#string.Format("{0:0,0}", DataBinder.Eval(Container.DataItem, "VND"))%>
                </td>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "USD")%>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr style="background-color:#999966; color:White;">
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "RoomName")%>
                </td>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "NomalMorning") + "%"%>
                </td>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "NomalAfternoon") + "%"%>
                </td>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "NomalEvening") + "%"%>
                </td>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "WeekendMorning") + "%"%>
                </td>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "WeekendAfternoon") + "%"%>
                </td>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "WeekendEvening") + "%"%>
                </td>
                <td>
                    <%--<%# DataBinder.Eval(Container.DataItem, "TotalSession")%>--%>
                </td>
                <td>
                    <%--<%# DataBinder.Eval(Container.DataItem, "Utilization") + "%"%>--%>
                </td>
                <td>
                    <%--<%# DataBinder.Eval(Container.DataItem, "VND")%>--%>
                </td>
                <td>
                    <%--<%# DataBinder.Eval(Container.DataItem, "USD")%>--%>
                </td>
            </tr>
        </AlternatingItemTemplate>
        </asp:Repeater>
            <tr style="background-color:#CCCC00; color:Red; font-weight:bold;">
                <td>
                    Total session
                </td>
                <td>
                    <asp:Label ID="lbTotalNomalMorning" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbTotalNomalAfternoon" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbTotalNomalEvening" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbTotalWeekendMorning" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbTotalWeekendAternoon" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbTotalWeekendEvening" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbTotalofTotal" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    
                </td>
                <td>
                    <asp:Label ID="lbTotalVND" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbTotalUSD" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr style="background-color:#339966; color:White;">
                <td>
                    % Utilization 
                </td>
                <td>
                    <asp:Label ID="lbNM" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbNA" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbNE" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbWM" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbWA" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbWE" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    
                </td>
                <td>
                    <asp:Label ID="lbTB" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    
                </td>
                <td>
                   
                </td>
            </tr>    
        </table>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
</div>
</asp:Content>

