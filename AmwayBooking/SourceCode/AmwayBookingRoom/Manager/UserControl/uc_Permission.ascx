<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Permission.ascx.cs"
    Inherits="Manager_UserControl_uc_Permission" %>
<div style="min-height:800px; height: auto">
    <div class="TitlePage">
        PHÂN QUYỀN CHỨC NĂNG</div>
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
                                    Nhóm người dùng <span style="color: Red">(*)</span>:
                                </td>
                                <td align="left" class="tdsearch3">
                                    <asp:DropDownList ID="ddlDEPARTMENTID" CssClass="txtBox" runat="server" Width="100%">
                                    </asp:DropDownList>
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
                                    <asp:Button CssClass="btn_admin" ID="btnSave" runat="server" Text="Lưu" OnClick="btnSave_Click" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
            </asp:Panel>
            <div style="clear: both; height: 10px">
            </div>
            <div id="divPermissionList">
                <asp:Repeater ID="repPermissionList" runat="server">
                    <HeaderTemplate>
                        <table cellspacing="0" border="1" style="width: 100%; border-collapse: collapse;
                            margin: 5px 0;">
                            <tr class="trper">
                                <th scope="col" class="thper" style="width: 400px">
                                    Tên chức năng cha
                                </th>
                                <th scope="col" class="thper" style="width: 400px">
                                    Tên chức năng con
                                </th>
                                <th scope="col" class="thper">
                                </th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="trper" style="background-color: #BCD7B4">
                            <td class="tdper" scope="col" colspan="3">
                                <%# DataBinder.Eval(Container.DataItem, "MENUNAME") %>
                                <asp:HiddenField ID="hdfMenuChaID" Value='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                    runat="server" />
                            </td>
                        </tr>
                        <asp:Repeater ID="repPermissionDetail" runat="server">
                            <ItemTemplate>
                                <tr class="trper">
                                    <td class="tdper" scope="col">
                                    </td>
                                    <td scope="col" class="tdper">
                                        <%# DataBinder.Eval(Container.DataItem, "MENUNAME") %>
                                        <asp:HiddenField ID="hdfMenuID" Value='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                            runat="server" />
                                    </td>
                                    <td align="center" class="tdper" scope="col">
                                        <asp:CheckBox ID="chkSelectMenu" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "CHECKPER") %>' />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
