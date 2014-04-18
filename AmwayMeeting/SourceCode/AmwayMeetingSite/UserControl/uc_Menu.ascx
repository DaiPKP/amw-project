<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Menu.ascx.cs" Inherits="UserControl_uc_Menu" %>
 <ul class="nav_top">
<asp:Repeater runat="server" ID="repMenuParent">
    <ItemTemplate>
       
            <li><a href="" title="">
                <asp:HiddenField ID="hdfMenuParent" Value='<%# DataBinder.Eval(Container.DataItem, "ID") %>' runat="server" />
                <asp:HiddenField ID="hdfGroupMenu" Value='<%# DataBinder.Eval(Container.DataItem, "GROUPMENU") %>' runat="server" />
                <%# DataBinder.Eval(Container.DataItem, "MENUNAME") %></a>
                <ul class="subnav">
                    <asp:Repeater runat="server" ID="repMenu">
                        <ItemTemplate>
                            <li><a href="<%# DataBinder.Eval(Container.DataItem, "URL") %>" title=" <%# DataBinder.Eval(Container.DataItem, "MENUNAME") %>">
                                <%# DataBinder.Eval(Container.DataItem, "MENUNAME") %></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </li>
       
    </ItemTemplate>
</asp:Repeater>
 </ul>
