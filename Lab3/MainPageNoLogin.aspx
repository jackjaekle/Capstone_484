<%@ Page Title="" Language="C#" MasterPageFile="~/LabMasterPage.Master" AutoEventWireup="true" CodeBehind="MainPageNoLogin.aspx.cs" Inherits="Lab1.MainPageNoLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>Noah George, William Kilpatrick, Henry Requeno-Villeda</title>

    <style type="text/css">
        #myIframe {
            width: 1342px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--the page for people who are not logged in--%>
<!--Noah  George, William Kilpatrick, Henry Requeno-Villeda  2/15/2021 -->

    <div align="center">
        <iframe src="https://www.greenvalleyauctions.com/" frameborder="0" style="width: 100%; height: 100%; min-height: 1000px; border:none;" scrolling="auto"></iframe>
        </div>
</asp:Content>
