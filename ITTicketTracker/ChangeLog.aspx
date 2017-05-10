<%@ Page Title="Change Log" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ChangeLog.aspx.cs" Inherits="ChangeLog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <fieldset>
        <legend>Change Log</legend>

        <b>Add Commenting -</b> <span style="font-style:italic;">December 11 2012 - December 18 2012  </span>
        <ul>
            <li>Ability for user and IT to add additional comments after a ticket has been created</li>
            <li>Email Notification to user or IT when a new comment has been added based on who commented</li>
        </ul>
        <b>File Upload - </b><span style="font-style:italic;">December 11 2012 - December 18 2012  </span>
        <ul>
            <li>Ability to upload/download/delete file on both the Create Ticket and Edit Ticket Pages. </li>
            <li>One file per ticket</li>
            <li>Supported file types include "jpg", "png", "pdf", "docx", "xlsx", "msg" </li>
        </ul>
        <b>Active Directory -</b> <span style="font-style:italic;">December 11 2012 - December 18 2012 </span>
        <ul>
            <li>Merged ITTicket Tracker with ITAdmin Active Directory decides who can view what</li>
        </ul>
        <b>Dashboard -</b> <span style="font-style:italic;"> December 17 2012  </span> 
        <ul>
            <li>Modified Ticket Aging Chart to report in % and based on new set of time periods</li>
            <li>Modified Six Month Trending Chart to report average ticket life based on average of days open</li>
        </ul>
        <b>Updated Create Forms -</b> <span style="font-style:italic;">December 18 2012  </span>
        <ul>
            <li>Reorganized fields on create forms to flow better</li>
        </ul>
        <b>Updated Export Options -</b> <span style="font-style:italic;">December 18 2012  </span>
        <ul>
            <li>Updated Exporting to excel code so files can now be opened with out prompt</li>
        </ul>

    </fieldset>
</asp:Content>

