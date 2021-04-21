<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeBehind="EstimateWorkSheet.aspx.cs" Inherits="Lab3.EstimateWorkSheet" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <h2>Move Estimate Sheet</h2>

        <div class="row estimate">
            <div class="col-md-3">
                <h5>Chosen Customer:</h5>
            </div>
        </div>
        <div class="row estimate">
            <div class="col-md">
                <h5>Move Start Date:</h5>
            </div>
            <label for="ChosenCust"></label>
            <div class="col-md-9">
                <input type="Text" class="form-control" id="ChosenCust" runat="server" readonly="true" CssClass ="form-control">
            </div>
       
        </div>
        <div class="row estimate">
            <div class="col-md">
                <h5>Choose Service Name:</h5>
            </div>
            <div class="col-md-9">
                <asp:DropDownList ID="ChosenService" runat="server" OnSelectedIndexChanged="ChosenService_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>

                <%-- <select id="inputState" class="form-control">
                            <option selected>Choose...</option>
                            <option></option>--%>
                          </select>
            </div>
        </div>
        <div class="row estimate">
            <div class="col-md">
                <h5>Move Start Date:</h5>
            </div>
            <label for="StartingDate"></label>
            <div class="col-md-9">
                <input type="Text" class="form-control" id="startingDate" runat="server" readonly="true" CssClass ="form-control">
            </div>
       
        </div>
        
        <div class="row estimate">
            <div class="col-md">
                <h5>Move End Date:</h5>
            </div>
            <label for="Enddate"></label>
            <div class="col-md-9">
                <input type="Text" class="form-control" id="endDate" runat="server" readonly="true" CssClass ="form-control">
            </div>
       
        </div>
        <div class="row estimate">
            <div class="col-md">
                <h5>Where Price Originated:</h5>
            </div>
            <div class="col-md-9">
                <asp:DropDownList ID="PricingDDL" runat="server" OnSelectedIndexChanged="ChosenService_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">
                    <asp:ListItem>MLS Listing</asp:ListItem>
                    <asp:ListItem>A Look At</asp:ListItem>
                    <asp:ListItem>A Phone</asp:ListItem>
                    <asp:ListItem>Email Conversation</asp:ListItem>
                </asp:DropDownList>

            </div>
        </div>
        <div class="row estimate">
            <div class="col-md-3">
                <h5>Available Equipment:</h5>
            </div>
            <div class="col-md">
                <asp:DropDownList ID="truckDDL" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>

                <%--<select id="inputState" class="form-control">
                            <option selected>Choose...</option>
                            <option></option>
                          </select>--%>
            </div>
            <div class="col-lg-2">
                <asp:Button ID="equipButton" runat="server" Text="Add Equipment to Job" OnClick="truckAdd_Click" CssClass="btn btn-primary btn-md" />
                <%-- <button type="button" class="btn btn-primary btn-md">Add Equipment to Job</button>--%>
            </div>
        </div>
        <div class="row estimate">
            <div class="col-lg-12">
                
                    <p>Equipment chosen for service:</p>
                    <div class="form-group">
                        <asp:ListBox ID="truckList" runat="server" CssClass="form-control"></asp:ListBox>
                        <%--<textarea class="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>--%>
                    </div>
                
            </div>
        </div>
        <div class="row estimate">
            <div class="col-md-3">
                <h5>Available Employees:</h5>
            </div>
            <div class="col-md">

                <asp:DropDownList ID="empDDL" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                <%-- <select id="inputState" class="form-control">
                    <option selected>Choose...</option>
                    <option></option>
                </select>--%>
            </div>
            <div class="col-lg-2">
                <asp:Button ID="empButton" runat="server" Text="Add Employee to Job" OnClick="empAdd_Click" CssClass="btn btn-primary btn-md" />
                <%--<button type="button" class="btn btn-primary btn-md">Add Employee to Job</button>--%>
            </div>
        </div>
        <div class="row estimate">
            <div class="col-lg-12">
               
                    <p>Employees chosen for service:</p>
                    <div class="form-group">
                        <asp:ListBox ID="empList" runat="server" CssClass="form-control"></asp:ListBox>
                        <%-- <textarea class="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>--%>
                    </div>
              
            </div>
        </div>
        
            <div class="row estimate">
                <div class="col-lg-6">
                    <div class="form-group input">
                        <label for="exampleInputEmail1">Estimate/Contract Price</label>
                        <asp:TextBox ID="PriceBox" runat="server" CssClass="form-control"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="PriceBox" Text="(Required)" Display="Dynamic" runat="server" ValidationGroup="Submit" />
                        <asp:CompareValidator ID="CompareValidator3" ControlToValidate="PriceBox" Text="Needs to be a number" Operator="DataTypeCheck" Type="Integer" runat="server" ValidationGroup="Submit" />--%>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="form-group input">
                        <label for="exampleInputPassword1">Total Cost of Supplies</label>
                        <asp:TextBox ID="SuppliesBox" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="SuppliesBox" Text="(Required)" Display="Dynamic" runat="server" ValidationGroup="Submit" />
                        <asp:CompareValidator ID="CompareValidator4" ControlToValidate="SuppliesBox" Text="Needs to be a number" Operator="DataTypeCheck" Type="double" runat="server" ValidationGroup="Submit" />
                    </div>
                </div>
            </div>
       
       
            <div class="row estimate">
                <div class="col-lg-6">
                    <div class="form-group input">
                        <label for="exampleInputEmail1">Estimated Hours</label>
                        <asp:TextBox ID="EstBox" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="EstBox" Text="(Required)" Display="Dynamic" runat="server" ValidationGroup="Submit" />
                        <asp:CompareValidator ID="CompareValidator5" ControlToValidate="EstBox" Text="Needs to be a number" Operator="DataTypeCheck" Type="Double" runat="server" ValidationGroup="Submit" />
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="form-group input">
                        <label for="exampleInputPassword1">Final Hours</label>
                        <asp:TextBox ID="FinalBox" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="FinalBox" Text="(Required)" Display="Dynamic" runat="server" ValidationGroup="Submit" />
                        <asp:CompareValidator ID="CompareValidator6" ControlToValidate="FinalBox" Text="Needs to be a number" Operator="DataTypeCheck" Type="Double" runat="server" ValidationGroup="Submit" />
                    </div>
                </div>
            </div>
       
            <div class="row estimate">
                <div class="col-lg-6">
                    <div class="form-group input">
                        <label for="exampleInputEmail1">Total Mileage</label>
                        <asp:TextBox ID="MileageBox" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="MileageBox" Text="(Required)" Display="Dynamic" runat="server" ValidationGroup="Submit" />
                        <asp:CompareValidator ID="CompareValidator7" ControlToValidate="MileageBox" Text="Needs to be a number" Operator="DataTypeCheck" Type="Integer" runat="server" ValidationGroup="Submit" />
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="form-group input">
                        <label for="exampleInputEmail1">Trucks' Fuel Capacity &#40;gallons&#41;</label>
                        <asp:TextBox ID="FuelBox" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="FuelBox" Text="(Required)" Display="Dynamic" runat="server" ValidationGroup="Submit" />
                        <asp:CompareValidator ID="CompareValidator8" ControlToValidate="FuelBox" Text="Needs to be est fuel in gallons" Operator="DataTypeCheck" Type="Integer" runat="server" ValidationGroup="Submit" />
                    </div>
                </div>
            </div>
        
            <div class="row estimate">
                <div class="col-lg-6">
                    <div class="form-group input">
                        <label for="exampleInputEmail1">Insurance Company</label>
                        <asp:TextBox ID="InsuranceBox" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="InsuranceBox" Text="(Required)" Display="Dynamic" runat="server" ValidationGroup="Submit" />
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="form-group input">
                        <label for="exampleInputPassword1">How much for each worker?</label>
                        <asp:TextBox ID="WorkerCostBox" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="WorkerCostBox" Text="(Required)" Display="Dynamic" runat="server" ValidationGroup="Submit" />
                        <asp:CompareValidator ID="CompareValidator10" ControlToValidate="WorkerCostBox" Text="Needs to be in dollars" Operator="DataTypeCheck" Type="Currency" runat="server" ValidationGroup="Submit" />
                    </div>
                </div>
            </div>
       
            <div class="row estimate">
                <div class="col-lg-6">
                    <div class="form-group input">
                        <label for="exampleInputEmail1">Food Needed</label>
                        <asp:TextBox ID="FoodBox" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="FoodBox" Text="(Required)" Display="Dynamic" runat="server" ValidationGroup="Submit" />
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="form-group input">
                        <label for="exampleInputPassword1">Hotel Needed</label>
                        <asp:TextBox ID="HotelBox" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="HotelBox" Text="(Required)" Display="Dynamic" runat="server" ValidationGroup="Submit" />
                    </div>
                </div>
            </div>
       

        <div class="row no-gutters">
            <div class="col-lg-4">
                <asp:Button ID="ReturnButton" runat="server" Text="Back to Main Menu" OnClick="ReturnButton_Click" CssClass="btn btn-primary" />
                <%--  <a href="landingcustserv.html" type="submit" class="btn btn-primary">&#60; Back to Main Menu</a>--%>
            </div>
            <div class="col-lg-2 offset-lg-6">
                <asp:Button ID="SaveService" runat="server" Text="Submit Updated Service" OnClick="SaveService_Click" ValidationGroup="Submit" CssClass="btn btn-primary" />
            </div>
        </div>
        <div class="row estimate">
            <div class="col-md-3">
                <asp:Label ID="Updated" runat="server" Text="" ForeColor="Green" CssClass="form-control"></asp:Label>

            </div>
        </div>
    </div>
</asp:Content>
