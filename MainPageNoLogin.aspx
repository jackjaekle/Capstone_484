<%@ Page Title="" Language="C#" MasterPageFile="~/LabMasterPage.Master" AutoEventWireup="true" CodeBehind="MainPageNoLogin.aspx.cs" Inherits="Lab1.MainPageNoLogin"  %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Log In</h2>
        <div class="col-md-10">
            <form class="login">
                <div class="form-group">
                    <label for="exampleInputEmail1">Email address</label>
                    <input type="Text" class="form-control" id="UserName" runat="server">
                </div>
                <div class="form-group">
                    <label for="Password">Password</label>
                    <input id="Password" type="Password" class="form-control" runat="server">
                </div>
                <div class="form-group form-check">
                </div>
                <asp:Button runat="server" class="btn btn-primary" type ="button" style="margin-left: 18.5rem" OnClick="CLogin_Click" Text="Submit" />
                <br />
                <asp:Label ID="MissingInput" runat="server" Text=""></asp:Label>
            </form>
        </div>
    </div>
</asp:Content>
