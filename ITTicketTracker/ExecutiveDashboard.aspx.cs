using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.IO;
using System.Drawing;
using OfficeOpenXml;
using Shield.Web.UI;
using System.Dynamic;
using System.Globalization;



public partial class ChartReports : System.Web.UI.Page
{
    //ShieldChart WeeklyChart = new ShieldChart();
    ShieldChart Chart12WkComparison = new ShieldChart();
    //ShieldChart WeekTypeChart = new ShieldChart();
    ShieldChart ChartAging = new ShieldChart();
    ShieldChart ChartResource = new ShieldChart();
    ShieldChart ChartBacklog = new ShieldChart();
    private bool showIT = false;
    private bool mthShowIT = false;


    protected void Page_Load(object sender, EventArgs e)
    {
        /** Calculate Year **/
        int _currentyear;
        const int _year = 2013;
        _currentyear = DateTime.Now.Year;
        int _currentMonth = DateTime.Now.Month;
        //only add if list is clear -- it will add new items on every graph refresh

        if (ddlYear.Items.Count < 1 || ddlDrillYear.Items.Count < 1)
        {
            for (int s = _currentyear; s >= _year; s--)
            {
                ddlYear.Items.Add(new ListItem((s).ToString(), (s).ToString()));
                ddlDrillYear.Items.Add(new ListItem((s).ToString(), (s).ToString()));
                ddlYr.Items.Add(new ListItem((s).ToString(), (s).ToString()));
            }
        }
        //ddlYear.DataBind();

        /** Calculate Week **/
        CultureInfo ciCurr = CultureInfo.CurrentCulture;
        int weekNum = ciCurr.Calendar.GetWeekOfYear(DateTime.Now.Date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        int mthNum = ciCurr.Calendar.GetMonthsInYear(DateTime.Now.Year);

        //only add if list if clear -- it will add new items on every graph refresh
        if (ddlWeek.Items.Count < 1 || ddlDrillWeek.Items.Count < 1)
        {
            for (int s = weekNum; s >= 1; s--)
            {
                ddlDrillWeek.Items.Add(new ListItem((s).ToString(), (s).ToString()));
                ddlWeek.Items.Add(new ListItem((s).ToString(), (s).ToString()));
            }


        }
        if (ddlMth.Items.Count < 1)
        {
            int stop = 12 - _currentMonth;
            for (int s = _currentMonth; s >= 1; s--)
            {
                ddlMth.Items.Add(new ListItem((s).ToString(), (s).ToString()));
            }

            for (int s = 12; s > 12 - stop; s--)
            {
                ddlMth.Items.Add(new ListItem((s).ToString(), (s).ToString()));
            }
        }

        if (ddlResource.Items.Count < 1)
        {



            List<String> members = new List<String>();
            //get IT Members 
            members = ScoreCardReports.GetITMembers();
            members.Remove("Unassigned"); //should always be 0 hours - don't display

            foreach (String name in members)
            {
                ddlResource.Items.Add(name);
            }
        }


        if (ddlBacklogYear.Items.Count < 1)
        {



            List<int> years = new List<int>();
            //get IT Members 
            years = ScoreCardReports.GetBacklog_Year();


            foreach (int name in years)
            {
                ddlBacklogYear.Items.Add(name.ToString());
            }
        }

        if (ddlBacklogWeek.Items.Count < 1)
        {



            List<int> weeks = new List<int>();
            //get IT Members 
            weeks = ScoreCardReports.GetBacklog_Week();


            foreach (int name in weeks)
            {
                ddlBacklogWeek.Items.Add(name.ToString());
            }
        }
        CreateWeeklyChart();

        Create12WeekChart();
        CreateWeeklyIssuesDrillDown();
        CreateMonthlyIssuesDrillDown();
        CreateAgingChart();
        NewWeeklyByResource();
        CreateBacklog();


    }



    private string GetYearString(DateTime dateToCheck, int interval)
    {
        string dateField = "";


        DateTime twelveMonthsPrevious = dateToCheck.AddMonths(-11);

        if (dateToCheck.Year == twelveMonthsPrevious.Year)
            dateField = dateToCheck.Year.ToString();
        else
            dateField = twelveMonthsPrevious.Year.ToString() + @"-" + dateToCheck.Year.ToString();

        return dateField;
    }

    /// <summary>
    /// new weekly
    /// </summary>
    public void CreateWeeklyChart()
    {

        WeeklyChart.Width = Unit.Percentage(100);
        WeeklyChart.Height = Unit.Pixel(400);
        WeeklyChart.CssClass = "chart";
        WeeklyChart.PrimaryHeader.Text = "Weekly Statistics";
        WeeklyChart.TooltipSettings.AxisMarkers.Enabled = true;
        WeeklyChart.TooltipSettings.AxisMarkers.Mode = ChartXYMode.Y;
        WeeklyChart.TooltipSettings.AxisMarkers.Width = new Unit(1);
        WeeklyChart.TooltipSettings.AxisMarkers.ZIndex = 3;

        WeeklyChart.Font.Size = 12;
        WeeklyChart.Font.Bold = true;

        ChartAxisX axisX = new ChartAxisX();

        axisX.CategoricalValuesField = "label";
        axisX.AxisType = ChartAxisType.Datetime;



        WeeklyChart.Axes.Add(axisX);
        ChartAxisY axisY = new ChartAxisY();
        axisY.Title.Text = "# of Tickets";

        WeeklyChart.Axes.Add(axisY);

        ChartBarSeries splineSeriesOpen = new ChartBarSeries();
        splineSeriesOpen.DataFieldY = "Open";
        splineSeriesOpen.CollectionAlias = "Open Tickets";
        WeeklyChart.DataSeries.Add(splineSeriesOpen);
        //splineSeriesOpen.Settings.StackMode = ChartStackMode.Normal;

        ChartBarSeries splineSeriesNew = new ChartBarSeries();
        splineSeriesNew.DataFieldY = "New";
        splineSeriesNew.CollectionAlias = "New Tickets";
        WeeklyChart.DataSeries.Add(splineSeriesNew);
        //splineSeriesB.Settings.StackMode = ChartStackMode.Normal;

        ChartBarSeries splineSeriesClosed = new ChartBarSeries();
        splineSeriesClosed.DataFieldY = "Closed";
        splineSeriesClosed.CollectionAlias = "Closed Tickets";
        WeeklyChart.DataSeries.Add(splineSeriesClosed);
        //splineSeriesC.Settings.StackMode = ChartStackMode.Normal;
        /*
        ChartLineSeries splineSeriesTarget = new ChartLineSeries();
        splineSeriesTarget.DataFieldY = "ShiftTarget";
        splineSeriesTarget.CollectionAlias = "Shift Target";
        WeeklyChart.DataSeries.Add(splineSeriesTarget);
        */

        WeeklyChart.TakeDataSource += WeeklyChart_TakeDataSource;



        WeeklyChart.DataBind();
    }

    protected void WeeklyChart_TakeDataSource(object sender, Shield.Web.UI.ChartTakeDataSourceEventArgs e)
    {
        String myLabel = "";
        //Define datasource
        List<Tickets> datasource = new List<Tickets>();
        //Get Data from SQL Stored Procs
        List<int> Open = ScoreCardReports.WeekGetNumberOfOpenTickets(Int32.Parse(ddlWeek.SelectedValue), Int32.Parse(ddlYear.SelectedValue));
        List<int> New = ScoreCardReports.WeekGetNumberOfNewTickets(Int32.Parse(ddlWeek.SelectedValue), Int32.Parse(ddlYear.SelectedValue));
        List<int> Closed = ScoreCardReports.WeekGetNumberOfClosedTickets(Int32.Parse(ddlWeek.SelectedValue), Int32.Parse(ddlYear.SelectedValue));

        myLabel = "Week " + ddlWeek.SelectedValue + " of " + ddlYear.SelectedValue;
        datasource.Add(new Tickets() { Open = Open[0], New = New[0], Closed = Closed[0], label = myLabel });

        //Databind
        WeeklyChart.DataSource = datasource;

    }

    ///
    //12 week starts here 
    public void Create12WeekChart()
    {

        Chart12WkComparison.Width = Unit.Percentage(100);
        Chart12WkComparison.Height = Unit.Pixel(400);
        Chart12WkComparison.CssClass = "chart";
        Chart12WkComparison.PrimaryHeader.Text = "IT Tickets: Last 12 Weeks Statistics";
        Chart12WkComparison.TooltipSettings.AxisMarkers.Enabled = true;
        Chart12WkComparison.TooltipSettings.AxisMarkers.Mode = ChartXYMode.Y;
        Chart12WkComparison.TooltipSettings.AxisMarkers.Width = new Unit(1);
        Chart12WkComparison.TooltipSettings.AxisMarkers.ZIndex = 3;

        Chart12WkComparison.Font.Size = 12;
        Chart12WkComparison.Font.Bold = true;

        ChartAxisX axisX = new ChartAxisX();

        /**************************************************************************************************
        //***************************Dynamically Set X-Axis Labels*****************************************
        /**************************************************************************************************/

        System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();

        int selectedYear;
        int selectedMonth = DateTime.Today.Month - 1;
        if (selectedMonth < 1)
            selectedMonth = 12;

        int currentMonth = 0;

        if (selectedMonth == 12)
        {
            selectedYear = DateTime.Today.Year - 1;
            currentMonth = 1;
        }
        else
        {
            selectedYear = DateTime.Today.Year - 1;
            currentMonth = selectedMonth + 1;
        }


        double postion = 0.5;
        string[] monthLabels = new string[12];
        int postionModifier = 1; int x = 0;
        do
        {

            monthLabels[x] = "";//mfi.GetMonthName(currentMonth).ToString() + @"-" + selectedYear.ToString();
            postion += postionModifier;

            currentMonth++;
            if (currentMonth == 13)// Roll over the month
            {
                currentMonth = 1; //Jan
                selectedYear = selectedYear + 1;// Increase the year we are now in the previous year.
            }

            //comparisonChart.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);
            x++;
        } while (currentMonth != selectedMonth);

        monthLabels[x] = "";// mfi.GetMonthName(currentMonth).ToString() + @"-" + selectedYear.ToString();

        /*******************************************************************************************************/
        axisX.CategoricalValuesField = "label";

        axisX.AxisType = ChartAxisType.Datetime;

        //axisX.CategoricalValues = monthLabels;

        Chart12WkComparison.Axes.Add(axisX);
        ChartAxisY axisY = new ChartAxisY();
        axisY.Title.Text = "# of Tickets";
        Chart12WkComparison.Axes.Add(axisY);

        ChartLineSeries splineSeriesNew = new ChartLineSeries();
        splineSeriesNew.DataFieldY = "New";
        splineSeriesNew.CollectionAlias = "New Tickets";
        Chart12WkComparison.DataSeries.Add(splineSeriesNew);

        ChartLineSeries splineSeriesOpen = new ChartLineSeries();
        splineSeriesOpen.DataFieldY = "Open";
        splineSeriesOpen.CollectionAlias = "Open Tickets";
        Chart12WkComparison.DataSeries.Add(splineSeriesOpen);

        ChartLineSeries splineSeriesClosed = new ChartLineSeries();
        splineSeriesClosed.DataFieldY = "Closed";
        splineSeriesClosed.CollectionAlias = "Closed Tickets";
        Chart12WkComparison.DataSeries.Add(splineSeriesClosed);

        Chart12WkComparison.TakeDataSource += Chart12WkComparison_TakeDataSource;

        StatPanel.Controls.Add(Chart12WkComparison);
    }

    protected void Chart12WkComparison_TakeDataSource(object sender, Shield.Web.UI.ChartTakeDataSourceEventArgs e)
    {

        //Define datasource
        List<Tickets> datasource = new List<Tickets>();
        //Get Data from SQL Stored Procs
        List<int> closedData = ScoreCardReports.Week12GetNumberOfClosedTickets();
        List<int> openData = ScoreCardReports.Week12GetNumberOfOpenTickets();
        List<int> newData = ScoreCardReports.Week12GetNumberOfNewTickets();
        List<string> label = ScoreCardReports.Get12WeekLabels();

        // Merge 3 arraylist data into multidimentional class array
        for (int i = 0; i < closedData.Count; i++)
        {
            datasource.Add(new Tickets() { Open = openData[i], New = newData[i], Closed = closedData[i], label = label[i] });
        }

        //Databind
        Chart12WkComparison.DataSource = datasource;
    }


    //------------Weekly Drill Graph Containing Issues -------


    public void CreateWeeklyIssuesDrillDown()
    {

        TypePanel.Width = Unit.Percentage(100);
        TypePanel.Height = Unit.Pixel(400);
        TypePanel.CssClass = "chart";
        TypePanel.PrimaryHeader.Text = "Week " + ddlDrillWeek.SelectedValue + ": Class Level View";
        TypePanel.TooltipSettings.AxisMarkers.Enabled = true;
        TypePanel.TooltipSettings.AxisMarkers.Mode = ChartXYMode.Y;
        TypePanel.TooltipSettings.AxisMarkers.Width = new Unit(2);
        TypePanel.TooltipSettings.AxisMarkers.ZIndex = 3;

        TypePanel.Font.Size = 12;
        TypePanel.Font.Bold = true;

        ChartAxisX axisX = new ChartAxisX();

        axisX.CategoricalValuesField = "label";


        TypePanel.Axes.Add(axisX);
        ChartAxisY axisY = new ChartAxisY();
        axisY.Title.Text = "# of Hours ";
        TypePanel.Axes.Add(axisY);

        ChartBarSeries splineSeriesNone = new ChartBarSeries();
        splineSeriesNone.DataFieldY = "Unassigned";
        splineSeriesNone.ID = "Unassigned";
        splineSeriesNone.CollectionAlias = "Unassigned";
        TypePanel.DataSeries.Add(splineSeriesNone);

        ChartBarSeries splineSeriesFault = new ChartBarSeries();
        splineSeriesFault.DataFieldY = "Fault";
        splineSeriesFault.ID = "Fault/Failure";
        splineSeriesFault.CollectionAlias = "Fault/Failure";
        TypePanel.DataSeries.Add(splineSeriesFault);

        ChartBarSeries splineSeriesService = new ChartBarSeries();
        splineSeriesService.DataFieldY = "Service";
        splineSeriesService.ID = "Service Request";
        splineSeriesService.CollectionAlias = "Service Request";
        TypePanel.DataSeries.Add(splineSeriesService);

        ChartBarSeries splineSeriesAssistance = new ChartBarSeries();
        splineSeriesAssistance.DataFieldY = "Assistance";
        splineSeriesAssistance.CollectionAlias = "Assistance/Inquiry";
        splineSeriesAssistance.ID = "Assistance/Inquiry";
        TypePanel.DataSeries.Add(splineSeriesAssistance);



        //if(!IsPostBack)
        //{

        ClassLevelDrill();
        //   }

        TypePanel.DataBind();


        //TypePanel.Controls.Add(WeekTypeChart);
    }
    protected void ResetButton_Click(object sender, EventArgs e)
    {
        showIT = false;
        MemberView.Text = "Show IT Members";


        TypePanel.AutoPostBack = true;

        TypePanel.DataSeries.Clear();
        drillDownDatasource.Clear();
        TypePanel.Axes.Clear();

        CreateWeeklyIssuesDrillDown();



        MonthPanel.DataSeries.Clear();

        MonthPanel.Axes.Clear();

        CreateMonthlyIssuesDrillDown();

        WeeklyChart.Axes.Clear();
        WeeklyChart.DataSeries.Clear();

        CreateWeeklyChart();

        ResetButton.Visible = false;

    }

    protected void TypePanel_SeriesClick(object sender, ChartSeriesClickEventArgs e)
    {

        ResetButton.Visible = true;

        TypePanel.AutoPostBack = false;


        object clickedITName = e.Name;
        object clickedSeries = e.Series.ID;


        String itName = clickedITName.ToString();
        String className = clickedSeries.ToString();

        TypePanel.DataSeries.Clear();
        drillDownDatasource.Clear();
        //drillDownDatasource = new List<Issues>();
        TypePanel.Axes.Clear();
        TypePanel.PrimaryHeader.Text = "Week " + ddlDrillWeek.SelectedValue + ": Category Level View";

        ChartAxisX axisX = new ChartAxisX();

        axisX.CategoricalValuesField = "label";


        TypePanel.Axes.Add(axisX);
        ChartAxisY axisY = new ChartAxisY();
        axisY.Title.Text = "# of Hours ";
        TypePanel.Axes.Add(axisY);

        ChartBarSeries splineSeriesNone = new ChartBarSeries();
        splineSeriesNone.DataFieldY = "Unassigned";
        splineSeriesNone.ID = "Unassigned";
        splineSeriesNone.CollectionAlias = "Unassigned";
        TypePanel.DataSeries.Add(splineSeriesNone);

        ChartBarSeries splineSeriesHardware = new ChartBarSeries();
        splineSeriesHardware.DataFieldY = "Hardware";
        splineSeriesHardware.ID = "Hardware";
        splineSeriesHardware.CollectionAlias = "Hardware";
        TypePanel.DataSeries.Add(splineSeriesHardware);

        ChartBarSeries splineSeriesSoftware = new ChartBarSeries();
        splineSeriesSoftware.DataFieldY = "Software";
        splineSeriesSoftware.ID = "Software";
        splineSeriesSoftware.CollectionAlias = "Software";
        TypePanel.DataSeries.Add(splineSeriesSoftware);

        ChartBarSeries splineSeriesNetwork = new ChartBarSeries();
        splineSeriesNetwork.DataFieldY = "Network";
        splineSeriesNetwork.CollectionAlias = "Network";
        splineSeriesNetwork.ID = "Network";
        TypePanel.DataSeries.Add(splineSeriesNetwork);

        ChartBarSeries splineSeriesPeople = new ChartBarSeries();
        splineSeriesPeople.DataFieldY = "People";
        splineSeriesPeople.ID = "People/Accomodation";
        splineSeriesPeople.CollectionAlias = "People/Accomodation";
        TypePanel.DataSeries.Add(splineSeriesPeople);

        ChartBarSeries splineSeriesProcess = new ChartBarSeries();
        splineSeriesProcess.DataFieldY = "Process";
        splineSeriesProcess.ID = "Process";
        splineSeriesProcess.CollectionAlias = "Process";
        TypePanel.DataSeries.Add(splineSeriesProcess);

        ChartBarSeries splineSeriesDocumentation = new ChartBarSeries();
        splineSeriesDocumentation.DataFieldY = "Documentation";
        splineSeriesDocumentation.CollectionAlias = "Documentation";
        splineSeriesDocumentation.ID = "Documentation";
        TypePanel.DataSeries.Add(splineSeriesDocumentation);


        CategoryLevelDrill(itName, className);

        WeeklyChart.Axes.Clear();
        WeeklyChart.DataSeries.Clear();
        CreateWeeklyChart();

        MonthPanel.DataSeries.Clear();
        MonthPanel.Axes.Clear();
        mthdrillDownDatasource.Clear();
        CreateMonthlyIssuesDrillDown();

    }


    //Define datasource for dtill down Graph
    List<Issues> drillDownDatasource = new List<Issues>();

    private void ClassLevelDrill()
    {
        //Get Data from SQL Stored Procs

        List<String> issueClass = ScoreCardReports.GetIssueClass();
        List<String> iTmembers = new List<string>();

        if (showIT == true)
        {
            iTmembers = ScoreCardReports.GetITMembers();

            iTmembers.Remove("Unassigned"); //will always be 0 hours - no diplay
        }
        else
        {

            iTmembers.Add("ALL");
        }

        foreach (String name in iTmembers)
        {


            double none = ScoreCardReports.GetNumberOfClasses(name, "none", Int32.Parse(ddlDrillWeek.SelectedValue), Int32.Parse(ddlDrillYear.SelectedValue));
            double fault = ScoreCardReports.GetNumberOfClasses(name, "Fault/Failure", Int32.Parse(ddlDrillWeek.SelectedValue), Int32.Parse(ddlDrillYear.SelectedValue));
            double service = ScoreCardReports.GetNumberOfClasses(name, "Service Request", Int32.Parse(ddlDrillWeek.SelectedValue), Int32.Parse(ddlDrillYear.SelectedValue));
            double assistance = ScoreCardReports.GetNumberOfClasses(name, "Assistance/Inquiry", Int32.Parse(ddlDrillWeek.SelectedValue), Int32.Parse(ddlDrillYear.SelectedValue));

            // Merge 3 arraylist data into multidimentional class array

            drillDownDatasource.Add(new Issues() { Unassigned = none, Fault = fault, Assistance = assistance, Service = service, label = name });



        }
        //this change
        //TypePanel.DataBind();

        TypePanel.TakeDataSource += WeekDrillDown_TakeDataSource;

    }


    private void CategoryLevelDrill(String ITMember, String className)
    {


        double none = ScoreCardReports.GetNumberOfCategory(ITMember, className, "none", Int32.Parse(ddlDrillWeek.SelectedValue), Int32.Parse(ddlDrillYear.SelectedValue));
        double hardware = ScoreCardReports.GetNumberOfCategory(ITMember, className, "Hardware", Int32.Parse(ddlDrillWeek.SelectedValue), Int32.Parse(ddlDrillYear.SelectedValue));
        double software = ScoreCardReports.GetNumberOfCategory(ITMember, className, "Software", Int32.Parse(ddlDrillWeek.SelectedValue), Int32.Parse(ddlDrillYear.SelectedValue));
        double network = ScoreCardReports.GetNumberOfCategory(ITMember, className, "Network", Int32.Parse(ddlDrillWeek.SelectedValue), Int32.Parse(ddlDrillYear.SelectedValue));
        double people = ScoreCardReports.GetNumberOfCategory(ITMember, className, "People/Accomodation", Int32.Parse(ddlDrillWeek.SelectedValue), Int32.Parse(ddlDrillYear.SelectedValue));
        double process = ScoreCardReports.GetNumberOfCategory(ITMember, className, "Process", Int32.Parse(ddlDrillWeek.SelectedValue), Int32.Parse(ddlDrillYear.SelectedValue));
        double docs = ScoreCardReports.GetNumberOfCategory(ITMember, className, "Documentation", Int32.Parse(ddlDrillWeek.SelectedValue), Int32.Parse(ddlDrillYear.SelectedValue));

        drillDownDatasource.Add(new Issues() { Unassigned = none, Hardware = hardware, Software = software, Network = network, label = ITMember + ": " + className, People = people, Process = process, Documentation = docs });


        TypePanel.DataBind();
        TypePanel.TakeDataSource += WeekDrillDown_TakeDataSource;



    }

    protected void WeekDrillDown_TakeDataSource(object sender, Shield.Web.UI.ChartTakeDataSourceEventArgs e)
    {

        //Databind
        TypePanel.DataSource = drillDownDatasource;
    }


    private class Issues
    {
        public double Unassigned { get; set; }
        public double Fault { get; set; }
        public double Assistance { get; set; }
        public string label { get; set; }

        public double Service { get; set; }

        public double Hardware { get; set; }

        public double Software { get; set; }
        public double Network { get; set; }
        public double People { get; set; }
        public double Process { get; set; }
        public double Documentation { get; set; }
    }

    //-------------Monthly Drill Graph ------------------------//


    public void CreateMonthlyIssuesDrillDown()
    {

        MonthPanel.Width = Unit.Percentage(100);
        MonthPanel.Height = Unit.Pixel(400);
        MonthPanel.CssClass = "chart";
        MonthPanel.PrimaryHeader.Text = "Month " + ddlMth.SelectedValue + ": Class Level View";
        MonthPanel.TooltipSettings.AxisMarkers.Enabled = true;
        MonthPanel.TooltipSettings.AxisMarkers.Mode = ChartXYMode.Y;
        MonthPanel.TooltipSettings.AxisMarkers.Width = new Unit(2);
        MonthPanel.TooltipSettings.AxisMarkers.ZIndex = 3;

        MonthPanel.Font.Size = 12;
        MonthPanel.Font.Bold = true;

        ChartAxisX axisX = new ChartAxisX();

        axisX.CategoricalValuesField = "label";


        MonthPanel.Axes.Add(axisX);
        ChartAxisY axisY = new ChartAxisY();
        axisY.Title.Text = "# of Hours ";
        MonthPanel.Axes.Add(axisY);

        ChartBarSeries splineSeriesNone = new ChartBarSeries();
        splineSeriesNone.DataFieldY = "Unassigned";
        splineSeriesNone.ID = "Unassigned";
        splineSeriesNone.CollectionAlias = "Unassigned";
        MonthPanel.DataSeries.Add(splineSeriesNone);

        ChartBarSeries splineSeriesFault = new ChartBarSeries();
        splineSeriesFault.DataFieldY = "Fault";
        splineSeriesFault.ID = "Fault/Failure";
        splineSeriesFault.CollectionAlias = "Fault/Failure";
        MonthPanel.DataSeries.Add(splineSeriesFault);

        ChartBarSeries splineSeriesService = new ChartBarSeries();
        splineSeriesService.DataFieldY = "Service";
        splineSeriesService.ID = "Service Request";
        splineSeriesService.CollectionAlias = "Service Request";
        MonthPanel.DataSeries.Add(splineSeriesService);

        ChartBarSeries splineSeriesAssistance = new ChartBarSeries();
        splineSeriesAssistance.DataFieldY = "Assistance";
        splineSeriesAssistance.CollectionAlias = "Assistance/Inquiry";
        splineSeriesAssistance.ID = "Assistance/Inquiry";
        MonthPanel.DataSeries.Add(splineSeriesAssistance);



        //if(!IsPostBack)
        //{

        mthClassLevelDrill();
        //   }

        MonthPanel.DataBind();


        //TypePanel.Controls.Add(WeekTypeChart);
    }

    protected void mthResetButton_Click(object sender, EventArgs e)
    {
        mthShowIT = false;
        btnMem.Text = "Show IT Members";


        MonthPanel.AutoPostBack = true;

        MonthPanel.DataSeries.Clear();
        mthdrillDownDatasource.Clear();
        MonthPanel.Axes.Clear();
        CreateMonthlyIssuesDrillDown();


        WeeklyChart.Axes.Clear();
        WeeklyChart.DataSeries.Clear();
        CreateWeeklyChart();

        TypePanel.DataSeries.Clear();
        TypePanel.Axes.Clear();
        drillDownDatasource.Clear();
        CreateWeeklyIssuesDrillDown();


        btnRes.Visible = false;

    }

    protected void MonthPanel_SeriesClick(object sender, ChartSeriesClickEventArgs e)
    {

        btnRes.Visible = true;

        MonthPanel.AutoPostBack = false;


        object clickedITName = e.Name;
        object clickedSeries = e.Series.ID;


        String itName = clickedITName.ToString();
        String className = clickedSeries.ToString();

        MonthPanel.DataSeries.Clear();
        mthdrillDownDatasource.Clear();
        //drillDownDatasource = new List<Issues>();
        MonthPanel.Axes.Clear();
        MonthPanel.PrimaryHeader.Text = "Month " + ddlMth.SelectedValue + ": Category Level View";

        ChartAxisX axisX = new ChartAxisX();

        axisX.CategoricalValuesField = "label";


        MonthPanel.Axes.Add(axisX);
        ChartAxisY axisY = new ChartAxisY();
        axisY.Title.Text = "# of Hours ";
        MonthPanel.Axes.Add(axisY);

        ChartBarSeries splineSeriesNone = new ChartBarSeries();
        splineSeriesNone.DataFieldY = "Unassigned";
        splineSeriesNone.ID = "Unassigned";
        splineSeriesNone.CollectionAlias = "Unassigned";
        MonthPanel.DataSeries.Add(splineSeriesNone);

        ChartBarSeries splineSeriesHardware = new ChartBarSeries();
        splineSeriesHardware.DataFieldY = "Hardware";
        splineSeriesHardware.ID = "Hardware";
        splineSeriesHardware.CollectionAlias = "Hardware";
        MonthPanel.DataSeries.Add(splineSeriesHardware);

        ChartBarSeries splineSeriesSoftware = new ChartBarSeries();
        splineSeriesSoftware.DataFieldY = "Software";
        splineSeriesSoftware.ID = "Software";
        splineSeriesSoftware.CollectionAlias = "Software";
        MonthPanel.DataSeries.Add(splineSeriesSoftware);

        ChartBarSeries splineSeriesNetwork = new ChartBarSeries();
        splineSeriesNetwork.DataFieldY = "Network";
        splineSeriesNetwork.CollectionAlias = "Network";
        splineSeriesNetwork.ID = "Network";
        MonthPanel.DataSeries.Add(splineSeriesNetwork);

        ChartBarSeries splineSeriesPeople = new ChartBarSeries();
        splineSeriesPeople.DataFieldY = "People";
        splineSeriesPeople.ID = "People/Accomodation";
        splineSeriesPeople.CollectionAlias = "People/Accomodation";
        MonthPanel.DataSeries.Add(splineSeriesPeople);

        ChartBarSeries splineSeriesProcess = new ChartBarSeries();
        splineSeriesProcess.DataFieldY = "Process";
        splineSeriesProcess.ID = "Process";
        splineSeriesProcess.CollectionAlias = "Process";
        MonthPanel.DataSeries.Add(splineSeriesProcess);

        ChartBarSeries splineSeriesDocumentation = new ChartBarSeries();
        splineSeriesDocumentation.DataFieldY = "Documentation";
        splineSeriesDocumentation.CollectionAlias = "Documentation";
        splineSeriesDocumentation.ID = "Documentation";
        MonthPanel.DataSeries.Add(splineSeriesDocumentation);


        mthCategoryLevelDrill(itName, className);

        WeeklyChart.Axes.Clear();
        WeeklyChart.DataSeries.Clear();
        CreateWeeklyChart();

        TypePanel.DataSeries.Clear();
        TypePanel.Axes.Clear();
        drillDownDatasource.Clear();
        CreateWeeklyIssuesDrillDown();


    }


    //Define datasource for dtill down Graph
    List<Issues> mthdrillDownDatasource = new List<Issues>();

    private void mthClassLevelDrill()
    {

        //Get Data from SQL Stored Procs

        List<String> issueClass = ScoreCardReports.GetIssueClass();
        List<String> iTmembers = new List<string>();

        if (mthShowIT == true)
        {
            iTmembers = ScoreCardReports.GetITMembers();

            iTmembers.Remove("Unassigned"); //will always be 0 hours - no diplay
        }
        else
        {

            iTmembers.Add("ALL");
        }

        foreach (String name in iTmembers)
        {


            double none = ScoreCardReports.GetMonthNumberOfClasses(name, "none", Int32.Parse(ddlMth.SelectedValue), Int32.Parse(ddlYr.SelectedValue));
            double fault = ScoreCardReports.GetMonthNumberOfClasses(name, "Fault/Failure", Int32.Parse(ddlMth.SelectedValue), Int32.Parse(ddlYr.SelectedValue));
            double service = ScoreCardReports.GetMonthNumberOfClasses(name, "Service Request", Int32.Parse(ddlMth.SelectedValue), Int32.Parse(ddlYr.SelectedValue));
            double assistance = ScoreCardReports.GetMonthNumberOfClasses(name, "Assistance/Inquiry", Int32.Parse(ddlMth.SelectedValue), Int32.Parse(ddlYr.SelectedValue));

            // Merge 3 arraylist data into multidimentional class array

            mthdrillDownDatasource.Add(new Issues() { Unassigned = none, Fault = fault, Assistance = assistance, Service = service, label = name });



        }


        MonthPanel.TakeDataSource += MonthDrillDown_TakeDataSource;

    }


    private void mthCategoryLevelDrill(String ITMember, String className)
    {


        double none = ScoreCardReports.GetMonthNumberOfCategory(ITMember, className, "none", Int32.Parse(ddlMth.SelectedValue), Int32.Parse(ddlYr.SelectedValue));
        double hardware = ScoreCardReports.GetMonthNumberOfCategory(ITMember, className, "Hardware", Int32.Parse(ddlMth.SelectedValue), Int32.Parse(ddlYr.SelectedValue));
        double software = ScoreCardReports.GetMonthNumberOfCategory(ITMember, className, "Software", Int32.Parse(ddlMth.SelectedValue), Int32.Parse(ddlYr.SelectedValue));
        double network = ScoreCardReports.GetMonthNumberOfCategory(ITMember, className, "Network", Int32.Parse(ddlMth.SelectedValue), Int32.Parse(ddlYr.SelectedValue));
        double people = ScoreCardReports.GetMonthNumberOfCategory(ITMember, className, "People/Accomodation", Int32.Parse(ddlMth.SelectedValue), Int32.Parse(ddlYr.SelectedValue));
        double process = ScoreCardReports.GetMonthNumberOfCategory(ITMember, className, "Process", Int32.Parse(ddlMth.SelectedValue), Int32.Parse(ddlYr.SelectedValue));
        double docs = ScoreCardReports.GetMonthNumberOfCategory(ITMember, className, "Documentation", Int32.Parse(ddlMth.SelectedValue), Int32.Parse(ddlYr.SelectedValue));

        mthdrillDownDatasource.Add(new Issues() { Unassigned = none, Hardware = hardware, Software = software, Network = network, label = ITMember + ": " + className, People = people, Process = process, Documentation = docs });


        MonthPanel.DataBind();
        MonthPanel.TakeDataSource += MonthDrillDown_TakeDataSource;



    }

    protected void MonthDrillDown_TakeDataSource(object sender, Shield.Web.UI.ChartTakeDataSourceEventArgs e)
    {

        //Databind
        MonthPanel.DataSource = mthdrillDownDatasource;
    }




    public void CreateAgingChart()
    {

        ChartAging.Width = Unit.Percentage(100);
        ChartAging.Height = Unit.Pixel(400);
        ChartAging.CssClass = "chart";
        ChartAging.PrimaryHeader.Text = "IT Tickets: Aging >90 Days (Last 12 Weeks)";
        ChartAging.TooltipSettings.AxisMarkers.Enabled = true;
        ChartAging.TooltipSettings.AxisMarkers.Mode = ChartXYMode.Y;
        ChartAging.TooltipSettings.AxisMarkers.Width = new Unit(1);
        ChartAging.TooltipSettings.AxisMarkers.ZIndex = 3;

        ChartAging.Font.Size = 12;
        ChartAging.Font.Bold = true;

        ChartAxisX axisX = new ChartAxisX();

        /**************************************************************************************************
        //***************************Dynamically Set X-Axis Labels*****************************************
        /**************************************************************************************************/

        System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();

        int selectedYear;
        int selectedMonth = DateTime.Today.Month - 1;
        if (selectedMonth < 1)
            selectedMonth = 12;

        int currentMonth = 0;

        if (selectedMonth == 12)
        {
            selectedYear = DateTime.Today.Year - 1;
            currentMonth = 1;
        }
        else
        {
            selectedYear = DateTime.Today.Year - 1;
            currentMonth = selectedMonth + 1;
        }


        double postion = 0.5;
        string[] monthLabels = new string[12];
        int postionModifier = 1; int x = 0;
        do
        {

            monthLabels[x] = "";//mfi.GetMonthName(currentMonth).ToString() + @"-" + selectedYear.ToString();
            postion += postionModifier;

            currentMonth++;
            if (currentMonth == 13)// Roll over the month
            {
                currentMonth = 1; //Jan
                selectedYear = selectedYear + 1;// Increase the year we are now in the previous year.
            }

            //comparisonChart.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);
            x++;
        } while (currentMonth != selectedMonth);

        monthLabels[x] = "";// mfi.GetMonthName(currentMonth).ToString() + @"-" + selectedYear.ToString();

        /*******************************************************************************************************/
        axisX.CategoricalValuesField = "label";

        axisX.AxisType = ChartAxisType.Datetime;

        //axisX.CategoricalValues = monthLabels;

        ChartAging.Axes.Add(axisX);
        ChartAxisY axisY = new ChartAxisY();
        axisY.Title.Text = "Age of Tickets";
        ChartAging.Axes.Add(axisY);


        ChartLineSeries splineSeriesAging = new ChartLineSeries();
        splineSeriesAging.DataFieldY = "Aging";
        splineSeriesAging.CollectionAlias = "Aging Tickets";
        ChartAging.DataSeries.Add(splineSeriesAging);

        ChartAging.TakeDataSource += Chart12MthAging_TakeDataSource;

        AgingPanel.Controls.Add(ChartAging);
    }

    protected void Chart12MthAging_TakeDataSource(object sender, Shield.Web.UI.ChartTakeDataSourceEventArgs e)
    {

        //Define datasource
        List<Tickets> datasource = new List<Tickets>();
        //Get Data from SQL Stored Procs
        List<int> agingData = ScoreCardReports.Get12WeekAgingTickets();

        List<string> label = ScoreCardReports.Get12WeekLabels();

        // Merge 3 arraylist data into multidimentional class array
        for (int i = 0; i < agingData.Count; i++)
        {
            datasource.Add(new Tickets() { Aging = agingData[i], label = label[i] });
        }

        //Databind
        ChartAging.DataSource = datasource;
    }




    private class Tickets
    {
        public double New { get; set; }
        public double Open { get; set; }
        public double Closed { get; set; }
        public string label { get; set; }

        public double Aging { get; set; }
    }



    protected void WeekUpdate_Click(object sender, EventArgs e)
    {

        showIT = false;
        mthShowIT = false;
        TypePanel.AutoPostBack = true;
        TypePanel.DataSeries.Clear();
        drillDownDatasource.Clear();
        TypePanel.Axes.Clear();
        MemberView.Text = "Show IT Members";
        CreateWeeklyIssuesDrillDown();
        ResetButton.Visible = false;

        mthShowIT = false;
        MonthPanel.AutoPostBack = true;
        MonthPanel.DataSeries.Clear();
        mthdrillDownDatasource.Clear();
        MonthPanel.Axes.Clear();
        btnMem.Text = "Show IT Members";
        CreateMonthlyIssuesDrillDown();
        btnRes.Visible = false;

        WeeklyChart.Axes.Clear();
        WeeklyChart.DataSeries.Clear();

        CreateWeeklyChart();
    }


    protected void DrillUpdate_Click(object sender, EventArgs e)
    {

        WeeklyChart.Axes.Clear();
        WeeklyChart.DataSeries.Clear();
        CreateWeeklyChart();

        mthShowIT = false;
        btnMem.Text = "Show IT Members";
        btnRes.Visible = false;
        MonthPanel.DataSeries.Clear();
        MonthPanel.Axes.Clear();
        mthdrillDownDatasource.Clear();
        CreateMonthlyIssuesDrillDown();

        showIT = false;
        TypePanel.AutoPostBack = true;
        TypePanel.DataSeries.Clear();
        drillDownDatasource.Clear();
        TypePanel.Axes.Clear();
        MemberView.Text = "Show IT Members";
        CreateWeeklyIssuesDrillDown();

        ResetButton.Visible = false;
    }


    protected void mthDrillUpdate_Click(object sender, EventArgs e)
    {

        WeeklyChart.Axes.Clear();
        WeeklyChart.DataSeries.Clear();
        CreateWeeklyChart();

        showIT = false;
        MemberView.Text = "Show IT Members";
        ResetButton.Visible = false;
        TypePanel.DataSeries.Clear();
        TypePanel.Axes.Clear();
        drillDownDatasource.Clear();
        CreateWeeklyIssuesDrillDown();

        MonthPanel.AutoPostBack = true;
        MonthPanel.DataSeries.Clear();
        mthdrillDownDatasource.Clear();
        MonthPanel.Axes.Clear();
        btnMem.Text = "Show IT Members";
        CreateMonthlyIssuesDrillDown();

        btnRes.Visible = false;
    }



    protected void MemberView_Click(object sender, EventArgs e)
    {

        if (MemberView.Text == "Show IT Members")
        {

            showIT = true;
            MemberView.Text = "Show ALL";


        }
        else
        {

            showIT = false;
            MemberView.Text = "Show IT Members";


        }
        TypePanel.AutoPostBack = true;
        TypePanel.DataSeries.Clear();
        drillDownDatasource.Clear();
        TypePanel.Axes.Clear();

        //TypePanel.DataBind();
        CreateWeeklyIssuesDrillDown();

        ResetButton.Visible = false;

        WeeklyChart.Axes.Clear();
        WeeklyChart.DataSeries.Clear();
        CreateWeeklyChart();

        mthShowIT = false;
        btnMem.Text = "Show IT Members";
        btnRes.Visible = false;
        MonthPanel.DataSeries.Clear();
        MonthPanel.Axes.Clear();
        mthdrillDownDatasource.Clear();
        CreateMonthlyIssuesDrillDown();

    }


    protected void mthMemberView_Click(object sender, EventArgs e)
    {

        if (btnMem.Text == "Show IT Members")
        {

            mthShowIT = true;
            btnMem.Text = "Show ALL";


        }
        else
        {

            mthShowIT = false;
            btnMem.Text = "Show IT Members";


        }

        MonthPanel.AutoPostBack = true;
        MonthPanel.DataSeries.Clear();
        mthdrillDownDatasource.Clear();
        MonthPanel.Axes.Clear();

        //TypePanel.DataBind();
        CreateMonthlyIssuesDrillDown();

        btnRes.Visible = false;

        WeeklyChart.Axes.Clear();
        WeeklyChart.DataSeries.Clear();
        CreateWeeklyChart();


        showIT = false;
        MemberView.Text = "Show IT Members";
        ResetButton.Visible = false;
        TypePanel.DataSeries.Clear();
        TypePanel.Axes.Clear();
        drillDownDatasource.Clear();
        CreateWeeklyIssuesDrillDown();

    }



    //------------------new ticket by it resource --------------------------//


    public void NewWeeklyByResource()
    {

        ChartResource.Width = Unit.Percentage(100);
        ChartResource.Height = Unit.Pixel(400);
        ChartResource.CssClass = "chart";
        ChartResource.PrimaryHeader.Text = "New IT Tickets (Last 12 Weeks)";
        ChartResource.TooltipSettings.AxisMarkers.Enabled = true;
        ChartResource.TooltipSettings.AxisMarkers.Mode = ChartXYMode.Y;
        ChartResource.TooltipSettings.AxisMarkers.Width = new Unit(1);
        ChartResource.TooltipSettings.AxisMarkers.ZIndex = 3;

        ChartResource.Font.Size = 12;
        ChartResource.Font.Bold = true;

        ChartAxisX axisX = new ChartAxisX();

        axisX.CategoricalValuesField = "label";
        // axisX.CategoricalValues = label.ToArray();
        //axisX.CategoricalValues = monthLabels;

        ChartResource.Axes.Add(axisX);
        ChartAxisY axisY = new ChartAxisY();
        axisY.Title.Text = "# of New Tickets";
        ChartResource.Axes.Add(axisY);


        List<Tickets> datasource = new List<Tickets>();


        ChartLineSeries splineSeriesNew = new ChartLineSeries();
        splineSeriesNew.DataFieldY = "New";
        splineSeriesNew.ID = "New Tickets";
        splineSeriesNew.CollectionAlias = ddlResource.SelectedValue;
        ChartResource.DataSeries.Add(splineSeriesNew);

        List<int> newData = ScoreCardReports.Get12WeekNewByResource(ddlResource.SelectedValue);
        List<string> label = ScoreCardReports.Get12WeekLabels();

        for (int i = 0; i < newData.Count; i++)
        {
            datasource.Add(new Tickets() { New = newData[i], label = label[i] });
        }




        ChartResource.DataSource = datasource;
        //ChartResource.TakeDataSource += ChartResource_TakeDataSource;
        NewWeekly.DataBind();
        NewWeekly.Controls.Add(ChartResource);
    }

    protected void btnNewWeek_Click(object sender, EventArgs e)
    {
        ChartResource.Axes.Clear();
        ChartResource.DataSeries.Clear();
        //ChartResource.DataSource = null;

        NewWeeklyByResource();

        showIT = false;
        mthShowIT = false;
        TypePanel.AutoPostBack = true;
        TypePanel.DataSeries.Clear();
        drillDownDatasource.Clear();
        TypePanel.Axes.Clear();
        MemberView.Text = "Show IT Members";
        CreateWeeklyIssuesDrillDown();
        ResetButton.Visible = false;

        mthShowIT = false;
        MonthPanel.AutoPostBack = true;
        MonthPanel.DataSeries.Clear();
        mthdrillDownDatasource.Clear();
        MonthPanel.Axes.Clear();
        btnMem.Text = "Show IT Members";
        CreateMonthlyIssuesDrillDown();
        btnRes.Visible = false;

        WeeklyChart.Axes.Clear();
        WeeklyChart.DataSeries.Clear();

        CreateWeeklyChart();
    }



    //------------------------------------------------------------------------------------------

    public void CreateBacklog()
    {
        DropDownList ddlbweek = (DropDownList)FindControl("ddlBacklogWeek");


        ChartBacklog.Width = Unit.Percentage(100);
        ChartBacklog.Height = Unit.Pixel(400);
        ChartBacklog.CssClass = "chart";
        ChartBacklog.PrimaryHeader.Text = "IT Tickets Backlog (Week: " + ddlBacklogWeek.SelectedItem.Text + " of " + ddlBacklogYear.SelectedItem.Text + ")";
        ChartBacklog.TooltipSettings.AxisMarkers.Enabled = true;
        ChartBacklog.TooltipSettings.AxisMarkers.Mode = ChartXYMode.Y;
        ChartBacklog.TooltipSettings.AxisMarkers.Width = new Unit(1);
        ChartBacklog.TooltipSettings.AxisMarkers.ZIndex = 3;

        ChartBacklog.Font.Size = 12;
        ChartBacklog.Font.Bold = true;

        ChartAxisX axisX = new ChartAxisX();

        axisX.CategoricalValuesField = "label";
        //axisX.CategoricalValues = label.ToArray();
        //axisX.CategoricalValues = monthLabels;

        ChartBacklog.Axes.Add(axisX);
        ChartAxisY axisY = new ChartAxisY();
        axisY.Title.Text = "Hours";
        ChartBacklog.Axes.Add(axisY);


        List<Backlog> datasource = new List<Backlog>();


        ChartBarSeries splineSeriesNew = new ChartBarSeries();
        splineSeriesNew.DataFieldY = "BacklogHour";
        splineSeriesNew.ID = "BacklogHour";
        splineSeriesNew.CollectionAlias = "Backlog";
        ChartBacklog.DataSeries.Add(splineSeriesNew);

        List<double> newData = ScoreCardReports.GetBacklog_Hours(Convert.ToInt32(ddlBacklogWeek.SelectedValue), Convert.ToInt32(ddlBacklogYear.SelectedValue));
        List<string> name = ScoreCardReports.GetBacklog_Names(Convert.ToInt32(ddlBacklogWeek.SelectedValue), Convert.ToInt32(ddlBacklogYear.SelectedValue));

        if (newData.Count > 0)
        {
            for (int i = 0; i < newData.Count; i++)
            {
                datasource.Add(new Backlog() { BacklogHour = newData[i], label = name[i] });
            }

            ChartBacklog.DataSource = datasource;
            //ChartResource.TakeDataSource += ChartResource_TakeDataSource;
            BacklogPanel.DataBind();
            BacklogPanel.Controls.Add(ChartBacklog);
        }
        
    }


    private class Backlog
    {
        public string label { get; set; }
        public double BacklogHour { get; set; }
       
        public string dates { get; set; }

       
    }


   protected void btnBacklog_Click(object sender, EventArgs e)
    {
        ChartBacklog.Axes.Clear();
        ChartBacklog.DataSeries.Clear();
        //ChartResource.DataSource = null;
        CreateBacklog();


        //NewWeeklyByResource();

        showIT = false;
        mthShowIT = false;
        TypePanel.AutoPostBack = true;
        TypePanel.DataSeries.Clear();
        drillDownDatasource.Clear();
        TypePanel.Axes.Clear();
        MemberView.Text = "Show IT Members";
        CreateWeeklyIssuesDrillDown();
        ResetButton.Visible = false;

        mthShowIT = false;
        MonthPanel.AutoPostBack = true;
        MonthPanel.DataSeries.Clear();
        mthdrillDownDatasource.Clear();
        MonthPanel.Axes.Clear();
        btnMem.Text = "Show IT Members";
        CreateMonthlyIssuesDrillDown();
        btnRes.Visible = false;

        WeeklyChart.Axes.Clear();
        WeeklyChart.DataSeries.Clear();

        CreateWeeklyChart();
    }


}