<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeFile="CustServReq.aspx.cs" Inherits="Lab3.CustServReq" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:RadioButton ID="MovingRadio" runat="server" AutoPostBack="True" Checked="True" OnCheckedChanged="MovingRadio_CheckedChanged" Text="Moving Service" />
            <%--Creates a set of radio buttons--%>
            <br />
            <asp:RadioButton ID="AuctionRadio" runat="server" AutoPostBack="True" OnCheckedChanged="AuctionRadio_CheckedChanged" Text="Auction Service" />
            <br />
     <br />
     Requested Start Date&nbsp;
     <asp:TextBox ID="reqDate" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID ="dateReq" ControlToValidate ="reqDate" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup ="Submit"/>
            <asp:CompareValidator ID ="dateVali" ControlToValidate ="reqDate" Text ="Needs to be a Valid Date (mm/dd/yyyy)" Operator ="DataTypeCheck" Type ="Date" runat ="server" ValidationGroup ="Submit"/>
     <br />
     Service Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:TextBox ID="servAddress" runat="server"></asp:TextBox>
     <br />
     Description of needs<br />
&nbsp;<asp:TextBox ID="descOfNeeds" runat="server" Height="141px" Width="302px"></asp:TextBox>
     <asp:RequiredFieldValidator ID ="needsReq" ControlToValidate ="descOfNeeds" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup ="Submit"/>
         
     <br />
     <br />

    <asp:Button ID="Return" runat="server" Text="Main Menu" OnClick="Return_Click" /><%-- Creates all the required buttons  --%>  
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" ValidationGroup ="Submit"/>
            <asp:Label ID="MissingInput" runat="server" Text=""></asp:Label>
     <br />
     <br />
     <br />
     <br />
     <br />
     <br />
            <br />


</asp:Content>
