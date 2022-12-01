var input = File.ReadAllLines("input.txt");

var results = new List<int>();
var elf = 0;

foreach (var line in input)
{
    if (line.Length == 0)
    {
        results.Add(elf);
        elf = 0;
    }
    else
    {
        elf+=int.Parse(line);
    }
}

Console.WriteLine(results.Max());
Console.WriteLine(results.OrderByDescending(x=>x).Take(3).Sum());