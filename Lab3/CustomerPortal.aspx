<%@ Page Title="" Language="C#" MasterPageFile="~/LabMasterPage.Master" AutoEventWireup="true" CodeBehind="CustomerPortal.aspx.cs" Inherits="Lab3.CustomerPortal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>Noah George, William Kilpatrick, Henry Requeno-Villeda</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    Customer Portal<br /><%--the page for people who are logged in--%>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Customer First Name"></asp:Label><%--Creates all the Labels and text boxes that need to be filled--%>
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="CustomerFirstName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID ="customerFirstRequire" ControlToValidate ="CustomerFirstName" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup='Submit'/>
            <asp:CompareValidator ID ="customerFirstVali" ControlToValidate ="CustomerFirstName" Text ="Needs to be a String" Operator ="DataTypeCheck" Type ="String" runat ="server" ValidationGroup='Submit'/>
            
            <br />
            Customer Last Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="CustomerLastName" runat="server"></asp:TextBox>          <%--  Impliments Validators--%>     
            <asp:RequiredFieldValidator ID ="customerLastReq" ControlToValidate ="CustomerLastName" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup='Submit'/>
            <asp:CompareValidator ID ="customerLastVali" ControlToValidate ="CustomerLastName" Text ="Needs to be a String" Operator ="DataTypeCheck" Type ="String" runat ="server" ValidationGroup='Submit'/>
            
            <br />
            <asp:Label ID="Label2" runat="server" Text="Customer Phone"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="CustomerPhone" runat="server"></asp:TextBox> <%--  Impliments Validators--%>
             <asp:RequiredFieldValidator ID ="custPhoneReq" ControlToValidate ="CustomerPhone" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup='Submit'/>
            <asp:CompareValidator ID ="custPhoneVali" ControlToValidate ="CustomerPhone" Text ="Needs to be an Integer" Operator ="DataTypeCheck" Type ="Integer" runat ="server" ValidationGroup='Submit'/>
            
           
            <br />
            Phone Type&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="DDL3" AutoPostBack = "true" runat ="server" ></asp:DropDownList>
            
           
            <br />
            <asp:Label ID="Label3" runat="server" Text="Customer Email"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="CustomerEmail" runat="server"></asp:TextBox> <%--  Impliments Validators--%>
            <asp:RequiredFieldValidator ID ="custEmailReq" ControlToValidate ="CustomerEmail" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup='Submit'/>
            <asp:CompareValidator ID ="custEmailvali" ControlToValidate ="CustomerEmail" Text ="Needs to be a String" Operator ="DataTypeCheck" Type ="String" runat ="server" ValidationGroup='Submit'/>

            <br />
            <asp:Label ID="Label4" runat="server" Text="Customer Password"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Password" runat="server"></asp:TextBox> <%--  Impliments Validators--%>
            <asp:RequiredFieldValidator ID ="custPasswordReq" ControlToValidate ="Password" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup='Submit'/>
            <asp:CompareValidator ID ="custPasswordVali" ControlToValidate ="Password" Text ="Needs to be a String" Operator ="DataTypeCheck" Type ="String" runat ="server" ValidationGroup='Submit'/>
            
            <br />
            How did they hear?&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="customerHear" runat="server"></asp:TextBox> <%--  Impliments Validators--%>
            <asp:RequiredFieldValidator ID ="customerHearReq" ControlToValidate ="customerHear" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup='Submit'/>
            <asp:CompareValidator ID ="customerHearVali" ControlToValidate ="customerHear" Text ="Needs to be a String" Operator ="DataTypeCheck" Type ="String" runat ="server" ValidationGroup='Submit'/>

            <br />
            Currect Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Address" runat="server"></asp:TextBox> <%--  Impliments Validators--%>
            <asp:RequiredFieldValidator ID ="CustAddressReq" ControlToValidate ="Address" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup='Submit'/>
            <asp:CompareValidator ID ="custAddressVali" ControlToValidate ="Address" Text ="Needs to be a String" Operator ="DataTypeCheck" Type ="String" runat ="server" ValidationGroup='Submit'/>
        
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
            <br />
            &nbsp;<asp:Label ID="Label7" runat="server" Text="Contact Medium"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="DDL2" AutoPostBack = "true" runat ="server" ></asp:DropDownList>

            <asp:TextBox ID="otherBox" runat="server"></asp:TextBox> <%--  Impliments Validators--%>
            <asp:RequiredFieldValidator ID ="otherBoxReq" ControlToValidate ="otherBox" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup='Submit'/>
            <asp:CompareValidator ID ="otherBoxVali" ControlToValidate ="otherBox" Text ="Needs to be a String" Operator ="DataTypeCheck" Type ="String" runat ="server" ValidationGroup='Submit'/>
            <br />

            <%--Creates A list box to display output--%>
            <br />
            <asp:Button ID="Return" runat="server" Text="Main Menu" OnClick="Return_Click" /><%-- Creates all the required buttons  --%>  
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" ValidationGroup ="Submit" />
            <asp:Label ID="MissingInput" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Button ID="PopulateButton" runat="server" OnClick="PopulateButton_Click" Text="Populate" />
            <asp:Button ID="ClearButton" runat="server" Text="Clear" OnClick="ClearButton_Click" />
            <asp:Label ID="TestLabel" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />

</asp:Content>
