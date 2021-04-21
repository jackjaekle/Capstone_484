<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeBehind="landingcustserv.aspx.cs" Inherits="Lab3.landingcustserv" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row" style="margin-top: 2rem;">
            <div class="col-xl-2">
                <h2 style="margin-top: 0rem;">Main Menu</h2>
            </div>
            <!-- end col h2 -->

            <div class="col-xl-6">
                <nav class="nav nav-tabs">
                    <a class="nav-link active" href="landingcustserv.aspx">Customer/Service</a>
                    <a class="nav-link" href="landingauctinv.aspx">Auction/Inventory</a>
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

                <a href="LogNewCustomer.aspx">
                    <img src="images/GreenValleyButton.png" width="350"></a>

                <div class="menubox shadow p-3 mb-5 bg-white rounded">
                    <div class="row" style="margin-top: 1rem;">
                        <div class="col-3">
                            <h3>View Customers</h3>

                        </div>
                    </div>
                    <div class="col-md-9">
                        <div class="formgroup">

                            <input type="Text" class="form-control" id="MissingText" runat="server" readonly="true" visible="false">

                            <input type="Text" class="form-control" id="NameLbl" runat="server" readonly="true" visible=" false">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="input-group">
                                <asp:DropDownList ID="CustLB" runat="server" OnSelectedIndexChanged="CustLB_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                <%--<select class="custom-select" id="inputGroupSelect04" aria-label="Example select with button addon">
                                <option selected>Select Customer</option>
                                <option value="1">One</option>
                                <option value="2">Two</option>
                                <option value="3">Three</option>
                              </select>--%>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-11">
                            <table class="table">
                                <thead class="thead-light">
                                    <tr>
                                        <th scope="col">Address</th>
                                        <th scope="col">Phone</th>
                                        <th scope="col">Email</th>
                                        <th scope="col">Discovery Type</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:Label ID="add" runat="server" Text=""></asp:Label></td>
                                        <td>
                                            <asp:Label ID="phone" runat="server" Text=""></asp:Label></td>
                                        <td>
                                            <asp:Label ID="email" runat="server" Text=""></asp:Label></td>
                                        <td>
                                            <asp:Label ID="disc" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <!-- end col -->
                    </div>
                    <!-- end row -->
                </div>

                <div class="menubox shadow p-3 mb-5 bg-white rounded">
                    <div class="row">
                        <div class="col-3">
                            <h3>View Service Event</h3>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="input-group">
                                <asp:ListBox ID="SvcLB" runat="server" Visible="false" OnSelectedIndexChanged="SvcLB_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:ListBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <asp:GridView ID="InfoGV" runat="server" Visible="true"></asp:GridView>
                        </div>
                        <!-- end col -->
                    </div>
                    <!-- end row -->

                    <div class="row">
                        <div class="col-md-6" style="margin-top: 1rem;">
                            <asp:Button ID="UpdateBtn" runat="server" Text="Update Selected Ticket->" OnClick="UpdateBtn_Click" Visible="false" CssClass="form-control" />

                        </div>
                    </div>

                    <div class="row notes-associated">
                        <div class="col-md-6">
                            <p>Notes Associated With Service</p>
                        </div>
                    </div>

                    <div class="row">
                        <asp:ListBox ID="notesList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="notesList_SelectedIndexChanged" CssClass="form-control"></asp:ListBox>
                    </div>
                </div>

                <div class="col-lg-3">
                    <div class=" row">
                        <asp:GridView ID="NoteGV" runat="server" Visible="false"></asp:GridView>
                    </div>
                </div>
                <div class="col-lg-3">
                    <div class=" row">
                        <asp:Button ID="editNote" runat="server" Text="Edit Selected Note" OnClick="editNote_Click" CssClass="form-control" />
                        <br />
                    </div>
                </div>
                <div class="col-lg-3">
                    <div class=" row">
                        <asp:Button ID="newNote" runat="server" Text="New Note" OnClick="newNote_Click" CssClass="form-control" />
                        <br />
                    </div>
                </div>
                <div class="col-lg-3">
                    <div class=" row">
                        <asp:Button ID="noteCreate" runat="server" Text="Create Note" OnClick="noteCreate_Click" CssClass="form-control" />
                        <br />
                    </div>
                </div>
                <div class="col-lg-3">
                    <div class=" row">
                        <asp:Button ID="UpdateNote" runat="server" Text="Update Note" OnClick="UpdateNote_Click" CssClass="form-control" />
                        <br />
                    </div>
                </div>

                <div class="col-lg-3">
                    <div class=" row">
                        <asp:TextBox ID="noteTitle" runat="server" CssClass="form-control" Visible="false" Text =" Enter Note title here"></asp:TextBox>
                        <%--<input type="Text" class="form-control" id="Label9" runat="server" text="Note Title" readonly="true">--%>
                    </div>
                </div>
                <%--<div class="col-lg-4">
                    <div class=" row">
                        <input type="Text" class="form-control" id="Text1" runat="server" text="Note Title " readonly="true">
                    </div>
                </div>--%>

                <div class="col-lg-3">
                    <div class=" row">
                        <asp:TextBox ID="noteBody" runat="server" CssClass="form-control" Visible="false" Text ="enter Note body here"></asp:TextBox>

                    </div>
                </div>
                <%--<div class="col-lg-4">
                    <div class=" row">
                        <input type="Text" class="form-control" id="Label10" runat="server" text="Note Body" readonly="true">
                    </div>
                </div>--%>

                <div class="row align-items-center">
                    <div class="col-md-10">
                        <div class="form-group">
                        </div>
                    </div>
                    <div class="col-md-2">
                        <%--                        <button type="button" class="btn btn-secondary btn-md">Submit</button>--%>
                    </div>
                </div>


                <div class="row" style="margin-top: 2rem;">
                    <div class="col-12">
                        <p>Employee Workflow History</p>
                    </div>
                </div>

                <div class="row employee-workflow">
                    <div class="col-11">
                        <asp:GridView ID="HistoryGV" runat="server" Visible="false"></asp:GridView>
                    </div>
                    <!-- end col -->
                </div>
                <!-- end row -->

                <div class="row">
                    <div class="col-md-6">
                        <p>Equipment History</p>
                    </div>
                </div>

                <div class="row equip-history">
                    <div class="col-11">
                        <asp:GridView ID="EquipmentGV" runat="server" Visible="false"></asp:GridView>
                    </div>
                    <!-- end col -->
                </div>
                <!-- end row -->
            </div>
             
            <div class="menubox shadow p-3 mb-5 bg-white rounded">
            <div class="row" style="margin-top: 1rem;">
                <div class="col-4">
                    <h3>Move Form Information</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <p>Select move service:</p>
                </div>
            </div>
            <div class="row">

                <div class="col-xl-8">
                    <div class="input-group">
                        <asp:DropDownList ID="ddlMoveForm" runat="server" DataValueField="MoveFormID" CssClass="form-control"></asp:DropDownList >
                        <div class="input-group-append">
                            </button><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CausesValidation="false" CssClass="btn btn-outline-secondary"/>
                        </div>
                    </div>
                </div>
                

            </div>
            <div class="row">
                <div class="col-11">
                    <asp:GridView ID="grdMoveForm" runat="server"></asp:GridView>
                </div>
                <!-- end col -->
            </div>
            <!-- end row -->
            <div class="row" style="margin-top: 2rem;">
                <div class="col-12">
                    <p>View rooms for a specific floor:</p>
                </div>
            </div>
            <div class="row">
                <div class="col-xl-8">
                    <div class="input-group">
                        <asp:DropDownList ID="ddlFloor" runat="server" DataTextField="Floor"></asp:DropDownList>
                        <div class="input-group-append">
                           <asp:Button ID="btnShowFloor" runat="server" Text="Sort by floor" OnClick="btnShowFloor_Click" CausesValidation="false" Enabled="false" CssClass="btn btn-outline-secondary"/>
                        </div>
                    </div>
                </div>
                <div class="col-4">
                    <asp:Button ID="btnShowAll" runat="server" Text="Show all Floors" OnClick="btnShowAll_Click" CausesValidation="false" Enabled="false" CssClass="btn btn-outline-secondary"/>
                </div>
                <!-- service request -->
            </div>
            <div class="row">
                <div class="col-11">
                    <asp:GridView ID="grdRoomInfo" runat="server"></asp:GridView>
                </div>
                <!-- end col -->
            </div>
            <!-- end row -->

                <%--//second part--%>
                <div class="row" style="margin-top: 2rem;">
                <div class="col-12">
                    <p>View Items for a specific room:</p>
                </div>
            </div>
            <div class="row">
                <div class="col-xl-8">
                    <div class="input-group">
                        <asp:DropDownList ID="ddlRooms" runat="server" DataTextField="Floor"></asp:DropDownList>
                        <div class="input-group-append">
                           
                <div class="col-4">
                    <asp:Button ID="Button2" runat="server" Text="Show all Floors" OnClick="btnSubmitItems_Click" CausesValidation="false" Enabled="false" CssClass="btn btn-outline-secondary"/>
                </div>
                <!-- service request -->
            </div>
            <div class="row">
                <div class="col-11">
                    <asp:GridView ID="grdViewItems" runat="server"></asp:GridView>
                </div>
                <!-- end col -->
            </div>
        </div>

        </div>
        
    </div>
          <div class="col-sm-4 d-xl-none" style="margin-top: -1.5rem;">
                    <h3 style="margin-top: 2rem; margin-bottom: 2rem;">Pending Customers</h3>
                
                <div class="col-xl-4" style="margin-top: -2rem;">
                    <div class="pending">
                        <h4>Customers Waiting on Service</h4>
                                <!-- service request -->
                            <div class="btn-group btn-group-toggle" data-toggle="buttons">
                              <label class="btn btn-secondary active">
                                <input type="radio" name="options" id="option1" checked> Moving Service
                              </label>
                              <label class="btn btn-secondary">
                                <input type="radio" name="options" id="option2"> Auction Service
                              </label>
                            </div>

                            
                                <div class="form-group">
                                    <textarea class="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>
                                </div>
                            

                            <div class="input-group mb-3" style="width: 30rem;">
                              <input type="text" class="form-control" placeholder="Customer Name" aria-label="Customer Name" aria-describedby="button-addon2">
                              <div class="input-group-append">
                                <a href="custmoveauctrequest.html" type="submit" class="btn btn-secondary btn-md">Service Customer</a>
                              </div>
                            </div> <!-- service request -->
                    </div>
                    
                    <div class="pending">
                        <h4>Customers Waiting on Moving Price</h4>
                           
                                <div class="form-group">
                                    <textarea class="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>
                                </div>
                           
                        <a href="moveestimatesheet.html" type="submit" class="btn btn-secondary btn-md">Move to Estimate Sheet</a>
                    </div>
                    
                    <div class="pending">
                        <h4>Customers Inventories Waiting to be Sent to Auction</h4>
                            
                                <div class="form-group">
                                    <textarea class="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>
                                </div>
                           
                        <div class="input-group mb-3" style="width: 30rem;">
                              <input type="text" class="form-control" placeholder="Customer Name" aria-label="Customer Name" aria-describedby="button-addon2">
                            <div class="input-group-append">
                                <a href="assigncustauct.html" type="submit" class="btn btn-secondary btn-md">Service Customer</a>
                            </div>
                        </div> <!-- service request -->
                        <asp:SqlDataSource ID="dtaSrcMoveFormID" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>"  SelectCommand ="SELECT MoveFormID from MoveForm"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dtaSrcRoomItemsID" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>"></asp:SqlDataSource>
                 </div>
                
                
                
            
            


        <asp:Table ID="ProgressTbl" runat="server" HorizontalAlign="Left" Width="20px">
            <asp:TableRow>
                <asp:TableCell Visible="false" ID="Bar0">
                    <asp:Image ID="Image0" runat="server" ImageUrl="/Img/bar0.png" />
                    <br />
                    <asp:Label ID="Lbl0" runat="server" Text=""></asp:Label>
                </asp:TableCell>
                <asp:TableCell Visible="false" ID="Bar1">
                    <asp:Image ID="Image1" runat="server" ImageUrl="/Img/bar1.png" />
                    <br />
                    <asp:Label ID="Lbl1" runat="server" Text=""></asp:Label>
                </asp:TableCell>
                <asp:TableCell Visible="false" ID="Bar2">
                    <asp:Image ID="Image2" runat="server" ImageUrl="/Img/bar2.png" />
                    <br />
                    <asp:Label ID="Lbl2" runat="server" Text=""></asp:Label>
                </asp:TableCell>
                <asp:TableCell Visible="false" ID="Bar3">
                    <asp:Image ID="Image3" runat="server" ImageUrl="/Img/bar3.png" />
                    <br />
                    <asp:Label ID="Lbl3" runat="server" Text=""></asp:Label>
                </asp:TableCell>
                <asp:TableCell Visible="false" ID="Bar4">
                    <asp:Image ID="Image4" runat="server" ImageUrl="/Img/bar4.png" />
                    <br />
                    <asp:Label ID="Lbl4" runat="server" Text=""></asp:Label>
                </asp:TableCell>
                <asp:TableCell Visible="false" ID="Bar5">
                    <asp:Image ID="Image5" runat="server" ImageUrl="/Img/bar5.png" />
                    <br />
                    <asp:Label ID="Lbl5" runat="server" Text=""></asp:Label>
                </asp:TableCell>
                <asp:TableCell Visible="false" ID="Bar6">
                    <asp:Image ID="Image6" runat="server" ImageUrl="/Img/bar6.png" />
                    <br />
                    <asp:Label ID="Lbl6" runat="server" Text=""></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
   



        </div>
</div>

    </div>
    </div>
</asp:Content>
