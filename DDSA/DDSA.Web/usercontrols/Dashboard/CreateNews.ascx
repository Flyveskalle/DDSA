<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateNews.ascx.cs"
    Inherits="DDSA.Web.usercontrols.Dashboard.CreateNews" %>
<%@ Register TagPrefix="umbraco" Namespace="umbraco.uicontrols" Assembly="controls" %>
<umbraco:Pane runat="server" ID="uiCreateNominie" Text="Opret Nyhed">
    <umbraco:PropertyPanel runat="server" ID="uiPropNewsName" >
        <asp:TextBox runat="server" ID="uiTxtNewsName" />
    </umbraco:PropertyPanel>
    <umbraco:PropertyPanel runat="server" ID="uiPropNewsShowInMenu" >
        <asp:CheckBox runat="server" AutoPostBack="false" Checked="true" Text="Vis i menu ?" ID="uiChbShowInMenu" />
    </umbraco:PropertyPanel>
    <umbraco:PropertyPanel runat="server" ID="uiPropNewsPublish" >
        <asp:CheckBox runat="server" AutoPostBack="false" Checked="true" Text="Publiser ?" ID="uiChbPublish" />
    </umbraco:PropertyPanel>
    <umbraco:PropertyPanel runat="server" ID="PropertyPanel1" Text="">
        <asp:Button runat="server" ID="uiBtnCreateNews" Text="Opret" OnClick="uiBtnCreateNewsClick"/>   
    </umbraco:PropertyPanel>
    </umbraco:Pane>