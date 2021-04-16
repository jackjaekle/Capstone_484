<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeBehind="LogAvailableAuctions.aspx.cs" Inherits="Lab3.LogAvailableAuctions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     Assign customer to available auction<br />
    <br />
     Customer Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:Label ID="custName" runat="server" Text=""></asp:Label>
     <br />
     <br />
     Upcoming Auctions&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="auctionDDL" AutoPostBack = "true" runat ="server" OnSelectedIndexChanged ="auctionDDL_SelectedIndexChanged"></asp:DropDownList>
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;<br />
     Auction Location&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:Label ID="auctLocation" runat="server" Text=""></asp:Label>
     <br />
    <br />
     Auction Start&nbsp;&nbsp;&nbsp; <%--  Impliments Validators--%>
            
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:Label ID="AuctionStart" runat="server" Text=""></asp:Label>
            
            <br />
     <br />
     <br />
            
             <asp:Label ID="Label4" runat="server" Text="Available Equipment"></asp:Label>&nbsp;&nbsp;
    <asp:DropDownList ID="equipAvail" runat="server">
    </asp:DropDownList>
        
        <asp:Button ID="equipButton" runat="server" Text="Add Equipment to Job" OnClick="equipButton_Click" />
        
        <br />
        <asp:ListBox ID="equipList" runat="server" Height="116px" Width="248px"></asp:ListBox>
    <asp:Label ID="Label2" runat="server" Text="Equipment chosen for service"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label5" runat="server" Text="Available employees"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="empAvail" runat="server" AutoPostBack="True">
    </asp:DropDownList>
    <asp:Button ID="empButton" runat="server" Text="Add Employee to Job" OnClick="empButton_Click" />
    <br />
    <asp:ListBox ID="empList" runat="server" Height="139px" Width="252px"></asp:ListBox>
    <asp:Label ID="Label3" runat="server" Text="Employees chosen for service"></asp:Label>
    <br /><br />
    <br />
    &nbsp;
    <asp:Label ID="matchCheck" runat="server" Text=""></asp:Label>
    <br />
    <br />
    <br />
    <asp:Button ID="Return" runat="server" Text="Main Menu" OnClick="Return_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="servCust" runat="server" Text="Assign to Auction" OnClick="servCust_Click" ValidationGroup='Submit' />
     <asp:Label ID="MissingText" runat="server" Text=""></asp:Label>
    <br />


</asp:Content>
