<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_ManageRoom.ascx.cs" Inherits="Admin_UserControl_uc_ManageRoom" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<script type="text/javascript">
    function ValidateKeypress(numcheck, e)
    {
        var keynum, keychar, numcheck;
        if (window.event) {//IE
            keynum = e.keyCode;
        }
        else if (e.which) {// Netscape/Firefox/Opera
            keynum = e.which;
        }
        if (keynum == 8 || keynum == 127 || keynum == null || keynum == 9 || keynum == 0 || keynum == 13) return true;
        keychar = String.fromCharCode(keynum);
        var result = numcheck.test(keychar);
        return result;
    }
</script>
<div style="text-align: center; width: 100%; height: auto; float: right; font-size: 12px; font-family: Tahoma; color: #4c4c27;">
    <asp:UpdatePanel ID="update" runat="server">
        <ContentTemplate>
            <div>
                <span class="titleText">Quản lý thông tin phòng họp</span><br />
                <img src="/Images/line.gif" />
                <br />
                <table width="100%" style="margin-left: auto; margin-right: auto;">
                    <tr>
                        <td class="td_title">Thành phố
                        </td>
                        <td class="td_value">                            
                            <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" Width="95%">
                            </asp:DropDownList>                            
                        </td>
                        <td colspan="2" class="td_title" style="font-weight:bold; text-align:center;">
                            Giá Phòng
                        </td>
                    </tr>
                    <tr>
                        <td class="td_title">Trung tâm
                        </td>
                        <td class="td_value">                            
                            <asp:DropDownList ID="ddlCenter" runat="server" Width="95%">
                            </asp:DropDownList>                            
                        </td>
                        <td class="td_title">Ca sáng
                        </td>
                        <td class="td_value">                            
                            <asp:TextBox ID="txtPriceMorning" runat="server" CssClass="textboxnumber" onkeypress="return ValidateKeypress(/\d/,event);" Width="95%"></asp:TextBox>                               
                        </td>
                    </tr>
                    <tr>
                        <td class="td_title">Mã phòng
                        </td>
                        <td class="td_value">
                            <asp:TextBox ID="txtRoomCode" MaxLength="10" runat="server" Width="95%"></asp:TextBox>
                        </td>
                        <td class="td_title">Ca chiều
                        </td>
                        <td class="td_value">                            
                            <asp:TextBox ID="txtPriceAfternoon" runat="server" CssClass="textboxnumber" onkeypress="return ValidateKeypress(/\d/,event);"  Width="95%"></asp:TextBox>                               
                        </td>
                    </tr>
                    <tr>
                        <td class="td_title">Tên phòng
                        </td>
                        <td class="td_value">
                            <asp:TextBox ID="txtRoomName" MaxLength="100" runat="server" Width="95%"></asp:TextBox>
                        </td>
                        <td class="td_title">Ca tối
                        </td>
                        <td class="td_value">                            
                            <asp:TextBox ID="txtPriceEvening" runat="server" CssClass="textboxnumber" onkeypress="return ValidateKeypress(/\d/,event);"  Width="95%"></asp:TextBox>                               
                        </td>
                    </tr>
                    <tr>
                        <td class="td_title">Sức chứa (người)
                        </td>
                        <td class="td_value">
                            <asp:TextBox ID="txtAmount" runat="server" CssClass="textboxnumber" onkeypress="return ValidateKeypress(/\d/,event);"  Width="95%"></asp:TextBox>
                        </td>
                        <td class="td_title">Sáng cuối tuần
                        </td>
                        <td class="td_value">                            
                            <asp:TextBox ID="txtPriceWeekendMorning" runat="server" CssClass="textboxnumber" onkeypress="return ValidateKeypress(/\d/,event);"  Width="95%"></asp:TextBox>                               
                        </td>
                    </tr>
                    <tr>
                        <td class="td_title">Trạng thái
                        </td>
                        <td class="td_value">
                            <asp:CheckBox ID="chkStatus" runat="server" />
                        </td>
                        <td class="td_title">Chiều cuối tuần
                        </td>
                        <td class="td_value">                            
                            <asp:TextBox ID="txtPriceWeekendAfternoon" runat="server" CssClass="textboxnumber" onkeypress="return ValidateKeypress(/\d/,event);"  Width="95%"></asp:TextBox>                               
                        </td>
                    </tr>
                    <tr>
                        <td class="td_title">
                        </td>
                        <td class="td_value">
                        </td>
                        <td class="td_title">Tối cuối tuần
                        </td>
                        <td class="td_value">                            
                            <asp:TextBox ID="txtPriceWeekendEvening" runat="server" CssClass="textboxnumber" onkeypress="return ValidateKeypress(/\d/,event);"  Width="95%"></asp:TextBox>                               
                        </td>
                    </tr>
                    <tr>
                        <td class="td_title">
                        </td>
                        <td class="td_value">
                        </td>
                        <td class="td_title">Đặt phòng tháng
                        </td>
                        <td class="td_value">                            
                            <asp:TextBox ID="txtBookingMonthly" runat="server" CssClass="textboxnumber" onkeypress="return ValidateKeypress(/\d/,event);"  Width="95%"></asp:TextBox>                               
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">

                            <asp:Button CssClass="button" ID="btSearch" runat="server" Text="Tìm Kiếm" OnClick="btSearch_Click" />

                            <asp:Button CssClass="button" ID="btClear" runat="server" Text="Xóa Trắng" OnClick="btClear_Click" />

                            <asp:Button CssClass="button" ID="btSave" runat="server" Text="Thêm Mới" OnClick="btSave_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="width:100%; text-align:center; color:red;">
                <asp:Label ID="lblAlerting" runat="server" CssClass="Alerting"></asp:Label>
            </div>
            
            <img src="/Images/line.gif" />
            <br /><br />
            <div id="divUserList">
                <asp:GridView ID="grdList" runat="server" AutoGenerateColumns="false" DataKeyNames="RoomCode"
                    Width="100%" CssClass="grid" AllowPaging="True"
                    PageSize="20" OnRowEditing="grdList_RowEditing" OnPageIndexChanging="grdList_PageIndexChanging">
                    <Columns>                        
                        <asp:TemplateField HeaderText="Mã phòng" HeaderStyle-BackColor="#333300" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lbRoomCode" runat="server" Text='<%# Eval("RoomCode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Trung tâm" HeaderStyle-BackColor="#333300" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lbCenterName" runat="server" Text='<%# Eval("CenterName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên phòng" HeaderStyle-BackColor="#333300" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lbRoomName" runat="server" Text='<%# Eval("RoomName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sức chứa (người)" HeaderStyle-BackColor="#333300" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lbAmount" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Trạng thái" HeaderStyle-BackColor="#333300" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lbStatus" runat="server" Text='<%# Eval("Status") %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Buổi sáng" HeaderStyle-BackColor="#333300" HeaderStyle-ForeColor="White" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lbMorning" runat="server" Text='<%# Eval("PriceMorning") %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Buổi chiều" HeaderStyle-BackColor="#333300" HeaderStyle-ForeColor="White" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lbAfternoon" runat="server" Text='<%# Eval("PriceAfternoon") %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Buổi tối" HeaderStyle-BackColor="#333300" HeaderStyle-ForeColor="White" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lbEvening" runat="server" Text='<%# Eval("PriceEvening") %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sáng cuối tuần" HeaderStyle-BackColor="#333300" HeaderStyle-ForeColor="White" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lbWeekendMorning" runat="server" Text='<%# Eval("PriceWeekendMorning") %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Chiều cuối tuần" HeaderStyle-BackColor="#333300" HeaderStyle-ForeColor="White" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lbWeekendAfternoon" runat="server" Text='<%# Eval("PriceWeekendAfternoon") %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tối cuối tuần" HeaderStyle-BackColor="#333300" HeaderStyle-ForeColor="White" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lbWeekendEvening" runat="server" Text='<%# Eval("PriceWeekendEvening") %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Phòng tháng" HeaderStyle-BackColor="#333300" HeaderStyle-ForeColor="White" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lbMonthly" runat="server" Text='<%# Eval("PriceBookingMonthly") %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mã thành phố" HeaderStyle-BackColor="#333300" HeaderStyle-ForeColor="White" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lbCityCode" runat="server" Text='<%# Eval("CityCode") %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mã trung tâm" HeaderStyle-BackColor="#333300" HeaderStyle-ForeColor="White" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lbCenterCode" runat="server" Text='<%# Eval("CenterCode") %>'>></asp:Label>
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
