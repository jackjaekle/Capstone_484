<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeFile="LogInDepth.aspx.cs" Inherits="Lab3.LogInDepth" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    View In Depth Customer Info<br />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
     &nbsp;&nbsp;&nbsp;&nbsp;

    <asp:DropDownList ID="ListBox2" AutoPostBack = "true" runat ="server" OnSelectedIndexChanged ="custStuff_SelectedIndexChanged"></asp:DropDownList>


    <br /><br />
    <asp:ListBox ID="Info_Box" runat="server" Height="283px" Width="829px"></asp:ListBox><%--Creates A list box to display output--%>
    <br />
    <asp:Button ID="Return" runat="server" Text="Main Menu" OnClick="Return_Click" /><%-- Creates all the required buttons  --%>  
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Info_Click1" runat="server" Text="Customer Information" OnClick="Info_Click" />

</asp:Content>