<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeFile="LogServiceRequest.aspx.cs" Inherits="Lab3.LogServiceRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Customers waiting on service<br />
    <br />
    Select Service Type to View Customers Waiting on That Service<br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RadioButton ID="MovingRadio" runat="server" AutoPostBack="True" Checked="True" OnCheckedChanged="MovingRadio_CheckedChanged" Text="Moving Service" />
            <%--Creates a set of radio buttons--%>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RadioButton ID="AuctionRadio" runat="server" AutoPostBack="True" OnCheckedChanged="AuctionRadio_CheckedChanged" Text="Auction Service" />
            <br />
    <asp:ListBox ID="custList" runat="server" AutoPostBack ="true" OnSelectedIndexChanged ="custList_SelectedIndexChanged"  Height="271px" Width="419px"></asp:ListBox>
    <br />
    <br />
    Chosen Customer Name to service&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="UserInput" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID ="UserInputReq" ControlToValidate ="UserInput" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup='Submit'/> <%--  Impliments Validators--%>
            
            <br />
    <asp:Button ID="servCust" runat="server" Text="Service Customer" OnClick="servCust_Click" ValidationGroup='Submit' />
    <br />
    &nbsp;
    <asp:Label ID="matchCheck" runat="server" Text=""></asp:Label>
    <br />
    <br />
    <br />
    <asp:Button ID="Return" runat="server" Text="Main Menu" OnClick="Return_Click" />
    <br />
</asp:Content>
