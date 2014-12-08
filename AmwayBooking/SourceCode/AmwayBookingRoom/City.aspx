<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="City.aspx.cs" Inherits="City" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="text-align: center; width:100%;">
        <div style="text-align: center;">
            <div style="width:800px; float:right;"><br />
                <span class="titleText">Phòng Họp Tại 
                    <asp:Label ID="lbCityName" runat="server" Text=""></asp:Label></span><br /><br />
                <img src="/Images/line.gif" />
            </div>
            
            <div style="text-align:center; width:800px; float:right;" >
                <asp:ListView ID="listViewRoom" runat="server" GroupItemCount="3">
                    <ItemTemplate>
                        <td>
                            <a href="/Room.aspx?RoomCode=<%# Eval("RoomCode") %>">
                                <img src='ImageHandler.ashx?ID=<%#Eval("RoomCode")%>&table=Room&column=RoomCode' width="200px" height="120px" />
                            </a><br />
                            <span class="spanName">Tên Phòng: </span><span class="spanValue"><%#Eval("RoomName") %></span> <br />
                            <span class="spanName">Địa Điểm: </span><span class="spanValue"><%#Eval("CenterName") %></span> <br />
                            <span class="spanName">Số người: </span><span class="spanValue"><%#Eval("Amount")+ " người" %></span> <br />
                            <%--<span class="spanName">Giá Phòng: </span><span class="spanValue"><%#string.Format("{0:0,0 VNĐ}", Eval("PriceMorning")) %></span><br />
                            <span class="spanName">Giá Phòng Cuối Tuần: </span><span class="spanValue"><%#string.Format("{0:0,0 VNĐ}", Eval("PriceWeekendMorning")) %></span>--%>
                        </td>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <span>Không có phòng họp</span>
                    </EmptyDataTemplate>
                    <LayoutTemplate>
                        <table cellpadding="0" runat="server" id="tblDepartments" cellspacing="35" width="100%">
                            <tr runat="server" id="groupPlaceholder" />
                        </table>
                    </LayoutTemplate>
                    <GroupTemplate>
                        <tr id="Tr1" runat="server">
                            <td runat="server" id="itemPlaceholder" />
                        </tr>
                    </GroupTemplate>
                </asp:ListView>
                <asp:SqlDataSource ID="SqlDataSourceRoom" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:AmwayBookingRoomConnectionString %>" 
                    SelectCommand="SELECT * FROM [Room] WHERE (([CityCode] = @CityCode) AND ([Status] = @Status))">
                    <SelectParameters>
                        <asp:QueryStringParameter DefaultValue="HCM" Name="CityCode" 
                            QueryStringField="CityCode" Type="String" />
                        <asp:Parameter DefaultValue="Y" Name="Status" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
        </div>
    </div>
</asp:Content>
