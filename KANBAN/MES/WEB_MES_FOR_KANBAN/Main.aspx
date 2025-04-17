

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="WEB_MES_FOR_KANBAN.Main" %>

<%@ Register assembly="DundasWebGauge" namespace="Dundas.Gauges.WebControl" tagprefix="DGWC" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>流程进度看板</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" /> 
<meta name ="Description" content ="流程进度看板" />
<meta name ="keywords" content =<"流程进度看板" />

    <link rel="Stylesheet" href="Css/view.css" type ="text/css" />
    <style type="text/css">
        #TextArea1 {
            width: 24px;
        }
    </style>
    <script type="text/javascript" src="jquery.min.js"></script>
</head>
<body  class ="c131010701"  onload ="onload1()">
<form id="Form1" runat ="server" >
     <input id="url" type="hidden"  runat="server" />
    <input id="usido" type="hidden"  runat="server" />
    <input id="machine_area_count" type="hidden"  runat="server" />
    <input id="if_separate" type="hidden"  runat="server" />
    <input id="build_no" type="hidden"  runat="server" />
    <input id="fabn" type="hidden"  runat="server" />
    <input id="hint" type="hidden"  runat="server" />
    <input id="page" type="hidden"  runat="server" />
    <input id="update" type="hidden"  runat="server" />
    <input id="if_show_option" type="hidden"  runat="server" />
    <input id="roller_speed" type="hidden"  runat="server" />
  
  <div>
      
      
<div  class="c13042401">
             <div class ="c13051001">
      <div class="c13052503" id ="Div2">
   <span class="c13052504" id ="Span1"><img src ="Image/logo_index.png" alt ="" /></span>
       </div>
       
          <div class="c13052908" id ="Div3">
<img id="i13052801" src=""  alt=""  style =" display :none ; float :left ; margin-top :16px; color :Blue "/>
          <span style =" margin-right :0px;"><asp:Label ID="L1" runat="server" ></asp:Label></span>
         <span style =" margin-left :10px;"><asp:Label ID="L2" runat="server" ></asp:Label></span>
         <span style =" margin-left :10px;"><asp:Label ID="L3" runat="server" ></asp:Label></span>
         <span style =" margin-left :10px;"><asp:Label ID="L4" runat="server" ></asp:Label></span>
         <span  style =" margin-left :10px;">  
             <a href ="Default.aspx" target ="_top">
              <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" ></asp:LinkButton>
              </a></span>
              
                     </div>
                 <div class ="c1305290801">
                     
                     <img src ="Image/top.jpg" alt ="" style="height:100%; width:100%" />
   </div>

    </div> 
  <div id="13102901" class="c13102901" />
      
        <div class="c13051202" id ="i13053106">
                               <div class ="c14103007">
<div class ="c13051001">
      <div class="c1305250301" id ="Div4">
          <div class="c13052503" id ="Div1">
   <span class="c13052504" id ="Span2"><img src ="Image/3.png" alt ="" /></span>
       </div>
          <asp:Label ID="ShowByStringLabel" runat="server" Text="Label"></asp:Label>
      </div>
    </div>
<div class="c14103009" id ="Div16">
<asp:DataList ID="DataList2" runat="server" RepeatColumns="15"  >
                　<ItemTemplate >    
<div id='<%#Eval ("PAGE") %>' class ="c13042901 " onclick ="farea_click('<%#Eval ("PAGE") %>')">
    <%#Eval ("MACHINE_AREA_ID") %></div>            
</ItemTemplate> 　
</asp:DataList>
           </div>
            </div>
<iframe   id="wk" name="ContentP" frameborder="0"  
        style="height: 100%; width :100% "  ></iframe>
    </div>
      </div>

  </div>
    
<script type ="text/javascript">
    function myrefresh() {
        window.location.reload();
    }
    setTimeout('myrefresh()', 1000000); //指定100秒強行刷新瀏覽器，使崩潰的瀏覽器恢復正常顯示 160817
</script>
    <script type ="text/javascript" >
        var arrbuild_no = new Array();
        var url = window.location.search;
        var s = url.indexOf("?");
        var t = url.substring(s + 1);
        var t1 = t.split('&');
        var area_count;
        var fabn=document.getElementById("fabn").value;
        var if_separate=document.getElementById("if_separate").value;
        var page=document.getElementById("page").value;
        var Invocation = document.getElementById("wk");
        var roller_speed = document.getElementById("roller_speed").value;
        var obj2 = 0;
       

     
        Invocation.target = "ContentP";
        window.onload = function onload1() {
            if (document.getElementById("hint").value =="網絡鏈接中斷") {
                document.getElementById("ShowByStringLabel").innerText = document.getElementById("hint").value;
                location.reload()//當出現錯誤頁時強制刷新瀏覽器 使頁面恢復正常 160817
                //location.replace("error_page.aspx?id="+window.location.href);//如果網絡中斷將鏈接到一個類似日常畫面的錯誤頁
                //location.replace(document.getElementById("url").value);
            }
            else {
                var timeInterval = 100000;
                if (page!=1) {
                    timeInterval = 100000;
                }
               
                    area_count = document.getElementById("machine_area_count").value;//取得區域數量
                    setInterval(changeImg, timeInterval);
                    Invocation.src = "view.aspx?page=" + page + "";
                    document.getElementById(page).className = "c13042902";//僅分區顯示時邊框顏色才選中
                
                
            }
           
        }
        function changeImg() {
            if (s == -1) {
                farea(1);
            }
            else if (t1.length > 0) {
                farea(t1[0].substring(5));//截取區域數值
            }
        }
        function farea(obj) {
            if (parseInt(obj) > parseInt(area_count)-1) {
                obj = 1;
                //alert(area_count+"count");
                location.replace("main.aspx?page=" +obj + "")
                Invocation.src = "view.aspx?page="+obj+"";
            }
            else {
                obj = parseInt(obj) + 1;
                //alert(obj);
                location.replace("main.aspx?page=" + obj + "")
                Invocation.src = "view.aspx?page=" + obj + "";
              
            }
        }
        function farea_click(obj) {
            location.replace("main.aspx?page=" + obj + "")
            Invocation.src = "view.aspx?page=" + obj + "";
        }
        function b(obj) {
            var dom = document.all;
            var ele = event.srcElement;
            if (ele.tagName == "INPUT" && ele.type.toLowerCase() == "radio")
            {
                for (i = 0; i < dom.length; i++)
                {
                    if (dom[i].tagName == "INPUT" && dom[i].type.toLowerCase() == "radio")
                    { dom[i].checked = false; }
                }
            }
            ele.checked = true;
            location.replace("main.aspx?page=" + t1[0].substring(5) + "")

        }
        function x(s) {
            var test = /^[0-9]*$/;
            var result = test.test(s);
            return result;
        }
        function enter2tab(e) {
            if (window.event.keyCode == 13) window.event.keyCode = 9
        }
        document.onkeydown = enter2tab;
        </script>

          </form> 
</body>

</html>