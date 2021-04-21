<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedinMaster.Master" AutoEventWireup="true" CodeBehind="LoggedNotes.aspx.cs" Inherits="Lab3.LoggedNotes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!--Noah  George, William Kilpatrick, Henry Requeno-Villeda  2/15/2021 -->
    <div style="height: 551px; width: 1247px;">
            Notes Management<br /><%--the page for people who are logged in--%>
            <asp:RadioButton ID="EditNote" runat="server" AutoPostBack= "True" Text= "View / Edit Notes" OnCheckedChanged="EditNote_CheckedChanged" />
            <br />
            <asp:RadioButton ID="NewNote" runat="server"  AutoPostBack= "True" Text ="Create New Note" OnCheckedChanged="NewNote_CheckedChanged" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Service Name"></asp:Label><%--Creates all the Labels and text boxes that need to be filled--%>
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:DropDownList ID="ServiceDDL" AutoPostBack = "true" runat ="server" OnSelectedIndexChanged ="ServiceDDL_SelectedIndexChanged" style="margin-left: 0px"></asp:DropDownList>
            <br />
        <asp:Label ID="noteDDLTitle" runat="server" Text="Note Title"></asp:Label>
             
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             
        <asp:DropDownList ID="NoteDDL" runat="server" AutoPostBack="true" OnSelectedIndexChanged ="NoteDDL_SelectedIndexChanged"></asp:DropDownList>
       
            
            <br />
            <asp:Label ID="noteTitleLbl" runat="server" Text="New Note Name"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="noteTitle" runat="server" Text =" "></asp:TextBox>
            <br />
            <br />
            <br />
                
            

            <br />

            

            <asp:TextBox ID="NoteInfo" runat="server" Height="283px" Width="829px"></asp:TextBox><%--Creates A list box to display output--%>
            <asp:RequiredFieldValidator ID ="noteInfoReq" ControlToValidate ="NoteInfo" Text ="(Required)" Display ="Dynamic" runat ="server" ValidationGroup='Submit'/> <%--  Impliments Validators--%>
            <asp:CompareValidator ID ="noteInfoVali" ControlToValidate ="NoteInfo" Text ="Needs to be a String" Operator ="DataTypeCheck" Type ="String" runat ="server" ValidationGroup='Submit'/>
            <br />
            <asp:Button ID="Return" runat="server" Text="Main Menu" OnClick="Return_Click" /><%-- Creates all the required buttons  --%>  
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			
            <asp:Label ID="MissingInput" runat="server" Text=""></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="saveChanges" runat="server" OnClick="saveChanges_Click" Text="Save Changes" ValidationGroup='Submit' />
            <asp:Label ID="noteStatus" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <br />
           
            <br />
            <br />
            <br />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />

        </div>


</asp:Content>
