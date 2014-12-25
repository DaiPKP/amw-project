<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_ManageCenter.ascx.cs" Inherits="Admin_UserControl_uc_ManageCenter" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div style="text-align: center; width: 100%; height: auto; float: right; font-size: 12px; font-family: Tahoma; color: #4c4c27;">
    <asp:UpdatePanel ID="update" runat="server">
        <ContentTemplate>
            <div>
                <span class="titleText">Quản lý thông tin trung tâm</span><br />
                <hr />
                <br />
                <table width="100%" style="margin-left: auto; margin-right: auto;">
                    <tr>
                        <td class="td_title" width="45%">Thành phố
                        </td>
                        <td class="td_value">                            
                            <asp:DropDownList ID="ddlCity" runat="server">
                            </asp:DropDownList>                            
                        </td>
                    </tr>
                    <tr>
                        <td class="td_title" width="45%">Mã trung tâm
                        </td>
                        <td class="td_value">
                            <asp:TextBox ID="txtCenterCode" MaxLength="10" runat="server"></asp:TextBox>                        </td>
                    </tr>
                    <tr>
                        <td class="td_title">Tên trung tâm
                        </td>
                        <td class="td_value">
                            <asp:TextBox ID="txtCenterName" MaxLength="100" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="td_title">Địa chỉ
                        </td>
                        <td class="td_value">
                            <asp:TextBox ID="txtAddress" MaxLength="100" runat="server" Rows="3" TextMode="MultiLine" Width="98%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="td_title">Trạng thái
                        </td>
                        <td class="td_value">

                            <asp:CheckBox ID="chkStatus" runat="server" />

                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center;">
                            <hr />
                            <asp:Button CssClass="btn_admin" ID="btSearch" runat="server" Text="Tìm Kiếm" OnClick="btSearch_Click" />

                            <asp:Button CssClass="btn_admin" ID="btClear" runat="server" Text="Xóa Trắng" OnClick="btClear_Click" />

                            <asp:Button CssClass="btn_admin" ID="btSave" runat="server" Text="Thêm Mới" OnClick="btSave_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="width:100%; text-align:center; color:red;">
                <asp:Label ID="lblAlerting" runat="server" CssClass="Alerting"></asp:Label>
            </div>
            
            <hr />
            <div id="divUserList">
                <asp:GridView ID="grdList" runat="server" AutoGenerateColumns="false" DataKeyNames="CityCode"
                    Width="100%" CssClass="grid" AllowPaging="True"
                    PageSize="20" OnRowEditing="grdList_RowEditing">
                    <Columns>                        
                        <asp:TemplateField HeaderText="Mã trung tâm" HeaderStyle-BackColor="#333300" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lbCenterCode" runat="server" Text='<%# Eval("CenterCode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Thành phố" HeaderStyle-BackColor="#333300" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lbCityName" runat="server" Text='<%# Eval("CityName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên trung tâm" HeaderStyle-BackColor="#333300" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lbCenterName" runat="server" Text='<%# Eval("CenterName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Trạng thái" HeaderStyle-BackColor="#333300" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lbStatus" runat="server" Text='<%# Eval("Status") %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Địa chỉ" HeaderStyle-BackColor="#333300" HeaderStyle-ForeColor="White" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lbAddress" runat="server" Text='<%# Eval("Address") %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#333300" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server" Text="Sửa" CommandName="Edit"
                                    Font-Underline="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                    <PagerStyle CssClass="pager" HorizontalAlign="Right" />
                </asp:GridView>
            </div>
            <asp:HiddenField ID="hdfId" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
