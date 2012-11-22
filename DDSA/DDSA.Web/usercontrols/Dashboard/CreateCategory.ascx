<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateCategory.ascx.cs" Inherits="DDSA.Web.usercontrols.Dashboard.CreateCategory" %>
<%@ Register TagPrefix="umbraco" Namespace="umbraco.uicontrols" Assembly="controls" %>
<umbraco:Pane runat="server" ID="uiCreateNominie">
    <umbraco:PropertyPanel runat="server" ID="uiPropCategory" Text="Kategori navn">
        Årets <asp:TextBox runat="server" ID="uiTxtCategoryName" /><br />
        <asp:Label runat="server" ID="uiLblMessage" />
    </umbraco:PropertyPanel>
    <umbraco:PropertyPanel runat="server" ID="PropertyPanel1" Text="">
        <asp:Button runat="server" ID="uiBtnCreateCategory" Text="Opret kategori" OnClick="uiBtnCreateCategoryClick" />
    </umbraco:PropertyPanel>
    </umbraco:Pane>