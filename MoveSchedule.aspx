<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeBehind="MoveSchedule.aspx.cs" Inherits="Lab3.MoveSchedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2"  ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table ID="Table1" runat="server">
    <asp:TableRow>
        <asp:TableCell>
           Select a Customer waiting on Moving service assignment
        </asp:TableCell>
    </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="Label1" runat="server" Text="Filler" ForeColor="White"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:ListBox ID="CustomerInfo" runat="server" Height="100px" Width="500px"></asp:ListBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="Label2" runat="server" Text="Filler" ForeColor="White"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
               
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="EstimateSheet" runat="server" Text="Move to Estimate Sheet for Chosen Customer" OnClick="EstimateSheet_Click" />
            </asp:TableCell>
            <asp:TableCell>
                 <asp:Button ID="Return" runat="server" Text="Main Menu" OnClick="Return_Click"/>
            </asp:TableCell>
        </asp:TableRow>

    </asp:Table>
    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
</asp:Content>
