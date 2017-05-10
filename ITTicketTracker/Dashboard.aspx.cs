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



public partial class ChartReports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e) 
    {

        CreatUnplannedTicketChart();
        CreateComparisonChart();
        CreateSixMonthTrendChart();
        CreateASNIssueChart();
        CreateRepeatIssueChart();
        CreateCustomerIssueChart();
        CreateRealTimeChart();
        CreateTicketHealthTrendChart();
        CreateHistoricalTicketStats();
    
    }

 



    /// <summary>
    /// The methods below are used to create the look and feel of the different charts
    /// </summary>
    #region Create Chart Methods
 

    public void CreatUnplannedTicketChart()
    {
        List<int> returnedData = new List<int>();
        unplannedTicketsChart.Titles[0].Text = "Unplanned Issues (" + GetYearString(DateTime.Now, 12) + ")";
        returnedData = ScoreCardReports.GetNumberOfUnplannedTickets();

        unplannedTicketsChart.ChartAreas["caScoreCard"].AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 11);

        int unplannedCount =0;
        foreach (int value in returnedData)
        {
            unplannedTicketsChart.Series["sData"].Points.Add(value);
            unplannedCount += value;
        }
        unplannedTicketsChart.Series["sData"].LegendText = "Unplanned (" + unplannedCount + ")";

        CustomLabel customLabel = new CustomLabel();
        string[] months = new string[] {"JAN", "FEB", "MAR", "APR",
                "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"};

        int selectedYear;
        int selectedMonth = DateTime.Today.Month;
        int currentMonth = 0;

        if (selectedMonth == 12)
        {
            selectedYear = DateTime.Today.Year;
            currentMonth = 1;
        }
        else
        {
            selectedYear = DateTime.Today.Year - 1;
            currentMonth = selectedMonth + 1;
        }


        double postion = 0.5;

        int postionModifier = 1;
        do
        {

            customLabel.Text = (currentMonth).ToString() + @"-" + selectedYear.ToString();
            customLabel.FromPosition = postion;
            customLabel.ToPosition = postion + postionModifier;
            postion += postionModifier;

            currentMonth++;
            if (currentMonth == 13)// Roll over the month
            {
                currentMonth = 1; //Jan
                selectedYear = selectedYear + 1;// Increase the year we are now in the previous year.
            }

            unplannedTicketsChart.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);

            customLabel = new CustomLabel();

        } while (currentMonth != selectedMonth);

        customLabel.Text = (currentMonth).ToString() + @"-" + selectedYear.ToString();
        customLabel.FromPosition = postion;
        customLabel.ToPosition = postion + postionModifier;

        unplannedTicketsChart.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);

        customLabel = new CustomLabel();

        Series trendLine = createTrendLine(unplannedTicketsChart.Series["sData"]);
        trendLine.ChartType = SeriesChartType.Line;

        //unplannedTicketsChart.Series.Add(trendLine);
    }

    public void CreateComparisonChart()
    {
        List<int> newData = new List<int>();
        List<int> closedData = new List<int>();
        List<int> openData = new List<int>();
        

        comparisonChart.Series["New"].Points.Clear();
        comparisonChart.Series["Closed"].Points.Clear();
        comparisonChart.Series["Open"].Points.Clear();


        comparisonChart.Titles[0].Text = "12 Months Statistics (" + GetYearString(DateTime.Now.AddMonths(-1), 12) + ")";

        comparisonChart.ChartAreas["caScoreCard"].AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 11);

        closedData = ScoreCardReports.GetNumberOfClosedTickets();
        openData = ScoreCardReports.GetNumberOfOpenTickets();
        newData = ScoreCardReports.GetNumberOfNewTickets();

        foreach (int value in openData)
        {
            comparisonChart.Series["Open"].Points.Add(value);
        }

        comparisonChart.Series["Open"].LegendText = "Open";

        int newTotal = 0;
        foreach (int value in newData)
        {
            comparisonChart.Series["New"].Points.Add(value);
            newTotal += value;
        }
        comparisonChart.Series["New"].LegendText = "New";

        int closedTotal = 0;
        foreach (int value in closedData)
        {
            comparisonChart.Series["Closed"].Points.Add(value);
            closedTotal += value;
        }
        comparisonChart.Series["Closed"].LegendText = "Closed";


        CustomLabel customLabel = new CustomLabel();
        string[] months = new string[] {"JAN", "FEB", "MAR", "APR",
                "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"};

        System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();

        int selectedYear;
        int selectedMonth = DateTime.Today.Month - 1;
        if (selectedMonth < 1)
            selectedMonth = 12;

        int currentMonth = 0;

        if (selectedMonth == 12)
        {
            selectedYear = DateTime.Today.Year -1;
            currentMonth = 1;
        }
        else
        {
            selectedYear = DateTime.Today.Year - 1;
            currentMonth = selectedMonth + 1;
        }


        double postion = 0.5;

        int postionModifier = 1;
        do
        {

            customLabel.Text = mfi.GetMonthName(currentMonth).ToString() + @"-" + selectedYear.ToString();
            customLabel.FromPosition = postion;
            customLabel.ToPosition = postion + postionModifier;
            postion += postionModifier;

            currentMonth++;
            if (currentMonth == 13)// Roll over the month
            {
                currentMonth = 1; //Jan
                selectedYear = selectedYear + 1;// Increase the year we are now in the previous year.
            }

            comparisonChart.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);

            customLabel = new CustomLabel();

        } while (currentMonth != selectedMonth);

        customLabel.Text = mfi.GetMonthName(currentMonth).ToString() + @"-" + selectedYear.ToString();
        customLabel.FromPosition = postion;
        customLabel.ToPosition = postion + postionModifier;

        comparisonChart.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);

        customLabel = new CustomLabel();
    }


    public void CreateCustomerIssueChart()
    {
        List<int> returnedData = new List<int>();
        CustomerIssuesChart.Titles[0].Text = "Customer Issues (" + GetYearString(DateTime.Now, 12) + ")";
        returnedData = ScoreCardReports.GetNumberOfCustomer();

        CustomerIssuesChart.ChartAreas["caScoreCard"].AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 11);

        int customerIssueCount = 0;
        foreach (int value in returnedData)
        {
            CustomerIssuesChart.Series["sData"].Points.Add(value);
            customerIssueCount += value;
        }

        CustomerIssuesChart.Series["sData"].LegendText = "Customer Issues(" + customerIssueCount + ")";


        CustomLabel customLabel = new CustomLabel();
        string[] months = new string[] {"JAN", "FEB", "MAR", "APR",
                "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"};

        int selectedYear;
        int selectedMonth = DateTime.Today.Month;
        int currentMonth = 0;

        if (selectedMonth == 12)
        {
            selectedYear = DateTime.Today.Year;
            currentMonth = 1;
        }
        else
        {
            selectedYear = DateTime.Today.Year - 1;
            currentMonth = selectedMonth + 1;
        }


        double postion = 0.5;

        int postionModifier = 1;
        do
        {

            customLabel.Text = (currentMonth).ToString() + @"-" + selectedYear.ToString();
            customLabel.FromPosition = postion;
            customLabel.ToPosition = postion + postionModifier;
            postion += postionModifier;

            currentMonth++;
            if (currentMonth == 13)// Roll over the month
            {
                currentMonth = 1; //Jan
                selectedYear = selectedYear + 1;// Increase the year we are now in the previous year.
            }

            CustomerIssuesChart.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);

            customLabel = new CustomLabel();

        } while (currentMonth != selectedMonth);

        customLabel.Text = (currentMonth).ToString() + @"-" + selectedYear.ToString();
        customLabel.FromPosition = postion;
        customLabel.ToPosition = postion + postionModifier;

        CustomerIssuesChart.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);

        customLabel = new CustomLabel();

        Series trendLine = createTrendLine(CustomerIssuesChart.Series["sData"]);
        trendLine.ChartType = SeriesChartType.Line;

        //CustomerIssuesChart.Series.Add(trendLine);
    }

    public void CreateRepeatIssueChart()
    {
        List<int> returnedData = new List<int>();
        RepeatIssuesChart.Titles[0].Text = "Repeat Issues ("  + GetYearString(DateTime.Now, 12)  +")";
        returnedData = ScoreCardReports.GetNumberOfRepeat();

        RepeatIssuesChart.ChartAreas["caScoreCard"].AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 11);

        int repeateCount = 0;
        foreach (int value in returnedData)
        {
            RepeatIssuesChart.Series["sData"].Points.Add(value);
            repeateCount += value;
        }
        RepeatIssuesChart.Series["sData"].LegendText = "Repeat Issues(" + repeateCount + ")";

        CustomLabel customLabel = new CustomLabel();
        string[] months = new string[] {"JAN", "FEB", "MAR", "APR",
                "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"};

        int selectedYear;
        int selectedMonth = DateTime.Today.Month;
        int currentMonth = 0;

        if (selectedMonth == 12)
        {
            selectedYear = DateTime.Today.Year;
            currentMonth = 1;
        }
        else
        {
            selectedYear = DateTime.Today.Year - 1;
            currentMonth = selectedMonth + 1;
        }


        double postion = 0.5;

        int postionModifier = 1;
        do
        {

            customLabel.Text = (currentMonth).ToString() + @"-" + selectedYear.ToString();
            customLabel.FromPosition = postion;
            customLabel.ToPosition = postion + postionModifier;
            postion += postionModifier;

            currentMonth++;
            if (currentMonth == 13)// Roll over the month
            {
                currentMonth = 1; //Jan
                selectedYear = selectedYear + 1;// Increase the year we are now in the previous year.
            }

            RepeatIssuesChart.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);

            customLabel = new CustomLabel();

        } while (currentMonth != selectedMonth);

        customLabel.Text = (currentMonth).ToString() + @"-" + selectedYear.ToString();
        customLabel.FromPosition = postion;
        customLabel.ToPosition = postion + postionModifier;

        RepeatIssuesChart.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);

        customLabel = new CustomLabel();

        Series trendLine = createTrendLine(RepeatIssuesChart.Series["sData"]);
        trendLine.ChartType = SeriesChartType.Line;

        //RepeatIssuesChart.Series.Add(trendLine);

    }


    public void CreateASNIssueChart()
    {
        List<int> returnedData = new List<int>();
        ASNIssueChart.Titles[0].Text = "ASN Issues (" + GetYearString(DateTime.Now,12) + ")";
        returnedData = ScoreCardReports.GetNumberOfASNIssues();

        ASNIssueChart.ChartAreas["caScoreCard"].AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 11);
        int asnCount = 0;
        foreach (int value in returnedData)
        {
            ASNIssueChart.Series["sData"].Points.Add(value);
            asnCount += value;
        }
        ASNIssueChart.Series["sData"].LegendText = "Asn Issues(" + asnCount + ")";

        CustomLabel customLabel = new CustomLabel();
        //string[] months = new string[] {"JAN", "FEB", "MAR", "APR",
        //        "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"};

        int selectedYear;
        int selectedMonth =  DateTime.Today.Month;
        int currentMonth = 0;

        if (selectedMonth == 12)
        {
            selectedYear = DateTime.Today.Year;
            currentMonth = 1;
        }
        else
        {
            selectedYear = DateTime.Today.Year - 1;
            currentMonth = selectedMonth+1;
        }

        
        double postion = 0.5;

        int postionModifier = 1;
        do
        {

            customLabel.Text = (currentMonth).ToString() + @"-" + selectedYear.ToString();
            customLabel.FromPosition = postion;
            customLabel.ToPosition = postion + postionModifier;
            postion += postionModifier;

            currentMonth++;
            if (currentMonth == 13)// Roll over the month
            {
                currentMonth = 1; //Jan
                selectedYear = selectedYear + 1;// Decrease the year we are now in the previous year.
            }

            ASNIssueChart.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);

            customLabel = new CustomLabel();

        } while (currentMonth != selectedMonth);

        customLabel.Text = (currentMonth).ToString() + @"-" + selectedYear.ToString();
        customLabel.FromPosition = postion;
        customLabel.ToPosition = postion + postionModifier;

        ASNIssueChart.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);

        customLabel = new CustomLabel();

        Series trendLine = createTrendLine(ASNIssueChart.Series["sData"]);
        trendLine.ChartType = SeriesChartType.Line;

        //ASNIssueChart.Series.Add(trendLine);

    }

    public Series createTrendLine(Series dataseries)
    {
        Series TrendLine = new Series();

        double total = 0;

        for (int i = 1; i < dataseries.Points.Count; i++)
        {
            total += dataseries.Points[i-1].YValues[0];
            TrendLine.Points.AddY(total / i);
        }
        return TrendLine;
        
    }

    public void CreateRealTimeChart()
    {
        List<int> returnedData = new List<int>();

        System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
        RealTimeChart.Titles[0].Text = "Current Month (" + mfi.GetMonthName(DateTime.Now.Month).ToString() + ")";

        returnedData = ScoreCardReports.GetRealTime();

        RealTimeChart.Series["New"].Points.Add( returnedData[0]);
        RealTimeChart.Series["Closed"].Points.Add( returnedData[1]);
        RealTimeChart.Series["Open"].Points.Add( returnedData[2]);
        RealTimeChart.Series["Unassigned"].Points.Add(returnedData[3]);
        RealTimeChart.Series["Averg"].Points.Add(returnedData[4]);


        RealTimeChart.ChartAreas["caScoreCard"].AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 11);
        CustomLabel customLabel = new CustomLabel();
        string[] months = new string[] {"JAN", "FEB", "MAR", "APR",
                "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"};


        customLabel.Text = months[(DateTime.Now.Month -1)];
        customLabel.FromPosition = 0.5;
        customLabel.ToPosition = 1.5;

        RealTimeChart.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);
        RealTimeChart.Series["Open"].LegendText = "Running Open";

        RealTimeChart.Series["Averg"].LegendText = "Average Days Open";
    }



    public void CreateSixMonthTrendChart()
    {
        List<double> newData = new List<double>();
        List<double> closedData = new List<double>();
        List<double> openData = new List<double>();

        SixMonthTrendChart.Series["New"].Points.Clear();
        SixMonthTrendChart.Series["Closed"].Points.Clear();
        SixMonthTrendChart.Series["Open"].Points.Clear();    


        SixMonthTrendChart.Titles[0].Text = "6 Month Trending";
        SixMonthTrendChart.ChartAreas["caScoreCard"].AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 11);

        closedData = ScoreCardReports.GetSixMonthTrendClosed();
        openData = ScoreCardReports.GetSixMonthTrendOpen();
        newData = ScoreCardReports.GetSixMonthTrendNew();


        foreach (int value in openData)
        {
            SixMonthTrendChart.Series["Open"].Points.Add(value);
        }

        SixMonthTrendChart.Series["Open"].LegendText = "Open";


        foreach (int value in newData)
        {
            SixMonthTrendChart.Series["New"].Points.Add(value);
        }
        SixMonthTrendChart.Series["New"].LegendText = "New";

        foreach (int value in closedData)
        {
            SixMonthTrendChart.Series["Closed"].Points.Add(value);
        }
        SixMonthTrendChart.Series["Closed"].LegendText = "Closed";

        CustomLabel customLabel = new CustomLabel();

        System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
       
        DateTime d = new DateTime(2013, 01, 01);


        int selectedYear;
        int selectedMonth =  DateTime.Today.Month;
        int currentMonth = DateTime.Parse( DateTime.Today.AddMonths(-6).ToString()).Month;

        if (selectedMonth == 12)
        {
            selectedYear = DateTime.Today.Year;
        }
        else
        {
            selectedYear = DateTime.Parse(DateTime.Today.AddMonths(-6).ToString()).Year ;
        }


        double postion = 0.5;

        int postionModifier = 1;
        do
        {

            customLabel.Text = mfi.GetMonthName(currentMonth) + @"-" + selectedYear.ToString();
            customLabel.FromPosition = postion;
            customLabel.ToPosition = postion + postionModifier;
            postion += postionModifier;

            currentMonth++;
            if (currentMonth == 13)// Roll over the month
            {
                currentMonth = 1; //Jan
                selectedYear = selectedYear + 1;// Increase the year we are now in the previous year.
            }

            SixMonthTrendChart.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);

            customLabel = new CustomLabel();

        } while (currentMonth != selectedMonth);

    }


    public void CreateTicketHealthTrendChart()
    {

        List<double> averageOpenData = new List<double>();
        List<double> averageCloseData = new List<double>();


        TicketHealthChart.Series["AverageOpen"].Points.Clear();
        TicketHealthChart.Series["AvergToClose"].Points.Clear();


        TicketHealthChart.Titles[0].Text = "Ticket Health";
        TicketHealthChart.ChartAreas["caScoreCard"].AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 11);

        averageCloseData = ScoreCardReports.GetAverageCloseTime();     
        averageOpenData = ScoreCardReports.GetAverageOpenTime();

        foreach (int value in averageOpenData)
        {
            TicketHealthChart.Series["AverageOpen"].Points.Add(value);
        }
        TicketHealthChart.Series["AverageOpen"].LegendText = "Average Day's Open";


        foreach (int value in averageCloseData)
        {
            TicketHealthChart.Series["AvergToClose"].Points.Add(value);
        }
        TicketHealthChart.Series["AvergToClose"].LegendText = "Average Day's To Close";



        CustomLabel customLabel = new CustomLabel(); System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();

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

        int postionModifier = 1;
        do
        {

            customLabel.Text = mfi.GetMonthName(currentMonth).ToString() + @"-" + selectedYear.ToString();
            customLabel.FromPosition = postion;
            customLabel.ToPosition = postion + postionModifier;
            postion += postionModifier;

            currentMonth++;
            if (currentMonth == 13)// Roll over the month
            {
                currentMonth = 1; //Jan
                selectedYear = selectedYear + 1;// Increase the year we are now in the previous year.
            }

            TicketHealthChart.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);

            customLabel = new CustomLabel();

        } while (currentMonth != selectedMonth);

        customLabel.Text = mfi.GetMonthName(currentMonth).ToString() + @"-" + selectedYear.ToString();
        customLabel.FromPosition = postion;
        customLabel.ToPosition = postion + postionModifier;

        TicketHealthChart.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);

        customLabel = new CustomLabel();

    }

    public void CreateHistoricalTicketStats()
    {
        List<int> returnedData = new List<int>();

        returnedData = ScoreCardReports.GetTotalTickets();//data gets returned as @Current,@OneToSeven, @SevenToThirty, @ThirtyToSixty,@SixtyToNinety, @OlderThenNinety

        TotalTicketsChart.Titles[0].Text = "Current Open Ticket Aging (" + returnedData.Sum()+ ")";

        TotalTicketsChart.ChartAreas["caScoreCard"].AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 11);
        
        float total = 0;

        foreach(int value in returnedData)
        {
            total += value;
        }

        TotalTicketsChart.Series["sData"].Points.Add(Math.Round(((returnedData[0] / total) * 100), 0));
        TotalTicketsChart.Series["sData"].Points[0].LegendText = "< Day (" + Math.Round(((returnedData[0] / total) * 100), 0) + "%)";
        TotalTicketsChart.Series["sData"].Points[0].Color = Color.Green;
        TotalTicketsChart.Series["sData"].Points[0].Label = Math.Round(((returnedData[0] / total) * 100),0) + "%";


        TotalTicketsChart.Series["sData"].Points.Add(Math.Round(((returnedData[1] / total) * 100), 0));
        TotalTicketsChart.Series["sData"].Points[1].LegendText = "< Week (" + Math.Round(((returnedData[1] / total) * 100), 0) + "%)";
        TotalTicketsChart.Series["sData"].Points[1].Color = Color.DeepSkyBlue;
        TotalTicketsChart.Series["sData"].Points[1].Label = Math.Round(((returnedData[1] / total) * 100),0) + "%";

        TotalTicketsChart.Series["sData"].Points.Add(Math.Round(((returnedData[2] / total) * 100), 0));
        TotalTicketsChart.Series["sData"].Points[2].LegendText = "< Month (" + Math.Round(((returnedData[2] / total) * 100), 0) + "%)";
        TotalTicketsChart.Series["sData"].Points[2].Color = Color.DodgerBlue;
        TotalTicketsChart.Series["sData"].Points[2].Label = Math.Round(((returnedData[2] / total) * 100),0) + "%";

        TotalTicketsChart.Series["sData"].Points.Add(Math.Round(((returnedData[3] / total) * 100), 0));
        TotalTicketsChart.Series["sData"].Points[3].LegendText = "< 60 Days (" + Math.Round(((returnedData[3] / total) * 100), 0) + "%)";
        TotalTicketsChart.Series["sData"].Points[3].Color = Color.Orange;
        TotalTicketsChart.Series["sData"].Points[3].Label = Math.Round(((returnedData[3] / total) * 100),0) + "%";

        TotalTicketsChart.Series["sData"].Points.Add(Math.Round(((returnedData[4] / total) * 100), 0));
        TotalTicketsChart.Series["sData"].Points[4].LegendText = "< 90 Days (" + Math.Round(((returnedData[4] / total) * 100),0) + "%)";
        TotalTicketsChart.Series["sData"].Points[4].Color = Color.Red;
        TotalTicketsChart.Series["sData"].Points[4].Label = Math.Round(((returnedData[4] / total) * 100),0) + "%";

        TotalTicketsChart.Series["sData"].Points.Add(Math.Round(((returnedData[5] / total) * 100), 0));
        TotalTicketsChart.Series["sData"].Points[5].LegendText = "> 90 Days (" + Math.Round(((returnedData[5] / total) * 100), 0) + "%)";
        TotalTicketsChart.Series["sData"].Points[5].Color = Color.Chocolate;
        TotalTicketsChart.Series["sData"].Points[5].Label = Math.Round(((returnedData[5] / total) * 100), 0) + "%";

        TotalTicketsChart.DataBind();
    }

    #endregion

    ///// <summary>
    ///// Creates Y axis for the specified series.
    ///// </summary>
    ///// <param name="chart">Chart control.</param>
    ///// <param name="area">Original chart area.</param>
    ///// <param name="series">Series.</param>
    ///// <param name="axisOffset">New Y axis offset in relative coordinates.</param>
    ///// <param name="labelsSize">Extra space for new Y axis labels in relative coordinates.</param>
    //public void CreateYAxis(Chart chart, ChartArea area, Series series, float axisOffset, float labelsSize)
    //{
    //    // Create new chart area for original series
    //    ChartArea areaSeries = chart.ChartAreas.Add("ChartArea_" + series.Name);
    //    areaSeries.BackColor = Color.Transparent;
    //    areaSeries.BorderColor = Color.Transparent;
    //    areaSeries.Position.FromRectangleF(area.Position.ToRectangleF());
    //    areaSeries.InnerPlotPosition.FromRectangleF(area.InnerPlotPosition.ToRectangleF());
    //    areaSeries.AxisX.MajorGrid.Enabled = false;
    //    areaSeries.AxisX.MajorTickMark.Enabled = false;
    //    areaSeries.AxisX.LabelStyle.Enabled = false;
    //    areaSeries.AxisY.MajorGrid.Enabled = false;
    //    areaSeries.AxisY.MajorTickMark.Enabled = false;
    //    areaSeries.AxisY.LabelStyle.Enabled = false;
    //    areaSeries.AxisY.IsStartedFromZero = area.AxisY.IsStartedFromZero;


    //    series.ChartArea = areaSeries.Name;

    //    // Create new chart area for axis
    //    ChartArea areaAxis = chart.ChartAreas.Add("AxisY_" + series.ChartArea);
    //    areaAxis.BackColor = Color.Transparent;
    //    areaAxis.BorderColor = Color.Transparent;
    //    areaAxis.Position.FromRectangleF(chart.ChartAreas[series.ChartArea].Position.ToRectangleF());
    //    areaAxis.InnerPlotPosition.FromRectangleF(chart.ChartAreas[series.ChartArea].InnerPlotPosition.ToRectangleF());

    //    // Create a copy of specified series
    //    Series seriesCopy = chart.Series.Add(series.Name + "_Copy");
    //    seriesCopy.ChartType = series.ChartType;
    //    foreach (DataPoint point in series.Points)
    //    {
    //        seriesCopy.Points.AddXY(point.XValue, point.YValues[0]);
    //    }

    //    // Hide copied series
    //    seriesCopy.IsVisibleInLegend = false;
    //    seriesCopy.Color = Color.Transparent;
    //    seriesCopy.BorderColor = Color.Transparent;
    //    seriesCopy.ChartArea = areaAxis.Name;

    //    // Disable drid lines & tickmarks
    //    areaAxis.AxisX.LineWidth = 0;
    //    areaAxis.AxisX.MajorGrid.Enabled = false;
    //    areaAxis.AxisX.MajorTickMark.Enabled = false;
    //    areaAxis.AxisX.LabelStyle.Enabled = false;
    //    areaAxis.AxisY.MajorGrid.Enabled = false;
    //    areaAxis.AxisY.IsStartedFromZero = area.AxisY.IsStartedFromZero;
    //    areaAxis.AxisY.LabelStyle.Font = area.AxisY.LabelStyle.Font;

    //    //// Adjust area position
    //    //areaAxis.Position.X -= axisOffset;
    //    //areaAxis.InnerPlotPosition.X += labelsSize;

    //}

    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);


        TableRow dummie = new TableRow();

        #region Saving Charts and Image Paths
        string comparisonChartImage;
        comparisonChartImage = FileLocation.FilePath + "comparisonChartImage.jpg";
        comparisonChart.SaveImage(comparisonChartImage);

        string SixMonthTrendChartImage;
        SixMonthTrendChartImage = FileLocation.FilePath + "SixMonthTrendChartImage.jpg";
        SixMonthTrendChart.SaveImage(SixMonthTrendChartImage);

        string TicketHealthChartImage;
        TicketHealthChartImage = FileLocation.FilePath + "TicketHealthChartImage.jpg";
        TicketHealthChart.SaveImage(TicketHealthChartImage);

        string RepeatIssuesChartImage;
        RepeatIssuesChartImage = FileLocation.FilePath + "RepeatIssuesChartImage.jpg";
        RepeatIssuesChart.SaveImage(RepeatIssuesChartImage);

        string CustomerIssuesChartImage;
        CustomerIssuesChartImage = FileLocation.FilePath + "CustomerIssuesChartImage.jpg";
        CustomerIssuesChart.SaveImage(CustomerIssuesChartImage);

        string unplannedTicketsChartImage;
        unplannedTicketsChartImage = FileLocation.FilePath + "unplannedTicketsChartImage.jpg";
        unplannedTicketsChart.SaveImage(unplannedTicketsChartImage);

        string ASNIssueChartImage;
        ASNIssueChartImage = FileLocation.FilePath + "ASNIssueChartImage.jpg";
        ASNIssueChart.SaveImage(ASNIssueChartImage);

        string RealTimeChartImage;
        RealTimeChartImage = FileLocation.FilePath + "RealTimeChartImage.jpg";
        RealTimeChart.SaveImage(RealTimeChartImage);

        string HistoricleTotalsImage;
        HistoricleTotalsImage = FileLocation.FilePath + "HistoricleTotalsImage.jpg";
        TotalTicketsChart.SaveImage(HistoricleTotalsImage);


        #endregion

        Table tbl = new Table();
        tbl.Width = Unit.Pixel(100);



        //Comparison Row
        TableRow comparisonRow = new TableRow();
        TableCell cell = new TableCell();
        TableCell cell12 = new TableCell();
        cell.Text = "<img src='" + comparisonChartImage + @"' \>";
        comparisonRow.Cells.Add(cell);
        comparisonRow.Cells.Add(cell12);
        tbl.Rows.Add(comparisonRow);

        for (int count = 0; count <= 20; count++)
        {
            dummie = new TableRow();
            tbl.Rows.Add(dummie);
        }

        //Six Month Trend Chart
        TableRow sixMonthTrendRow = new TableRow();
        TableCell cell1 = new TableCell();
        TableCell cell13 = new TableCell();
        cell1.Text = "<img src='" + SixMonthTrendChartImage + @"' \>";
        sixMonthTrendRow.Cells.Add(cell1);
        sixMonthTrendRow.Cells.Add(cell13);
        tbl.Rows.Add(sixMonthTrendRow);

        for (int count = 0; count <= 20; count++)
        {
            dummie = new TableRow();
            tbl.Rows.Add(dummie);
        }


        //Ticket Health Chart
        TableRow ticketHealthRow = new TableRow();
        TableCell cellTicketHealth = new TableCell();
        TableCell cellTicketHealth2 = new TableCell();
        cellTicketHealth.Text = "<img src='" + SixMonthTrendChartImage + @"' \>";
        ticketHealthRow.Cells.Add(cellTicketHealth);
        ticketHealthRow.Cells.Add(cellTicketHealth2);
        tbl.Rows.Add(ticketHealthRow);

        for (int count = 0; count <= 20; count++)
        {
            dummie = new TableRow();
            tbl.Rows.Add(dummie);
        }

        //The rest of the charts have to be 2 per line to mimic the look of the webpage
        /***********
        * LINE TWO
        * *********/
        TableRow LineTwoRow = new TableRow();
        //Repeat Issues Chart
        TableCell repeatIssueCell = new TableCell();
        repeatIssueCell.Text = "<img src='" + RepeatIssuesChartImage + @"' \>";
        repeatIssueCell.ColumnSpan = 8;
        LineTwoRow.Cells.Add(repeatIssueCell);

        //Customer Issues
        TableCell CustomerIssuesCell = new TableCell();
        CustomerIssuesCell.Text = "<img src='" + CustomerIssuesChartImage + @"' \>";
        LineTwoRow.Cells.Add(CustomerIssuesCell);

        tbl.Rows.Add(LineTwoRow);

        for (int count = 0; count <= 20; count++)
        {
            dummie = new TableRow();
            tbl.Rows.Add(dummie);
        }

        ///***********
        //* LINE THREE
        //* *********/
        TableRow LineThreeRow = new TableRow();
        //UnPlanned Issues Chart
        TableCell unPlannedCell = new TableCell();
        unPlannedCell.ColumnSpan = 8;
        unPlannedCell.Text = "<img src='" + unplannedTicketsChartImage + @"' \>";
        LineThreeRow.Cells.Add(unPlannedCell);


        //ASN Issues
        TableCell asnIssuesCell = new TableCell();
        asnIssuesCell.Text = "<img src='" + ASNIssueChartImage + @"' \>";
        LineThreeRow.Cells.Add(asnIssuesCell);

        tbl.Rows.Add(LineThreeRow);
        for (int count = 0; count <= 20; count++)
        {
            dummie = new TableRow();
            tbl.Rows.Add(dummie);
        }

        ///***********
        //* LINE FOUR
        //* *********/
        TableRow LineFourRow = new TableRow();
        //Real Time Issues Chart
        TableCell realTimeCell = new TableCell();
        realTimeCell.ColumnSpan = 8;
        realTimeCell.Text = "<img src='" + RealTimeChartImage + @"' \>";
        LineFourRow.Cells.Add(realTimeCell);


        //Current Open Ticket Aging  Issues Chart
        TableCell historyCell = new TableCell();
        historyCell.ColumnSpan = 8;
        historyCell.Text = "<img src='" + HistoricleTotalsImage + @"' \>";
        LineFourRow.Cells.Add(historyCell);

        tbl.Rows.Add(LineFourRow);


        
        

        Response.Clear();
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment; filename=IT-Ticket-Stats.xls;");

        DataList1.RenderControl(hw);

        tbl.RenderControl(hw);

        Response.Write(sw.ToString());
        Response.End();

    }


    private string GetYearString(DateTime dateToCheck,int interval)
    {
        string dateField ; 


        DateTime twelveMonthsPrevious = dateToCheck.AddMonths(-11);

        if (dateToCheck.Year == twelveMonthsPrevious.Year)
            dateField = dateToCheck.Year.ToString(); 
        else
            dateField = dateToCheck.Year.ToString() + @"\" + twelveMonthsPrevious.Year.ToString() ;
        
        return dateField;
    }
}