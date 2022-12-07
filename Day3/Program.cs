var input = File.ReadAllLines("input.txt").ToList();

var priorityDictionray = new Dictionary<char, int>();
for (char i = 'a'; i <= 'z'; i++) priorityDictionray.Add(i, i - 'a' + 1);
for (char i = 'A'; i <= 'Z'; i++) priorityDictionray.Add(i, i - 'A' + 27);

var sum = 0;

foreach (var item in input)
{
    var first = item.Take(item.Length / 2);
    var second = item.Skip(item.Length / 2);

    sum += priorityDictionray[first.Intersect(second).FirstOrDefault()];
}
Console.WriteLine(sum);
sum = 0;

for (int i = 0; i < input.Count; i+=3)
{
    var first = input[i];
    var second = input[i+1];
    var third = input[i+2];

    sum += priorityDictionray[first.Intersect(second).Intersect(third).FirstOrDefault()];
}

Console.WriteLine(sum);