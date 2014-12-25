<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_SearchBooking.ascx.cs" Inherits="Manager_UserControl_uc_SearchBooking" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div style="text-align: center; width: 100%; height: auto; float: right; font-size: 12px; font-family: Tahoma; color: #4c4c27;">
    <asp:UpdatePanel ID="update" runat="server">
        <ContentTemplate>
            <div>
                <span class="titleText">Quản lý trạng thái thanh toán</span><br />
                <hr />
                <br />
                <table width="100%" style="margin-left: auto; margin-right: auto;">
                    <tr>
                        <td class="td_title">Mã booking
                        </td>
                        <td class="td_value">
                            <asp:TextBox ID="txtBookingCode" runat="server"></asp:TextBox>

                        </td>
                        <td class="td_title">Tên phòng
                        </td>
                        <td class="td_value">                            
                            <asp:DropDownList ID="ddlRoom" runat="server">
                            </asp:DropDownList>                            
                        </td>
                    </tr>
                    <tr>
                        <td class="td_title">ADA ID
                        </td>
                        <td class="td_value">
                            <asp:TextBox ID="txtADAID" runat="server"></asp:TextBox>

                        </td>
                        <td class="td_title">Tên NPP
                        </td>
                        <td class="td_value">                            
                            <asp:Label ID="lbADAName" runat ="server"></asp:Label>                         
                        </td>
                    </tr>
                    <tr>
                        <td class="td_title">Ngày họp
                        </td>
                        <td class="td_value">
                            <asp:Label ID="lbMeetingDate" runat ="server"></asp:Label>
                        </td>
                        <td class="td_title">Buổi họp
                        </td>
                        <td class="td_value">
                            <asp:Label ID="lbSection" runat ="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="td_title">Chi phí
                        </td>
                        <td class="td_value">
                            <asp:Label ID="lbPrice" runat ="server"></asp:Label>
                        </td>
                        <td class="td_title">
                        </td>
                        <td class="td_value">
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="td_title">Trạng thái booking
                        </td>
                        <td class="td_value">

                            <asp:CheckBox ID="chkBookingStatus" runat="server" />

                        </td>
                        <td class="td_title">Trạng thái thanh toán
                        </td>
                        <td class="td_value">

                            <asp:CheckBox ID="chkPaymentStatus" runat="server" />

                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">

                            <asp:Button CssClass="btn_admin" ID="btSearch" runat="server" Text="Tìm Kiếm" OnClick="btSearch_Click" />

                            <asp:Button CssClass="btn_admin" ID="btClear" runat="server" Text="Xóa Trắng" OnClick="btClear_Click" />

                            <asp:Button CssClass="btn_admin" ID="btSave" runat="server" Text="Cập Nhật" OnClick="btSave_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="width:100%; text-align:center; color:red;">
                <asp:Label ID="lblAlerting" runat="server" CssClass="Alerting"></asp:Label>
            </div>
            
            <hr />
            <br /><br />
            <div id="divUserList">
                <asp:GridView ID="grdList" runat="server" AutoGenerateColumns="false" DataKeyNames="Code"
                    Width="100%" CssClass="grid" AllowPaging="True"
                    PageSize="50" OnRowEditing="grdList_RowEditing" OnPageIndexChanging="grdList_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="Mã đặt phòng" HeaderStyle-BackColor="#333300" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lbBookingCode" runat="server" Text='<%# Eval("BookingCode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên phòng" HeaderStyle-BackColor="#333300" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lbRoomName" runat="server" Text='<%# Eval("RoomName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ngày họp" HeaderStyle-BackColor="#333300" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lbMeetingDate" runat="server" Text='<%# Eval("Date","{0:dd/MM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Buổi họp" HeaderStyle-BackColor="#333300" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lbSection" runat="server" Text='<%# Eval("Section") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Giá phòng" HeaderStyle-BackColor="#333300" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lbPrice" runat="server" Text='<%# Eval("Price","{0:0,0}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Trạng thái đặt phòng" HeaderStyle-BackColor="#333300" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lbBookingStatus" runat="server" Text='<%# Eval("Status") %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Trạng thái thanh toán" HeaderStyle-BackColor="#333300" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lbPaymentStatus" runat="server" Text='<%# Eval("Paid") %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mã phòng" HeaderStyle-BackColor="#333300" HeaderStyle-ForeColor="White" Visible ="false">
                            <ItemTemplate>
                                <asp:Label ID="lbRoomCode" runat="server" Text='<%# Eval("RoomCode") %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ADA ID" HeaderStyle-BackColor="#333300" HeaderStyle-ForeColor="White" Visible ="false">
                            <ItemTemplate>
                                <asp:Label ID="lbADAID" runat="server" Text='<%# Eval("ADA_ID") %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ADA Name" HeaderStyle-BackColor="#333300" HeaderStyle-ForeColor="White" Visible ="false">
                            <ItemTemplate>
                                <asp:Label ID="lbADAName" runat="server" Text='<%# Eval("ADA_Name") %>'>></asp:Label>
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
