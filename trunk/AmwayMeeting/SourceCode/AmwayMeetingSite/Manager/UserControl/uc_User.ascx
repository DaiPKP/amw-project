<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_User.ascx.cs" Inherits="Manager_UserControl_uc_User" %>
<div style="min-height: 800px; height: auto">
    <div class="TitlePage">
        TÀI KHOẢN
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel runat="server" ID="pnlSearch">
                <div style="text-align: left; width: 100%">
                    <fieldset>
                        <table width="100%">
                            <tr>
                                <td class="tdsearch1"></td>
                                <td align="left" class="tdsearch2">Mã số Amway<span style="color: Red">(*)</span>:
                                </td>
                                <td align="left" class="tdsearch3">
                                    <asp:TextBox runat="server" ID="txtADA" MaxLength="50" CssClass="txtBox" Width="150px"></asp:TextBox>
                                </td>
                                <td class="tdsearch4"></td>
                                <td align="left" class="tdsearch5">
                                </td>
                                <td align="left" class="tdsearch6">
                                    </td>
                                <td class="tdsearch7"></td>
                            </tr>
                             <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                             <tr>
                                <td class="tdsearch1"></td>
                                <td align="left" class="tdsearch2">Họ và tên đệm<span style="color: Red">(*)</span>:
                                </td>
                                <td align="left" class="tdsearch3">
                                    <asp:TextBox runat="server" ID="txtLastName" MaxLength="50" CssClass="txtBox" Width="100%"></asp:TextBox>
                                </td>
                                <td class="tdsearch4"></td>
                                <td align="left" class="tdsearch5">Tên<span style="color: Red">(*)</span>:
                                </td>
                                <td align="left" class="tdsearch6">
                                    <asp:TextBox runat="server" ID="txtFirstName" MaxLength="50" CssClass="txtBox" Width="100%"></asp:TextBox>
                                </td>
                                <td class="tdsearch7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                             <tr>
                                <td class="tdsearch1"></td>
                                <td align="left" class="tdsearch2">Họ và tên đệm(Vợ/Chồng):
                                </td>
                                <td align="left" class="tdsearch3">
                                    <asp:TextBox runat="server" ID="txtRelativeLastName" MaxLength="50" CssClass="txtBox" Width="100%"></asp:TextBox>
                                </td>
                                <td class="tdsearch4"></td>
                                <td align="left" class="tdsearch5">Tên(Vợ/Chồng):
                                </td>
                                <td align="left" class="tdsearch6">
                                    <asp:TextBox runat="server" ID="txtRelativeFirstName" MaxLength="20" CssClass="txtBox" Width="100%"></asp:TextBox>
                                </td>
                                <td class="tdsearch7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                            <tr>
                                <td class="tdsearch1"></td>
                                <td align="left" class="tdsearch2">Mã số đơn/kép<span style="color: Red">(*)</span>:
                                </td>
                                <td align="left" class="tdsearch3">
                                    <asp:TextBox runat="server" ID="txtCode" MaxLength="20" CssClass="txtBox" Width="100%"></asp:TextBox>

                                </td>
                                <td class="tdsearch4"></td>
                                <td align="left" class="tdsearch5">Số tài khoản<span style="color: Red">(*)</span>:
                                </td>
                                <td align="left" class="tdsearch6">
                                    <asp:TextBox runat="server" ID="txtAccBank" MaxLength="50" CssClass="txtBox" Width="100%"></asp:TextBox>
                                </td>
                                <td class="tdsearch7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                            <tr>
                                <td class="tdsearch1"></td>
                                <td align="left" class="tdsearch2">Số điện thoại<span style="color: Red">(*)</span>:
                                </td>
                                <td align="left" class="tdsearch3">
                                    <asp:TextBox runat="server" ID="txtTelephone" MaxLength="20" CssClass="txtBox" Width="100%"></asp:TextBox>

                                </td>
                                <td class="tdsearch4"></td>
                                <td align="left" class="tdsearch5">Fax:
                                </td>
                                <td align="left" class="tdsearch6">
                                    <asp:TextBox runat="server" ID="txtFax" MaxLength="20" CssClass="txtBox" Width="100%"></asp:TextBox>
                                </td>
                                <td class="tdsearch7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                            <tr>
                                <td class="tdsearch1"></td>
                                <td align="left" class="tdsearch2">Email <span style="color: Red">(*)</span>:
                                </td>
                                <td align="left" class="tdsearch3">
                                    <asp:TextBox runat="server" ID="txtEmail" MaxLength="50" CssClass="txtBox" Width="100%"></asp:TextBox>
                                </td>
                                <td class="tdsearch4"></td>
                                <td align="left" class="tdsearch5">Địa chỉ<span style="color: Red">(*)</span>:
                                </td>
                                <td align="left" class="tdsearch6">
                                    <asp:TextBox ID="txtAddress" runat="server" CssClass="txtBox" MaxLength="200" Width="100%"></asp:TextBox>
                                </td>
                                <td class="tdsearch7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                            <tr>
                                <td class="tdsearch1"></td>
                                <td align="left" class="tdsearch2">Tỉnh thành làm việc<span style="color: Red">(*)</span>:
                                </td>
                                <td align="left" class="tdsearch3">
                                    <asp:DropDownList ID="ddlWorkProvince" CssClass="txtBox" runat="server" Width="101%" AutoPostBack="True" OnSelectedIndexChanged="ddlWorkProvince_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td class="tdsearch4"></td>
                                <td align="left" class="tdsearch5">Quận huyện làm việc<span style="color: Red">(*)</span>:
                                </td>
                                <td align="left" class="tdsearch6">
                                    <asp:DropDownList ID="ddlWorkDistrict" CssClass="txtBox" runat="server" Width="101%">
                                    </asp:DropDownList>
                                </td>
                                <td class="tdsearch7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                            <tr>
                                <td class="tdsearch1"></td>
                                <td align="left" class="tdsearch2">Danh hiệu<span style="color: Red">(*)</span>:
                                </td>
                                <td align="left" class="tdsearch3">
                                    <asp:DropDownList ID="ddlUserType" CssClass="txtBox" runat="server" Width="101%">
                                    </asp:DropDownList>
                                </td>
                                <td class="tdsearch4"></td>
                                <td align="left" class="tdsearch5">Nhóm người dùng <span style="color: Red">(*)</span>:
                                </td>
                                <td align="left" class="tdsearch6">
                                    <asp:DropDownList ID="ddlDepartment" CssClass="txtBox" runat="server" Width="101%">
                                    </asp:DropDownList>
                                </td>
                                <td class="tdsearch7"></td>
                            </tr>
                            <tr>
                                <td align="left" class="divClearBothInAdmin"></td>
                            </tr>
                            <tr>
                                <td class="tdsearch1"></td>
                                <td align="left" class="tdsearch2">Ghi chú :</td>

                                <td align="left" class="tdsearch3">
                                    <asp:TextBox ID="txtDescription" runat="server" CssClass="txtBox" MaxLength="500" Width="100%"></asp:TextBox>
                               
                                </td>
                                <td class="tdsearch4"></td>
                                <td align="left" class="tdsearch5">
                                    Tình trạng<span style="color: Red">(*)</span>:
                                </td>
                                <td align="left" class="tdsearch6"><asp:CheckBox ID="chkActive" runat="server" Checked="true" /></td>
                                <td class="tdsearch7"></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="7">
                                    <asp:Label ID="lblAlerting" runat="server" CssClass="Alerting"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="7">
                                    <asp:Button CssClass="btn_admin" ID="btnSearch" runat="server" Text="Tìm kiếm" OnClick="btnSearch_Click" />
                                    &nbsp;&nbsp;
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
                <asp:GridView ID="grdUserList" runat="server" AutoGenerateColumns="false" DataKeyNames="UserID"
                    Width="100%" CssClass="grid" AllowPaging="True"
                    PageSize="20" OnRowEditing="grdUserList_RowEditing" OnPageIndexChanging="grdUserList_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="Mã số Amway">
                            <ItemTemplate>
                                <asp:Label ID="lblListingADA" runat="server" Text='<%# Eval("ADA") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Họ và tên">
                            <ItemTemplate>
                                <asp:Label ID="lblListingViceGerent" runat="server" Text='<%# Eval("FULLNAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                            <ItemTemplate>
                                <asp:Label ID="lblListingEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tỉnh thành làm việc">
                            <ItemTemplate>
                                <asp:Label ID="lblListingWorkProvinceName" runat="server" Text='<%# Eval("WORKPROVINCENAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Quận huyện làm việc">
                            <ItemTemplate>
                                <asp:Label ID="lblListingWorkDistrictName" runat="server" Text='<%# Eval("WORKDISTRICTNAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Danh hiệu">
                            <ItemTemplate>
                                <asp:Label ID="lblListingUserTypeName" runat="server" Text='<%# Eval("USERTYPENAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Nhóm người dùng">
                            <ItemTemplate>
                                <asp:Label ID="lblListingDepartmentName" runat="server" Text='<%# Eval("DEPARTMENTNAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tình trạng" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblListingTinhTrang" runat="server" Text='<%# Eval("TINHTRANG") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TELEPHONE" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblListingTelephone" runat="server" Text='<%# Eval("TELEPHONE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FAX" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblListingFax" runat="server" Text='<%# Eval("FAX") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="FirstName" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblListingFirstName" runat="server" Text='<%# Eval("FIRSTNAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="LastName" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblListingLastName" runat="server" Text='<%# Eval("LASTNAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="RelativeFirstName" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblListingRelativeFirstName" runat="server" Text='<%# Eval("RELATIVE_FIRSTNAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="RelativeFirstName" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblListingRelativeLastName" runat="server" Text='<%# Eval("RELATIVE_LASTNAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Mã số đơn/kép" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblListingCode" runat="server" Text='<%# Eval("CODE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="AccBank" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblListingAccBank" runat="server" Text='<%# Eval("ACCBANK") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Địa Chỉ" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblListingAddress" runat="server" Text='<%# Eval("ADDRESS") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Description" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblListingDescription" runat="server" Text='<%# Eval("DESCRIPTION") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Active" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblListingActive" runat="server" Text='<%# Eval("Active") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Mã số Danh Hiệu " Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblListingUserTypeId" runat="server" Text='<%# Eval("USERTYPEID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mã số nhóm" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblListingDepartmentId" runat="server" Text='<%# Eval("DEPARTMENTID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Mã số Tỉnh thành đang ở" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblListingWorkDistrictId" runat="server" Text='<%# Eval("WORKDISTRICTID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Mã số Tỉnh Thành Làm Việc" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblListingWorkProvinceId" runat="server" Text='<%# Eval("WORKPROVINCEID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnListingEdit" runat="server" Text="Sửa" CommandName="Edit"
                                    CommandArgument='<%# Eval("UserID") %>' Font-Underline="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="pager" HorizontalAlign="Right" />
                </asp:GridView>
            </div>
            <asp:HiddenField ID="hdfUserID" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
