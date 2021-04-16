<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeBehind="DriverPage.aspx.cs" Inherits="Lab3.DriverPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="Label1" runat="server" Text="View an Upcoming Move:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="MoveDDL" runat="server" AutoPostBack ="true"></asp:DropDownList>
            </asp:TableCell>
        
        </asp:TableRow>
        <asp:TableRow>
           
        </asp:TableRow>
    </asp:Table>
    <br />
    <asp:GridView ID="SpecificGV" runat="server" Visible="false" ></asp:GridView>
    <asp:GridView ID="VehicleGV" runat="server" Visible="false"></asp:GridView>
    <br />
    
</asp:Content>
