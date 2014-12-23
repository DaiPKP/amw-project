<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageInfo.aspx.cs" Inherits="ManageInfo" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div style="text-align: center; width:100%; height:auto; float:right; font-family:Tahoma; color:#4c4c27; font-size:13px;">
        <div style="width:100%;position:relative; display:table;">
            <span class="titleText">Manage City Information</span><br />
            <img src="/Images/line.gif" /><br />
            <asp:UpdatePanel ID="updateCity" runat="server">
            <ContentTemplate>
            <div>
                <table border="0" style="text-align:left; float:left; width:49%;border:1px; border-style:double; border-color:#4c4c27;">
                    <tr>
                        <td>
                        City Code
                        </td>
                        <td>
                            <asp:TextBox ID="txtCityCode" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        City Name
                        </td>
                        <td>
                            <asp:TextBox ID="txtCityName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        Status
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlStatus" runat="server">
                                <asp:ListItem>Y</asp:ListItem>
                                <asp:ListItem>N</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:right;">
                            <asp:Button ID="btnInsert" runat="server" Text="Insert" BackColor="#4c4c27" 
                Font-Size="12px" ForeColor="White"
                                onclick="btnInsert_Click" />            
                        </td>
                        <td style="text-align:left;">
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" BackColor="#4c4c27" 
                Font-Size="12px" ForeColor="White"
                                onclick="btnUpdate_Click" />
                            <asp:Button ID="btnClear" runat="server" Text="Clear" BackColor="#4c4c27" 
                Font-Size="12px" ForeColor="White"
                                onclick="btnClear_Click" />
                        </td>
                    </tr>
                </table>
                <div style="float:right; width:50%;">
                    <asp:gridview id="gridviewCity" runat="server" autogeneratecolumns="False" 
                        cellpadding="4" datakeynames="citycode" datasourceid="sqldatasourcecity" 
                        backcolor="White" bordercolor="#4c4c27" borderstyle="None" 
                        borderwidth="1px" width="100%" 
                        onselectedindexchanged="gridview1_SelectedIndexChanged">
                        <columns>
                            <asp:commandfield showselectbutton="true" />
                            <asp:boundfield datafield="citycode" headertext="City Code" readonly="true" 
                                sortexpression="citycode"/>
                            <asp:boundfield datafield="cityname" headertext="City Name" 
                                sortexpression="cityname"/>
                            <asp:boundfield datafield="status" headertext="Status" 
                                sortexpression="status"/>
                        </columns>
                        <footerstyle backcolor="#99cccc" forecolor="#003399" />
                        <headerstyle backcolor="#4c4c27" font-bold="true" forecolor="#ccccff" />
                        <pagerstyle backcolor="#99cccc" forecolor="#003399" horizontalalign="left" />
                        <rowstyle backcolor="white" forecolor="#003399" />
                        <selectedrowstyle backcolor="#009999" font-bold="true" forecolor="#ccff99" />
                        <sortedascendingcellstyle backcolor="#edf6f6" />
                        <sortedascendingheaderstyle backcolor="#0d4ac4" />
                        <sorteddescendingcellstyle backcolor="#d6dfdf" />
                        <sorteddescendingheaderstyle backcolor="#002876" />
                    </asp:gridview>
                </div>
            </div>             
            </ContentTemplate>
            </asp:UpdatePanel>                     
        </div>
        <asp:UpdatePanel ID="UpdateCenter" runat="server">
        <ContentTemplate>
            <div style="width:100%;position:relative; display:table;">
                <span class="titleText">Manage Center Information</span><br />
                <img src="/Images/line.gif" /><br />
                <table border="0" style="text-align:left; float:left; width:49%; border:1px; border-style:double; border-color:#4c4c27;">
                    <tr>
                        <td>
                        Center Code
                        </td>
                        <td>
                            <asp:TextBox ID="txtCenterCode" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        Center Name
                        </td>
                        <td>
                            <asp:TextBox ID="txtCenterName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            City
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCenterCity" runat="server">
                            
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        Address
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        Status
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCenterStatus" runat="server">
                                <asp:ListItem>Y</asp:ListItem>
                                <asp:ListItem>N</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:right;">
                            <asp:Button ID="btnInsertCenter" runat="server" Text="Insert" BackColor="#4c4c27" 
                Font-Size="12px" ForeColor="White" onclick="btnInsertCenter_Click" />            
                        </td>
                        <td style="text-align:left;">
                            <asp:Button ID="btnUpdateCenter" runat="server" Text="Update" BackColor="#4c4c27" 
                Font-Size="12px" ForeColor="White" onclick="btnUpdateCenter_Click" />
                            <asp:Button ID="btnClearCenter" runat="server" Text="Clear" BackColor="#4c4c27" 
                Font-Size="12px" ForeColor="White" onclick="btnClearCenter_Click" />
                        </td>
                    </tr>
                </table>
                <div style="float:right; width:50%;">
                    <asp:GridView ID="GridViewCenter" runat="server" AllowSorting="True" 
                        AutoGenerateColumns="False" DataKeyNames="CenterCode" 
                        DataSourceID="SqlDataSourceCenter" BackColor="White" BorderColor="#4c4c27" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        onselectedindexchanged="GridViewCenter_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="CenterCode" HeaderText="Center Code" ReadOnly="True" 
                                SortExpression="CenterCode" />
                            <asp:BoundField DataField="CityCode" HeaderText="City Code" 
                                SortExpression="CityCode" />
                            <asp:BoundField DataField="CenterName" HeaderText="Center Name" 
                                SortExpression="CenterName" />
                            <asp:BoundField DataField="Address" HeaderText="Address" 
                                SortExpression="Address" />
                            <asp:BoundField DataField="Status" HeaderText="Status" 
                                SortExpression="Status" />
                        </Columns>
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <HeaderStyle BackColor="#4c4c27" Font-Bold="True" ForeColor="#CCCCFF" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                        <SortedDescendingHeaderStyle BackColor="#002876" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSourceCenter" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:AmwayBookingRoomDBConnectionString %>" 
                        SelectCommand="SELECT * FROM [Center] where [Status] = 'Y'"></asp:SqlDataSource>
                </div>
            </div>
        </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdateRoom" runat="server">
            <ContentTemplate>
        <div style="width:100%; position:relative; display:table;"">
            <span class="titleText">Manage Information Room</span> <br />
            <img src="/Images/line.gif" />
            <table border="0" style="text-align:left; width:100%; border:1px; border-style:double; border-color:#4c4c27;">
                <tr>
                    <td>
                        Room Code
                    </td>
                    <td>
                        <asp:TextBox ID="txtRoomCode" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td>
                        Room Name
                    </td>
                    <td>
                        <asp:TextBox ID="txtRoomName" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Center
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCenter" runat="server">
                            
                        </asp:DropDownList>
                    </td>
                    <td>
                        Amount
                    </td>
                    <td>
                        <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
                        <asp:NumericUpDownExtender ID="txtAmount_NumericUpDownExtender" runat="server" 
                            Enabled="True" Maximum="1.7976931348623157E+308" 
                            Minimum="0" RefValues="" ServiceDownMethod="" 
                            ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" 
                            TargetButtonUpID="" TargetControlID="txtAmount" Width="200">
                        </asp:NumericUpDownExtender>
                    </td>
                </tr>
                <tr>
                    <td>
                        Price Morning
                    </td>
                    <td>
                        <asp:TextBox ID="txtPriceMorning" runat="server"></asp:TextBox>
                        <asp:NumericUpDownExtender ID="txtPrice_NumericUpDownExtender" runat="server" 
                            Enabled="True" Maximum="1.7976931348623157E+308" 
                            Minimum="0" RefValues="" ServiceDownMethod="" 
                            ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" 
                            TargetButtonUpID="" TargetControlID="txtPriceMorning" Width="200">
                        </asp:NumericUpDownExtender>
                    </td>
                    <td>
                        Price Morning Weekend
                    </td>
                    <td>
                        <asp:TextBox ID="txtPriceWeenkendMorning" runat="server"></asp:TextBox>
                        <asp:NumericUpDownExtender ID="txtPriceWeenkend_NumericUpDownExtender" 
                            runat="server" Enabled="True" Maximum="1.7976931348623157E+308" 
                            Minimum="0" RefValues="" ServiceDownMethod="" 
                            ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" 
                            TargetButtonUpID="" TargetControlID="txtPriceWeenkendMorning" Width="200">
                        </asp:NumericUpDownExtender>
                    </td>
                </tr>
                <tr>
                    <td>
                        Price Afternoon
                    </td>
                    <td>
                        <asp:TextBox ID="txtPriceAfternoon" runat="server"></asp:TextBox>
                        <asp:NumericUpDownExtender ID="NumericUpDownExtender1" runat="server" 
                            Enabled="True" Maximum="1.7976931348623157E+308" 
                            Minimum="0" RefValues="" ServiceDownMethod="" 
                            ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" 
                            TargetButtonUpID="" TargetControlID="txtPriceAfternoon" Width="200">
                        </asp:NumericUpDownExtender>
                    </td>
                    <td>
                        Price Afternoon Weekend
                    </td>
                    <td>
                        <asp:TextBox ID="txtPriceWeekendAfternoon" runat="server"></asp:TextBox>
                        <asp:NumericUpDownExtender ID="NumericUpDownExtender2" 
                            runat="server" Enabled="True" Maximum="1.7976931348623157E+308" 
                            Minimum="0" RefValues="" ServiceDownMethod="" 
                            ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" 
                            TargetButtonUpID="" TargetControlID="txtPriceWeekendAfternoon" Width="200">
                        </asp:NumericUpDownExtender>
                    </td>
                </tr>
                <tr>
                    <td>
                        Price Evening
                    </td>
                    <td>
                        <asp:TextBox ID="txtPriceEvening" runat="server"></asp:TextBox>
                        <asp:NumericUpDownExtender ID="NumericUpDownExtender3" runat="server" 
                            Enabled="True" Maximum="1.7976931348623157E+308" 
                            Minimum="0" RefValues="" ServiceDownMethod="" 
                            ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" 
                            TargetButtonUpID="" TargetControlID="txtPriceEvening" Width="200">
                        </asp:NumericUpDownExtender>
                    </td>
                    <td>
                        Price Evening Weekend
                    </td>
                    <td>
                        <asp:TextBox ID="txtPriceWeekendEvening" runat="server"></asp:TextBox>
                        <asp:NumericUpDownExtender ID="NumericUpDownExtender4" 
                            runat="server" Enabled="True" Maximum="1.7976931348623157E+308" 
                            Minimum="0" RefValues="" ServiceDownMethod="" 
                            ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" 
                            TargetButtonUpID="" TargetControlID="txtPriceWeekendEvening" Width="200">
                        </asp:NumericUpDownExtender>
                    </td>
                </tr>
                <tr>
                    <td>
                        Status
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlRoomStatus" runat="server">
                            <asp:ListItem>Y</asp:ListItem>
                            <asp:ListItem>N</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        Price Booking Monthly
                    </td>
                    <td>
                        <asp:TextBox ID="txtPriceBookingMonthly" runat="server"></asp:TextBox>
                        <asp:NumericUpDownExtender ID="NumericUpDownExtender5" 
                            runat="server" Enabled="True" Maximum="1.7976931348623157E+308" 
                            Minimum="0" RefValues="" ServiceDownMethod="" 
                            ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" 
                            TargetButtonUpID="" TargetControlID="txtPriceBookingMonthly" Width="200">
                        </asp:NumericUpDownExtender>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align:center;">
                        <asp:Button ID="btnInsertRoom" runat="server" Text="Insert" BackColor="#4c4c27" 
                            Font-Size="12px" ForeColor="White"
                            onclick="btnInsertRoom_Click" />
                        <asp:Button ID="btnUpdateRoom" runat="server" Text="Update" BackColor="#4c4c27" 
                            Font-Size="12px" ForeColor="White"
                            onclick="btnUpdateRoom_Click" />
                        <asp:Button ID="btnClearRoom" runat="server" Text="Clear" BackColor="#4c4c27" 
                            Font-Size="12px" ForeColor="White"
                            onclick="btnClearRoom_Click" />
                    </td>
                </tr>
            </table>
            
            <div style="">
                <asp:GridView ID="GridViewRoom" runat="server" AllowSorting="True" 
                    AutoGenerateColumns="False" BackColor="White" BorderColor="#4c4c27" 
                    BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="RoomCode" 
                    DataSourceID="SqlDataSourceRoom" width="100%" 
                    onselectedindexchanged="GridViewRoom_SelectedIndexChanged" >
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="RoomCode" HeaderText="Room Code" ReadOnly="True" 
                            SortExpression="RoomCode" />
                        <asp:BoundField DataField="RoomName" HeaderText="Room Name" 
                            SortExpression="RoomName" />
                        <asp:BoundField DataField="CenterCode" HeaderText="Center Code" 
                            SortExpression="CenterCode" />
                        <asp:BoundField DataField="Amount" HeaderText="Amount" 
                            SortExpression="Amount" />
                        <asp:BoundField DataField="PriceMorning" HeaderText="Price Morning" SortExpression="PriceMorning" />
                        <asp:BoundField DataField="PriceAfternoon" HeaderText="Price Afternoon" SortExpression="PriceAfternoon" />
                        <asp:BoundField DataField="PriceEvening" HeaderText="Price Evening" SortExpression="PriceEvening" />
                        <asp:BoundField DataField="PriceWeekendMorning" HeaderText="Price Morning Weekend" SortExpression="PriceWeekendMorning" />
                        <asp:BoundField DataField="PriceWeekendAfternoon" HeaderText="Price Afternoon Weekend" SortExpression="PriceWeekendAfternoon" />
                        <asp:BoundField DataField="PriceWeekendEvening" HeaderText="Price Evening Weekend" SortExpression="PriceWeekendEvening" />
                        <asp:BoundField DataField="PriceBookingMonthly" HeaderText="Price Booking Monthly" SortExpression="PriceBookingMonthly" />
                        <asp:BoundField DataField="Status" HeaderText="Status"
                            SortExpression="Status" />
                    </Columns>
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#4c4c27" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                    <SortedDescendingHeaderStyle BackColor="#002876" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSourceRoom" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:AmwayBookingRoomDBConnectionString %>" 
                    SelectCommand="SELECT * FROM [Room] where [Status] = 'Y'">
                </asp:SqlDataSource>
            </div>            
        </div><br />
        </ContentTemplate>
        </asp:UpdatePanel> 
    </div><br />
    <asp:SqlDataSource ID="SqlDataSourceCity" runat="server" 
                ConnectionString="<%$ ConnectionStrings:AmwayBookingRoomDBConnectionString %>" 
                SelectCommand="SELECT * FROM [City] where [Status] = 'Y'"></asp:SqlDataSource>  
</asp:Content>

