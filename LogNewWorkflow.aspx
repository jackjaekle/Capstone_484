<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeBehind="LogNewWorkflow.aspx.cs" Inherits="Lab2.LogNewWorkflow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>Noah George, William Kilpatrick</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!--Noah  George, William Kilpatrick, Henry Requeno-Villeda  2/15/2021 -->
    <div style="height: 551px">
            New Workflow<br /><%--the page for people who are logged in--%>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Employee Name"></asp:Label><%--Creates all the Labels and text boxes that need to be filled--%>
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			 <asp:DropDownList ID="empDDL" AutoPostBack = "true" runat ="server" ></asp:DropDownList>   <%--  Impliments Validators--%>          
            <
            <br />
            <asp:Label ID="Label2" runat="server" Text="Service Name"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="serviceDDL" AutoPostBack = "true" runat ="server" ></asp:DropDownList>      
           
            <br />
            <asp:Label ID="Label3" runat="server" Text="Start Date"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="StartDate" runat="server"></asp:TextBox>       <%--  Impliments Validators--%>      
            <asp:RequiredFieldValidator ID ="startDateReq" ControlToValidate ="StartDate" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup ="Submit"/>
            <asp:CompareValidator ID ="startDateVali" ControlToValidate ="StartDate" Text ="Needs to be a valid Date (mm/dd/yyyy)" Operator ="DataTypeCheck" Type ="Date" runat ="server" ValidationGroup ="Submit"/>
            <br />
            <asp:Label ID="Label4" runat="server" Text="End Date"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
			<asp:TextBox ID="EndDate" runat="server"></asp:TextBox>     <%--  Impliments Validators--%>        
            <asp:RequiredFieldValidator ID ="endDateReq" ControlToValidate ="EndDate" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup ="Submit"/>
            <asp:CompareValidator ID ="endDateAdvance" ControlToValidate ="EndDate" ControlToCompare= "StartDate" Text ="Needs to be after the Start Date" Operator ="GreaterThan" Type ="Date" runat ="server" ValidationGroup ="Submit"/>
            
            <br />
            <asp:Label ID="Label5" runat="server" Text="Status"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
			<asp:TextBox ID="Status" runat="server"></asp:TextBox> <%--  Impliments Validators--%>
            <asp:RequiredFieldValidator ID ="statusReq" ControlToValidate ="Status" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup ="Submit"/>
            <asp:CompareValidator ID ="statusVali" ControlToValidate ="Status" Text ="Needs to be a String" Operator ="DataTypeCheck" Type ="String" runat ="server" ValidationGroup ="Submit"/>
            <br />
            <%--Creates A list box to display output--%>
            <br />
            <asp:Button ID="Return" runat="server" Text="Main Menu" OnClick="Return_Click" /><%-- Creates all the required buttons  --%>  
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" ValidationGroup ="Submit"/>
            <asp:Label ID="MissingInput" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Button ID="PopulateButton" runat="server" OnClick="PopulateButton_Click" Text="Populate" />
            <asp:Button ID="ClearButton" runat="server" OnClick="ClearButton_Click" Text="Clear" />
            <asp:Label ID="TestLabel" runat="server" Text=""></asp:Label>
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
