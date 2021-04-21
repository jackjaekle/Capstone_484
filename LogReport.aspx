<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeBehind="LogReport.aspx.cs" Inherits="Lab3.LogReport" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged ="Date_SelectedIndexChanged"></asp:Calendar>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="All" runat="server" Text="Show all activity" OnClick="All_Click" />

    <asp:Table id="Table1" runat="server"
        CellPadding="10" 
        GridLines="Both">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="Label1" runat="server" AutoPostBack ="true" Text=""></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label2" runat="server" AutoPostBack ="true" Text=""></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="box1" runat="server" Text=""></asp:Label>
<%--                <asp:ListBox ID="custList" runat="server"></asp:ListBox>--%>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="box2" runat="server" Text=""></asp:Label>
<%--                <asp:ListBox ID="EmpList" runat="server"></asp:ListBox>--%>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <br />
    <asp:Button ID="Return" runat="server" Text="Main Menu" OnClick="Return_Click" />

</asp:Content>
