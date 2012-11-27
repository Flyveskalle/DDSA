<%@ Page Language="C#" MasterPageFile="/umbraco/masterpages/umbracoPage.Master" AutoEventWireup="true" CodeBehind="MediaTree.aspx.cs" Inherits="uMediaPicker.umbraco.plugins.uMediaPicker.MediaTree" %>




<asp:Content ID="Content" ContentPlaceHolderID="body" runat="server">

    <link href="/usercontrols/uMediaPicker/css/jplayer.blue.monday.css" rel="stylesheet" type="text/css" />
    <link href="/umbraco/plugins/uMediaPicker/includes/jQueryFileTree.css" rel="stylesheet" type="text/css" />   
    <script type="text/javascript" src="/umbraco/plugins/uMediaPicker/includes/jQuery.js"></script>    
    <script type="text/javascript" src="/umbraco/plugins/uMediaPicker/includes/jPlayer.js"></script>
    <script type="text/javascript" src="/usercontrols/uMediaPicker/js/tinyscrollbar.js"></script>
    <script type="text/javascript" src="/umbraco/plugins/uMediaPicker/includes/jQueryFileTree.js"></script>
    <script type="text/javascript" src="/umbraco/plugins/uMediaPicker/includes/jQueryeasing.js"></script>

    <style>
        body { width: 645px; background: #f0f0f0; font-family: "Trebuchet MS",verdana,arial; font-size:11px; }
        #mediaTree 
        {
            /*background: url("/umbraco_client/propertypane/images/propertyBackground.gif") repeat-x scroll center top #FFFFFF;*/
            background: white;
            border: 1px solid #D9D7D7;
            width: 340px;
            height: 430px;
            float: left;
            margin-right:2px;
            padding:0px;
            box-shadow:0 0 17px -3px #A1A1A1;
        }
    
        .preview
        {
            /*background: url("/umbraco_client/propertypane/images/propertyBackground.gif") repeat-x scroll center top #FFFFFF;*/
            width: 290px;
            height: 350px;
            float: left;
            padding: 0 5px 5px 5px;
            margin-top: 1px;
        }
        
        .buttonsBox
        {
            width: 295px;
            height: 30px;
            margin-top:10px;
            float: left;
            text-align: right;
        }
        
        .buttonsBox input[type='button']
        {
            width: 70px;
            height: 30px;
            margin-top: 10px;
            float:right;
        }
        
        .buttonsBox input[type='button']:nth-child(2)
        {
            margin-right:10px;
        }
        
        #mediaTree .viewport { width: 325px; height: 430px; overflow: hidden; position: relative; }
        #mediaTree .overview { list-style: none; position: absolute; left: 0; top: 0; }
        #mediaTree .thumb .end,
        #mediaTree .thumb { background-color: #BFBFBF; }
        #mediaTree .scrollbar { position: relative; float: right; width: 13px; }
        #mediaTree .track { height: 100%; width:13px; position: relative; padding: 0 1px; }
        #mediaTree .thumb { height: 20px; width: 13px; cursor: pointer; overflow: hidden; position: absolute; top: 0; }
        #mediaTree .thumb .end { overflow: hidden; height: 5px; width: 13px; }
        #mediaTree .disable{ display: none; }
        .noSelect { user-select: none; -o-user-select: none; -moz-user-select: none; -khtml-user-select: none; -webkit-user-select: none; }
        ul.jqueryFileTree { padding: 5px 0px 5px 5px; }
        ul.jqueryFileTree > li > ul.jqueryFileTree { padding:0px; }
    </style>

    <div style="width:100%;float:left;height:30px;margin-bottom:5px;">
        <input id="mediaSearch" type="text" value="Search..." style="width:305px;height:24px;float:left;" />
        <!--<input id="mediaSearchButton" type="button" value="Search" style="width:73px;height:32px;float:left;margin-top:-1px;" />-->
        <a href="#" id="mediaSearchButton" style="float:left;">
            <img src="/umbraco/plugins/umediapicker/images/search.png" style="height:30px;width:30px;" />
        </a>
        <input id="mediaSearchCancelButton" type="button" value="Cancel" style="width:73px;height:32px;float:left;margin-top:-1px;display:none;" />
    </div>

    <div id="mediaTree">
        <div class="scrollbar"><div class="track"><div class="thumb"><div class="end"></div></div></div></div>
        <div class="viewport">
            <div class="overview">
                <div class="mediaSearchCollection" style="display:none;">
                    
                </div>
                <div class="mediaLoader" style="display:none;margin:180px 0px 140px 140px;">
                    <img src="/umbraco/plugins/umediapicker/images/loader.gif" />
                </div>
                <div id="mediaTreePicker">
                    <ul class="jqueryFileTree" style="">
                        <li class="directory collapsed"><a href="#" rel="/this/folder/">Folder Name</a></li>
                        <li class="file ext_txt"><a href="#" rel="/this/folder/filename.txt">filename.txt</a></li>
                    </ul>
                </div>
                
            </div>
        </div>
    </div>
    <div class="preview">
        <div>
            <div class="players">
                <div class="imagePreview" style="display:none;height:277px;">
                    <img style="height:210px;width:290px;" />
                </div>
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
            </div>
        </div>
        <div class="previewDetails">
            <p>File Name: <span id="currentMediaName"></span></p>
            <p>File Type: <span id="currentMediaType"></span></p>
            <p>Media Id: <span id="currentMediaId"></span></p>
            <input type="hidden" id="currentMediaIsPreviewable" />
            <input type="hidden" id="currentMediaIsImage" />
        </div>
    </div>
    <div class="buttonsBox">
            
            <!--<input id="mediaTreeButtonOK" type="button" value="OK" />-->
            <!--<input type="button" id="mediaTreeBtnClose"  value="Cancel" />-->
            <a href="#" id="mediaTreeBtnClose"><img src="/umbraco/plugins/uMediaPicker/images/cancel.png" /></a> &nbsp; 
            <a href="#" id="mediaTreeButtonOK"><img src="/umbraco/plugins/uMediaPicker/images/tick.png" /></a>
        </div>

    <script type="text/javascript">
        var changed = false;
        var currentPath = "";
        $(document).ready(function () {
            
            $("#mediaSearch").focus(function () {
                if ($(this).val() == "Search...")
                    $(this).val("");
            }).blur(function () {
                if ($(this).val() == "")
                    $(this).val("Search...");
            });
            $("#mediaSearchButton").click(function (e) {
                var searchTerm = $("#mediaSearch").val();
                if(searchTerm == "Search..." || searchTerm == "") {
                    e.preventDefault();
                    $("#mediaSearchCancelButton").trigger("click");
                    return;
                }
                $(".mediaSearchCollection").html("");
                $("#mediaSearchCancelButton").show();
                $("#mediaTreePicker").fadeOut(50, function () {
                    $(".mediaLoader").fadeIn(100, function () {
                        $.ajax({
                            url: "/umbraco/plugins/uMediaPicker/searchmedia.ashx?search=" + searchTerm,
                        }).done(function (data) {
                            $(".mediaSearchCollection").html(data);
                            $(".mediaLoader").fadeOut(100, function () {
                                $(".mediaSearchCollection").fadeIn(100);
                                $("#mediaTree").tinyscrollbar_update();
                            });
                        });

                    });

                });
            });
            $("#mediaSearchCancelButton").click(function () {
                var $cancelButton = $(this);
                $(".mediaSearchCollection").fadeOut(100, function () {
                    $("#mediaTreePicker").fadeIn(100, function () {
                        $cancelButton.hide();
                        $("#mediaTree").tinyscrollbar_update();
                    });
                });
            });
            $("#mediaTreeButtonOK").click(function () {
                if(changed)
                {
                    var isPreviewable = $("#currentMediaIsPreviewable").val() == "true";
                    var isImage = $("#currentMediaIsImage").val() == "true";
                    var returnObj = { id: $("#currentMediaId").text(),
                             type: $("#currentMediaType").text(),
                             name: $("#currentMediaName").text(),
                             path: currentPath,
                             isPreviewable: isPreviewable,
                             isImage: isImage
                            };
                    UmbClientMgr.closeModalWindow(returnObj);
                }
                else
                {
                    UmbClientMgr.closeModalWindow();
                }

            });
            $("#mediaTreeBtnClose").click(function () {
                UmbClientMgr.closeModalWindow();
            });
            $('#mediaTree').tinyscrollbar({ axis: 'y' });
            $("#mediaTreePicker").fileTree(
                {
                    root: '-1',
                    script: "/umbraco/plugins/uMediaPicker/GetMediaChildren.aspx",
                    multiFolder: true,
                    expandSpeed: 1000,
                    collapseSpeed: 1000
                },
                previewVideo
            );
            $("li.searchPreview").live('click',function () {
                previewVideo($(this).find("a").attr("rel"));
            });

            $("#jquery_jplayer_2").jPlayer({
                ready: function () {
                    $(this).jPlayer("setMedia", {
                        mp3: "",
                        poster: "/usercontrols/umediapicker/css/preview.png"
                    });
                    //$(this).jPlayer("play", 0);
                },
                ended: function (event) {
                    $("#jquery_jplayer_2").jPlayer("play", 0);
                },
                autoPlay: false,
                swfPath: "/usercontrols/uMediaPicker/js",
                supplied: "m4v,mp3,m4a,fla,flv,wav,mp4",
                cssSelectorAncestor: "#jp_interface_2",
                cssClass: "",
                size: { width: 290, height: 200 }
            })
            .bind($.jPlayer.event.play, function () { // pause other instances of player when current one play
                $(this).jPlayer("pauseOthers");
            });
        });

function previewVideo(path)
{
    changed = true;
    
    var parts = path.split('[split]');
    path = parts[0];
    currentPath = path;
    var fileType = path.split('.')[path.split('.').length - 1].toLowerCase();
    var isPlayable = true;
    switch(fileType)
    {
        case "mp3" :
            $("#jquery_jplayer_2").jPlayer("setMedia", { mp3: path, poster: "/usercontrols/umediapicker/css/preview.png" });
            break;
        case "mp3" :
            $("#jquery_jplayer_2").jPlayer("setMedia", { m4a: path });
            break;
        case "m4v" :
            $("#jquery_jplayer_2").jPlayer("setMedia", { m4v: path });
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
            $("#jquery_jplayer_2").jPlayer("setMedia", { wav: path, poster: "/usercontrols/umediapicker/css/preview.png" });
            break;
        case "mp4" :
            $("#jquery_jplayer_2").jPlayer("setMedia", { mp4: path });
            break;
        default:
            isPlayable = false;
            break;
    }
    $("#currentMediaId").text(parts[1])
    $("#currentMediaType").text(fileType);
    $("#currentMediaName").text(parts[2]);
    $("#currentMediaIsPreviewable").val("false");
    $("#currentMediaIsImage").val("false");
    if(isPlayable)
    {
        $(".imagePreview").hide();
        $(".jp-video").show();
        $("#jquery_jplayer_2").jPlayer("play");
        $("#currentMediaIsPreviewable").val("true");
        $("#currentMediaIsImage").val("false");
    }
    else
    {
        $("#jquery_jplayer_2").jPlayer("stop");
        $(".jp-video").hide();
        $(".imagePreview").hide();
        if(fileType == "jpg" ||
           fileType == "jpeg" ||
           fileType == "gif" ||
           fileType == "png" ||
           fileType == "apng" ||
           fileType == "svg" ||
           fileType == "bmp" ||
           fileType == "ico" ||
           fileType == "TIFF")
        {
            $(".imagePreview").show();
            $(".imagePreview > img").attr("src", path);
            $("#currentMediaIsPreviewable").val("true");
            $("#currentMediaIsImage").val("true");
        }
        else
        {
            $(".imagePreview").show();
            $(".imagePreview > img").attr("src", "/umbraco/plugins/uMediaPicker/Images/unknownfile.png");
            $("#currentMediaIsPreviewable").val("false");
            $("#currentMediaIsImage").val("false");
        }
    }
}

function updateScroll()
{
    //alert("Update called");
    $('#mediaTree').tinyscrollbar_update();
}
              
</script>
</asp:Content>

