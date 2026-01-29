using System.Text;

string path = Console.ReadLine()!;

static bool IsLegal(string path)
{
    foreach (string line in File.ReadLines(path))
    {
        if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
        {
            continue;
        }
        
        string[] cell = line.Split(';');
        
        if (cell.Length != 3 || string.IsNullOrWhiteSpace(cell[0]) || !int.TryParse(cell[1], out _))
        {
            return false;
        }
    }

    return true;
}

static List<string[]> SortTable(string path)
{
    List<string[]> table = new List<string[]>();

    foreach (string line in File.ReadLines(path))
    {
        if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("#"))
        {
            table.Add(line.Split(';'));
        }
    }
    
    table.Sort((a, b) => int.Parse(a[1]).CompareTo(int.Parse(b[1])));

    return table;
}

static void PrintTable(List<string[]> table)
{
    StringBuilder sb = new StringBuilder();
    foreach (var line in table)
    {
        foreach (var cell in line)
        {
            sb.Append(cell);
            sb.Append(' ');
        }
        sb.AppendLine();
    }
    Console.Write(sb.ToString());
}


if (File.Exists(path))
{
    if (IsLegal(path))
    {
        PrintTable(SortTable(path));
    }
    else
    {
        Console.WriteLine("Формат файла не соответствует требованиям");
    }
}
else
{
    Console.WriteLine("указан неверный путь к файлу или он не существует");
}