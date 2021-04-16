<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeBehind="LogEquipmentRentInfo.aspx.cs" Inherits="Lab2.LogEquipmentRentInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Noah George, William Kilpatrick</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Noah  George, William Kilpatrick, Henry Requeno-Villeda  2/15/2021 -->
    <div style="height: 551px">
            Equipment Rent Information<br /><%--the page for people who are logged in--%>
           <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Equipment Name"></asp:Label><%--Creates all the Labels and text boxes that need to be filled--%>
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:DropDownList ID="DDL" AutoPostBack = "true" runat ="server" ></asp:DropDownList>
            <br />
             <asp:Button
                    ID="btnLoadEquipmentData"
                    runat="server"
                    Text="Show Equipment Information>"
                    OnClick="btnLoadEquipmentData_Click" />
                <asp:Button ID="BtnShowAll" runat="server" Text="Show All Equipment Information >"
                    OnClick="BtnShowAll_Click" />
            

            <br />
            

            <asp:ListBox ID="EquipmentInformation" runat="server" Height="283px" Width="829px"></asp:ListBox><%--Creates A list box to display output--%>
            <br />
            <asp:Button ID="Return" runat="server" Text="Return" OnClick="Return_Click" /><%-- Creates all the required buttons  --%>  
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
