<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeBehind="LogAuctionInfo.aspx.cs" Inherits="Lab3.LogAuctionInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <!--Noah  George, William Kilpatrick, Henry Requeno-Villeda  2/15/2021 -->
    <div style="height: 551px">
            Retreive Auction Info<br /><%--the page for people who are logged in--%>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Auction Name"></asp:Label><%--Creates all the Labels and text boxes that need to be filled--%>
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:DropDownList ID="DDL" AutoPostBack = "true" runat ="server" ></asp:DropDownList>
            <br />
             <asp:Button
                    ID="btnLoadEmployeeData"
                    runat="server"
                    Text="Show Auction Information>"
                    OnClick="btnLoadEmployeeData_Click" />
                <asp:Button ID="BtnShowAll" runat="server" Text="Show All Auctions Information >"
                    OnClick="BtnShowAll_Click" />
            

            <br />
            

            <asp:ListBox ID="AuctionInformation" runat="server" Height="283px" Width="829px"></asp:ListBox><%--Creates A list box to display output--%>
            <br />
            <asp:Button ID="Return" runat="server" Text="Main Menu" OnClick="Return_Click" /><%-- Creates all the required buttons  --%>  
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			
            <asp:Label ID="MissingInput" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <br />
           
            <br />
            <br />
            <br />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />

        </div>
</asp:Content>
