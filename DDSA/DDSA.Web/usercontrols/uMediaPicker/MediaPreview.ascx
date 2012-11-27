<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MediaPreview.ascx.cs" Inherits="uMediaPicker.usercontrols.uMediaPicker.MediaPreview" %>

        <link href="/usercontrols/uMediaPicker/css/jplayer.blue.monday.css" rel="stylesheet" type="text/css" />
        
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>    
        <script type="text/javascript" src="http://jplayer.org/2.1.0/js/jquery.jplayer.min.js"></script>
        <script type="text/javascript">

            /*paste or reference your JS here*/
              
        </script>

<div class="example">

    <div>
        <div class="players">
            <div class="jp-video jp-video-270p">
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

        </div>
    </div>

</div>


<script type="text/javascript">
    $(document).ready(function(){

    $("#jquery_jplayer_1").jPlayer({
        ready: function () {
            $(this).jPlayer("setMedia", {
                mp3: "media/track.mp3",
            }).jPlayer("play"); // auto play
        },
        ended: function (event) {
            $(this).jPlayer("play");
        },
        swfPath: "swf",
        supplied: "mp3"
    })
    .bind($.jPlayer.event.play, function() { // pause other instances of player when current one play
            $(this).jPlayer("pauseOthers");
    });

    $("#jquery_jplayer_2").jPlayer({
        ready: function () {
            $(this).jPlayer("setMedia", {
                <%= FileType %>: "<%= UmbracoFile %>",
            });
        },
        ended: function (event) {
            $("#jquery_jplayer_2").jPlayer("play", 0);
        },
        swfPath: "/usercontrols/uMediaPicker/js",
        supplied: "<%= FileType %>",
        cssSelectorAncestor: "#jp_interface_2"
    })
    .bind($.jPlayer.event.play, function() { // pause other instances of player when current one play
            $(this).jPlayer("pauseOthers");
    });

});
              
</script>