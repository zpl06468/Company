<%@ Page Title="" Language="C#" MasterPageFile="~/View/Common.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Company.Web.View.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="placeRight" runat="server">
    <table id="tbList">
        <tr><th colspan="6">当前正在【<a href="MgrMenu.aspx">菜单列表</a>】页面</th></tr>
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
                    <td><%#Eval("MId")%></td>
                    <td><%#Eval("MName")%></td>
                    <td><%#Eval("MSort")%></td>
                    <td><%#Company.Common.PageHelper.Bool2CnStr(Eval("MIsDel").ToString())%></td>
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
    <div id="dialogModify" title="菜单操作">
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
</asp:Content>
