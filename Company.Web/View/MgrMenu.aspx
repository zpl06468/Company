<%@ Page Title="" Language="C#" MasterPageFile="~/View/Common.Master" AutoEventWireup="true" CodeBehind="MgrMenu.aspx.cs" Inherits="Company.Web.View.MgrMenu" %>
<script src="../Script/jquery-1.9.0.min.js"></script>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#dialogModify").dialog({
                autoOpen: false,
                width: 400,
                modal: true,
                buttons: {
                    "确定": function () {
                        $(this).dialog("close");
                    },
                    "取消": function () {
                        $(this).dialog("close");
                    }
                }
            })
        });
        function showSonMenu(id)
        {
            
        }
        function showEditPanel(mid)
        {
            msgBox.showMsgWait("加载中...");
            $.get("/Action/Mgr.ashx", { type: "get", mid: mid }, function (jsObj)
            {
                msgBox.hidBox();
                switch (jsObj.statu) {
                    case "ok":
                        $("#MgrName").val(jsObj.data.MgrName);
                        $("#MgrSort").val(jsObj.data.MgrSort);
                        $('#dialogModify').dialog('open');
                        break;
                    case "err":
                        msgBox.showMsgErr(jsObj.msg);
                }
                
            },"json")
        }
        function doDel(pid,btn)
        {

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="placeRight" runat="server">
    <table id="tbList">
        <tr>
            <th>Id</th>
            <th>菜单名</th>
            <th>序号</th>
            <th>删除标识</th>
            <th>操作</th>
        </tr>
        <asp:Repeater runat="server" ID="rptList">
            <ItemTemplate>
                <tr>
                    <td><%#Eval("MgrId")%></td>
                    <td><%#Eval("MgrName")%></td>
                    <td><%#Eval("MgrSort")%></td>
                    <td><%#IsDel(Eval("MgrAddtime").ToString())%></td>
                    <td>
                        <a href="javascript:void(0)" onclick="doDel(<%#Eval("MgrId")%>,this)">删除</a>
                        <a href="javascript:void(0)" onclick="showEditPanel(<%#Eval("MgrId")%>)">修改</a>
                        <a href="javascript:void(0)" onclick="showSonMenu(<%#Eval("MgrId")%>)">查看子菜单</a>

                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <div id="dialogModify" title="修改菜单">
        <table id="tbModify">
            <tr>
                <td>菜单名称</td><td><input type="text" id="MgrName" /></td>
            </tr>
            <tr>
                <td>序列号</td><td><input type="text" id="MgrSort" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
