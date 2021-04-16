<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeBehind="CustHistoryPage.aspx.cs" Inherits="Lab3.CustHistoryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="NewCustomerBtn" runat="server" Text="Create a New Customer"  OnClick="NewCustomerBtn_Click"/>
    <br />
    <asp:ListBox ID="CustLB" runat="server" OnSelectedIndexChanged="CustLB_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
    <br />
    <asp:Label ID="NameLbl" runat="server" Text=""></asp:Label>
    <br />
    Customer Address:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="add" runat="server" Text=""></asp:Label>
    <br />
    Customer Phone:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="phone" runat="server" Text=""></asp:Label>
    <br />
    Customer Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="email" runat="server" Text=""></asp:Label>
    <br />
    Customer Discovery type:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="disc" runat="server" Text=""></asp:Label>
    <br />
   
    <br />
   
    <br />
    <asp:Button ID="NewServiceBtn" runat="server" Text="Create a new service for selected customer"  OnClick="NewServiceBtn_Click"/>
    <br />
    <br />
    <br />
    <br />
      <asp:Label ID="Label2" runat="server" Text="Select a Service Event to update and/or view information:" Visible="false"></asp:Label>
    <br />
    <asp:ListBox ID="SvcLB" runat="server" Visible="false" OnSelectedIndexChanged="SvcLB_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
    <br />
    Service Details<br />
   
    <asp:GridView ID="InfoGV" runat="server" Visible="true"> </asp:GridView> 
   
    <asp:Button ID="UpdateBtn" runat="server" Text="Update Selected Ticket->"  OnClick="UpdateBtn_Click" Visible="false"/>
   
    <br />
    <br />
    
    <br />
    <asp:Label ID="Label8" runat="server" Text="Notes Associated With Service"></asp:Label>
    <br />
    <asp:GridView ID="NoteGV" runat="server" Visible="false"></asp:GridView>
    <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
    <br />

    <br />
    <asp:Label ID="Label1" runat="server" Text="Employee Workflow History: " Visible="false"></asp:Label>
    <br />
    <asp:GridView ID="HistoryGV" runat="server" Visible="false"> </asp:GridView> 
    <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Ticket Equipment History: " Visible="false"></asp:Label>
    <br />
    <asp:GridView ID="EquipmentGV" runat="server" Visible="false"> </asp:GridView> 
    <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
    <br />
    <br />
    <br />
    <asp:Button ID="MainMenuBtn" runat="server" Text="Main Menu"  OnClick="MainMenuBtn_Click"/>
    <br />


</asp:Content>
