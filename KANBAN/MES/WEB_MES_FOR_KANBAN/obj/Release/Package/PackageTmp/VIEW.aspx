<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VIEW.aspx.cs" Inherits="WEB_MES_FOR_KANBAN.VIEW" %>

<%@ Register assembly="DundasWebGauge" namespace="Dundas.Gauges.WebControl" tagprefix="DGWC" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>即時生產表現儀表板</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" /> 
<meta name ="Description" content ="即時生產表現儀表板" />
<meta name ="keywords" content =<"即時生產表現儀表板" />

    <link rel="Stylesheet" href="Css/view.css" type ="text/css" />
    <style type="text/css">
        #TextArea1 {
            width: 24px;
        }
            .style2
        {
        font-family:"微軟正黑體","Microsoft JhengHei","Arial";
        font-size :16pt;
     
        }
   
    </style>
   
    <script type="text/javascript" src="jquery.min.js"></script>
</head>
<body  class ="c131010801"  onload ="onload1()">
<form id="Form1" runat ="server"  >
    <input id="usido" type="hidden"  runat="server" />
    <input id="machine_area_count" type="hidden"  runat="server" />
    <input id="if_separate" type="hidden"  runat="server" />
    <input id="build_no" type="hidden"  runat="server" />
    <input id="fabn" type="hidden"  runat="server" />
    <input id="hint" type="hidden"  runat="server" />
     <input id="update" type="hidden"  runat="server" />
     <input id="page" type="hidden"  runat="server" />
   <input id="roller_speed" type="hidden"  runat="server" />
    <asp:GridView ID="GridView1"     AutoGenerateColumns="False"  runat="server" 
       CellPadding="4" ForeColor="#333333"  Width="100%"  
        GridLines="None" AllowSorting=true 
        CssClass="style2">
        <RowStyle  BackColor="#92d050" ForeColor="#333333" Wrap=false  />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"   />
        <EditRowStyle BackColor="#999999" />
		
          <Columns>
         <asp:TemplateField HeaderText="項次" ItemStyle-HorizontalAlign="Center">
             <ItemTemplate  >
                 <asp:Label ID="Label1" runat="server"  Text=' <%#Container.DataItemIndex + 1%>'></asp:Label> 

             </ItemTemplate></asp:TemplateField>      
             <asp:BoundField DataField="工单号" HeaderText="工单号" >
                              <ItemStyle   HorizontalAlign="Center"/>
                                    <HeaderStyle HorizontalAlign="Center"  />
                          </asp:BoundField>
   <asp:BoundField DataField="客户名称"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="客户名称"   HtmlEncode="False" />
             
              <asp:BoundField DataField="站别名称" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="站别名称"   HtmlEncode="False" />
                                         <asp:BoundField DataField="进度" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="进度"  HtmlEncode="False" />
              <asp:BoundField DataField="状态" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="状态"  HtmlEncode="False" />
                           <asp:BoundField DataField="下单日期" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="下单日期"  HtmlEncode="False" />
                            <asp:BoundField DataField="预计完工日期" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="预计完工日期"  HtmlEncode="False" />
                            <asp:BoundField DataField="完工日期" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="完工日期"  HtmlEncode="False" />

                            <asp:BoundField DataField="备注" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="备注"  HtmlEncode="False" />
  </Columns>
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Bold="False" />   
    </asp:GridView>
              
    <script type ="text/javascript" >
        var arrbuild_no = new Array();
        var url = window.location.search;
        var s = url.indexOf("?");
        var t = url.substring(s + 1);
        var t1 = t.split('&');
        var area_count;
        var build_no = document.getElementById("build_no").value;
        var fabn = document.getElementById("fabn").value;
        var if_separate = document.getElementById("if_separate").value;
        var update = document.getElementById("update").value;
        var page = document.getElementById("page").value;
        var roller;
        var roller_speed = document.getElementById("roller_speed").value;
        window.onload = function onload1() {
            if (document.getElementById("hint").value == "網絡鏈接中斷") {


                //location.replace("error_page.aspx?id="+url);//如果網絡中斷將鏈接到一個類似日常畫面的錯誤頁
            }
            else {


                if (if_separate == 0) {
                    roller = 400
                    roller_speed = 100;
                    scrollhtml()

                }


            }

        }
        function enter2tab(e) {
            if (window.event.keyCode == 13) window.event.keyCode = 9
        }
        document.onkeydown = enter2tab;
        </script>
    <script type="text/javascript">

        var position = 0;
        var timeoutid = null;
        var status1 = "";
        var status2 = "go";
        function scrollhtml() {

            if (position < roller) {
                //  position++;
                position = position + 1;
                scroll(0, position);
                clearTimeout(timeoutid);
                timeoutid = setTimeout("scrollhtml()", roller_speed);
                status1 = "down";
                status2 = "go";


            }
            else {
                //          clearTimeout(timeoutid);
                //          scroll(0, 0);
                timeoutid = setTimeout("scrollhtmlup()", roller_speed);
                status1 = "up";
                status2 = "go";


            }
        }
        function scrollhtmlup() {

            if (position <= roller && position > -50) {
                // position--;

                position = position - 1;
                scroll(0, position);
                clearTimeout(timeoutid);
                timeoutid = setTimeout("scrollhtmlup()", roller_speed);

                status1 = "up";
                status2 = "go";

            }
            else {
                //            clearTimeout(timeoutid);
                //            scroll(0, 0);

                timeoutid = setTimeout("scrollhtml()", roller_speed);
                status1 = "down";
                status2 = "go";
            }
        }


        /*function stopCount() {
             if (status2 == "go") {
                 clearTimeout(timeoutid);
                 status2 = "stop";
                 // alert(status2 + "first");
             }
             else {
                 status2="go";
                 //  alert(status2 + status1);
                 if (status1 == "up") {
                     timeoutid = setTimeout("scrollhtmlup()", 1);
                 }
                 else {
                     timeoutid = setTimeout("scrollhtml()", 1);
                 }
 
             }
 
 
 
             //        if (status2 == "stop") {
             //      
             //           
             //        }
 
 
         }*/
</script>
          </form> 
</body>

</html>