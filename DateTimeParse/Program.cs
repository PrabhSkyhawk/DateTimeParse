using System;
using System.Globalization;
using System.Net.NetworkInformation;
class Program
{
    public Program()
    {
        DateTimeParseTryCatch();
        DateTimeParseIfElse();
        DateTimeParseExact();
        DateTimeFormatException();
        DateTimeTryParse();
        DateTimeWithCultureInfo();
        DateTimeParseLastModifier();
    }
    static void Main(string[] args)
    {
        new Program();
    }
    void DateTimeParseTryCatch()
    {
        string dateString = "07/18/2024 10:00";
        try
        {
            DateTime parsedDate = DateTime.Parse(dateString);
            Console.WriteLine("Parsed DateTime: " + parsedDate);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Error parsing DateTime: " + ex.Message);
        }
    }
    void DateTimeParseIfElse()
    {
        string dt = "07/18/2024 10:00";

        DateTime parsedDate;
        if (DateTime.TryParse(dt, out parsedDate))
        {
            Console.WriteLine("Parsed DateTime: " + parsedDate);
        }
        else
        {
            Console.WriteLine("Failed to parse DateTime.");
        }
    }
    void DateTimeParseExact()
    {
        var ds = "Thu 18,2024";
        var dt = DateTime.ParseExact(ds, "ddd dd,yyyy", CultureInfo.CurrentCulture);
        Console.WriteLine(dt);
        var ds2 = "10-22-2015";
        var dt2 = DateTime.ParseExact(ds2, "MM-dd-yyyy", CultureInfo.CurrentCulture);
        Console.WriteLine(dt2);
    }
    void DateTimeFormatException()
    {
        var ds = "2024-07-18 12:30:45";
        var stringformat = "MM/dd/yyyy  HH:mm:ss";
        try
        {
            DateTime parsedate = DateTime.ParseExact(ds, stringformat, CultureInfo.InvariantCulture);
            Console.WriteLine(parsedate);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("error parsing datetime:" + ex.Message);
        }
    }
    void DateTimeTryParse()
    {
        string dateString = "2024-07-18";
        DateTime parsedDate;

        if (DateTime.TryParse(dateString, out parsedDate))
        {
            Console.WriteLine("Parsed DateTime: " + parsedDate);
        }
        else
        {
            Console.WriteLine("Unable to parse the date string.");
        }
    }
    void DateTimeWithCultureInfo()
    {
        string dateString = "18-Jul-2024";
        CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");

        try
        {
            DateTime parsedDate = DateTime.Parse(dateString, culture);
            Console.WriteLine("Parsed DateTime: " + parsedDate);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Error parsing DateTime: " + ex.Message);
        }
    }
    void DateTimeParseLastModifier()
    {
        string lastModifiedHeader = "Wed, 18 Jul 2024 10:00:00 GMT";
        string[] formats = { "ddd, dd MMM yyyy HH:mm:ss 'GMT'", "ddd, dd MMM yyyy HH:mm:ss GMT", "ddd, dd-MMM-yy HH:mm:ss GMT" };

        CultureInfo provider = CultureInfo.InvariantCulture;
        if (DateTime.TryParseExact(lastModifiedHeader, formats, provider, DateTimeStyles.None, out DateTime parsedDate))
        {
            Console.WriteLine("Parsed Last-Modified Date: " + parsedDate.ToString("yyyy-MM-dd HH:mm:ss"));
        }
        else
        {
            Console.WriteLine("Unable to parse Last-Modified date.");
        }
    }
}



    