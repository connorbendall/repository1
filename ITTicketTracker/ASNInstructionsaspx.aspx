<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ASNInstructionsaspx.aspx.cs" Inherits="ASNInstructionsaspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <fieldset>
            <legend>ASN Instructions</legend>

            <p>
                If there is no response to your IT Ticket within 45 minutes:
                <br />
                <OL>
                    <li>Contact the IT Team at informationservices@bend-all.com</li>
                    <li>Contact Solarsoft Support.</li>
                </OL>
            </p>
            <asp:Label ID="lblTicketNumber" runat="server" Text="" Font-Bold="true"/>
            
</fieldset>

</asp:Content>

