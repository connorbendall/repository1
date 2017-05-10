// Decompiled with JetBrains decompiler
// Type: RFQLog.Helpers.DateTimeExtensions
// Assembly: RFQLog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 25B8AF27-D382-432E-8A3A-9BE2F231470C
// Assembly location: C:\Users\ckurtz\Documents\Projects\RFQLog\bin\RFQLog.dll

using System;
using System.Globalization;

namespace RFQLog.Helpers
{
  internal static class DateTimeExtensions
  {
    private static GregorianCalendar _gc = new GregorianCalendar();

    public static int GetWeekOfMonth(this DateTime time)
    {
      DateTime time1 = new DateTime(time.Year, time.Month, 1);
      return time.GetWeekOfYear() - time1.GetWeekOfYear() + 1;
    }

    private static int GetWeekOfYear(this DateTime time)
    {
      return DateTimeExtensions._gc.GetWeekOfYear(time, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
    }

    public static int GetIso8601WeekOfYear(DateTime time)
    {
      DayOfWeek dayOfWeek = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
      if (dayOfWeek >= DayOfWeek.Monday && dayOfWeek <= DayOfWeek.Wednesday)
        time = time.AddDays(3.0);
      return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
    }

    public static DateTime FirstDateOfWeek(int year, int weekOfYear, CultureInfo ci)
    {
      DateTime time = new DateTime(year, 1, 1);
      int firstDayOfWeekOne = DateTimeExtensions.GetFirstDayOfWeekOne(year);
      DateTime dateTime = time.AddDays((double) (firstDayOfWeekOne - 1));
      int weekOfYear1 = ci.Calendar.GetWeekOfYear(time, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
      if ((weekOfYear1 <= 1 || weekOfYear1 >= 52) && firstDayOfWeekOne >= -3)
        --weekOfYear;
      return dateTime.AddDays((double) (weekOfYear * 7));
    }

    public static int GetFirstDayOfWeekOne(int year)
    {
      int day = 0;
      int num;
      if (DateTimeExtensions.GetIso8601WeekOfYear(new DateTime(year, 1, 1)) == 1)
      {
        int iso8601WeekOfYear;
        do
        {
          ++day;
          iso8601WeekOfYear = DateTimeExtensions.GetIso8601WeekOfYear(new DateTime(year, 1, day));
        }
        while (iso8601WeekOfYear == 1);
        num = !DateTime.IsLeapYear(year) ? (iso8601WeekOfYear != 2 || day != 8 ? 365 - (7 - day) : 1) : 366 - (7 - day);
      }
      else
      {
        do
        {
          ++day;
        }
        while (DateTimeExtensions.GetIso8601WeekOfYear(new DateTime(year, 1, day)) > 1);
        num = day;
      }
      return num;
    }

    public static DateTime GetSixWeekRollBack_DateFrom_Inclusive(DateTime date)
    {
      int num = DateTimeExtensions.FirstDayOf_FirstWeekInMonth(date).DayOfYear - 35 - 1;
      return new DateTime(date.Year, 1, 1).AddDays((double) num);
    }

    public static DateTime FirstDayOf_FirstWeekInMonth(DateTime date)
    {
      DayOfWeek dayOfWeek = date.DayOfWeek;
      int day = 1;
      DateTime dateTime = date;
      while (dayOfWeek != DayOfWeek.Monday)
      {
        dateTime = new DateTime(date.Year, date.Month, day);
        dayOfWeek = dateTime.DayOfWeek;
        ++day;
      }
      return dateTime;
    }

    public static string GetMonthNameFromNumber(int monthNumber)
    {
      return new string[12]
      {
        "January",
        "February",
        "March ",
        "Apirl",
        "May",
        "June",
        "July",
        "August",
        "September",
        "October",
        "November",
        "December"
      }[monthNumber];
    }

    public static string GetMonthNameFromNumber(DateTime date)
    {
      return new string[12]
      {
        "January",
        "February",
        "March ",
        "Apirl",
        "May",
        "June",
        "July",
        "August",
        "September",
        "October",
        "November",
        "December"
      }[date.Month];
    }
  }
}
