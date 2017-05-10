<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <fieldset>
       
            <h2 style="font-weight:bold;">OOPS!!</h2>
            
            <h4>An Error Occurred Within the application.</h4>
           <img src='images/error.jpg'>  
            <br />
            <p>You can submit an IT Ticket by clicking <a href="http://tuxania/ITTicketTracker" target="_blank">here</a></p>
            
            <br />
            <br />
            <h4>Error Details:</h4>
            <asp:Label ID="lblError" Font-Bold="true" runat ="server" ForeColor="Red" />
        
    </fieldset>
</asp:Content>

