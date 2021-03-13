<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeFile="LoggedinMainPage.aspx.cs" Inherits="Lab1.LoggedinMainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Noah  George, William Kilpatrick, Henry Requeno-Villeda  2/15/2021 -->
        <div>
                Main Menu<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Information&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Create New&nbsp; Record&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Edit / Update Records&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Customer Requests<br />
                <br />
            <%-- Creates all the required buttons  --%><%--the page for people who are logged in--%>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="CustomerInfo" runat="server" Text="Customer Info" OnClick="CustomerInfo_Click" Width="130px" />
                <asp:Button ID="newAuction" runat="server" Text="New Auction Event" OnClick="newAuction_Click" Width="194px"/>
            <asp:Button ID="noteMgmt" runat="server" Text="Note Management" OnClick="noteMgmt_Click" Width="160px"/>
                <asp:Button ID="servReq" runat="server" Text="Customer Service Requests" OnClick="servReq_Click" Width="312px" />
                <asp:Label ID="customersWait" runat="server" Text=""></asp:Label>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="EmployeeInfo" runat="server" Text="Employee Info" OnClick="EmployeeInfo_Click" Width="130px" />
            
            <asp:Button ID="NewEmployee" runat="server" Text="New Employee" OnClick="NewEmployee_Click" Width="194px" Height="26px" />

            <asp:Button ID="serviceEdit" runat="server" Text="Service Ticket Edit" OnClick="serviceEdit_Click" Width="160px" />

                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="InventoryInfo" runat="server" Text="Inventory info" OnClick="InventoryInfo_Click" Width="130px" />
            <asp:Button ID="NewItem" runat="server" Text="Add Item to Service Inventory" OnClick="NewItem_Click" Width="194px" />
            <asp:Button ID="equipMana" runat="server" Text="Equipment Management" Width="160px" OnClick="equipMana_Click" />
            
                <asp:Button ID="invAuction" runat="server" Text="Customer Inventories Waiting to be sent to Auction" OnClick="invAuction_Click" Width="312px"/>
                <asp:Label ID="auctionWait" runat="server" Text=""></asp:Label>
                <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="moveFormBtn" runat="server" Text="MoveForm Info" OnClick="moveFormBtn_Click" Width="130px"/>

            <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="ServiceInfo" runat="server" Text="Service Info" Width="130px" OnClick="ServiceInfo_Click" />

                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="WorkFlowInfo" runat="server" Text="WorkFlow Info / History" OnClick="WorkFlowInfo_Click" Width="160px" />
            <br />
            
            <br />

            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <br />
            
        </div>

</asp:Content>
