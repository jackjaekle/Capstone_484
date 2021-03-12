<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeFile="EquipmentManagement.aspx.cs" Inherits="Lab3.EquipmentManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="NewEquipment" runat="server" Text="New Equipment" Width="130px" OnClick="NewEquipment_Click" />
            <asp:Button ID="EquipmentStatus" runat="server" Text="Equipment Info" Width="130px" OnClick="EquipmentStatus_Click" />
            <asp:Button ID="EquipmentRent" runat="server" Text="Equipment Rental" OnClick="EquipmentRent_Click" Width="130px" />
            <asp:Button ID="EquipmentRentInfo" runat="server" Text="EquipmentRentInfo" OnClick="EquipmentRentInfo_Click" Width =" 150px" />

    <br />
    <br />
    <br />
    <br />

    <asp:Button ID="Return" runat="server" Text="Main Menu" OnClick="Return_Click" /><%-- Creates all the required buttons  --%>  
</asp:Content>
