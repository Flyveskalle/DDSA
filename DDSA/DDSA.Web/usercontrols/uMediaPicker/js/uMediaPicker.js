var currentMediaPicker;
var scrollOriginalLeft;
var scroll_text;

///
//initialise method
///
function uMediaPickerInit(id, path, type, currentParent) {
    if (path != "") {
        var returnPreviewable = previewable(type);
        currentMediaPicker = currentParent;
        if (returnPreviewable == "isImage" || returnPreviewable == "isVideo") {
            var isImage = returnPreviewable == "isImage";
            chosenMedia({ outVal: { id: id, type: type, path: path, isPreviewable: true, isImage: isImage } });
        }
        else {
            $(currentParent).find("img.preview").hide();
            $(currentParent).find("img.playButton").hide();
        }
    }
    else {
        $(currentParent).find("img.preview").hide();
        $(currentParent).find("img.playButton").hide();
    }
}


$(document).ready(function () {
    ///
    //video/audio preview modal popup
    ///
    jQuery(".playButton").click(function () {
        var parent = $(this).parents(".uMediaPicker");
        var filePath = $(parent).find(".filePath").val();
        var fileType = $(parent).find(".fileType").val();
        UmbClientMgr.openModalWindow("/umbraco/plugins/umediapicker/mediapreview.aspx?path=" + filePath + "&type=" + fileType, "Preview", true, 400, 340, 60, 0, '', null);
    });

    ///
    //choose media modal popup
    ///

    jQuery(".chooseMedia").click(function () {
        currentMediaPicker = $(this).parents(".uMediaPicker");
        UmbClientMgr.openModalWindow("/umbraco/plugins/umediapicker/mediatree.aspx", "Choose media", true, 655, 515, 60, 0, '', chosenMedia);
    });

    ///
    //upload media modal popup
    ///
    jQuery(".uploadMedia").click(function () {
        currentMediaPicker = $(this).parents(".uMediaPicker");
        UmbClientMgr.openModalWindow("/umbraco/plugins/umediapicker/UploadMedia.aspx", "Upload media", true, 655, 515, 60, 0, '', chosenMedia);
    });


    ///
    //image preview
    ///
    $('.preview').click(function () {
        if ($(this).css("height") == "46px")
            $(this).stop().css("height", "").animate({ width: '430px' }, 500);
        else
            $(this).stop().animate({ height: '46px', width: '45px' }, 500);
    });

    ///
    //scroll
    ///
    $(".scrollerDiv").hover(function () {
        var parent = $(this).parents(".uMediaPicker");
        var $elmt = $(parent).find(".chosenMediaItem");
        scrollOriginalLeft = $(parent).find(".chosenMediaItem").find("span").position().left - 5;
        scroll_text = setInterval(function () {
            scrollText($elmt);
        }, 28);
    },
    function () {
        clearInterval(scroll_text);
        $(this).parents(".uMediaPicker").find(".chosenMediaItem").find('span').css({
            left: scrollOriginalLeft
        });
    });

    var scrollText = function ($elmt) {
        var span = $elmt.find("span"),
        width = $(span).width(),
        left = $(span).position().left - 6;
        if ((left + width) < (scrollOriginalLeft + $elmt.width() - 20))
            left = scrollOriginalLeft;
        $(span).css({
            left: left
        });
    };

});

///
// Returns whether the fileType is previewable and if is image or video
///
function previewable(fileType) {
    var isPlayable = true;
    switch (fileType) {
        case "mp3":
            //$("#jquery_jplayer_2").jPlayer("setMedia", { mp3: path, poster: "http://www.buzberry.com/wp-content/uploads/2009/10/red-velvet-curtain.jpg" });
            break;
        case "mp3":
            //$("#jquery_jplayer_2").jPlayer("setMedia", { m4a: path });
            break;
        case "m4v":
            //$("#jquery_jplayer_2").jPlayer("setMedia", { m4v: path });
            break;
        case "webma":
            //$("#jquery_jplayer_2").jPlayer("setMedia", { webma: path });
            break;
        case "webmv":
            //$("#jquery_jplayer_2").jPlayer("setMedia", { webmv: path });
            break;
        case "oga":
            //$("#jquery_jplayer_2").jPlayer("setMedia", { oga: path });
            break;
        case "ogv":
            //$("#jquery_jplayer_2").jPlayer("setMedia", { ogv: path });
            break;
        case "fla":
            //$("#jquery_jplayer_2").jPlayer("setMedia", { fla: path });
            break;
        case "flv":
            //$("#jquery_jplayer_2").jPlayer("setMedia", { flv: path });
            break;
        case "wav":
            //$("#jquery_jplayer_2").jPlayer("setMedia", { wav: path });
            break;
        case "mp4":
            //$("#jquery_jplayer_2").jPlayer("setMedia", { mp4: path });
            break;
        default:
            isPlayable = false;
            break;
    }
    if (isPlayable) {
        return "isVideo";
    }
    else {

        if (fileType == "jpg" ||
           fileType == "jpeg" ||
           fileType == "gif" ||
           fileType == "png" ||
           fileType == "apng" ||
           fileType == "svg" ||
           fileType == "bmp" ||
           fileType == "ico" ||
           fileType == "TIFF") {
            return "isImage";
        }
        else {
            return "";
        }
    }
}

///
//chosen media - handles the selected media item
///
function chosenMedia(e) {
    if (e.outVal != undefined && e.outVal != null) {
        var media = e.outVal;
        $(currentMediaPicker).find(".fileId").val(media.id);
        $(currentMediaPicker).find(".fileType").val(media.type);
        $(currentMediaPicker).find(".filePath").val(media.path);
        $(currentMediaPicker).find(".chosenMediaItem > span").text(media.name);
        if (media.isPreviewable) {
            if (media.isImage) {
                $(currentMediaPicker).find("img.preview").attr("src", media.path);
                $(currentMediaPicker).find("img.preview").show();
                $(currentMediaPicker).find("img.playButton").hide();
            }
            else {
                $(currentMediaPicker).find("img.preview").hide();
                $(currentMediaPicker).find("img.playButton").show();
            }
        }
        else {
            $(currentMediaPicker).find("img.preview").hide();
            $(currentMediaPicker).find("img.playButton").hide();
        }
    }
}