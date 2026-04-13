using System;
using System.Collections.Generic;
using System.Text;

class ReportBuilder
{
    private DatabaseManager _db;
    private string _sql;
    private string _title;
    private string[] _headers;
    private int[] _widths;
    private bool _numbered;
    private string _footer;

    public ReportBuilder(DatabaseManager db)
    {
        _db = db;
        _headers = new string[0];
        _widths = new int[0];
        _title = "";
        _footer = "";
    }

    public ReportBuilder Query(string sql)
    {
        _sql = sql;
        return this;
    }

    public ReportBuilder Title(string title)
    {
        _title = title;
        return this;
    }

    public ReportBuilder Header(params string[] headers)
    {
        _headers = headers;
        return this;
    }

    public ReportBuilder ColumnWidths(params int[] widths)
    {
        _widths = widths;
        return this;
    }

    public ReportBuilder Numbered()
    {
        _numbered = true;
        return this;
    }

    public ReportBuilder Footer(string footer)
    {
        _footer = footer;
        return this;
    }

    public void Print()
    {
        var data = _db.ExecuteQuery(_sql);

        Console.WriteLine("\n" + _title + "\n");

        string[] headers = _headers.Length > 0 ? _headers : data.cols;
        int n = headers.Length;

        int[] widths = _widths.Length == n ? _widths : new int[n];
        for (int i = 0; i < n; i++)
            if (widths.Length > 0) { }
        if (_widths.Length == 0)
        {
            widths = new int[n];
            for (int i = 0; i < n; i++) widths[i] = 20;
        }

        if (_numbered)
            Console.Write("№".PadRight(5));

        for (int i = 0; i < n; i++)
            Console.Write(headers[i].PadRight(widths[i]));

        Console.WriteLine();
        Console.WriteLine(new string('-', 50));

        for (int i = 0; i < data.rows.Count; i++)
        {
            if (_numbered)
                Console.Write((i + 1).ToString().PadRight(5));

            for (int j = 0; j < n; j++)
                Console.Write(data.rows[i][j].PadRight(widths[j]));

            Console.WriteLine();
        }

        if (_footer != "")
            Console.WriteLine("\n" + _footer + ": " + data.rows.Count);
    }
}