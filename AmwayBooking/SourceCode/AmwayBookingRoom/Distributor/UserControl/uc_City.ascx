<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_City.ascx.cs" Inherits="Distributor_UserControl_uc_City" %>
<div style="text-align: center; width: 100%;">
    <div style="text-align: center;">
        <div>
            <br />
            <span class="titleText">Phòng Họp Tại 
                    <asp:Label ID="lbCityName" runat="server" Text=""></asp:Label></span><br />
            <br />
            <hr />
        </div>

        <div style="text-align: center;">
            <asp:ListView ID="listViewRoom" runat="server" GroupItemCount="3">
                <ItemTemplate>
                    <td>
                        <a href="/Distributor/Room.aspx?RoomCode=<%# Eval("RoomCode") %>">
                            <img src='/ImageHandler.ashx?ID=<%#Eval("RoomCode")%>&table=Room&column=RoomCode' width="200px" height="120px" />
                        </a>
                        <br />
                        <span class="spanName">Tên Phòng: </span><span class="spanValue"><%#Eval("RoomName") %></span>
                        <br />
                        <span class="spanName">Địa Điểm: </span><span class="spanValue"><%#Eval("CenterName") %></span>
                        <br />
                        <span class="spanName">Số người: </span><span class="spanValue"><%#Eval("Amount")+ " người" %></span>
                        <br />
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
        </div>
    </div>
</div>
