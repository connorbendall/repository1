<%@ Page Title="IT Dashboard" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ExecutiveDashboard.aspx.cs" Inherits="ChartReports" %>

<%@ Register Assembly="Shield.Web.UI" Namespace="Shield.Web.UI" TagPrefix="shield" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">

    <link rel="stylesheet" type="text/css" href="css/light/all.min.css" />
    <link rel="stylesheet" type="text/css" href="Styles/Site.css" />
    <script src="js/jquery-1.11.1.min.js" type="text/javascript"></script>
    <script src="js/shieldui-all.min.js" type="text/javascript"></script>
    <style type="text/css">
        .centerText {
            text-align: left;
            font-size: 16px;
            text-decoration: None;
            font-weight: bolder;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />



    <div class="row" style="width: 100%; padding-bottom: 1%; padding-top: 3%">

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <fieldset style="width: 15%; float: left;">
                    <legend>Drill-Drown Graph:</legend>


                    <div style="width: 100%;">
                        <div class="col-md-2" style="width: 80%; margin-left: 10%;">
                            <asp:Label ID="Label1" runat="server" Text="Year:" CssClass="id" Width="48%"></asp:Label>
                            <asp:DropDownList ID="ddlDrillYear" runat="server" CssClass="" Width="48%" AutoPostBack="false"></asp:DropDownList>

                        </div>
                        <br />
                        <div class="col-md-2" style="width: 80%; margin-left: 10%;">
                            <asp:Label ID="Label3" runat="server" Text="Week:" CssClass="id" Width="48%"></asp:Label>
                            <asp:DropDownList ID="ddlDrillWeek" runat="server" CssClass="" Width="48%" AutoPostBack="false"></asp:DropDownList>
                        </div>

                        <br />
                        <div class="col-md-2" style="width: 100%;">
                            <asp:Button runat="server" ID="DrillUpdate" OnClick="DrillUpdate_Click" Text="Update Chart" CssClass="button" Width="100%" />
                            <br />
                            <br />
                            <asp:Button runat="server" ID="MemberView" OnClick="MemberView_Click" Text="Show IT Members" CssClass="button" Width="100%" />
                            <br />
                            <br />
                            <asp:Button runat="server" ID="ResetButton" OnClick="ResetButton_Click" Text="Class Level View" CssClass="button" Width="100%" Visible="false" />
                        </div>

                    </div>



                </fieldset>
                <br />


                <br />
                <div style="padding-top: 15%; width: 100%">
                    <shield:ShieldChart ID="TypePanel" OnSeriesClick="TypePanel_SeriesClick" Width="50%" Height="400px" runat="server"
                        AutoPostBack="true" OnTakeDataSource="WeekDrillDown_TakeDataSource" UseCalbackFunction="false" CssClass="chart">
                    </shield:ShieldChart>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <div class="row" style="padding-bottom: 10%; padding-top: 5%"></div>


        <div class="row" style="width: 100%; padding-bottom: 1%; padding-top: 3%">

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <fieldset style="width: 15%; float: left;">
                    <legend>Drill-Drown Monthly Graph:</legend>


                    <div style="width: 100%;">
                        <div class="col-md-2" style="width: 80%; margin-left: 10%;">
                            <asp:Label ID="Label5" runat="server" Text="Year:" CssClass="id" Width="48%"></asp:Label>
                            <asp:DropDownList ID="ddlYr" runat="server" CssClass="" Width="48%" AutoPostBack="false"></asp:DropDownList>

                        </div>
                        <br />
                        <div class="col-md-2" style="width: 80%; margin-left: 10%;">
                            <asp:Label ID="Label6" runat="server" Text="Month:" CssClass="id" Width="48%"></asp:Label>
                            <asp:DropDownList ID="ddlMth" runat="server" CssClass="" Width="48%" AutoPostBack="false"></asp:DropDownList>
                        </div>

                        <br />
                        <div class="col-md-2" style="width: 100%;">
                            <asp:Button runat="server" ID="btnUpd" OnClick="mthDrillUpdate_Click" Text="Update Chart" CssClass="button" Width="100%" />
                            <br />
                            <br />
                            <asp:Button runat="server" ID="btnMem" OnClick="mthMemberView_Click" Text="Show IT Members" CssClass="button" Width="100%" />
                            <br />
                            <br />
                            <asp:Button runat="server" ID="btnRes" OnClick="mthResetButton_Click" Text="Class Level View" CssClass="button" Width="100%" Visible="false" />
                        </div>

                    </div>



                </fieldset>
                <br />


                <br />
                <div style="padding-top: 15%; width: 100%">
                    <shield:ShieldChart ID="MonthPanel" OnSeriesClick="MonthPanel_SeriesClick" Width="50%" Height="400px" runat="server"
                        AutoPostBack="true" OnTakeDataSource="MonthDrillDown_TakeDataSource" UseCalbackFunction="false" CssClass="chart">
                    </shield:ShieldChart>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <div class="row" style="padding-bottom: 10%; padding-top: 5%">






        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <fieldset style="width: 15%; float: left;">
                    <legend>Weekly Statistics Graph:</legend>



                    <div style="width: 80%; margin-left: 10%;">
                        <asp:Label ID="Label2" runat="server" Text="Year:" CssClass="id" Width="48%"></asp:Label>
                        <asp:DropDownList ID="ddlYear" runat="server" CssClass="" Width="48%" AutoPostBack="false"></asp:DropDownList>


                    </div>
                    <br />
                    <div style="width: 80%; margin-left: 10%;">
                        <asp:Label ID="Label4" runat="server" Text="Week:" CssClass="id" Width="48%"></asp:Label>

                        <asp:DropDownList ID="ddlWeek" runat="server" CssClass="" Width="48%" AutoPostBack="false"></asp:DropDownList>
                    </div>
                    <br />
                    <div>
                        <asp:Button runat="server" ID="WeekUpdate" OnClick="WeekUpdate_Click" Text="Update Chart" CssClass="button" Width="100%" />

                    </div>
                </fieldset>

                <br />


                <div style="width: 50%; padding-top: 10%;">
                    <shield:ShieldChart ID="WeeklyChart" Width="100%" Height="400px" runat="server"
                        AutoPostBack="true" UseCalbackFunction="false" CssClass="chart">
                    </shield:ShieldChart>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="row" style="padding-bottom: 10%; padding-top: 5%">
        <asp:Panel runat="server" ID="StatPanel"></asp:Panel>
    </div>



    <div style="padding-bottom: 10%; padding-top: 5%">
        <asp:Panel runat="server" ID="AgingPanel"></asp:Panel>
    </div>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <fieldset style="width: 15%; float: left;">
                <legend>New Weekly IT Tickets:</legend>


                <div style="width: 100%;">
                    <div class="col-md-2" style="width: 80%; margin-left: 10%;">
                        <asp:Label ID="Label7" runat="server" Text="Resource:" CssClass="id" Width="70%"></asp:Label><br />
                        <asp:DropDownList ID="ddlResource" runat="server" CssClass="" Width="100%" AutoPostBack="false"></asp:DropDownList>

                        <br />
                        <div class="col-md-2" style="width: 100%;">
                            <asp:Button runat="server" ID="btnNewWeek" OnClick="btnNewWeek_Click" Text="Update Chart" CssClass="button" Width="100%" />
                            <br />
                            <br />

                        </div>
            </fieldset>
            <div style="padding-bottom: 10%; padding-top: 10%">
                <asp:Panel runat="server" ID="NewWeekly"></asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>



    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <fieldset style="width: 15%; float: left;">
                <legend>Backlog Hours:</legend>


                <div style="width: 100%;">
                    <div style="width: 80%; margin-left: 10%;">
                        <asp:Label ID="Label9" runat="server" Text="Year:" CssClass="id" Width="48%"></asp:Label>
                        <asp:DropDownList ID="ddlBacklogYear" runat="server" CssClass="" Width="48%" AutoPostBack="false" >
                        </asp:DropDownList>


                    </div>
                    <br />
                    <div style="width: 80%; margin-left: 10%;">
                        <asp:Label ID="Label10" runat="server" Text="Week:" CssClass="id" Width="48%"></asp:Label>
                        <asp:DropDownList ID="ddlBacklogWeek" runat="server" CssClass="" Width="48%" AutoPostBack="false" ></asp:DropDownList>
                    </div>
                    <br />



                    <div class="col-md-2" style="width: 100%;">
                        <asp:Button runat="server" ID="btnBacklog" OnClick="btnBacklog_Click" Text="Update Chart" CssClass="button" Width="100%" />
                        <br />
                        <br />

                    </div> 

                </div>
            </fieldset>
          
            <div style="padding-bottom: 10%; padding-top: 15%">
             <asp:Panel runat="server" ID="BacklogPanel"></asp:Panel>
           
                
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

