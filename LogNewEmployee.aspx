<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeBehind="LogNewEmployee.aspx.cs" Inherits="Lab2.LogNewEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>Noah George, William Kilpatrick</title>
    /////////real page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Noah  George, William Kilpatrick, Henry Requeno-Villeda  2/15/2021 -->
    <div style="height: 551px">
            New Employee Insertion<br /><%--the page for people who are logged in--%>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Employeee First Name"></asp:Label><%--Creates all the Labels and text boxes that need to be filled--%>
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:TextBox ID="EmployeeFirstName" runat="server"></asp:TextBox> <%--  Impliments Validators--%>
             <asp:RequiredFieldValidator ID ="empFirstReq" ControlToValidate ="EmployeeFirstName" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup ="Submit"/>
            <asp:CompareValidator ID ="empFirstVali" ControlToValidate = "EmployeeFirstName" Text ="Needs to be a String" Operator ="DataTypeCheck" Type ="String" runat ="server" ValidationGroup ="Submit"/>
           
            <br />
            Employee Last Name&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="EmployeeLastName" runat="server"></asp:TextBox> <%--  Impliments Validators--%>
             <asp:RequiredFieldValidator ID ="empLastReq" ControlToValidate ="EmployeeLastName" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup ="Submit"/>
            <asp:CompareValidator ID ="empLastVali" ControlToValidate = "EmployeeLastName" Text ="Needs to be a String" Operator ="DataTypeCheck" Type ="String" runat ="server" ValidationGroup ="Submit"/>
           
            <br />
            <asp:Label ID="Label2" runat="server" Text="Employee Phone"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="EmployeePhone" runat="server"></asp:TextBox> <%--  Impliments Validators--%>
            <asp:RequiredFieldValidator ID ="empPhoneReq" ControlToValidate ="EmployeePhone" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup ="Submit"/>
            <asp:CompareValidator ID ="empPhoneVali" ControlToValidate ="EmployeePhone" Text ="Needs to be a Phone Number. No dashes" Operator ="DataTypeCheck" Type ="Integer" runat ="server" ValidationGroup ="Submit"/>
            
            <br />
            <asp:Label ID="Label3" runat="server" Text="Employee Email"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="EmployeeEmail" runat="server"></asp:TextBox> <%--  Impliments Validators--%>
            <asp:RequiredFieldValidator ID ="empEmailReq" ControlToValidate ="EmployeeEmail" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup ="Submit"/>
            <asp:CompareValidator ID ="empEmailVali" ControlToValidate ="EmployeeEmail" Text ="Needs to be a String" Operator ="DataTypeCheck" Type ="String" runat ="server" ValidationGroup ="Submit"/>

            <br />
            <asp:Label ID="Label5" runat="server" Text="Employee Password"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Password" runat="server"></asp:TextBox> <%--  Impliments Validators--%>
            <asp:RequiredFieldValidator ID ="empPasswordReq" ControlToValidate ="Password" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup='Submit'/>
            <asp:CompareValidator ID ="empPasswordVali" ControlToValidate ="Password" Text ="Needs to be a String" Operator ="DataTypeCheck" Type ="String" runat ="server" ValidationGroup='Submit'/>
            
            <br />
            <asp:Label ID="Label4" runat="server" Text="Employee Address"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
			<asp:TextBox ID="EmployeeAddress" runat="server"></asp:TextBox> <%--  Impliments Validators--%>
            <asp:RequiredFieldValidator ID ="EmpAddressReq" ControlToValidate ="EmployeeAddress" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup ="Submit"/>
            <asp:CompareValidator ID ="empAddressVali" ControlToValidate ="EmployeeAddress" Text ="Needs to be a String" Operator ="DataTypeCheck" Type ="String" runat ="server" ValidationGroup ="Submit"/>
            
            <br />
            Employee Rank&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="rankDDL" runat="server">
            </asp:DropDownList>
            
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
