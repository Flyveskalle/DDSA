<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsletterSignup.ascx.cs" Inherits="DDSA.Web.usercontrols.NewsletterSignup" %>
<asp:PlaceHolder runat="server" ID="uiPhNewsletterSignUpForm">
    <div class="newslettersignup">
        <asp:Label runat="server" ID="uiLblNewsletterSignUpName" Text="Navn" AssociatedControlID="uiTxtNewsletterSignUpName" />
        <asp:TextBox runat="server" ID="uiTxtNewsletterSignUpName" /><br />
        <asp:Label runat="server" ID="uiLblNewsletterSignUpEmail" Text="Navn" AssociatedControlID="uiTxtNewsletterSignUpName" />
        <asp:TextBox runat="server" ID="uiTxtNewsletterSignUpEmail" /><br />
        <asp:Button runat="server" ID="uiBtnNewsletterSignUp" Text="Tilmeld" OnClick="BtnNewsletterSignUpClick" />
        <asp:Label runat="server" ID="uiLblNewsletterSignUpMessage" />
    </div>
</asp:PlaceHolder>