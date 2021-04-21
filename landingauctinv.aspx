<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeBehind="landingauctinv.aspx.cs" Inherits="Lab3.landingauctinv" MaintainScrollPositionOnPostback="true" %>

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
                    <a class="nav-link active" href="landingauctinv.aspx">Auction/Inventory</a>
                    <a class="nav-link" href="landingequip.aspx">Equipment</a>
                    <a class="nav-link" href="loggedInMainPage.aspx" tabindex="-1" aria-disabled="true">Employee</a>
                </nav>
            </div>
            <!-- end col nav -->

            <div class="col-sm-4 d-none d-xl-block" style="margin-top: -1.5rem;">
                <h3 style="margin-top: 2rem; margin-bottom: 2rem;">Pending Customers</h3>
            </div>
        </div>

        <div class="row">
            <div class="col-xl-8" style="margin-top: 2rem;">
                <a href="lognewcustomer.aspx">
                    <img src="images/GreenValleyButton.png" width="350"></a>

                <div class="menubox shadow p-3 mb-5 bg-white rounded">
                    <div class="row">
                        <div class="col-11">
                            <h3>Create New Auction</h3>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="exampleInputEmail1">Auction Name</label>
                                         <asp:TextBox ID="auctionName" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="exampleInputEmail1">Auction Date</label>
                                         <asp:TextBox ID="auctionDate" runat="server" CssClass="form-control"></asp:TextBox>
                                        
                                    </div>
                                </div>
                            </div>
                            <div class="row no-gutters">
                                <div class="col-6">
                                    <div class="form-group">
                                        <label for="exampleInputEmail1">Auction Location</label>
                                        <asp:TextBox ID="auctionLocation" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-2 offset-md-4" style="margin-top: 3rem;">
                                    <asp:Button runat="server" ID="submit" CssClass="btn btn-primary btn-md" Text="Submit" OnClick ="Submit_Click"/>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="menubox shadow p-3 mb-5 bg-white rounded">
                    <div class="row" style="margin-top: 1rem;">
                        <div class="col-4">
                            <h3>Auction Information</h3>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xl-8">
                            <div class="input-group">
                                <asp:DropDownList ID="AuctionName1" runat="server" AutoPostBack="true" CssClass="custom-select"></asp:DropDownList>
                                <div class="input-group-append">
                                    <asp:Button ID="showInfo" CssClass="btn btn-outline-secondary" runat="server" Text="Show Information" Onclick ="btnLoadEmployeeData_Click"/>
                                </div>
                            </div>
                        </div>
                        <div class="col-4">
                            <asp:Button runat="server" Text="Show All Information" CssClass="btn btn-secondary btn-md" OnClick ="BtnShowAll_Click"/>
                        </div>
                        <!-- service request -->
                    </div>

                    <div class="row">
                        <div class="col">
                            <div class="form-group" style="margin-top: 2rem;">
                                <asp:ListBox runat="server" ID="DropDownList1" CssClass="form-control"></asp:ListBox>
                            </div>
                        </div>
                    </div>

                </div>

                <div class="menubox shadow p-3 mb-5 bg-white rounded">
                    <div class="row" style="margin-top: 1rem;">
                        <div class="col-lg-6">
                            <h3>Add Item to Service Inventory</h3>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-xl-5">
                            <div class="input-group mb-3">
                                <asp:DropDownList ID="Service" CssClass="custom-select" runat="server"></asp:DropDownList>

                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-11">
                            <div class="form-group">
                                <label for="exampleFormControlTextarea1">Item description</label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-11">
                            <div class="form-group">
                                 <asp:TextBox ID="needs" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <form>
                        <div class="row no-gutters">
                            <div class="col-md-5">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Item Cost</label>
                                     <asp:TextBox ID="cost" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-2 offset-md-5" style="margin-top: 2rem;">
                                <asp:Button runat="server" CssClass="btn btn-primary btn-md" Text="Submit" ID="Submit2" OnClick =" Submit2_Click" />
                            </div>
                        </div>
                    </form>
                </div>

                <div class="menubox shadow p-3 mb-5 bg-white rounded">
                    <div class="row" style="margin-top: 1rem;">
                        <div class="col-4">
                            <h3>Inventory Information</h3>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="input-group mb-3">
                                <asp:DropDownList runat="server" ID="invInfo" CssClass="custom-select"></asp:DropDownList>

                            </div>
                        </div>
                        <div class="col-4">
                            <asp:Button runat="server" CssClass="btn btn-secondary btn-md" Text="Show All" ID="showAll2" />
                        </div>
                        <!-- service request -->
                    </div>

                    <div class="row">
                        <div class="col-11">
                            <asp:Table class="table" runat="server" ID="table1">
                                <asp:TableHeaderRow ID="empName" runat="server" CssClass="thead-light" BackColor="#e9ecef">
                                    <asp:TableCell Text="Service Name" CssClass="column" ID="n"></asp:TableCell>
                                    <asp:TableCell CssClass="column" Text="Item Description" ID="a"></asp:TableCell>
                                    <asp:TableCell CssClass="column" Text="Item Cost" ID="p"></asp:TableCell>
                                    <asp:TableCell CssClass="column" Text="Inventory Date" ID="e"></asp:TableCell>
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
