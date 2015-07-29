<%@ Page Title="" Language="C#" MasterPageFile="~/View/Common.Master" AutoEventWireup="true" CodeBehind="MgrMenu.aspx.cs" Inherits="Company.Web.View.MgrMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        //菜单操作的url
        var targetUrl = "/Action/Mgr.ashx";
        var $nowRow = null;
        $(function () {
            $("#dialogModify").dialog({
                autoOpen: false,
                width: 400,
                modal: true,
                buttons: {
                    "确定": function () {
                        //1.提交修改数据
                        var data = $("#fModify").serialize();
                        alert(data);
                        $.post(targetUrl, data + "&type=m", function (jsObj) {
                            processData(jsObj, function () {
                                if ($nowRow != null) {
                                    var $tds = $nowRow.children("td");
                                    $tds[1].innerHTML = jsObj.data.MgrName;
                                    $tds[2].innerHTML = jsObj.data.MgrSort;
                                    $nowRow = null;
                                }
                            });
                        }, "json");
                        $(this).dialog("close");
                    },
                    "取消": function () {
                        $(this).dialog("close");
                    }
                }
            })
            $("btnAdd").click(showEdit);
        });
        function showSonMenu(id) {

        }
        function showEditPanel(mid, btn) {
            $nowRow = $(btn).parent().parent();
            msgBox.showMsgWait("加载中...");
            //$.get(targetUrl, { type: "get", mid: mid }, function (jsObj) {
            //    msgBox.hidBox();
            //    processData(jsObj, function () {
            //        $("#MgrName").val(jsObj.data.MgrName);
            //        $("#MgrSort").val(jsObj.data.MgrSort);
            //        $("#MgrId").val(jsObj.data.MgrId);
            //        $('#dialogModify').dialog('open');
            //    }, function () { })

            //}, "json");
            $.ajax(targetUrl, {
                type: "get",
                data: { type: "get", "mid": mid },
                dataType: "json",
                cache: false,
                success: function (jsObj) {
                    msgBox.hidBox();
                    processData(jsObj, function () {
                        $("#MgrName").val(jsObj.data.MgrName);
                        $("#MgrSort").val(jsObj.data.MgrSort);
                        $("#MgrId").val(jsObj.data.MgrId);
                        $('#dialogModify').dialog('open');
                    });
                }
            });
        }
        function doDel(pid, btn) {

        };
        function showEdit() {
            $("dialogModify").dialog("open");
        };
        //统一处理返回的数据
        function processData(jsObj, okFunc, errFunc) {
            switch (jsObj.statu) {
                case "ok":
                    okFunc();
                    break;
                case "err":
                    if (errFunc) {
                        errFunc();
                    }
                    msgBox.showMsgErr(jsObj.msg);
                    break;
                case "np":
                    msgBox.showMsgErr(jsObj.msg, function () {
                        window.location = jsObj.nextUrl;
                    });
                    break;
            }
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
                    <td><%#Company.Common.PageHelper.Bool2CnStr(Eval("MgrIsDel").ToString())%></td>
                    <td>
                        <a href="javascript:void(0)" onclick="doDel(<%#Eval("MgrId")%>,this)">删除</a>
                        <a href="javascript:void(0)" onclick="showEditPanel(<%#Eval("MgrId")%>,this)">修改</a>
                        <a href="MgrMenuSon.aspx?mid=<%#Eval("MgrId")%>">查看子菜单</a>

                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <div id="oprDiv">
        <input type="button" id="btnAdd" value="新增" />
    </div>
    <div id="dialogModify" title="修改菜单">
        <form id="fModify">
            <input type="hidden" id="MgrId" name="MgrId" />
            <table id="tbModify">
                <tr>
                    <td>菜单名称</td>
                    <td>
                        <input type="text" id="MgrName" name="MgrName" /></td>
                </tr>
                <tr>
                    <td>序列号</td>
                    <td>
                        <input type="text" id="MgrSort" name="MgrSort" /></td>
                </tr>
            </table>
        </form>
    </div>
    <%--<div id="dialogSons" title="子菜单列表">
        
    </div>--%>
</asp:Content>
