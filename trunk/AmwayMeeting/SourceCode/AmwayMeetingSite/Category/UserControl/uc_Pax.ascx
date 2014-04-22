<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Pax.ascx.cs"
    Inherits="Category_UserControl_uc_Pax" %>
<div style="min-height:800px; height: auto">
    <div class="TitlePage">
       PAX</div>
        
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel runat="server" ID="pnlSearch">
                <div style="text-align: left; width: 100%">
                    <fieldset>
                        <table width="100%">
                            <tr>
                                <td class="tdsearch1">
                                </td>
                                <td align="left" class="tdsearch2">
                                    Tên Pax<span style="color: Red">(*)</span>:
                                </td>
                                <td align="left" class="tdsearch3">
                                    <asp:TextBox runat="server" ID="txtPaxName" MaxLength="50" CssClass="txtBox" Width="100%"></asp:TextBox>
                                </td>
                                <td class="tdsearch4">
                                </td>
                                <td align="left" class="tdsearch5">
                                    Ghi chú:
                                </td>
                                <td align="left" class="tdsearch6">
                                    <asp:TextBox runat="server" ID="txtDescription" MaxLength="50" CssClass="txtBox" Width="100%"
                                        TextMode="SingleLine"></asp:TextBox>
                                </td>
                                <td class="tdsearch7">
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin">
                                </td>
                            </tr>
                            <tr>
                                <td class="tdsearch1">
                                </td>
                                <td align="left" class="tdsearch2">
                                    Tình trạng <span style="color: Red">(*)</span>:
                                </td>
                                <td align="left" class="tdsearch3">
                                    <asp:CheckBox ID="chkActive" runat="server" Checked="true" />
                                </td>
                                <td class="tdsearch4">
                                </td>
                                <td align="left" class="tdsearch5">
                                </td>
                                <td align="left" class="tdsearch6">
                                </td>
                                <td class="tdsearch7">
                                </td>
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
                                    &nbsp;&nbsp;
                                    <asp:Button CssClass="btn_admin" ID="btnSave" runat="server" Text="Thêm mới" OnClick="btnSave_Click" />
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
                        <asp:TemplateField HeaderText="Tên Pax">
                            <ItemTemplate>
                                <asp:Label ID="lblListingPaxName" runat="server" Text='<%# Eval("PAXNAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ghi chú">
                            <ItemTemplate>
                                <asp:Label ID="lblListingDescription" runat="server" Text='<%# Eval("DESCRIPTION") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tình trạng" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblListingTinhTrang" runat="server" Text='<%# Eval("TINHTRANG") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Active" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblListingActive" runat="server" Text='<%# Eval("Active") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnListingEdit" runat="server" Text="Sửa" CommandName="Edit"
                                    Font-Underline="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="pager" HorizontalAlign="Right" />
                </asp:GridView>
            </div>
            <asp:HiddenField ID="hdfPaxId" runat="server" />
        </ContentTemplate>
        </asp:UpdatePanel>
</div>
