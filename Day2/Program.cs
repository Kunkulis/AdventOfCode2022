enum Outcome
{
    Win,
    Lose,
    Draw
}

enum Choice
{
    Rock,
    Paper,
    Scissors
}
class Program
{
    public static void Main(string[] args)
    {
        var input = File.ReadAllLines("input.txt");
        int totalScore = 0;
        foreach (var line in input)
        {
            totalScore += DidIWin(line) switch
            {
                Outcome.Win => 6,
                Outcome.Draw => 3,
                Outcome.Lose => 0,
                _ => throw new Exception()
            };

            totalScore += MyChoice(line.Split(' ')[1]);
        }
        Console.WriteLine(totalScore);
        totalScore = 0;

        foreach (var line in input)
        {
            totalScore += RoundOutcome(line.Split(' ')[1]) switch
            {
                Outcome.Win => 6,
                Outcome.Draw => 3,
                Outcome.Lose => 0,
                _ => throw new Exception()
            };

            totalScore += WhatToChose(line);
        }
        Console.WriteLine(totalScore);
    }

    private static int WhatToChose(string line) => line switch
    {
        "A X" => 3,//Lose
        "A Y" => 1,//Draw
        "A Z" => 2,//Win
        "B X" => 1,//Lose
        "B Y" => 2,//Draw
        "B Z" => 3,//Win
        "C X" => 2,//Lose
        "C Y" => 3,//Draw
        "C Z" => 1,//Win
        _ => throw new NotImplementedException()
    };   

    private static Outcome RoundOutcome(string line) => line switch
    {
        "X" => Outcome.Lose,
        "Y" => Outcome.Draw,
        "Z" => Outcome.Win,
        _ => throw new NotImplementedException()
    };

    private static Outcome DidIWin(string line) => line switch
    {
        "A X" => Outcome.Draw,
        "A Y" => Outcome.Win,
        "A Z" => Outcome.Lose,
        "B X" => Outcome.Lose,
        "B Y" => Outcome.Draw,
        "B Z" => Outcome.Win,
        "C X" => Outcome.Win,
        "C Y" => Outcome.Lose,
        "C Z" => Outcome.Draw,
        _ => throw new NotImplementedException()
    };

    private static int MyChoice(string v) => v switch
    {
        "X" => 1,
        "Y" => 2,
        "Z" => 3
    };

}