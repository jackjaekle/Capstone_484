<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeBehind="LogCustServCreation.aspx.cs" Inherits="Lab3.LogCustServCreation" MaintainScrollPositionOnPostback="true"%>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Noah  George, William Kilpatrick, Henry Requeno-Villeda 2/15/2021 -->
    <div class="container">
        <h2>Customer Auction Request</h2>

        <div class="row">
            <div class="col-lg-12">
                <form style="margin-top: -2rem;">
                    <p>Customer Moving Request</p>
                    <div class="form-group">
                        <asp:ListBox ID="custRequest" runat="server" CssClass="form-control"></asp:ListBox>
                        <%-- <textarea class="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>--%>
                    </div>
                </form>
            </div>
        </div>
        <div class="row movereq">
            <div class="col-md-3">
                <p>Customer Name:</p>
            </div>


            <div class="col-md-9">
                <asp:Label ID="custNameLabel" runat="server" Text="" CssClass="form-control" readonly="true"></asp:Label>
            </div>
        </div>

        <div class="row movereq">
            <div class="col-md-3">
                <p>Customer Phone:</p>
            </div>


            <div class="col-md-9">
                <asp:Label ID="custPhone" runat="server" Text="" CssClass="form-control" readonly="true"></asp:Label>
            </div>
        </div>
        <div class="row movereq">
            <div class="col-md-3">
                <p>Origin Address:</p>
            </div>


            <div class="col-md-9">
                <asp:Label ID="originLabel" runat="server" Text="" CssClass="form-control" readonly="true"></asp:Label>
            </div>
        </div>
        <div class="row movereq">
            <div class="col-md-3">
                <p>Destination Address:</p>
            </div>
            <div class="col-md-9">
                <div class="form-group input">
                    <asp:TextBox ID="SecondChanged" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="secondChangedValiReq" ControlToValidate="SecondChanged" Text="(Required)" Display="Dynamic" runat="server" ValidationGroup="Submit" />
                    <asp:CompareValidator ID="secondChangedVali" ControlToValidate="SecondChanged" Text="Needs to be a String" Operator="DataTypeCheck" Type="String" runat="server" ValidationGroup="Submit" />
                </div>
            </div>
        </div>
        <div class="row movereq">
            <div class="col-md-3">
                <p>Service Cost:</p>
            </div>
            <div class="col-md-9">
                <div class="form-group input">
                    <asp:TextBox ID="ServiceCost" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="completionDateReq" ControlToValidate="CompletionDate" Text="(Required)" Display="Dynamic" runat="server" ValidationGroup="Submit" />
                    <asp:CompareValidator ID="completionDateVali" ControlToValidate="CompletionDate" Text="Needs to be a Valid Date (mm/dd/yyyy)" Operator="DataTypeCheck" Type="Date" runat="server" ValidationGroup="Submit" />
                </div>
            </div>
        </div>
        <div class="row movereq">
            <div class="col-md-3">
                <p>Start Date:</p>
            </div>
            <div class="col-md-9">
                <div class="form-group input">
                    <asp:TextBox ID="startingDate" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="startingDate" Text="(Required)" Display="Dynamic" runat="server" ValidationGroup="Submit" />
                    <asp:CompareValidator ID="CompareValidator1" ControlToValidate="startingDate" Text="Needs to be a Valid Date (mm/dd/yyyy)" Operator="DataTypeCheck" Type="Date" runat="server" ValidationGroup="Submit" />
                </div>
            </div>
        </div>
        <div class="row movereq">
            <div class="col-md-3">
                <p>Completion Date:</p>
            </div>
            <div class="col-md-9">
                <div class="form-group input">
                    <asp:TextBox ID="CompletionDate" runat="server" CssClass="form-control"></asp:TextBox>
                    <%--  Impliments Validators--%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="CompletionDate" Text="(Required)" Display="Dynamic" runat="server" ValidationGroup="Submit" />
                    <asp:CompareValidator ID="CompareValidator2" ControlToValidate="CompletionDate" Text="Needs to be a Valid Date (mm/dd/yyyy)" Operator="DataTypeCheck" Type="Date" runat="server" ValidationGroup="Submit" />
                </div>
            </div>
        </div>
        <div class="row movereq">
            <div class="col-md-3">
                <p>Service Name:</p>
            </div>
            <div class="col-md-9">
                <div class="form-group input">
                    <asp:TextBox ID="ServiceName" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="serviceReq" ControlToValidate="ServiceName" Text="(Required)" Display="Dynamic" runat="server" ValidationGroup="Submit" />
                    <asp:CompareValidator ID="serviceVali" ControlToValidate="ServiceName" Text="Needs to be a String" Operator="DataTypeCheck" Type="String" runat="server" ValidationGroup="Submit" />
                </div>
            </div>
        </div>

        <div class="row no-gutters">
            <div class="col-lg-4">
                <asp:Button ID="Return" runat="server" Text="Main Menu" OnClick="Return_Click" CssClass="btn btn-primary" />
                <%-- <a href="landingcustserv.html" type="submit" class="btn btn-primary">&#60; Back to Main Menu</a>--%>
            </div>
            <div class="col-lg-2 offset-lg-6">
                <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" ValidationGroup="Submit" CssClass="btn btn-primary btn-md" />
                
                <%--                <button type="button" class="btn btn-primary btn-md">Submit</button>--%>
            </div>
        </div>
        <div class="row movereq">
            <div class="col-md-3">
                <asp:Label ID="TestLabel" runat="server" Text="" CssClass="form-control" readonly="true"></asp:Label>
                <asp:Label ID="MissingInput" runat="server" Text="" CssClass="form-control" readonly="true"></asp:Label>
            </div>
            </div>

    </div>

</asp:Content>
