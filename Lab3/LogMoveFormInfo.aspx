<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeBehind="LogMoveFormInfo.aspx.cs" Inherits="Lab3.LogMoveFormInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Choose what move you would like information on"></asp:Label>
    <asp:DropDownList ID="ddlMoveForm" runat="server" DataValueField="MoveFormID"></asp:DropDownList>
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CausesValidation="false" />
    <fieldset>
        <legend>
            <asp:Label ID="lblMoveForm" runat="server" Text="MoveForm Information"></asp:Label>
        </legend>
        <asp:GridView ID="grdMoveForm" runat="server"></asp:GridView>
    </fieldset>

    <asp:Label ID="lblFloorInfo" runat="server" Text="View rooms for a specific floor: "></asp:Label>
    <asp:DropDownList ID="ddlFloor" runat="server" DataTextField="Floor"></asp:DropDownList>
    <asp:Button ID="btnShowFloor" runat="server" Text="Sort by floor" OnClick="btnShowFloor_Click" CausesValidation="false" Enabled="false"/>
    <asp:Button ID="btnShowAll" runat="server" Text="Show all Floors" OnClick="btnShowAll_Click" CausesValidation="false" Enabled="false"/>

    <br />



    <fieldset>
        <legend>
            <asp:Label ID="lblRoomInfo" runat="server" Text="Rooms Information"></asp:Label>
        </legend>
        <asp:GridView ID="grdRoomInfo" runat="server"></asp:GridView>
    </fieldset>

    <br />

    <asp:Label ID="Label2" runat="server" Text="View Items for a specific Room: "></asp:Label>
    <asp:DropDownList ID="ddlRooms" runat="server" DataSourceID="dtaSrcRoomItemsID"></asp:DropDownList>
    <asp:Button ID="btnSubmitItems" runat="server" Text="See all Items in the Room" OnClick="btnSubmitItems_Click" CausesValidation="false" Enabled="false"/>

    <br />
    <asp:Label ID="Label3" runat="server" Text="Name: "></asp:Label>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtItemName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtItemName" runat="server"></asp:TextBox>

    <asp:Label ID="Label4" runat="server" Text="Description: "></asp:Label>
    <asp:TextBox ID="txtItemDescrip" runat="server" ></asp:TextBox>

    <asp:RadioButton ID="rdoBtnMove" runat="server" Text="Move" GroupName="RadioGroup1" Checked="true"/>
    <asp:RadioButton ID="rdoBtnDispose" runat="server" Text="Dispose"  GroupName="RadioGroup1"/>

    <asp:Button ID="btnAddNewItem" runat="server" Text="Submit New Item" CausesValidation="true" OnClick="btnAddNewItem_Click" Enabled="false" />

    <fieldset>
        <legend>
            <asp:Label ID="lblItemInfo" runat="server" Text="Item Information"></asp:Label>
        </legend>
        <asp:GridView ID="grdViewItems" runat="server"></asp:GridView>
    </fieldset>

    <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click"/>
    <asp:SqlDataSource ID="dtaSrcMoveFormID" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>"  SelectCommand ="SELECT MoveFormID from MoveForm"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dtaSrcRoomItemsID" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>"></asp:SqlDataSource>

</asp:Content>
