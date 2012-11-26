<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateNewsletter.ascx.cs"
    Inherits="DDSA.Web.usercontrols.Dashboard.CreateNewsletter" %>
<%@ Import Namespace="DDSA.Backend.Business.DocTypes" %>
<%@ Import Namespace="umbraco.cms.businesslogic.media" %>
<%@ Import Namespace="umbraco.NodeFactory" %>
<link href="/scripts/ui-lightness/jquery-ui-1.9.1.custom.css" rel="stylesheet" type="text/css" />
<script src="/scripts/jquery-1.8.3.js" type="text/javascript"></script>
<script src="/scripts/jquery-ui-1.9.1.custom.js" type="text/javascript"></script>
<style>
    #settings
    {
        width: 100px;
        min-height: 300px;
        padding: 2px;
        margin-left: 20px;
        background-color: #E6E6DC;
        float: left;
        -moz-border-radius: 5px;
        border-radius: 5px;
    }
    
    #settings .button
    {
        width: 94px;
        height: 70px;
        margin: 3px;
    }
    
    #sortable, #banners
    {
        list-style-type: none;
        margin: 0;
        padding: 0;
        width: 500px;
    }
    
    #sortable li, #banners li
    {
        margin: 0 5px 5px 5px;
        padding: 5px;
        font-size: 1.2em;
        height: 150px;
    }
    
    html > body #sortable li, #newsletter li .news, #banners li .news
    {
        height: 150px;
        line-height: 1em;
        font-family: Verdana;
        font-size: 15px;
    }
    
    #newsletterConatiner
    {
        float: left;
        min-height: 500px;
        margin-left: 40px;
        width: 532px;
        background-color: #E6e6DC;
        -moz-box-shadow: 0 0 5px #888;
        -webkit-box-shadow: 0 0 5px #888;
        box-shadow: 0 0 5px #888;
    }
    
    #newsletter
    {
        width: 500px;
        min-height: 170px;
        padding: 5px;
        border: 1px solid #D3D3D3;
        float: left;
        margin-left: 10px;
    }
    
    #newsletter li
    {
        margin: 0 5px 5px 5px;
        padding: 5px;
        font-size: 1.2em;
        height: 155px;
        list-style-position: outside;
        list-style-type: none;
        background-color: #D3D3D3;
    }
    
    #newsletter li .news, #sortable li .news, #banners li .news
    {
        background-color: White;
    }
    
    .ui-state-highlight
    {
        height: 150px;
        line-height: 0.2em;
    }
    
    .news
    {
        width: 475px;
        height: 145px;
        border: 1px solid black;
        padding: 2px;
        float: left;
    }
    
    .news img
    {
        width: 150px;
        padding-right: 5px;
        float: left;
    }
    
    .desc
    {
    }
    
    .ui-state-highlight
    {
        border: 2px solid #fed22f;
    }
    
    .ui-tabs
    {
        float: left;
        height: 700px;
        width: 540px;
    }
</style>
<script type="text/javascript" language="javascript">
    $(function () {
        $('#tabs').tabs();

        $("#sortable, #newsletter, #banners").sortable({
            connectWith: "#newsletter",
            placeholder: "ui-state-highlight"
        }).disableSelection();

    });

    function save_list() {
        var result = "";
        var listLength = $('#newsletter li.item').length-1;
        var count = 0;
        $('#newsletter li').each(function (index, elm) {

            if ($(elm).hasClass("item")) {
                console.log('count: ' + count + ' listLength: ' + listLength);


                result += $(elm).find(':hidden').val();
                result += ",";
                result += $(elm).find('.news').length > 0;
                result += count == listLength ? '' : '|';
                count++;
            }
        });
        console.log(result);
                        $.ajax({
                            url: '/Webservices/Dashboard/Handler1.ashx',
                            data: "result="+result

        //                    success: function (response) {
        //                        $('#testing').append('<li>' + index + '||' + $(elm).find('strong').html() + '</li>');
        //                    }

                        });
    }

    //            
    //        }
</script>
<div id="tabs">
    <ul>
        <li><a href="#tabs-1">Nyheder</a> </li>
        <li><a href="#tabs-2">Banner</a> </li>
    </ul>
    <div id="tabs-1">
        <div style="float: left; min-width: 500px; min-height: 100px; background-color: lightgray;
            border: 1px solid black;">
            <ul id="sortable">
                <asp:Repeater runat="server" ID="uiRptNewslist">
                    <ItemTemplate>
                        <li class="item">
                            <div class="news">
                                <input type="hidden" value="<%# ((TextPageDoctType)Container.DataItem).Id %>" />
                                <strong>
                                    <%# ((TextPageDoctType)Container.DataItem).Name%></strong>
                                <img src="/Images/WebGraphics/fish-food_1224_549_100.jpg" />
                                <div class="desc">
                                    <%# ((TextPageDoctType)Container.DataItem).ShortDescription%>
                                </div>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
    <div id="tabs-2">
        <ul id="banners">
            <asp:Repeater runat="server" ID="uiRptMedia">
                <ItemTemplate>
                    <li class="item">
                    <input type="hidden" value="<%# ((Media)Container.DataItem).Id %>" />
                        <img src='<%# ((Media)Container.DataItem).getProperty("umbracoFile").Value %>' alt="<%# ((Media)Container.DataItem).Text %>" /><br />
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
<div id="newsletterConatiner">
    <ul id="newsletter">
        <li></li>
    </ul>
</div>
<div id="settings">
    <input type="button" value="Gem" id="uiBtnSave" class="button" onclick="javascript:save_list();" />
    <input type="button" value="Udgiv" id="Button1" class="button" />
    <ul id="testing">
    </ul>
</div>
