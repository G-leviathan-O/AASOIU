using System.Text;

class ReportBuilder
{
    private DatabaseManager _db;
    private string _sql = "";
    private string _title = "";
    private string[] _headers = Array.Empty<string>();
    private int[] _widths = Array.Empty<int>();

    public ReportBuilder(DatabaseManager db)
    {
        _db = db;
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

    public string Build()
    {
        var (cols, rows) = _db.ExecuteQuery(_sql);
        var sb = new StringBuilder();

        sb.AppendLine($"\n=== {_title} ===");

        var headers = _headers.Length > 0 ? _headers : cols;
        int n = headers.Length;

        int[] widths = _widths.Length == n ? _widths : Enumerable.Repeat(20, n).ToArray();

        for (int i = 0; i < n; i++)
            sb.Append(headers[i].PadRight(widths[i]));
        sb.AppendLine();

        sb.AppendLine(new string('─', widths.Sum()));

        foreach (var row in rows)
        {
            for (int i = 0; i < n; i++)
                sb.Append(row[i].PadRight(widths[i]));
            sb.AppendLine();
        }

        return sb.ToString();
    }

    public void Print() => Console.WriteLine(Build());

    public void SaveToFile(string path)
    {
        File.WriteAllText(path, Build());
        Console.WriteLine($"Saved to {path}");
    }
}