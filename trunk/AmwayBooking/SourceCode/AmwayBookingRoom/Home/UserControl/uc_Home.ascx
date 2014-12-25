<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Home.ascx.cs" Inherits="Home_UserControl_uc_Home" %>

            <div id="defaultpage" style="text-align: center;">
                <br />
                <span class="titleText">Chọn tỉnh, thành phố bên dưới để xem lịch đăng ký phòng hội họp</span>
                <asp:ListView ID="listView" runat="server" GroupItemCount="3">
                    <ItemTemplate>
                        <td style="text-align: center;">
                            <a href="/Distributor/City.aspx?CityCode=<%# Eval("CityCode") %>">
                                <img src='/ImageHandler.ashx?ID=<%#Eval("CityCode")%>&table=City&column=CityCode' width="200px" height="120px" /><br />
                                <br />
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
                <asp:SqlDataSource ID="SqlDataSourceCity" runat="server"
                    ConnectionString="<%$ ConnectionStrings:AmwayBookingRoomDBConnectionString %>"
                    SelectCommand="SELECT * FROM [City] WHERE ([Status] = @Status) order by CityName">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="Y" Name="Status" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>