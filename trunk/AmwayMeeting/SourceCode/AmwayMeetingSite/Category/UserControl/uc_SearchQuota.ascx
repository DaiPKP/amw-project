<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_SearchQuota.ascx.cs"
    Inherits="Category_UserControl_uc_SearchQuota" %>
<div style="min-height: 800px; height: auto">
    <div class="TitlePage">
        TRA CỨU CHỈ TIÊU ĐĂNG KÝ HỘI HỌP
    </div>
    <asp:UpdatePanel ID="update" runat="server">
        <ContentTemplate>

        
    
    <asp:Panel runat="server" ID="pnlSearch">
        <div style="text-align: left; width: 100%">
            <fieldset>
                <table width="100%" style="margin-left:auto; margin-right:auto;">
                    <tr>
                        <td style ="width:10%; text-align:right; padding-right:5px;">
                            Mã số ADA
                        </td>
                        <td style ="width:15%;">
                            <asp:TextBox runat="server" ID="txtADA" MaxLength="50" CssClass="txtBox" Width="100%"></asp:TextBox>
                        </td>
                        <td style ="width:10%; text-align:right;">
                            Tên NPP:
                        </td>
                        <td style ="width:25%; font-weight:bold;">
                            <asp:Label ID="lbUserName" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style ="text-align:right; padding-right:5px;">
                            Pax
                        </td>
                        <td >
                            <asp:DropDownList ID="ddlPAXID" CssClass="txtBox" runat="server" Width="101%" Height="22px">
                            </asp:DropDownList>
                        </td>
                        <td style ="text-align:right;">
                            Danh hiệu:
                        </td>
                        <td style ="width:25%; font-weight:bold;">
                            <asp:Label ID="lbUserType" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style ="text-align:right; padding-right:5px;">
                            Quí tài chính
                        </td>
                        <td >
                            <asp:DropDownList ID="ddlPERIODID" CssClass="txtBox" runat="server" Width="101%" Height="22px">
                            </asp:DropDownList>
                        </td>
                        <td style ="text-align:right;">
                            Quota được cấp:
                        </td>
                        <td style ="width:25%;">
                            <asp:TextBox runat="server" ID="txtQuota" MaxLength="50" CssClass="txtBox" Width="50%" onKeyUp="addCommas(event,this);"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td style ="text-align:right;">
                            Quota đã sử dụng:
                        </td>
                        <td style ="width:25%;">
                            <asp:TextBox ID="txtUsedQuota" runat="server" MaxLength="50" CssClass="txtBox" Width="50%" onKeyUp="addCommas(event,this);"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4">
                            <asp:Label ID="lblAlerting" runat="server" CssClass="Alerting"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4">
                            <asp:Button CssClass="btn_admin" ID="btnSearch" runat="server" Text="Tra Cứu" OnClick="btnSearch_Click" />&nbsp;&nbsp;
                                    <asp:Button CssClass="btn_admin" ID="btnXoaTrang" runat="server" Text="Xóa trắng"
                                        OnClick="btnXoaTrang_Click" />&nbsp;&nbsp;
                            <asp:Button CssClass="btn_admin" ID="btnSave" runat="server" Text="Thêm Mới" OnClick="btnSave_Click"/>
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
                 <asp:TemplateField HeaderText="Mã số ADA">
                    <ItemTemplate>
                        <asp:Label ID="lblListingADAID" runat="server" Text='<%# Eval("ADA") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Họ tên NPP">
                    <ItemTemplate>
                        <asp:Label ID="lblListingDistributor" runat="server" Text='<%# Eval("FULLNAME") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Danh hiệu">
                    <ItemTemplate>
                        <asp:Label ID="lblListingUserTypeName" runat="server" Text='<%# Eval("USERTYPENAME") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Số người tham dự">
                    <ItemTemplate>
                        <asp:Label ID="lblListingPaxName" runat="server" Text='<%# Eval("PAXNAME") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quota được cấp">
                    <ItemTemplate>
                        <asp:Label ID="lblListingQuota" runat="server" Text='<%# Eval("QUOTA") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="Quota sử dụng">
                    <ItemTemplate>
                        <asp:Label ID="lblListingUsedQuota" runat="server" Text='<%# Eval("USEDQUOTA") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Qui Tai Chinh" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblListingPeriodId" runat="server" Text='<%# Eval("PERIODID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>      
                 <asp:TemplateField HeaderText="Pax" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblListingPaxId" runat="server" Text='<%# Eval("PAXID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>                  
                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnListingEdit" runat="server" Text="Chỉnh sửa" CommandName="Edit"
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
