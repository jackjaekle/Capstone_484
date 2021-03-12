<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeFile="LogServiceTicketEdit.aspx.cs" Inherits="Lab2.LogServiceTicketEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <title>Noah George William Kilpatrick</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!--Noah  George, William Kilpatrick, Henry Requeno-Villeda  2/15/2021 -->
     <div>
        </div>
        <div style="margin-left: 160px"><%--the page for people who are logged in--%>
          Service Ticket Edit
        </div>
&nbsp;<asp:Label ID="Label1" runat="server" Text="Service Name"></asp:Label>
&nbsp;&nbsp;
        <asp:DropDownList ID="DDL" runat="server" AutoPostBack="true" OnSelectedIndexChanged ="DDL_SelectedIndexChanged">
        </asp:DropDownList>
        
       
        <br />
      
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp; <br />
        <br />
        Service Name&nbsp;&nbsp;&nbsp; <asp:TextBox ID="serviceName" runat="server" Width="100px"></asp:TextBox>

&nbsp;<asp:RequiredFieldValidator ID ="serviceNameReq" ControlToValidate ="serviceName" Text ="(Service Name Required)" Display ="Dynamic" runat ="server" ValidationGroup='Submit'/>
        
        <br />
    Service Cost&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="serviceCost" runat="server" Width="100px"></asp:TextBox>
        
        <asp:RequiredFieldValidator ID ="serviceCostReq" ControlToValidate ="serviceCost" Text ="(Service Cost Required)" Display ="Static" runat ="server" ValidationGroup='Submit'/>
        <br />
    Completion Date<asp:TextBox ID="completionDate" runat="server" Width="100px"></asp:TextBox>
        <asp:RequiredFieldValidator ID ="completionDateReq" ControlToValidate ="completionDate" Text ="(Completion Date Required)" Display ="Static" runat ="server" ValidationGroup='Submit'/>
        <br />
    Update Status&nbsp;&nbsp;&nbsp; <asp:TextBox ID="updateStatus" runat="server" Width="100px"></asp:TextBox>
        <asp:RequiredFieldValidator ID ="updateStatusReq" ControlToValidate ="updateStatus" Text ="(Update Status Required)" Display ="Static" runat ="server" ValidationGroup='Submit'/>
        <br />
    Payment Status&nbsp; <asp:TextBox ID="paymentStatus" runat="server" Width="100px"></asp:TextBox>
        <asp:RequiredFieldValidator ID ="paymentStatusReq" ControlToValidate ="paymentStatus" Text ="(Payment Status Required)" Display ="Static" runat ="server" ValidationGroup='Submit'/>
        <br />
    Origin&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="origin" runat="server" Width="100px"></asp:TextBox>
        <asp:RequiredFieldValidator ID ="originReq" ControlToValidate ="origin" Text ="(Origin Required)" Display ="Static" runat ="server" ValidationGroup='Submit'/>
        <br />
    Destination&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="destination" runat="server" Width="100px"></asp:TextBox> <%--  Impliments Validators--%>
        <asp:RequiredFieldValidator ID ="destinationReq" ControlToValidate ="destination" Text ="(Destination Required)" Display ="Static" runat ="server" ValidationGroup='Submit'/>

        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
        <br />
        <br />


        <br />
        <asp:Button ID="Return" runat="server" Text="Main Menu" OnClick="Return_Click" /><%-- Creates all the required buttons  --%>  
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" ValidationGroup ="Submit"/>
        <asp:Label ID="noteStatus" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
</asp:Content>
