<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uMediaPicker.ascx.cs" Inherits="uMediaPicker.usercontrols.uMediaPicker.uMediaPicker" %>

<div id="uMediaPickerContainer" class="uMediaPicker" runat="server" style="width:450px;">
    <div class="scrollerDiv" style="margin:0px">
        <img class="playButton" style="float:left;cursor:pointer;" src="/umbraco/plugins/umediapicker/images/previewIcon.png" />
        <img class="preview" style="float:left;display:none;border:1px solid #00a9ec;border-right:0px;height:46px;width:45px;box-shadow:0px 0px -5px black;" />
        <div class="chosenMediaItem" style="position:relative;overflow:hidden;width:280px;height:36px;padding:5px;border:1px solid #00a9ec;float:left;margin-right:4px;color:#00a9ec;font-size:18px;">
            <span id="mediaName" runat="server" style="position:relative;padding-top:7px;float:left;white-space: nowrap;"></span>
        </div>
    </div>
    <a href="#" style="float:left;" class="chooseMedia"><img src="/umbraco/plugins/umediapicker/images/mediaicon.png" /></a>
    <a href="#" style="float:left;margin-left:4px;" class="uploadMedia"><img src="/umbraco/plugins/umediapicker/images/uploadicon.png" /></a>
    <asp:TextBox ID="fileType" runat="server" CssClass="fileType" style="display:none" />
    <asp:TextBox ID="filePath" runat="server" CssClass="filePath" style="display:none" />
    <asp:TextBox ID="fileId" runat="server" CssClass="fileId" style="display:none" />
</div>

<script type="text/javascript">
    $(document).ready(function () {
        var id = $("#<%= fileId.ClientID %>").val();
        var type = $("#<%= fileType.ClientID %>").val();
        var path = $("#<%= filePath.ClientID %>").val();

        uMediaPickerInit(id, path, type, $("#<%= uMediaPickerContainer.ClientID %>"));
    });
</script>