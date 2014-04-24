<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegisterRoom.aspx.cs" Inherits="AmwayMeetingSubsidy.Admin.RegisterRoom" %>
<%@ Register src="../UserControl/UserCombineInfo.ascx" tagname="UserCombineInfo" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <style type="text/css">
        .style1
        {
            width:80%;
        }
        .style2
        {
            width:20%;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width:830px; height:100%; margin-left:35px;line-height:2em; color:#89ade9;font-size:12px;background-color:#89ade9;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div class="panel">        
            <table style="width: 100%;color:Window;">
                <tr>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp; Chose Meeting Type&nbsp;
                        <asp:DropDownList ID="ddl_meeting_type" runat="server" 
                            DataSourceID="SqlDataSource_LoadMeetingType" DataTextField="Meeting_Type_Name" 
                            DataValueField="Meeting_Type_ID" AutoPostBack="True" 
                            onselectedindexchanged="ddl_meeting_type_SelectedIndexChanged">
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Chose Meeting Room Type&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="ddl_room_type" runat="server" AutoPostBack="True" AppendDataBoundItems="True"
                            DataSourceID="SqlDataSource_LoadRoomType" DataTextField="Room_Type_Name" 
                            DataValueField="Room_Type_ID" 
                            onselectedindexchanged="ddl_room_type_SelectedIndexChanged" >
                            <asp:ListItem Value="default" Text="Chose Meeting Room Type" />
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Chose City&nbsp;&nbsp;
                        <asp:DropDownList ID="ddl_city" runat="server"
                            DataSourceID="SqlDataSource_LoadCity" DataTextField="City_Name" 
                            DataValueField="City_ID" Width="100px">
                            <asp:ListItem Value="" Text="Chose City" />
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource_LoadCity" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
                            SelectCommand="SELECT [City_ID], [City_Name] FROM [v_City] WHERE ([Room_Type_ID] = @Room_Type_ID)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddl_room_type" DefaultValue="NULL" 
                                    Name="Room_Type_ID" PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        &nbsp;<asp:SqlDataSource ID="SqlDataSource_LoadRoomType" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
                            SelectCommand="SELECT [Room_Type_ID], [Room_Type_Name] FROM [Meeting_Room_Type] WHERE ([Status] = @Status)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="Active" Name="Status" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource_LoadMeetingType" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
                            SelectCommand="SELECT [Meeting_Type_ID], [Meeting_Type_Name] FROM [Meeting_Type] WHERE ([Status] = @Status)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="Active" Name="Status" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;ADA ID of Organizer&nbsp;&nbsp;
                        <asp:TextBox ID="txt_organizer_id" runat="server" Height="16px" Width="72px"></asp:TextBox>
                         &nbsp;
                        <asp:ImageButton ID="bt_check_organizer" runat="server" Height="23px" 
                            ImageUrl="~/images/check_icon.png" Width="26px" 
                            onclick="bt_check_organizer_Click" />
                        Organizer Name&nbsp;
                        <asp:TextBox ID="txt_organizer_name" runat="server" Enabled="False" Height="16px" 
                            Width="180px"></asp:TextBox>
                        &nbsp;&nbsp;Level&nbsp;
                        <asp:TextBox ID="txt_organizer_level" runat="server" Enabled="False" 
                           Height="16px" Width="120px"></asp:TextBox>
                        &nbsp;Quota&nbsp;
                        <asp:ImageButton ID="bt_ok" runat="server" Height="23px" 
                            ImageUrl="~/images/check_icon.png" Width="26px" Visible="False" />
                        <asp:ImageButton ID="bt_error" runat="server" Height="23px" 
                            ImageUrl="~/images/error.png" Width="26px" Visible="False" 
                            AlternateText="Quota Expire, Click Here to borrow quota !" 
                            onclick="bt_error_Click"/> 
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;Using Quota of level&nbsp;&nbsp;
                        <asp:DropDownList ID="ddl_rule_level" runat="server" 
                            DataSourceID="SqlDataSource_LoadRuleLevel" DataTextField="Rule_Name" 
                            DataValueField="Condition_Combined" Height="20px" Width="100px" 
                            AutoPostBack="True" 
                            onselectedindexchanged="ddl_rule_level_SelectedIndexChanged">
                        </asp:DropDownList>
                        &nbsp;&nbsp;
                        <asp:ImageButton ID="bt_process" runat="server" 
                            ImageUrl="~/images/bt_process.jpg" onclick="bt_process_Click" />
                        &nbsp;<asp:SqlDataSource ID="SqlDataSource_LoadRuleLevel" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
                            SelectCommand="SELECT * FROM [v_rule_level] WHERE ([Room_Type_ID] = @Room_Type_ID)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddl_room_type" DefaultValue="NULL" 
                                    Name="Room_Type_ID" PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
            </table>
            </div>
            <br>
            <asp:Panel ID="combined_1" runat="server" CssClass="panel" Visible="false">
                <table style="width: 100%;color:Window;">
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;ADA ID of Distributor&nbsp;&nbsp;
                            <asp:TextBox ID="txt_combined1_id" runat="server" Height="16px" Width="72px"></asp:TextBox>
                            &nbsp;
                            <asp:ImageButton ID="bt_combined1_check" runat="server" Height="23px" 
                                ImageUrl="~/images/check_icon.png" onclick="bt_combined1_check_Click" 
                                Width="26px" />
                            Distributor Name&nbsp;
                            <asp:TextBox ID="txt_combined1_name" runat="server" Enabled="False" 
                                Height="16px" Width="180px"></asp:TextBox>
                            &nbsp;&nbsp;Level&nbsp;
                            <asp:TextBox ID="txt_combined1_level" runat="server" Enabled="False" 
                                Height="16px" Width="120px"></asp:TextBox>
                            &nbsp;Quota&nbsp;
                            <asp:ImageButton ID="bt_combined1_ok" runat="server" Height="23px" 
                                ImageUrl="~/images/check_icon.png" Visible="False" Width="26px" />
                            <asp:ImageButton ID="bt_combined1_error" runat="server" Height="23px" 
                                ImageUrl="~/images/error.png" Visible="False" Width="26px" 
                                onclick="bt_error_Click" />
                        </td>
                    </tr>
                </table>
                <div style="text-align:center;">
                    <asp:ImageButton ID="bt_combined1_update" runat="server" ImageUrl="~/images/update.jpg" 
                        onclick="bt_combined1_update_Click" />
                </div>
            </asp:Panel>
            <asp:Panel ID="combined_2" runat="server" CssClass="panel" Visible="false">
                <table style="width: 100%;color:Window;">
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;ADA ID of Distributor&nbsp;&nbsp;
                            <asp:TextBox ID="txt_combined2_id1" runat="server" Height="16px" Width="72px"></asp:TextBox>
                            &nbsp;
                            <asp:ImageButton ID="bt_combined2_check1" runat="server" Height="23px" 
                                ImageUrl="~/images/check_icon.png" onclick="bt_combined2_check1_Click" 
                                Width="26px" />
                            Distributor Name&nbsp;
                            <asp:TextBox ID="txt_combined2_name1" runat="server" Enabled="False" Height="16px" 
                                Width="180px"></asp:TextBox>
                            &nbsp;&nbsp;Level&nbsp;
                            <asp:TextBox ID="txt_combined2_level1" runat="server" Enabled="False" Height="16px" 
                                Width="120px"></asp:TextBox>
                            &nbsp;Quota&nbsp;
                            <asp:ImageButton ID="bt_combined2_ok1" runat="server" Height="23px" 
                                ImageUrl="~/images/check_icon.png" Visible="False" Width="26px" />
                            <asp:ImageButton ID="bt_combined2_error1" runat="server" Height="23px" 
                                ImageUrl="~/images/error.png" Visible="False" Width="26px" 
                                onclick="bt_error_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;ADA ID of Distributor&nbsp;&nbsp;
                            <asp:TextBox ID="txt_combined2_id2" runat="server" Height="16px" Width="72px"></asp:TextBox>
                            &nbsp;
                            <asp:ImageButton ID="bt_combined2_check2" runat="server" Height="23px" 
                                ImageUrl="~/images/check_icon.png" onclick="bt_combined2_check2_Click" 
                                Width="26px" />
                            Distributor Name&nbsp;
                            <asp:TextBox ID="txt_combined2_name2" runat="server" Enabled="False" Height="16px" 
                                Width="180px"></asp:TextBox>
                            &nbsp;&nbsp;Level&nbsp;
                            <asp:TextBox ID="txt_combined2_level2" runat="server" Enabled="False" Height="16px" 
                                Width="120px"></asp:TextBox>
                            &nbsp;Quota&nbsp;
                            <asp:ImageButton ID="bt_combined2_ok2" runat="server" Height="23px" 
                                ImageUrl="~/images/check_icon.png" Visible="False" Width="26px" />
                            <asp:ImageButton ID="bt_combined2_error2" runat="server" Height="23px" 
                                ImageUrl="~/images/error.png" Visible="False" Width="26px" 
                                onclick="bt_error_Click" />
                        </td>
                    </tr>
                </table>
                <div style="text-align:center;">
                    <asp:ImageButton ID="bt_combined2_update" runat="server" 
                        ImageUrl="~/images/update.jpg" onclick="bt_combined2_update_Click" />
                </div>
            </asp:Panel>
            <asp:Panel ID="combined_3" runat="server" CssClass="panel" Visible="false">
                <table style="width: 100%;color:Window;">
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;ADA ID of Distributor&nbsp;&nbsp;
                            <asp:TextBox ID="txt_combined3_id1" runat="server" Height="16px" Width="72px"></asp:TextBox>
                            &nbsp;
                            <asp:ImageButton ID="bt_combined3_check1" runat="server" Height="23px" 
                                ImageUrl="~/images/check_icon.png" onclick="bt_combined3_check1_Click" 
                                Width="26px" />
                            Distributor Name&nbsp;
                            <asp:TextBox ID="txt_combined3_name1" runat="server" Enabled="False" Height="16px" 
                                Width="180px"></asp:TextBox>
                            &nbsp;&nbsp;Level&nbsp;
                            <asp:TextBox ID="txt_combined3_level1" runat="server" Enabled="False" Height="16px" 
                                Width="120px"></asp:TextBox>
                            &nbsp;Quota&nbsp;
                            <asp:ImageButton ID="bt_combined3_ok1" runat="server" Height="23px" 
                                ImageUrl="~/images/check_icon.png" Visible="False" Width="26px" />
                            <asp:ImageButton ID="bt_combined3_error1" runat="server" Height="23px" 
                                ImageUrl="~/images/error.png" Visible="False" Width="26px" 
                                onclick="bt_error_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;ADA ID of Distributor&nbsp;&nbsp;
                            <asp:TextBox ID="txt_combined3_id2" runat="server" Height="16px" Width="72px"></asp:TextBox>
                            &nbsp;
                            <asp:ImageButton ID="bt_combined3_check2" runat="server" Height="23px" 
                                ImageUrl="~/images/check_icon.png" onclick="bt_combined3_check2_Click" 
                                Width="26px" />
                            Distributor Name&nbsp;
                            <asp:TextBox ID="txt_combined3_name2" runat="server" Enabled="False" Height="16px" 
                                Width="180px"></asp:TextBox>
                            &nbsp;&nbsp;Level&nbsp;
                            <asp:TextBox ID="txt_combined3_level2" runat="server" Enabled="False" Height="16px" 
                                Width="120px"></asp:TextBox>
                            &nbsp;Quota&nbsp;
                            <asp:ImageButton ID="bt_combined3_ok2" runat="server" Height="23px" 
                                ImageUrl="~/images/check_icon.png" Visible="False" Width="26px" />
                            <asp:ImageButton ID="bt_combined3_error2" runat="server" Height="23px" 
                                ImageUrl="~/images/error.png" Visible="False" Width="26px" 
                                onclick="bt_error_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;ADA ID of Distributor&nbsp;&nbsp;
                            <asp:TextBox ID="txt_combined3_id3" runat="server" Height="16px" Width="72px"></asp:TextBox>
                            &nbsp;
                            <asp:ImageButton ID="bt_combined3_check3" runat="server" Height="23px" 
                                ImageUrl="~/images/check_icon.png" onclick="bt_combined3_check3_Click" 
                                Width="26px" />
                            Distributor Name&nbsp;
                            <asp:TextBox ID="txt_combined3_name3" runat="server" Enabled="False" Height="16px" 
                                Width="180px"></asp:TextBox>
                            &nbsp;&nbsp;Level&nbsp;
                            <asp:TextBox ID="txt_combined3_level3" runat="server" Enabled="False" Height="16px" 
                                Width="120px"></asp:TextBox>
                            &nbsp;Quota&nbsp;
                            <asp:ImageButton ID="bt_combined3_ok3" runat="server" Height="23px" 
                                ImageUrl="~/images/check_icon.png" Visible="False" Width="26px" />
                            <asp:ImageButton ID="bt_combined3_error3" runat="server" Height="23px" 
                                ImageUrl="~/images/error.png" Visible="False" Width="26px" 
                                onclick="bt_error_Click" />
                        </td>
                    </tr>
                </table>
                <div style="text-align:center;">
                    <asp:ImageButton ID="bt_combined3_update" runat="server" 
                        ImageUrl="~/images/update.jpg" onclick="bt_combined3_update_Click" />
                </div>
            </asp:Panel>
            <asp:Panel ID="combined_4" runat="server" CssClass="panel" Visible="false">
                <table style="width: 100%;color:Window;">
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;ADA ID of Distributor&nbsp;&nbsp;
                            <asp:TextBox ID="txt_combined4_id1" runat="server" Height="16px" Width="72px"></asp:TextBox>
                            &nbsp;
                            <asp:ImageButton ID="bt_combined4_check1" runat="server" Height="23px" 
                                ImageUrl="~/images/check_icon.png" onclick="bt_combined4_check1_Click" 
                                Width="26px" />
                            Distributor Name&nbsp;
                            <asp:TextBox ID="txt_combined4_name1" runat="server" Enabled="False" Height="16px" 
                                Width="180px"></asp:TextBox>
                            &nbsp;&nbsp;Level&nbsp;
                            <asp:TextBox ID="txt_combined4_level1" runat="server" Enabled="False" Height="16px" 
                                Width="120px"></asp:TextBox>
                            &nbsp;Quota&nbsp;
                            <asp:ImageButton ID="bt_combined4_ok1" runat="server" Height="23px" 
                                ImageUrl="~/images/check_icon.png" Visible="False" Width="26px" />
                            <asp:ImageButton ID="bt_combined4_error1" runat="server" Height="23px" 
                                ImageUrl="~/images/error.png" Visible="False" Width="26px" 
                                onclick="bt_error_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;ADA ID of Distributor&nbsp;&nbsp;
                            <asp:TextBox ID="txt_combined4_id2" runat="server" Height="16px" Width="72px"></asp:TextBox>
                            &nbsp;
                            <asp:ImageButton ID="bt_combined4_check2" runat="server" Height="23px" 
                                ImageUrl="~/images/check_icon.png" onclick="bt_combined4_check2_Click" 
                                Width="26px" />
                            Distributor Name&nbsp;
                            <asp:TextBox ID="txt_combined4_name2" runat="server" Enabled="False" Height="16px" 
                                Width="180px"></asp:TextBox>
                            &nbsp;&nbsp;Level&nbsp;
                            <asp:TextBox ID="txt_combined4_level2" runat="server" Enabled="False" Height="16px" 
                                Width="120px"></asp:TextBox>
                            &nbsp;Quota&nbsp;
                            <asp:ImageButton ID="bt_combined4_ok2" runat="server" Height="23px" 
                                ImageUrl="~/images/check_icon.png" Visible="False" Width="26px" />
                            <asp:ImageButton ID="bt_combined4_error2" runat="server" Height="23px" 
                                ImageUrl="~/images/error.png" Visible="False" Width="26px" 
                                onclick="bt_error_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;ADA ID of Distributor&nbsp;&nbsp;
                            <asp:TextBox ID="txt_combined4_id3" runat="server" Height="16px" Width="72px"></asp:TextBox>
                            &nbsp;
                            <asp:ImageButton ID="bt_combined4_check3" runat="server" Height="23px" 
                                ImageUrl="~/images/check_icon.png" onclick="bt_combined4_check3_Click" 
                                Width="26px" />
                            Distributor Name&nbsp;
                            <asp:TextBox ID="txt_combined4_name3" runat="server" Enabled="False" Height="16px" 
                                Width="180px"></asp:TextBox>
                            &nbsp;&nbsp;Level&nbsp;
                            <asp:TextBox ID="txt_combined4_level3" runat="server" Enabled="False" Height="16px" 
                                Width="120px"></asp:TextBox>
                            &nbsp;Quota&nbsp;
                            <asp:ImageButton ID="bt_combined4_ok3" runat="server" Height="23px" 
                                ImageUrl="~/images/check_icon.png" Visible="False" Width="26px" />
                            <asp:ImageButton ID="bt_combined4_error3" runat="server" Height="23px" 
                                ImageUrl="~/images/error.png" Visible="False" Width="26px" 
                                onclick="bt_error_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;ADA ID of Distributor&nbsp;&nbsp;
                            <asp:TextBox ID="txt_combined4_id4" runat="server" Height="16px" Width="72px"></asp:TextBox>
                            &nbsp;
                            <asp:ImageButton ID="bt_combined4_check4" runat="server" Height="23px" 
                                ImageUrl="~/images/check_icon.png" onclick="bt_combined4_check4_Click" 
                                Width="26px" />
                            Distributor Name&nbsp;
                            <asp:TextBox ID="txt_combined4_name4" runat="server" Enabled="False" Height="16px" 
                                Width="180px"></asp:TextBox>
                            &nbsp;&nbsp;Level&nbsp;
                            <asp:TextBox ID="txt_combined4_level4" runat="server" Enabled="False" Height="16px" 
                                Width="120px"></asp:TextBox>
                            &nbsp;Quota&nbsp;
                            <asp:ImageButton ID="bt_combined4_ok4" runat="server" Height="23px" 
                                ImageUrl="~/images/check_icon.png" Visible="False" Width="26px" />
                            <asp:ImageButton ID="bt_combined4_error4" runat="server" Height="23px" 
                                ImageUrl="~/images/error.png" Visible="False" Width="26px" 
                                onclick="bt_error_Click" />
                        </td>
                    </tr>
                </table>
                <div style="text-align:center;">
                    <asp:ImageButton ID="bt_combined4_update" runat="server" 
                        ImageUrl="~/images/update.jpg" onclick="bt_combined4_update_Click" />
                </div>
            </asp:Panel>
            <asp:Panel ID="combined_5" runat="server" CssClass="panel" Visible="false">
                <table style="width: 100%;color:Window;">
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;ADA ID of Distributor&nbsp;&nbsp;
                            <asp:TextBox ID="txt_combined5_id1" runat="server" Height="16px" Width="72px"></asp:TextBox>
                            &nbsp;
                            <asp:ImageButton ID="bt_combined5_check1" runat="server" Height="23px" 
                                ImageUrl="~/images/check_icon.png" onclick="bt_combined5_check1_Click" 
                                Width="26px" />
                            Distributor Name&nbsp;
                            <asp:TextBox ID="txt_combined5_name1" runat="server" Enabled="False" Height="16px" 
                                Width="180px"></asp:TextBox>
                            &nbsp;&nbsp;Level&nbsp;
                            <asp:TextBox ID="txt_combined5_level1" runat="server" Enabled="False" Height="16px" 
                                Width="120px"></asp:TextBox>
                            &nbsp;Quota&nbsp;
                            <asp:ImageButton ID="bt_combined5_ok1" runat="server" Height="23px" 
                                ImageUrl="~/images/check_icon.png" Visible="False" Width="26px" />
                            <asp:ImageButton ID="bt_combined5_error1" runat="server" Height="23px" 
                                ImageUrl="~/images/error.png" Visible="False" Width="26px" 
                                onclick="bt_error_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;ADA ID of Distributor&nbsp;&nbsp;
                            <asp:TextBox ID="txt_combined5_id2" runat="server" Height="16px" Width="72px"></asp:TextBox>
                            &nbsp;
                            <asp:ImageButton ID="bt_combined5_check2" runat="server" Height="23px" 
                                ImageUrl="~/images/check_icon.png" onclick="bt_combined5_check2_Click" 
                                Width="26px" />
                            Distributor Name&nbsp;
                            <asp:TextBox ID="txt_combined5_name2" runat="server" Enabled="False" Height="16px" 
                                Width="180px"></asp:TextBox>
                            &nbsp;&nbsp;Level&nbsp;
                            <asp:TextBox ID="txt_combined5_level2" runat="server" Enabled="False" Height="16px" 
                                Width="120px"></asp:TextBox>
                            &nbsp;Quota&nbsp;
                            <asp:ImageButton ID="bt_combined5_ok2" runat="server" Height="23px" 
                                ImageUrl="~/images/check_icon.png" Visible="False" Width="26px" />
                            <asp:ImageButton ID="bt_combined5_error2" runat="server" Height="23px" 
                                ImageUrl="~/images/error.png" Visible="False" Width="26px" 
                                onclick="bt_error_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;ADA ID of Distributor&nbsp;&nbsp;
                            <asp:TextBox ID="txt_combined5_id3" runat="server" Height="16px" Width="72px"></asp:TextBox>
                            &nbsp;
                            <asp:ImageButton ID="bt_combined5_check3" runat="server" Height="23px" 
                                ImageUrl="~/images/check_icon.png" onclick="bt_combined5_check3_Click" 
                                Width="26px" />
                            Distributor Name&nbsp;
                            <asp:TextBox ID="txt_combined5_name3" runat="server" Enabled="False" Height="16px" 
                                Width="180px"></asp:TextBox>
                            &nbsp;&nbsp;Level&nbsp;
                            <asp:TextBox ID="txt_combined5_level3" runat="server" Enabled="False" Height="16px" 
                                Width="120px"></asp:TextBox>
                            &nbsp;Quota&nbsp;
                            <asp:ImageButton ID="bt_combined5_ok3" runat="server" Height="23px" 
                                ImageUrl="~/images/check_icon.png" Visible="False" Width="26px" />
                            <asp:ImageButton ID="bt_combined5_error3" runat="server" Height="23px" 
                                ImageUrl="~/images/error.png" Visible="False" Width="26px" 
                                onclick="bt_error_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;ADA ID of Distributor&nbsp;&nbsp;
                            <asp:TextBox ID="txt_combined5_id4" runat="server" Height="16px" Width="72px"></asp:TextBox>
                            &nbsp;
                            <asp:ImageButton ID="bt_combined5_check4" runat="server" Height="23px" 
                                ImageUrl="~/images/check_icon.png" onclick="bt_combined5_check4_Click" 
                                Width="26px" />
                            Distributor Name&nbsp;
                            <asp:TextBox ID="txt_combined5_name4" runat="server" Enabled="False" Height="16px" 
                                Width="180px"></asp:TextBox>
                            &nbsp;&nbsp;Level&nbsp;
                            <asp:TextBox ID="txt_combined5_level4" runat="server" Enabled="False" Height="16px" 
                                Width="120px"></asp:TextBox>
                            &nbsp;Quota&nbsp;
                            <asp:ImageButton ID="bt_combined5_ok4" runat="server" Height="23px" 
                                ImageUrl="~/images/check_icon.png" Visible="False" Width="26px" />
                            <asp:ImageButton ID="bt_combined5_error4" runat="server" Height="23px" 
                                ImageUrl="~/images/error.png" Visible="False" Width="26px" 
                                onclick="bt_error_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;ADA ID of Distributor&nbsp;&nbsp;
                            <asp:TextBox ID="txt_combined5_id5" runat="server" Height="16px" Width="72px"></asp:TextBox>
                            &nbsp;
                            <asp:ImageButton ID="bt_combined5_check5" runat="server" Height="23px" 
                                ImageUrl="~/images/check_icon.png" onclick="bt_combined5_check5_Click" 
                                Width="26px" />
                            Distributor Name&nbsp;
                            <asp:TextBox ID="txt_combined5_name5" runat="server" Enabled="False" Height="16px" 
                                Width="180px"></asp:TextBox>
                            &nbsp;&nbsp;Level&nbsp;
                            <asp:TextBox ID="txt_combined5_level5" runat="server" Enabled="False" Height="16px" 
                                Width="120px"></asp:TextBox>
                            &nbsp;Quota&nbsp;
                            <asp:ImageButton ID="bt_combined5_ok5" runat="server" Height="23px" 
                                ImageUrl="~/images/check_icon.png" Visible="False" Width="26px" />
                            <asp:ImageButton ID="bt_combined5_error5" runat="server" Height="23px" 
                                ImageUrl="~/images/error.png" Visible="False" Width="26px" 
                                onclick="bt_error_Click" />
                        </td>
                    </tr>
                </table>
                <div style="text-align:center;">
                    <asp:ImageButton ID="bt_combine5_update" runat="server" 
                        ImageUrl="~/images/update.jpg" onclick="bt_combine5_update_Click" />
                </div>
            </asp:Panel>
            <br />
            <asp:Panel ID="Info" runat="server" Visible= "false">
            <div class="panel">
            <table style="width: 100%;color:Window;">
                <tr>
                    <td colspan="2">
                    <div>
                        &nbsp;&nbsp;&nbsp;&nbsp; Meeting Information&nbsp;
                    </div>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;&nbsp;&nbsp;&nbsp; Meeting Name</td>
                    <td>
                        &nbsp;
                        <asp:TextBox ID="txt_meeting_name" runat="server" Width="96%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;&nbsp;&nbsp;&nbsp; Number of Participant</td>
                    <td>
                        &nbsp;
                        <asp:TextBox ID="txt_number_user" runat="server"></asp:TextBox>
                        <asp:NumericUpDownExtender ID="txt_number_user_NumericUpDownExtender" 
                            runat="server" Enabled="True" Maximum="1.7976931348623157E+308" 
                            Minimum="0" RefValues="" ServiceDownMethod="" 
                            ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" 
                            TargetButtonUpID="" TargetControlID="txt_number_user" Width="100">
                        </asp:NumericUpDownExtender>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;&nbsp;&nbsp;&nbsp; Meeting Address</td>
                    <td>
                        &nbsp;
                        <asp:TextBox ID="txt_meeting_address" runat="server" Width="96%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;&nbsp;&nbsp;&nbsp; Meeting Date</td>
                    <td>
                        &nbsp;
                        <asp:TextBox ID="txt_meeting_date" runat="server"></asp:TextBox>
                        <asp:CalendarExtender ID="txt_meeting_date_CalendarExtender" runat="server" 
                            Enabled="True" TargetControlID="txt_meeting_date">
                        </asp:CalendarExtender>
                        &nbsp;Start Time&nbsp;
                        <asp:TextBox ID="txt_start_time_hh" runat="server" Width="50px"></asp:TextBox>
                        <asp:NumericUpDownExtender ID="txt_start_time_hh_NumericUpDownExtender" 
                            runat="server" Enabled="True" Maximum="23" 
                            Minimum="0" RefValues="" ServiceDownMethod="" 
                            ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" 
                            TargetButtonUpID="" TargetControlID="txt_start_time_hh" Width="50">
                        </asp:NumericUpDownExtender>
                        &nbsp;<asp:TextBox ID="txt_start_time_mm" runat="server" Width="50px"></asp:TextBox>
                        <asp:NumericUpDownExtender ID="txt_start_time_mm_NumericUpDownExtender" 
                            runat="server" Enabled="True" Maximum="59" 
                            Minimum="0" RefValues="" ServiceDownMethod="" 
                            ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" 
                            TargetButtonUpID="" TargetControlID="txt_start_time_mm" Width="50">
                        </asp:NumericUpDownExtender>
                        &nbsp;End Time&nbsp;
                        <asp:TextBox ID="txt_end_time_hh" runat="server" Width="50px"></asp:TextBox>
                        <asp:NumericUpDownExtender ID="txt_end_time_hh_NumericUpDownExtender" 
                            runat="server" Enabled="True" Maximum="23" 
                            Minimum="0" RefValues="" ServiceDownMethod="" 
                            ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" 
                            TargetButtonUpID="" TargetControlID="txt_end_time_hh" Width="50">
                        </asp:NumericUpDownExtender>
                        &nbsp;<asp:TextBox ID="txt_end_time_mm" runat="server" Width="50px"></asp:TextBox>
                        <asp:NumericUpDownExtender ID="txt_end_time_mm_NumericUpDownExtender" 
                            runat="server" Enabled="True" Maximum="59" 
                            Minimum="0" RefValues="" ServiceDownMethod="" 
                            ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" 
                            TargetButtonUpID="" TargetControlID="txt_end_time_mm" Width="50">
                        </asp:NumericUpDownExtender>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;&nbsp;&nbsp;&nbsp; Method of Payment</td>
                    <td>
                        &nbsp;
                        <asp:DropDownList ID="ddl_payment" runat="server" Width="97%">
                        <asp:ListItem Value="1" Text="Amway thanh toán 80% cho NPP" />
                        <asp:ListItem Value="2" Text="Amway thanh toán 80% cho địa điểm" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;&nbsp;&nbsp;&nbsp; Invitation Paper</td>
                    <td>
                        &nbsp;
                        <asp:DropDownList ID="ddl_invitation_paper" runat="server" Width="97%">
                        <asp:ListItem Value="1" Text="Sử dụng mẫu giấy mời của Amway" />
                        <asp:ListItem Value="2" Text="Tự thiết kế (phải nộp mẫu để xét duyệt)" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;&nbsp;&nbsp;&nbsp; Slogan Type</td>
                    <td>
                        &nbsp;
                        <asp:DropDownList ID="ddl_slogan" runat="server" Width="97%">
                        <asp:ListItem Value="1" Text="Sử dụng mẫu biểu ngữ của Amway" />
                        <asp:ListItem Value="2" Text="Tự thiết kế (phải nộp mẫu để xét duyệt)" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;&nbsp;&nbsp;&nbsp; How to send invitation paper</td>
                    <td>
                        &nbsp;
                        <asp:TextBox ID="txt_how_to_invite" runat="server" Width="96%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;&nbsp;&nbsp;&nbsp; Date send invitation paper</td>
                    <td>
                        &nbsp;
                        <asp:TextBox ID="txt_invite_date" runat="server"></asp:TextBox>
                        <asp:CalendarExtender ID="txt_invite_date_CalendarExtender" runat="server" 
                            Enabled="True" TargetControlID="txt_invite_date">
                        </asp:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td class="style1" colspan="2">
                        &nbsp;&nbsp;&nbsp;&nbsp; Water&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        <asp:DropDownList ID="ddl_water" runat="server">
                        <asp:ListItem Value="Yes" Text="Có" />
                        <asp:ListItem Value="No" Text="Không" />
                        </asp:DropDownList>
                        
                        &nbsp;&nbsp;&nbsp;&nbsp; Water Price&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txt_water_price" runat="server">0</asp:TextBox>
                        <asp:NumericUpDownExtender ID="txt_water_price_NumericUpDownExtender" 
                            runat="server" Enabled="True" Maximum="1.7976931348623157E+308" 
                            Minimum="0" RefValues="" ServiceDownMethod="" 
                            ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" 
                            TargetButtonUpID="" TargetControlID="txt_water_price" Width="80">
                        </asp:NumericUpDownExtender>
                        &nbsp;&nbsp;&nbsp;VND&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Food&nbsp;&nbsp;
                        <asp:DropDownList ID="ddl_food" runat="server">
                        <asp:ListItem Value="Yes" Text="Có" />
                        <asp:ListItem Value="No" Text="Không" />
                        </asp:DropDownList>
                        
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Food Price&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txt_food_price" runat="server">0</asp:TextBox>
                        
                        <asp:NumericUpDownExtender ID="txt_food_price_NumericUpDownExtender" 
                            runat="server" Enabled="True" Maximum="1.7976931348623157E+308" 
                            Minimum="0" RefValues="" ServiceDownMethod="" 
                            ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" 
                            TargetButtonUpID="" TargetControlID="txt_food_price" Width="80">
                        </asp:NumericUpDownExtender>
                        
                        &nbsp; VND</td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;&nbsp;&nbsp;&nbsp;<hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    <div>
                        &nbsp;&nbsp;&nbsp;&nbsp; Local Speaker Information&nbsp;
                    </div>
                    <div>
                        &nbsp;&nbsp;&nbsp;&nbsp;ADA ID&nbsp;&nbsp;
                            <asp:TextBox ID="txt_ADA_ID_speaker1" runat="server" Width="72px">0</asp:TextBox>
                            <asp:NumericUpDownExtender ID="txt_ADA_ID_speaker1_NumericUpDownExtender" 
                            runat="server" Enabled="True" Maximum="1.7976931348623157E+308" 
                            Minimum="0" RefValues="" ServiceDownMethod="" 
                            ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" 
                            TargetButtonUpID="" TargetControlID="txt_ADA_ID_speaker1" Width="100">
                        </asp:NumericUpDownExtender>
                            &nbsp; &nbsp;Name&nbsp;
                            <asp:TextBox ID="txt_speaker1_name" runat="server" 
                                Width="180px"></asp:TextBox>
                            &nbsp;&nbsp;Level&nbsp;
                            <asp:TextBox ID="txt_speaker1_level" runat="server" 
                                Width="120px"></asp:TextBox>
                    </div>
                    <div>
                        &nbsp;&nbsp;&nbsp;&nbsp;Speak Content
                    </div>
                    <div>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txt_speaker1_content" runat="server" TextMode="MultiLine" 
                            Width="96%"></asp:TextBox>
                    </div>
                    <hr />
                    <div>
                        &nbsp;&nbsp;&nbsp;&nbsp; Foreign Speaker Information&nbsp;
                    </div>
                    <div>
                        &nbsp;&nbsp;&nbsp;&nbsp;ADA ID&nbsp;&nbsp;
                            <asp:TextBox ID="txt_ADA_ID_speaker2" runat="server" Width="72px">0</asp:TextBox>
                            <asp:NumericUpDownExtender ID="txt_ADA_ID_speaker2_NumericUpDownExtender" 
                            runat="server" Enabled="True" Maximum="1.7976931348623157E+308" 
                            Minimum="0" RefValues="" ServiceDownMethod="" 
                            ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" 
                            TargetButtonUpID="" TargetControlID="txt_ADA_ID_speaker2" Width="100">
                        </asp:NumericUpDownExtender>
                            &nbsp; &nbsp;Name&nbsp;
                            <asp:TextBox ID="txt_speaker2_name" runat="server" 
                                Width="180px"></asp:TextBox>
                            &nbsp;&nbsp;Level&nbsp;
                            <asp:TextBox ID="txt_speaker2_level" runat="server" 
                                Width="120px"></asp:TextBox>
                    </div>
                    <div>
                        &nbsp;&nbsp;&nbsp;&nbsp;Speak Content
                    </div>
                    <div>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txt_speaker2_content" runat="server" TextMode="MultiLine" 
                            Width="96%"></asp:TextBox>
                    </div>
                    <hr />
                    <div>
                        &nbsp;&nbsp;&nbsp;&nbsp;Spending Information
                    </div>
                    </td>
                <tr>
                    <td class="style2">
                        &nbsp;&nbsp;&nbsp;&nbsp; Amway Support</td>
                    <td>
                        &nbsp;
                        <asp:TextBox ID="txt_amway_pay" runat="server" Enabled="False">0</asp:TextBox>
                        &nbsp; VND</td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;&nbsp;&nbsp;&nbsp; Distributor Spend</td>
                    <td>
                        &nbsp;
                        <asp:TextBox ID="txt_dist_pay" runat="server" Enabled="False">0</asp:TextBox>
                        &nbsp; VND</td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;&nbsp;&nbsp;&nbsp; Total Spend</td>
                    <td>
                        &nbsp;
                        <asp:TextBox ID="txt_spend_to_rent" runat="server"></asp:TextBox>
                        <asp:NumericUpDownExtender ID="txt_spend_to_rent_NumericUpDownExtender" 
                            runat="server" Enabled="True" Maximum="1.7976931348623157E+308" 
                            Minimum="0" RefValues="" ServiceDownMethod="" 
                            ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" 
                            TargetButtonUpID="" TargetControlID="txt_spend_to_rent" Width="150">
                        </asp:NumericUpDownExtender>
                        &nbsp; VND</td>
                </tr>
                <tr>
                    <td colspan="2">
                    <hr />
                    <div style="text-align:center;">
                        <br />
                        <asp:ImageButton ID="bt_register" runat="server" 
                            ImageUrl="~/images/bt_register.jpg" onclick="bt_register_Click" />
                    </div>
                    </td>
                </tr>                
            </table>
            </div>
            </asp:Panel>
        </ContentTemplate> 
        </asp:UpdatePanel>
    </div>
    
</asp:Content>

