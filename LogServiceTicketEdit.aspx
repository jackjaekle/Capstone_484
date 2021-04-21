<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeBehind="LogServiceTicketEdit.aspx.cs" Inherits="Lab2.LogServiceTicketEdit" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Noah  George, William Kilpatrick, Henry Requeno-Villeda  2/15/2021 -->


    <div class="container">
        <h2>Service Ticket Edit</h2>

        
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group input">
                        <label for="exampleInputEmail1">Service Name</label>
                        <label for="serviceName"></label>
                        <input type="Text" class="form-control" id="serviceName" runat="server" readonly="true">

                        <%-- <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">--%>
                    </div>
                </div>
                <div class="col-md-5">
                    <div class="form-group input">
                        <label for="exampleInputPassword1">Service Date</label>
                        <asp:TextBox ID="startDate" runat="server" OnTextChanged="startChanged" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="serviceReq" ControlToValidate="startDate" Text="(Required)" Display="Dynamic" runat="server" ValidationGroup="Submit" />
                        <asp:CompareValidator ID="serviceVali" ControlToValidate="startDate" Text="Needs to be a Date" Operator="DataTypeCheck" Type="Date" runat="server" ValidationGroup="Submit" />
                        <%-- <input type="password" class="form-control" id="exampleInputPassword1">--%>
                        <asp:Label ID="Label6" runat="server" Text="" ></asp:Label>
                         
                    
                         <asp:Label ID="warn1" runat="server" Text="" CssClass =></asp:Label>
                    </div>
                     
                         
                        
                </div>
            </div>
        
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group input">
                        <label for="exampleInputEmail1">Completion Date</label>
                        <asp:TextBox ID="completionDate" runat="server" OnTextChanged="endChanged" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="completionDate" Text="(Required)" Display="Dynamic" runat="server" ValidationGroup="Submit" />
                        <asp:CompareValidator ID="CompareValidator1" ControlToValidate="completionDate" Text="Needs to be a Date" Operator="DataTypeCheck" Type="Date" runat="server" ValidationGroup="Submit" />
                        <%-- <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">--%>
                   
                         <asp:Label ID="Label7" runat="server" Text="" ></asp:Label>
                      
                         <asp:Label ID="warn2" runat="server" Text=""></asp:Label>
                        </div>
                        
                </div>
                <div class="col-md-6">
                    <div class="form-group input">
                        <label for="exampleInputEmail1">ServiceCost</label>
                        <asp:TextBox ID="serviceCost" runat="server" CssClass ="form-control"></asp:TextBox>
        
        <asp:RequiredFieldValidator ID ="serviceCostReq" ControlToValidate ="serviceCost" Text ="(Service Cost Required)" Display ="Static" runat ="server" ValidationGroup='Submit'/>
                        <%-- <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">--%>
                    </div>
                </div>


                <div class="col-md-5">
                    <div class="form-group input">
                        <label for="exampleInputPassword1">Update Status</label>
                        <asp:DropDownList ID="updateStatus" runat="server" CssClass="form-control"></asp:DropDownList>
                        <%-- <input type="password" class="form-control" id="exampleInputPassword1">--%>
                    </div>
                </div>
            </div>
        
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group input">
                        <label for="exampleInputEmail1">Payment Status</label>
                        <asp:DropDownList ID="paymentStatus" runat="server" CssClass="form-control"></asp:DropDownList>
                        <%--<input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">--%>
                    </div>
                </div>
            </div>
       
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group input">
                        <label for="exampleInputEmail1">Origin</label>
                        <asp:TextBox ID="origin" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="originReq" ControlToValidate="origin" Text="(Origin Required)" Display="Static" runat="server" ValidationGroup='Submit' />
                        <%--<input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">--%>
                    </div>
                </div>
                <div class="col-md-5">
                    <div class="form-group input">
                        <label for="exampleInputPassword1">Destination</label>
                        <asp:TextBox ID="destination" runat="server" CssClass="form-control"></asp:TextBox>
                        <%--  Impliments Validators--%>
                        <asp:RequiredFieldValidator ID="destinationReq" ControlToValidate="destination" Text="(Destination Required)" Display="Static" runat="server" ValidationGroup='Submit' />
                        <%-- <input type="password" class="form-control" id="exampleInputPassword1">--%>
                    </div>
                </div>
            </div>
       

        <div class="row estimate">
            <div class="col-md-3">
               <asp:Label ID="Label4" runat="server" Text="Available Equipment" CssClass ="form-control"></asp:Label>
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

                <asp:Label ID="Label2" runat="server" Text="Equipment chosen for service" CssClass ="form-control"></asp:Label>
                <div class="form-group">
                    <asp:ListBox ID="equipList" runat="server" CssClass="form-control"></asp:ListBox>
                    <%--<textarea class="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>--%>
                </div>

            </div>
        </div>
        <div class="row estimate">
            <div class="col-md-3">
                 <asp:Label ID="Label5" runat="server" Text="Available employees" CssClass="form-control"></asp:Label>
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

                <asp:Label ID="Label3" runat="server" Text="Employees chosen for service" CssClass ="form-control"></asp:Label>
                <div class="form-group">
                    <asp:ListBox ID="empList" runat="server" CssClass="form-control"></asp:ListBox>
                    <%-- <textarea class="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>--%>
                </div>

            </div>
        </div>
        <div class="row no-gutters">
            <div class="col-md-4">
                <asp:Button ID="Return" runat="server" Text="Main Menu" OnClick="Return_Click" CssClass="btn btn-primary btn-md"/>
                <%-- <a href="landingcustserv.html" type="submit" class="btn btn-primary">&#60; Back to Main Menu</a>--%>
            </div>
            <div class="col-md-2 offset-md-6">
                <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" ValidationGroup="Submit" CssClass="btn btn-primary btn-md" />
                <asp:Button ID="Submit2" runat="server" Text="Submit" OnClick="Submit2_Click" ValidationGroup="Submit" CssClass="btn btn-primary btn-md" />
                <%--<button type="button" class="btn btn-primary btn-md">Submit</button>--%>
            </div>
            <div class="col-md-4">
                <asp:Label ID="noteStatus" runat="server" Text="" ></asp:Label>
                <asp:Button ID="yesButton" runat="server" Text="Yes" OnClick="yesButton_Click" CssClass="btn btn-primary btn-md" />
                <asp:Button ID="noButton" runat="server" Text="No" OnClick="noButton_Click" CssClass="btn btn-primary btn-md" />
                <asp:DropDownList ID="DDL" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDL_SelectedIndexChanged" Visible="false" Font-Bold="true">
                </asp:DropDownList>
                <br />
                <asp:Label ID="svcNm" runat="server" Text="" Visible ="false"></asp:Label>
            </div>
        </div>

    </div>
</asp:Content>
