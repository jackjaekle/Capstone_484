<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeBehind="temp.aspx.cs" Inherits="Lab3.temp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="container-fluid">
        <div class="row" style="margin-top: 2rem;">
            <div class="col-xl-2">
                <h2 style="margin-top: 0rem;">Main Menu</h2>
            </div>
            <!-- end col h2 -->

            <div class="col-xl-6">
                <nav class="nav nav-tabs">
                    <a class="nav-link active" href="landingcustserv.html">Customer/Service</a>
                    <a class="nav-link" href="landingauctinv.html">Auction/Inventory</a>
                    <a class="nav-link" href="landingequip.html">Equipment</a>
                    <a class="nav-link" href="landingemployee.html" tabindex="-1" aria-disabled="true">Employee</a>
                </nav>
            </div>
            <!-- end col nav -->

            <div class="col-sm-4 d-none d-xl-block" style="margin-top: -1.5rem;">
                <h3 style="margin-top: 2rem; margin-bottom: 2rem;">Pending Customers</h3>
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
</asp:Content>

