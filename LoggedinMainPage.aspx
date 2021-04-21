<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeBehind="LoggedinMainPage.aspx.cs" Inherits="Lab1.LoggedinMainPage" MaintainScrollPositionOnPostback="true" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row" style="margin-top: 2rem;">
            <div class="col-xl-2">
                <h2 style="margin-top: 0rem;">Main Menu</h2>
            </div>
            <!-- end col h2 -->

            <div class="col-xl-6">
                <nav class="nav nav-tabs">
                    <a class="nav-link" href="landingcustserv.aspx">Customer/Service</a>
                    <a class="nav-link" href="landingauctinv.aspx">Auction/Inventory</a>
                    <a class="nav-link" href="landingequip.aspx">Equipment</a>
                    <a class="nav-link active" href="loggedinMainPage.aspx" tabindex="-1" aria-disabled="true">Employee</a>
                </nav>
            </div>
            <!-- end col nav -->

            <div class="col-sm-4 d-none d-xl-block" style="margin-top: -1.5rem;">
                <h3 style="margin-top: 2rem; margin-bottom: 2rem;">Pending Customers</h3>
            </div>
        </div>

        <div class="row">
            
            <div class="col-xl-8" style="margin-top: 2rem;">
                <a href="LogNewCustomer.aspx">
                    <img src="images/GreenValleyButton.png" width="350"></a>
                <div class="menubox shadow p-3 mb-5 bg-white rounded">
                    <div class="row">
                        <div class="col-11">
                            <h3>New Employee</h3>
                            <div class="row">
                                <div class="col-md-5">
                                    <div class="form-group">
                                        <label for="FirstName">First Name</label>
                                        <input type="Text" class="form-control" id="EmployeeFirstName" aria-describedby="fname" runat="server">
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="form-group">
                                        <label for="LastName">Last Name</label>
                                        <input type="Text" class="form-control" id="EmployeeLastName" runat="server">
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-5">
                                    <div class="form-group">
                                        <label for="Phone">Phone</label>
                                        <input type="Text" class="form-control" id="EmployeePhone" aria-describedby="phone" runat="server">
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="form-group">
                                        <label for="Address">Address</label>
                                        <input type="Text" class="form-control" id="EmployeeAddress" runat="server">
                                    </div>
                                </div>
                            </div>



                            <div class="row">
                                <div class="col-md-5">
                                    <div class="form-group">
                                        <label for="Employee Rank">Employee Title</label>
                                        <asp:DropDownList CssClass="custom-select" ID="rankDDL" runat="server">
                                            <asp:ListItem Text="Employee" Value="Employee" />
                                            <asp:ListItem Text="Driver" Value="Driver" />
                                            <asp:ListItem Text="Mover" Value="Mover" />
                                            <asp:ListItem Text="Admin" Value="Admin" />
                                        </asp:DropDownList>

                                    </div>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-md-5">
                                    <div class="form-group">
                                
                                         <label for="Address">Email</label>
                                        <input type="Text" class="form-control" id="EmployeeEmail" runat="server">

                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="form-group">
                                         <label for="Address">Password</label>
                                        <input type="Text" class="form-control" id="Password" runat="server">
                                    </div>
                                </div>
                                <div class="col-2" style="margin-top: 2rem;">

                                    <asp:Button ID="employeeTemp" OnClick="Submit_Click" class="btn btn-primary btn-md" runat="server" Text="Submit"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="menubox shadow p-3 mb-5 bg-white rounded">
                    <div class="row" style="margin-top: 1rem;">
                        <div class="col-4">
                            <h3>Employee Information</h3>
                        </div>
                    </div>




                    <div class="row">
                        <div class="col-xl-8">
                            <div class="input-group">
                                <asp:DropDownList CssClass="custom-select" ID="DDL" runat="server">
                                </asp:DropDownList>
                                <div class="input-group-append">
                                    <asp:Button class="btn btn-outline-secondary" type="button" Text="Show Employee Information" OnClick="btnLoadEmployeeData_Click" runat="server"></asp:Button>
                                </div>
                            </div>
                        </div>
                        <div class="col-4">
                            <asp:Button class="btn btn-secondary btn-md" runat="server" OnClick="Show_All_Information" Text="Show All Information"></asp:Button>
                        </div>
                        <!-- service request -->
                    </div>




                    <div class="row">
                        <div class="col-11">
                            <asp:Table class="table" runat="server" ID="table1">
                                <asp:TableHeaderRow ID="empName" runat="server" CssClass="thead-light" BackColor="#e9ecef">
                                    <asp:TableCell Text="Employee Name" CssClass="column" ID="n"></asp:TableCell>
                                    <asp:TableCell CssClass="column" Text="Employee Address" ID="a"></asp:TableCell>
                                    <asp:TableCell CssClass="column" Text="Employee Phone" ID="p"></asp:TableCell>
                                    <asp:TableCell CssClass="column" Text="Employee Email" ID="e"></asp:TableCell>
                                </asp:TableHeaderRow>
                            </asp:Table>
                        </div>
                        <!-- end col -->
                    </div>


                    <!-- end row -->
                </div>

            </div>

            <div class="col-sm-4 d-xl-none" style="margin-top: -1.5rem;">
                <h3 style="margin-top: 2rem; margin-bottom: 2rem;">Pending Customers</h3>
            </div>
            <div class="col-xl-4" style="margin-top: -2rem;">
                <div class="pending2">
                    <h4>Customers Waiting on Service</h4>
                    <!-- service request -->



                    <div class="btn-group btn-group-toggle" data-toggle="buttons">
                        <label class="btn btn-secondary active">
                            <asp:RadioButton ID="MovingRadio" runat="server" AutoPostBack="True" Checked="True" OnCheckedChanged="MovingRadio_CheckedChanged" Text="Moving Service" />
                        </label>
                        <label class="btn btn-secondary active">
                            <asp:RadioButton ID="AuctionRadio" runat="server" AutoPostBack="True" OnCheckedChanged="AuctionRadio_CheckedChanged" Text="Auction Service" />
                        </label>
                    </div>











                    <div class="form-group">
                        <asp:ListBox runat="server" ID="custList" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="custList_SelectedIndexChanged"></asp:ListBox>
                    </div>



                    <div class="input-group mb-3" style="width: 30rem;">
                        <asp:TextBox Text="Customer Name" ReadOnly="true" ID="UserInput" runat="server" CssClass="form-control" />
                        <div class="input-group-append">


                            <asp:Button CssClass="btn btn-outline-secondary" Text="submit" ID="help" OnClick="servCust_Click" ValidationGroup='Submit' runat="server" />
                        </div>
                    </div>



                    <!-- service request -->
                </div>




                <div class="pending">

                    <h4>Customers Waiting On Moving Price</h4>
                    <div class="form-group">

                        <asp:ListBox ID="CustomerInfo" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CustomerInfo_SelectedIndexChanged"></asp:ListBox>

                    </div>
                    <div class="input-group mb-3" style="width: 30rem;">
                        <div class="input-group-append">


                            <asp:Button CssClass="btn btn-outline-secondary" Text="Move to Estimate Sheet" ID="Button1" OnClick="Button1_Click" ValidationGroup='Submit' runat="server" />
                        </div>
                    </div>
                </div>

                <div class="pending">

                    <h4>Inventories Waiting to be Sent to Auction</h4>
                    <div class="form-group">

                        <asp:ListBox ID="custInvList" AutoPostBack="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="custInvList_SelectedIndexChanged"></asp:ListBox>

                    </div>

                    <div class="input-group-append">

                        <asp:TextBox Text="Customer Name" ReadOnly="true" ID="Textbox1" runat="server" CssClass="form-control" />
                        <asp:Button runat="server" CssClass="btn btn-secondary btn-md" Text="Submit" OnClick="Auction_Click" />
                    </div>
                </div>



            </div>
        </div>
    </div>
</asp:Content>
