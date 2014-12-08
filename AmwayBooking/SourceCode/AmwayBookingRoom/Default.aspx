<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Amway Booking Room</title>
    <link href= "Styles/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="wrap">
        <div id="Header">
            <a href="http://www.amway2u.com/c1/main.jsp"><img src="/Images/banner.gif" style="margin-top:-10px; margin-left:70px; border:0px;"/></a>
            <div style="float:right; margin-right:10px; margin-top:-5px;">                
                
            </div>
            <div style="float:left; font-size:12px; text-align:center; width:100%;">
                <a href="http://www.amway2u.com/c1/main.jsp">Amway2u </a>|
                <a href="http://www.phonghopamway.com.vn">Trang Chủ </a>|
                <a href="/Training.aspx"> Lịch Huấn Luyện </a>|
                <a href="/News.aspx"> Thông Tin Mới </a>|
                <asp:LoginView ID="HeadLoginView" runat="server" EnableViewState="false">
                    <AnonymousTemplate>
                        [ <a href="/Account/Login.aspx" ID="HeadLoginStatus" runat="server">Log In</a> ]
                    </AnonymousTemplate>
                    <LoggedInTemplate>
                        Welcome <span class="bold"><asp:LoginName ID="HeadLoginName" runat="server" /></span>!
                        [ <asp:LoginStatus ID="HeadLoginStatus" runat="server" LogoutAction="Redirect" LogoutText="Log Out" LogoutPageUrl="~/"/> ]
                    </LoggedInTemplate>
                </asp:LoginView>
            </div>
            <div style="font-size:11px; margin-left:20px; position:absolute; top:130px;">
                Tổng lượt truy cập:<span style="font-weight:bold;"> <asp:Label ID="lbSum" runat="server" Text=""></asp:Label></span><br />
                Số người đang online:<span style="font-weight:bold;"> <asp:Label ID="lbOnline" runat="server" Text=""></asp:Label></span>
            </div>
        </div>         
        <div id="defaultpage" style="text-align:center;">
        <img src="/Images/line.gif" /><br /><br />
            <span class="titleText">Chọn tỉnh, thành phố bên dưới để xem lịch thuê phòng hội họp</span>
            <asp:ListView ID="listView" runat="server" GroupItemCount="3">
                <ItemTemplate>
                    <td style="text-align:center;">
                        <a href="/City.aspx?CityCode=<%# Eval("CityCode") %>">
                            <img src='/ImageHandler.ashx?ID=<%#Eval("CityCode")%>&table=City&column=CityCode' width="200px" height="120px"/><br /><br />
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("CityName") %>' CssClass="CityName"></asp:Label>
                        </a>
                    </td>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <span>Không có thành phố nào trong danh sách</span>
                </EmptyDataTemplate>
                <LayoutTemplate>
                    <table cellpadding="0" runat="server" id="tblDepartments" cellspacing="30" width="100%">
                        <tr runat="server" id="groupPlaceholder" />
                    </table>
                </LayoutTemplate>
                <GroupTemplate>
                    <tr id="Tr1" runat="server">
                        <td runat="server" id="itemPlaceholder" />
                    </tr>
                </GroupTemplate>
            </asp:ListView>
            
            <%--<asp:UpdatePanel ID="update" runat="server">
            <ContentTemplate>
                <span class="titleText">
                <asp:LinkButton ID="lbtnLich" runat="server" onclick="lbtnLich_Click">Lịch Huấn Luyện</asp:LinkButton></span><br />
                <img src="/Images/line.gif" /><br />
                <asp:Panel ID="panelLich" runat="server" Visible="false">
                    <asp:Label ID="lbLichHuanLuyen" runat="server" Text="Label"></asp:Label><br />
                </asp:Panel>
                <span class="titleText">
                <asp:LinkButton ID="LinkButton1" runat="server" onclick="lbtnLich_Click">Lịch Huấn Luyện</asp:LinkButton></span><br />
                <img src="/Images/line.gif" /><br />
                <asp:Panel ID="panelThongTin" runat="server">
                    <asp:Label ID="lbThongTin" runat="server" Text="Label"></asp:Label>
                </asp:Panel>
            </ContentTemplate>
            </asp:UpdatePanel> --%>  
            <asp:SqlDataSource ID="SqlDataSourceCity" runat="server" 
                ConnectionString="<%$ ConnectionStrings:AmwayBookingRoomConnectionString %>" 
                SelectCommand="SELECT * FROM [City] WHERE ([Status] = @Status) order by CityName">
                <SelectParameters>
                    <asp:Parameter DefaultValue="Y" Name="Status" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <div id="end">
            
            <span class="CopyRight">Copyright © 2012 Amway</span><br />
            <img src="/Images/line.gif" /><br />
            <div style="text-align:left; width:95%;font-size:13px;font-family:Arial; margin-left:30px;">
                <asp:Label ID="lbLienHe" runat="server" Text=""></asp:Label>
            </div>
            <img src="/Images/line.gif" /><br />
            <div style="text-align:center; font-size:13px;">
               <a href="/Manager/BookingRoom.aspx">Booking Room </a>|
               <a href="/Manager/BookingMonthly.aspx"> Booking Monthly </a>|
               <a href="/Manager/BookingWeekly.aspx"> Booking Weekly </a>|
               <a href="/Manager/ManageRejectBooking.aspx"> Manage Rejected Booking </a>|
               <a href="/Manager/Payment.aspx"> Payment </a> <br />
               <a href="/ManageUser/ManageUsers.aspx"> Manage Users </a>|
               <a href="/Admin/ManageInfo.aspx"> Manage Information Room </a>|
               <a href="/Admin/Information.aspx"> Manage Information </a>|
               <a href="/Admin/ReportCost.aspx"> Report by Cost </a>|
               <a href="/Admin/ReportUtilization.aspx"> Report by Utilization </a>|
               <a href="/Account/ChangePassword.aspx"> Change Password </a>
            </div>
            <img src="/Images/line.gif" />
        </div>
    </div>
    </form>
</body>
</html>
