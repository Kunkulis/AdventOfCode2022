var input = File.ReadAllText("input.txt");

var position = 0;

for (int i = 0; i < input.Length; i++)
{
    var sub = input.Substring(i, 4);
    if (sub.Distinct().Count() == sub.Length)
    {
        position = i + 4;
        break;
    }
}
Console.WriteLine(position);

position = 0;
for (int i = 0; i < input.Length; i++)
{
    var sub = input.Substring(i, 14);
    if (sub.Distinct().Count() == sub.Length)
    {
        position = i + 14;
        break;
    }
}
Console.WriteLine(position);