<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeBehind="LogMoveFormInfo.aspx.cs" Inherits="Lab3.LogMoveFormInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Choose what move you would like information on"></asp:Label>
    <asp:DropDownList ID="ddlMoveForm" runat="server" DataSourceID="dtaSrcMoveFormID" DataTextField="MoveFormID"></asp:DropDownList>
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    <fieldset>
        <legend>
            <asp:Label ID="lblMoveForm" runat="server" Text="MoveForm Information"></asp:Label>
        </legend>
        <asp:GridView ID="grdMoveForm" runat="server"></asp:GridView>
    </fieldset>
    <fieldset>
        <legend>
            <asp:Label ID="lblRoomInfo" runat="server" Text="Rooms Information"></asp:Label>
        </legend>
        <asp:GridView ID="grdRoomInfo" runat="server"></asp:GridView>
    </fieldset>
    <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click"/>
    <asp:SqlDataSource ID="dtaSrcMoveFormID" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>"  SelectCommand ="SELECT MoveFormID from MoveForm"></asp:SqlDataSource>

</asp:Content>
