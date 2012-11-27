<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TextPageTags.ascx.cs" Inherits="DDSA.Web.usercontrols.TextPageTags" %>
<asp:Repeater runat="server" ID="uiRptTags">
    <ItemTemplate>
        <asp:Button runat="server" ID="uiBtnTag" Text="<%# Container.DataItem %>" OnClick="uiBtnTagClick" />
    </ItemTemplate>
</asp:Repeater>