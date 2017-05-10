<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="ChartReports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<style type="text/css">
    .centerText
    {
        text-align:left;
        font-size:16px;
        text-decoration:None;
        font-weight:bolder;
    }

</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <fieldset >
    <legend>Controls</legend>
            <table  >
             <tr>
                 <td>
                       <asp:Button ID="btnExportToExcel" runat="server" Text="Export To Excel"   style="margin-left:25px; "  onclick="btnExportToExcel_Click" /> <asp:Label ID="lblExport" Text ="Please Note: File Must Be Saved Locally To Be Opened" runat="server" ForeColor="Red" />
                 </td>
             </tr>
             <tr>
                <td>
                        <asp:Label ID="lblError" Font-Bold="true" ForeColor="Red" runat="server" /> 
                 </td>
             </tr>
         </table>      
    </fieldset>         
    <br/>
    <fieldset >
        <legend>Dashboard</legend>

          <br />
            <asp:Label ID="lblText" Width="904" runat="server" CssClass="centerText"  Text="IT User Statistics"/>
         <br />
            <asp:DataList ID="DataList1" runat="server" CellPadding="4" CssClass="centerText"  DataSourceID="sqlStaffStat" 
                RepeatDirection="Horizontal" ForeColor="#333333" BorderColor="Black" BorderWidth="2" Width="904">
                <AlternatingItemStyle BackColor="White"/>
                <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" 
                    Font-Italic="False" Font-Overline="False" Font-Size="Smaller" 
                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" Font-Bold="False" 
                    Font-Italic="False" Font-Overline="False" Font-Size="Small" 
                    Font-Strikeout="False" Font-Underline="False" />
                <ItemTemplate>
                    USER:
                    <asp:Label ID="USERLabel" runat="server" Text='<%# Eval("USER") %>' />
                    <br />
                    OPEN:
                    <asp:Label ID="OPENLabel" runat="server" Text='<%# Eval("OPEN") %>' />
                    <br />
                    CLOSED:
                    <asp:Label ID="CLOSEDLabel" runat="server" Text='<%# Eval("CLOSED") %>' />
                    <br />
                    TOTAL:
                    <asp:Label ID="TOTALLabel" runat="server" Text='<%# Eval("TOTAL") %>' />
                    <br />
                    Percentage:
                    <asp:Label ID="PercentageLabel" runat="server" 
                        Text='<%# Eval("Percentage") %>' />
                    <br />
                    Avg Life:
                    <asp:Label ID="AvgLabel" runat="server" 
                        Text='<%# Eval("Avg Ticket Life") %>' />
                    <br />
                    <br />
                </ItemTemplate>
                <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        </asp:DataList>
        <asp:SqlDataSource ID="sqlStaffStat" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
            SelectCommand="ITStaffStats" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>


        <br />    
        <br />      

        <asp:Label ID="Label1" Width="904" CssClass="centerText"  runat="server" Text="IT Ticket Statistics"/>

        <br />
        <asp:Chart  ID="comparisonChart"  runat="server" BorderColor="26, 59, 105" BorderWidth="2" BackGradientStyle="TopBottom" BackSecondaryColor="White" 
                palette="Pastel" BorderlineDashStyle="Solid" BackColor="WhiteSmoke" ImageType="Png" BackImage="~/images/Bendall.png" Width="904px" Height="400px">
            <titles>
				<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ForeColor="Black"></asp:Title>
            </titles>
            <legends>
				<asp:legend LegendStyle="Table"  IsTextAutoFit="False" DockedToChartArea="caScoreCard" Docking="Bottom" IsDockedInsideChartArea="False" Name="Default" 
                        BackColor="Transparent" Font="Trebuchet MS, 12pt, style=Bold" Alignment="Center"></asp:legend>
			</legends>
            <Series>
                <asp:Series Name="New" Color="Red" ChartType="Column" IsValueShownAsLabel="true" Font="Trebuchet MS, 10pt, style=Bold" >
                </asp:Series>
                <asp:Series Name="Closed" Color="Green" ChartType="Column" IsValueShownAsLabel="true" Font="Trebuchet MS,10pt, style=Bold" >
                </asp:Series>
                <asp:Series Name="Open" Color="Blue" ChartType="Column" IsValueShownAsLabel="true" Font="Trebuchet MS, 10pt, style=Bold" >
                </asp:Series>
            </Series>
            <ChartAreas >
                <asp:ChartArea Name="caScoreCard" > 
                    <AxisX IsLabelAutoFit="true">
                        <LabelStyle Angle ="90" Font="Arial, 12pt"   IsStaggered="true" Enabled="true"/>
                    </AxisX>
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>

        <br />
        <br />

        <asp:Chart ID="SixMonthTrendChart"  runat="server" BorderColor="26, 59, 105" BorderWidth="2" BackGradientStyle="TopBottom" BackSecondaryColor="White" palette="Pastel" BorderlineDashStyle="Solid" BackColor="WhiteSmoke" ImageType="Png" BackImage="~/images/Bendall.png"   Width="904px" Height="400px">
            <titles>
				<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ForeColor="Black"></asp:Title>
            </titles>
            <legends>
		        <asp:legend LegendStyle="Table"  IsTextAutoFit="False" DockedToChartArea="caScoreCard" Docking="Bottom" IsDockedInsideChartArea="False" Name="Default" 
                        BackColor="Transparent" Font="Trebuchet MS, 12pt, style=Bold" Alignment="Center"></asp:legend>	
            </legends>
            <Series>
                <asp:Series Name="New" Color="Red" BorderWidth="3" YAxisType="Primary"  ChartType="Line" IsValueShownAsLabel="true" Font="Trebuchet MS, 10pt, style=Bold" >
                </asp:Series>
                <asp:Series Name="Closed" Color="Green" BorderWidth="3" YAxisType="Primary" ChartType="Line" IsValueShownAsLabel="true" Font="Trebuchet MS, 10pt, style=Bold" >
                </asp:Series>
                <asp:Series Name="Open" Color="Blue" BorderWidth="3" YAxisType="Primary"  ChartType="Line" IsValueShownAsLabel="true" Font="Trebuchet MS, 10pt, style=Bold" >
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="caScoreCard" >
                <AxisX IsLabelAutoFit="true">
                    <LabelStyle Angle ="90" Font="Arial, 12pt" IsStaggered="true" Enabled="true"/>
                </AxisX>
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>

        <br />
        <br />
        <asp:Chart ID="TicketHealthChart"  runat="server" BorderColor="26, 59, 105" BorderWidth="2" BackGradientStyle="TopBottom" BackSecondaryColor="White" palette="Pastel" BorderlineDashStyle="Solid" BackColor="WhiteSmoke" ImageType="Png" BackImage="~/images/Bendall.png"   Width="904px" Height="400px">
            <titles>
				<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ForeColor="Black"></asp:Title>
            </titles>
            <legends>
		        <asp:legend LegendStyle="Table"  IsTextAutoFit="False" DockedToChartArea="caScoreCard" Docking="Bottom" IsDockedInsideChartArea="False" Name="Default" 
                        BackColor="Transparent" Font="Trebuchet MS, 12pt, style=Bold" Alignment="Center"></asp:legend>	
            </legends>
            <Series>
                <asp:Series Name="AverageOpen" Color="Green" BorderWidth="3"  ChartType="Line" IsValueShownAsLabel="true" Font="Trebuchet MS, 10pt, style=Bold" >
                </asp:Series>
                <asp:Series Name="AvergToClose" Color="Orange" BorderWidth="3"   ChartType="Line" IsValueShownAsLabel="true" Font="Trebuchet MS, 10pt, style=Bold" >
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="caScoreCard" >
                <AxisX IsLabelAutoFit="true">
                    <LabelStyle Angle ="90" Font="Arial, 12pt" IsStaggered="true" Enabled="true"/>
                </AxisX>
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
            
        <br />
        <br />

        <div >
            <asp:Chart ID="RealTimeChart"  runat="server" BorderColor="26, 59, 105" BorderWidth="2" BackGradientStyle="TopBottom" BackSecondaryColor="White" palette="Pastel" BorderlineDashStyle="Solid" BackColor="WhiteSmoke" ImageType="Png" BackImage="~/images/Bendall.png" Width="460px"  Height="296px">
                <titles>
				    <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ForeColor="Black"></asp:Title>
                </titles>
                <legends>
		            <asp:legend LegendStyle="Table"  IsTextAutoFit="False" DockedToChartArea="caScoreCard" Docking="Bottom" IsDockedInsideChartArea="False" Name="Default" 
                        BackColor="Transparent" Font="Trebuchet MS, 12pt, style=Bold" Alignment="Center"></asp:legend>	
                </legends>
                <Series>
                    <asp:Series Name="New" Color="Red" ChartType="Column" IsValueShownAsLabel="true" Font="Trebuchet MS, 10pt, style=Bold" >
                    </asp:Series>
                    <asp:Series Name="Closed" Color="Green" ChartType="Column" IsValueShownAsLabel="true" Font="Trebuchet MS, 10pt, style=Bold" >
                    </asp:Series>
                    <asp:Series Name="Open" Color="Blue" ChartType="Column" IsValueShownAsLabel="true" Font="Trebuchet MS,10pt, style=Bold" >
                    </asp:Series>
                    <asp:Series Name="Unassigned" Color="Yellow" ChartType="Column" IsValueShownAsLabel="true" Font="Trebuchet MS,10pt, style=Bold" >
                    </asp:Series>
                    <asp:Series Name="Averg" Color="Orange" ChartType="Column" IsValueShownAsLabel="true" Font="Trebuchet MS,10pt, style=Bold" >
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="caScoreCard">
                    <AxisX IsLabelAutoFit="true">
                        <LabelStyle Angle ="90"  IsStaggered="true" Enabled="true"/>
                    </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>

         <asp:Chart ID="TotalTicketsChart" runat="server" BorderColor="26, 59, 105" BorderWidth="2" BackGradientStyle="TopBottom" BackSecondaryColor="White" palette="Pastel" BorderlineDashStyle="Solid" 
            BackColor="WhiteSmoke" ImageType="Png" BackImage="~/images/Bendall.png"   Width="460px" Height="296px">
            <titles>
				    <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ForeColor="Black"></asp:Title>
                </titles>
                <legends>
		            <asp:legend LegendStyle="Table"  IsTextAutoFit="False" DockedToChartArea="caScoreCard" Docking="Bottom" IsDockedInsideChartArea="False" Name="Default" 
                        BackColor="Transparent" Font="Trebuchet MS, 12pt, style=Bold" Alignment="Center"></asp:legend>	
                </legends>
            <Series>
                <asp:Series Name="sData" Color="Blue" Font="Trebuchet MS, 10pt, style=Bold"  LabelForeColor="White" ChartType="Pie" IsValueShownAsLabel="true">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="caScoreCard">
                <area3dstyle Enable3D="True" />
                <AxisX IsLabelAutoFit="true">
                    <LabelStyle Angle ="90" IsStaggered="true" Enabled="true"/>
                </AxisX>
                </asp:ChartArea>
            </ChartAreas>
            </asp:Chart>
           
            </div>   
            <br />
            <br />

            <div >

            <asp:Chart ID="ASNIssueChart"  runat="server" BorderColor="26, 59, 105" BorderWidth="2" BackGradientStyle="TopBottom" BackSecondaryColor="White" palette="Pastel" BorderlineDashStyle="Solid" BackColor="WhiteSmoke" ImageType="Png" BackImage="~/images/Bendall.png"   Width="460px" Height="296px">
                <titles>
				    <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ForeColor="Black"></asp:Title>
                </titles>
                <legends>
		            <asp:legend LegendStyle="Table"  IsTextAutoFit="False" DockedToChartArea="caScoreCard" Docking="Bottom" IsDockedInsideChartArea="False" Name="Default" 
                        BackColor="Transparent" Font="Trebuchet MS, 12pt, style=Bold" Alignment="Center"></asp:legend>	
                </legends>
                <Series>
                    <asp:Series Name="sData" Color="Blue" ChartType="Column" IsValueShownAsLabel="true" Font="Trebuchet MS, 10pt, style=Bold" >
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="caScoreCard">
                    <AxisX IsLabelAutoFit="true">
                        <LabelStyle Angle ="90"  IsStaggered="true" Enabled="true"/>
                    </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>

            <asp:Chart ID="RepeatIssuesChart"  runat="server" BorderColor="26, 59, 105" BorderWidth="2" BackGradientStyle="TopBottom" BackSecondaryColor="White" palette="Pastel" BorderlineDashStyle="Solid" BackColor="WhiteSmoke" ImageType="Png" BackImage="~/images/Bendall.png"  Width="460px" Height="296px">
                <titles>
				    <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ForeColor="Black"></asp:Title>
                </titles>
                <legends>
		            <asp:legend LegendStyle="Table"  IsTextAutoFit="False" DockedToChartArea="caScoreCard" Docking="Bottom" IsDockedInsideChartArea="False" Name="Default" 
                        BackColor="Transparent" Font="Trebuchet MS, 12pt, style=Bold" Alignment="Center"></asp:legend>	
                </legends>
                <Series>
                    <asp:Series Name="sData" Color="Blue" ChartType="Column" IsValueShownAsLabel="true" Font="Trebuchet MS, 10pt, style=Bold" >
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="caScoreCard">
                    <AxisX IsLabelAutoFit="true">
                        <LabelStyle Angle ="90"  IsStaggered="true" Enabled="true"/>
                    </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>
        <br />
        <br />

            <div >

            <asp:Chart ID="CustomerIssuesChart"  runat="server" BorderColor="26, 59, 105" BorderWidth="2" BackGradientStyle="TopBottom" BackSecondaryColor="White" palette="Pastel" BorderlineDashStyle="Solid" BackColor="WhiteSmoke" ImageType="Png" BackImage="~/images/Bendall.png"   Width="460px" Height="296px">
                <titles>
				    <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ForeColor="Black"></asp:Title>
                </titles>
                <legends>
		            <asp:legend LegendStyle="Table"  IsTextAutoFit="False" DockedToChartArea="caScoreCard" Docking="Bottom" IsDockedInsideChartArea="False" Name="Default" 
                        BackColor="Transparent" Font="Trebuchet MS, 12pt, style=Bold" Alignment="Center"></asp:legend>	
                </legends>
                <Series>
                    <asp:Series Name="sData" Color="Blue" ChartType="Column" IsValueShownAsLabel="true" Font="Trebuchet MS, 10pt, style=Bold" >
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="caScoreCard">
                    <AxisX IsLabelAutoFit="true">
                        <LabelStyle Angle ="90" IsStaggered="true" Enabled="true"/>
                    </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>

            <asp:Chart ID="unplannedTicketsChart"  runat="server" BorderColor="26, 59, 105" BorderWidth="2" BackGradientStyle="TopBottom" BackSecondaryColor="White" palette="Pastel" BorderlineDashStyle="Solid" BackColor="WhiteSmoke" ImageType="Png" BackImage="~/images/Bendall.png"   Width="460px" Height="296px">
                    <titles>
				        <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ForeColor="Black"></asp:Title>
                    </titles>
                    <legends>
		                <asp:legend LegendStyle="Table"  IsTextAutoFit="False" DockedToChartArea="caScoreCard" Docking="Bottom" IsDockedInsideChartArea="False" Name="Default" 
                            BackColor="Transparent" Font="Trebuchet MS, 12pt, style=Bold" Alignment="Center"></asp:legend>	
                    </legends>
                    <Series>
                        <asp:Series Name="sData" Color="Blue" ChartType="Column" IsValueShownAsLabel="true" Font="Trebuchet MS, 10pt, style=Bold" >
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                    <asp:ChartArea Name="caScoreCard">
                    <AxisX IsLabelAutoFit="true">
                        <LabelStyle Angle ="90"  IsStaggered="true" Enabled="true"/>
                    </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            </div>

    </fieldset>
</asp:Content>

