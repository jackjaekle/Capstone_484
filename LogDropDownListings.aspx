<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeBehind="LogDropDownListings.aspx.cs" Inherits="Lab2.LogDropDownListings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Noah  George, William Kilpatrick, Henry Requeno-Villeda 2/15/2021 -->
    <div>
            <fieldset>
                <legend>Select Customer to View Services:</legend><%--the page for people who are logged in--%>

                <asp:DropDownList ID="DDL" AutoPostBack = "true" runat ="server" ></asp:DropDownList><%-- creates the DDL--%>
                <br />
              
                <asp:Button
                    ID="btnLoadCustomerData"
                    runat="server"
                    Text="Show Customer Services>"
                    OnClick="btnLoadCustomerData_Click" />
                <asp:Button ID="BtnShowAll" runat="server" Text="Show All Services >"
                    OnClick="BtnShowAll_Click" />
                

            </fieldset>
            <br />
            <fieldset>
                <legend>Services for Selected Customer: </legend>
                <asp:ListBox ID="DisplayBox" runat="server" Height="283px" Width="500px"></asp:ListBox>
            </fieldset>

        </div>
        <asp:SqlDataSource runat="server"
            ID="dtasrcCustomerList"
            ConnectionString="Server=Localhost;Database= Lab2;Trusted_Connection=Yes;"
            SelectCommand= "Select CustomerName FROM Customer" />
          <asp:Button ID="Return" runat="server" Text="Main Menu >"
                    OnClick="Return_Click" />

</asp:Content>
