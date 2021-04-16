<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeBehind="AuctionPickUpForm.aspx.cs" Inherits="Lab3.AuctionPickUpForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>Noah George, William Kilpatrick, Henry Requeno-Villeda</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    Auction Pick Up Form<br /><%--the page for people who are logged in--%>
            <br />
        <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
            <br />

                <asp:Label ID="Label3" runat="server" Text="Bring in date*"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="RentDate" runat="server"></asp:TextBox>                                      <%--  Impliments Validators--%>
            <asp:RequiredFieldValidator ID ="rentDateReq" ControlToValidate ="RentDate" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup='Submit'/>
            <asp:CompareValidator ID ="rentDateVali" ControlToValidate ="RentDate" Text ="Needs to be a date (mm/dd/yyy)" Operator ="DataTypeCheck" Type ="Date" runat ="server" ValidationGroup='Submit'/>
            <br />

                <asp:Label ID="Label1" runat="server" Text="Pickup date"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>                                      <%--  Impliments Validators--%>
            <asp:CompareValidator ID ="CompareValidator1" ControlToValidate ="TextBox1" Text ="Needs to be a date (mm/dd/yyy)" Operator ="DataTypeCheck" Type ="Date" runat ="server" ValidationGroup='Submit'/>
            <br />

                <asp:Label ID="Label2" runat="server" Text="Look at date"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>                                      <%--  Impliments Validators--%>
            <asp:CompareValidator ID ="CompareValidator2" ControlToValidate ="TextBox2" Text ="Needs to be a date (mm/dd/yyy)" Operator ="DataTypeCheck" Type ="Date" runat ="server" ValidationGroup='Submit'/>
            <br />

                <asp:Label ID="Label4" runat="server" Text="Appraisal date"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>                                      <%--  Impliments Validators--%>
            <asp:CompareValidator ID ="CompareValidator3" ControlToValidate ="TextBox3" Text ="Needs to be a date (mm/dd/yyy)" Operator ="DataTypeCheck" Type ="Date" runat ="server" ValidationGroup='Submit'/>
            <br />
    
                <asp:Label ID="Label6" runat="server" Text="Sale date"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>                                      <%--  Impliments Validators--%>
            <asp:CompareValidator ID ="CompareValidator4" ControlToValidate ="TextBox4" Text ="Needs to be a date (mm/dd/yyy)" Operator ="DataTypeCheck" Type ="Date" runat ="server" ValidationGroup='Submit'/>
            <br />

                <asp:Label ID="Label5" runat="server" Text="storage location"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
			<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox> <%--  Impliments Validators--%>
            <asp:CompareValidator ID ="CompareValidator5" ControlToValidate ="TextBox5" Text ="Needs to be a String" Operator ="DataTypeCheck" Type ="String" runat ="server" ValidationGroup='Submit'/>
            <br />
                
            image upload

            <br /><br />
            * is required

            <br /><br />
            <asp:Button ID="MainMenu" runat="server" Text="Main Menu" OnClick="MainMenu_Click" /><%-- Creates all the required buttons  --%>  
            <asp:Button ID="Return" runat="server" Text="Return" OnClick="Return_Click" />
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:Button ID="Submit" runat="server" Text="Update" OnClick="Submit_Click" ValidationGroup ="Submit" />
            <asp:Label ID="MissingInput" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Button ID="PopulateButton" runat="server" OnClick="PopulateButton_Click" Text="Populate" />
            <asp:Button ID="ClearButton" runat="server" Text="Clear" OnClick="ClearButton_Click" />
            <asp:Label ID="TestLabel" runat="server" Text=""></asp:Label>

</asp:Content>
