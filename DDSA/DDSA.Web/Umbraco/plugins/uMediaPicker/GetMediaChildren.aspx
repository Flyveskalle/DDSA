<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetMediaChildren.aspx.cs" Inherits="uMediaPicker.umbraco.plugins.uMediaPicker.GetMediaChildren" %>


<%
    umbraco.cms.businesslogic.ContentType folderType = umbraco.cms.businesslogic.ContentType.GetByAlias("Folder");
    int nodeId;
    bool folderOnly = Request.QueryString["folderOnly"] != null;
    
    if (Request.Form["dir"] == null || Request.Form["dir"].Length <= 0)
        nodeId = -1;
    else
        nodeId = int.Parse(Server.UrlDecode(Request.Form["dir"]));
    umbraco.cms.businesslogic.media.Media parent = new umbraco.cms.businesslogic.media.Media(nodeId);

    string markup = "<ul class='jqueryFileTree'>";

    foreach (umbraco.cms.businesslogic.media.Media child in parent.Children.OrderBy<umbraco.cms.businesslogic.media.Media, int>(c => c.ContentType.Id).ThenBy(c => c.Text))
    {
        if (child.ContentType.Id == folderType.Id)
        {
            markup += "<li class='directory collapsed'><a href='#' rel='" + child.Id.ToString() + "'>" + child.Text + "</a></li>";
        }
        else if(!folderOnly)
        {
            string filePath = child.getProperty("umbracoFile").Value.ToString();
            string fileType = filePath.Split('.').Last();
            markup += "<li class='file ext_" + fileType + "'><a href='#' rel='" + filePath + "[split]" + child.Id.ToString() + "[split]" + child.Text + "'>" + child.Text + "</a></li>";
        }
    }
    markup += "</ul>";

    Response.Write(markup);

 %>