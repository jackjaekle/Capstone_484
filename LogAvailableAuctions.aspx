<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeBehind="LogAvailableAuctions.aspx.cs" Inherits="Lab3.LogAvailableAuctions" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Assign Customer to Available Auction</h2>

        <div class="row estimate">
            <div class="col-md-3">
                <h5>Customer Name:</h5>
            </div>
        </div>
        <div class="col-md-9">
            <div class="formgroup">
                <label for = "custName"></Label>
                <input type="Text" class="form-control" id="custName" runat="server" readonly ="true">
            </div>
        </div>

        <div class="row estimate">
            <div class="col-md">
                <h5>Upcoming Auctions:</h5>
            </div>
            <div class="col-md-9">
                <asp:DropDownList ID="auctionDDL" AutoPostBack="true" runat="server" OnSelectedIndexChanged="auctionDDL_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                <%--<select id="inputState" class="form-control">
                            <option selected>Choose...</option>
                            <option></option>
                          </select>--%>
            </div>
        </div>
        <div class="row estimate">
            <div class="col-md">
                <h5>Auction Location:</h5>
            </div>
        </div>
        <div class="col-md-9">
            <div class="formgroup">
                <label for = "custName"></Label>
                <input type="Text" class="form-control" id="auctLocation" runat="server"  readonly ="true">
            </div>
        </div>
        <div class="row estimate">
            <div class="col-md">
                <h5>Auction Start:</h5>
            </div>
        </div>
        <div class="col-md-9">
            <div class="formgroup">
                <label for = "custName"></Label>
                <input type="Text" class="form-control" id="AuctionStart" runat="server"  readonly ="true">
            </div>
        </div>
        <div class="row estimate">
            <div class="col-md-3">
                <h5>Available Equipment:</h5>
            </div>
            <div class="col-md">
                <asp:DropDownList ID="equipAvail" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>

                <%--<select id="inputState" class="form-control">
                            <option selected>Choose...</option>
                            <option></option>
                          </select>--%>
            </div>
            <div class="col-lg-2">
                <asp:Button ID="equipButton" runat="server" Text="Add Equipment to Job" OnClick="equipButton_Click" CssClass="btn btn-primary btn-md" />
                <%-- <button type="button" class="btn btn-primary btn-md">Add Equipment to Job</button>--%>
            </div>
        </div>
        <div class="row estimate">
            <div class="col-lg-12">
                <form style="margin-top: -2rem; margin-bottom: 2rem;">
                    <p>Equipment chosen for service:</p>
                    <div class="form-group">
                        <asp:ListBox ID="equipList" runat="server" CssClass="form-control"></asp:ListBox>
                        <%--<textarea class="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>--%>
                    </div>
                </form>
            </div>
        </div>
        <div class="row estimate">
            <div class="col-md-3">
                <h5>Available Employees:</h5>
            </div>
            <div class="col-md">

                <asp:DropDownList ID="empAvail" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                <%-- <select id="inputState" class="form-control">
                    <option selected>Choose...</option>
                    <option></option>
                </select>--%>
            </div>
            <div class="col-lg-2">
                <asp:Button ID="empButton" runat="server" Text="Add Employee to Job" OnClick="empButton_Click" CssClass="btn btn-primary btn-md" />
                <%--<button type="button" class="btn btn-primary btn-md">Add Employee to Job</button>--%>
            </div>
        </div>
        <div class="row estimate">
            <div class="col-lg-12">
                <form style="margin-top: -2rem; margin-bottom: 2rem;">
                    <p>Employees chosen for service:</p>
                    <div class="form-group">
                        <asp:ListBox ID="empList" runat="server" CssClass="form-control"></asp:ListBox>
                        <%-- <textarea class="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>--%>
                    </div>
                </form>
            </div>
        </div>


        <div class="col-md-9">
            <div class="formgroup">
                <label for = "MissingText"></Label>
                <input type="Text" id="MissingText" runat="server"  Width="150" readonly ="true">
            </div>
        </div>
        <div class="row no-gutters">
            <div class="col-lg-4">
                <asp:Button ID="Return" runat="server" Text="Main Menu" OnClick="Return_Click" CssClass="btn btn-primary" />
                <%-- <a href="landingcustserv.html" type="submit" class="btn btn-primary">&#60; Back to Main Menu</a>--%>
            </div>
            <div class="col-lg-2 offset-lg-6">
                <asp:Button ID="servCust" runat="server" Text="Assign to Auction" OnClick="servCust_Click" ValidationGroup='Submit' CssClass="btn btn-primary btn-md" />
                <%-- <button type="button" class="btn btn-primary btn-md">Assign to Auction</button>--%>
            </div>
        </div>

    </div>

</asp:Content>
