<%@ Page Title="" Language="C#" MasterPageFile="~/View/Common.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Company.Web.View.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#divLeft .claTitle").click(function () {
                $(this).siblings("li").slideToggle();
            });
        });
      
</script>
</asp:Content>

<asp:Content ID="contentbody" ContentPlaceHolderID="placeRight" runat="server">
    哇哈哈哈哈000000000
</asp:Content>
