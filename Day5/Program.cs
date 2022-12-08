using System.Collections;

var rawInputGrouped = File.ReadAllText("input.txt").Split("\r\n\r\n");
var moveInstructions = rawInputGrouped[1].Split(Environment.NewLine);
var crateRows = rawInputGrouped[0].Split(Environment.NewLine);
var crateNumberRow = crateRows.Last();
var lablePositions = GetLabelPositions(crateNumberRow);
var crateStacks = PopulateCrateStacks(lablePositions, crateRows);

foreach (var item in moveInstructions)
{
    var (transferCount, from, to) = ParseInstructino(item);
    //PART1 
    //for (int i = 0; i < transferCount; i++)
    //{
    //    var crate = crateStacks[from].Pop();
    //    crateStacks[to].Push(crate);
    //}
    //PART2
    crateStacks[from].ToArray()
       .Take(transferCount)
       .Reverse().ToList()
       .ForEach(supply =>
       {
           crateStacks[from].Pop();
           crateStacks[to].Push(supply);
       });
}

Console.WriteLine(string.Join("", crateStacks.Select(crateStack => (char)(crateStack.Value.Peek() ?? "")).ToList()));


(int transferCount, int from, int to) ParseInstructino(string item)
{
    var groupedRow = item.Split(' ');
    var transferCount = int.Parse(groupedRow[1]);
    var from = int.Parse(groupedRow[3]);
    var to = int.Parse(groupedRow[5]);

    return (transferCount, from, to);
}

Dictionary<int, Stack> PopulateCrateStacks(IReadOnlyList<int> lablePositions, IReadOnlyList<string> crateRows)
{
    var stacks = new Dictionary<int, Stack>();
    for (int i = 0; i < crateRows.Count; i++) stacks.Add(i + 1, new Stack());

    for (int i = 0; i < lablePositions.Count; i++)
    {
        var cratePosition = lablePositions[i];
        for (int j = crateRows.Count - 1; j >= 0; j--)
        {
            var row = crateRows[j];
            var crate = row[cratePosition];
            if (char.IsLetter(crate)) stacks[i + 1].Push(crate);
        }
    }
    return stacks;
}

List<int> GetLabelPositions(string row)
{
    var positions = new List<int>();
    for (int i = 0; i < row.Length; i++)
    {
        if (char.IsDigit(row[i]))
        {
            positions.Add(i);
        }
    }

    return positions;
}