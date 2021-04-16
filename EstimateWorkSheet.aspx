<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeBehind="EstimateWorkSheet.aspx.cs" Inherits="Lab3.EstimateWorkSheet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 
                <asp:Label ID="CustLabel" runat="server" Text="Chosen Customer"></asp:Label>
           
                <asp:Label ID="ChosenCust" runat="server"></asp:Label>
       
                <br />
       
                <asp:Label ID="ServiceLabel" runat="server" Text="Choose Service Name"></asp:Label>
          
                <asp:DropDownList ID="ChosenService" runat="server" OnSelectedIndexChanged= "ChosenService_SelectedIndexChanged" AutoPostBack ="true"></asp:DropDownList> 
          
                <br />
          
                <asp:Label ID="MoveDateLabel" runat="server" Text="Move Start Date (mm/dd/yyyy)"></asp:Label>
           
                <asp:Label ID="startingDate" runat="server" ></asp:Label>
               
          
                <br />
          
                <asp:Label ID="Label1" runat="server" Text="Move End Date (mm/dd/yyyy)"></asp:Label>
            
                <asp:Label ID="endDate" runat="server" ></asp:Label>
                
            
                <br />
            
            <asp:Label ID="PricingOrigin" runat="server" Text="Where Price Originated"></asp:Label>
                <asp:DropDownList ID="PricingDDL" runat="server">
                    <asp:ListItem>MLS Listing</asp:ListItem>
                    <asp:ListItem>A Look At</asp:ListItem>
                    <asp:ListItem>A Phone</asp:ListItem>
                    <asp:ListItem>Email Conversation</asp:ListItem>
                </asp:DropDownList>
                
           
                <br />
                
           
                <asp:Label ID="numOfTrucks" runat="server" Text="Trucks available during timeframe"></asp:Label>
            
                <asp:DropDownList ID="truckDDL" runat="server">
                </asp:DropDownList>
            
                <asp:Button ID="truckAdd" runat="server" Text="Add Truck to Job" OnClick="truckAdd_Click" />
            
                <br />
                <asp:ListBox ID="truckList" runat="server" Height="99px" Width="211px"></asp:ListBox>
                Trucks chosen for job<br />
            
                <asp:Label ID="numOfWorkers" runat="server" Text="Employees available during timeframe"></asp:Label>
           
                <asp:DropDownList ID="empDDL" runat="server">
                </asp:DropDownList>
           
                <asp:Button ID="empAdd" runat="server" OnClick="empAdd_Click" Text="Add Employee to Job" />
           
                <br />
                <asp:ListBox ID="empList" runat="server" Height="102px" Width="216px"></asp:ListBox>
                Employees chosen for job<br />
           
                <asp:Label ID="PriceLabel" runat="server" Text="Estimate/Contract Price"></asp:Label>
           
                <asp:TextBox ID="PriceBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID ="RequiredFieldValidator3" ControlToValidate ="PriceBox" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup ="Submit"/>
            <asp:CompareValidator ID ="CompareValidator3" ControlToValidate ="PriceBox" Text ="Needs to be a number" Operator ="DataTypeCheck" Type ="Integer" runat ="server" ValidationGroup ="Submit"/>
          
                <br />
          
                <asp:Label ID="SuppliesLabel" runat="server" Text="Total Cost of Supplies"></asp:Label>
          
                <asp:TextBox ID="SuppliesBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID ="RequiredFieldValidator4" ControlToValidate ="SuppliesBox" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup ="Submit"/>
            <asp:CompareValidator ID ="CompareValidator4" ControlToValidate ="SuppliesBox" Text ="Needs to be a number" Operator ="DataTypeCheck" Type ="double" runat ="server" ValidationGroup ="Submit"/>
            
                <br />
            
                <asp:Label ID="EstLabel" runat="server" Text="Estimated Hours"></asp:Label>
            &nbsp;<asp:TextBox ID="EstBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID ="RequiredFieldValidator5" ControlToValidate ="EstBox" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup ="Submit"/>
            <asp:CompareValidator ID ="CompareValidator5" ControlToValidate ="EstBox" Text ="Needs to be a number" Operator ="DataTypeCheck" Type ="Double" runat ="server" ValidationGroup ="Submit"/>
           
                <br />
           
                <asp:Label ID="FinalLabel" runat="server" Text="Final Hours"></asp:Label>
           
                <asp:TextBox ID="FinalBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID ="RequiredFieldValidator6" ControlToValidate ="FinalBox" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup ="Submit"/>
            <asp:CompareValidator ID ="CompareValidator6" ControlToValidate ="FinalBox" Text ="Needs to be a number" Operator ="DataTypeCheck" Type ="Double" runat ="server" ValidationGroup ="Submit"/>
          
                <br />
          
                <asp:Label ID="MileageLabel" runat="server" Text="Total Mileage"></asp:Label>
           
                <asp:TextBox ID="MileageBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID ="RequiredFieldValidator7" ControlToValidate ="MileageBox" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup ="Submit"/>
            <asp:CompareValidator ID ="CompareValidator7" ControlToValidate ="MileageBox" Text ="Needs to be a number" Operator ="DataTypeCheck" Type ="Integer" runat ="server" ValidationGroup ="Submit"/>
          
                <br />
          
                <asp:Label ID="FuelLabel" runat="server" Text="Trucks' Fuel Capacity (gallons)"></asp:Label>
            
                <asp:TextBox ID="FuelBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID ="RequiredFieldValidator8" ControlToValidate ="FuelBox" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup ="Submit"/>
            <asp:CompareValidator ID ="CompareValidator8" ControlToValidate ="FuelBox" Text ="Needs to be est fuel in gallons" Operator ="DataTypeCheck" Type ="Integer" runat ="server" ValidationGroup ="Submit"/>
           
                <br />
           
                <asp:Label ID="InsuranceLabel" runat="server" Text="Insurance Company"></asp:Label>
           
                <asp:TextBox ID="InsuranceBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID ="RequiredFieldValidator9" ControlToValidate ="InsuranceBox" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup ="Submit"/>
          
        
                <br />
          
        
                <asp:Label ID="WorkerCostLabel" runat="server" Text="How much for each worker?"></asp:Label>
            
                <asp:TextBox ID="WorkerCostBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID ="RequiredFieldValidator10" ControlToValidate ="WorkerCostBox" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup ="Submit"/>
            <asp:CompareValidator ID ="CompareValidator10" ControlToValidate ="WorkerCostBox" Text ="Needs to be in dollars" Operator ="DataTypeCheck" Type ="Currency" runat ="server" ValidationGroup ="Submit"/>
            
                <br />
            
                <asp:Label ID="FoodLabel" runat="server" Text="Food Needed"></asp:Label>
            
                <asp:TextBox ID="FoodBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID ="RequiredFieldValidator11" ControlToValidate ="FoodBox" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup ="Submit"/>
           
            
                <br />
           
            
                <asp:Label ID="HotelLabel" runat="server" Text="Hotel Needed"></asp:Label>
            
                <asp:TextBox ID="HotelBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID ="RequiredFieldValidator12" ControlToValidate ="HotelBox" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup ="Submit"/>
           
           
                <br />
           
           
           <asp:Button ID="ReturnButton" runat="server" Text="Return to Customer Selection Screen" OnClick="ReturnButton_Click" />
        
                
                 <asp:Button ID="SaveService" runat="server" Text="Submit Updated Service" OnClick="SaveService_Click" ValidationGroup ="Submit" />
        
                <asp:Label ID="Updated" runat="server" Text="" ForeColor="Green"></asp:Label>
            
                
                 </asp:Content>
