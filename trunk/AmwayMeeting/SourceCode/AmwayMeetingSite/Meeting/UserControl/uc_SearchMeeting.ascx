<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_SearchMeeting.ascx.cs"
    Inherits="Meeting_UserControl_uc_SearchMeeting" %>
<div style="min-height: 800px; height: auto">
    <div class="TitlePage">
        TRA CỨU ĐĂNG KÝ HỘI HỌP
    </div>
    <asp:Panel runat="server" ID="pnlSearch">
        <div style="text-align: left; width: 100%">
            <fieldset>
                <table width="100%">
                    <tr>
                        <td class="tdsearch1"></td>
                        <td align="left" class="tdsearch2">Mã số ADA:
                        </td>
                        <td align="left" class="tdsearch3">
                            <asp:TextBox runat="server" ID="txtADA" MaxLength="50" CssClass="txtBox" Width="100%"></asp:TextBox>
                        </td>
                        <td class="tdsearch4"></td>
                        <td align="left" class="tdsearch5">
                            Pax:
                        </td>
                        <td align="left" class="tdsearch6">
                           <asp:DropDownList ID="ddlPAXID" CssClass="txtBox" runat="server" Width="140px" Height="22px">
                            </asp:DropDownList>
                        </td>
                        <td class="tdsearch7"></td>
                    </tr>
                    <tr>
                        <td align="left" class="divClearBothInAdmin"></td>
                    </tr>
                    <tr>
                        <td class="tdsearch1"></td>
                        <td align="left" class="tdsearch2">Loại đăng ký hội họp:
                        </td>
                        <td align="left" class="tdsearch3">
                            <asp:DropDownList ID="ddlMEETINGTYPEID" CssClass="txtBox" runat="server" Width="140px" Height="22px">
                            </asp:DropDownList>
                        </td>
                        <td class="tdsearch4"></td>
                        <td align="left" class="tdsearch5">Tình trạng đăng ký:

                        </td>
                        <td align="left" class="tdsearch6">
                            <asp:DropDownList ID="ddlSTATUS_MEETING_REGISTERID" CssClass="txtBox" runat="server" Width="140px" Height="22px">
                            </asp:DropDownList>
                        </td>
                        <td class="tdsearch7"></td>
                    </tr>
                    <tr>
                        <td align="left" class="divClearBothInAdmin"></td>
                    </tr>
                    <tr>
                        <td class="tdsearch1"></td>
                        <td align="left" class="tdsearch2">Tỉnh thành:
                        </td>
                        <td align="left" class="tdsearch3">
                             <asp:DropDownList ID="ddlPROVINCEID" CssClass="txtBox" runat="server" Width="140px" Height="22px">
                            </asp:DropDownList>
                        </td>
                        <td class="tdsearch4"></td>
                        <td align="left" class="tdsearch5">
                        </td>
                        <td align="left" class="tdsearch6">Quận huyện
                            <asp:DropDownList ID="ddlDISTRICTID" CssClass="txtBox" runat="server" Width="140px" Height="22px">
                            </asp:DropDownList>
                        </td>
                        <td class="tdsearch7"></td>
                    </tr>
                    <tr>
                        <td align="left" class="divClearBothInAdmin"></td>
                    </tr>
                    <tr>
                        <td class="tdsearch1"></td>
                        <td align="left" class="tdsearch2">Người nước ngoài:
                                  
                        </td>
                        <td align="left" class="tdsearch3">
                            <asp:DropDownList ID="ddlForeigner" CssClass="txtBox" runat="server" Width="140px" Height="22px">
                                <asp:ListItem Value="-1">--Tất cả--</asp:ListItem>
                                <asp:ListItem Value="0">Có</asp:ListItem>
                                <asp:ListItem Value="1">Không</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="tdsearch4"></td>
                        <td align="left" class="tdsearch5">Báo cáo:
                        </td>
                        <td align="left" class="tdsearch6">
                           <asp:DropDownList ID="ddlReport" CssClass="txtBox" runat="server" Width="140px" Height="22px">
                                <asp:ListItem Value="-1">--Tất cả--</asp:ListItem>
                                <asp:ListItem Value="0">Có</asp:ListItem>
                                <asp:ListItem Value="1">Không</asp:ListItem>
                            </asp:DropDownList>
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
                                    <asp:Button CssClass="btn_admin" ID="btnXoaTrang" runat="server" Text="Xóa trắng"
                                        OnClick="btnXoaTrang_Click" />
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
            PageSize="20" OnRowEditing="grdList_RowEditing" OnPageIndexChanging="grdList_PageIndexChanging">
            <Columns>
                 <asp:TemplateField HeaderText="Loại đăng ký hộp họp">
                    <ItemTemplate>
                        <asp:Label ID="lblListingMEETINGTYPENAME" runat="server" Text='<%# Eval("MEETINGTYPENAME") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mã số ADA">
                    <ItemTemplate>
                        <asp:Label ID="lblListingORGANIZER_ADAID" runat="server" Text='<%# Eval("ORGANIZER_ADAID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Họ tên người đăng ký">
                    <ItemTemplate>
                        <asp:Label ID="lblListingORGANIZER_NAME" runat="server" Text='<%# Eval("ORGANIZER_NAME") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
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
                  <asp:TemplateField HeaderText="Quận huyện">
                    <ItemTemplate>
                        <asp:Label ID="lblListingDISTRICTNAME" runat="server" Text='<%# Eval("DISTRICTNAME") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tình trạng">
                    <ItemTemplate>
                        <asp:Label ID="lblListingTinhTrang" runat="server" Text='<%# Eval("STATUS_MEETING_REGISTERNAME") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnListingEdit" runat="server" Text="Xem" CommandName="Edit"
                            Font-Underline="false" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerStyle CssClass="pager" HorizontalAlign="Right" />
        </asp:GridView>
    </div>
    <asp:HiddenField ID="hdfId" runat="server" />
</div>
