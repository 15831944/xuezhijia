﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NewsList.aspx.cs" Inherits="XuezhijiaWebsite.News.NewsList" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/newslist.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../Scripts/jtemplates.js" type="text/javascript"></script>
  <script type="text/javascript">
      /*--获取网页传递的参数--*/
      function request(paras) {
          var url = location.href;
          var paraString = url.substring(url.indexOf("?") + 1, url.length).split("&");
          var paraObj = {}
          for (i = 0; j = paraString[i]; i++) {
              paraObj[j.substring(0, j.indexOf("=")).toLowerCase()] = j.substring(j.indexOf("=") + 1, j.length);
          }
          var returnValue = paraObj[paras.toLowerCase()];
          if (typeof (returnValue) == "undefined") {
              return "";
          } else {
              return returnValue;
          }
      }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="newslistnav">新闻列表</div>
<div id="newslistcontent" class="newslist">

</div>
<div class="right_nav" id="right_nav">


<div class="block" id="rightblock">

</div>


</div>
<div style="clear:both;"></div>
<script type="text/javascript">

    $.ajax({
        type: "POST",
        url: "/WS/CommonService.asmx/getNewsByType",
        data: "{type:" + $.trim(request("type")) + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend: Loading, //执行ajax前执行loading函数.直到success 
        success: Success,
        error: Error
    });

    //加载中的状态
    function Loading() {
        $('#newslistcontent').html('<img src="/Image/loader.gif"/>');
    }
    //加载成功
    function Success(data, status) {
        //在0s内将透明度设为0
        //$("#newslistcontent").fadeTo(0.001, 0);
        $("#newslistcontent").setTemplateURL('../News/newslisttemplate.htm');
        $('#newslistcontent').processTemplate(data.d);
        //在1s内将透明度设为1
        //$("#newslistcontent").fadeTo(1000, 1);

    }
    </script>

     <script type="text/javascript">

         $.ajax({
             type: "POST",
             url: "/WS/CommonService.asmx/getArticleByID",
             data: "{id:'16'}",
             contentType: "application/json; charset=utf-8",
             dataType: "json",
             beforeSend: Loadingnav, //执行ajax前执行loading函数.直到success 
             success: Successnav,
             error: Error
         });

         function Error() {
             alert("error");
         }
         //加载中的状态
         function Loadingnav() {
             $('#right_nav').html('<img src="/Image/loader.gif"/>');
         }
         //加载成功
         function Successnav(data, status) {
             //在0s内将透明度设为0
             //$("#right_nav").fadeTo(0.001, 0);
             $("#right_nav").setTemplateURL('../Car/rightnav.htm', null, { filter_data: false });

             $("#right_nav").processTemplate(data.d);
             //在1s内将透明度设为1
            // $("#right_nav").fadeTo(1000, 1);

         }
    </script>

</asp:Content>
