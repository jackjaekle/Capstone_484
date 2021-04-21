<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeBehind="LogNewCustomer.aspx.cs" Inherits="Lab2.LogNewCustomer" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!--Noah  George, William Kilpatrick, Henry Requeno-Villeda  2/15/2021 -->

        <div class="container">
            <h2>New Customer</h2>
            
            <h4>Information</h4>
                
                    <div class="row">
                        <div class="col-md-6">
                          <div class="form-group">
                            <label for="exampleInputEmail1">First Name</label>
                              <asp:TextBox ID="CustomerFirstName" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID ="customerFirstRequire" ControlToValidate ="CustomerFirstName" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup='Submit'/>
            <asp:CompareValidator ID ="customerFirstVali" ControlToValidate ="CustomerFirstName" Text ="Needs to be a String" Operator ="DataTypeCheck" Type ="String" runat ="server" ValidationGroup='Submit'/>
                            <%--<input type="email" CssClass="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">--%>
                          </div>
                        </div>
                        <div class="col-md-6">
                          <div class="form-group">
                            <label for="exampleInputPassword1">Address</label>
                              <asp:TextBox ID="CustomerAddress" runat="server" CssClass="form-control"></asp:TextBox> <%--  Impliments Validators--%>
            <asp:RequiredFieldValidator ID ="RequiredFieldValidator1" ControlToValidate ="CustomerAddress" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup='Submit'/>
                            <%--<input type="password" class="form-control" id="exampleInputPassword1">--%>
                          </div>
                        </div>
                    </div>
                
                    <div class="row">
                        <div class="col-md-6">
                          <div class="form-group">
                            <label for="exampleInputEmail1">Last Name</label>
                               <asp:TextBox ID="CustomerLastName" runat="server" CssClass="form-control"></asp:TextBox>          <%--  Impliments Validators--%>     
            <asp:RequiredFieldValidator ID ="customerLastReq" ControlToValidate ="CustomerLastName" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup='Submit'/>
            <asp:CompareValidator ID ="customerLastVali" ControlToValidate ="CustomerLastName" Text ="Needs to be a String" Operator ="DataTypeCheck" Type ="String" runat ="server" ValidationGroup='Submit'/>
                            <%--<input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">--%>
                          </div>
                        </div>
                        <div class="col-md-6">
                          <div class="form-group">
                            <label for="exampleInputPassword1">Request/Needs</label>
                               <asp:TextBox ID="custNeeds" runat="server"  CssClass="form-control"></asp:TextBox> <%--  Impliments Validators--%>
            <asp:RequiredFieldValidator ID ="RequiredFieldValidator2" ControlToValidate ="custNeeds" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup='Submit'/>
                            <%--<input type="password" class="form-control" id="exampleInputPassword1">--%>
                          </div>
                        </div>
                    </div>
               
                    <div class="row">
                        <div class="col-md-4">
                          <div class="form-group">
                            <label for="exampleInputEmail1">Phone</label>
                              <asp:TextBox ID="CustomerPhone" runat="server" CssClass="form-control"></asp:TextBox> <%--  Impliments Validators--%>
             <asp:RequiredFieldValidator ID ="custPhoneReq" ControlToValidate ="CustomerPhone" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup='Submit'/>
            <asp:CompareValidator ID ="custPhoneVali" ControlToValidate ="CustomerPhone" Text ="Needs to be an Integer" Operator ="DataTypeCheck" Type ="Integer" runat ="server" ValidationGroup='Submit'/>
                            <%--<input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">--%>
                          </div>
                        </div>
                        <div class="form-group col-md-2">
                          <label for="inputState">Phone Type</label>
                            <asp:DropDownList ID="DDL3" AutoPostBack = "true" runat ="server" ></asp:DropDownList>
                          <%--<select id="inputState" class="form-control">
                            <option selected>Choose...</option>
                            <option></option>
                          </select>--%>
                        </div>
                        <div class="col-md-6">
                          <div class="form-group">
                            <label for="exampleInputEmail1">How Did They Hear?</label>
                              <asp:TextBox ID="customerHear" runat="server" CssClass="form-control"></asp:TextBox> <%--  Impliments Validators--%>
            <asp:RequiredFieldValidator ID ="customerHearReq" ControlToValidate ="customerHear" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup='Submit'/>
            <asp:CompareValidator ID ="customerHearVali" ControlToValidate ="customerHear" Text ="Needs to be a String" Operator ="DataTypeCheck" Type ="String" runat ="server" ValidationGroup='Submit'/>
                            <%--<input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">--%>
                          </div>
                        </div>
                    </div>
                
                    <div class="row">
                        <div class="col-md-6">
                          <div class="form-group">
                            <label for="exampleInputEmail1">Email</label>
                               <asp:TextBox ID="CustomerEmail" runat="server" CssClass="form-control"></asp:TextBox> <%--  Impliments Validators--%>
            <asp:RequiredFieldValidator ID ="custEmailReq" ControlToValidate ="CustomerEmail" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup='Submit'/>
            <asp:CompareValidator ID ="custEmailvali" ControlToValidate ="CustomerEmail" Text ="Needs to be a String" Operator ="DataTypeCheck" Type ="String" runat ="server" ValidationGroup='Submit'/>
                            <%--<input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">--%>
                          </div>
                        </div>
                        <div class="form-group col-md-2">
                          <label for="inputState">Contact Medium</label>
<asp:DropDownList ID="DDL2" AutoPostBack = "true" runat ="server"  CssClass="form-control"></asp:DropDownList>
                          
                        </div>
                        <div class="col-md-4">
                          <div class="form-group">
                            <label for="exampleInputEmail1">Other</label>
                               <asp:TextBox ID="otherBox" runat="server" CssClass="form-control"></asp:TextBox> <%--  Impliments Validators--%>
            <asp:RequiredFieldValidator ID ="otherBoxReq" ControlToValidate ="otherBox" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup='Submit'/>
            <asp:CompareValidator ID ="otherBoxVali" ControlToValidate ="otherBox" Text ="Needs to be a String" Operator ="DataTypeCheck" Type ="String" runat ="server" ValidationGroup='Submit'/>
                            <%--<input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">--%>
                          </div>
                        </div>
                    </div>
                
                <h4>Service</h4>
                <div class="row">
                    <div class="col">
                        <div class="btn-group btn-group-toggle" data-toggle="buttons">
                     
                        <label class="btn btn-secondary active">
                            <asp:RadioButton ID="MovingRadio" runat="server" AutoPostBack="True" Checked="True" OnCheckedChanged="MovingRadio_CheckedChanged" Text="Moving Service" />
                        </label>
                        <label class="btn btn-secondary active">
                            <asp:RadioButton ID="AuctionRadio" runat="server" AutoPostBack="True" OnCheckedChanged="AuctionRadio_CheckedChanged" Text="Auction Service" />
                        </label>

                        </div>
                    </div>
                </div>
                
                    <div class="row">
                        <div class="col-md-6">
                          <div class="form-group">
                            <label for="exampleInputEmail1">Requested Start Date</label>
                              <asp:TextBox ID="reqDate" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="dateReq" ControlToValidate="reqDate" Text="(Required)" Display="Dynamic" runat="server" ValidationGroup="Submit" CssClass ="form-control"/>
    <asp:CompareValidator ID="dateVali" ControlToValidate="reqDate" Text="Needs to be a Valid Date (mm/dd/yyyy)" Operator="DataTypeCheck" Type="Date" runat="server" ValidationGroup="Submit" />
                            <%--<input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">--%>
                          </div>
                        </div>
                        <div class="col-md-6">
                          <div class="form-group">
                            <label for="exampleInputPassword1">Service Address</label>
                               <asp:TextBox ID="servAddress" runat="server" CssClass ="file-control"></asp:TextBox>
                            <%--<input type="password" class="form-control" id="exampleInputPassword1">--%>
                          </div>
                        </div>
                    </div>
                
                    <div class="form-group">
                        <label for="exampleFormControlTextarea1">Description of Needs</label>
                        <asp:TextBox ID="descOfNeeds" runat="server" CssClass="form-control"></asp:TextBox>
    <asp:RequiredFieldValidator ID="needsReq" ControlToValidate="descOfNeeds" Text="(Required)" Display="Dynamic" runat="server" ValidationGroup="Submit" />
                        <%--<textarea class="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>--%>
                    </div>
               
            <div class="row">
                <div class="col-6">
                   
                      <div class="form-group">
                          <asp:FileUpload ID ="uploadFiles" runat="server" AllowMultiple="true" style="margin-left: 0px" Width="406px" CssClass ="form-control"/>
                        <%--<input type="file" class="form-control-file" id="exampleFormControlFile1">--%>
                      </div>
                   
                </div>
                <div class="col-6">
                    <asp:Button ID="upload" Text="Upload Files" runat="server" OnClick="Upload_Click" CssClass="form-control"/>
                    <%--<a href="#" type="submit" class="btn btn-primary">Upload Files</a>--%>
                </div>
            </div>
            
                <div class="row">
                    <div class="col-md-6">
                         <asp:Button ID="Return" runat="server" Text="Main Menu" OnClick="Return_Click" CssClass="btn btn-primary"/>
                        <%--<a href="landingcustserv.html" type="submit" class="btn btn-primary">&#60; Back to Main Menu</a>--%>
                    </div>
                    <div class="col-md-6">
                        <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" ValidationGroup ="Submit" CssClass="btn btn-primary"/>
                        <%--<a href="confirmation.html" type="submit" class="btn btn-primary">Submit</a>--%>
                    </div>
                     <div class="col-md-6">
                  <asp:Label ID="MissingInput" runat="server" Text=" "></asp:Label>
                  <asp:Label ID="TestLabel1" runat="server" Text=" "></asp:Label>
                    </div>
                </div>
            
            
        </div>

</asp:Content>
