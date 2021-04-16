<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeBehind="LogNewEquipment.aspx.cs" Inherits="Lab2.LogNewEquipment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>Noah George, William Kilpatrick</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!--Noah  George, William Kilpatrick, Henry Requeno-Villeda  2/15/2021 -->
    <div style="height: 551px">
            New Equipment Form<br /><%--the page for people who are logged in--%>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Equipment Name"></asp:Label><%--Creates all the Labels and text boxes that need to be filled--%>
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="EquipmentName" runat="server"></asp:TextBox> <%--  Impliments Validators--%>
            <asp:RequiredFieldValidator ID ="equipNameVal" ControlToValidate ="EquipmentName" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup ="Submit"/>
            <asp:CompareValidator ID ="equipNameReq" ControlToValidate ="EquipmentName" Text ="Needs to be a String" Operator ="DataTypeCheck" Type ="String" runat ="server" ValidationGroup ="Submit"/>
            
           
            <br />
            <asp:Label ID="Label3" runat="server" Text="Equipment Cost"></asp:Label>
            &nbsp;&nbsp; &nbsp;
            <asp:TextBox ID="EquipmentCost" runat="server"></asp:TextBox> <%--  Impliments Validators--%>
            <asp:RequiredFieldValidator ID ="EquipCostVal" ControlToValidate ="EquipmentCost" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup ="Submit"/>
            <asp:CompareValidator ID ="EquipCostReq" ControlToValidate ="EquipmentCost" Text ="Needs to be a Double" Operator ="DataTypeCheck" Type ="Double" runat ="server" ValidationGroup ="Submit"/>
            

            <br />
            <%--Creates A list box to display output--%>
            <br />
            <asp:Button ID="Return" runat="server" Text="Return" OnClick="Return_Click" /><%-- Creates all the required buttons  --%>  
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
