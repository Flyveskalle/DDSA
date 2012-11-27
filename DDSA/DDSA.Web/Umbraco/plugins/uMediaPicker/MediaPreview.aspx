<%@ Page Language="C#" MasterPageFile="/umbraco/masterpages/umbracoPage.Master" AutoEventWireup="true" CodeBehind="MediaPreview.aspx.cs" Inherits="uMediaPicker.umbraco.plugins.uMediaPicker.MediaPreview" %>

<asp:Content ID="Content" ContentPlaceHolderID="body" runat="server">

    <link href="/usercontrols/uMediaPicker/css/jplayer.blue.monday.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/umbraco/plugins/uMediaPicker/includes/jQuery.js"></script>    
    <script type="text/javascript" src="/umbraco/plugins/uMediaPicker/includes/jPlayer.js"></script>

    
    <div class="jp-video" style="border:none;">
        <div class="jp-type-single">
            <div id="jquery_jplayer_2" class="jp-jplayer"></div>
            <div id="jp_interface_2" class="jp-interface">
                <div class="jp-video-play"></div>
                <ul class="jp-controls">
                    <li><a href="#" class="jp-play" tabindex="1">play</a></li>
                    <li><a href="#" class="jp-pause" tabindex="1">pause</a></li>
                    <li><a href="#" class="jp-stop" tabindex="1">stop</a></li>
                    <li><a href="#" class="jp-mute" tabindex="1">mute</a></li>
                    <li><a href="#" class="jp-unmute" tabindex="1">unmute</a></li>
                </ul>
                <div class="jp-progress">
                    <div class="jp-seek-bar">
                        <div class="jp-play-bar"></div>
                    </div>
                </div>
                <div class="jp-volume-bar">
                    <div class="jp-volume-bar-value"></div>
                </div>
                <div class="jp-current-time"></div>
                <div class="jp-duration"></div>
            </div>
            <div id="jp_playlist_2" class="jp-playlist">
                <ul>
                    <li>Preview</li>
                </ul>
            </div>
        </div>
    </div>
                
    <script type="text/javascript">
        var changed = false;
        var currentPath = "";
        $(document).ready(function () {
            var path = '<%= Request.QueryString["path"] %>';
            var fileType = '<%= Request.QueryString["type"] %>';
            $("#jquery_jplayer_2").jPlayer({
                ready: function () {
                    previewVideo(path, fileType);
                },
                ended: function (event) {
                    $("#jquery_jplayer_2").jPlayer("play", 0);
                },
                autoPlay: false,
                swfPath: "/usercontrols/uMediaPicker/js",
                supplied: "m4v,mp3,m4a,fla,flv,wav,mp4",
                cssSelectorAncestor: "#jp_interface_2",
                cssClass: "",
                size: { width: 384, height: 200 }
            })
            .bind($.jPlayer.event.play, function () { // pause other instances of player when current one play
                $(this).jPlayer("pauseOthers");
            });
        });

function previewVideo(path, fileType) {
    var isPlayable = true;
    switch(fileType)
    {
        case "mp3" :
            $("#jquery_jplayer_2").jPlayer("setMedia", { mp3: path, poster: "/usercontrols/umediapicker/css/preview.png"
                                                         });
            break;
        case "m4a" :
            $("#jquery_jplayer_2").jPlayer("setMedia", { 
                                                         m4a: path
                                                         
                                                        });
            break;
        case "m4v" :
            $("#jquery_jplayer_2").jPlayer("setMedia", {
                                                         
                                                         m4v: path
                                                     });
            break;
        case "webma" :
            $("#jquery_jplayer_2").jPlayer("setMedia", { webma: path });
            break;
        case "webmv" :
            $("#jquery_jplayer_2").jPlayer("setMedia", { webmv: path });
            break;
        case "oga" :
            $("#jquery_jplayer_2").jPlayer("setMedia", { oga: path });
            break;
        case "ogv" :
            $("#jquery_jplayer_2").jPlayer("setMedia", { ogv: path });
            break;
        case "fla" :
            $("#jquery_jplayer_2").jPlayer("setMedia", { fla: path });
            break;
        case "flv" :
            $("#jquery_jplayer_2").jPlayer("setMedia", { flv: path });
            break;
        case "wav" :
            $("#jquery_jplayer_2").jPlayer("setMedia", { wav: path });
            break;
        case "mp4" :
            $("#jquery_jplayer_2").jPlayer("setMedia", { mp4: path });
            break;
        default:
            isPlayable = false;
            break;
    }

    if(isPlayable) {
        $(".imagePreview").hide();
        $(".jp-video").show();
        $("#jquery_jplayer_2").jPlayer("play");
        $("#currentMediaIsPreviewable").val("true");
        $("#currentMediaIsImage").val("false");
    }
}
              
</script>
</asp:Content>

