<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_XuatUyQuyen.ascx.cs"
    Inherits="Meeting_UserControl_uc_XuatUyQuyen" %>
<div style="min-height: 800px; height: auto">
    <div class="TitlePage">
        XUẤT ỦY QUYỀN
    </div>
    <script type="text/javascript">
            $(document).ready(function () {
                var objTuNgay = document.getElementById("<%=txtStartDate.ClientID %>");
                var objDenNgay = document.getElementById("<%=txtEndDate.ClientID %>");
                $(objTuNgay).datepicker({
                    showOn: "button",
                    buttonImage: "../images/calendar.gif",
                    buttonImageOnly: true
                }),

                     $(objDenNgay).datepicker({
                         showOn: "button",
                         buttonImage: "../images/calendar.gif",
                         buttonImageOnly: true
                     });
            });
    </script>
    <asp:Panel runat="server" ID="pnlSearch">
        <div style="text-align: left; width: 100%">
            <fieldset>
                <table width="100%">
                    <tr>
                        <td class="tdsearch1"></td>
                        <td align="left" class="tdsearch2">Loại đăng ký hội họp<span style="color: Red">(*)</span>:
                        </td>
                        <td align="left" class="tdsearch3">
                            <asp:DropDownList ID="ddlMEETINGTYPEID" CssClass="txtBox" runat="server" Width="101%" Height="22px">
                            </asp:DropDownList>
                        </td>
                        <td class="tdsearch4"></td>
                        <td align="left" class="tdsearch5">Tình trạng đăng ký:

                        </td>
                        <td align="left" class="tdsearch6">
                            <asp:DropDownList ID="ddlSTATUS_MEETING_REGISTERID" CssClass="txtBox" runat="server" Width="101%" Height="22px">
                            </asp:DropDownList>
                        </td>
                        <td class="tdsearch7"></td>
                    </tr>
                    <tr>
                        <td align="left" class="divClearBothInAdmin"></td>
                    </tr>
                    <tr>
                        <td class="tdsearch1"></td>
                        <td align="left" class="tdsearch2">Đăng ký từ ngày:
                        </td>
                        <td align="left" class="tdsearch3">
                            <asp:TextBox runat="server" ID="txtStartDate" MaxLength="50" CssClass="txtBoxDate" Width="90%"></asp:TextBox>
                        </td>
                        <td class="tdsearch4"></td>
                        <td align="left" class="tdsearch5">Đăng ký đến ngày:
                        </td>
                        <td align="left" class="tdsearch6">
                            <asp:TextBox runat="server" ID="txtEndDate" MaxLength="50" CssClass="txtBoxDate" Width="90%"></asp:TextBox>
                        </td>
                        <td class="tdsearch7"></td>
                    </tr>
                    <tr>
                        <td align="center" colspan="7">
                            <asp:Label ID="lblAlerting" runat="server" CssClass="Alerting"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="7">
                            <asp:Button CssClass="btn_admin" ID="btnSearch" runat="server" Text="Tìm kiếm" OnClick="btnSearch_Click" />&nbsp;&nbsp;
                                    <asp:Button CssClass="btn_admin" ID="btnXuatUyQuyen" runat="server" Text="Xuất Ủy Quyền" OnClick="btnXuatUyQuyen_Click"
                                        />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </asp:Panel>
    <div style="clear: both; height: 10px">
    </div>
    <div id="divUserList">
        <asp:GridView ID="grdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID"
            Width="100%" CssClass="grid" AllowPaging="True"
            PageSize="2000">
            <Columns>  
                <asp:TemplateField HeaderText="Ngày đăng ký">
                    <ItemTemplate>
                        <asp:Label ID="lblListingCREATEDATE" runat="server" Text='<%# Eval("STR_CREATEDATE") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tên pax">
                    <ItemTemplate>
                        <asp:Label ID="lblListingPAXNAME" runat="server" Text='<%# Eval("PAXNAME") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tỉnh thành">
                    <ItemTemplate>
                        <asp:Label ID="lblListingPROVINCENAME" runat="server" Text='<%# Eval("PROVINCENAME") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Giờ họp">
                    <ItemTemplate>
                        <asp:Label ID="lblListingGIOHOP" runat="server" Text='<%# Eval("MEETING_TIME") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ngày họp">
                    <ItemTemplate>
                        <asp:Label ID="lblListingNGAYHOP" runat="server" Text='<%# Eval("STR_MEETING_DATE") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MeetingTypeID" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblListingMeetingTypeID" runat="server" Text='<%# Eval("MEETINGTYPEID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Địa điểm họp">
                    <ItemTemplate>
                        <asp:Label ID="lblListingDIADIEMHOP" runat="server" Text='<%# Eval("MEETING_ADDRESS") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Số người" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblListingSONGUOI" runat="server" Text='<%# Eval("NUMBER_OF_PARTICIPANT") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="PaxID" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblListingPaxID" runat="server" Text='<%# Eval("PAXID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSave" runat="server" Checked="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ID" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblListingID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerStyle CssClass="pager" HorizontalAlign="Right" />
        </asp:GridView>
    </div>
</div>
