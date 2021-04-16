<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeBehind="AddServiceByPhone.aspx.cs" Inherits="Lab3.AddServiceByPhone" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <br />
            <br /><%--the page for people who are logged in--%>
            <br />
            <asp:RadioButton ID="MovingRadio" runat="server" AutoPostBack="True" Checked="True" OnCheckedChanged="MovingRadio_CheckedChanged" Text="Moving Service" />
            <%--Creates a set of radio buttons--%>
            <br />
            <asp:RadioButton ID="AuctionRadio" runat="server" AutoPostBack="True" OnCheckedChanged="AuctionRadio_CheckedChanged" Text="Auction Service" />
            <br />

            <asp:Label ID="Label1" runat="server" Text="Customer Name"></asp:Label><%--Creates all the Labels and text boxes that need to be filled--%>
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:Label ID="custNameLabel" runat="server" Text=""></asp:Label>
            
            
            <br />
            <asp:Label ID="Label2" runat="server" Text=" "></asp:Label>
            <asp:Label ID="Label4" runat="server" Text="Origin Address" Visible="true"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <%--  Impliments Validators--%>
            <asp:Label ID="originLabel" runat="server" Text="" Visible="true"></asp:Label>
            
            <br />

            &nbsp;<asp:Label ID="Label5" runat="server" Text="Destination Address"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;
            <asp:TextBox ID="SecondChanged" runat="server"></asp:TextBox>   
            <asp:RequiredFieldValidator ID ="secondChangedValiReq" ControlToValidate ="SecondChanged" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup ="Submit"/>
            <asp:CompareValidator ID ="secondChangedVali" ControlToValidate ="SecondChanged" Text ="Needs to be a String" Operator ="DataTypeCheck" Type ="String" runat ="server" ValidationGroup ="Submit"/>
            

            <br />
            &nbsp;<asp:Label ID="Label6" runat="server" Text="Service Cost"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
			<asp:TextBox ID="ServiceCost" runat="server"></asp:TextBox>    <%--  Impliments Validators--%>
            <asp:RequiredFieldValidator ID ="serviceCostReq" ControlToValidate ="ServiceCost" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup ="Submit"/>
            <asp:CompareValidator ID ="serviceCostVali" ControlToValidate ="ServiceCost" Text ="Needs to be a Double" Operator ="DataTypeCheck" Type ="Double" runat ="server" ValidationGroup ="Submit"/>
            

                <br />
                Start Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="startDate" runat="server" TextMode="Date"></asp:TextBox>
     <asp:RequiredFieldValidator ID ="RequiredFieldValidator1" ControlToValidate ="startDate" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup ="Submit"/>
            <asp:CompareValidator ID ="CompareValidator1" ControlToValidate ="startDate" Text ="Needs to be a Valid Date (mm/dd/yyyy)" Operator ="DataTypeCheck" Type ="Date" runat ="server" ValidationGroup ="Submit"/>
            

            <br />
            <asp:Label ID="Label7" runat="server" Text="Completion Date"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:TextBox ID="CompletionDate" runat="server" TextMode="Date"></asp:TextBox> <%--  Impliments Validators--%>
            <asp:RequiredFieldValidator ID ="completionDateReq" ControlToValidate ="CompletionDate" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup ="Submit"/>
            <asp:CompareValidator ID ="completionDateVali" ControlToValidate ="CompletionDate" Text ="Needs to be a Valid Date (mm/dd/yyyy)" Operator ="DataTypeCheck" Type ="Date" runat ="server" ValidationGroup ="Submit"/>
            
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
            <br />

            Service Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
           
            <asp:TextBox ID="ServiceName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID ="serviceReq" ControlToValidate ="ServiceName" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup ="Submit"/>
            <asp:CompareValidator ID ="serviceVali" ControlToValidate ="ServiceName" Text ="Needs to be a String" Operator ="DataTypeCheck" Type ="String" runat ="server" ValidationGroup ="Submit"/>
            

            <br />
            <%--Creates A list box to display output--%>
            <br />
            <asp:Button ID="Return" runat="server" Text="Main Menu" OnClick="Return_Click" /><%-- Creates all the required buttons  --%>  
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" ValidationGroup ="Submit"/>
            <asp:Label ID="MissingInput" runat="server" Text=""></asp:Label>
            <br />
            <br />
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
</asp:Content>
