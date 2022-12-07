var rawInput = File.ReadAllLines("input.txt");
var moves = rawInput.Skip(10).ToList();
string[,] crates = new string[8,100];

for (int i = 0; i < 9; i++)
{
    var line = rawInput[i].Split("   ");
    for (int j = 0; j < line.Length; j++)
    {
        crates[i, j] = line[j];
    }
}