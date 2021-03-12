<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeFile="LogInvToAuction.aspx.cs" Inherits="Lab3.LogInvToAuction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <p>
        Choose Customer to service</p>
    <p>
        <asp:ListBox ID="custList" runat="server" AutoPostBack ="true" OnSelectedIndexChanged ="custList_SelectedIndexChanged" Height="302px" Width="400px"></asp:ListBox>
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        Selected
        Customer Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="UserInput" runat="server" Text=""></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
     <asp:Button ID="Return" runat="server" Text="Main Menu" OnClick="Return_Click" /><%-- Creates all the required buttons  --%>  
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:Button ID="Submit" runat="server" Text="Service Customer" OnClick="Submit_Click" ValidationGroup ="Submit" />

</asp:Content>
