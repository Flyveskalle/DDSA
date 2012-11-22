<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FrontpageNewsList.ascx.cs" Inherits="DDSA.Web.usercontrols.FrontpageNewsList" %>
<%@ Import Namespace="DDSA.Backend.Business.DocTypes" %>
<asp:Repeater runat="server" ID="uiRptFrontpageNews">
    <ItemTemplate>
        <strong><%# ((TextPageDoctType)Container.DataItem).Headline %></strong><br />
    </ItemTemplate>
</asp:Repeater>