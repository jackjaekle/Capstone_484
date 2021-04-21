<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeBehind="landingequip.aspx.cs" Inherits="Lab3.landingequip" MaintainScrollPositionOnPostback="true"%>

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
                    <a class="nav-link active" href="landingequip.aspx">Equipment</a>
                    <a class="nav-link" href="LoggedinMainPage.aspx" tabindex="-1" aria-disabled="true">Employee</a>
                </nav>
            </div>
            <!-- end col nav -->

            <div class="col-sm-4 d-none d-xl-block" style="margin-top: -1.5rem;">
                <h3 style="margin-top: 2rem; margin-bottom: 2rem;">Pending Customers</h3>
            </div>
        </div>

        <div class="row">
            <div class="col-xl-8" style="margin-top: 2rem;">
                <a href="lognewcustomer.html">
                    <img src="images/GreenValleyButton.png" width="350"></a>

                <div class="menubox shadow p-3 mb-5 bg-white rounded">
                    <div class="row">
                        <div class="col-11">
                            <h3>New Equipment</h3>
                            <div class="row">
                                <div class="col-md-5">
                                    <div class="form-group">
                                        <label for="name">Name</label>
                                        <input type="text" class="form-control" id="equipName" runat="server" aria-describedby="equipment">
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="form-group">
                                        <label for="cost">Cost</label>
                                        <input type="text" class="form-control" id="equipCost" runat="server">
                                    </div>
                                </div>
                                <div class="col-2" style="margin-top: 2rem;">
                                    <asp:Button CssClass="btn btn-primary btn-md" OnClick="Submit_Click" Text="Submit" runat="server" />

                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="menubox shadow p-3 mb-5 bg-white rounded">
                    <div class="row" style="margin-top: 1rem;">
                        <div class="col-3">
                            <h3>Equipment Status</h3>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xl-8">
                            <div class="input-group">



                                <asp:DropDownList CssClass="custom-select" runat="server" ID="equipmentDDL" AutoPostBack="true"></asp:DropDownList>


                                <div class="input-group-append">
                                    <asp:Button CssClass="btn btn-outline-secondary" ID="showSelected" OnClick="showSelected_Click" Text="Show Information" runat="server" />

                                </div>
                            </div>
                        </div>
                        <div class="col-4">
                            <asp:Button runat="server" CssClass="btn btn-secondary btn-md" ID="showAll" OnClick="showAll_Click" Text="Show All Information" />

                        </div>
                        <!-- service request -->
                    </div>


                    <div class="row">
                        <div class="col-11">
                            <asp:Table class="table" runat="server" ID="table1">
                                <asp:TableHeaderRow ID="empName" runat="server" CssClass="thead-light" BackColor="#e9ecef">
                                    <asp:TableCell Text="Equipment Name" CssClass="column" ID="eN"></asp:TableCell>
                                    <asp:TableCell CssClass="column" Text="Equipment Cost" ID="eC"></asp:TableCell>
                                </asp:TableHeaderRow>
                            </asp:Table>
                        </div>
                        <!-- end col -->
                    </div>
                </div>

                <div class="menubox shadow p-3 mb-5 bg-white rounded">
                    <div class="row">
                        <div class="col-11">
                            <h3>Equipment Rental</h3>
                            <div class="row">
                                <div class="col-md-5">
                                    <div class="form-group">

                                        <label for="inputState">Equipment ID</label>
                                        <asp:DropDownList runat="server" ID="DDLEquipID" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="form-group">
                                        <label for="inputState">Service ID</label>
                                        <asp:DropDownList runat="server" ID="DDLServiceID" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="form-group">
                                        <label for="exampleInputPassword1">Rent Date</label>
                                        <input type="date" class="form-control" id="RentDate" runat="server">
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="form-group">
                                        <label for="exampleInputPassword1">Rented Condition</label>
                                        <input type="Text" class="form-control" id="RentedCondition" runat="server">
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="form-group">
                                        <label for="exampleInputPassword1">Return Date</label>
                                        <input type="Date" class="form-control" id="ReturnDate" runat="server">
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="form-group">
                                        <label for="exampleInputPassword1">Return Condition</label>
                                        <input type="Text" class="form-control" id="ReturnCondition" runat="server">
                                    </div>
                                </div>
                                <div class="col-2" style="margin-top: 2rem;">
                                    <asp:Button runat="server" Text="Submit" CssClass="btn btn-primary btn-md" ID="SubmitRental" OnClick="SubmitRental_Click"/>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="menubox shadow p-3 mb-5 bg-white rounded">
                    <div class="row" style="margin-top: 1rem;">
                        <div class="col-5">
                            <h3>Equipment Rental Information</h3>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xl-8">
                            <div class="input-group">
                                <asp:DropDownList runat="server" ID="DDL" CssClass="form-control"></asp:DropDownList>

                                <div class="input-group-append">
                                    <asp:Button runat="server" CssClass="btn btn-outline-secondary" Text="Show Equipment Information" ID="ShowInfo" OnClick="ShowInfo_Click" />

                                </div>
                            </div>
                        </div>
                        <div class="col-4">
                            <asp:Button runat="server" CssClass="btn btn-outline-secondary" Text="Show All Information" ID="ShowAllInfo" OnClick="ShowAllInfo_Click" />

                        </div>
                        <!-- service request -->
                    </div>



                    <%--  <div class="row">
                        <div class="col-11">
                            <table class="table">
                              <thead class="thead-light">
                                <tr>
                                  <th scope="col">#</th>
                                  <th scope="col">Equipment Name</th>
                                  <th scope="col">Rent Date</th>
                                  <th scope="col">Rent Condition</th>
                                  <th scope="col">Return Date</th>
                                  <th scope="col">Return Condition</th>
                                </tr>
                              </thead>
                              <tbody>
                                <tr>
                                  <th scope="row">1</th>
                                    <td>forklift1</td>
                                    <td>2/11/2021 12:00:00 AM</td>
                                    <td>good</td>
                                    <td>3/12/2021 12:00:00 AM</td>
                                    <td>good</td>
                                </tr>
                              </tbody>
                            </table>
                        </div> <!-- end col -->
                    </div>--%>
                    <!-- end row -->


                    <div class="row">
                        <div class="col-11">
                            <asp:Table class="table" runat="server" ID="table2">
                                <asp:TableHeaderRow ID="TableHeaderRow1" runat="server" CssClass="thead-light" BackColor="#e9ecef">
                                    <asp:TableCell Text="Equipment Name" CssClass="column" ID="equipN"></asp:TableCell>
                                    <asp:TableCell Text="Rent Date" CssClass="column" ID="rD"></asp:TableCell>
                                    <asp:TableCell Text="Rent Condition" CssClass="column" ID="rC"></asp:TableCell>
                                    <asp:TableCell Text="Return Date" CssClass="column" ID="rD2"></asp:TableCell>
                                    <asp:TableCell CssClass="column" Text="Return Condition" ID="rC2"></asp:TableCell>
                                </asp:TableHeaderRow>
                            </asp:Table>
                        </div>
                        <!-- end col -->
                    </div>





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
