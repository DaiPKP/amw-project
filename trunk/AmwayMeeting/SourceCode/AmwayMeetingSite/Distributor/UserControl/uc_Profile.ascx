﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Profile.ascx.cs" Inherits="Distributor_UserControl_uc_Profile" %>
<div style="min-height: 600px; height: auto">
    <div class="TitlePage">
        Thông Tin Tài Khoản
    </div>
    <div class="menuTitle">
        Thông Tin Cá Nhân
    </div>
            <asp:Panel runat="server" ID="pnlSearch">
                <div style="text-align: left; width: 100%">
                    <fieldset>
                        <table style="width: 100%; text-align:left; padding-left:20px; padding-right:20px;">
                            <tr>
                                <td class="td_title" style="width:25%;">Mã số Amway</td>
                                <td class="td_value" style="width:25%;">
                                    <asp:Label ID="lbADA" runat="server" Text=""></asp:Label>
                                </td>
                                <td class="td_title" style="width:25%;"></td>
                                <td class="td_value" style="width:25%;"></td>
                            </tr>
                            <tr>
                                <td class="td_title">Họ và tên</td>
                                <td class="td_value">
                                    <asp:Label ID="lbName" runat="server" Text=""></asp:Label>
                                </td>
                                <td class="td_title"></td>
                                <td class="td_value">
                                </td>
                            </tr>
                            <tr>
                                <td class="td_title">Số điện thoại</td>
                                <td class="td_value">
                                    <asp:Label ID="lbTelephone" runat="server" Text=""></asp:Label>
                                </td>
                                <td class="td_title"></td>
                                <td class="td_value">
                                </td>
                            </tr>                            
                            <tr>
                                <td class="td_title">Tỉnh thành làm việc</td>
                                <td class="td_value">
                                    <asp:Label ID="lbWorkProvince" runat="server"></asp:Label>
                                </td>
                                <td class="td_title"></td>
                                <td class="td_value"></td>
                            </tr>
                            <tr>
                                <td class="td_title">Quận huyện làm việc</td>
                                <td class="td_value">
                                    <asp:Label ID="lbWorkDistrict" runat="server"></asp:Label>
                                </td>
                                <td class="td_title"></td>
                                <td class="td_value"></td>
                            </tr>
                            <tr>
                                <td class="td_title">Danh hiệu</td>
                                <td class="td_value">
                                    <asp:Label ID="lbUserType" runat="server" Text=""></asp:Label>
                                </td>
                                <td class="td_title"></td>
                                <td class="td_value"></td>
                            </tr>
                            <tr>
                                <td class="td_title">Email</td>
                                <td class="td_value" colspan="3">
                                    <asp:TextBox ID="txtEmail" runat="server" Text="" Width="99%"></asp:TextBox>
                                </td>
                                
                            </tr>
                            <tr>
                                <td class="td_title">Địa chỉ</td>
                                <td class="td_value" colspan="3">
                                    <asp:TextBox ID="txtAddress" runat="server" Text="" Rows="3" TextMode="MultiLine" Width="99%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="text-align:center;">
                                    <span class="Alerting">
                                        <asp:Label ID="lbMess" runat="server" Text=""></asp:Label>
                                    </span>
                                    <br />
                                    <asp:Button id="btnEdit" runat ="server" Text="Cập Nhật" OnClick="btnEdit_Click"/>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
            </asp:Panel>
            <div style="clear: both; height: 10px">
            </div>
            <div class="menuTitle">
                Thông Tin Sử Dụng Quota (dành cho Hội họp được hỗ trợ chi phí)
            </div>
            <div id="divQuotaList" style="text-align:center;">
                <asp:GridView ID="grdQuotaList" runat="server" AutoGenerateColumns="false" DataKeyNames="UserID"
                    Width="100%" CssClass="grid" AllowPaging="True"
                    PageSize="20">
                    <Columns>
                        <asp:TemplateField HeaderText="Loại hội họp">
                            <ItemTemplate>
                                <asp:Label ID="lblListingADA" runat="server" Text='<%# Eval("PAXNAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quota">
                            <ItemTemplate>
                                <asp:Label ID="lblListingViceGerent" runat="server" Text='<%# Eval("QUOTA") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quota đã sử dụng">
                            <ItemTemplate>
                                <asp:Label ID="lblListingEmail" runat="server" Text='<%# Eval("USEDQUOTA") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quota đã mượn">
                            <ItemTemplate>
                                <asp:Label ID="lblListingWorkProvinceName" runat="server" Text='<%# Eval("BORROWEDQUOTA") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quota còn lại có thể sử dụng">
                            <ItemTemplate>
                                <asp:Label ID="lblListingUserTypeName" runat="server" Text='<%# Eval("AVAILABLE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="pager" HorizontalAlign="Right" />
                </asp:GridView>
            </div>
            <div style="clear: both; height: 10px">
            </div>
            <div class="menuTitle">
                Lịch Sử Đăng Ký Hội Họp
            </div>
            <div id="divMeetingHistory" style="text-align:center;">
                <asp:GridView ID="grdMeetingList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID"
                    Width="100%" CssClass="grid" AllowPaging="True"
                    PageSize="20" OnPageIndexChanging="grdMeetingList_PageIndexChanging" OnRowEditing="grdMeetingList_RowEditing">
                    <Columns>
                        <asp:TemplateField HeaderText="Loại hội họp">
                            <ItemTemplate>
                                <asp:Label ID="lblListingTYPENAME" runat="server" Text='<%# Eval("MEETINGTYPENAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Số người tham dự">
                            <ItemTemplate>
                                <asp:Label ID="lblListingPAXNAME" runat="server" Text='<%# Eval("PAXNAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ngày đăng ký">
                            <ItemTemplate>
                                <asp:Label ID="lblListingMEETING_STARTDATE" runat="server" Text='<%# Eval("CREATEDATE")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Giờ họp">
                            <ItemTemplate>
                                <asp:Label ID="lblListingMEETING_TIME" runat="server" Text='<%# Eval("MEETING_TIME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Thành phố">
                            <ItemTemplate>
                                <asp:Label ID="lblListingPROVINCENAME" runat="server" Text='<%# Eval("PROVINCENAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Địa điểm tổ chức">
                            <ItemTemplate>
                                <asp:Label ID="lblListingMEETING_PLACE_NAME" runat="server" Text='<%# Eval("MEETING_PLACE_NAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Có yếu tố nước ngoài">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkListingFOREIGNER" runat="server" Checked='<%# Eval("FOREIGNER") %>' Enabled="false"></asp:CheckBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Đã lập báo cáo">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkListingREPORTED" runat="server" Checked='<%# Eval("REPORTED") %>' Enabled ="false"></asp:CheckBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Trạng thái">
                            <ItemTemplate>
                                <asp:Label ID="lblListingSTATUS" runat="server" Text='<%# Eval("STATUS_MEETING_REGISTERNAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center"> 
                            <ItemTemplate>
                                <asp:LinkButton ID="btnListingView" runat="server" Text="Xem" CommandName="Edit"
                                    CommandArgument='<%# Eval("ID") %>' Font-Underline="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="pager" HorizontalAlign="Right" />
                </asp:GridView>
            </div>
            <asp:HiddenField ID="hdfMeetingID" runat="server" />
</div>
