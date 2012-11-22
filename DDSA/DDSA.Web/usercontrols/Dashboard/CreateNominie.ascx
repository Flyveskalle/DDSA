<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateNominie.ascx.cs" Inherits="DDSA.Web.usercontrols.Dashboard.CreateNominie" %>
<%@ Register TagPrefix="umbraco" Namespace="umbraco.uicontrols" Assembly="controls" %>
<umbraco:Pane runat="server" ID="uiCreateNominie" Text="Opret nomineret artist">
    <umbraco:PropertyPanel runat="server" ID="uiPropNominie" Text="Nomineret navn">
        <asp:TextBox runat="server" ID="uiTxtNominieName" /><br />
        <asp:Label runat="server" ID="uiLblMessage" />
    </umbraco:PropertyPanel>
    <umbraco:PropertyPanel runat="server" ID="PropertyPanel1" Text="Nomineret navn">
        <asp:Button runat="server" Text="Opret nomineret" ID="uiBtnCreateArtist" OnClick="uiBtnCreateArtistClick" />
    </umbraco:PropertyPanel>
    

</umbraco:Pane>