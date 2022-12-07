var input = File.ReadAllLines("input.txt");

var count = 0;
var part2 = 0;

foreach (var item in input)
{
    var first = ReturnNumberList(item.Split(',')[0].Split('-'));
    var second = ReturnNumberList(item.Split(',')[1].Split('-'));

    var matches = first.Intersect(second).Count();

    if (matches == first.Length || second.Length == matches)
        count++;

    if (first.Intersect(second).Count() > 0) 
        part2++;
}

Console.WriteLine(count);
Console.WriteLine(part2);

int[] ReturnNumberList(string[] section)
{
    var list = new List<int>();
    for (int i = int.Parse(section[0]); i <= int.Parse(section[1]); i++)
    {
        list.Add(i);
    }
    return list.ToArray();
}